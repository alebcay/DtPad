using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Go to line DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class GoToLine : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            Form1 form = (Form1)Owner;

            int linesNumber = TextManager.ReadRTBLineNumbers(form) == 0 ? 1 : TextManager.ReadRTBLineNumbers(form);
            lineNumberLabel.Text = linesNumber.ToString();
            lineNumericUpDown.Maximum = linesNumber;
            lineNumericUpDown.Minimum = 1;

            int currentRow;
            if (!Int32.TryParse(form.rowToolStripStatusLabel1.Text, out currentRow))
            {
                currentRow = 1;
            }
            lineNumericUpDown.Value = currentRow;
            lineCurrentLabel.Text = currentRow.ToString();
        }

        private void GoToLine_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            TabManager.GoToLine(form, Convert.ToInt32(lineNumericUpDown.Value));
            WindowManager.CloseForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(lineNumericUpDown);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.PasteControl(lineNumericUpDown);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(lineNumericUpDown);
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
