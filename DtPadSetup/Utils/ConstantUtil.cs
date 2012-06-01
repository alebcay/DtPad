using System;

namespace DtPadSetup.Utils
{
    /// <summary>
    /// Constants used by DtPadSetup.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ConstantUtil
    {
        #region Internal Instance Constants

        internal const int standardMessageWidth = 266;
        internal const int standardButtonPositionFromRight = 93;
        internal const int standardButtonDistanceFromRight = 81;
        internal const String dtPadAppConfigName = "DtPad.exe.Config";
        internal const String dtPadURL = "http://www.diariotraduttore.com/diariorama/dtpad/";
        internal const String pwFile = @"SupportFiles\DtPad.exe.pw"; //Passwords
        internal static readonly String defaultPasswordFileContent = "<?xml version=\"1.0\"?>" + Environment.NewLine +
                                                                     "<!-- WARNING: MANUALLY EDITING OF THIS FILE COULD CAUSE DTPAD DYSFUNCTIONS!!! -->" +
                                                                     Environment.NewLine + Environment.NewLine + "<configuration>" + Environment.NewLine +
                                                                     Environment.NewLine + "  <appSettings>" + Environment.NewLine +
                                                                     "    <add key=\"ProxyUsername\" value=\"\" />" + Environment.NewLine +
                                                                     "    <add key=\"ProxyPassword\" value=\"\" />" + Environment.NewLine +
                                                                     "    <add key=\"ProxyDomain\" value=\"\" />" + Environment.NewLine +
                                                                     "    <add key=\"DropboxUsername\" value=\"\" />" + Environment.NewLine +
                                                                     "    <add key=\"DropboxPassword\" value=\"\" />" + Environment.NewLine +
                                                                     "  </appSettings>" + Environment.NewLine + Environment.NewLine + "</configuration>" +
                                                                     Environment.NewLine;
        internal const String defaultKey = "392346f9-ef82-4cf5-8edb-0f80870f3684";
        internal const String defaultIV = "DtPadApp";

        #endregion Internal Instance Constants
    }
}
