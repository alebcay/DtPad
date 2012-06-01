using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Internal explorer manager (tab and notes).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ExplorerManager
    {
        private const String className = "ExplorerManager";
        
        #region Tab Explorer Methods

        internal static void InitializeTabExplorer(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            TreeView tabExplorerTreeView = form.tabPanel.tabExplorerTreeView;
            XtraTabControl verticalTabControl = form.verticalTabControl;
            XtraTabPage tabExplorerTabPage = form.tabExplorerTabPage;

            if (verticalSplitContainer.Panel2Collapsed || verticalTabControl.SelectedTabPage != tabExplorerTabPage)
            {
                return;
            }

            tabExplorerTreeView.Nodes.Clear();

            for (int i = 0; i < pagesTabControl.TabPages.Count; i++)
            {
                XtraTabPage tabPage = pagesTabControl.TabPages[i];
                AddNodeToTabExplorer(form, tabPage.Text, tabPage.Name, tabPage.ImageIndex, tabPage.ImageIndex);
            }

            SelectTreeNodeFromTabControl(form, pagesTabControl.SelectedTabPage.Name);
        }

        internal static void ClearTabExplorer(Form1 form)
        {
            TreeView tabExplorerTreeView = form.tabPanel.tabExplorerTreeView;
            tabExplorerTreeView.Nodes.Clear();
        }

        internal static void AddNodeToTabExplorer(Form1 form, String text, String name, int imageIndex, int selectedImageIndex)
        {
            SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            TreeView tabExplorerTreeView = form.tabPanel.tabExplorerTreeView;
            XtraTabControl verticalTabControl = form.verticalTabControl;
            XtraTabPage tabExplorerTabPage = form.tabExplorerTabPage;

            if (verticalSplitContainer.Panel2Collapsed || verticalTabControl.SelectedTabPage != tabExplorerTabPage)
            {
                return;
            }

            TreeNode node = new TreeNode(text, imageIndex, selectedImageIndex)
                                {
                                    //ForeColor = foreColor,
                                    Name = String.Format("{0}{1}", ConstantUtil.tabNodePrefix, name),
                                    ContextMenuStrip = form.pageContextMenuStrip
                                };
            tabExplorerTreeView.Nodes.Add(node);
        }

        internal static void RemoveNodeToTabExplorer(Form1 form, String selectedTabName)
        {
            SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            TreeView tabExplorerTreeView = form.tabPanel.tabExplorerTreeView;
            XtraTabControl verticalTabControl = form.verticalTabControl;
            XtraTabPage tabExplorerTabPage = form.tabExplorerTabPage;

            if (verticalSplitContainer.Panel2Collapsed || verticalTabControl.SelectedTabPage != tabExplorerTabPage)
            {
                return;
            }

            tabExplorerTreeView.Nodes[String.Format("{0}{1}", ConstantUtil.tabNodePrefix, selectedTabName)].Remove();
        }

        internal static void TabPage_TextChanged(Form1 form, object sender)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            TreeView tabExplorerTreeView = form.tabPanel.tabExplorerTreeView;
            XtraTabControl verticalTabControl = form.verticalTabControl;
            XtraTabPage tabExplorerTabPage = form.tabExplorerTabPage;

            if (verticalSplitContainer.Panel2Collapsed || verticalTabControl.SelectedTabPage != tabExplorerTabPage)
            {
                return;
            }

            XtraTabPage tabPage = (XtraTabPage)sender;
            String tabName = String.Format("{0}{1}", ConstantUtil.tabNodePrefix, tabPage.Name);

            if (!tabExplorerTreeView.Nodes.ContainsKey(tabName))
            {
                return;
            }

            //tabExplorerTreeView.Nodes[tabName].ForeColor = pagesTabControl.SelectedTabPage.Appearance.Header.ForeColor;
            tabExplorerTreeView.Nodes[tabName].Text = pagesTabControl.SelectedTabPage.Text;
            tabExplorerTreeView.Nodes[tabName].ImageIndex = pagesTabControl.SelectedTabPage.ImageIndex;
            tabExplorerTreeView.Nodes[tabName].SelectedImageIndex = pagesTabControl.SelectedTabPage.ImageIndex;
        }

        internal static void SelectTabPageFromTabExplorer(Form1 form, TreeNodeMouseClickEventArgs e)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            TreeView tabExplorerTreeView = form.tabPanel.tabExplorerTreeView;

            tabExplorerTreeView.SelectedNode = e.Node;
            pagesTabControl.SelectedTabPage = TabManager.GetXtraTabPageFromName(pagesTabControl, tabExplorerTreeView.SelectedNode.Name.Substring(ConstantUtil.tabNodePrefix.Length));
            
            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    TabManager.ClosePage(form);
                    break;
                default:
                    break;
            }

            TabManager.ToggleTabMoveButtons(form, e.Node, tabExplorerTreeView.Nodes.Count);
        }

        internal static void SelectTreeNodeFromTabControl(Form1 form, String name)
        {
            SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            TreeView tabExplorerTreeView = form.tabPanel.tabExplorerTreeView;
            XtraTabControl verticalTabControl = form.verticalTabControl;
            XtraTabPage tabExplorerTabPage = form.tabExplorerTabPage;

            if (verticalSplitContainer.Panel2Collapsed || verticalTabControl.SelectedTabPage != tabExplorerTabPage)
            {
                return;
            }

            tabExplorerTreeView.SelectedNode = tabExplorerTreeView.Nodes[name];
        }

        #endregion Tab Explorer Methods

        #region Notes Methods

        internal static int AddNote(Form1 form, int noteIdentity)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            ContextMenuStrip noteContextMenuStrip = form.notePanel.noteContextMenuStrip;

            if (nodeTextTextBox.Focused)
            {
                SaveTextNode(form);
            }

            if (noteIdentity < notesTreeView.Nodes.Count)
            {
                noteIdentity = notesTreeView.Nodes.Count;
            }

            noteIdentity++;
            String description = String.Format("{0} ({1})", LanguageUtil.GetCurrentLanguageString("Note", className), noteIdentity);

            while (CheckNoteIdentityExists(form, description))
            {
                noteIdentity++;
                description = String.Format("{0} ({1})", LanguageUtil.GetCurrentLanguageString("Note", className), noteIdentity);
            }

            TreeNode node = new TreeNode(description, 0, 0) { ContextMenuStrip = noteContextMenuStrip };
            notesTreeView.Nodes.Add(node);
            notesTreeView.SelectedNode = node;

            NoteManager.AddNote(form, description);
            ToggleNoteInput(form);

            noteTitleTextBox.Focus();
            noteTitleTextBox.SelectAll();

            return noteIdentity;
        }

        internal static void RemoveNote(Form1 form)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;
            ToolStripButton warningRemoveNoteToolStripButton = form.notePanel.warningRemoveNoteToolStripButton;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;

            if (nodeTextTextBox.Focused)
            {
                SaveTextNode(form);
            }

            String noteTitle = notesTreeView.SelectedNode.Text;
            if (warningRemoveNoteToolStripButton.Checked)
            {
                if (WindowManager.ShowQuestionBox(form, String.Format("{0} \"{1}\"?", LanguageUtil.GetCurrentLanguageString("DeleteNote", className), noteTitle)) == DialogResult.No)
                {
                    return;
                }
            }

            notesTreeView.SelectedNode.Remove();
            if (notesTreeView.Nodes.Count > 0)
            {
                notesTreeView.SelectedNode = notesTreeView.Nodes[notesTreeView.Nodes.Count - 1];
            }

            NoteManager.RemoveNote(form, noteTitle);

            ToggleNoteInput(form);
        }

        internal static void ReadNote(Form1 form, TreeViewEventArgs e)
        {
            TextBox nodeTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TreeView notesTreeView = form.notePanel.notesTreeView;
            ToolStripButton moveFirstToolStripButton = form.notePanel.moveFirstToolStripButton;
            ToolStripButton moveUpToolStripButton = form.notePanel.moveUpToolStripButton;
            ToolStripButton moveDownToolStripButton = form.notePanel.moveDownToolStripButton;
            ToolStripButton moveLastToolStripButton = form.notePanel.moveLastToolStripButton;

            nodeTitleTextBox.Text = e.Node.Text;
            nodeTextTextBox.Text = NoteManager.GetNoteText(form, e.Node.Text);

            if (notesTreeView.SelectedNode.Index == 0)
            {
                moveFirstToolStripButton.Enabled = false;
                moveUpToolStripButton.Enabled = false;
            }
            else
            {
                moveFirstToolStripButton.Enabled = true;
                moveUpToolStripButton.Enabled = true;
            }

            if (notesTreeView.SelectedNode.Index == notesTreeView.Nodes.Count - 1)
            {
                moveDownToolStripButton.Enabled = false;
                moveLastToolStripButton.Enabled = false;
            }
            else
            {
                moveDownToolStripButton.Enabled = true;
                moveLastToolStripButton.Enabled = true;
            }
        }

        internal static void SaveTitleNode(Form1 form)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;
            TextBox nodeTitleTextBox = form.notePanel.noteTitleTextBox;

            if (notesTreeView.Nodes.Count > 0 && !String.IsNullOrEmpty(nodeTitleTextBox.Text))
            {
                String oldTitle = notesTreeView.SelectedNode.Text;
                String newTitle = nodeTitleTextBox.Text;

                if (oldTitle == newTitle)
                {
                    return;
                }

                //notesTreeView.SelectedNode.Text = newTitle;
                if (NoteManager.SaveTitleNode(form, oldTitle, newTitle))
                {
                    notesTreeView.SelectedNode.Text = newTitle;
                }
            }
            else if (notesTreeView.Nodes.Count > 0 && String.IsNullOrEmpty(nodeTitleTextBox.Text))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("NoteNameNotEmpty", className));
            }
        }

        internal static void SaveTextNode(Form1 form)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox nodeTitleTextBox = form.notePanel.noteTitleTextBox;

            if (notesTreeView.Nodes.Count > 0)
            {
                NoteManager.SaveTextNode(form, nodeTitleTextBox.Text, nodeTextTextBox.Text);
            }
        }

        internal static void ToggleNoteInput(Form1 form)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox nodeTitleTextBox = form.notePanel.noteTitleTextBox;
            ToolStripButton removeNoteToolStripButton = form.notePanel.removeNoteToolStripButton;

            if (notesTreeView.Nodes.Count == 0)
            {
                nodeTextTextBox.Text = String.Empty;
                nodeTitleTextBox.Text = String.Empty;
                nodeTextTextBox.ReadOnly = true;
                nodeTitleTextBox.ReadOnly = true;
                removeNoteToolStripButton.Enabled = false;
            }
            else
            {
                nodeTextTextBox.ReadOnly = false;
                nodeTitleTextBox.ReadOnly = false;
                removeNoteToolStripButton.Enabled = true;
            }
        }

        #endregion Notes Methods

        #region Other Methods

        internal static void SelectNodeFromTreeView(TreeNodeMouseClickEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.Right:
                    e.Node.TreeView.SelectedNode = e.Node;
                    break;
                case MouseButtons.Middle:
                    break;
                default:
                    break;
            }
        }

        #endregion Other Methods

        #region Private Methods

        private static bool CheckNoteIdentityExists(Form1 form, String descriptionToSearch)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;

            //foreach (TreeNode node in notesTreeView.Nodes)
            //{
            //    if (node.Text == descriptionToSearch)
            //    {
            //        return true;
            //    }
            //}
            return notesTreeView.Nodes.Cast<TreeNode>().Any(node => node.Text == descriptionToSearch);
        }

        #endregion Private Methods
    }
}
