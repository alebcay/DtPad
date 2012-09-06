using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Tools management DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Tools : Form
    {
        private ToolObjectList toolObjectList;
        private int newToolIdentity;

        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            toolObjectList = ToolManager.LoadToolsList(this);
        }

        private void toolTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ToolManager.LoadTool(this, toolObjectList);
            CheckNodeCount();
        }

        private void descriptionTextBox_Leave(object sender, EventArgs e)
        {
            if (!ToolManager.SaveDescription(this, toolObjectList))
            {
                WindowManager.CloseForm(this);
            }
        }

        private void commandLineTextBox_Leave(object sender, EventArgs e)
        {
            ToolManager.SaveCommandLine(this, toolObjectList);
        }

        private void workingFolderTextBox_Leave(object sender, EventArgs e)
        {
            ToolManager.SaveWorkingFolder(this, toolObjectList);
        }

        private void runComboBox_Leave(object sender, EventArgs e)
        {
            ToolManager.SaveRun(this, toolObjectList);
        }

        private void Tools_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = ControlUtil.FocusedTextBoxCanUndo(sender);
        }

        #endregion Window Methods

        #region Button Methods

        private void addButton_Click(object sender, EventArgs e)
        {
            newToolIdentity = ToolManager.AddTool(this, toolObjectList, newToolIdentity);
            ToolManager.LoadTool(this, toolObjectList);
            CheckNodeCount();

            descriptionTextBox.Focus();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (!ToolManager.RemoveTool(this, toolObjectList))
            {
                WindowManager.CloseForm(this);
                return;
            }
            ToolManager.LoadTool(this, toolObjectList);
            CheckNodeCount();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            if (!ToolManager.SaveToolsIntoFile(this, toolObjectList))
            {
                return;
            }

            FileListManager.LoadTools(form);
            WindowManager.CloseForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            toolObjectList = ToolManager.MoveTool(this, ObjectListUtil.Movement.Up, toolObjectList);
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            toolObjectList = ToolManager.MoveTool(this, ObjectListUtil.Movement.Down, toolObjectList);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            toolToolTip.SetToolTip(workingFolderPictureBox, LanguageUtil.GetCurrentLanguageString("workingFolderPictureBoxToolTip", Name));
            toolToolTip.SetToolTip(commandLinePictureBox, LanguageUtil.GetCurrentLanguageString("commandLinePictureBoxToolTip", Name));
            toolToolTip.SetToolTip(removeButton, LanguageUtil.GetCurrentLanguageString("removeButtonToolTip", Name));
            toolToolTip.SetToolTip(addButton, LanguageUtil.GetCurrentLanguageString("addButtonToolTip", Name));
            toolToolTip.SetToolTip(moveUpButton, LanguageUtil.GetCurrentLanguageString("moveUpButtonToolTip", Name));
            toolToolTip.SetToolTip(moveDownButton, LanguageUtil.GetCurrentLanguageString("moveDownButtonToolTip", Name));
        }

        private void CheckNodeCount()
        {
            if (toolTreeView.Nodes.Count <= 1)
            {
                moveUpButton.Enabled = false;
                moveDownButton.Enabled = false;
                return;
            }

            moveUpButton.Enabled = toolTreeView.SelectedNode.Index > 0;
            moveDownButton.Enabled = toolTreeView.SelectedNode.Index < toolTreeView.Nodes.Count - 1;
        }

        #endregion Private Methods
    }
}
