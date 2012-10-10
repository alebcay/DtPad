using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Select lines DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class SelectLines : Form
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

            lineFromNumericUpDown.Maximum = linesNumber;
            lineFromNumericUpDown.Minimum = 1;

            lineToNumericUpDown.Maximum = linesNumber;
            lineToNumericUpDown.Minimum = 1;
        }

        private void SelectLines_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            TextManager.SelectLinesFromRowAToRowB(form, Convert.ToInt32(lineFromNumericUpDown.Value - 1), Convert.ToInt32(lineToNumericUpDown.Value - 1));
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
            if (lineFromNumericUpDown.Focused)
            {
                TextManager.CopyControl(lineFromNumericUpDown);
            }
            else if (lineToNumericUpDown.Focused)
            {
                TextManager.CopyControl(lineToNumericUpDown);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lineFromNumericUpDown.Focused)
            {
                TextManager.PasteControl(lineFromNumericUpDown);
            }
            else if (lineToNumericUpDown.Focused)
            {
                TextManager.PasteControl(lineToNumericUpDown);
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lineFromNumericUpDown.Focused)
            {
                TextManager.SelectAllControl(lineFromNumericUpDown);
            }
            else if (lineToNumericUpDown.Focused)
            {
                TextManager.SelectAllControl(lineToNumericUpDown);
            }
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
