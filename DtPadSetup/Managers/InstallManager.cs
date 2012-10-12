using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DtPadSetup.Utils;
using Microsoft.Win32;

namespace DtPadSetup.Managers
{
    /// <summary>
    /// Install steps manager.
    /// </summary>
    /// <remarks>Rem lines because of inline help disabled.</remarks>
    /// <author>Marco Macciò</author>
    internal static class InstallManager
    {
        private const String className = "InstallManager";
        
        #region Internal Methods

        internal static void InitInstallPanel(TextBox destinationPathTextBox, Label availableSpaceLabel1, Label requiredSpaceLabel1, ComboBox languageComboBox, String culture)
        {
            if (!String.IsNullOrEmpty(destinationPathTextBox.Text))
            {
                return;
            }

            destinationPathTextBox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "DtPad");
            RefreshInstallPanel(destinationPathTextBox, availableSpaceLabel1, requiredSpaceLabel1, languageComboBox, culture);
        }

        internal static void RefreshInstallPanel(TextBox destinationPathTextBox, Label availableSpaceLabel1, Label requiredSpaceLabel1, ComboBox languageComboBox, String culture)
        {
            if (String.IsNullOrEmpty(destinationPathTextBox.Text))
            {
                return;
            }

            DriveInfo selectedDrive = new DriveInfo("C");
            String driveVolumeLabel = destinationPathTextBox.Text.Substring(0, 3);
            DriveInfo[] actualDrive = DriveInfo.GetDrives();
            bool foundDrive = false;

            foreach (DriveInfo t in actualDrive)
            {
                if (t.Name.ToUpper() != driveVolumeLabel.ToUpper())
                {
                    continue;
                }

                selectedDrive = t;
                foundDrive = true;
                break;
            }

            long requiredSpace = FileResource.DtPad_exe.Length + FileResource.DtPad_exe_config.Length + FileResource.DtPad_exe_pw.Length + FileResource.DtPad_exe_fv.Length + FileResource.DtPad_exe_rf.Length +
                                 FileResource.DtPad_exe_ex.Length + FileResource.DtPad_exe_sh.Length + FileResource.DtPad_exe_to.Length + FileResource.DtPad_exe_no.Length + FileResource.DtPad_exe_cl.Length +
                                 FileResource.DtPad_exe_sf.Length + FileResource.DtPadUpdater_exe.Length + FileResource.DtHelp_exe.Length + FileResource.en_resources.Length + FileResource.it_resources.Length +
                                 FileResource.fr_resources.Length + FileResource.es_resources.Length + FileResource.License_txt.Length + FileResource.DevExpress_Data_v12_1_dll.Length +
                                 FileResource.DevExpress_Utils_v12_1_dll.Length + FileResource.DevExpress_XtraEditors_v12_1_dll.Length + FileResource.log4net_dll.Length + FileResource.ICSharpCode_SharpZipLib_dll.Length +
                                 FileResource.DtControls_dll.Length + FileResource.itextsharp_dll.Length + FileResource.Info_txt.Length + FileResource.DtPadUninstaller_exe.Length + FileResource.DtPad_exe_rs.Length +
                                 FileResource.DtPad_exe_tm.Length + FileResource.Be_Windows_Forms_HexBox_dll.Length + FileResource.DtPad_exe_rp.Length + FileResource.DtPad_exe_ru.Length + FileResource.XmlGridControl_dll.Length +
                                 FileResource.MonthCalendar_dll.Length + FileResource.AppLimit_CloudComputing_SharpBox_Net40_dll.Length + FileResource.Newtonsoft_Json_dll.Length + FileResource.Microsoft_WindowsAPICodePack_dll.Length +
                                 FileResource.Microsoft_WindowsAPICodePack_Shell_dll.Length + FileResource.NHunspell_dll.Length + FileResource.Hunspellx86_dll.Length + FileResource.Hunspellx64_dll.Length;
                                //+ GuideResource.DtPadGuide_en_dhg.Length + GuideResource.DtPadGuide_it_dhg.Length;

            double requiredMbSpace = (requiredSpace / 1024f) / 1024f;
            requiredSpaceLabel1.Text = requiredMbSpace.ToString("#,#", CultureInfo.GetCultureInfo(GetCulture(languageComboBox))) + " MB";

            if (foundDrive)
            {
                double freeMbSpace = (selectedDrive.TotalFreeSpace / 1024f) / 1024f;
                availableSpaceLabel1.Text = freeMbSpace.ToString("#,#", CultureInfo.GetCultureInfo(GetCulture(languageComboBox))) + " MB";
            }
            else
            {
                availableSpaceLabel1.Text = LanguageUtil.GetCurrentLanguageString("Unavailable", className, culture);
            }
        }

