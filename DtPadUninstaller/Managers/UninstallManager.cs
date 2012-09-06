using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DtPadUninstaller.Utils;
using Microsoft.Win32;

namespace DtPadUninstaller.Managers
{
    /// <summary>
    /// Uninstall process manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class UninstallManager
    {
        private const String className = "UninstallManager";

        #region Internal Methods

        internal static void UninstallProcedure(Form1 form, String culture)
        {
            ProgressBar updateProgressBar = form.updateProgressBar;
            TextBox updateTextBox = form.updateTextBox;

            updateProgressBar.Maximum = 0;
            updateProgressBar.Value = 0;
            updateProgressBar.Step = 1;
            
            try
            {
                updateTextBox.AppendText(LanguageUtil.GetCurrentLanguageString("Start", className, culture));

                String[] fileFolders = Directory.GetDirectories(ConstantUtil.ApplicationExecutionPath());
                updateProgressBar.Maximum += fileFolders.Length;

                String desktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "DtPad.lnk");
                if (File.Exists(desktop))
                {
                    updateProgressBar.Maximum += 1;
                }

                String linkFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "DtPad");
                String[] links = new String[0];
                if (Directory.Exists(linkFolder))
                {
                    links = Directory.GetFiles(linkFolder, "*.*", SearchOption.TopDirectoryOnly);
                    updateProgressBar.Maximum += links.Length;
                }

                String[] files = Directory.GetFiles(ConstantUtil.ApplicationExecutionPath(), "*.*", SearchOption.AllDirectories);
                updateProgressBar.Maximum += files.Length;
                
                String sendto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SendTo), "DtPad.lnk");
                if (File.Exists(sendto))
                {
                    updateProgressBar.Maximum += 1;
                }

                //String openwith = String.Format(@"Software\Classes\*\shell\{0}\command", LanguageUtil.GetCurrentLanguageString("ShellString", className, culture));
                if (ExistsRegistry())
                {
                    updateProgressBar.Maximum += 1;
                }

                //Files
                updateTextBox.AppendText(Environment.NewLine + LanguageUtil.GetCurrentLanguageString("DeleteFiles", className, culture));
                foreach (String file in files)
                {
                    if (file == Path.Combine(ConstantUtil.ApplicationExecutionPath(), "DtPadUninstaller.exe"))
                    {
                        continue;
                    }

                    FileDelete(file, updateTextBox, updateProgressBar, culture);
                }

                //Desktop
                updateTextBox.AppendText(Environment.NewLine + LanguageUtil.GetCurrentLanguageString("DeleteDesktop", className, culture));
                if (File.Exists(desktop))
                {
                    FileDelete(desktop, updateTextBox, updateProgressBar, culture);
                }

                //Links
                updateTextBox.AppendText(Environment.NewLine + LanguageUtil.GetCurrentLanguageString("DeleteLinks", className, culture));
                foreach(String link in links)
                {
                    FileDelete(link, updateTextBox, updateProgressBar, culture);
                }

                //SendTo
                if (File.Exists(sendto))
                {
                    updateTextBox.AppendText(Environment.NewLine + LanguageUtil.GetCurrentLanguageString("DeleteSendTo", className, culture));
                    FileDelete(sendto, updateTextBox, updateProgressBar, culture);
                }

                //OpenWith
                if (ExistsRegistry())
                {
                    updateTextBox.AppendText(Environment.NewLine + LanguageUtil.GetCurrentLanguageString("DeleteOpenWith", className, culture));
                    RegistryDelete(updateTextBox, updateProgressBar, culture);
                }

                //File folders
                foreach(String fileFolder in fileFolders)
                {
                    FolderDelete(fileFolder, updateTextBox, updateProgressBar, culture);
                }

                //Link folder
                if (Directory.Exists(linkFolder))
                {
                    FolderDelete(linkFolder, updateTextBox, updateProgressBar, culture);
                }

                updateProgressBar.Value = updateProgressBar.Maximum;
                updateTextBox.AppendText(Environment.NewLine + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Success", className, culture));
            }
            catch (Exception exception)
            {
                updateTextBox.AppendText(Environment.NewLine + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Error", className, culture) + " " + exception.Message);
            }
        }

        #endregion Internal Methods

        #region Private Methods

        private static void FileDelete(String file, TextBoxBase updateTextBox, ProgressBar updateProgressBar, String culture)
        {
            if (!File.Exists(file))
            {
                updateProgressBar.PerformStep();
                return;
            }
            
            FileInfo info = new FileInfo(file);
            if (info.IsReadOnly)
            {
                info.IsReadOnly = false;
            }
            
            File.Delete(file);
            updateTextBox.AppendText(Environment.NewLine + LanguageUtil.GetCurrentLanguageString("File", className, culture) + " \"" + file + "\" " + LanguageUtil.GetCurrentLanguageString("DeletedFile", className, culture));
            updateProgressBar.PerformStep();
        }

        private static void FolderDelete(String folder, TextBoxBase updateTextBox, ProgressBar updateProgressBar, String culture)
        {
            if (!Directory.Exists(folder))
            {
                updateProgressBar.PerformStep();
                return;
            }
            
            Directory.Delete(folder, true);
            updateTextBox.AppendText(Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Folder", className, culture) + " \"" + folder + "\" " + LanguageUtil.GetCurrentLanguageString("DeletedFolder", className, culture));
            updateProgressBar.PerformStep();
        }

        private static void RegistryDelete(TextBoxBase updateTextBox, ProgressBar updateProgressBar, String culture)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\*\shell");

            if (regKey == null)
            {
                return;
            }

            String[] keys = regKey.GetSubKeyNames();
            foreach (String key in keys)
            {
                if (!key.Contains("DtPad"))
                {
                    continue;
                }

                //Registry.CurrentUser.DeleteSubKey(String.Format(@"Software\Classes\*\shell\{0}\command", key));
                Registry.CurrentUser.DeleteSubKeyTree(String.Format(@"Software\Classes\*\shell\{0}", key));

                updateTextBox.AppendText(Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Key", className, culture) + " \"" + key + "\" " + LanguageUtil.GetCurrentLanguageString("DeletedKey", className, culture));
                break;
            }

            updateProgressBar.PerformStep();
        }

        private static bool ExistsRegistry()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\*\shell");

            if (regKey == null)
            {
                return false;
            }

            String[] keys = regKey.GetSubKeyNames();
            //foreach (String key in keys)
            //{
            //    if (key.Contains("DtPad"))
            //    {
            //        return true;
            //    }
            //}
            return keys.Any(key => key.Contains("DtPad"));
        }

        #endregion Private Methods
    }
}
