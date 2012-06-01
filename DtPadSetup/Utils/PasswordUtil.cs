using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace DtPadSetup.Utils
{
    /// <summary>
    /// Password reading and writing util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class PasswordUtil
    {
        #region Internal Methods

        internal static void UpdateParameters(String[] parameterNames, String[] parameterValues, String executablePath)
        {
            try
            {
                Configuration configuration = GetPasswordConfig(executablePath);

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
                EncryptPasswordConfig(executablePath);
            }
        }

        #endregion Internal Methods

        #region Private Methods

        private static Configuration GetPasswordConfig(String executablePath)
        {
            DecryptPasswordConfig(executablePath);

            ExeConfigurationFileMap pwdConfig = new ExeConfigurationFileMap
                                                    {
                                                        ExeConfigFilename = Path.Combine(executablePath, ConstantUtil.pwFile)
                                                    };
            return ConfigurationManager.OpenMappedExeConfiguration(pwdConfig, ConfigurationUserLevel.None);
        }

        private static void DecryptPasswordConfig(String executablePath)
        {
            String fileName = Path.Combine(executablePath, ConstantUtil.pwFile);
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

        private static void EncryptPasswordConfig(String executablePath)
        {
            String fileName = Path.Combine(executablePath, ConstantUtil.pwFile);
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
