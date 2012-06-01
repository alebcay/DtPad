using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Extensions management DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Extensions : Form
    {
        private ExtensionObjectList extensionObjectList;
        private int newExtensionIdentity;
        
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            extensionObjectList = ExtensionManager.LoadExtensionsList(this);
            ExtensionManager.LoadExtension(this, extensionObjectList);
        }

        private void extensionTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ExtensionManager.LoadExtension(this, extensionObjectList);
            CheckNodeCount();
        }

        private void descriptionTextBox_Leave(object sender, EventArgs e)
        {
            if (!ExtensionManager.SaveDescription(this, extensionObjectList))
            {
                Close();
            }
        }

        private void extensionTextBox_Leave(object sender, EventArgs e)
        {
            ExtensionManager.SaveExtension(this, extensionObjectList);
        }

        private void defaultCheckBox_Leave(object sender, EventArgs e)
        {
            ExtensionManager.SaveDefault(this, extensionObjectList);
        }

        private void Extensions_HelpButtonClicked(object sender, CancelEventArgs e)
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
            newExtensionIdentity = ExtensionManager.AddExtension(this, extensionObjectList, newExtensionIdentity);
            ExtensionManager.LoadExtension(this, extensionObjectList);
            CheckNodeCount();

            descriptionTextBox.Focus();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (!ExtensionManager.RemoveExtension(this, extensionObjectList))
            {
                WindowManager.HiddenForm(this);
                return;
            }
            ExtensionManager.LoadExtension(this, extensionObjectList);
            CheckNodeCount();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ExtensionManager.SaveExtensionsIntoFile(this, extensionObjectList))
            {
                WindowManager.HiddenForm(this);
            }
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            extensionObjectList = ExtensionManager.MoveExtension(this, ObjectListUtil.Movement.Up, extensionObjectList);
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            extensionObjectList = ExtensionManager.MoveExtension(this, ObjectListUtil.Movement.Down, extensionObjectList);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            extensionToolTip.SetToolTip(extensionPictureBox, LanguageUtil.GetCurrentLanguageString("extensionPictureBoxToolTip", Name));
            extensionToolTip.SetToolTip(addButton, LanguageUtil.GetCurrentLanguageString("addButtonToolTip", Name));
            extensionToolTip.SetToolTip(removeButton, LanguageUtil.GetCurrentLanguageString("removeButtonToolTip", Name));
            extensionToolTip.SetToolTip(moveUpButton, LanguageUtil.GetCurrentLanguageString("moveUpButtonToolTip", Name));
            extensionToolTip.SetToolTip(moveDownButton, LanguageUtil.GetCurrentLanguageString("moveDownButtonToolTip", Name));
        }

        private void CheckNodeCount()
        {
            if (extensionTreeView.Nodes.Count <= 2)
            {
                moveUpButton.Enabled = false;
                moveDownButton.Enabled = false;
                return;
            }

            moveUpButton.Enabled = extensionTreeView.SelectedNode.Index > 1;

            if (extensionTreeView.SelectedNode.Index < extensionTreeView.Nodes.Count - 1 && extensionTreeView.SelectedNode.Index > 0)
            {
                moveDownButton.Enabled = true;
            }
            else
            {
                moveDownButton.Enabled = false;
            }
        }

        #endregion Private Methods
    }
}
