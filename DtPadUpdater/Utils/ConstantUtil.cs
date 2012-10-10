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
        internal const String commentStart = "//";
        internal const String generalRepositoryDebug = @"..\DebugRepository\";
        internal const String generalRepository = "http://dtpad.diariotraduttore.com/files/";
        internal const String generalRepositoryFE = "http://dtpad.diariotraduttore.com/files/fe/";
        internal const String dtPadAppConfigName = "DtPad.exe.Config";
        internal const String tempDtPadAppConfigName = @"UpdateTemp\DtPad.exe.Config";
        internal const String dtPadURL = "http://dtpad.codeplex.com/";
        internal const String logFile = @"Logs\DtPadUpdater.log";
        internal const String pwFile = @"SupportFiles\DtPad.exe.pw"; //Passwords
        internal const String defaultKey = "392346f9-ef82-4cf5-8edb-0f80870f3684";
        internal const String defaultIV = "DtPadApp";
        internal const String dtShortURL = "www.diariotraduttore.com";

        #endregion Internal Instance Constants

        #region Internal Methods

        internal static String ApplicationExecutionPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        #endregion Internal Methods
    }
}
