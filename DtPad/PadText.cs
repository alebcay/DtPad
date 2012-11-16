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
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            LookFeelUtil.SetLookAndFeel(content2contextMenuStrip);
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

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = whiteCharacterTextBox.CanUndo;
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

        #region ContextMenu Methods

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.UndoControl(whiteCharacterTextBox);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CutControl(whiteCharacterTextBox);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(whiteCharacterTextBox);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.PasteControl(whiteCharacterTextBox);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.DeleteControl(whiteCharacterTextBox);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(whiteCharacterTextBox);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(widthNumericUpDown);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextManager.PasteControl(widthNumericUpDown);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(widthNumericUpDown);
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            padTextToolTip.SetToolTip(absoluteWidthPictureBox, LanguageUtil.GetCurrentLanguageString("absoluteWidthPictureBoxToolTip", Name));
        }

        #endregion Private Methods
    }
}
