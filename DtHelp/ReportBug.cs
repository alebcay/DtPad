using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtHelp.Managers;
using DtHelp.Utils;

namespace DtHelp
{
    /// <summary>
    /// User report DtHelp form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class ReportBug : Form
    {
        private String cultureInternal;
        
        #region Window Methods

        internal void InitializeForm(String culture)
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel((Form1)Owner, contentContextMenuStrip);
            cultureInternal = culture;
            LanguageUtil.SetCurrentLanguage(this, cultureInternal);
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckRequiredFields();
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckRequiredFields();
        }

        private void areaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckRequiredFields();
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckRequiredFields();
        }

        private void ReportBug_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e, cultureInternal);
        }

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = ControlUtil.FocusedTextBoxCanUndo(sender);
        }

        #endregion Window Methods

        #region Button Methods

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            EmailManager.SendBugReport(this, cultureInternal);
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.UndoControl(ControlUtil.GetFocusedControl(sender));
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CutControl(ControlUtil.GetFocusedControl(sender));
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(ControlUtil.GetFocusedControl(sender));
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.PasteControl(ControlUtil.GetFocusedControl(sender));
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.DeleteControl(ControlUtil.GetFocusedControl(sender));
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(ControlUtil.GetFocusedControl(sender));
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private void CheckRequiredFields()
        {
            if (!String.IsNullOrEmpty(nameTextBox.Text) && !String.IsNullOrEmpty(emailTextBox.Text) && areaComboBox.SelectedIndex > 0
                && !String.IsNullOrEmpty(descriptionTextBox.Text.Trim()))
            {
                sendButton.Enabled = true;
            }
            else
            {
                sendButton.Enabled = false;
            }
        }

        #endregion Private Methods
    }
}
