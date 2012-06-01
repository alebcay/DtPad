using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;

namespace DtPad.Utils
{
    /// <summary>
    /// File system util.
    /// </summary>
    /// <author>Marco Macciò, external source</author>
    internal static class FileUtil
    {
        private const String className = "FileUtil";

        #region Internal Methods

        internal static String EvaluateRelativePath(String mainDirPath, String absoluteFilePath)
        {
            String[] firstPathParts = mainDirPath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
            String[] secondPathParts = absoluteFilePath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);

            int sameCounter = 0;

            for (int i = 0; i < Math.Min(firstPathParts.Length, secondPathParts.Length); i++)
            {
                if (!firstPathParts[i].ToLower().Equals(secondPathParts[i].ToLower()))
                {
                    break;
                }

                sameCounter++;
            }

            if (sameCounter == 0)
            {
                if (!absoluteFilePath.EndsWith(@"\"))
                {
                    absoluteFilePath += @"\";
                }

                return absoluteFilePath;
            }

            String newPath = String.Empty;
            for (int i = sameCounter; i < firstPathParts.Length; i++)
            {
                newPath += @"..\";
            }

            for (int i = sameCounter; i < secondPathParts.Length; i++)
            {
                newPath += secondPathParts[i] + @"\";
            }

            return newPath;
        }

        internal static String EvaluateAbsolutePath(String mainDirPath, String relativeFilePath)
        {
            if (String.IsNullOrEmpty(relativeFilePath))
            {
                return mainDirPath;
            }
            if (relativeFilePath.Contains(":"))
            {
                return relativeFilePath;
            }

            Uri uriMainDirPath = new Uri(mainDirPath, true);
            int stepsBehind = StringUtil.SearchCountOccurences(relativeFilePath, @"..\");

            String returnPath = String.Empty;
            for (int i = 1; i < uriMainDirPath.Segments.Length - stepsBehind; i++)
            {
                returnPath = Path.Combine(returnPath, uriMainDirPath.Segments[i]); //.Replace("%20", " ")
            }

            //Up after down (if there are)
            if (stepsBehind > 0)
            {
                returnPath += relativeFilePath.Replace(@"..\", String.Empty);
            }
            else
            {
                returnPath = Path.Combine(returnPath, relativeFilePath);
            }

            return returnPath.Replace("/", @"\");
        }

        internal static IEnumerable<String> GetFiles(String sourceFolder, String filters, SearchOption searchOption)
        {
	        return filters.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries).SelectMany(filter => Directory.GetFiles(sourceFolder, filter.Trim(), searchOption)).ToArray();
        }

        internal static String ReadToEndWithEncoding(String absoluteFilePath)
        {
            Encoding fileEncoding;
            return ReadToEndWithEncoding(absoluteFilePath, out fileEncoding);
        }
        internal static String ReadToEndWithEncoding(String absoluteFilePath, out Encoding fileEncoding)
        {
            fileEncoding = EncodingUtil.GetFileEncoding(absoluteFilePath);
            StreamReader textFile = null;
            String fileContent;

            try
            {
                textFile = new StreamReader(absoluteFilePath, fileEncoding);
                fileContent = textFile.ReadToEnd();
            }
            finally
            {
                if (textFile != null)
                {
                    textFile.Close();
                }
            }

            if (ConfigUtil.GetBoolParameter("IgnoreNullChar"))
            {
                fileContent = fileContent.Replace("\0", String.Empty);
            }
            return fileContent;
        }

        internal static String ReadToEndWithStandardEncoding(String absoluteFilePath)
        {
            StreamReader textFile = null;
            String fileContent;

            try
            {
                textFile = new StreamReader(absoluteFilePath, Encoding.Default);
                fileContent = textFile.ReadToEnd();
            }
            finally
            {
                if (textFile != null)
                {
                    textFile.Close();
                }
            }

            return fileContent;
        }

        internal static String GetFileNameAndPath(Form1 form, String filter, int defaultExtension, String defaultExtensionShortString)
        {
            OpenFileDialog openFileDialog = form.openFileDialog;
            openFileDialog.InitialDirectory = ConfigUtil.GetStringParameter("LastUserFolder");
            openFileDialog.Filter = filter;
            openFileDialog.FilterIndex = defaultExtension;
            openFileDialog.FileName = defaultExtensionShortString;

            return openFileDialog.ShowDialog() != DialogResult.OK ? String.Empty : openFileDialog.FileName;
        }

        internal static void GetDefaultPath(Options form)
        {
            FolderBrowserDialog folderBrowserDialog = form.folderBrowserDialog;
            TextBox specificFolderTextBox = form.specificFolderTextBox;

            folderBrowserDialog.Description = LanguageUtil.GetCurrentLanguageString("folderDialogDefault", className);

            if (Directory.Exists(specificFolderTextBox.Text))
            {
                folderBrowserDialog.SelectedPath = specificFolderTextBox.Text;
            }
            else
            {
                folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }

            if (form.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                specificFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        internal static void GetBackupPath(Options form)
        {
            FolderBrowserDialog folderBrowserDialog = form.folderBrowserDialog;
            TextBox backupCustomFolderTextBox = form.backupCustomFolderTextBox;

            folderBrowserDialog.Description = LanguageUtil.GetCurrentLanguageString("folderDialogBackup", className);

            if (form.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                backupCustomFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        internal static String GetInitialFolder(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            String filename = ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage);

            if (!String.IsNullOrEmpty(filename) && ConfigUtil.GetBoolParameter("OverrideFolderWithActiveFile"))
            {
                String path = Path.GetDirectoryName(filename);
                if (!String.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    return path;
                }
            }

            return ConfigUtil.GetStringParameter(ConfigUtil.GetIntParameter("SettingFolder") == 1 ? "LastUserFolder" : "SpecificFolder");
        }

        internal static bool IsFileInUse(String fileName)
        {
            try
            {
                FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read);
                fileStream.Close();
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        internal static bool IsFileAlreadyOpen(Form1 form, String fileName, out XtraTabPage tabPageFound)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            tabPageFound = null;

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                if (ProgramUtil.GetFilenameTabPage(tabPage) == fileName)
                {
                    tabPageFound = tabPage;
                }
            }

            return tabPageFound != null;
        }

        internal static void SetFilePermissions(String fileNameAndPath)
        {
            FileInfo fInfo = new FileInfo(fileNameAndPath);
            FileSecurity fSecurity = fInfo.GetAccessControl();
            SystemUtil.OS operativeSystem = SystemUtil.GetOSInfo();

            String user = String.Format(@"{0}\{1}", Environment.UserDomainName, Environment.UserName);

            switch (operativeSystem)
            {
                case SystemUtil.OS.Seven:
                case SystemUtil.OS.Vista:
                    fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.FullControl, AccessControlType.Allow));
                    break;
            }

            fInfo.SetAccessControl(fSecurity);
        }

        #endregion Internal Methods
    }
}
