using System;
using System.Drawing;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad.MessageBoxes
{
    /// <summary>
    /// Error message box form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class ErrorOR : Form
    {
        private readonly Exception exception;
        
        internal ErrorOR(Form parent, String message, Exception exception)
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
                reportBugButton.Location = new Point(Width - ConstantUtil.standardButtonPositionFromRight, reportBugButton.Location.Y);
                okButton.Location = new Point(reportBugButton.Location.X - ConstantUtil.standardButtonDistanceFromRight, okButton.Location.Y);
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
            reportBugWindow.InitializeForm();
            reportBugWindow.errorMessageTextBox.Text = exception != null ? exception.Message : errorLabel.Text;
            reportBugWindow.Show();

            DialogResult = DialogResult.OK;
        }

        private void copyErrorDescriptionPictureBox_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(exception != null ? exception.Message : errorLabel.Text, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            copyErrorMessageToolTip.SetToolTip(copyErrorDescriptionPictureBox, LanguageUtil.GetCurrentLanguageString("copyErrorDescriptionPictureBoxToolTip", Name));
        }

        #endregion Private Methods
    }
}
