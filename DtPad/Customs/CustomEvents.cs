using System;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom form events.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class CustomEvents
    {
        #region Generic Clipboard Methods

        internal static void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.UndoControl(ControlUtil.GetFocusedControl(sender));
        }

        internal static void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CutControl(ControlUtil.GetFocusedControl(sender));
        }

        internal static void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(ControlUtil.GetFocusedControl(sender));
        }

        internal static void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.PasteControl(ControlUtil.GetFocusedControl(sender));
        }

        internal static void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.DeleteControl(ControlUtil.GetFocusedControl(sender));
        }

        internal static void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(ControlUtil.GetFocusedControl(sender));
        }

        #endregion Generic Clipboard Methods

        #region Form1 Methods

        internal static void dtHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpManager.OpenDtHelp();
        }

        #endregion Form1 Methods

        #region Hosts Panel Methods

        internal static void sectionsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == e.NewValue || e.NewValue == CheckState.Indeterminate || e.CurrentValue == CheckState.Indeterminate)
            {
                return;
            }

            CustomFilesManager.ChangeSection((Form1)((Control)sender).FindForm(), e.Index, e.NewValue > CheckState.Unchecked);
        }

        internal static void sectionsCheckedListBox_Refresh(object sender, EventArgs e)
        {
            CustomFilesManager.GetSections((Form1)((Control)sender).FindForm(), false);
        }

        #endregion Hosts Panel Methods

        #region Annotation Panel Methods

        internal static void annotationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                TextManager.PasteControl(ControlUtil.GetFocusedControl(sender));
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                TextManager.UndoControl(ControlUtil.GetFocusedControl(sender));
                e.SuppressKeyPress = true;
            }
        }

        internal static void annotationContextMenuStrip_Opening(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)sender;

            contextMenuStrip.Items["undoToolStripMenuItem"].Enabled = ((CustomRichTextBoxBase)(contextMenuStrip.SourceControl)).CanUndo;
        }

        #endregion Annotation Panel Methods
    }
}
