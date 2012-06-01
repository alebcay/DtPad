using System;
using System.IO;
using System.Reflection;

namespace DtPad.Utils
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

        internal static String AssemblyConfiguration
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false);
                return (attributes.Length == 0) ? String.Empty : ((AssemblyConfigurationAttribute)attributes[0]).Configuration;
            }
        }

        #endregion Internal Instance Methods

        #region Internal Methods

        internal static String GetExternalAssemblyVersion(String assemblyPath, String assemblyName)
        {
            return Assembly.Load(File.ReadAllBytes(Path.Combine(assemblyPath, assemblyName))).GetName().Version.ToString();
        }

        #endregion Internal Methods
    }
}
