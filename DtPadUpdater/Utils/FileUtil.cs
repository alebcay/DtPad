using System;
using System.IO;
using System.Security.AccessControl;

namespace DtPadUpdater.Utils
{
    /// <summary>
    /// File system util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class FileUtil
    {
        #region Internal Methods

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

        internal static void SetDirPermissions(String path)
        {
            DirectoryInfo dInfo = new DirectoryInfo(path);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            SystemUtil.OS operativeSystem = SystemUtil.GetOSInfo();

            String user = String.Format(@"{0}\{1}", Environment.UserDomainName, Environment.UserName);

            switch (operativeSystem)
            {
                case SystemUtil.OS.Seven:
                case SystemUtil.OS.Vista:
                    dSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.FullControl, AccessControlType.Allow));
                    break;
            }

            dInfo.SetAccessControl(dSecurity);
        }

        #endregion Internal Methods
    }
}
