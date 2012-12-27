using System;
using System.Windows.Forms;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// String entry for new directory creation on Dropbox form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class NameEntry : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            SetLanguage();
            ControlUtil.SetContextMenuStrip(this, fileNameTextBox);
        }

        private void fileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            StringForm form = (StringForm)Owner;

            okButton.Enabled = !(String.IsNullOrEmpty(fileNameTextBox.Text));

            if (form.GetType() == typeof(DropboxFileDialog) && DropboxManager.StringContainsCharNotAllowed(fileNameTextBox.Text))
            {
                okButton.Enabled = false;
                WindowManager.ShowAlertBox(this, LanguageUtil.GetCurrentLanguageString("DPDefaultFileCharNotAllowed", Name));
                fileNameTextBox.Focus();
            }
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            StringForm form = (StringForm)Owner;

            form.newObjectName = fileNameTextBox.Text;
            WindowManager.CloseForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            StringForm form = (StringForm)Owner;

            form.newObjectName = String.Empty;
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            StringForm form = (StringForm)Owner;
            
            if (form.GetType() == typeof(DropboxFileDialog))
            {
                LanguageUtil.SetCurrentLanguage(this);

                fileNameLabel.Text = LanguageUtil.GetCurrentLanguageString("fileNameLabel_DropboxFileDialog", Name);
                okButton.Text = LanguageUtil.GetCurrentLanguageString("okButton_DropboxFileDialog", Name);
                Text = LanguageUtil.GetCurrentLanguageString("Title_DropboxFileDialog", Name);
            }
            else if (form.GetType() == typeof(ZipExtract))
            {
                LanguageUtil.SetCurrentLanguage(this);

                fileNameLabel.Text = LanguageUtil.GetCurrentLanguageString("fileNameLabel_ZipExtract", Name);
                okButton.Text = LanguageUtil.GetCurrentLanguageString("okButton_ZipExtract", Name);
                Text = LanguageUtil.GetCurrentLanguageString("Title_ZipExtract", Name);
            }
        }

        #endregion Private Methods
    }
}
