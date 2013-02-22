using System;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.MessageBoxes
{
    /// <summary>
    /// Fatal error message box form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class ErrorO : Form
    {
        private readonly Exception exception;
        
        internal ErrorO(Form parent, String message, Exception exception)
        {
            InitializeComponent();
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

        private void copyErrorDescriptionPictureBox_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject((exception != null) ? GetFullErrorMessage() : errorLabel.Text, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
        }

        private void errorDetailsPictureBox_Click(object sender, EventArgs e)
        {
            WindowManager.ShowContent(Owner, (exception != null) ? GetFullErrorMessage() : errorLabel.Text);
        }

        #endregion Button Methods

        #region Private Methods

        private String GetFullErrorMessage()
        {
            return String.Format("{0}{1}{2}{1}{3}", errorLabel.Text, Environment.NewLine, exception.Message, exception.StackTrace);
        }

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            copyErrorMessageToolTip.SetToolTip(copyErrorDescriptionPictureBox, LanguageUtil.GetCurrentLanguageString("copyErrorDescriptionPictureBoxToolTip", Name));
            copyErrorMessageToolTip.SetToolTip(errorDetailsPictureBox, LanguageUtil.GetCurrentLanguageString("errorDetailsPictureBoxToolTip", Name));
        }

        #endregion Private Methods
    }
}
