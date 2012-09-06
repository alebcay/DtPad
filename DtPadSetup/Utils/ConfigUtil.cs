using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace DtPadSetup.Utils
{
    /// <summary>
    /// Configuration reading and writing util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ConfigUtil
    {
        #region Internal Methods

        internal static void UpdateParameter(String parameterName, String parameterValue, String executablePath)
        {
            ExeConfigurationFileMap appConfig = new ExeConfigurationFileMap { ExeConfigFilename = Path.Combine(executablePath, ConstantUtil.dtPadAppConfigName) };
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(appConfig, ConfigurationUserLevel.None);

            if (CheckAppSettingExists(configuration, parameterName))
            {
                configuration.AppSettings.Settings[parameterName].Value = parameterValue;
            }
            else
            {
                configuration.AppSettings.Settings.Add(parameterName, parameterValue);
            }

            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        internal static bool CheckAppSettingExists(Configuration appConfig, String parameterName)
        {
            //foreach (String key in appConfig.AppSettings.Settings.AllKeys)
            //{
            //    if (key == parameterName)
            //    {
            //        return true;
            //    }
            //}
            return appConfig.AppSettings.Settings.AllKeys.Any(key => key == parameterName);
        }

        #endregion Internal Methods
    }
}
