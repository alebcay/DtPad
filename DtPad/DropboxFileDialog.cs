using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AppLimit.CloudComputing.SharpBox;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Dropbox file dialog (open and save) DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class DropboxFileDialog : StringForm
    {
        private Form1 form;
        private const int folderIconIndex = 0;
        private const int fileIconIndex = 1;
        private String selectedFilePosition = "/";

        internal enum WindowType
        {
            [Description("Save a file on Dropbox")]
            Save,
            [Description("Open a file on Dropbox")]
            Open
        }

        #region Internal Instance Fields

        internal WindowType windowType { private get; set; }

        #endregion Internal Instance Fields

        #region Window Methods

        internal bool InitializeForm()
        {
            form = (Form1)Owner;
            form.DropboxCloudStorage = DropboxManager.InitCouldStorage(form, form.DropboxCloudStorage);
            if (form.DropboxCloudStorage == null)
            {
                WindowManager.CloseForm(this);
                return false;
            }

            InitializeComponent();
            if (windowType == WindowType.Open)
            {
                fileNameTextBox.ReadOnly = true;
                //fileNameTextBox.ContextMenuStrip = textMenuStrip;
            }
            SetLanguage();
            ControlUtil.SetContextMenuStrip(this, fileNameTextBox);

            if (!String.IsNullOrEmpty(form.LastDropboxFolder) && DropboxManager.ExistsDirectory(form, form.LastDropboxFolder))
            {
                positionLabel.Text = form.LastDropboxFolder;
            }

            viewComboBox.SelectedIndex = Convert.ToInt32(LookFeelUtil.ListViewView.List);
            SetFileDialogFilter(); //associazione saveAsComboBox

            if (!ConfigUtil.GetBoolParameter("EnableDropboxDelete"))
            {
                fseListView.ContextMenuStrip = null;
            }

            return true;
        }

        private void DropboxFileDialog_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void fileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !(String.IsNullOrEmpty(fileNameTextBox.Text));
        }

        private void fseListView_ItemActivate(object sender, EventArgs e)
        {
            ListView item = (ListView)sender;

            switch (item.FocusedItem.ImageIndex)
            {
                case folderIconIndex:
                    String position = positionLabel.Text;
                    if (!position.EndsWith("/"))
                    {
                        position += "/";
                    }

                    LoadFileList(DropboxManager.GetDirectory(form, position + item.FocusedItem.Text));
                    break;
                case fileIconIndex:
                    OpenSave();
                    break;
            }
        }

        private void fseListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.ImageIndex != fileIconIndex)
            {
                return;
            }

            fileNameTextBox.Text = e.Item.Text;
            selectedFilePosition = positionLabel.Text;
        }

        private void saveAsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFileList(DropboxManager.GetDirectory(form, positionLabel.Text));
        }

        private void fseListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            Rename(sender, e);
        }

        private void dropboxFileDialogContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            deleteToolStripMenuItem1.Enabled = (fseListView.SelectedItems.Count > 0);
        }

        private void viewComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (viewComboBox.SelectedIndex)
            {
                case (int)LookFeelUtil.ListViewView.LargeIcon:
                    fseListView.View = View.LargeIcon;
                    break;
                case (int)LookFeelUtil.ListViewView.SmallIcon:
                    fseListView.View = View.SmallIcon;
                    break;
                case (int)LookFeelUtil.ListViewView.List:
                    fseListView.View = View.List;
                    break;
                case (int)LookFeelUtil.ListViewView.Tile:
                    fseListView.View = View.Tile;
                    break;
            }
        }

        #endregion Window Methods

        #region Button Methods

        private void superiorLevelButton_Click(object sender, EventArgs e)
        {
            switch (positionLabel.Text.LastIndexOf('/'))
            {
                case 0:
                    LoadFileList(DropboxManager.GetDirectory(form, "/"));
                    break;

                default:
                    LoadFileList(DropboxManager.GetDirectory(form, positionLabel.Text.Substring(0, positionLabel.Text.LastIndexOf('/'))));
                    break;
            }
        }

        private void newFolderButton_Click(object sender, EventArgs e)
        {
            WindowManager.ShowNameEntry(this);

            if (!String.IsNullOrEmpty(newObjectName) && DropboxManager.CreateDirectoryOnDropbox(form, newObjectName, DropboxManager.GetDirectory(form, positionLabel.Text)))
            {
                LoadFileList(DropboxManager.GetDirectory(form, positionLabel.Text));
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            OpenSave();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Delete();
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private void LoadFileList(ICloudDirectoryEntry directory)
        {
            fseListView.Cursor = Cursors.WaitCursor;

            fseListView.Items.Clear();
            IEnumerable<DropboxFSEObject> folderContentList = DropboxManager.GetFolderContent(directory, GetSelectedExtension()); //caricamento fseListView

            foreach (DropboxFSEObject folderContent in folderContentList.Where(folderContent => folderContent.Type == DropboxFSEObject.FSEType.Directory))
            {
                fseListView.Items.Add(new ListViewItem(folderContent.Name, folderIconIndex));
            }
            foreach (DropboxFSEObject folderContent in folderContentList.Where(folderContent => folderContent.Type == DropboxFSEObject.FSEType.File))
            {
                fseListView.Items.Add(new ListViewItem(folderContent.Name, fileIconIndex));
            }

            positionLabel.Text = DropboxManager.GetFolderCompletePath(directory);
            superiorLevelButton.Enabled = positionLabel.Text != "/";

            fseListView.Cursor = Cursors.Default;
        }

        private String GetSelectedExtension()
        {
            String toAnalyze = saveAsComboBox.SelectedItem.ToString();
            int startPosition = toAnalyze.LastIndexOf('(') + 1;

            return toAnalyze.Substring(startPosition, toAnalyze.LastIndexOf(')') - startPosition);
        }

        private bool ValidateFileName()
        {
            if (DropboxManager.StringContainsCharNotAllowed(fileNameTextBox.Text))
            {
                WindowManager.ShowAlertBox(this, LanguageUtil.GetCurrentLanguageString("DPDefaultFileCharNotAllowed", Name));
                fileNameTextBox.Focus();

                return false;
            }

            return true;
        }

        private void SetFileDialogFilter()
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            int defaultExtension;
            String defaultExtensionShortString;
            String extensions = ExtensionManager.GetFileDialogFilter(out defaultExtension, out defaultExtensionShortString);
            String[] extensionsSplit = extensions.Split(new[] {'|'});

            int i = 0;
            while (i < extensionsSplit.Length)
            {
                saveAsComboBox.Items.Add(extensionsSplit[i]);
                i = i + 2;
            }

            if (defaultExtension != -1 && defaultExtension < saveAsComboBox.Items.Count)
            {
                saveAsComboBox.SelectedIndex = defaultExtension;
            }
            fileNameTextBox.Text = defaultExtensionShortString;

            String fileNameTab = ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage);
            if (windowType == WindowType.Save && !String.IsNullOrEmpty(fileNameTab))
            {
                fileNameTextBox.Text = Path.GetFileName(fileNameTab);
            }
        }

        private void OpenSave()
        {
            if (windowType == WindowType.Open)
            {
                okButton.Enabled = false;
                cancelButton.Enabled = false;
                Refresh();

                if (FileManager.OpenFileFromDropbox(form, this, fileNameTextBox.Text, selectedFilePosition))
                {
                    WindowManager.CloseForm(this);
                }
                else
                {
                    okButton.Enabled = true;
                    cancelButton.Enabled = true;
                }
            }
            else
            {
                if (!ValidateFileName())
                {
                    return;
                }

                okButton.Enabled = false;
                cancelButton.Enabled = false;
                Refresh();

                if (FileManager.SaveFileOnDropbox(form, this, fileNameTextBox.Text, positionLabel.Text))
                {
                    WindowManager.CloseForm(this);
                }
                else
                {
                    okButton.Enabled = true;
                    cancelButton.Enabled = true;
                }
            }
        }

        private void Rename(object sender, LabelEditEventArgs e)
        {
            ListView item = (ListView)sender;

            String oldName = item.Items[Convert.ToInt32(e.Item)].Text;
            String newName = e.Label;

            if (String.IsNullOrEmpty(newName) || oldName == e.Label || !ValidateFileName())
            {
                e.CancelEdit = true;
                return;
            }

            switch (item.FocusedItem.ImageIndex)
            {
                case folderIconIndex:
                    {
                        String folderToRename = positionLabel.Text;
                        if (!folderToRename.EndsWith("/"))
                        {
                            folderToRename += "/";
                        }
                        folderToRename += oldName;

                        if (!DropboxManager.RenameFolder(form, DropboxManager.GetDirectory(form, folderToRename), newName))
                        {
                            e.CancelEdit = true;
                        }
                    }
                    break;
                case fileIconIndex:
                    if (!DropboxManager.RenameFile(form, DropboxManager.GetDirectory(form, positionLabel.Text), oldName, newName))
                    {
                        e.CancelEdit = true;
                    }
                    break;
            }
        }

        private void Delete()
        {
            String name = fseListView.SelectedItems[0].Text;

            switch (fseListView.FocusedItem.ImageIndex)
            {
                case folderIconIndex:
                    {
                        String folderToDelete = positionLabel.Text;
                        if (!folderToDelete.EndsWith("/"))
                        {
                            folderToDelete += "/";
                        }
                        folderToDelete += name;

                        DropboxManager.DeleteFolder(form, DropboxManager.GetDirectory(form, folderToDelete));
                    }
                    break;
                case fileIconIndex:
                    DropboxManager.DeleteFile(form, DropboxManager.GetDirectory(form, positionLabel.Text), name);
                    break;
            }
        }

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);

            if (windowType == WindowType.Open)
            {
                okButton.Text = LanguageUtil.GetCurrentLanguageString("okButton_Open", Name);
                saveAsLabel.Text = LanguageUtil.GetCurrentLanguageString("saveAsLabel_Open", Name);
                saveInLabel.Text = LanguageUtil.GetCurrentLanguageString("saveInLabel_Open", Name);
                Text = LanguageUtil.GetCurrentLanguageString("Title_Open", Name);
            }

            dropboxFileDialogToolTip.SetToolTip(superiorLevelButton, LanguageUtil.GetCurrentLanguageString("superiorLevelButtonToolTip", Name));
            dropboxFileDialogToolTip.SetToolTip(newFolderButton, LanguageUtil.GetCurrentLanguageString("newFolderButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
