using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;
using DtPad.Validators;

namespace DtPad
{
    /// <summary>
    /// Pattern (regular expression) search DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class SearchPattern : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            FileListManager.LoadRecentPatterns(this);
            regularExpressionTextBox.Focus();
        }

        private void historyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(historyComboBox.SelectedItem.ToString()))
            {
                regularExpressionTextBox.Text = historyComboBox.SelectedItem.ToString();
            }
        }

        private void SearchPattern_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void regularExpressionTextBox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = !String.IsNullOrEmpty(regularExpressionTextBox.Text);
        }

        private void predefinedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (predefinedComboBox.SelectedIndex)
            {
                case 1:
                    regularExpressionTextBox.Text = RegularExpressionValidator.EmailRegEx;
                    break;
                case 2:
                    regularExpressionTextBox.Text = RegularExpressionValidator.IpRegEx;
                    break;
                case 3:
                    regularExpressionTextBox.Text = RegularExpressionValidator.HtmlTagRegEx;
                    break;
                case 4:
                    regularExpressionTextBox.Text = RegularExpressionValidator.CapitalizedWords;
                    break;
            }
        }

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = regularExpressionTextBox.CanUndo;
        }

        #endregion Window Methods

        #region Button Methods

        private void regularExpressionPictureBox_Click(object sender, EventArgs e)
        {
            OtherManager.StartProcessBrowser(this, "http://www.regular-expressions.info/");
        }

        private void clearHistoryButton_Click(object sender, EventArgs e)
        {
            FileListManager.ClearRecentPatterns(this);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            if (RegularExpressionValidator.Validate(form, regularExpressionTextBox.Text, denyRegexCheckBox.Checked))
            {
                FileListManager.SetNewRecentPattern(this, regularExpressionTextBox.Text);
            }
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.UndoControl(regularExpressionTextBox);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CutControl(regularExpressionTextBox);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(regularExpressionTextBox);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.PasteControl(regularExpressionTextBox);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.DeleteControl(regularExpressionTextBox);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(regularExpressionTextBox);
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            searchPatternToolTip.SetToolTip(regularExpressionPictureBox, LanguageUtil.GetCurrentLanguageString("regularExpressionPictureBoxToolTip", Name));
            searchPatternToolTip.SetToolTip(clearHistoryButton, LanguageUtil.GetCurrentLanguageString("clearHistoryButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
