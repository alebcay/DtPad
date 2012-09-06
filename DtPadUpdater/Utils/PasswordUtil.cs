using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DtPadUpdater.Exceptions;
using DtPadUpdater.Objects;
using Microsoft.Win32;

namespace DtPadUpdater.Utils
{
    /// <summary>
    /// Password reading and writing util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class PasswordUtil
    {
        private const String className = "PasswordUtil";

        #region Internal Methods

        internal static List<PasswordObject> GetStringParameters(IEnumerable<String> parameterNames, String culture)
        {
            Configuration configuration = GetPasswordConfig();
            List<PasswordObject> passwordList = new List<PasswordObject>();

            foreach (String parameterName in parameterNames)
            {
                String parameterValue = configuration.AppSettings.Settings[parameterName].Value;
                if (parameterValue == null)
                {
                    throw new ConfigException(String.Format(LanguageUtil.GetCurrentLanguageString("NoValue", className, culture), parameterName));
                }

                passwordList.Add(new PasswordObject(parameterName, parameterValue));
            }

            EncryptPasswordConfig();

            return passwordList;
        }

        #endregion Internal Methods

        #region Private Methods

        private static Configuration GetPasswordConfig()
        {
            DecryptPasswordConfig();

            ExeConfigurationFileMap pwdConfig = new ExeConfigurationFileMap { ExeConfigFilename = Path.Combine(Application.StartupPath, ConstantUtil.pwFile) };
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
            finally
            {
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
