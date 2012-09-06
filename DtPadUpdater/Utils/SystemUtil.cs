using System;
using System.ComponentModel;
using System.Security.Principal;

namespace DtPadUpdater.Utils
{
    /// <summary>
    /// OS detection util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class SystemUtil
    {
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
                    }
                    break;
            }

            return operatingSystem;
        }

        internal static bool IsUserAdministrator()
        {
            bool isAdmin;

            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);

                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }

            return isAdmin;
        }

        #endregion Internal Methods
    }
}
