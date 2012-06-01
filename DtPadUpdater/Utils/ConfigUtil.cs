using System;
using System.Configuration;
using System.IO;

namespace DtPadUpdater.Utils
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

        internal static bool GetBoolParameter(String parameterName, String parameterDefault, String executablePath)
        {
            try
            {
                ExeConfigurationFileMap appConfig = new ExeConfigurationFileMap
                                                        {
                                                            ExeConfigFilename = Path.Combine(executablePath, ConstantUtil.dtPadAppConfigName)
                                                        };

                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(appConfig, ConfigurationUserLevel.None);
                String parameterValue = configuration.AppSettings.Settings[parameterName].Value;
                return String.IsNullOrEmpty(parameterValue) ? Convert.ToBoolean(parameterDefault) : Convert.ToBoolean(parameterValue);
            }
            catch (Exception)
            {
                return Convert.ToBoolean(parameterDefault);
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

        internal static void InsertParameter(String parameterName, String parameterValue, String executablePath)
        {
            ExeConfigurationFileMap appConfig = new ExeConfigurationFileMap
                                                    {
                                                        ExeConfigFilename = Path.Combine(executablePath, ConstantUtil.dtPadAppConfigName)
                                                    };

            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(appConfig, ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Add(parameterName, parameterValue);
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        internal static void UpdateParameter(String parameterName, String parameterValue, String executablePath)
        {
            ExeConfigurationFileMap appConfig = new ExeConfigurationFileMap
                                                    {
                                                        ExeConfigFilename = Path.Combine(executablePath, ConstantUtil.dtPadAppConfigName)
                                                    };

            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(appConfig, ConfigurationUserLevel.None);

            if (!ExistsParameter(configuration, parameterName))
            {
                return;
            }
         
            configuration.AppSettings.Settings[parameterName].Value = parameterValue;
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        internal static void DeleteParameter(String parameterName, String executablePath)
        {
            ExeConfigurationFileMap appConfig = new ExeConfigurationFileMap
                                                    {
                                                        ExeConfigFilename = Path.Combine(executablePath, ConstantUtil.dtPadAppConfigName)
                                                    };

            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(appConfig, ConfigurationUserLevel.None);

            if (!ExistsParameter(configuration, parameterName))
            {
                return;
            }

            configuration.AppSettings.Settings.Remove(parameterName);
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        internal static void RenameParameter(String parameterOldName, String parameterNewName, String executablePath)
        {
            ExeConfigurationFileMap appConfig = new ExeConfigurationFileMap
                                                    {
                                                        ExeConfigFilename = Path.Combine(executablePath, ConstantUtil.dtPadAppConfigName)
                                                    };

            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(appConfig, ConfigurationUserLevel.None);

            if (!ExistsParameter(configuration, parameterOldName))
            {
                return;
            }

            configuration.AppSettings.Settings.Add(parameterNewName, configuration.AppSettings.Settings[parameterOldName].Value);
            configuration.AppSettings.Settings.Remove(parameterOldName);
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool ExistsParameter(Configuration configuration, String parameterName)
        {
            bool exists = false;

            foreach (String key in configuration.AppSettings.Settings.AllKeys)
            {
                if (key != parameterName)
                {
                    continue;
                }

                exists = true;
                break;
            }

            return exists;
        }

        #endregion Private Methods
    }
}
