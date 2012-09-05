using System;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad.MessageBoxes
{
    /// <summary>
    /// Warning message box form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class WarningYNC : Form
    {
        internal WarningYNC(Form parent, String message)
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);

            if (parent == null)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }

            warningLabel.Text = message;
            if (warningLabel.Width <= ConstantUtil.standardMessageWidth)
            {
                return;
            }

            Width = Width + warningLabel.Width - ConstantUtil.standardMessageWidth;
        }

        #region Button Methods

        private void yesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion Button Methods
    }
}
