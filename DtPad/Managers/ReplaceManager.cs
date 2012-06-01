using System;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Text replace manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ReplaceManager
    {
        private const String className = "ReplaceManager";

        #region Factory Methods

        //internal static void ReplaceNext(Form1 form)
        //{
        //    TODO
        //}

        //internal static void ReplacePrevious(Form1 form)
        //{
        //    TODO
        //}

        internal static void ReplaceAll(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;
            CustomRichTextBox textBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            if (searchAllTabsCheckBox.Checked)
            {
                ReplaceAll_InAllFiles(form);
            }
            else
            {
                ReplaceAll_InOneFile(form, false);
            }

            textBox.ScrollToCaret();
        }

        #endregion Factory Methods

        #region Replace Next Methods



        #endregion Replace Next Methods

        #region Replace All Methods

        private static bool ReplaceAll_InOneFile(Form1 form, bool searchInAllFiles)
        {
            CustomRichTextBox textBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;

            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return false;
            }

            FileListManager.SetNewSearchHistory(form, searchTextBox.Text);

            String textWhereToSearch;
            String textToSearch;
            GetTextCaseNormalization(form, out textWhereToSearch, out textToSearch);

            int positionSearchedText = textWhereToSearch.IndexOf(textToSearch);
            if (positionSearchedText != -1)
            {
                int counter = SearchManager.SearchCountOccurency(form, false, true); //TODO
                textBox.SelectAll();

                if (caseCheckBox.Checked)
                {
                    textBox.SelectedText = Replace(textBox.Text, GetTextNewLineNormalization(searchTextBox.Text), GetTextNewLineNormalization(replaceTextBox.Text), StringComparison.Ordinal);
                }
                else
                {
                    textBox.SelectedText = Replace(textBox.Text, GetTextNewLineNormalization(searchTextBox.Text), GetTextNewLineNormalization(replaceTextBox.Text), StringComparison.OrdinalIgnoreCase);
                }

                TextManager.RefreshUndoRedoExternal(form);
                textBox.Select(0, 0);

                toolStripStatusLabel.Text = String.Format("{0} {1}", counter, LanguageUtil.GetCurrentLanguageString("Replaced", className, counter));

                return true;
            }
            if (!searchInAllFiles)
            {
                String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
                WindowManager.ShowInfoBox(form, notFoundMessage);
                toolStripStatusLabel.Text = notFoundMessage;
            }

            return false;
        }

        private static void ReplaceAll_InAllFiles(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            bool valueFounded = false;

            for (int i = 0; i < pagesTabControl.TabPages.Count; i++)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                CustomRichTextBox textBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                textBox.SelectionStart = 0;
                textBox.SelectionLength = 0;

                bool tempValueFounded = ReplaceAll_InOneFile(form, true);

                if (!valueFounded)
                {
                    valueFounded = tempValueFounded;
                }
            }

            if (valueFounded)
            {
                return;
            }

            String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
            WindowManager.ShowInfoBox(form, notFoundMessage);
            toolStripStatusLabel.Text = notFoundMessage;
        }

        #endregion Replace All Methods

        #region Replace Fastest Methods

        private static String Replace(String original, String pattern, String replacement, StringComparison comparisonType, int stringBuilderInitialSize = -1)
        {
            if (String.IsNullOrEmpty(original))
            {
                return String.Empty;
            }
            
            if (String.IsNullOrEmpty(pattern))
            {
                return original;
            }
            
            int posCurrent = 0;
            int lenPattern = pattern.Length;
            int idxNext = original.IndexOf(pattern, comparisonType);

            StringBuilder result = new StringBuilder(stringBuilderInitialSize < 0 ? Math.Min(4096, original.Length) : stringBuilderInitialSize);
            
            while (idxNext >= 0)
            {
                result.Append(original, posCurrent, idxNext - posCurrent);
                result.Append(replacement);
                posCurrent = idxNext + lenPattern;
                idxNext = original.IndexOf(pattern, posCurrent, comparisonType);
            }
            
            result.Append(original, posCurrent, original.Length - posCurrent);
            return result.ToString();
        }

        #endregion Replace Fastest Methods

        #region Normalization Methods

        private static void GetTextCaseNormalization(Form1 form, out String textWhereToSearch, out String textToSearch)
        {
            RichTextBox textBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            
            textWhereToSearch = textBox.Text;
            textToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            FileListManager.SetNewSearchHistory(form, textToSearch);

            if (caseCheckBox.Checked)
            {
                return;
            }

            textWhereToSearch = textWhereToSearch.ToLower();
            textToSearch = textToSearch.ToLower();
        }

        private static String GetTextNewLineNormalization(String text)
        {
            return text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
        }

        #endregion Normalization Methods
    }
}
