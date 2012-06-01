using System;
using System.IO;
using System.Windows.Forms;

namespace DtPadUpdater.Utils
{
    /// <summary>
    /// Constants used by DtPadUpdater.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ConstantUtil
    {
        #region Internal Instance Constants

        internal const int standardMessageWidth = 266;
        internal const int standardButtonPositionFromRight = 93;
        internal const String commentStart = "//";
        internal const String generalRepositoryDebug = @"..\DebugRepository\";
        internal const String generalRepository = "http://www.diariotraduttore.com/wp-content/files/dtpad/";
        internal const String generalRepositoryFE = "http://www.diariotraduttore.com/wp-content/files/dtpad/fe/";
        internal const String dtPadAppConfigName = "DtPad.exe.Config";
        internal const String tempDtPadAppConfigName = @"UpdateTemp\DtPad.exe.Config";
        internal const String dtPadURL = "http://www.diariotraduttore.com/diariorama/dtpad/";
        internal const String logFile = @"Logs\DtPadUpdater.log";
        internal const String pwFile = @"SupportFiles\DtPad.exe.pw"; //Passwords
        internal const String defaultKey = "392346f9-ef82-4cf5-8edb-0f80870f3684";
        internal const String defaultIV = "DtPadApp";

        #endregion Internal Instance Constants

        #region Internal Methods

        internal static String ApplicationExecutionPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        #endregion Internal Methods
    }
}
