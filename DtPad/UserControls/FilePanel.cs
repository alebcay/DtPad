using System;
using System.IO;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.UserControls
{
    /// <summary>
    /// File explorer user control.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class FilePanel : UserControl
    {
        //bool blnClose = true;

        internal FilePanel()
        {
            InitializeComponent();

        }

        #region Window Methods

        private void FilePanel_Load(object sender, EventArgs e)
        {
            if (ParentForm == null || ParentForm.GetType() != typeof(Form1))
            {
                return;
            }

            ControlUtil.SetContextMenuStrip(this, pathTextBox);
        }

        private void fileExplorerTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            fileExplorerTreeView.SelectedNode = e.Node;
            FileExplorerManager.LoadDirectory(form, e.Node, false);
        }

        private void fileExplorerTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.SelectNode(form);
        }

        private void fileExplorerTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            fileExplorerTreeView.SelectedNode = e.Node;
        }

        private void fileExplorerTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.OpenSelectedNode(form);
        }

        private void pathTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            if (e.KeyCode == Keys.Enter)
            {
                FileExplorerManager.GoToSelectedFolder(form);
            }
        }

        private void pathTextBox_Leave(object sender, EventArgs e)
        {
            pathTextBox.Select(pathTextBox.Text.Length, 0);
        }

        private void fileExplorerTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ExplorerManager.SelectNodeFromTreeView(e);
        }

        private void pathTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pathTextBox.Focus();
            }
        }

        #endregion Window Methods

        #region Menu Methods

        private void openSelectedFileToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.OpenSelectedNode(form);
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            if (fileExplorerTreeView.SelectedNode != null)
            {
                FileExplorerManager.LoadDirectory(form, fileExplorerTreeView.SelectedNode, true);
                pathTextBox.Text = fileExplorerTreeView.SelectedNode.ToolTipText;
                pathTextBox.Select(pathTextBox.Text.Length, 0);
            }
            else
            {
                FileExplorerManager.LoadFileTree(form, true);
            }
        }

        private void refreshDriveToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.LoadFileTree(form, true);
        }

        private void hiddenToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.LoadFileTree(form, true);
        }

        private void pathGoButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.GoToSelectedFolder(form);
        }

        #endregion Menu Methods

        #region File Context Methods

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.OpenSelectedNode(form);
        }

        private void filePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.ShowPropertiesSelectedNode(form);
        }

        #endregion File Context Methods

        #region Directory Context Methods

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.LoadDirectory(form, fileExplorerTreeView.SelectedNode, true);
        }

        private void openIntoWindowsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.OpenIntoWindowsExplorer(form, fileExplorerTreeView.SelectedNode);
        }

        private void listFolderContentIntoFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.ListFolderContentIntoFile(form, fileExplorerTreeView.SelectedNode, false);
        }

        private void listFolderContentWithLenghtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileExplorerManager.ListFolderContentIntoFile(form, fileExplorerTreeView.SelectedNode, true);
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchWithFilters();
        }

        private void listFolderContentWithPatternValueToolStripMenuItem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            SearchWithFilters();
        }

        #endregion Directory Context Methods

        #region Multilanguage Methods

        internal void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, fileContextMenuStrip.Items);
            LanguageUtil.CicleControls(Name, directoryContextMenuStrip.Items);
        }

        #endregion Multilanguage Methods

        #region Private Methods

        private void SearchWithFilters()
        {
            Form1 form = (Form1)ParentForm;

            SearchOption searchOption = SearchOption.TopDirectoryOnly;
            if (includeSubdirectoriesToolStripMenuItem.Checked)
            {
                searchOption = SearchOption.AllDirectories;
            }

            FileExplorerManager.ListFolderContentIntoFile(form, fileExplorerTreeView.SelectedNode, showSizeToolStripMenuItem.Checked, listFolderContentWithPatternValueToolStripMenuItem.Text, searchOption);
        }

        #endregion Private Methods

        //private void includeSubdirectoriesToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        //{
        //    blnClose = false;
        //}

        //private void showSizeToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        //{
        //    blnClose = false;
        //}

        //private void directoryContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        //{
        //    e.Cancel = !blnClose;
        //    blnClose = true;
        //}
    }
}
