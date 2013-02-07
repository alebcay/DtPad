using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;

namespace DtPad.Utils
{
    /// <summary>
    /// Search and replace util.
    /// </summary>
    /// <author>Marco Macciò, Derek Morin</author>
    internal static class SearchReplaceUtil
    {
        internal enum SearchType
        {
            First,
            Last,
            Next,
            Previous
        }

        #region Internal Methods

        internal static int SearchCountOccurency(Form1 form, bool searchInAllFiles, bool forceDisableHighlight = false, String specificTextToSearch = null)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            TextBox searchTextBox = form.searchPanel.searchTextBox;

            int counter = 0;
            String stringToSearch = !String.IsNullOrEmpty(specificTextToSearch) ? specificTextToSearch : searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);

            if (searchInAllFiles)
            {
                foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
                {
                    CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(tabPage);
                    String text = pageTextBox.Text;

                    if (!caseCheckBox.Checked)
                    {
                        stringToSearch = stringToSearch.ToLower();
                        text = text.ToLower();
                    }

                    counter += StringUtil.SearchCountOccurences(text, stringToSearch, form, pageTextBox, forceDisableHighlight);
                }
            }
            else
            {
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                String text = pageTextBox.Text;

                if (!caseCheckBox.Checked)
                {
                    stringToSearch = stringToSearch.ToLower();
                    text = text.ToLower();
                }

                counter = StringUtil.SearchCountOccurences(text, stringToSearch, form, pageTextBox, forceDisableHighlight);
            }

            return counter;
        }

        internal static void FindStringPositionAndLength(String textWhereToSearch, String textToSearch, SearchType searchType, bool useRegularExpressions, CustomRichTextBox pageTextBox, out int positionSearchedText, out int selectionLength)
        {
            positionSearchedText = -1;
            selectionLength = -1;

            if (useRegularExpressions == false)
            {
                switch (searchType)
                {
                    case SearchType.First:
                        positionSearchedText = textWhereToSearch.IndexOf(textToSearch);
                        break;
                    case SearchType.Last:
                        positionSearchedText = textWhereToSearch.LastIndexOf(textToSearch);
                        break;
                    case SearchType.Next:
                        positionSearchedText = textWhereToSearch.IndexOf(textToSearch, pageTextBox.SelectionStart + pageTextBox.SelectionLength);
                        break;
                    case SearchType.Previous:
                        positionSearchedText = textWhereToSearch.LastIndexOf(textToSearch); //textWhereToSearch = subString
                        break;
                }

                selectionLength = textToSearch.Length;
            }
            else
            {
                Regex regex = new Regex(textToSearch);
                Match regexMatch = null;

                switch (searchType)
                {
                    case SearchType.First:
                        regexMatch = regex.Match(textWhereToSearch, 0);
                        break;
                    case SearchType.Last:
                        regexMatch = Regex.Match(textWhereToSearch, textToSearch, RegexOptions.RightToLeft);
                        break;
                    case SearchType.Next:
                        regexMatch = regex.Match(textWhereToSearch, pageTextBox.SelectionStart + pageTextBox.SelectionLength);
                        break;
                    case SearchType.Previous:
                        regexMatch = Regex.Match(textWhereToSearch, textToSearch, RegexOptions.RightToLeft); //textWhereToSearch = subString
                        break;
                }

                if (regexMatch != null && regexMatch.Success)
                {
                    positionSearchedText = regexMatch.Index;
                    selectionLength = regexMatch.Value.Length;
                }
            }
        }

        internal static bool GetNoMatchesInFile(String textWhereToSearch, String textToSearch, bool useRegularExpressions)
        {
            if (useRegularExpressions == false)
            {
                return (textWhereToSearch.IndexOf(textToSearch) == -1);
            }

            Match regexMatch = Regex.Match(textWhereToSearch, textToSearch);
            return !regexMatch.Success;
        }

        #endregion Private Methods
    }
}
