using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using DtPad.Managers;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace DtPad.Utils
{
    /// <summary>
    /// OS detection util.
    /// </summary>
    /// <author>Marco Macciò, external source</author>
    /// <see>http://www.codeproject.com/Articles/73000/Getting-Operating-System-Version-Info-Even-for-Win</see>
    internal static class SystemUtil
    {
        private const String className = "SystemUtil";

        internal enum OS
        {
            [Description("Windows 3.1")]
            ThreeOne,
            [Description("Windows CE")]
            Ce,
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
            [Description("Windows NT 4.0 Server")]
            NtFourServer,
            [Description("Windows 2000")]
            TwoThousand,
            [Description("Windows XP")]
            Xp,
            [Description("Windows Server 2003")]
            ServerTwoThousandThree,
            [Description("Windows Vista")]
            Vista,
            [Description("Windows Server 2008")]
            ServerTwoThousandEight,
            [Description("Windows 7")]
            Seven,
            [Description("Windows Server 2008 R2")]
            ServerTwoThousandEightR2,
            [Description("Windows 8")]
            Eight,
            [Description("Windows Server 2012")]
            ServerTwoThousandTwelve,
            [Description("Other")]
            Other
        }

        #region Internal Methods

        #region OSVERSIONINFOEX
        [StructLayout(LayoutKind.Sequential)]
        private struct OSVERSIONINFOEX
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szCSDVersion;
            public short wServicePackMajor;
            public short wServicePackMinor;
            public short wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }
        #endregion OSVERSIONINFOEX

        #region VERSION
        [DllImport("kernel32.dll")]
        private static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);
        #endregion VERSION

        internal static OS GetOSInfo()
        {
            OS operatingSystem = OS.Other;

            OperatingSystem osVersion = Environment.OSVersion;
            OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX();
            osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));

            if (GetVersionEx(ref osVersionInfo))
            {
                int majorVersion = osVersion.Version.Major;
                int minorVersion = osVersion.Version.Minor;

                switch (osVersion.Platform)
                {
                    case PlatformID.Win32S:
                        operatingSystem = OS.ThreeOne;
                        break;
                    case PlatformID.WinCE:
                        operatingSystem = OS.Ce;
                        break;
                    case PlatformID.Win32Windows:
                        {
                            if (majorVersion == 4)
                            {
                                string csdVersion = osVersionInfo.szCSDVersion;
                                switch (minorVersion)
                                {
                                    case 0:
                                        operatingSystem = OS.NinetyFive;
                                        break;
                                    case 10:
                                        operatingSystem = csdVersion == "A" ? OS.NinetyEightSe : OS.NinetyEight;
                                        break;
                                    case 90:
                                        operatingSystem = OS.Me;
                                        break;
                                }
                            }
                            break;
                        }
                    case PlatformID.Win32NT:
                        {
                            byte productType = osVersionInfo.wProductType;

                            switch (majorVersion)
                            {
                                case 3:
                                    operatingSystem = OS.NtThreeFiveOne;
                                    break;
                                case 4:
                                    switch (productType)
                                    {
                                        case 1:
                                            operatingSystem = OS.NtFour;
                                            break;
                                        case 3:
                                            operatingSystem = OS.NtFourServer;
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (minorVersion)
                                    {
                                        case 0:
                                            operatingSystem = OS.TwoThousand;
                                            break;
                                        case 1:
                                            operatingSystem = OS.Xp;
                                            break;
                                        case 2:
                                            operatingSystem = OS.ServerTwoThousandThree;
                                            break;
                                    }
                                    break;
                                case 6:
                                    switch (minorVersion)
                                    {
                                        case 0:
                                            switch (productType)
                                            {
                                                case 1:
                                                    operatingSystem = OS.Vista;
                                                    break;
                                                case 3:
                                                    operatingSystem = OS.ServerTwoThousandEight;
                                                    break;
                                            }
                                            break;

                                        case 1:
                                            switch (productType)
                                            {
                                                case 1:
                                                    operatingSystem = OS.Seven;
                                                    break;
                                                case 3:
                                                    operatingSystem = OS.ServerTwoThousandEightR2;
                                                    break;
                                            }
                                            break;
                                        case 2:
                                            switch (productType)
                                            {
                                                case 1:
                                                    operatingSystem = OS.Eight;
                                                    break;
                                                case 3:
                                                    operatingSystem = OS.ServerTwoThousandTwelve;
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                        }
                }
            }

            return operatingSystem;
        }

        internal static String GetOSDescription(OS operatingSystem)
        {
            String osDescription;

            switch (operatingSystem)
            {
                case OS.ThreeOne:
                    osDescription = "Windows 3.1";
                    break;
                case OS.Ce:
                    osDescription = "Windows CE";
                    break;
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
                case OS.NtFourServer:
                    osDescription = "Windows NT 4.0 Server";
                    break;
                case OS.TwoThousand:
                    osDescription = "Windows 2000";
                    break;
                case OS.Xp:
                    osDescription = "Windows XP";
                    break;
                case OS.ServerTwoThousandThree:
                    osDescription = "Windows Server 2003";
                    break;
                case OS.Vista:
                    osDescription = "Windows Vista";
                    break;
                case OS.ServerTwoThousandEight:
                    osDescription = "Windows Server 2008";
                    break;
                case OS.Seven:
                    osDescription = "Windows 7";
                    break;
                case OS.ServerTwoThousandEightR2:
                    osDescription = "Windows Server 2008 R2";
                    break;
                case OS.Eight:
                    osDescription = "Windows 8";
                    break;
                case OS.ServerTwoThousandTwelve:
                    osDescription = "Windows Server 2012";
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
