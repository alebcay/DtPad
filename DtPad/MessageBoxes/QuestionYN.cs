using System;
using System.Drawing;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad.MessageBoxes
{
    /// <summary>
    /// Question message box form (with "yes" and "no" answers).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class QuestionYN : Form
    {
        internal QuestionYN(Form parent, String message)
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);

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
