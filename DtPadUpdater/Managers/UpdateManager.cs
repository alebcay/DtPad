using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using DtPadUpdater.Exceptions;
using DtPadUpdater.Utils;

namespace DtPadUpdater.Managers
{
    /// <summary>
    /// Update operations manager.
    /// </summary>
    /// <author>Marco Macci�</author>
    internal static class UpdateManager
    {
        private const String className = "UpdateManager";

        #region Internal Methods

        internal static String CheckChangeLog(String executablePath, String culture, out WebException exception)
        {
            exception = null;

            WebClient webClient = null;
            String fileContent;

            try
            {
                webClient = ProxyUtil.InitWebClientProxy(executablePath, culture);
                fileContent = webClient.DownloadString(ProxyUtil.GetRepository() + "dtpad-changelog.log");
            }
            catch (WebException webException)
            {
                exception = webException;
                return String.Empty;
            }
            finally
            {
                if (webClient != null)
                {
                    webClient.Dispose();
                }
            }

            return fileContent;
        }

        internal static bool UpdateProcess(Form1 form, String executablePath, TextBox updateTextBox, ProgressBar updateProgressBar, String culture, out String fromVersion, out String toVersion)
        {
            bool updateFounded = false;
            fromVersion = String.Empty;
            toVersion = String.Empty;
            String updateBackupPath = Path.Combine(executablePath, "UpdateBackup");

            try
            {
                if (Directory.Exists(updateBackupPath))
                {
                    foreach (String fileAndPathName in Directory.GetFiles(updateBackupPath))
                    {
                        BeginReadOnlyCheck(fileAndPathName);
                    }
                    Directory.Delete(updateBackupPath, true);
                }
                updateTextBox.Text = LanguageUtil.GetCurrentLanguageString("Backup", className, culture);
                form.Refresh();

                Directory.CreateDirectory(updateBackupPath);
                foreach (String fileAndPathName in Directory.GetFiles(executablePath))
                {
                    String fileName = Path.GetFileName(fileAndPathName);

                    if (fileName != "DtPadUpdater.exe" && fileName != "log4net.dll" && fileName != "DtPadUpdater.pdb" && fileName != "DtPadUpdater.vshost.exe")
                    {
                        if (IsFileInUse(fileAndPathName))
                        {
                            throw new FileException(String.Format("{0}: {1}", LanguageUtil.GetCurrentLanguageString("FileInUse", className, culture), fileAndPathName));
                        }

                        File.Copy(fileName, Path.Combine(updateBackupPath, fileName));
                    }
                }
                updateProgressBar.PerformStep(); //1
                updateTextBox.Text = updateTextBox.Text + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Read", className, culture);

                WebClient webClient = ProxyUtil.InitWebClientProxy(executablePath, culture);

                fromVersion = AssemblyUtil.GetAssemblyVersion(updateBackupPath, "DtPad.exe");
                toVersion = webClient.DownloadString(ProxyUtil.GetRepository() + "dtpad-lastversion.log");

                String fileContent = webClient.DownloadString(ProxyUtil.GetRepository() + "dtpad-versioning.log");
                String[] split0 = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String t in split0)
                {
                    if (t.StartsWith(ConstantUtil.commentStart))
                    {
                        continue; //Log comment row, the search continues from next log row
                    }

                    String[] split1 = t.Split(new[] { "�" }, StringSplitOptions.RemoveEmptyEntries);
                    String[] split2 = split1[0].Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                    if (split2[0] != fromVersion)
                    {
                        continue; //Log update row different from desiderd, the search continues from next log row
                    }

                    updateFounded = true;

                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Update", className, culture);
                    form.Refresh();

                    String[] split3 = split1[1].Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                    updateProgressBar.PerformStep(); //2

                    int remainingPBSteps = updateProgressBar.Maximum - updateProgressBar.Value;
                    updateProgressBar.Step = Convert.ToInt32(Math.Floor(Convert.ToDecimal(remainingPBSteps / split3.Length)));

                    foreach (String t1 in split3)
                    {
                        String[] split4 = t1.Split(new[] { "%" }, StringSplitOptions.RemoveEmptyEntries);

                        SwitchActions(form, split4[0], split4[1], executablePath, updateTextBox, webClient, culture);
                        updateProgressBar.PerformStep(); //n
                    }

                    form.Refresh();
                }

                webClient.Dispose();

                if (updateProgressBar.Value < updateProgressBar.Maximum)
                {
                    updateProgressBar.Value = updateProgressBar.Maximum;
                }

                if (updateFounded)
                {
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Success", className, culture);
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Launch", className, culture);
                }
                else
                {
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("NoInfo", className, culture);
                }
            }
            catch (Exception exception)
            {
                updateProgressBar.Value = 0;
                updateTextBox.Text = updateTextBox.Text + Environment.NewLine + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Error", className, culture) + Environment.NewLine + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("Proxy", className, culture), ConstantUtil.dtShortURL);
                updateTextBox.Text = updateTextBox.Text + Environment.NewLine + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Exception", className, culture) + " " + exception.Message;

                foreach (String fileAndPathName in Directory.GetFiles(updateBackupPath))
                {
                    String fileName = Path.GetFileName(fileAndPathName);
                    BeginReadOnlyCheck(Path.Combine(executablePath, fileName));
                    File.Delete(Path.Combine(executablePath, fileName));
                    File.Move(fileAndPathName, Path.Combine(executablePath, fileName));
                }

                return false;
            }
            finally
            {
                if (Directory.Exists(updateBackupPath))
                {
                    foreach (String fileAndPathName in Directory.GetFiles(updateBackupPath))
                    {
                        BeginReadOnlyCheck(fileAndPathName);
                    }
                    Directory.Delete(updateBackupPath, true);
                }
            }

