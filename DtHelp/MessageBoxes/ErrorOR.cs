using System;
using System.Windows.Forms;
using DtHelp.Utils;

namespace DtHelp.MessageBoxes
{
    /// <summary>
    /// Error message box form.
    /// </summary>
    /// <author>Marco Macci�</author>
    internal partial class ErrorOR : Form
    {
        private readonly String cultureInternal;
        private readonly Exception exception;

        internal ErrorOR(Form parent, String message, Exception exception, String culture)
        {
            InitializeComponent();
            cultureInternal = culture;
            SetLanguage();

            if (parent == null)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }

            errorLabel.Text = message;
            if (errorLabel.Width > ConstantUtil.standardMessageWidth)
            {
                Width = Width + errorLabel.Width - ConstantUtil.standardMessageWidth;
            }

            this.exception = exception;
        }

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void reportBugButton_Click(object sender, EventArgs e)
        {
            ReportBug reportBugWindow = new ReportBug();
            reportBugWindow.Owner = Owner;
            reportBugWindow.InitializeForm(cultureInternal);
            reportBugWindow.errorMessageTextBox.Text = exception != null ? exception.Message : errorLabel.Text;
            reportBugWindow.Show(Owner);
            DialogResult = DialogResult.Yes;
        }

        private void copyErrorDescriptionPictureBox_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(exception != null ? exception.Message : errorLabel.Text);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this, cultureInternal);
            copyErrorMessageToolTip.SetToolTip(copyErrorDescriptionPictureBox, LanguageUtil.GetCurrentLanguageString("copyErrorDescriptionPictureBoxToolTip", Name, cultureInternal));
        }

        #endregion Private Methods
    }
}
