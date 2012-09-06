using System;
using System.Reflection;

namespace DtHelp.Utils
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
                return attributes.Length == 0 ? String.Empty : ((AssemblyConfigurationAttribute)attributes[0]).Configuration;
            }
        }

        #endregion Internal Instance Methods
    }
}
