using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;

namespace DtPad.Utils
{
    /// <summary>
    /// Directory util.
    /// </summary>
    /// <author>Marco Macciò, external source</author>
    internal static class DirectoryUtil
    {
        #region Internal Methods

        internal static long GetSize(DirectoryInfo d, int filesCountIn, int dirsCountIn, out int filesCountOut, out int dirsCountOut)
        {
            long size = 0;
            filesCountOut = filesCountIn;
            dirsCountOut = dirsCountIn;
            FileInfo[] fis = d.GetFiles();

            foreach (FileInfo fi in fis)
            {
                filesCountOut++;
                size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();

            foreach (DirectoryInfo di in dis)
            {
                dirsCountOut++;
                size += GetSize(di, filesCountOut, dirsCountOut, out filesCountOut, out dirsCountOut);
            }

            return size;
        }

        internal static IEnumerable<String> GetDirectories(String sourceFolder, String filters, SearchOption searchOption)
        {
            return filters.Split(',').SelectMany(filter => Directory.GetDirectories(sourceFolder, filter, searchOption)).ToArray();
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
