using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using DtPad.Exceptions;

namespace DtPad.Utils
{
    /// <summary>
    /// Configuration reading and writing util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ConfigUtil
    {
        private const String className = "ConfigUtil";

        #region Internal Methods

        internal static String GetStringParameter(String parameterName)
        {
            try
            {
                String parameterValue = ConfigurationManager.AppSettings[parameterName];
                if (parameterValue == null)
                {
                    throw new ConfigException(String.Format(LanguageUtil.GetCurrentLanguageString("NoValue", className), parameterName));
                }

                return parameterValue;
            }
            catch (Exception)
            {
                String parameterDefault = ConstantUtil.GetAppConfigDefault(parameterName);
                UpdateParameter(parameterName, parameterDefault);
                return parameterDefault;
            }
        }

        internal static DateTime GetDateParameter(String parameterName)
        {
            try
            {
                String parameterValue = ConfigurationManager.AppSettings[parameterName];
                if (parameterValue == null)
                {
                    throw new ConfigException(String.Format(LanguageUtil.GetCurrentLanguageString("NoValue", className), parameterName));
                }

                String year = parameterValue.Substring(0, parameterValue.IndexOf('-', 0));
                int monthStartIndex = year.Length + 1;
                String month = parameterValue.Substring(monthStartIndex, parameterValue.IndexOf('-', monthStartIndex) - monthStartIndex);
                int dayStartIndex = monthStartIndex + month.Length + 1;
                String day = parameterValue.Substring(dayStartIndex);

                return new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            }
            catch (Exception)
            {
                String parameterDefault = ConstantUtil.GetAppConfigDefault(parameterName);
                UpdateParameter(parameterName, parameterDefault);

                String year = parameterDefault.Substring(0, parameterDefault.IndexOf('-', 0));
                int monthStartIndex = year.Length + 1;
                String month = parameterDefault.Substring(monthStartIndex, parameterDefault.IndexOf('-', monthStartIndex) - monthStartIndex);
                int dayStartIndex = monthStartIndex + month.Length + 1;
                String day = parameterDefault.Substring(dayStartIndex);

                return new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                //return new DateTime(Convert.ToInt32(parameterDefault.Substring(0, 4)), Convert.ToInt32(parameterDefault.Substring(5, 2)), Convert.ToInt32(parameterDefault.Substring(8, 2)));
            }
        }

        internal static Font GetFontParameter(String parameterName)
        {
            try
            {
                String parameterValue = ConfigurationManager.AppSettings[parameterName];
                if (parameterValue == null)
                {
                    throw new ConfigException(String.Format(LanguageUtil.GetCurrentLanguageString("NoValue", className), parameterName));
                }

                char divisor = parameterValue.Contains(";") ? ';' : ',';

                int indexOfSeparator = parameterValue.IndexOf(divisor);
                return new Font(parameterValue.Substring(0, indexOfSeparator), Convert.ToInt32(parameterValue.Substring(indexOfSeparator + 2, parameterValue.LastIndexOf("pt") - indexOfSeparator - 2)));
            }
            catch (Exception)
            {
                String parameterDefault = ConstantUtil.GetAppConfigDefault(parameterName);
                UpdateParameter(parameterName, parameterDefault);

                char divisor = parameterDefault.Contains(";") ? ';' : ',';
                int indexOfSeparator = parameterDefault.IndexOf(divisor);
                return new Font(parameterDefault.Substring(0, indexOfSeparator), Convert.ToInt32(parameterDefault.Substring(indexOfSeparator + 2, parameterDefault.LastIndexOf("pt") - indexOfSeparator - 2)));
            }
        }

        internal static bool GetBoolParameter(String parameterName)
        {
            try
            {
                String parameterValue = ConfigurationManager.AppSettings[parameterName];
                if (parameterValue == null)
                {
                    throw new ConfigException(String.Format(LanguageUtil.GetCurrentLanguageString("NoValue", className), parameterName));
                }

                return Convert.ToBoolean(parameterValue);
            }
            catch (Exception)
            {
                String parameterDefault = ConstantUtil.GetAppConfigDefault(parameterName);
                UpdateParameter(parameterName, parameterDefault);
                return Convert.ToBoolean(parameterDefault);
            }
        }

        internal static int GetIntParameter(String parameterName)
        {
            try
            {
                String parameterValue = ConfigurationManager.AppSettings[parameterName];
                if (parameterValue == null)
                {
                    throw new ConfigException(String.Format(LanguageUtil.GetCurrentLanguageString("NoValue", className), parameterName));
                }

                return Convert.ToInt32(parameterValue);
            }
            catch (Exception)
            {
                String parameterDefault = ConstantUtil.GetAppConfigDefault(parameterName);
                UpdateParameter(parameterName, parameterDefault);
                return Convert.ToInt32(parameterDefault);
            }
        }

        internal static Color GetColorParameter(String parameterName)
        {
            try
            {
                String parameterValue = ConfigurationManager.AppSettings[parameterName];
                if (parameterValue == null)
                {
                    throw new ConfigException(String.Format(LanguageUtil.GetCurrentLanguageString("NoValue", className), parameterName));
                }

                return Color.FromName(parameterValue);
            }
            catch (Exception)
            {
                String parameterDefault = ConstantUtil.GetAppConfigDefault(parameterName);
                UpdateParameter(parameterName, parameterDefault);
                return Color.FromName(parameterDefault);
            }
        }

        internal static void UpdateParameter(String parameterName, String parameterValue, bool disableAddNewSettings = false)
        {
            Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (CheckAppSettingExists(appConfig, parameterName))
            {
                appConfig.AppSettings.Settings[parameterName].Value = parameterValue;
            }
            else if (!disableAddNewSettings)
            {
                appConfig.AppSettings.Settings.Add(parameterName, parameterValue);
            }

            appConfig.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        internal static void UpdateParameters(String[] parameterNames, String[] parameterValues)
        {
            Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            for (int i = 0; i < parameterNames.Length; i++)
            {
                if (CheckAppSettingExists(appConfig, parameterNames[i]))
                {
                    appConfig.AppSettings.Settings[parameterNames[i]].Value = parameterValues[i];
                }
                else
                {
                    appConfig.AppSettings.Settings.Add(parameterNames[i], parameterValues[i]);
                }
            }
            
            appConfig.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        internal static bool CheckAppSettingExists(Configuration appConfig, String parameterName)
        {
            //foreach(String key in appConfig.AppSettings.Settings.AllKeys)
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
