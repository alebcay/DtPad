using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// User report DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class ReportBug : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);
            ControlUtil.SetContextMenuStrip(this, new[] { nameTextBox, emailTextBox, errorMessageTextBox, descriptionTextBox });
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckRequiredFields();
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckRequiredFields();
        }

        private void areaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckRequiredFields();
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckRequiredFields();
        }

        private void ReportBug_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            EmailManager.SendBugReport(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void CheckRequiredFields()
        {
            if (!String.IsNullOrEmpty(nameTextBox.Text) && !String.IsNullOrEmpty(emailTextBox.Text) && areaComboBox.SelectedIndex > 0
                && !String.IsNullOrEmpty(descriptionTextBox.Text.Trim()))
            {
                sendButton.Enabled = true;
            }
            else
            {
                sendButton.Enabled = false;
            }
        }

        #endregion Private Methods
    }
}
