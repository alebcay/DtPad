using System;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad.MessageBoxes
{
    /// <summary>
    /// Question message box form (with "yes", "no", "no to all" and "cancel" answers).
    /// </summary>
    /// <author>Marco Macci�</author>
    internal partial class QuestionYNNAC : Form
    {
        internal QuestionYNNAC(Form parent, String message)
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

        private void noButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
		
		private void noToAllButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Retry;
		}

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion Button Methods
    }
}
