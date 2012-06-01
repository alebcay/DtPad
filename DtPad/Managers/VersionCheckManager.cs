using System;
using System.IO;
using System.Net;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Version check manager (linked to DtPadUpdater).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class VersionCheckManager
    {
        private const String className = "VersionCheckManager";

        #region Internal Methods

        internal static bool IsDtPadUpdated(out WebException exception)
        {
            exception = null;
            String finalVersion;
            String actualVersion = AssemblyUtil.AssemblyVersion;

            WebClient webClient = null;

            String repository = ConstantUtil.repository;
            #if ReleaseFE
                repository = ConstantUtil.repositoryFE;
            #endif

            try
            {
                webClient = ProxyUtil.InitWebClientProxy();
                finalVersion = webClient.DownloadString(String.Format("{0}dtpad-lastversion.log", repository));
            }
            catch (WebException webException)
            {
                exception = webException;
                return false;
            }
            finally
            {
                if (webClient != null)
                {
                    webClient.Dispose();
                }
            }

            return actualVersion == finalVersion;
        }

        internal static bool UpdaterCheck(out String errorMessage)
        {
            errorMessage = String.Empty;
            String actualVersion = AssemblyUtil.GetExternalAssemblyVersion(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.dtPadUpdater);
            
            WebClient webClient = null;

            String repository = ConstantUtil.repository;
            #if ReleaseFE
                repository = ConstantUtil.repositoryFE;
            #endif

            try
            {
                webClient = ProxyUtil.InitWebClientProxy();
                String finalVersion = webClient.DownloadString(String.Format("{0}dtpadupdater-lastversion.log", repository));

                if (actualVersion != finalVersion)
                {
                    if (FileUtil.IsFileInUse("DtPadUpdater.exe"))
                    {
                        errorMessage = String.Format("DtPadUpdater.exe {0}", LanguageUtil.GetCurrentLanguageString("InUse", className));
                        return false;
                    }

                    try
                    {
                        Directory.CreateDirectory("UpdateBackup");
                        Directory.CreateDirectory("UpdateTemp");

                        File.Copy("DtPadUpdater.exe", Path.Combine("UpdateBackup", "DtPadUpdater.exe"));

                        webClient.DownloadFile(String.Format("{0}dtpadupdater-repository/DtPadUpdater.exe", repository), Path.Combine("UpdateTemp", "DtPadUpdater.exe"));

                        File.Delete("DtPadUpdater.exe");
                        File.Move(Path.Combine("UpdateTemp", "DtPadUpdater.exe"), "DtPadUpdater.exe");

                        Directory.Delete("UpdateBackup", true);
                        Directory.Delete("UpdateTemp", true);
                    }
                    catch (Exception)
                    {
                        File.Delete("DtPadUpdater.exe");
                        File.Move(Path.Combine("UpdateBackup", "DtPadUpdater.exe"), "DtPadUpdater.exe");
                    
                        Directory.Delete("UpdateBackup", true);
                        Directory.Delete("UpdateTemp", true);
                    
                        errorMessage = LanguageUtil.GetCurrentLanguageString("ErrorDownloadingUpdater", className);
                        return false;
                    }
                }
            }
            catch (WebException)
            {
                errorMessage = LanguageUtil.GetCurrentLanguageString("ErrorConnection", className);
                return false;
            }
            finally
            {
                if (webClient != null)
                {
                    webClient.Dispose();
                }
            }

            return true;
        }

        internal static bool IsPeriodicVersionCheckToRun()
        {
            switch (ConfigUtil.GetIntParameter("PeriodicVersionCheck"))
            {
                case 1:
                    return ConfigUtil.GetDateParameter("LastVersionCheck").AddMonths(1) <= DateTime.Today;
                case 2:
                    return ConfigUtil.GetDateParameter("LastVersionCheck").AddDays(7) <= DateTime.Today;
                default:
                    return false;
            }
        }

        #endregion Internal Methods
    }
}
