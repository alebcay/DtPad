using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Managers;

namespace DtPad.Utils
{
    /// <summary>
    /// String management util.
    /// </summary>
    /// <author>Marco Macciò, Derek Morin</author>
    internal static class StringUtil
    {
        #region Internal Methods

        internal static void SelectCurrentLinesTextBox(TextBoxBase textBox)
        {
            int start = textBox.SelectionStart;
            int end = start + textBox.SelectionLength;
            int totalLenght = 0;
            int firstLine = 0;

            for (int i = 0; i < textBox.Lines.Length; i++)
            {
                totalLenght += textBox.Lines[i].Length;

                int newLineLenght = 0;
                if (i < textBox.Lines.Length - 1)
                {
                    newLineLenght = i == 0 ? 1 : 2;
                    totalLenght += newLineLenght;
                }

                if (i == textBox.Lines.Length - 1 && totalLenght + 1 < start)
                {
                    continue;
                }
                if (i < textBox.Lines.Length - 1 && totalLenght < start)
                {
                    continue;
                }

                firstLine = i;
                start = totalLenght - textBox.Lines[i].Length - newLineLenght < 0 ? 0 : totalLenght - textBox.Lines[i].Length - newLineLenght;
                break;
            }

            for (int i = firstLine; i < textBox.Lines.Length; i++)
            {
                if (i != firstLine)
                {
                    totalLenght += textBox.Lines[i].Length;
                    if (i < textBox.Lines.Length - 1)
                    {
                        totalLenght += i == 0 ? 1 : 2;
                    }
                }
                if (totalLenght < end)
                {
                    continue;
                }

                end = totalLenght;
                break;
            }

            textBox.SelectionStart = start;
            textBox.SelectionLength = end - start + 1;
        }

        internal static bool SelectCurrentLines(TextBoxBase pageTextBox)
        {
            int firstCharPosition;
            int lastCharPosition;
            bool lastLineHasReturn = GetCurrentLineIndexes(pageTextBox, out firstCharPosition, out lastCharPosition);

            pageTextBox.SelectionStart = firstCharPosition;
            int selectionLenght = lastCharPosition - firstCharPosition;
            if (selectionLenght < 0)
            {
                selectionLenght = 0;
            }
            pageTextBox.SelectionLength = selectionLenght;

            if (lastLineHasReturn && !pageTextBox.SelectedText.EndsWith(ConstantUtil.newLine))
            {
                pageTextBox.SelectionLength++;
            }

            return lastLineHasReturn;
        }

        internal static int SelectCurrentLinesFirstIndex(TextBoxBase pageTextBox)
        {
            int firstCharPosition;
            int lastCharPosition;
            GetCurrentLineIndexes(pageTextBox, out firstCharPosition, out lastCharPosition);

            String[] separator = { ConstantUtil.newLine };
            String[] split = pageTextBox.Text.Split(separator, StringSplitOptions.None);

            int counter = 0;
            for (int i = 0; i < split.Length; i++)
            {
                counter += split[i].Length;
                if (i < split.Length - 1)
                {
                    counter += ConstantUtil.newLine.Length;
                }

                if (firstCharPosition < counter)
                {
                    return i;
                }
            }

            return split.Length - 1;
        }

        internal static void SelectLinesFromRowAToRowB(TextBoxBase pageTextBox, int firstCharIndexRowA, int firstCharIndexRowB, int rowB)
        {
            String[] separator = { ConstantUtil.newLine };
            String[] lines = pageTextBox.Text.Split(separator, StringSplitOptions.None);

            int lastCharIndexRowB = firstCharIndexRowB + lines[rowB].Length;
            if (rowB < lines.Length - 1)
            {
                lastCharIndexRowB++;
            }

            pageTextBox.Select(firstCharIndexRowA, lastCharIndexRowB - firstCharIndexRowA);
        }

        internal static String CheckStringLength(String name, int maxChars)
        {
            if (!String.IsNullOrEmpty(name) && name.Length > maxChars)
            {
                name = name.Substring(name.Length - maxChars + 1);
                name = "..." + name;
            }

            return name;
        }