            return true;
        }

        internal static bool IsUpdaterVersionUpdated(String executablePath, TextBox updateTextBox, String culture)
        {
            String lastVersion;
            WebClient webClient = ProxyUtil.InitWebClientProxy(executablePath, culture);
            String repository = ProxyUtil.GetRepository();

            try
            {
                lastVersion = webClient.DownloadString(String.Format("{0}dtpadupdater-lastversion.log", repository));
            }
            catch (WebException)
            {
                updateTextBox.Text = updateTextBox.Text + LanguageUtil.GetCurrentLanguageString("ErrorCheckVersion", className, culture);
                updateTextBox.Text = updateTextBox.Text + Environment.NewLine + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("Proxy", className, culture), ConstantUtil.dtShortURL);
                return false;
            }
            finally
            {
                webClient.Dispose();
            }

            if (AssemblyUtil.AssemblyVersion != lastVersion)
            {
                updateTextBox.Text = updateTextBox.Text + LanguageUtil.GetCurrentLanguageString("OldVersion", className, culture);
                return false;
            }

            return true;
        }

        internal static void CommitUpdate(bool isUserAdmin, String outcome, String fromVersion, String toVersion, String executablePath, String culture)
        {
            if (isUserAdmin)
            {
                return;
            }

            try
            {
                using (WebClient webClient = ProxyUtil.InitWebClientProxy(executablePath, culture))
                {
                    webClient.Headers.Add("user-agent", String.Format("DtPad Updater ({0})", AssemblyUtil.AssemblyVersion));
                    webClient.DownloadString(String.Format("{0}updates.php?from={1}&to={2}&env=prod&out={3}", ConstantUtil.actionsRepository, fromVersion, toVersion, outcome));
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool IsFileInUse(String fileName)
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

        private static void SwitchActions(Form1 form, String action, String value, String executablePath, Control updateTextBox, WebClient webClient, String culture)
        {
            String[] separator = { "!" };
            String[] valueSplit;
            bool wasReadOnly;
            String filename;
            String repository = ProxyUtil.GetRepository();

            switch (action)
            {
                case "INS_FILE":
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("INS_FILE", className, culture), value);
                    webClient.DownloadFile(repository + "/dtpad-repository/" + value, Path.Combine(executablePath, value));
                    FileUtil.SetFilePermissions(Path.Combine(executablePath, value));
                    break;
                case "INS_KEY":
                    valueSplit = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("INS_KEY", className, culture), valueSplit[0]);
                    ConfigUtil.InsertParameter(valueSplit[0], valueSplit[1], executablePath);
                    break;
                case "INS_DIR":
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("INS_DIR", className, culture), value);
                    Directory.CreateDirectory(Path.Combine(executablePath, value));
                    FileUtil.SetDirPermissions(Path.Combine(executablePath, value));
                    break;

                case "UPD_FILE":
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("UPD_FILE", className, culture), value);
                    filename = Path.Combine(executablePath, value);
                    wasReadOnly = BeginReadOnlyCheck(filename);
                    webClient.DownloadFile(repository + "/dtpad-repository/" + value, Path.Combine(executablePath, value));
                    EndReadOnlyCheck(filename, wasReadOnly);
                    FileUtil.SetFilePermissions(Path.Combine(executablePath, value));
                    break;
                case "UPD_KEY":
                    valueSplit = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    String parameterValue = String.Empty;
                    if (valueSplit.Length > 1)
                    {
                        parameterValue = valueSplit[1];
                    }
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("UPD_KEY", className, culture), valueSplit[0]);
                    ConfigUtil.UpdateParameter(valueSplit[0], parameterValue, executablePath);
                    break;

                case "DEL_FILE":
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("DEL_FILE", className, culture), value);
                    filename = Path.Combine(executablePath, value);
                    BeginReadOnlyCheck(filename);
                    File.Delete(filename);
                    break;
                case "DEL_KEY":
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("DEL_KEY", className, culture), value);
                    ConfigUtil.DeleteParameter(value, executablePath);
                    break;

                case "REN_FILE":
                    valueSplit = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("REN_FILE", className, culture), valueSplit[0], valueSplit[1]);
                    String originalFilename = Path.Combine(executablePath, valueSplit[0]);
                    String modifiedFilename = Path.Combine(executablePath, valueSplit[1]);
                    wasReadOnly = BeginReadOnlyCheck(originalFilename);
                    File.Move(originalFilename, modifiedFilename);
                    EndReadOnlyCheck(modifiedFilename, wasReadOnly);
                    FileUtil.SetFilePermissions(Path.Combine(executablePath, value));
                    break;
                case "REN_KEY":
                    valueSplit = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + String.Format(LanguageUtil.GetCurrentLanguageString("REN_KEY", className, culture), valueSplit[0], valueSplit[1]);
                    ConfigUtil.RenameParameter(valueSplit[0], valueSplit[1], executablePath);
                    break;

                case "SHW_MSG":
                    String message = LanguageUtil.GetCurrentLanguageString(String.Format("SHW_MSG_{0}", value), className, culture);
                    updateTextBox.Text = updateTextBox.Text + Environment.NewLine + message;
                    WindowManager.ShowAlertProgramBox(form, message, culture);
                    break;
            }
        }

        private static bool BeginReadOnlyCheck(String filePathAndName)
        {
            FileInfo fileInfo = new FileInfo(filePathAndName);

            if (fileInfo.IsReadOnly)
            {
                fileInfo.IsReadOnly = false;
                return true;
            }

            return false;
        }

        private static void EndReadOnlyCheck(String filePathAndName, bool wasReadOnly)
        {
            FileInfo fileInfo = new FileInfo(filePathAndName);

            if (wasReadOnly)
            {
                fileInfo.IsReadOnly = true;
            }
        }

        #endregion Private Methods
    }
}
