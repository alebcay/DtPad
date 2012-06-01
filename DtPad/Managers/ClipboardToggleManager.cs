using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Clipboard toggle state manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ClipboardToggleManager
    {
        #region Internal Methods

        internal static void ToggleUndoOnTextBox(Form1 form)
        {
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox calculationTextBox = form.calculatorPanel.calculationTextBox;
            TextBox calcTextBox = form.calculatorPanel.calcTextBox;
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;

            ToolStripMenuItem undoToolStripMenuItem2 = form.undoToolStripMenuItem2;

            if (searchTextBox.Focused)
            {
                undoToolStripMenuItem2.Enabled = searchTextBox.CanUndo;
            }
            else if (replaceTextBox.Focused)
            {
                undoToolStripMenuItem2.Enabled = replaceTextBox.CanUndo;
            }
            else if (noteTitleTextBox.Focused)
            {
                undoToolStripMenuItem2.Enabled = noteTitleTextBox.CanUndo;
            }
            else if (nodeTextTextBox.Focused)
            {
                undoToolStripMenuItem2.Enabled = nodeTextTextBox.CanUndo;
            }
            else if (calculationTextBox.Focused)
            {
                undoToolStripMenuItem2.Enabled = calculationTextBox.CanUndo;
            }
            else if (calcTextBox.Focused)
            {
                undoToolStripMenuItem2.Enabled = calcTextBox.CanUndo;
            }
            else if (prefixToolStripComboBox.Focused)
            {
                undoToolStripMenuItem2.Enabled = false;
            }
        }

        internal static void ToggleClipboard(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox calculationTextBox = form.calculatorPanel.calculationTextBox;
            TextBox calcTextBox = form.calculatorPanel.calcTextBox;
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;

            ToolStripMenuItem cutToolStripMenuItem = form.cutToolStripMenuItem;
            ToolStripMenuItem cutAppendToolStripMenuItem = form.cutAppendToolStripMenuItem;
            ToolStripMenuItem copyToolStripMenuItem = form.copyToolStripMenuItem;
            ToolStripMenuItem copyAppendToolStripMenuItem = form.copyAppendToolStripMenuItem;
            ToolStripMenuItem pasteToolStripMenuItem = form.pasteToolStripMenuItem;
            ToolStripMenuItem pasteSpecialToolStripMenuItem = form.pasteSpecialToolStripMenuItem;
            ToolStripMenuItem swapWithClipboardToolStripMenuItem = form.swapWithClipboardToolStripMenuItem;
            ToolStripMenuItem deleteToolStripMenuItem = form.deleteToolStripMenuItem;
            ToolStripMenuItem deleteLineToolStripMenuItem = form.deleteLineToolStripMenuItem;
            ToolStripMenuItem selectAllToolStripMenuItem = form.selectAllToolStripMenuItem;
            ToolStripMenuItem selectCurrentLineToolStripMenuItem = form.selectCurrentLineToolStripMenuItem;

            cutToolStripMenuItem.Enabled = false;
            cutAppendToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            copyAppendToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            pasteSpecialToolStripMenuItem.Enabled = false;
            swapWithClipboardToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
            deleteLineToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
            selectCurrentLineToolStripMenuItem.Enabled = false;

            if (pageTextBox.Focused || searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || calcTextBox.Focused
                || prefixToolStripComboBox.Focused || prefixToolStripTextBox.Focused || suffixToolStripTextBox.Focused)
            {
                cutToolStripMenuItem.Enabled = true;
                cutAppendToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                copyAppendToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem.Enabled = true;
                swapWithClipboardToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                deleteLineToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                selectCurrentLineToolStripMenuItem.Enabled = true;
            }
            else if (calculationTextBox.Focused)
            {
                copyToolStripMenuItem.Enabled = true;
                copyAppendToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                selectCurrentLineToolStripMenuItem.Enabled = true;
            }

            if (pageTextBox.Focused)
            {
                pasteSpecialToolStripMenuItem.Enabled = true;
            }
        }

        internal static void ToggleClipboardOnClick(Form1 form, bool forceEnable)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox calculationTextBox = form.calculatorPanel.calculationTextBox;
            TextBox calcTextBox = form.calculatorPanel.calcTextBox;
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;

            ToolStripButton cutToolStripButton = form.cutToolStripButton;
            ToolStripButton copyToolStripButton = form.copyToolStripButton;
            ToolStripButton pasteToolStripButton = form.pasteToolStripButton;

            if (forceEnable)
            {
                cutToolStripButton.Enabled = true;
                copyToolStripButton.Enabled = true;
                pasteToolStripButton.Enabled = true;
                
                return;
            }

            cutToolStripButton.Enabled = false;
            copyToolStripButton.Enabled = false;
            pasteToolStripButton.Enabled = false;

            if (pageTextBox.Focused || searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || calcTextBox.Focused
                || prefixToolStripComboBox.Focused || prefixToolStripTextBox.Focused || suffixToolStripTextBox.Focused)
            {
                cutToolStripButton.Enabled = true;
                copyToolStripButton.Enabled = true;
                pasteToolStripButton.Enabled = true;
            }
            else if (calculationTextBox.Focused)
            {
                copyToolStripButton.Enabled = true;
            }
        }

        internal static void DisableClipboardOnClick(Form1 form)
        {
            ToolStripMenuItem cutToolStripMenuItem = form.cutToolStripMenuItem;
            ToolStripMenuItem cutAppendToolStripMenuItem = form.cutAppendToolStripMenuItem;
            ToolStripMenuItem copyToolStripMenuItem = form.copyToolStripMenuItem;
            ToolStripMenuItem copyAppendToolStripMenuItem = form.copyAppendToolStripMenuItem;
            ToolStripMenuItem pasteToolStripMenuItem = form.pasteToolStripMenuItem;
            ToolStripMenuItem swapWithClipboardToolStripMenuItem = form.swapWithClipboardToolStripMenuItem;
            ToolStripMenuItem deleteToolStripMenuItem = form.deleteToolStripMenuItem;
            ToolStripMenuItem deleteLineToolStripMenuItem = form.deleteLineToolStripMenuItem;
            ToolStripMenuItem selectAllToolStripMenuItem = form.selectAllToolStripMenuItem;
            ToolStripMenuItem selectCurrentLineToolStripMenuItem = form.selectCurrentLineToolStripMenuItem;
            ToolStripButton cutToolStripButton = form.cutToolStripButton;
            ToolStripButton copyToolStripButton = form.copyToolStripButton;
            ToolStripButton pasteToolStripButton = form.pasteToolStripButton;

            cutToolStripMenuItem.Enabled = false;
            cutAppendToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            copyAppendToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            swapWithClipboardToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
            deleteLineToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
            selectCurrentLineToolStripMenuItem.Enabled = false;
            cutToolStripButton.Enabled = false;
            copyToolStripButton.Enabled = false;
            pasteToolStripButton.Enabled = false;
        }

        #endregion Internal Methods
    }
}
