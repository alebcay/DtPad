using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Text replace manager.
    /// </summary>
    /// <author>Marco Macciò, Derek Morin</author>
    internal static class ReplaceManager
    {
        private const String className = "ReplaceManager";

        #region Factory Methods

        internal static void ReplaceNext(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;
            CheckBox loopCheckBox = form.searchPanel.loopCheckBox;

            if (searchAllTabsCheckBox.Checked)
            {
                ReplaceNextInAllFiles(form);
            }
            else
            {
                ReplaceNext(form, loopCheckBox.Checked, false);
            }
        }

        internal static void ReplacePrevious(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;
            CheckBox loopCheckBox = form.searchPanel.loopCheckBox;

            if (searchAllTabsCheckBox.Checked)
            {
                ReplacePreviousInAllFiles(form);
            }
            else
            {
                ReplacePrevious(form, loopCheckBox.Checked, false);
            }
        }

        internal static void ReplaceAll(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;
            CustomRichTextBox textBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            if (searchAllTabsCheckBox.Checked)
            {
                ReplaceAllInAllFiles(form);
            }
            else
            {
                ReplaceAllInOneFile(form, false);
            }

            textBox.ScrollToCaret();
        }

        #endregion Factory Methods

        #region Replace Next Methods

        private static void ReplaceNextInAllFiles(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            int initialSelectedIndex = pagesTabControl.SelectedTabPageIndex;

            for (int i = initialSelectedIndex; i < pagesTabControl.TabPages.Count; i++)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                if (i != initialSelectedIndex)
                {
                    CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                    pageTextBox.SelectionStart = 0;
                    pageTextBox.SelectionLength = 0;
                }

                if (ReplaceNext(form, false, true))
                {
                    return;
                }
            }

            for (int i = 0; i < initialSelectedIndex; i++)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                pageTextBox.SelectionStart = 0;
                pageTextBox.SelectionLength = 0;

                if (ReplaceNext(form, false, true))
                {
                    return;
                }
            }

            String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
            WindowManager.ShowInfoBox(form, notFoundMessage);
            toolStripStatusLabel.Text = notFoundMessage;
        }

        private static bool ReplaceNext(Form1 form, bool loopAtEOF, bool searchInAllFiles)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            CheckBox useRegularExpressionsCheckBox = form.searchPanel.regularExpressionsCheckBox;

            bool valueFounded = false;

            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return false;
            }

            String textWhereToSearch = pageTextBox.Text;
            String textToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            FileListManager.SetNewSearchHistory(form, textToSearch);

            if (!caseCheckBox.Checked)
            {
                textWhereToSearch = textWhereToSearch.ToLower();
                textToSearch = textToSearch.ToLower();
            }

            RichTextBoxUtil.CheckAllTextSelected(pageTextBox);

            int positionSearchedText;
            int selectionLength;
            SearchReplaceUtil.FindStringPositionAndLength(textWhereToSearch, textToSearch, SearchReplaceUtil.SearchType.Next, useRegularExpressionsCheckBox.Checked, pageTextBox, out positionSearchedText, out selectionLength);

            if (positionSearchedText != -1)
            {
                toolStripStatusLabel.Text = String.Format("1 {0}", LanguageUtil.GetCurrentLanguageString("Replaced", className, 1));
                pageTextBox.Focus();
                pageTextBox.Select(positionSearchedText, selectionLength);
                pageTextBox.SelectedText = replaceTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
                TextManager.RefreshUndoRedoExternal(form);

                pageTextBox.ScrollToCaret();
                valueFounded = true;
            }
            else if (!searchInAllFiles)
            {
                if (SearchReplaceUtil.GetNoMatchesInFile(textWhereToSearch, textToSearch, useRegularExpressionsCheckBox.Checked))
                {
                    String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
                    WindowManager.ShowInfoBox(form, notFoundMessage);
                    toolStripStatusLabel.Text = notFoundMessage;
                }
                else
                {
                    if (loopAtEOF)
                    {
                        pageTextBox.SelectionStart = 0;
                        return ReplaceNext(form, false, false);
                    }

                    if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("EOF", className)) == DialogResult.Yes)
                    {
                        pageTextBox.SelectionStart = 0;
                        return ReplaceNext(form, false, false);
                    }
                }
            }

            return valueFounded;
        }

        #endregion Replace Next Methods

        #region Replace Previous Methods

        private static void ReplacePreviousInAllFiles(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            int initialSelectedIndex = pagesTabControl.SelectedTabPageIndex;

            for (int i = initialSelectedIndex; i >= 0; i--)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                if (i != initialSelectedIndex)
                {
                    CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                    pageTextBox.SelectionStart = pageTextBox.Text.Length - 1;
                    pageTextBox.SelectionLength = 0;
                }

                if (ReplacePrevious(form, false, true))
                {
                    return;
                }
            }

            for (int i = pagesTabControl.TabPages.Count - 1; i > initialSelectedIndex; i--)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                pageTextBox.SelectionStart = pageTextBox.Text.Length - 1;
                pageTextBox.SelectionLength = 0;

                if (ReplacePrevious(form, false, true))
                {
                    return;
                }
            }

            String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
            WindowManager.ShowInfoBox(form, notFoundMessage);
            toolStripStatusLabel.Text = notFoundMessage;
        }

        private static bool ReplacePrevious(Form1 form, bool loopAtEOF, bool searchInAllFiles)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            CheckBox useRegularExpressionsCheckBox = form.searchPanel.regularExpressionsCheckBox;

            bool valueFounded = false;

            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return false;
            }

            String textWhereToSearch = pageTextBox.Text;
            String textToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            FileListManager.SetNewSearchHistory(form, textToSearch);

            if (!caseCheckBox.Checked)
            {
                textWhereToSearch = textWhereToSearch.ToLower();
                textToSearch = textToSearch.ToLower();
            }

            String subString = textWhereToSearch.Substring(0, pageTextBox.SelectionStart);

            int positionSearchedText;
            int selectionLength;
            SearchReplaceUtil.FindStringPositionAndLength(subString, textToSearch, SearchReplaceUtil.SearchType.Previous, useRegularExpressionsCheckBox.Checked, pageTextBox, out positionSearchedText, out selectionLength);

            if (positionSearchedText != -1)
            {
                toolStripStatusLabel.Text = String.Format("1 {0}", LanguageUtil.GetCurrentLanguageString("Replaced", className, 1));
                pageTextBox.Focus();
                pageTextBox.Select(positionSearchedText, selectionLength);
                pageTextBox.SelectedText = replaceTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
                TextManager.RefreshUndoRedoExternal(form);

                pageTextBox.ScrollToCaret();
                valueFounded = true;
            }
            else if (!searchInAllFiles)
            {
                if (SearchReplaceUtil.GetNoMatchesInFile(textWhereToSearch, textToSearch, useRegularExpressionsCheckBox.Checked))
                {
                    String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
                    WindowManager.ShowInfoBox(form, notFoundMessage);
                    toolStripStatusLabel.Text = notFoundMessage;
                }
                else
                {
                    if (loopAtEOF)
                    {
                        pageTextBox.SelectionStart = pageTextBox.Text.Length - 1;
                        return ReplacePrevious(form, false, false);
                    }

                    if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("SOF", className)) == DialogResult.Yes)
                    {
                        pageTextBox.SelectionStart = pageTextBox.Text.Length - 1;
                        return ReplacePrevious(form, false, false);
                    }
                }
            }

            return valueFounded;
        }

        #endregion Replace Previous Methods

        #region Replace All Methods

        private static bool ReplaceAllInOneFile(Form1 form, bool searchInAllFiles)
        {
            CustomRichTextBox textBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            CheckBox useRegularExpressionsCheckBox = form.searchPanel.regularExpressionsCheckBox;

            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return false;
            }

            FileListManager.SetNewSearchHistory(form, searchTextBox.Text);

            String textWhereToSearch;
            String textToSearch;
            GetTextCaseNormalization(form, out textWhereToSearch, out textToSearch);

            int positionSearchedText;
            int selectionLength;
            SearchReplaceUtil.FindStringPositionAndLength(textWhereToSearch, textToSearch, SearchReplaceUtil.SearchType.First, useRegularExpressionsCheckBox.Checked, textBox, out positionSearchedText, out selectionLength);

            if (positionSearchedText != -1)
            {
                int counter = SearchReplaceUtil.SearchCountOccurency(form, false, true);
                textBox.SelectAll();

                if (caseCheckBox.Checked)
                {
                    textBox.SelectedText = Replace(useRegularExpressionsCheckBox.Checked, textBox.Text, GetTextNewLineNormalization(searchTextBox.Text), GetTextNewLineNormalization(replaceTextBox.Text), StringComparison.Ordinal);
                }
                else
                {
                    textBox.SelectedText = Replace(useRegularExpressionsCheckBox.Checked, textBox.Text, GetTextNewLineNormalization(searchTextBox.Text), GetTextNewLineNormalization(replaceTextBox.Text), StringComparison.OrdinalIgnoreCase);
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

        private static void ReplaceAllInAllFiles(Form1 form)
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

                bool tempValueFounded = ReplaceAllInOneFile(form, true);

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

        private static String Replace(bool useRegularExpressions, String original, String pattern, String replacement, StringComparison comparisonType, int stringBuilderInitialSize = -1)
        {
            if (String.IsNullOrEmpty(original))
            {
                return String.Empty;
            }

            if (String.IsNullOrEmpty(pattern))
            {
                return original;
            }

            if (useRegularExpressions)
            {
                return RegularExpressionReplace(original, pattern, replacement, comparisonType);
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

        private static String RegularExpressionReplace(String original, String pattern, String replacement, StringComparison comparisonType)
        {
            RegexOptions options;

            switch (comparisonType)
            {
                case StringComparison.Ordinal:
                    options = RegexOptions.None;
                    break;
                case StringComparison.OrdinalIgnoreCase:
                    options = RegexOptions.IgnoreCase;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("comparisonType"); //"Unexpected value for comparisonType"
            }

            return Regex.Replace(original, pattern, replacement, options);
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