        internal static String CheckStringLengthEnd(String name, int maxChars)
        {
            if (!String.IsNullOrEmpty(name) && name.Length > maxChars)
            {
                name = name.Substring(0, maxChars - 1);
                name = name + "...";
            }

            return name;
        }

        internal static int SearchCountOccurences(String text, String stringToSearch, Form1 form = null, CustomRichTextBox textBox = null, bool forceDisableHighlight = false, bool useRegularExpressions = false)
        {
            int counter = 0;

            bool highlights = false;
            if (!forceDisableHighlight)
            {
                highlights = ConfigUtil.GetBoolParameter("SearchHighlightsResults");
            }

            RichTextBox tempRichTextBox = new RichTextBox(); //Temporary RichTextBox to avoid too much undo/redo into buffer
            try
            {
                if (textBox != null) //Research inside a textbox (usually the pageTextBox)
                {
                    if (highlights)
                    {
                        textBox.SuspendPainting();
                    }

                    tempRichTextBox.Rtf = textBox.Rtf;
                    tempRichTextBox.SelectAll();
                    tempRichTextBox.SelectionBackColor = textBox.BackColor;

                    int positionSearchedText;
                    int selectionLength;
                    SearchReplaceUtil.FindStringPositionAndLength(text, stringToSearch, SearchReplaceUtil.SearchType.First, useRegularExpressions, textBox, out positionSearchedText, out selectionLength);

                    while (positionSearchedText != -1)
                    {
                        tempRichTextBox.Select(positionSearchedText, selectionLength);

                        if (highlights)
                        {
                            tempRichTextBox.SelectionBackColor = (textBox.BackColor == Color.Yellow) ? Color.Red : Color.Yellow;
                        }

                        SearchReplaceUtil.FindStringPositionAndLength(text, stringToSearch, SearchReplaceUtil.SearchType.Next, useRegularExpressions, tempRichTextBox, out positionSearchedText, out selectionLength);
                        counter++;
                    }
                }
                else //Search inside a string
                {
                    int i = 0;
                    while ((i = text.IndexOf(stringToSearch, i)) != -1)
                    {
                        i += stringToSearch.Length;
                        counter++;
                    }
                }

                if (textBox != null && highlights)
                {
                    textBox.IsHighlighting = true;
                    RichTextBoxUtil.ReplaceRTFContent(textBox, tempRichTextBox);
                    textBox.ResumePainting();

                    TextManager.RefreshUndoRedoExternal(form);
                }
            }
            finally
            {
                tempRichTextBox.Dispose();
            }

            return counter;
        }

        internal static void ClearHighlightsResults(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            if (form.IsOpening)
            {
                return;
            }

            RichTextBox tempRichTextBox = new RichTextBox(); //Temporary RichTextBox to avoid too much undo/redo into buffer
            try
            {
                foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
                {
                    CustomRichTextBox textBox = ProgramUtil.GetPageTextBox(tabPage);
                    textBox.SuspendPainting();

                    tempRichTextBox.Rtf = textBox.Rtf;
                    tempRichTextBox.SelectAll();
                    tempRichTextBox.Font = new Font(textBox.Font, FontStyle.Regular);
                    tempRichTextBox.SelectionBackColor = tempRichTextBox.BackColor;

                    RichTextBoxUtil.ReplaceRTFContent(textBox, tempRichTextBox);
                    textBox.ResumePainting();
                }
            }
            finally
            {
                tempRichTextBox.Dispose();
            }

            TextManager.RefreshUndoRedoExternal(form);
        }

