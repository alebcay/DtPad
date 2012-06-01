using System;
using System.Windows.Forms;
using DtPad.Exceptions;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.UserControls
{
    /// <summary>
    /// Search in files explorer user control.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class SearchInFilesPanel : UserControl
    {
        internal SearchInFilesPanel()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(searchInFilesContextMenuStrip);
            LookFeelUtil.SetLookAndFeel(textMenuStrip);
        }

        #region Window Methods

        private void searchInFilesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            openFileToolStripButton.Enabled = searchInFilesListBox.SelectedItems.Count > 0;
        }

        //private void searchInFilesContextMenuStrip_Opening(object sender, CancelEventArgs e)
        //{
        //    openSelectedFilesToolStripMenuItem.Enabled = searchInFilesListBox.SelectedItems.Count > 0;
        //}

        private void searchInFilesListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            int selectionPosition = searchInFilesListBox.IndexFromPoint(e.X, e.Y);

            if (selectionPosition >= 0)
            {
                searchInFilesListBox.ClearSelected();
                searchInFilesListBox.SelectedIndex = selectionPosition;
                ToggleContextMenuStrip(true);
            }
            else
            {
                ToggleContextMenuStrip(false);
            }
        }

        private void searchInFilesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            if (form == null)
            {
                throw new ParentFormNullException();
            }

            int selectionPosition = searchInFilesListBox.IndexFromPoint(e.X, e.Y);
            if (selectionPosition < 0)
            {
                return;
            }

            searchInFilesListBox.SelectedIndex = selectionPosition;

            String[] fileName = new String[1];
            fileName[0] = SearchFilesManager.GetFileCompletePathName(this, searchInFilesListBox.SelectedItem.ToString()); //pathBaseToolStripLabel.Text + searchInFilesListBox.SelectedItem.ToString().Substring(2);
            FileManager.OpenFile(form, form.TabIdentity, fileName);
        }

        #endregion Window Methods

        #region Button Methods

        private void newSearchToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;
            WindowManager.ShowSearchInFiles(form);
        }

        private void openFileToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchFilesManager.OpenSelectedFileItem(form, this);
        }

        private void exportListToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchFilesManager.ExportList(form, this);
        }

        private void clearToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchFilesManager.ClearList(form, this);
            openFileToolStripButton.Enabled = false;
            clearToolStripButton.Enabled = false;
            exportListToolStripButton.Enabled = false;
            infoDirLabel.Text = String.Empty;
            infoTextLabel.Text = String.Empty;
        }

        #endregion Button Methods

        #region Context Methods

        private void openSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchFilesManager.OpenSelectedFileItem(form, this);
        }

        private void copyFileFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchFilesManager.CopyFileFullPath(this);
        }

        #endregion Context Methods

        #region Multilanguage Methods

        internal void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, searchInFilesContextMenuStrip.Items);
            LanguageUtil.CicleControls(Name, textMenuStrip.Items);
            //LanguageUtil.CicleControls(Name, infoPanel.Controls, false);
        }

        #endregion Multilanguage Methods

        #region Private Methods

        private void ToggleContextMenuStrip(bool status)
        {
            foreach (ToolStripItem item in searchInFilesContextMenuStrip.Items)
            {
                item.Enabled = status;
            }
        }

        #endregion Private Methods
    }
}
