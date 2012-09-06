using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Merge tabs into one DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class MergeTabs : Form
    {
        private String[] itemValues;

        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            Form1 form = (Form1)Owner;

            itemValues = new String[form.pagesTabControl.TabPages.Count];

            for (int i = 0; i < form.pagesTabControl.TabPages.Count; i++)
            {
                XtraTabPage tabPage = form.pagesTabControl.TabPages[i];
                tabPagesListBox.Items.Add(String.Format("{0} - {1}", i + 1, tabPage.Text));
                itemValues[i] = tabPage.Name;
            }

            markSeparationTextBox.Text = ConfigUtil.GetStringParameter("MergeTabSeparation").Replace("\\r\\n", Environment.NewLine);
            moveUpButton.Enabled = tabPagesListBox.Items.Count > 1;
            moveDownButton.Enabled = tabPagesListBox.Items.Count > 1;
        }

        private void tabPagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = tabPagesListBox.SelectedItems.Count > 1;
            moveUpButton.Enabled = tabPagesListBox.Items.Count > 1;
            moveDownButton.Enabled = tabPagesListBox.Items.Count > 1;
        }

        private void markSeparationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            markSeparationTextBox.Enabled = markSeparationCheckBox.Checked;
        }

        private void MergeTabs_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = ControlUtil.FocusedTextBoxCanUndo(sender); //markSeparationTextBox.CanUndo;
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;
            XtraTabControl pagesTabControl = form.pagesTabControl;

            if (pagesTabControl.TabPages.Count != itemValues.Length)
            {
                WindowManager.ShowInfoBox(this, LanguageUtil.GetCurrentLanguageString("Conflict", Name));
                tabPagesListBox.Items.Clear();
                InitializeForm();
                return;
            }

            MergeManager.MergeTabs(this, itemValues);
            WindowManager.CloseForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            itemValues = MergeManager.MoveItemsUp(this, itemValues);
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            itemValues = MergeManager.MoveItemsDown(this, itemValues);
        }

        #endregion Button Methods

        //#region ContextMenu Methods

        //private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    TextManager.UndoControl(markSeparationTextBox);
        //}

        //private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    TextManager.CutControl(markSeparationTextBox);
        //}

        //private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    TextManager.CopyControl(markSeparationTextBox);
        //}

        //private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    TextManager.PasteControl(markSeparationTextBox);
        //}

        //private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    TextManager.DeleteControl(markSeparationTextBox);
        //}

        //private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    TextManager.SelectAllControl(markSeparationTextBox);
        //}

        //#endregion ContextMenu Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            mergeTabsToolTip.SetToolTip(moveDownButton, LanguageUtil.GetCurrentLanguageString("moveDownButtonToolTip", Name));
            mergeTabsToolTip.SetToolTip(moveUpButton, LanguageUtil.GetCurrentLanguageString("moveUpButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
