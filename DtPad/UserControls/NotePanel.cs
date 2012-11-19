using System;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.UserControls
{
    /// <summary>
    /// Notes user control.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class NotePanel : UserControl
    {
        internal int noteIdentity { get; private set; }

        internal NotePanel()
        {
            InitializeComponent();

            noteIdentity = 0;
            warningRemoveNoteToolStripButton.Checked = ConfigUtil.GetBoolParameter("WarningRemoveNote");
            noteTitleTextBox.Font = ConfigUtil.GetFontParameter("FontInUse");
            nodeTextTextBox.Font = ConfigUtil.GetFontParameter("FontInUse");

            int heightNoteList = ConfigUtil.GetIntParameter("HeightNoteList");
            if (noteSplitContainer.Height < heightNoteList)
            {
                heightNoteList = noteSplitContainer.Height - 50;
            }

            noteSplitContainer.SplitterDistance = heightNoteList;
        }

        #region Window Methods

        private void NotePanel_Load(object sender, EventArgs e)
        {
            if (ParentForm == null || ParentForm.GetType() != typeof(Form1))
            {
                return;
            }

            ControlUtil.SetContextMenuStrip(this, new[] { nodeTextTextBox, noteTitleTextBox });
        }

        private void notesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ExplorerManager.ReadNote(form, e);
        }

        private void notesTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ExplorerManager.SelectNodeFromTreeView(e);
        }

        private void noteTitleTextBox_Leave(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ExplorerManager.SaveTitleNode(form);
        }

        private void nodeTextTextBox_Leave(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ExplorerManager.SaveTextNode(form);
        }

        private void noteSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ConfigUtil.UpdateParameter("HeightNoteList", noteSplitContainer.SplitterDistance.ToString());
        }

        private void NotePanel_Resize(object sender, EventArgs e)
        {
            if (noteSplitContainer.Height < noteSplitContainer.SplitterDistance)
            {
                noteSplitContainer.Panel2Collapsed = true;
            }
            else if (noteSplitContainer.Height >= noteSplitContainer.SplitterDistance && noteSplitContainer.Panel2Collapsed)
            {
                noteSplitContainer.Panel2Collapsed = false;
            }
        }

        #endregion Window Methods

        #region Button Methods

        private void addNoteToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            noteIdentity = ExplorerManager.AddNote(form, noteIdentity);
        }

        private void removeNoteToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ExplorerManager.RemoveNote(form);
        }

        private void warningRemoveNoteToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            ConfigUtil.UpdateParameter("WarningRemoveNote", warningRemoveNoteToolStripButton.Checked.ToString());
        }

        private void xMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.ExportNotes(form, NoteManager.ExportTypeEnum.Xml);
        }

        private void tXTFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.ExportNotes(form, NoteManager.ExportTypeEnum.Txt);
        }

        private void moveFirstToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.MoveNoteFirstOrUp(form, true);
        }

        private void moveUpToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.MoveNoteFirstOrUp(form);
        }

        private void moveDownToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.MoveNoteDownOrLast(form);
        }

        private void moveLastToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.MoveNoteDownOrLast(form, true);
        }

        #endregion Button Methods

        #region Context Menu Methods

        private void newToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            noteIdentity = ExplorerManager.AddNote(form, noteIdentity);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ExplorerManager.RemoveNote(form);
        }

        private void openOnEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.OpenNoteOnEditor(form);
        }

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.ChangeNoteColor(form, NoteManager.TagEnum.Orange);
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.ChangeNoteColor(form, NoteManager.TagEnum.Red);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.ChangeNoteColor(form, NoteManager.TagEnum.Green);
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.ChangeNoteColor(form, NoteManager.TagEnum.Blue);
        }

        private void blackstandardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            NoteManager.ChangeNoteColor(form, NoteManager.TagEnum.Black);
        }

        #endregion Context Menu Methods

        #region Multilanguage Methods

        internal void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
        }

        #endregion Multilanguage Methods
    }
}
