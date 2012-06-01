using System;
using System.IO;
using System.Reflection;

namespace DtPadUpdater.Utils
{
    /// <summary>
    /// Assembly read util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class AssemblyUtil
    {
        #region Internal Instance Methods

        internal static String AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        #endregion Internal Instance Methods

        #region Internal Methods

        internal static String GetAssemblyVersion(String executablePath, String assemblyName)
        {
            //Assembly.LoadFile(Path.Combine(executablePath.Replace("\\\\", "\\"), assemblyName)).GetName().Version.ToString();
            return Assembly.Load(File.ReadAllBytes(Path.Combine(executablePath.Replace("\\\\", "\\"), assemblyName))).GetName().Version.ToString();
        }

        #endregion Internal Methods
    }
}
