using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AppLimit.CloudComputing.SharpBox.Common.Net.Web;
using AppLimit.CloudComputing.SharpBox;
using AppLimit.CloudComputing.SharpBox.Exceptions;
using AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox;
using DevExpress.XtraTab;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Dropbox manager.
    /// </summary>
    /// <author>Marco Macciò, external source</author>
    internal static class DropboxManager
    {
        private const String className = "DropboxManager";

        #region Storage Methods

        internal static bool IsCloudStorageOpen(CloudStorage cloudStorage)
        {
            return (cloudStorage != null && cloudStorage.IsOpened);
        }

        internal static CloudStorage InitCouldStorage(Form1 form, CloudStorage cloudStorage)
        {
            if (IsCloudStorageOpen(cloudStorage))
            {
                return cloudStorage;
            }

            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            try
            {
                if (ConfigUtil.GetBoolParameter("ProxyEnabled"))
                {
                    if (String.IsNullOrEmpty(ConfigUtil.GetStringParameter("ProxyHost")))
                    {
                        WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ProxyHostRequired", className));
                        return null;
                    }

                    WebRequestManager.Instance.SetProxySettings(ConfigUtil.GetStringParameter("ProxyHost"), ConfigUtil.GetIntParameter("ProxyPort"), ProxyUtil.InitNetworkCredential());
                }

                DropBoxConfiguration standardConfiguration = DropBoxConfiguration.GetStandardConfiguration();

                try //I try to authenticate myself with previous access token
                {
                    using (Stream tokenStream = new MemoryStream(Encoding.UTF8.GetBytes(ConfigUtil.GetStringParameter("LastDropboxAccessToken"))))
                    { 
                        if (tokenStream.Length == 0)
                        {
                            throw new UnauthorizedAccessException();
                        }

                        cloudStorage = new CloudStorage();
                        cloudStorage.Open(standardConfiguration, cloudStorage.DeserializeSecurityToken(tokenStream)); //cloudStorage.DeserializeSecurityToken(tokenStream, standardConfiguration)
                    }
                }
                catch (Exception) //No way, I should renew my access token
                {
                    standardConfiguration.AuthorizationCallBack = new Uri(ConstantUtil.dropboxAuthUrl);
                    DropBoxRequestToken requestToken = DropBoxStorageProviderTools.GetDropBoxRequestToken(standardConfiguration, ConstantUtil.dropboxConsumerKey, ConstantUtil.dropboxConsumerSecret);

                    if (requestToken == null)
                    {
                        throw new UnauthorizedAccessException();
                    }

                    if (WindowManager.ShowInternalBrowser(form, DropBoxStorageProviderTools.GetDropBoxAuthorizationUrl(standardConfiguration, requestToken)) == DialogResult.Cancel)
                    {
                        return null;
                    }

                    //OtherManager.StartProcess(form, DropBoxStorageProviderTools.GetDropBoxAuthorizationUrl(standardConfiguration, requestToken));
                    //if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("SuccessfullyAuth", className)) != DialogResult.Yes)
                    //{
                    //    return null;
                    //}

                    ICloudStorageAccessToken accessToken = DropBoxStorageProviderTools.ExchangeDropBoxRequestTokenIntoAccessToken(standardConfiguration, ConstantUtil.dropboxConsumerKey, ConstantUtil.dropboxConsumerSecret, requestToken);

                    if (accessToken == null)
                    {
                        throw new UnauthorizedAccessException();
                    }

                    cloudStorage = new CloudStorage();
                    cloudStorage.Open(standardConfiguration, accessToken);

                    if (ConfigUtil.GetBoolParameter("RememberDropboxAccess"))
                    {
                        using (Stream tokenStream = cloudStorage.SerializeSecurityToken(accessToken))
                        {
                            ConfigUtil.UpdateParameter("LastDropboxAccessToken", new StreamReader(tokenStream).ReadToEnd());
                        }
                    }
                    else
                    {
                        ConfigUtil.UpdateParameter("LastDropboxAccessToken", String.Empty);
                    }

                    toolStripStatusLabel.Text = LanguageUtil.GetCurrentLanguageString("DropboxLogIn", className);
                }

                return cloudStorage;
            }
            catch (UnauthorizedAccessException)
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("UnauthorizedAccess", className));
                return null;
            }
            catch (UriFormatException)
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("UriFormat", className));
                return null;
            }
        }

        internal static void CloseCouldStorage(Form1 form, CloudStorage cloudStorage)
        {
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            if (!IsCloudStorageOpen(cloudStorage))
            {
                return;
            }

            form.LastDropboxFolder = String.Empty;
            cloudStorage.Close();
            ConfigUtil.UpdateParameter("LastDropboxAccessToken", String.Empty);

            toolStripStatusLabel.Text = LanguageUtil.GetCurrentLanguageString("DropboxLogOut", className);
        }

        #endregion Storage Methods

        #region Folder Methods

        internal static IEnumerable<DropboxFSEObject> GetFolderContent(IEnumerable<ICloudFileSystemEntry> directory, String extensionFilter)
        {
            List<DropboxFSEObject> fseList = new List<DropboxFSEObject>();
            
            foreach (ICloudFileSystemEntry fsentry in directory)
            {
                if (fsentry is ICloudDirectoryEntry)
                {
                    fseList.Add(new DropboxFSEObject(fsentry.Name, DropboxFSEObject.FSEType.Directory));
                }
                else
                {
                    if (extensionFilter == "*.*")
                    {
                        fseList.Add(new DropboxFSEObject(fsentry.Name, DropboxFSEObject.FSEType.File));
                    }
                    else if (fsentry.Name.EndsWith(extensionFilter.Substring(2)))
                    {
                        fseList.Add(new DropboxFSEObject(fsentry.Name, DropboxFSEObject.FSEType.File));
                    }
                }
            }

            return fseList;
        }

        internal static bool CreateDirectoryOnDropbox(Form1 form, String directoryName, ICloudDirectoryEntry parent)
        {
            if (ExistsChildOnDropbox(parent, directoryName))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ExistsFolderOnDropbox", className));
                return false;
            }

            ICloudDirectoryEntry dir = form.DropboxCloudStorage.CreateFolder(directoryName, parent);
            return dir != null;
        }

        internal static ICloudDirectoryEntry GetDirectory(Form1 form, String directoryPath)
        {
            if (directoryPath.LastIndexOf('/') <= 0)
            {
                return form.DropboxCloudStorage.GetFolder(directoryPath, form.DropboxCloudStorage.GetRoot(), true);
            }

            int startPosition = directoryPath.LastIndexOf('/') + 1;
            return form.DropboxCloudStorage.GetFolder(directoryPath.Substring(startPosition, directoryPath.Length - startPosition),
                form.DropboxCloudStorage.GetFolder(directoryPath.Substring(0, directoryPath.LastIndexOf('/'))), true);
        }

        internal static bool ExistsDirectory(Form1 form, String directoryPath)
        {
            try
            {
                if (directoryPath.LastIndexOf('/') <= 0)
                {
                    form.DropboxCloudStorage.GetFolder(directoryPath, form.DropboxCloudStorage.GetRoot(), true);
                    return true;
                }

                int startPosition = directoryPath.LastIndexOf('/') + 1;
                form.DropboxCloudStorage.GetFolder(directoryPath.Substring(startPosition, directoryPath.Length - startPosition),
                    form.DropboxCloudStorage.GetFolder(directoryPath.Substring(0, directoryPath.LastIndexOf('/'))), true);
                return true;
            }
            catch (SharpBoxException)
            {
                return false;
            }
        }

        internal static String GetFolderCompletePath(ICloudDirectoryEntry directory)
        {
            String result = directory.Name;

            if (directory.Parent == null)
            {
                return "/";
            }

            while (directory.Parent != null)
            {
                if (String.IsNullOrEmpty(directory.Parent.Name))
                {
                    result = "/" + result;
                }
                else
                {
                    result = directory.Parent.Name + "/" + result;
                }

                directory = directory.Parent;
            }

            return result;
        }

        internal static bool RenameFolder(Form1 form, ICloudDirectoryEntry directory, String newFolderName)
        {
            String question = String.Format(LanguageUtil.GetCurrentLanguageString("SureRenameFolder", className), directory.Name, newFolderName);
            if (WindowManager.ShowQuestionBox(form, question) == DialogResult.No)
            {
                return false;
            }

            if (form.DropboxCloudStorage.RenameFileSystemEntry(directory, newFolderName) == false)
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("WarningRenaming", className));
                return false;
            }

            return true;
        }

        internal static void DeleteFolder(Form1 form, ICloudDirectoryEntry directory)
        {
            if (!ConfigUtil.GetBoolParameter("EnableDropboxDelete"))
            {
                return;
            }

            String question = String.Format(LanguageUtil.GetCurrentLanguageString("SureDeleteFolder", className), directory.Name);
            if (WindowManager.ShowQuestionBox(form, question) == DialogResult.No)
            {
                return;
            }

            if (!form.DropboxCloudStorage.DeleteFileSystemEntry(directory))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("WarningDeleting", className));
            }
        }

        #endregion Folder Methods

        #region File Methods

        internal static bool ExistsChildOnDropbox(ICloudDirectoryEntry directory, String childName)
        {
            try
            {
                ICloudFileSystemEntry file = directory.GetChild(childName);
                return file != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static String GetFileFromDropbox(ICloudDirectoryEntry directory, String fileName, out bool fileExists)
        {
            fileExists = false;
            if (!ExistsChildOnDropbox(directory, fileName))
            {
                return String.Empty;
            }

            ICloudFileSystemEntry file = directory.GetChild(fileName);

            String content;
            using (Stream streamFile = file.GetDataTransferAccessor().GetDownloadStream())
            {
                using (StreamReader reader = new StreamReader(streamFile, Encoding.UTF8))
                {
                    content = reader.ReadToEnd();
                }
            }

            fileExists = true;
            return content;
        }

        internal static void SaveFileOnDropbox(Form1 form1, ICloudDirectoryEntry directory, String fileName, String content)
        {
            SaveFile(form1.pagesTabControl, form1.DropboxCloudStorage, directory, fileName, content);
        }
        private static void SaveFile(XtraTabControl pagesTabControl, CloudStorage cloudStorage, ICloudDirectoryEntry dir, String fileName, String content)
        {
            Stream data = null;
            Encoding fileEncoding = EncodingUtil.GetDefaultEncoding();
            if (pagesTabControl != null)
            {
                fileEncoding = TabUtil.GetTabTextEncoding(pagesTabControl.SelectedTabPage);
            }

            byte[] contentBytes = fileEncoding.GetBytes(content); //Convert actual encoding to UTF8 (Dropbox standard)
            if (fileEncoding != Encoding.UTF8)
            {
                contentBytes = Encoding.Convert(fileEncoding, Encoding.UTF8, fileEncoding.GetBytes(content));
            }

            try
            {
                data = new MemoryStream(contentBytes);
                cloudStorage.UploadFile(data, fileName, dir);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                }
            }
        }

        internal static bool RenameFile(Form1 form, ICloudDirectoryEntry directory, String fileName, String newFileName)
        {
            String question = String.Format(LanguageUtil.GetCurrentLanguageString("SureRenameFile", className), fileName, newFileName);
            if (WindowManager.ShowQuestionBox(form, question) == DialogResult.No)
            {
                return false;
            }

            ICloudFileSystemEntry file = directory.GetChild(fileName);

            if (form.DropboxCloudStorage.RenameFileSystemEntry(file, newFileName) == false)
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("WarningRenaming", className));
                return false;
            }

            return true;
        }

        internal static void DeleteFile(Form1 form, ICloudDirectoryEntry directory, String fileName)
        {
            if (!ConfigUtil.GetBoolParameter("EnableDropboxDelete"))
            {
                return;
            }

            String question = String.Format(LanguageUtil.GetCurrentLanguageString("SureDeleteFile", className), fileName);
            if (WindowManager.ShowQuestionBox(form, question) == DialogResult.No)
            {
                return;
            }

            ICloudFileSystemEntry file = directory.GetChild(fileName);

            if (!form.DropboxCloudStorage.DeleteFileSystemEntry(file))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("WarningDeleting", className));
            }
        }

        #endregion File Methods

        #region Other Methods

        internal static bool StringContainsCharNotAllowed(String name)
        {
            //The following characters are not allowed: \ / : ? * < > " |
            if (name.Contains("\\") || name.Contains("/") || name.Contains(":") || name.Contains("?") || name.Contains("*") || name.Contains("<") || name.Contains(">") || name.Contains("\"") || name.Contains("|"))
            {
                return true;
            }

            return false;
        }

        #endregion Other Methods
    }
}
