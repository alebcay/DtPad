using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DtPad.Exceptions;
using DtPad.Objects;
using Microsoft.Win32;

namespace DtPad.Utils
{
    /// <summary>
    /// Password reading and writing util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class PasswordUtil
    {
        private const String className = "PasswordUtil";

        #region Internal Methods

        internal static String GetStringParameter(String parameterName)
        {
            //Configuration configuration = GetPasswordConfig();

            //try
            //{
            //    String parameterValue = configuration.AppSettings.Settings[parameterName].Value;
            //    if (parameterValue == null)
            //    {
            //        throw new ConfigException(String.Format(LanguageUtil.GetCurrentLanguageString("NoValue", className), parameterName));
            //    }

            //    return parameterValue;
            //}
            //catch (Exception)
            //{
            //    String parameterDefault = ConstantUtil.GetAppConfigDefault(parameterName);
            //    UpdateParameter(parameterName, parameterDefault);
            //    return parameterDefault;
            //}
            //finally
            //{
            //    EncryptPasswordConfig();
            //}

            return GetStringParameters(new[] { parameterName })[0].value;
        }
        internal static List<PasswordObject> GetStringParameters(IEnumerable<String> parameterNames)
        {
            Configuration configuration = GetPasswordConfig();
            List<PasswordObject> passwordList = new List<PasswordObject>();

            foreach (String parameterName in parameterNames)
            {
                try
                {
                    String parameterValue = configuration.AppSettings.Settings[parameterName].Value;
                    if (parameterValue == null)
                    {
                        throw new ConfigException(String.Format(LanguageUtil.GetCurrentLanguageString("NoValue", className), parameterName));
                    }

                    passwordList.Add(new PasswordObject(parameterName, parameterValue));
                }
                catch (Exception)
                {
                    String parameterDefault = ConstantUtil.GetAppConfigDefault(parameterName);
                    DoUpdateParameter(parameterName, parameterDefault);
                    passwordList.Add(new PasswordObject(parameterName, parameterDefault));
                }
            }

            EncryptPasswordConfig();

            return passwordList;
        }

        internal static void UpdateParameter(String parameterName, String parameterValue)
        {
            UpdateParameters(new[] { parameterName }, new[] { parameterValue });
        }
        internal static void UpdateParameters(String[] parameterNames, String[] parameterValues)
        {
            try
            {
                Configuration configuration = GetPasswordConfig();

                for (int i = 0; i < parameterNames.Length; i++)
                {
                    if (ConfigUtil.CheckAppSettingExists(configuration, parameterNames[i]))
                    {
                        configuration.AppSettings.Settings[parameterNames[i]].Value = parameterValues[i];
                    }
                    else
                    {
                        configuration.AppSettings.Settings.Add(parameterNames[i], parameterValues[i]);
                    }
                }

                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            finally
            {
                EncryptPasswordConfig();
            }
        }

        #endregion Internal Methods

        #region Private Methods

        private static void DoUpdateParameter(String parameterName, String parameterValue)
        {
            Configuration configuration = GetPasswordConfig();

            if (ConfigUtil.CheckAppSettingExists(configuration, parameterName))
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

        private static Configuration GetPasswordConfig()
        {
            String fileNameAndPath = Path.Combine(Application.StartupPath, ConstantUtil.pwFile);

            //Check for read-only flag
            FileInfo fileInfo = new FileInfo(fileNameAndPath);
            if (fileInfo.Exists && fileInfo.IsReadOnly)
            {
                File.SetAttributes(fileNameAndPath, FileAttributes.Normal);
            }

            DecryptPasswordConfig();

            ExeConfigurationFileMap pwdConfig = new ExeConfigurationFileMap { ExeConfigFilename = fileNameAndPath };
            return ConfigurationManager.OpenMappedExeConfiguration(pwdConfig, ConfigurationUserLevel.None);
        }

        private static void DecryptPasswordConfig()
        {
            String fileName = Path.Combine(Application.StartupPath, ConstantUtil.pwFile);
            TripleDESCryptoServiceProvider cryptAlgorithm = ReadKeyIV();
            FileStream fsFile = null;
            String allLines;

            try
            {
                //Read the file
                fsFile = File.OpenRead(fileName);
                CryptoStream csEncrypt = new CryptoStream(fsFile, cryptAlgorithm.CreateDecryptor(), CryptoStreamMode.Read);
                StreamReader srEncStream = new StreamReader(csEncrypt, Encoding.UTF8);
                allLines = srEncStream.ReadToEnd();
                srEncStream.Close();
            }
            catch (CryptographicException)
            {
                allLines = ConstantUtil.defaultPasswordFileContent;
                if (fsFile != null)
                {
                    fsFile.Close();
                }
            }

            //Write the file
            fsFile = File.Create(fileName);
            StreamWriter swCleanStream = new StreamWriter(fsFile, Encoding.UTF8);
            swCleanStream.Write(allLines);
            swCleanStream.Close();
            
            fsFile.Close();
        }

        private static void EncryptPasswordConfig()
        {
            String fileName = Path.Combine(Application.StartupPath, ConstantUtil.pwFile);
            TripleDESCryptoServiceProvider cryptAlgorithm = ReadKeyIV();

            //Read the file
            FileStream fsFile = File.OpenRead(fileName);
            StreamReader srCleanStream = new StreamReader(fsFile, Encoding.UTF8);
            String allLines = srCleanStream.ReadToEnd();
            srCleanStream.Close();

            //Write the file
            fsFile = File.Create(fileName);
            CryptoStream csEncrypt = new CryptoStream(fsFile, cryptAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
            StreamWriter swEncStream = new StreamWriter(csEncrypt, Encoding.UTF8);
            swEncStream.Write(allLines);
            swEncStream.Close();

            fsFile.Close();
        }

        private static TripleDESCryptoServiceProvider ReadKeyIV()
        {
            //Read encryption key and IV
            TripleDESCryptoServiceProvider cryptAlgorithm = new TripleDESCryptoServiceProvider();
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography");

            String keyStr = (key == null) ? ConstantUtil.defaultKey : key.GetValue("MachineGuid").ToString();

            UTF8Encoding enc = new UTF8Encoding();
            cryptAlgorithm.Key = enc.GetBytes(keyStr.Substring(0, 24));
            cryptAlgorithm.IV = enc.GetBytes(ConstantUtil.defaultIV);

            return cryptAlgorithm;
        }

        #endregion Private Methods
    }
}
