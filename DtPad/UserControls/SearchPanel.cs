using System;
using System.Windows.Forms;
using DtPad.Customs;
using DtPad.Exceptions;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.UserControls
{
    /// <summary>
    /// Search and replace user control.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class SearchPanel : UserControl
    {
        internal SearchPanel()
        {
            InitializeComponent();
            searchTextBox.ReturnActionType = ConfigUtil.GetIntParameter("SearchReturn") == 0 ? CustomTextBox.ReturnAction.StartSearch : CustomTextBox.ReturnAction.InsertCR;
            replaceTextBox.ReturnActionType = ConfigUtil.GetIntParameter("SearchReturn") == 0 ? CustomTextBox.ReturnAction.StartSearch : CustomTextBox.ReturnAction.InsertCR;
        }

        #region Window Methods

        private void SearchPanel_Load(object sender, EventArgs e)
        {
            if (ParentForm == null || ParentForm.GetType() != typeof(Form1))
            {
                return;
            }
            
            Form1 form = (Form1)ParentForm;

            if (form == null)
            {
                throw new ProgramException();
            }

            searchTextBox.ContextMenuStrip = form.searchContextMenuStrip;
            replaceTextBox.ContextMenuStrip = form.searchContextMenuStrip;
        }

        private void caseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WindowManager.CheckSearchCaseSensitive(caseCheckBox.Checked, caseCheckBox, true);
        }

        private void loopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WindowManager.CheckSearchLoop(loopCheckBox.Checked, loopCheckBox, true);
        }

        private void highlightsResultsToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ConfigUtil.UpdateParameter("SearchHighlightsResults", highlightsResultsToolStripButton.Checked.ToString());
            if (!highlightsResultsToolStripButton.Checked)
            {
                StringUtil.ClearHighlightsResults(form);
            }

            //if (highlightsResultsToolStripButton.Checked)
            //{
            //    StringUtil.ClearHighlightsResults(form);
            //}
            //else
            //{
            //    StringUtil.ClearHighlightsResults(form);
            //}
        }

        #endregion Window Methods

        #region Button Methods

        private void findFirstToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.SearchFirstFactory(form);
        }

        private void findNextToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.SearchNextFactory(form);
        }

        private void findPreviousToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.SearchPreviousFactory(form);
        }

        private void findLastToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.SearchLastFactory(form);
        }

        private void searchCountToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.SearchCountFactory(form);
        }

        private void replaceToolStripButton2_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.ReplaceNextFactory(form);
        }

        private void replacePreviousToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.ReplacePreviousFactory(form);
        }

        private void replaceAllToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ReplaceManager.ReplaceAll(form);
        }

        private void closeToolStripButton2_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            WindowManager.CheckSearchReplacePanel(form, true, true);
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            FileListManager.ClearSearchHistory(form);
        }

        private void patternToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            WindowManager.ShowSearchPattern(form);
        }

        #endregion Button Methods

        #region Multilanguage Methods

        internal void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
        }

        #endregion Multilanguage Methods
    }
}
