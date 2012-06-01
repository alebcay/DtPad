using System;
using System.Drawing;
using System.Windows.Forms;
using DtPadSetup.Utils;

namespace DtPadSetup.MessageBoxes
{
    /// <summary>
    /// Warning message box form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class WarningYNC : Form
    {
        private readonly String cultureInternal;

        internal WarningYNC(Form parent, String message, String culture)
        {
            InitializeComponent();
            cultureInternal = culture;
            LanguageUtil.SetCurrentLanguage(this, cultureInternal);

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
            cancelButton.Location = new Point(Width - ConstantUtil.standardButtonPositionFromRight, cancelButton.Location.Y);
            noButton.Location = new Point(cancelButton.Location.X - ConstantUtil.standardButtonDistanceFromRight, noButton.Location.Y);
            yesButton.Location = new Point(noButton.Location.X - ConstantUtil.standardButtonDistanceFromRight, yesButton.Location.Y);
            //yesButton.Location = new Point(Width - ConstantUtil.standardButtonPositionFromRight, yesButton.Location.Y);
            //noButton.Location = new Point(yesButton.Location.X - ConstantUtil.standardButtonDistanceFromRight, noButton.Location.Y);
            //cancelButton.Location = new Point(noButton.Location.X - ConstantUtil.standardButtonDistanceFromRight, cancelButton.Location.Y);
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
