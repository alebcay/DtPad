using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Pad text function DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class PadText : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            ControlUtil.SetContextMenuStrip(this, new[] { whiteCharacterTextBox, (Control)widthNumericUpDown });
            SetLanguage();
        }

        private void whiteCharacterTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = (whiteCharacterTextBox.Text.Length > 0);
        }

        private void PadText_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void leftCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            rightCheckBox.Checked = !leftCheckBox.Checked;
        }

        private void rightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            leftCheckBox.Checked = !rightCheckBox.Checked;
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            if (leftCheckBox.Checked)
            {
                TextManager.PadToLeft(form, this);
            }
            else
            {
                TextManager.PadToRight(form, this);
            }

            WindowManager.CloseForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            padTextToolTip.SetToolTip(absoluteWidthPictureBox, LanguageUtil.GetCurrentLanguageString("absoluteWidthPictureBoxToolTip", Name));
        }

        #endregion Private Methods
    }
}