        internal static void ClearHighlightsResults(CustomRichTextBox pageTextBox)
        {
            RichTextBox tempRichTextBox = new RichTextBox(); //Temporary RichTextBox to avoid too much undo/redo into buffer
            try
            {
                pageTextBox.SuspendPainting();

                tempRichTextBox.Rtf = pageTextBox.Rtf;
                tempRichTextBox.SelectAll();
                tempRichTextBox.Font = new Font(pageTextBox.Font, FontStyle.Regular);
                tempRichTextBox.SelectionBackColor = tempRichTextBox.BackColor;

                RichTextBoxUtil.ReplaceRTFContent(pageTextBox, tempRichTextBox);
                pageTextBox.ResumePainting();
            }
            finally
            {
                tempRichTextBox.Dispose();
            }
        }

        /// <summary>
        /// Get longer string index in a string array.
        /// </summary>
        /// <param name="array">String array.</param>
        /// <returns>Index of the longer string.</returns>
        internal static int GetLongerStringInArray(String[] array)
        {
            int longerString = 0;
            int longerStringIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                String value = array[i];

                if (value.Length <= longerString)
                {
                    continue;
                }

                longerString = value.Length;
                longerStringIndex = i;
            }

            return longerStringIndex;
        }

        internal static bool AreLinesTooMuchForPasteWithRowLines(String text)
        {
            if (!ConfigUtil.GetBoolParameter("CheckLineNumber"))
            {
                return false;
            }

            String[] split = text.Split(new[] { ConstantUtil.newLine }, StringSplitOptions.None);

            return split.Length > ConfigUtil.GetIntParameter("CheckLineNumberMax");
        }

        internal static bool AreLinesTooMuchForPasteWithRowLines_External(String text)
        {
            if (!ConfigUtil.GetBoolParameter("CheckLineNumber"))
            {
                return false;
            }

            text = text.Replace(Environment.NewLine, ConstantUtil.newLine);
            String[] split = text.Split(new[] { ConstantUtil.newLine, "\r" }, StringSplitOptions.None);

            return split.Length > ConfigUtil.GetIntParameter("CheckLineNumberMax");
        }

        internal static String Rot13Transform(String inputString)
        {
            char[] array = inputString.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }

                array[i] = (char)number;
            }

            return new String(array);
        }

        //Valid method to enable if usefull
        //internal static int CountCharsInString(String text, String stringToSearch)
        //{
        //    String[] separator = { stringToSearch };
        //    String[] split = text.Split(separator, StringSplitOptions.None);

        //    return split.Length - 1;
        //}

        #endregion Internal Methods

        #region Private Methods

        private static bool GetCurrentLineIndexes(TextBoxBase pageTextBox, out int firstCharPosition, out int lastCharPosition)
        {
            int selectionStart = pageTextBox.SelectionStart;
            int selectionLength = pageTextBox.SelectionLength;
            int lastPosition = selectionLength > 0 ? selectionStart + selectionLength - 1 : selectionStart;

            firstCharPosition = 0;
            lastCharPosition = 0;
            int characterCount = 0;
            int characterCount2 = 0;
            int selectionStartCount = selectionStart;
            int lastPositionCount = lastPosition;
            bool firstPositionFounded = false;
            bool lastPositionFounded = false;
            bool lastLineHasReturn = false;
            String[] textLines = pageTextBox.Lines;

            for (int i = 0; i < textLines.Length; i++)
            {
                int lineLength = textLines[i].Length + 1;

                if (!(selectionStartCount < lineLength))
                {
                    selectionStartCount = selectionStartCount - lineLength;
                    characterCount = characterCount + lineLength;
                }
                else if (!firstPositionFounded)
                {
                    firstCharPosition = characterCount;
                    firstPositionFounded = true;
                }

                if (!(lastPositionCount < lineLength))
                {
                    lastPositionCount = lastPositionCount - lineLength;
                    characterCount2 = characterCount2 + lineLength;
                }
                else if (!lastPositionFounded)
                {
                    lastCharPosition = characterCount2 + lineLength - 1;
                    lastPositionFounded = true;

                    if (i < textLines.Length - 1)
                    {
                        lastLineHasReturn = true;
                    }
                }
            }

            return lastLineHasReturn;
        }

        #endregion Private Methods
    }
}
