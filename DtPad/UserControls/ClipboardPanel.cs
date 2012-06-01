using System;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.UserControls
{
    /// <summary>
    /// Clipboard history user control.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class ClipboardPanel : UserControl
    {
        internal ClipboardPanel()
        {
            InitializeComponent();
        }

        #region Window Methods

        private void clipboardListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            int selectionPosition = clipboardListBox.IndexFromPoint(e.X, e.Y);

            if (selectionPosition >= 0)
            {
                clipboardListBox.SelectedIndex = selectionPosition;
                ToggleContextMenuStrip(true);
            }
            else
            {
                ToggleContextMenuStrip(false);
            }
        }

        private void clipboardListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            int selectionPosition = clipboardListBox.IndexFromPoint(e.X, e.Y);
            if (selectionPosition < 0)
            {
                return;
            }

            clipboardListBox.SelectedIndex = selectionPosition;
            ClipboardManager.ShowSelectedContent(form);
        }

        #endregion Window Methods

        #region Button Methods

        private void clearClipboardToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ClipboardManager.ClearClipboardFile(form);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardManager.CopyContent(this);
        }

        private void showAllContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ClipboardManager.ShowSelectedContent(form);
        }

        #endregion Button Methods

        #region Multilanguage Methods

        internal void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, clipboardContextMenuStrip.Items);
        }

        #endregion Multilanguage Methods

        #region Private Methods

        private void ToggleContextMenuStrip(bool status)
        {
            foreach (ToolStripItem item in clipboardContextMenuStrip.Items)
            {
                item.Enabled = status;
            }
        }

        #endregion Private Methods
    }
}
