using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// File renaming DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class FileRename : Form
    {
        private FileTypes fileType;

        internal enum FileTypes
        {
            [Description("Rename of a text file")]
            Text,
            [Description("Rename of a session file")]
            Session
        }
        
        #region Window Methods

        internal void InitializeForm(FileTypes fileTypeToRename, String fileNameAndPath)
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(new[] { contentContextMenuStrip, contentContextMenuStrip1 });
            LanguageUtil.SetCurrentLanguage(this);

            fileType = fileTypeToRename;

            fileNameValueLabel.Text = StringUtil.CheckStringLength(Path.GetFileName(fileNameAndPath), 60);
            folderValueLabel.Text = StringUtil.CheckStringLength(Path.GetDirectoryName(fileNameAndPath), 60);
            renameToTextBox.Text = Path.GetFileName(fileNameAndPath);

            renameToTextBox.Select();

            if (renameToTextBox.Text.Contains("."))
            {
                renameToTextBox.Select(0, renameToTextBox.Text.LastIndexOf('.'));
            }
            else
            {
                renameToTextBox.SelectAll();
            }
        }

        private void FileRename_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void renameToTextBox_TextChanged(object sender, EventArgs e)
        {
            renameButton.Enabled = !String.IsNullOrEmpty(renameToTextBox.Text);
        }

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = renameToTextBox.CanUndo;
        }

        #endregion Window Methods

        #region Button Methods

        private void renameButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            switch (fileType)
            {
                case FileTypes.Text:
                    FileManager.RenameFile(form, renameToTextBox.Text);
                    break;
                case FileTypes.Session:
                    SessionManager.RenameSession(form, renameToTextBox.Text);
                    break;
            }

            WindowManager.CloseForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods
    }
}