        internal static bool InstallProcedure(Form1 form, ProgressBar installProgressBar, TextBox installTextBox, String culture)
        {
            try
            {
                String destinationPath = form.destinationPathTextBox.Text;
                bool onlySetPermissions = false;

                if (Directory.Exists(destinationPath))
                {
                    DirectoryInfo destinationDir = new DirectoryInfo(destinationPath);
                    FileInfo[] destinationFiles = destinationDir.GetFiles();
                    
                    if (destinationFiles.Length > 0)
                    {
                        bool alreadyExistsDtPad = SearchDtPadFiles(destinationFiles);
                        String warningMessage = alreadyExistsDtPad ? "DestinationDirWithDtPad" : "DestinationDirWithFiles";

                        if (WindowManager.ShowWarningBox(form, LanguageUtil.GetCurrentLanguageString(warningMessage, className, culture), culture) != DialogResult.Yes)
                        {
                            installTextBox.Text = LanguageUtil.GetCurrentLanguageString("InstallInterrupted", className, culture);
                            return false;
                        }

                        if (alreadyExistsDtPad)
                        {
                            onlySetPermissions = true;
                        }
                    }
                }

                installProgressBar.Value = 0;

                installTextBox.Text = LanguageUtil.GetCurrentLanguageString("PreparingInstall", className, culture);
                form.Refresh();
                
                //Directories
                installTextBox.Text += Environment.NewLine + LanguageUtil.GetCurrentLanguageString("CreatingDir", className, culture);
                CreateDirAndSetPermissions(destinationPath);
                CreateDirAndSetPermissions(Path.Combine(destinationPath, "Guides"));
                CreateDirAndSetPermissions(Path.Combine(destinationPath, "Icons"));
                CreateDirAndSetPermissions(Path.Combine(destinationPath, "Icons\\JL"));
                CreateDirAndSetPermissions(Path.Combine(destinationPath, "Languages"));
                CreateDirAndSetPermissions(Path.Combine(destinationPath, "Logs"));
                CreateDirAndSetPermissions(Path.Combine(destinationPath, "SupportFiles"));
                CreateDirAndSetPermissions(Path.Combine(destinationPath, "InternetCache"));

                installProgressBar.PerformStep();

                //Executables and libraries
                installTextBox.Text += Environment.NewLine + LanguageUtil.GetCurrentLanguageString("ExtractingFile", className, culture);
                form.Refresh();
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "DtPad.exe"), FileResource.DtPad_exe);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "DtPadUpdater.exe"), FileResource.DtPadUpdater_exe);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "DtHelp.exe"), FileResource.DtHelp_exe);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "DtPadUninstaller.exe"), FileResource.DtPadUninstaller_exe);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "DevExpress.Data.v12.1.dll"), FileResource.DevExpress_Data_v12_1_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "DevExpress.Utils.v12.1.dll"), FileResource.DevExpress_Utils_v12_1_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "DevExpress.XtraEditors.v12.1.dll"), FileResource.DevExpress_XtraEditors_v12_1_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "log4net.dll"), FileResource.log4net_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "ICSharpCode.SharpZipLib.dll"), FileResource.ICSharpCode_SharpZipLib_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "DtControls.dll"), FileResource.DtControls_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "itextsharp.dll"), FileResource.itextsharp_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Be.Windows.Forms.HexBox.dll"), FileResource.Be_Windows_Forms_HexBox_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "XmlGridControl.dll"), FileResource.XmlGridControl_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "MonthCalendar.dll"), FileResource.MonthCalendar_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "AppLimit.CloudComputing.SharpBox.Net40.dll"), FileResource.AppLimit_CloudComputing_SharpBox_Net40_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Newtonsoft.Json.dll"), FileResource.Newtonsoft_Json_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Microsoft.WindowsAPICodePack.dll"), FileResource.Microsoft_WindowsAPICodePack_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Microsoft.WindowsAPICodePack.Shell.dll"), FileResource.Microsoft_WindowsAPICodePack_Shell_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Hunspellx86.dll"), FileResource.Hunspellx86_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Hunspellx64.dll"), FileResource.Hunspellx64_dll);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "NHunspell.dll"), FileResource.NHunspell_dll);
                installProgressBar.PerformStep();

                //Support files
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.fv"), FileResource.DtPad_exe_fv, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.ex"), FileResource.DtPad_exe_ex, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.no"), FileResource.DtPad_exe_no, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.rf"), FileResource.DtPad_exe_rf, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.rs"), FileResource.DtPad_exe_rs, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.rp"), FileResource.DtPad_exe_rp, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.sh"), FileResource.DtPad_exe_sh, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.to"), FileResource.DtPad_exe_to, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.tm"), FileResource.DtPad_exe_tm, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.cl"), FileResource.DtPad_exe_cl, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.sf"), FileResource.DtPad_exe_sf, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.ru"), FileResource.DtPad_exe_ru, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "SupportFiles\\DtPad.exe.pw"), FileResource.DtPad_exe_pw, onlySetPermissions);
                installProgressBar.PerformStep();
                
                //Language files
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Languages\\en.resources"), FileResource.en_resources);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Languages\\it.resources"), FileResource.it_resources);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Languages\\fr.resources"), FileResource.fr_resources);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Languages\\es.resources"), FileResource.es_resources);
                installProgressBar.PerformStep();
                
                //Guides
                //WriteFileAndSetPermissions(Path.Combine(destinationPath, "Guides\\DtPadGuide-en.dhg"), GuideResource.DtPadGuide_en_dhg);
                //WriteFileAndSetPermissions(Path.Combine(destinationPath, "Guides\\DtPadGuide-it.dhg"), GuideResource.DtPadGuide_it_dhg);
                installProgressBar.PerformStep();

                //Icons and txts
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\DtPad.ico"), FileResource.DtPad_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\DtPadUpdater.ico"), FileResource.DtPadUpdater_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\DtHelp.ico"), FileResource.DtHelp_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\DtPadUninstaller.ico"), FileResource.DtPadUninstaller_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\Dt.ico"), FileResource.Dt_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\JL\\WebSite.ico"), FileResource.WebSite_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\JL\\NewTab.ico"), FileResource.NewTab_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\JL\\OpenFile.ico"), FileResource.OpenFile_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\JL\\OpenSession.ico"), FileResource.OpenSession_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\JL\\SearchInFiles.ico"), FileResource.SearchInFiles_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "Icons\\JL\\CheckNewVersion.ico"), FileResource.CheckNewVersion_ico);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "DtPad.exe.Config"), FileResource.DtPad_exe_config, onlySetPermissions);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "InternetCache\\Info.txt"), FileResource.Info_txt);
                WriteFileAndSetPermissions(Path.Combine(destinationPath, "License.txt"), FileResource.License_txt);
                installProgressBar.PerformStep();

                //Shortcuts
                if (form.shortcutsCheckBox.Checked)
                {
                    installTextBox.Text += Environment.NewLine + LanguageUtil.GetCurrentLanguageString("CreatingShortcut", className, culture);
                    form.Refresh();

                    SetShortcuts(destinationPath, culture);
                }
                installProgressBar.PerformStep();

                //Associations
                if (form.sendToCheckBox.Checked)
                {
                    installTextBox.Text += Environment.NewLine + LanguageUtil.GetCurrentLanguageString("CreatingAssociation", className, culture);
                    form.Refresh();

                    SetSendToAssociation(destinationPath, culture);
                }
                if (form.shellCheckBox.Checked)
                {
                    installTextBox.Text += Environment.NewLine + LanguageUtil.GetCurrentLanguageString("IntegratingShell", className, culture);
                    form.Refresh();

                    if (!SetShellIntegration(destinationPath, culture))
                    {
                        installTextBox.Text += Environment.NewLine + LanguageUtil.GetCurrentLanguageString("IntegratingShellError", className, culture);
                    }
                }
                installProgressBar.PerformStep();

                //Settings (part 1)
                installTextBox.Text += Environment.NewLine + LanguageUtil.GetCurrentLanguageString("UpdatingSetting", className, culture);
                form.Refresh();
                ConfigUtil.UpdateParameter("ProxyEnabled", form.enableProxySettingsCheckBox.Checked.ToString(), destinationPath);
                ConfigUtil.UpdateParameter("StayOnTopDisabled", (!form.stayOnTopCheckBox.Checked).ToString(), destinationPath);
                ConfigUtil.UpdateParameter("MinimizeOnTrayIconDisabled", (!form.minimizeOnTrayIconCheckBox.Checked).ToString(), destinationPath);

                String[] passwordNames = { "ProxyUsername", "ProxyPassword", "ProxyDomain" };
                String[] passwordValues = { form.usernameTextBox.Text, CodingUtil.EncodeString(form.passwordTextBox.Text), form.domainTextBox.Text };
                PasswordUtil.UpdateParameters(passwordNames, passwordValues, destinationPath);

                installProgressBar.PerformStep();

                //Settings (part 2)
                if (form.dotNetRadioButton.Checked)
                {
                    ConfigUtil.UpdateParameter("LookAndFeel", "0", destinationPath);
                }
                else if (form.windowsRadioButton.Checked)
                {
                    ConfigUtil.UpdateParameter("LookAndFeel", "1", destinationPath);
                }
                ConfigUtil.UpdateParameter("Language", GetLongCulture(form.languageComboBox), destinationPath);
                installProgressBar.PerformStep();

                installTextBox.Text += Environment.NewLine + LanguageUtil.GetCurrentLanguageString("InstallComplete", className, culture);
                installTextBox.Text += Environment.NewLine + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("EndInfo", className, culture);
                
                return true;
            }
            catch (Exception exception)
            {
                installProgressBar.Value = 0;
                
                installTextBox.Text += Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Error1", className, culture) + Environment.NewLine + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Error2", className, culture);
                installTextBox.Text += Environment.NewLine + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("Exception", className, culture) + " " + exception.Message;

                return false;
            }
        }

        #endregion Internal Methods

        #region Culture Methods

        private static String GetCulture(ListControl languageComboBox)
        {
            String language;
            
            switch (languageComboBox.SelectedIndex)
            {
                case 0:
                    language = "en-GB";
                    break;
                case 1:
                    language = "it-IT";
                    break;

                default:
                    language = "en";
                    break;
            }

            return language;
        }

        private static String GetLongCulture(ListControl languageComboBox)
        {
            String language;

            switch (languageComboBox.SelectedIndex)
            {
                case 0:
                    language = "English";
                    break;
                case 1:
                    language = "Italiano";
                    break;

                default:
                    language = "English";
                    break;
            }

            return language;
        }

        #endregion Culture Methods

        #region Shortcuts And Association Methods

        private static void SetShortcuts(String destinationPath, String culture)
        {
            String deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            ShellShortcut shortcut = new ShellShortcut(Path.Combine(deskDir, "DtPad.lnk"))
                                         {
                                             Path = Path.Combine(destinationPath, "DtPad.exe"),
                                             WorkingDirectory = destinationPath,
                                             Description = LanguageUtil.GetCurrentLanguageString("LinkLaunchDtPad", className, culture),
                                             IconPath = Path.Combine(destinationPath, "Icons\\DtPad.ico")
                                         };
            shortcut.Save();

            String startDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "DtPad");
            if (!Directory.Exists(startDir))
            {
                Directory.CreateDirectory(startDir);
            }

            StreamWriter textFile = File.CreateText(Path.Combine(startDir, String.Format("{0}.url", LanguageUtil.GetCurrentLanguageString("LinkWebsite", className, culture))));
            textFile.WriteLine("[InternetShortcut]");
            textFile.WriteLine(String.Format("URL={0}", ConstantUtil.dtPadURL));
            textFile.WriteLine("IconIndex=0");
            textFile.WriteLine("IconFile=" + Path.Combine(destinationPath, "Icons\\Dt.ico"));
            textFile.Close();

            shortcut = new ShellShortcut(Path.Combine(startDir, "DtPad.lnk"))
                           {
                               Path = Path.Combine(destinationPath, "DtPad.exe"),
                               WorkingDirectory = destinationPath,
                               Description = LanguageUtil.GetCurrentLanguageString("LinkLaunchDtPad", className, culture),
                               IconPath = Path.Combine(destinationPath, "Icons\\DtPad.ico")
                           };
            shortcut.Save();

            shortcut = new ShellShortcut(Path.Combine(startDir, "DtPad Updater.lnk"))
                           {
                               Path = Path.Combine(destinationPath, "DtPadUpdater.exe"),
                               WorkingDirectory = destinationPath,
                               Description = LanguageUtil.GetCurrentLanguageString("LinkLaunchDtPadUpdater", className, culture),
                               IconPath = Path.Combine(destinationPath, "Icons\\DtPadUpdater.ico")
                           };
            shortcut.Save();

            shortcut = new ShellShortcut(Path.Combine(startDir, "DtPad Uninstaller.lnk"))
                           {
                               Path = Path.Combine(destinationPath, "DtPadUninstaller.exe"),
                               WorkingDirectory = destinationPath,
                               Description = LanguageUtil.GetCurrentLanguageString("LinkLaunchDtPadUninstaller", className, culture),
                               IconPath = Path.Combine(destinationPath, "Icons\\DtPadUninstaller.ico")
                           };
            shortcut.Save();

            //shortcut = new ShellShortcut(Path.Combine(startDir, LanguageUtil.GetCurrentLanguageString("LinkReadmeLabel", className, culture)))
            //               {
            //                  Path = Path.Combine(destinationPath, "Readme.txt"),
            //                  WorkingDirectory = destinationPath,
            //                  Description = LanguageUtil.GetCurrentLanguageString("LinkReadme", className, culture),
            //               };
            //shortcut.Save();
        }

        private static void SetSendToAssociation(String destinationPath, String culture)
        {
            String sendToDir = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);

            ShellShortcut shortcut = new ShellShortcut(Path.Combine(sendToDir, "DtPad.lnk"))
                                         {
                                             Path = Path.Combine(destinationPath, "DtPad.exe"),
                                             WorkingDirectory = destinationPath,
                                             Description = LanguageUtil.GetCurrentLanguageString("LinkLaunchDtPad", className, culture),
                                             IconPath = Path.Combine(destinationPath, "Icons\\DtPad.ico")
                                         };
            shortcut.Save();
        }

        private static bool SetShellIntegration(String destinationPath, String culture)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(String.Format(@"Software\Classes\*\shell\{0}", LanguageUtil.GetCurrentLanguageString("ShellString", className, culture)));
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(String.Format(@"Software\Classes\*\shell\{0}", LanguageUtil.GetCurrentLanguageString("ShellString", className, culture)));
            }
            if (key == null)
            {
                return false;
            }
            key.SetValue("icon", Path.Combine(Path.Combine(destinationPath, "Icons"), "DtPad.ico"));

            key = Registry.CurrentUser.OpenSubKey(String.Format(@"Software\Classes\*\shell\{0}\command", LanguageUtil.GetCurrentLanguageString("ShellString", className, culture)));
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(String.Format(@"Software\Classes\*\shell\{0}\command", LanguageUtil.GetCurrentLanguageString("ShellString", className, culture)));
            }
            if (key == null)
            {
                return false;
            }
            key.SetValue(String.Empty, Path.Combine(destinationPath, "DtPad.exe") + " \"%1\"");

            return true;
        }

        #endregion Shortcuts And Association Methods

        #region Files And Folders Methods

        private static void WriteFileAndSetPermissions(String fileNameAndPath, byte[] fileResource, bool onlySetPermission = false)
        {
            if (!onlySetPermission)
            {
                if (File.Exists(fileNameAndPath))
                {
                    FileInfo info = new FileInfo(fileNameAndPath);
                    info.IsReadOnly = false;
                }

                File.WriteAllBytes(fileNameAndPath, fileResource);
            }

            FileUtil.SetFilePermissions(fileNameAndPath);
        }

        private static void WriteFileAndSetPermissions(String fileNameAndPath, Icon icon)
        {
            if (File.Exists(fileNameAndPath))
            {
                FileInfo info = new FileInfo(fileNameAndPath);
                info.IsReadOnly = false;
                File.Delete(fileNameAndPath);
            }

            FileStream fileStream = File.Create(fileNameAndPath);
            icon.Save(fileStream);
            fileStream.Close();

            FileUtil.SetFilePermissions(fileNameAndPath);
        }

        private static void WriteFileAndSetPermissions(String fileNameAndPath, String fileResource, bool onlySetPermission = false)
        {
            if (!onlySetPermission)
            {
                if (File.Exists(fileNameAndPath))
                {
                    FileInfo info = new FileInfo(fileNameAndPath);
                    info.IsReadOnly = false;
                    File.Delete(fileNameAndPath);
                }

                FileStream fileStream = File.Create(fileNameAndPath);
                StreamWriter textFile = new StreamWriter(fileStream, Encoding.GetEncoding(1252));
                textFile.Write(fileResource);
                textFile.Close();
                fileStream.Close();
            }

            FileUtil.SetFilePermissions(fileNameAndPath);

            if (!onlySetPermission)
            {
                FileInfo info = new FileInfo(fileNameAndPath);
                info.IsReadOnly = fileNameAndPath.EndsWith("License.txt");
            }
        }

        private static void CreateDirAndSetPermissions(String destinationPath)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            FileUtil.SetDirPermissions(destinationPath);
        }

        #endregion Files And Folders Methods

        #region Other Methods

        private static bool SearchDtPadFiles(IEnumerable<FileInfo> files)
        {
            //foreach(FileInfo file in files)
            //{
            //    if (file.Name == "DtPad.exe")
            //    {
            //        return true;
            //    }
            //}
            return files.Any(file => file.Name == "DtPad.exe");
        }

        #endregion Other Methods
    }
}
