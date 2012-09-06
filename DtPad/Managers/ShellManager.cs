using System;
using System.IO;
using System.Linq;
using DtPad.Utils;
using Microsoft.Win32;

namespace DtPad.Managers
{
    /// <summary>
    /// Shell integration manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ShellManager
    {
        private const String className = "ShellManager";

        #region Send To Methods

        internal static bool ExistsSendToLink()
        {
            String sendto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SendTo), "DtPad.lnk");

            return File.Exists(sendto);
        }

        internal static void SetSendToLink()
        {
            String sendToDir = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            String destinationPath = ConstantUtil.ApplicationExecutionPath();

            ShellShortcut shortcut = new ShellShortcut(Path.Combine(sendToDir, "DtPad.lnk"))
                                         {
                                             Path = Path.Combine(destinationPath, "DtPad.exe"),
                                             WorkingDirectory = destinationPath,
                                             Description = LanguageUtil.GetCurrentLanguageString("LinkLaunchDtPad", className),
                                             IconPath = Path.Combine(destinationPath, "Icons\\DtPad.ico")
                                         };
            shortcut.Save();
        }

        internal static void RemoveSendToLink()
        {
            String sendto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SendTo), "DtPad.lnk");

            if (!File.Exists(sendto))
            {
                return;
            }

            FileInfo info = new FileInfo(sendto);
            if (info.IsReadOnly)
            {
                info.IsReadOnly = false;
            }

            File.Delete(sendto);
        }

        #endregion Send To Methods

        #region Open With Methods

        internal static bool ExistsOpenWithLink()
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

        internal static void SetOpenWithLink()
        {
            if (ExistsOpenWithLink())
            {
                return;
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(String.Format(@"Software\Classes\*\shell\{0}", LanguageUtil.GetCurrentLanguageString("ShellString", className)));
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(String.Format(@"Software\Classes\*\shell\{0}", LanguageUtil.GetCurrentLanguageString("ShellString", className)));
            }
            key.SetValue("icon", Path.Combine(Path.Combine(ConstantUtil.ApplicationExecutionPath(), "Icons"), "DtPad.ico"));

            key = Registry.CurrentUser.OpenSubKey(String.Format(@"Software\Classes\*\shell\{0}\command", LanguageUtil.GetCurrentLanguageString("ShellString", className)));
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(String.Format(@"Software\Classes\*\shell\{0}\command", LanguageUtil.GetCurrentLanguageString("ShellString", className)));
            }
            key.SetValue(String.Empty, Path.Combine(ConstantUtil.ApplicationExecutionPath(), "DtPad.exe") + " \"%1\"");

            //RegistryKey key = Registry.CurrentUser.OpenSubKey(String.Format(@"Software\Classes\*\shell\{0}\command", LanguageUtil.GetCurrentLanguageString("ShellString", className)));
            //if (key == null)
            //{
            //    key = Registry.CurrentUser.CreateSubKey(String.Format(@"Software\Classes\*\shell\{0}\command", LanguageUtil.GetCurrentLanguageString("ShellString", className)));
            //}
            //key.SetValue(String.Empty, Path.Combine(ConstantUtil.ApplicationExecutionPath(), "DtPad.exe") + " \"%1\"");
        }

        internal static void RemoveOpenWithLink()
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
                break;
            }
        }

        #endregion Open With Methods
    }
}
