using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Open a text list of files.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class FileListOpen : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            contentTextBox.Select(0, 0);

            if (ConfigUtil.GetIntParameter("LookAndFeel") == 1)
            {
                contentContextMenuStrip.RenderMode = ToolStripRenderMode.System;
            }

            contentTextBox.Font = ConfigUtil.GetFontParameter("FontInUse");
        }

        private void contentTextBox_TextChanged(object sender, EventArgs e)
        {
            openButton.Enabled = !String.IsNullOrEmpty(contentTextBox.Text);
            //undoToolStripMenuItem.Enabled = contentTextBox.CanUndo;
        }

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = contentTextBox.CanUndo;
        }

        #endregion Window Methods

        #region Button Methods

        private void openButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            FileManager.OpenFile(form, form.TabIdentity, contentTextBox.Text.Replace(Environment.NewLine, ConstantUtil.newLine).Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries));
            WindowManager.HiddenForm(this);
        }

        private void pasteFromClipboardButton_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                contentTextBox.Paste(Clipboard.GetText());
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.UndoControl(contentTextBox);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CutControl(contentTextBox);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(contentTextBox);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.PasteControl(contentTextBox);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.DeleteControl(contentTextBox);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(contentTextBox);
        }

        #endregion ContextMenu Methods

        #region Multilanguage Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, contentContextMenuStrip.Items);
            fileListOpenToolTip.SetToolTip(pasteFromClipboardButton, LanguageUtil.GetCurrentLanguageString("pasteFromClipboardButtonToolTip", Name));
        }

        #endregion Multilanguage Methods
    }
}
