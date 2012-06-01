using System;
using System.Net;
using System.Windows.Forms;
using DtPadSetup.Utils;

namespace DtPadSetup.Managers
{
    /// <summary>
    /// Options manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class OptionManager
    {
        private const String className = "OptionManager";

        #region Internal Methods

        internal static void CheckProxyStatus(Form1 form, String culture)
        {
            PictureBox statusPictureBox = form.statusPictureBox;

            statusPictureBox.Image = !CheckProxyStatusReturn(form, culture) ? ImageResource.exit : ImageResource.confirm;
        }

        internal static void CheckProxyStatusEnabled(Form1 form)
        {
            CheckBox enableProxySettingsCheckBox = form.enableProxySettingsCheckBox;
            TextBox usernameTextBox = form.usernameTextBox;
            TextBox passwordTextBox = form.passwordTextBox;
            TextBox confirmTextBox = form.domainTextBox;
            PictureBox statusPictureBox = form.statusPictureBox;
            Button testProxyButton = form.testProxyButton;

            if (!enableProxySettingsCheckBox.Checked)
            {
                usernameTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
                confirmTextBox.Enabled = false;
                statusPictureBox.Visible = false;
                testProxyButton.Enabled = false;
            }
            else
            {
                usernameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                confirmTextBox.Enabled = true;
                testProxyButton.Enabled = true;
            }
        }

        internal static String GetLanguage(Form1 form)
        {
            ComboBox languageComboBox = form.languageComboBox;

            if (languageComboBox.SelectedIndex == 0)
            {
                return "en";
            }

            return languageComboBox.SelectedIndex == 1 ? "it" : "en";
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool CheckProxyStatusReturn(Form1 form, String culture)
        {
            CheckBox enableProxySettingsCheckBox = form.enableProxySettingsCheckBox;
            TextBox usernameTextBox = form.usernameTextBox;
            TextBox passwordTextBox = form.passwordTextBox;
            TextBox domainTextBox = form.domainTextBox;
            const int timeout = 10;

            if (!enableProxySettingsCheckBox.Checked || String.IsNullOrEmpty(passwordTextBox.Text) || String.IsNullOrEmpty(passwordTextBox.Text))
            {
                return false;
            }

            try
            {
                WebRequest webRequest = WebRequest.Create("http://www.google.com/");
                webRequest = ProxyUtil.InitWebRequestProxy(webRequest, true, usernameTextBox.Text, passwordTextBox.Text, domainTextBox.Text);
                webRequest.Timeout = timeout * 1000;
                webRequest.GetResponse();

                return true;
            }
            catch (TimeoutException)
            {
                WindowManager.ShowAlertBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("ConnectionTimeout", className, culture), timeout), culture);
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion Private Methods
    }
}
