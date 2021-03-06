using System;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad.MessageBoxes
{
    /// <summary>
    /// Question message box form (with "yes", "yes to all", "no" and "cancel" answers).
    /// </summary>
    /// <author>Marco Macci�</author>
    internal partial class QuestionYYANC : Form
    {
        internal QuestionYYANC(Form parent, String message)
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
        }

        #region Button Methods

        private void yesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
		
		private void yesToAllButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Retry;
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
