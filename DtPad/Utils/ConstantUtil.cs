using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DtPad.Exceptions;

namespace DtPad.Utils
{
    /// <summary>
    /// Constants used by DtPad.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ConstantUtil
    {
        private const String className = "ConstantUtil";

        #region Internal Instance Constants

        internal const String cmdLineNoteModeOn = "-notemodeon";
        internal const String cmdLineJLNew = "-jlnew";
        internal const String cmdLineJLNewAndPaste = "-jlnewandpaste";
        internal const String cmdLineJLOpenFile = "-jlopenfile";
        internal const String cmdLineJLOpenSession = "-jlopensession";
        internal const String cmdLineJLSearchInFiles = "-jlsearchinfiles";
        internal const String cmdLineJLCheckNewVersion = "-jlchecknewversion";
        internal const String newLine = "\n"; //Use Environment.NewLine if present default UTF-8 encoding
        internal const String newLineNotCompatible = "\r\n";
        internal const String rfFile = @"SupportFiles\DtPad.exe.rf"; //Recent files
        internal const String fvFile = @"SupportFiles\DtPad.exe.fv"; //Favourites files
        internal const String shFile = @"SupportFiles\DtPad.exe.sh"; //Search history
        internal const String exFile = @"SupportFiles\DtPad.exe.ex"; //Files extensions
        internal const String toFile = @"SupportFiles\DtPad.exe.to"; //Tools
        internal const String tmFile = @"SupportFiles\DtPad.exe.tm"; //Templates
        internal const String noFile = @"SupportFiles\DtPad.exe.no"; //Notes
        internal const String clFile = @"SupportFiles\DtPad.exe.cl"; //Clipboard history
        internal const String rsFile = @"SupportFiles\DtPad.exe.rs"; //Recent sessions
        internal const String rpFile = @"SupportFiles\DtPad.exe.rp"; //Recent patterns
        internal const String sfFile = @"SupportFiles\DtPad.exe.sf"; //Search in files history
        internal const String ruFile = @"SupportFiles\DtPad.exe.ru"; //Recent urls
        internal const String pwFile = @"SupportFiles\DtPad.exe.pw"; //Passwords
        internal const String license = "License.txt";
        internal const String dtPadUpdater = "DtPadUpdater.exe";
        internal const String repository = "http://dtpad.diariotraduttore.com/files/";
        internal const String repositoryFE = "http://dtpad.diariotraduttore.com/files/fe/";
        internal const String dropboxAuthUrl = "http://dtpad.diariotraduttore.com/files/dropbox-authentication.html";
        internal const int standardMessageWidth = 266;
        internal const int maxLenghtTrayDescription = 63; //Formally in Windows it's 64, but it's necessary to reserve one character
        internal const int maxLenghtForBulletList = 5;
        internal const String tabIntoSpaces = "       ";
        internal static readonly String defaultExtensionFileContent = "All files|*|False" + Environment.NewLine + "Text document|txt|True";
        internal const int standardHelpPanelHeight = 30;
        internal static readonly String defaultNoteFileContent = "<?xml version=\"1.0\"?>" + Environment.NewLine + "<notes>" + Environment.NewLine +
            "  <note>" + Environment.NewLine + "    <title>Note (1)</title>" + Environment.NewLine + "    <text></text>" + Environment.NewLine + 
            "  </note>" + Environment.NewLine + "</notes>" + Environment.NewLine;
        internal static readonly String defaultClipboardFileContent = "<?xml version=\"1.0\"?>" + Environment.NewLine + "<clipboard>" + Environment.NewLine +
            "</clipboard>" + Environment.NewLine;
        internal static readonly String defaultSessionFileContent = "<?xml version=\"1.0\"?>" + Environment.NewLine + "<session>" + Environment.NewLine + "</session>";
        internal const String dtHelpExecutable = "DtHelp.exe";
        internal const String defaultDtPadGuideName = @"Guides\DtPadGuide-";
        internal const String defaultDtPadGuideExtension = ".dhg";
        internal const String myEmail = "maccioma@gmail.com";
        internal const String defaultCalculatorNumber = "0";
        internal const String calculatorSeparator = "-----------";
        internal const String exportOptionsFileName = "DtPadOptions";
        internal const String exportFileExtension = "dpe";
        internal const String internetCacheDirectoryName = "InternetCache";
        internal const String internetCacheInfoFileName = "Info.txt";
        internal const String tabNodePrefix = "TabNode_";
        internal const String dtPadURL = "http://dtpad.codeplex.com/";
        internal const String dtPadDocsURL = "http://dtpad.codeplex.com/documentation";
        internal const String dtFeedURL = "http://dtpad.codeplex.com/project/feeds/rss";
        internal const String w3cHtmlValidation = "<html><body style=\"text-align: left; font-family: Trebuchet MS; font-size: 12px;\">" + 
            "<form method=\"post\" enctype=\"multipart/form-data\" action=\"http://validator.w3.org/check\">" + 
            "<span style=\"padding-top: 10px; font-size: 18px; font-weight: bold;\">{0}</span><br /><br />" + 
            "<textarea cols=\"75\" rows=\"12\" name=\"fragment\" id=\"fragment\">{1}</textarea><br />" + 
            "<input type=\"submit\" value=\"{2}\" style=\"height:25px; font-family: Trebuchet MS; font-size: 12px;\"/></form></body></html>";
        internal const String w3cCssValidation = "<html><body style=\"text-align: left; font-family: Trebuchet MS; font-size: 12px;\">" + 
            "<form action=\"http://jigsaw.w3.org/css-validator/validator\" method=\"put\"><span style=\"padding-top: 10px; font-size: 18px; font-weight: bold;\">{0}</span>" + 
            "<br /><br /><textarea name=\"text\" rows=\"12\" cols=\"75\">{1}</textarea><br />" + 
            "<input type=\"submit\" value=\"{2}\" style=\"height:25px; font-family: Trebuchet MS; font-size: 12px;\"/></form></body></html>";
        internal const String hostsComments = "#// ";
        internal const String jumpListApplicationId = "DtPad-5FF8C004-BCED-4754-8FEB-74B66396CE92";
        internal const String dropboxConsumerKey = "1vyrdb7rdeyb9bq";
        internal const String dropboxConsumerSecret = "dvy4mo181hfx8v0";
        internal const String defaultKey = "392346f9-ef82-4cf5-8edb-0f80870f3684";
        internal const String defaultIV = "DtPadApp";
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
        internal const String columnsHeader = "        10        20        30        40        50        60        70        80        90        100       110       120       130       140       150       160       170       180       190       200       210       220       230       240       250" + newLineNotCompatible +
            "....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|";
        internal const String columnsHeaderShort = "10        20        30        40        50        60        70        80        90        100       110       120       130       140       150" + newLineNotCompatible +
            "....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|....5....|";
        internal const String sessionPrefix = "[S] ";
        internal const String urlPrefix = "[U] ";
        internal const int clipboardRetryTimes = 15;
        internal const int clipboardRetryDelay = 100;
        internal const int maxFileByteLength = 104857600;
        internal static readonly String dontTranslate = "DontTranslate";

        #endregion Internal Instance Constants

        #region Internal Methods

        internal static String ApplicationExecutionPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        internal static String GetAppConfigDefault(String parameterName)
        {
            foreach (KeyValuePair<String, String> keyValuePair in AppConfigDefaults)
            {
                if (keyValuePair.Key == parameterName)
                {
                    return keyValuePair.Value;
                }
            }

            throw new ConfigException(String.Format(LanguageUtil.GetCurrentLanguageString("NoDefault", className), parameterName));
        }

        #endregion Internal Methods

        #region Internal ValuePair

        //internal static readonly KeyValuePair<String, String>[] HtmlCharSet = {
        //    new KeyValuePair<String, String>("&#39;", "\'")
        //};

        internal static readonly KeyValuePair<String, String>[] HtmlTags = {
            new KeyValuePair<String, String>("&", "&amp;"),
            new KeyValuePair<String, String>("€", "&euro;"),
            new KeyValuePair<String, String>(LanguageUtil.GetCurrentLanguageString("SpaceChar", className), "&nbsp;"),
            new KeyValuePair<String, String>("\"", "&quot;"),
            new KeyValuePair<String, String>("<", "&lt;"),
            new KeyValuePair<String, String>(">", "&gt;"),
            new KeyValuePair<String, String>("¡", "&iexcl;"),
            new KeyValuePair<String, String>("¢", "&cent;"),
            new KeyValuePair<String, String>("£", "&pound;"),
            new KeyValuePair<String, String>("¤", "&curren;"),
            new KeyValuePair<String, String>("¥", "&yen;"),
            new KeyValuePair<String, String>("¦", "&brvbar;"),
            new KeyValuePair<String, String>("§", "&sect;"),
            new KeyValuePair<String, String>("¨", "&uml;"),
            new KeyValuePair<String, String>("©", "&copy;"),
            new KeyValuePair<String, String>("ª", "&ordf;"),
            new KeyValuePair<String, String>("«", "&laquo;"),
            new KeyValuePair<String, String>("¬", "&not;"),
            new KeyValuePair<String, String>("®", "&reg;"),
            new KeyValuePair<String, String>("¯", "&macr;"),
            new KeyValuePair<String, String>("°", "&deg;"),
            new KeyValuePair<String, String>("±", "&plusmn;"),
            new KeyValuePair<String, String>("²", "&sup2;"),
            new KeyValuePair<String, String>("³", "&sup3;"),
            new KeyValuePair<String, String>("´", "&acute;"),
            new KeyValuePair<String, String>("µ", "&micro;"),
            new KeyValuePair<String, String>("¶", "&para;"),
            new KeyValuePair<String, String>("·", "&middot;"),
            new KeyValuePair<String, String>("¸", "&cedil;"),
            new KeyValuePair<String, String>("¹", "&sup1;"),
            new KeyValuePair<String, String>("º", "&ordm;"),
            new KeyValuePair<String, String>("»", "&raquo;"),
            new KeyValuePair<String, String>("¼", "&frac14;"),
            new KeyValuePair<String, String>("½", "&frac12;"),
            new KeyValuePair<String, String>("¾", "&frac34;"),
            new KeyValuePair<String, String>("¿", "&iquest;"),
            new KeyValuePair<String, String>("À", "&Agrave;"),
            new KeyValuePair<String, String>("Á", "&Aacute;"),
            new KeyValuePair<String, String>("Â", "&Acirc;"),
            new KeyValuePair<String, String>("Ã", "&Atilde;"),
            new KeyValuePair<String, String>("Ä", "&Auml;"),
            new KeyValuePair<String, String>("Å", "&Aring;"),
            new KeyValuePair<String, String>("Æ", "&AElig;"),
            new KeyValuePair<String, String>("Ç", "&Ccedil;"),
            new KeyValuePair<String, String>("È", "&Egrave;"),
            new KeyValuePair<String, String>("É", "&Eacute;"),
            new KeyValuePair<String, String>("Ê", "&Ecirc;"),
            new KeyValuePair<String, String>("Ë", "&Euml;"),
            new KeyValuePair<String, String>("Ì", "&Igrave;"),
            new KeyValuePair<String, String>("Í", "&Iacute;"),
            new KeyValuePair<String, String>("Î", "&Icirc;"),
            new KeyValuePair<String, String>("Ï", "&Iuml;"),
            new KeyValuePair<String, String>("Ð", "&ETH;"),
            new KeyValuePair<String, String>("Ñ", "&Ntilde;"),
            new KeyValuePair<String, String>("Ò", "&Ograve;"),
            new KeyValuePair<String, String>("Ó", "&Oacute;"),
            new KeyValuePair<String, String>("Ô", "&Ocirc;"),
            new KeyValuePair<String, String>("Õ", "&Otilde;"),
            new KeyValuePair<String, String>("Ö", "&Ouml;"),
            new KeyValuePair<String, String>("×", "&times;"),
            new KeyValuePair<String, String>("Ø", "&Oslash;"),
            new KeyValuePair<String, String>("Ù", "&Ugrave;"),
            new KeyValuePair<String, String>("Ú", "&Uacute;"),
            new KeyValuePair<String, String>("Û", "&Ucirc;"),
            new KeyValuePair<String, String>("Ü", "&Uuml;"),
            new KeyValuePair<String, String>("Ý", "&Yacute;"),
            new KeyValuePair<String, String>("Þ", "&THORN;"),
            new KeyValuePair<String, String>("ß", "&szlig;"),
            new KeyValuePair<String, String>("à", "&agrave;"),
            new KeyValuePair<String, String>("á", "&aacute;"),
            new KeyValuePair<String, String>("â", "&acirc;"),
            new KeyValuePair<String, String>("ã", "&atilde;"),
            new KeyValuePair<String, String>("ä", "&auml;"),
            new KeyValuePair<String, String>("å", "&aring;"),
            new KeyValuePair<String, String>("æ", "&aelig;"),
            new KeyValuePair<String, String>("ç", "&ccedil;"),
            new KeyValuePair<String, String>("è", "&egrave;"),
            new KeyValuePair<String, String>("é", "&eacute;"),
            new KeyValuePair<String, String>("ê", "&ecirc;"),
            new KeyValuePair<String, String>("ë", "&euml;"),
            new KeyValuePair<String, String>("ì", "&igrave;"),
            new KeyValuePair<String, String>("í", "&iacute;"),
            new KeyValuePair<String, String>("î", "&icirc;"),
            new KeyValuePair<String, String>("ï", "&iuml;"),
            new KeyValuePair<String, String>("ð", "&eth;"),
            new KeyValuePair<String, String>("ñ", "&ntilde;"),
            new KeyValuePair<String, String>("ò", "&ograve;"),
            new KeyValuePair<String, String>("ó", "&oacute;"),
            new KeyValuePair<String, String>("ô", "&ocirc;"),
            new KeyValuePair<String, String>("õ", "&otilde;"),
            new KeyValuePair<String, String>("ö", "&ouml;"),
            new KeyValuePair<String, String>("÷", "&divide;"),
            new KeyValuePair<String, String>("ø", "&oslash;"),
            new KeyValuePair<String, String>("ù", "&ugrave;"),
            new KeyValuePair<String, String>("ú", "&uacute;"),
            new KeyValuePair<String, String>("û", "&ucirc;"),
            new KeyValuePair<String, String>("ü", "&uuml;"),
            new KeyValuePair<String, String>("ý", "&yacute;"),
            new KeyValuePair<String, String>("þ", "&thorn;")
        };

        internal static readonly KeyValuePair<String, String>[] HtmlTagsNumbers = {
            new KeyValuePair<String, String>("!", "&#33;"),
            new KeyValuePair<String, String>("\"", "&#34;"),
            new KeyValuePair<String, String>("#", "&#35;"),
            new KeyValuePair<String, String>("$", "&#36;"),
            new KeyValuePair<String, String>("%", "&#37;"),
            new KeyValuePair<String, String>("&", "&#38;"),
            new KeyValuePair<String, String>("'", "&#39;"),
            new KeyValuePair<String, String>("(", "&#40;"),
            new KeyValuePair<String, String>(")", "&#41;"),
            new KeyValuePair<String, String>("*", "&#42;"),
            new KeyValuePair<String, String>("+", "&#43;"),
            new KeyValuePair<String, String>(",", "&#44;"),
            new KeyValuePair<String, String>("-", "&#45;"),
            new KeyValuePair<String, String>(".", "&#46;"),
            new KeyValuePair<String, String>("/", "&#47;"),
            new KeyValuePair<String, String>(":", "&#58;"),
            new KeyValuePair<String, String>(";", "&#59;"),
            new KeyValuePair<String, String>("<", "&#60;"),
            new KeyValuePair<String, String>("=", "&#61;"),
            new KeyValuePair<String, String>(">", "&#62;"),
            new KeyValuePair<String, String>("?", "&#63;"),
            new KeyValuePair<String, String>("@", "&#64;"),
            new KeyValuePair<String, String>("[", "&#91;"),
            new KeyValuePair<String, String>("\\", "&#92;"),
            new KeyValuePair<String, String>("]", "&#93;"),
            new KeyValuePair<String, String>("^", "&#94;"),
            new KeyValuePair<String, String>("_", "&#95;"),
            new KeyValuePair<String, String>("`", "&#96;"),
            new KeyValuePair<String, String>("{", "&#123;"),
            new KeyValuePair<String, String>("|", "&#124;"),
            new KeyValuePair<String, String>("}", "&#125;"),
            new KeyValuePair<String, String>("~", "&#126;")
        };

        internal static readonly KeyValuePair<String, String>[] SmallHtmlTags = {
            new KeyValuePair<String, String>("€", "&euro;"),
            new KeyValuePair<String, String>("¡", "&iexcl;"),
            new KeyValuePair<String, String>("¢", "&cent;"),
            new KeyValuePair<String, String>("£", "&pound;"),
            new KeyValuePair<String, String>("¤", "&curren;"),
            new KeyValuePair<String, String>("¥", "&yen;"),
            new KeyValuePair<String, String>("¦", "&brvbar;"),
            new KeyValuePair<String, String>("§", "&sect;"),
            new KeyValuePair<String, String>("¨", "&uml;"),
            new KeyValuePair<String, String>("©", "&copy;"),
            new KeyValuePair<String, String>("ª", "&ordf;"),
            new KeyValuePair<String, String>("«", "&laquo;"),
            new KeyValuePair<String, String>("¬", "&not;"),
            new KeyValuePair<String, String>("®", "&reg;"),
            new KeyValuePair<String, String>("¯", "&macr;"),
            new KeyValuePair<String, String>("°", "&deg;"),
            new KeyValuePair<String, String>("±", "&plusmn;"),
            new KeyValuePair<String, String>("²", "&sup2;"),
            new KeyValuePair<String, String>("³", "&sup3;"),
            new KeyValuePair<String, String>("´", "&acute;"),
            new KeyValuePair<String, String>("µ", "&micro;"),
            new KeyValuePair<String, String>("¶", "&para;"),
            new KeyValuePair<String, String>("·", "&middot;"),
            new KeyValuePair<String, String>("¸", "&cedil;"),
            new KeyValuePair<String, String>("¹", "&sup1;"),
            new KeyValuePair<String, String>("º", "&ordm;"),
            new KeyValuePair<String, String>("»", "&raquo;"),
            new KeyValuePair<String, String>("¼", "&frac14;"),
            new KeyValuePair<String, String>("½", "&frac12;"),
            new KeyValuePair<String, String>("¾", "&frac34;"),
            new KeyValuePair<String, String>("¿", "&iquest;"),
            new KeyValuePair<String, String>("À", "&Agrave;"),
            new KeyValuePair<String, String>("Á", "&Aacute;"),
            new KeyValuePair<String, String>("Â", "&Acirc;"),
            new KeyValuePair<String, String>("Ã", "&Atilde;"),
            new KeyValuePair<String, String>("Ä", "&Auml;"),
            new KeyValuePair<String, String>("Å", "&Aring;"),
            new KeyValuePair<String, String>("Æ", "&AElig;"),
            new KeyValuePair<String, String>("Ç", "&Ccedil;"),
            new KeyValuePair<String, String>("È", "&Egrave;"),
            new KeyValuePair<String, String>("É", "&Eacute;"),
            new KeyValuePair<String, String>("Ê", "&Ecirc;"),
            new KeyValuePair<String, String>("Ë", "&Euml;"),
            new KeyValuePair<String, String>("Ì", "&Igrave;"),
            new KeyValuePair<String, String>("Í", "&Iacute;"),
            new KeyValuePair<String, String>("Î", "&Icirc;"),
            new KeyValuePair<String, String>("Ï", "&Iuml;"),
            new KeyValuePair<String, String>("Ð", "&ETH;"),
            new KeyValuePair<String, String>("Ñ", "&Ntilde;"),
            new KeyValuePair<String, String>("Ò", "&Ograve;"),
            new KeyValuePair<String, String>("Ó", "&Oacute;"),
            new KeyValuePair<String, String>("Ô", "&Ocirc;"),
            new KeyValuePair<String, String>("Õ", "&Otilde;"),
            new KeyValuePair<String, String>("Ö", "&Ouml;"),
            new KeyValuePair<String, String>("×", "&times;"),
            new KeyValuePair<String, String>("Ø", "&Oslash;"),
            new KeyValuePair<String, String>("Ù", "&Ugrave;"),
            new KeyValuePair<String, String>("Ú", "&Uacute;"),
            new KeyValuePair<String, String>("Û", "&Ucirc;"),
            new KeyValuePair<String, String>("Ü", "&Uuml;"),
            new KeyValuePair<String, String>("Ý", "&Yacute;"),
            new KeyValuePair<String, String>("Þ", "&THORN;"),
            new KeyValuePair<String, String>("ß", "&szlig;"),
            new KeyValuePair<String, String>("à", "&agrave;"),
            new KeyValuePair<String, String>("á", "&aacute;"),
            new KeyValuePair<String, String>("â", "&acirc;"),
            new KeyValuePair<String, String>("ã", "&atilde;"),
            new KeyValuePair<String, String>("ä", "&auml;"),
            new KeyValuePair<String, String>("å", "&aring;"),
            new KeyValuePair<String, String>("æ", "&aelig;"),
            new KeyValuePair<String, String>("ç", "&ccedil;"),
            new KeyValuePair<String, String>("è", "&egrave;"),
            new KeyValuePair<String, String>("é", "&eacute;"),
            new KeyValuePair<String, String>("ê", "&ecirc;"),
            new KeyValuePair<String, String>("ë", "&euml;"),
            new KeyValuePair<String, String>("ì", "&igrave;"),
            new KeyValuePair<String, String>("í", "&iacute;"),
            new KeyValuePair<String, String>("î", "&icirc;"),
            new KeyValuePair<String, String>("ï", "&iuml;"),
            new KeyValuePair<String, String>("ð", "&eth;"),
            new KeyValuePair<String, String>("ñ", "&ntilde;"),
            new KeyValuePair<String, String>("ò", "&ograve;"),
            new KeyValuePair<String, String>("ó", "&oacute;"),
            new KeyValuePair<String, String>("ô", "&ocirc;"),
            new KeyValuePair<String, String>("õ", "&otilde;"),
            new KeyValuePair<String, String>("ö", "&ouml;"),
            new KeyValuePair<String, String>("÷", "&divide;"),
            new KeyValuePair<String, String>("ø", "&oslash;"),
            new KeyValuePair<String, String>("ù", "&ugrave;"),
            new KeyValuePair<String, String>("ú", "&uacute;"),
            new KeyValuePair<String, String>("û", "&ucirc;"),
            new KeyValuePair<String, String>("ü", "&uuml;"),
            new KeyValuePair<String, String>("ý", "&yacute;"),
            new KeyValuePair<String, String>("þ", "&thorn;")
        };

        internal static readonly KeyValuePair<String, String>[] AppConfigDefaults = {
            new KeyValuePair<String, String>("ShowSplashScreen", "True"),
            new KeyValuePair<String, String>("WelcomeShown", "False"),
            new KeyValuePair<String, String>("TrayBalloonTipShown", "False"),
            new KeyValuePair<String, String>("MaxNumRecentFile", "10"),
            new KeyValuePair<String, String>("MaxNumSearchHistory", "10"),
            new KeyValuePair<String, String>("SettingFolder", "1"),
            new KeyValuePair<String, String>("LastUserFolder", String.Empty),
            new KeyValuePair<String, String>("SpecificFolder", String.Empty),
            new KeyValuePair<String, String>("OverrideFolderWithActiveFile", "True"),
            new KeyValuePair<String, String>("SearchReplacePanelDisabled", "True"),
            new KeyValuePair<String, String>("SearchCaseSensitive", "False"),
            new KeyValuePair<String, String>("SearchLoopAtEOF", "False"),
            new KeyValuePair<String, String>("SearchHighlightsResults", "True"),
            new KeyValuePair<String, String>("SearchReturn", "0"),
            new KeyValuePair<String, String>("WordWrapDisabled", "False"),
            new KeyValuePair<String, String>("StayOnTopDisabled", "True"),
            new KeyValuePair<String, String>("ToolbarInvisible", "False"),
            new KeyValuePair<String, String>("StatusBarInvisible", "False"),
            new KeyValuePair<String, String>("MinimizeOnTrayIconDisabled", "True"),
            new KeyValuePair<String, String>("InternalExplorerInvisible", "False"),
            new KeyValuePair<String, String>("WindowState", "Normal"),
            new KeyValuePair<String, String>("WindowSizeX", "1180"),
            new KeyValuePair<String, String>("WindowSizeY", "670"),
            new KeyValuePair<String, String>("ProxyEnabled", "False"),
            new KeyValuePair<String, String>("ProxyHost", ""),
            new KeyValuePair<String, String>("ProxyPort", "8080"),
            new KeyValuePair<String, String>("FontInUse", "Courier New; 10pt"),
            new KeyValuePair<String, String>("FontInUseColorARGB", "255;0;0;0"),
            new KeyValuePair<String, String>("BackgroundColorARGB", "255;255;255;255"),
            new KeyValuePair<String, String>("HighlightURL", "False"),
            new KeyValuePair<String, String>("UseDefaultBrowser", "True"),
            new KeyValuePair<String, String>("CustomBrowserCommand", String.Empty),
            new KeyValuePair<String, String>("MergeTabSeparation", "\r\n========== MERGE ==========\r\n"),
            new KeyValuePair<String, String>("LookAndFeel", "0"),
            new KeyValuePair<String, String>("Language", "English"),
            new KeyValuePair<String, String>("WarningRemoveNote", "True"),
            new KeyValuePair<String, String>("TabCloseButtonMode", "2"),
            new KeyValuePair<String, String>("DefaultEncoding", "True"),
            new KeyValuePair<String, String>("Encoding", "1"),
            new KeyValuePair<String, String>("LineNumbersVisible", "True"),
            new KeyValuePair<String, String>("TabPosition", "0"),
            new KeyValuePair<String, String>("TabOrientation", "0"),
            new KeyValuePair<String, String>("TabMultiline", "False"),
            new KeyValuePair<String, String>("BackupEnabled", "False"),
            new KeyValuePair<String, String>("BackupExtension", "bak"),
            new KeyValuePair<String, String>("BackupExtensionPosition", "0"),
            new KeyValuePair<String, String>("BackupLocation", "0"),
            new KeyValuePair<String, String>("BackupLocationCustom", ApplicationExecutionPath()),
            new KeyValuePair<String, String>("BackupIncremental", "True"),
            new KeyValuePair<String, String>("SpacesInsteadTabs", "False"),
            new KeyValuePair<String, String>("KeepInitialSpacesOnReturn", "False"),
            new KeyValuePair<String, String>("KeepBulletListOnReturn", "False"),
            new KeyValuePair<String, String>("AutomaticSessionSave", "False"),
            new KeyValuePair<String, String>("Translation", "en|it"),
            new KeyValuePair<String, String>("TranslationUseSelect", "False"),
            new KeyValuePair<String, String>("CheckLineNumber", "True"),
            new KeyValuePair<String, String>("CheckLineNumberMax", "1000"),
            new KeyValuePair<String, String>("AutoFormatFiles", String.Empty),
            new KeyValuePair<String, String>("AutoOpenHostsConfigurator", "True"),
            new KeyValuePair<String, String>("ColorHostsConfigurator", "Orange"),
            new KeyValuePair<String, String>("HeightNoteList", "150"),
            new KeyValuePair<String, String>("PeriodicVersionCheck", "0"),
            new KeyValuePair<String, String>("LastVersionCheck", "2010-1-1"),
            new KeyValuePair<String, String>("TryLastVersionCheck", "0"),
            new KeyValuePair<String, String>("ActiveJumpList", "True"),
            new KeyValuePair<String, String>("RecreateJumpList", "True"),
            new KeyValuePair<String, String>("EnableDropboxDelete", "False"),
            new KeyValuePair<String, String>("RememberDropboxAccess", "True"),
            new KeyValuePair<String, String>("LastDropboxAccessToken", String.Empty),
            new KeyValuePair<String, String>("IgnoreNullChar", "False"),
            new KeyValuePair<String, String>("NoteModeTabs", "False"),
            new KeyValuePair<String, String>("NoteModeSizeX", "400"),
            new KeyValuePair<String, String>("NoteModeSizeY", "300"),
            new KeyValuePair<String, String>("TabsSwitchType", "0"),
            //new KeyValuePair<String, String>("CalendarURL", "http://dtpad.diariotraduttore.com/files/dtpad-calendar.xml"),

            new KeyValuePair<String, String>("ProxyUsername", String.Empty),
            new KeyValuePair<String, String>("ProxyPassword", String.Empty),
            new KeyValuePair<String, String>("ProxyDomain", String.Empty)
        };

        #endregion Internal ValuePair
    }
}
