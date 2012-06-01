using System;
using System.Configuration;
using System.IO;

namespace DtPadUninstaller.Utils
{
    /// <summary>
    /// Configuration reading and writing util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ConfigUtil
    {
        #region Internal Methods

        internal static String GetStringParameter(String parameterName, String parameterDefault, String executablePath)
        {
            try
            {
                ExeConfigurationFileMap appConfig = new ExeConfigurationFileMap
                                                        {
                                                            ExeConfigFilename = Path.Combine(executablePath, ConstantUtil.dtPadAppConfigName)
                                                        };

                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(appConfig, ConfigurationUserLevel.None);
                String parameterValue = configuration.AppSettings.Settings[parameterName].Value;
                return String.IsNullOrEmpty(parameterValue) ? parameterDefault : parameterValue;
            }
            catch (Exception)
            {
                return parameterDefault;
            }
        }

        internal static int GetIntParameter(String parameterName, int parameterDefault, String executablePath)
        {
            try
            {
                ExeConfigurationFileMap appConfig = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = Path.Combine(executablePath, ConstantUtil.dtPadAppConfigName)
                };

                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(appConfig, ConfigurationUserLevel.None);
                String parameterValue = configuration.AppSettings.Settings[parameterName].Value;

                int result;
                return Int32.TryParse(parameterValue, out result) ? result : parameterDefault;
            }
            catch (Exception)
            {
                return parameterDefault;
            }
        }

        #endregion Internal Methods
    }
}
