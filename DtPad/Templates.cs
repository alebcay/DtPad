using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Templates management DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Templates : Form
    {
        private TemplateObjectList templateObjectList;
        private int newTemplateIdentity;

        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            templateObjectList = TemplateManager.LoadTemplatesList(this);
        }

        private void templateTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TemplateManager.LoadTemplate(this, templateObjectList);
            CheckNodeCount();
        }

        private void descriptionTextBox_Leave(object sender, EventArgs e)
        {
            if (!TemplateManager.SaveDescription(this, templateObjectList))
            {
                WindowManager.CloseForm(this);
            }
        }

        private void textTextBox_Leave(object sender, EventArgs e)
        {
            TemplateManager.SaveText(this, templateObjectList);
        }

        private void Templates_HelpButtonClicked(object sender, CancelEventArgs e)
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
            newTemplateIdentity = TemplateManager.AddTemplate(this, templateObjectList, newTemplateIdentity);
            TemplateManager.LoadTemplate(this, templateObjectList);
            CheckNodeCount();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (!TemplateManager.RemoveTemplate(this, templateObjectList))
            {
                WindowManager.CloseForm(this);
                return;
            }

            TemplateManager.LoadTemplate(this, templateObjectList);
            CheckNodeCount();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            if (!TemplateManager.SaveTemplatesIntoFile(this, templateObjectList))
            {
                return;
            }

            FileListManager.LoadTemplates(form);
            WindowManager.CloseForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            templateObjectList = TemplateManager.MoveTemplate(this, ObjectListUtil.Movement.Up, templateObjectList);
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            templateObjectList = TemplateManager.MoveTemplate(this, ObjectListUtil.Movement.Down, templateObjectList);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            templateToolTip.SetToolTip(removeButton, LanguageUtil.GetCurrentLanguageString("removeButtonToolTip", Name));
            templateToolTip.SetToolTip(addButton, LanguageUtil.GetCurrentLanguageString("addButtonToolTip", Name));
            templateToolTip.SetToolTip(moveUpButton, LanguageUtil.GetCurrentLanguageString("moveUpButtonToolTip", Name));
            templateToolTip.SetToolTip(moveDownButton, LanguageUtil.GetCurrentLanguageString("moveDownButtonToolTip", Name));
        }

        private void CheckNodeCount()
        {
            if (templateTreeView.Nodes.Count <= 1)
            {
                moveUpButton.Enabled = false;
                moveDownButton.Enabled = false;
                return;
            }

            moveUpButton.Enabled = templateTreeView.SelectedNode.Index > 0;
            moveDownButton.Enabled = templateTreeView.SelectedNode.Index < templateTreeView.Nodes.Count - 1;
        }

        #endregion Private Methods
    }
}
