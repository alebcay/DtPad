using System;
using System.Drawing;
using System.Windows.Forms;
using DtHelp.Utils;

namespace DtHelp.MessageBoxes
{
    /// <summary>
    /// Fatal error message box form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class ErrorO : Form
    {
        private readonly String cultureInternal;
        private readonly Exception exception;
        
        internal ErrorO(Form parent, String message, Exception exception, String culture)
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
                okButton.Location = new Point(Width - ConstantUtil.standardButtonPositionFromRight, okButton.Location.Y);
            }

            this.exception = exception;
        }

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
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
