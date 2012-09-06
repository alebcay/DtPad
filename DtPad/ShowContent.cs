using System;
using System.Drawing;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Show details about something DtPad form (ie. clipboard content).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class ShowContent : Form
    {
        #region Window Methods

        internal void InitializeForm(String content, bool helpMode)
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            contentTextBox.Text = content;
            SetLanguage();

            contentTextBox.Select(0, 0);

            if (ConfigUtil.GetIntParameter("LookAndFeel") == 1)
            {
                contentContextMenuStrip.RenderMode = ToolStripRenderMode.System;
            }

            contentTextBox.Font = ConfigUtil.GetFontParameter("FontInUse");

            if (helpMode)
            {
                contentTextBox.BackColor = SystemColors.Control;
                contentTextBox.BorderStyle = BorderStyle.None;
            }

            BringToFront();
        }

        private void contentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                contentTextBox.SelectAll();
            }
        }

        #endregion Window Methods

        #region Button Methods

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(contentTextBox);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(contentTextBox);
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, contentContextMenuStrip.Items);
        }

        #endregion Private Methods
    }
}
