using System;
using System.Drawing;
using System.Windows.Forms;
using DtPadUninstaller.Utils;

namespace DtPadUninstaller.MessageBoxes
{
    /// <summary>
    /// Question message box form (with "yes" and "no" answers).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class QuestionYN : Form
    {
        private readonly String cultureInternal;

        internal QuestionYN(Form parent, String message, String culture)
        {
            InitializeComponent();
            cultureInternal = culture;
            LanguageUtil.SetCurrentLanguage(this, cultureInternal);

            if (parent == null)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }

            questionLabel.Text = message;
            if (questionLabel.Width <= ConstantUtil.standardMessageWidth)
            {
                return;
            }

            Width = Width + questionLabel.Width - ConstantUtil.standardMessageWidth;
            noButton.Location = new Point(Width - ConstantUtil.standardButtonPositionFromRight, noButton.Location.Y);
            yesButton.Location = new Point(noButton.Location.X - ConstantUtil.standardButtonDistanceFromRight, yesButton.Location.Y);
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

        #endregion Button Methods
    }
}
