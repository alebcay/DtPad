using System;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.UserControls
{
    /// <summary>
    /// Search and replace user control.
    /// </summary>
    /// <author>Marco Macciò, Derek Morin</author>
    internal partial class SearchPanel : UserControl
    {
        internal SearchPanel()
        {
            InitializeComponent();
            //searchTextBox.ReturnActionType = ConfigUtil.GetIntParameter("SearchReturn") == 0 ? CustomTextBox.ReturnAction.StartSearch : CustomTextBox.ReturnAction.InsertCR;
            //replaceTextBox.ReturnActionType = ConfigUtil.GetIntParameter("SearchReturn") == 0 ? CustomTextBox.ReturnAction.StartReplace : CustomTextBox.ReturnAction.InsertCR;
            AttachKeyboardEventsForEscapeKey(this);
        }

        #region Window Methods

        private void SearchPanel_Load(object sender, EventArgs e)
        {
            if (ParentForm == null || ParentForm.GetType() != typeof(Form1))
            {
                return;
            }

            ControlUtil.SetContextMenuStrip(this, new[] { searchTextBox, replaceTextBox });
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

        //This closes the Search Panel if the user is on it and presses the escape key.
        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Form1 form = (Form1)ParentForm;
                    WindowManager.CheckSearchReplacePanel(form, false, true);
                    break;
            }
        }

        #endregion Window Methods

        #region Button Methods

        private void findFirstToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.SearchFirst(form);
        }

        private void findNextToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.SearchNext(form);
        }

        private void findPreviousToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.SearchPrevious(form);
        }

        private void findLastToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.SearchLast(form);
        }

        private void searchCountToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            SearchManager.SearchCount(form);
        }

        private void replaceToolStripButton2_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ReplaceManager.ReplaceNext(form);
        }

        private void replacePreviousToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ReplaceManager.ReplacePrevious(form);
        }

        private void replaceAllToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ReplaceManager.ReplaceAll(form);
        }

        private void closeToolStripButton2_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            WindowManager.CheckSearchReplacePanel(form, false, true);
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

        #region Private Methods

        /// <summary>
        /// This attaches to the KeyDown event for all child TextBox and CheckBox of the Search Panel
        /// If we hit the escape key on any of these controls we will close the search panel
        /// </summary>
        /// <param name="parentControl"></param>
        private void AttachKeyboardEventsForEscapeKey(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control as CheckBox != null || control as TextBox != null) //Only attach to controls that are CheckBox or TextBox
                {
                    control.KeyDown += control_KeyDown;
                }

                AttachKeyboardEventsForEscapeKey(control); //Recursively go down through child controls
            }
        }

        #endregion Private Methods
    }
}
