using System;
using System.Security.Principal;

namespace DtPadUninstaller.Utils
{
    /// <summary>
    /// OS detection util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class SystemUtil
    {
        #region Internal Methods

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
