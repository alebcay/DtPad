using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Convert string into a encoded URL DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class UrlEncode : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            ControlUtil.SetContextMenuStrip(this, new[] { stringToEncodeTextBox, encodedURLTextBox });
            SetLanguage();
        }

        private void UrlEncode_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void encodeButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(stringToEncodeTextBox.Text))
            {
                encodedURLTextBox.Text = Uri.EscapeDataString(stringToEncodeTextBox.Text);
            }
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(encodedURLTextBox.Text))
            {
                stringToEncodeTextBox.Text = Uri.UnescapeDataString(encodedURLTextBox.Text);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            urlEncodeToolTip.SetToolTip(encodeButton, LanguageUtil.GetCurrentLanguageString("encodeButtonToolTip", Name));
            urlEncodeToolTip.SetToolTip(decodeButton, LanguageUtil.GetCurrentLanguageString("decodeButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
