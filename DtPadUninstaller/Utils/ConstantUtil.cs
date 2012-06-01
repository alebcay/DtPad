using System;
using System.IO;
using System.Windows.Forms;

namespace DtPadUninstaller.Utils
{
    /// <summary>
    /// Constants used by DtPadUninstaller.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ConstantUtil
    {
        #region Internal Instance Constants

        internal const int standardMessageWidth = 266;
        internal const int standardButtonPositionFromRight = 93;
        internal const int standardButtonDistanceFromRight = 81;
        internal const String dtPadAppConfigName = "DtPad.exe.Config";
        internal const String myEmail = "maccioma@gmail.com";
        internal const String logFile = @"Logs\DtPadUninstaller.log";

        #endregion Internal Instance Constants

        #region Internal Methods

        internal static String ApplicationExecutionPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        #endregion Internal Methods
    }
}
