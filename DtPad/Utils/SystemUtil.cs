using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Principal;
using DtPad.Managers;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace DtPad.Utils
{
    /// <summary>
    /// OS detection util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class SystemUtil
    {
        private const String className = "SystemUtil";

        internal enum OS
        {
            [Description("Windows 95")]
            NinetyFive,
            [Description("Windows 98")]
            NinetyEight,
            [Description("Windows 98 Second Edition")]
            NinetyEightSe,
            [Description("Windows Millennium Edition")]
            Me,
            [Description("Windows NT 3.51")]
            NtThreeFiveOne,
            [Description("Windows NT 4.0")]
            NtFour,
            [Description("Windows 2000")]
            TwoThousand,
            [Description("Windows XP")]
            Xp,
            [Description("Windows Vista")]
            Vista,
            [Description("Windows 7")]
            Seven,
            [Description("Other")]
            Other
        }

        #region Internal Methods

        internal static OS GetOSInfo()
        {
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;

            OS operatingSystem = OS.Other;

            switch (os.Platform)
            {
                case PlatformID.Win32Windows:
                    switch (vs.Minor)
                    {
                        case 0:
                            operatingSystem = OS.NinetyFive;
                            break;
                        case 10:
                            operatingSystem = vs.Revision.ToString() == "2222A" ? OS.NinetyEightSe : OS.NinetyEight;
                            break;
                        case 90:
                            operatingSystem = OS.Me;
                            break;
                        default:
                            break;
                    }
                    break;
                case PlatformID.Win32NT:
                    switch (vs.Major)
                    {
                        case 3:
                            operatingSystem = OS.NtThreeFiveOne;
                            break;
                        case 4:
                            operatingSystem = OS.NtFour;
                            break;
                        case 5:
                            operatingSystem = vs.Minor == 0 ? OS.TwoThousand : OS.Xp;
                            break;
                        case 6:
                            operatingSystem = vs.Minor == 0 ? OS.Vista : OS.Seven;
                            break;
                        default:
                            break;
                    }
                    break;
            }

            return operatingSystem;
        }

        internal static String GetOSDescription(OS operatingSystem)
        {
            String osDescription;

            switch (operatingSystem)
            {
                case OS.NinetyFive:
                    osDescription = "Windows 95";
                    break;
                case OS.NinetyEight:
                    osDescription = "Windows 98";
                    break;
                case OS.NinetyEightSe:
                    osDescription = "Windows 98 Second Edition";
                    break;
                case OS.Me:
                    osDescription = "Windows Millennium Edition";
                    break;
                case OS.NtThreeFiveOne:
                    osDescription = "Windows NT 3.51";
                    break;
                case OS.NtFour:
                    osDescription = "Windows NT 4.0";
                    break;
                case OS.TwoThousand:
                    osDescription = "Windows 2000";
                    break;
                case OS.Xp:
                    osDescription = "Windows XP";
                    break;
                case OS.Vista:
                    osDescription = "Windows Vista";
                    break;
                case OS.Seven:
                    osDescription = "Windows 7";
                    break;
                default:
                    osDescription = LanguageUtil.GetCurrentLanguageString("OSOther", className);
                    break;
            }

            return osDescription;
        }

        internal static bool IsUserAdministrator()
        {
            bool isAdmin;

            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                if (user == null)
                {
                    return false;
                }

                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception)
            {
                return false;
            }

            return isAdmin;
        }

        internal static void ClearWindowsJumpList(Form1 form)
        {
            #if Debug
                return;
            #endif

            switch (GetOSInfo())
            {
                case OS.Seven:
                    {
                        JumpList list = JumpList.CreateJumpListForIndividualWindow(ConstantUtil.jumpListApplicationId, form.Handle); //TaskbarManager.Instance.ApplicationId
                        list.ClearAllUserTasks();

                        list.Refresh();
                    }
                    break;
            }
        }

        internal static void SetWindowsJumpList(Form1 form)
        {
            #if Debug
                return;
            #endif

            try
            {
                switch (GetOSInfo())
                {
                    case OS.Seven:
                        {
                            if (!ConfigUtil.GetBoolParameter("RecreateJumpList") || !ConfigUtil.GetBoolParameter("ActiveJumpList"))
                            {
                                return;
                            }

                            JumpList list = JumpList.CreateJumpListForIndividualWindow(ConstantUtil.jumpListApplicationId, form.Handle);
                            JumpListSeparator separator = null;
                            JumpListLink listLink = null;

                            try
                            {
                                separator = new JumpListSeparator();

                                listLink = new JumpListLink(Assembly.GetEntryAssembly().Location, LanguageUtil.GetCurrentLanguageString("New", className));
                                listLink.Arguments = ConstantUtil.cmdLineJLNew;
                                listLink.IconReference = new IconReference(String.Format(@"{0}\Icons\JL\NewTab.ico", ConstantUtil.ApplicationExecutionPath()), 0);
                                listLink.WorkingDirectory = ConstantUtil.ApplicationExecutionPath();
                                list.AddUserTasks(listLink);

                                listLink = new JumpListLink(Assembly.GetEntryAssembly().Location, LanguageUtil.GetCurrentLanguageString("NewAndPaste", className));
                                listLink.Arguments = ConstantUtil.cmdLineJLNewAndPaste;
                                listLink.WorkingDirectory = ConstantUtil.ApplicationExecutionPath();
                                list.AddUserTasks(listLink);

                                listLink = new JumpListLink(Assembly.GetEntryAssembly().Location, LanguageUtil.GetCurrentLanguageString("OpenFile", className));
                                listLink.Arguments = ConstantUtil.cmdLineJLOpenFile;
                                listLink.IconReference = new IconReference(String.Format(@"{0}\Icons\JL\OpenFile.ico", ConstantUtil.ApplicationExecutionPath()), 0);
                                listLink.WorkingDirectory = ConstantUtil.ApplicationExecutionPath();
                                list.AddUserTasks(listLink);

                                listLink = new JumpListLink(Assembly.GetEntryAssembly().Location, LanguageUtil.GetCurrentLanguageString("OpenSession", className));
                                listLink.Arguments = ConstantUtil.cmdLineJLOpenSession;
                                listLink.IconReference = new IconReference(String.Format(@"{0}\Icons\JL\OpenSession.ico", ConstantUtil.ApplicationExecutionPath()), 0);
                                listLink.WorkingDirectory = ConstantUtil.ApplicationExecutionPath();
                                list.AddUserTasks(listLink);

                                listLink = new JumpListLink(Assembly.GetEntryAssembly().Location, LanguageUtil.GetCurrentLanguageString("SearchInFiles", className));
                                listLink.Arguments = ConstantUtil.cmdLineJLSearchInFiles;
                                listLink.IconReference = new IconReference(String.Format(@"{0}\Icons\JL\SearchInFiles.ico", ConstantUtil.ApplicationExecutionPath()), 0);
                                listLink.WorkingDirectory = ConstantUtil.ApplicationExecutionPath();
                                list.AddUserTasks(listLink);

                                list.AddUserTasks(separator);

                                listLink = new JumpListLink(Assembly.GetEntryAssembly().Location, LanguageUtil.GetCurrentLanguageString("CheckNewVersion", className));
                                listLink.Arguments = ConstantUtil.cmdLineJLCheckNewVersion;
                                listLink.IconReference = new IconReference(String.Format(@"{0}\Icons\JL\CheckNewVersion.ico", ConstantUtil.ApplicationExecutionPath()), 0);
                                listLink.WorkingDirectory = ConstantUtil.ApplicationExecutionPath();
                                list.AddUserTasks(listLink);

                                #if Release
                                    listLink = new JumpListLink(ConstantUtil.dtPadURL, LanguageUtil.GetCurrentLanguageString("WebSite", className));
                                    listLink.IconReference = new IconReference(String.Format(@"{0}\Icons\JL\WebSite.ico", ConstantUtil.ApplicationExecutionPath()), 0);
                                    list.AddUserTasks(listLink);
                                #endif

                                list.Refresh();
                            }
                            finally
                            {
                                if (separator != null)
                                {
                                    separator.Dispose();
                                }
                                if (listLink != null)
                                {
                                    listLink.Dispose();
                                }
                            }

                            ConfigUtil.UpdateParameter("RecreateJumpList", false.ToString());
                        }
                        break;
                }
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
        }

        #endregion Internal Methods
    }
}
