using System;
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
            SetLanguage();
            ControlUtil.SetContextMenuStrip(this, contentTextBox);

            contentTextBox.Select(0, 0);
            contentTextBox.Font = ConfigUtil.GetFontParameter("FontInUse");
        }

        private void contentTextBox_TextChanged(object sender, EventArgs e)
        {
            openButton.Enabled = !String.IsNullOrEmpty(contentTextBox.Text);
            //undoToolStripMenuItem.Enabled = contentTextBox.CanUndo;
        }

        #endregion Window Methods

        #region Button Methods

        private void openButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            FileManager.OpenFile(form, form.TabIdentity, contentTextBox.Text.Replace(Environment.NewLine, ConstantUtil.newLine).Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries));
            WindowManager.CloseForm(this);
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
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            //LanguageUtil.CicleControls(Name, contentContextMenuStrip.Items);
            fileListOpenToolTip.SetToolTip(pasteFromClipboardButton, LanguageUtil.GetCurrentLanguageString("pasteFromClipboardButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
