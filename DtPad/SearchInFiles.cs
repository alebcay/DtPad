using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// In files search DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class SearchInFiles : Form
    {
        private Thread newThread;
        private String closeButtonText;
        private int previousWidth;
        private int previousLocationX;
        private int previousLocationY;
        private bool enlarged;
        private delegate void ThreadCallBack();
        private delegate void ThreadCallBackResult(List<String> result);

        internal String searchFolder { get; private set; }
        
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            FileListManager.LoadRecentSearchInFilesDirs(this);
        }

        private void SearchInFiles_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void searchFolderComboBox_TextChanged(object sender, EventArgs e)
        {
            searchFolder = searchFolderComboBox.Text;
        }

        private void SearchInFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            KillExecution();
        }

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = ControlUtil.FocusedTextBoxCanUndo(sender);
        }

        private void resizeButton_Click(object sender, EventArgs e)
        {
            if (!enlarged)
            {
                previousWidth = Width;
                previousLocationX = Location.X;
                previousLocationY = Location.Y;
                enlarged = true;

                Location = new Point(100, Location.Y);
                Size = new Size(Screen.FromControl(this).Bounds.Width - 200, Height);
                resizeButton.Image = ToolbarResource.arrow_left;
            }
            else
            {
                enlarged = false;

                Location = new Point(previousLocationX, previousLocationY);
                Size = new Size(previousWidth, Height);
                resizeButton.Image = ToolbarResource.arrow_right;
            }
        }

        #endregion Window Methods

        #region Button Methods

        private void searchFolderButton_Click(object sender, EventArgs e)
        {
            SearchFilesManager.GetPath(this);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textToSearchTextBox.Text))
            {
                WindowManager.ShowAlertBox(this, LanguageUtil.GetCurrentLanguageString("TextToSearchEmpty", Name));
                return;
            }
            if (String.IsNullOrEmpty(searchFolderComboBox.Text) || !Directory.Exists(searchFolderComboBox.Text))
            {
                WindowManager.ShowAlertBox(this, LanguageUtil.GetCurrentLanguageString("FolderNotExists", Name));
                return;
            }
            if (String.IsNullOrEmpty(filenamePatternTextBox.Text))
            {
                filenamePatternTextBox.Text = "*.*";
                Refresh();
            }

            FileListManager.SetNewRecentSearchInFilesDirs(this, searchFolderComboBox.Text);

            StartExecution();

            newThread = new Thread(SearchTextInFiles);
            newThread.Start();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //if (newThread != null && newThread.IsAlive)
            //{
            //    newThread.Abort();
            //}

            if (okButton.Enabled)
            {
                WindowManager.HiddenForm(this);
            }
            else
            {
                KillExecution();
                Invoke(new ThreadCallBack(StopExecution));
            }
        }

        #endregion Button Methods

        #region Delegate Methods

        private void SearchTextInFiles()
        {
            SearchFilesManager.SearchTextInFiles(this, new ThreadCallBackResult(ShowResult));
            Invoke(new ThreadCallBack(StopExecution));
        }

        private void StartExecution()
        {
            okButton.Enabled = false;
            closeButtonText = closeButton.Text;
            closeButton.Text = LanguageUtil.GetCurrentLanguageString("cancelButton", Name);
            searchInProgressLabel.Visible = true;
            searchInProgressPictureBox.Visible = true;
            Refresh();
        }

        private void StopExecution()
        {
            searchInProgressPictureBox.Visible = false;
            searchInProgressLabel.Visible = false;
            closeButton.Text = closeButtonText;
            okButton.Enabled = true;
        }

        private void ShowResult(List<String> result)
        {            
            if (result.Count <= 0)
            {
                searchInProgressPictureBox.Visible = false;
                searchInProgressLabel.Visible = false;
                WindowManager.ShowInfoBox(this, LanguageUtil.GetCurrentLanguageString("NoResults", Name));
                return;
            }
            
            Form1 form = (Form1)Owner;

            XtraTabControl verticalTabControl = form.verticalTabControl;
            ToolStripButton verticalContainerToolStripButton = form.verticalContainerToolStripButton;
            XtraTabPage searchInFilesTabPage = form.searchInFilesTabPage;
            ListBox searchInFilesListBox = form.searchInFilesPanel.searchInFilesListBox;
            TextBox infoDirLabel = form.searchInFilesPanel.infoDirLabel;
            TextBox infoTextLabel = form.searchInFilesPanel.infoTextLabel;
            ToolStripButton clearToolStripButton = form.searchInFilesPanel.clearToolStripButton;
            ToolStripButton exportListToolStripButton = form.searchInFilesPanel.exportListToolStripButton;
            ToolStripLabel pathBaseToolStripLabel = form.searchInFilesPanel.pathBaseToolStripLabel;

            searchInFilesListBox.Items.Clear();
            Refresh();

            infoDirLabel.Text = searchFolderComboBox.Text; //LanguageUtil.GetCurrentLanguageString("InfoDir", Name) + " " + searchFolderComboBox.Text;
            infoTextLabel.Text = LanguageUtil.GetCurrentLanguageString("InfoText", Name) + " " + textToSearchTextBox.Text;

            foreach(String fileName in result)
            {
                searchInFilesListBox.Items.Add(fileName);
            }
            clearToolStripButton.Enabled = true;
            exportListToolStripButton.Enabled = true;

            if (!verticalContainerToolStripButton.Checked)
            {
                WindowManager.CheckInternalExplorer(form, !verticalContainerToolStripButton.Checked, true);
            }

            verticalTabControl.SelectedTabPage = searchInFilesTabPage;

            pathBaseToolStripLabel.Text = searchFolderComboBox.Text;
        }

        #endregion Delegate Methods

        #region Private Methods

        private void KillExecution()
        {
            if (newThread != null && newThread.IsAlive)
            {
                newThread.Abort();
                GC.Collect(); //I perform a GC collection just because search in files deals lot of memory that is useless after its closure.
            }
        }

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            searchInFilesToolTip.SetToolTip(filenamePatternPictureBox, LanguageUtil.GetCurrentLanguageString("filenamePatternPictureBoxToolTip", Name));
            searchInFilesToolTip.SetToolTip(exclusionPatternPictureBox, LanguageUtil.GetCurrentLanguageString("exclusionPatternPictureBoxToolTip", Name));
            searchInFilesToolTip.SetToolTip(resizeButton, LanguageUtil.GetCurrentLanguageString("resizeButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
