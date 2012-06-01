using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DtControls;
using DtPad.Customs;
using DtPad.Utils;
using ComboBox = System.Windows.Forms.ComboBox;

namespace DtPad.Managers
{
    /// <summary>
    /// Text operations manager (ie. undo/redo, paste).
    /// </summary>
    /// <author>Marco Macciò</author>
    /// <see cref="http://msdn.microsoft.com/en-us/library/system.windows.forms.richtextbox_members(VS.80).aspx"/>
    /// <see cref="http://msdn.microsoft.com/en-us/library/system.windows.forms.textboxbase_methods(VS.80).aspx"/>
    /// <remarks>
    /// pageTextBox.GetFirstCharIndexFromLine => TextManager.ReadRTBFirstCharIndexFromLine
    /// pageTextBox.GetLineFromCharIndex => TextManager.ReadRTBLineFromCharIndex
    /// </remarks>CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
    internal static class TextManager
    {
        private const String className = "TextManager";

        internal enum SpecialPaste
        {
            HTML,
            RTF
        }

        #region Generic Methods

        internal static void Undo(Form1 form)
        {
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox pathTextBox = form.filePanel.pathTextBox;

            if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || prefixToolStripTextBox.Focused
                || suffixToolStripTextBox.Focused || pathTextBox.Focused)
            {
                TextBox textBox;

                if (TextBoxFactory(form, out textBox) && textBox.CanUndo)
                {
                    textBox.Undo();
                }
            }
            else //(pageTextBox.Focused && pageTextBox.CanUndo)
            {
                pageTextBox.IsUndoingRedoing = true;
                pageTextBox.Undo();
                RefreshUndoRedoExternal(form);
            }
        }

        internal static void Copy(Form1 form)
        {
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox pathTextBox = form.filePanel.pathTextBox;

            try
            {
                if (pageTextBox.Focused && pageTextBox.SelectionLength > 0)
                {
                    Clipboard.SetDataObject(pageTextBox.SelectedText.Replace(ConstantUtil.newLine, Environment.NewLine), true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                }
                else if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || prefixToolStripTextBox.Focused
                    || suffixToolStripTextBox.Focused || pathTextBox.Focused)
                {
                    TextBox textBox;

                    if (TextBoxFactory(form, out textBox) && textBox.SelectionLength > 0)
                    {
                        textBox.Copy();
                    }
                }
                else if (prefixToolStripComboBox.Focused && prefixToolStripComboBox.SelectionLength > 0)
                {
                    Clipboard.SetDataObject(prefixToolStripComboBox.SelectedText, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                }
            }
            catch (ExternalException exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }

            ClipboardManager.AddContent(form);
        }

        internal static void CopyAppend(Form1 form)
        {
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;

            try
            {
                if (pageTextBox.Focused && pageTextBox.SelectionLength > 0)
                {
                    String textClipboard = pageTextBox.SelectedText.Replace(ConstantUtil.newLine, Environment.NewLine);
                    if (Clipboard.ContainsText())
                    {
                        textClipboard = textClipboard.Insert(0, Clipboard.GetText());
                    }
                    Clipboard.SetDataObject(textClipboard, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                }
                else if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || prefixToolStripTextBox.Focused
                    || suffixToolStripTextBox.Focused)
                {
                    TextBox textBox;

                    if (TextBoxFactory(form, out textBox) && textBox.SelectionLength > 0)
                    {
                        String textClipboard = textBox.SelectedText;
                        if (Clipboard.ContainsText())
                        {
                            textClipboard = textClipboard.Insert(0, Clipboard.GetText());
                        }
                        Clipboard.SetDataObject(textClipboard, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                    }
                }
                else if (prefixToolStripComboBox.Focused && prefixToolStripComboBox.SelectionLength > 0)
                {
                    String textClipboard = prefixToolStripComboBox.SelectedText;
                    if (Clipboard.ContainsText())
                    {
                        textClipboard = textClipboard.Insert(0, Clipboard.GetText());
                    }
                    Clipboard.SetDataObject(textClipboard, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                }
            }
            catch (ExternalException exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }

            ClipboardManager.AddContent(form);
        }

        internal static void Cut(Form1 form)
        {
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox pathTextBox = form.filePanel.pathTextBox;

            try
            {
                if (pageTextBox.Focused && pageTextBox.SelectionLength > 0)
                {
                    Clipboard.SetDataObject(pageTextBox.SelectedText.Replace(ConstantUtil.newLine, Environment.NewLine), true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                    pageTextBox.SelectedText = String.Empty;
                    RefreshUndoRedoExternal(form);
                }
                else if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || prefixToolStripTextBox.Focused
                    || suffixToolStripTextBox.Focused || pathTextBox.Focused)
                {
                    TextBox textBox;

                    if (TextBoxFactory(form, out textBox) && textBox.SelectionLength > 0)
                    {
                        textBox.Cut();
                    }
                }
                else if (prefixToolStripComboBox.Focused && prefixToolStripComboBox.SelectionLength > 0)
                {
                    Clipboard.SetDataObject(prefixToolStripComboBox.SelectedText, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                    prefixToolStripComboBox.SelectedText = String.Empty;
                }
            }
            catch (ExternalException exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }

            ClipboardManager.AddContent(form);
        }

        internal static void CutAppend(Form1 form)
        {
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;

            try
            {
                if (pageTextBox.Focused && pageTextBox.SelectionLength > 0)
                {
                    String textClipboard = pageTextBox.SelectedText.Replace(ConstantUtil.newLine, Environment.NewLine);
                    if (Clipboard.ContainsText())
                    {
                        textClipboard = textClipboard.Insert(0, Clipboard.GetText());
                    }
                    pageTextBox.SelectedText = String.Empty;
                    Clipboard.SetDataObject(textClipboard, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                    RefreshUndoRedoExternal(form);
                }
                else if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || prefixToolStripTextBox.Focused
                    || suffixToolStripTextBox.Focused)
                {
                    TextBox textBox;

                    if (TextBoxFactory(form, out textBox) && textBox.SelectionLength > 0)
                    {
                        String textClipboard = textBox.SelectedText;
                        if (Clipboard.ContainsText())
                        {
                            textClipboard = textClipboard.Insert(0, Clipboard.GetText());
                        }
                        textBox.SelectedText = String.Empty;
                        Clipboard.SetDataObject(textClipboard, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                    }
                }
                else if (prefixToolStripComboBox.Focused && prefixToolStripComboBox.SelectionLength > 0)
                {
                    String textClipboard = prefixToolStripComboBox.SelectedText;
                    if (Clipboard.ContainsText())
                    {
                        textClipboard = textClipboard.Insert(0, Clipboard.GetText());
                    }
                    prefixToolStripComboBox.SelectedText = String.Empty;
                    Clipboard.SetDataObject(textClipboard, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                }
            }
            catch (ExternalException exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }

            ClipboardManager.AddContent(form);
        }

        internal static void Paste(Form1 form, bool forcePageTextBox = false)
        {
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox pathTextBox = form.filePanel.pathTextBox;
            CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.SelectedTabPage);

            if (!Clipboard.ContainsText())
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ClipboardNotText", className));
            }

            try
            {
                if (pageTextBox.Focused || forcePageTextBox)
                {
                    String clipboardText = Clipboard.GetText(TextDataFormat.Text).Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
                    bool linesDisabled = false;

                    if (StringUtil.AreLinesTooMuchForPasteWithRowLines(pageTextBox.Text + clipboardText) && customLineNumbers.Visible)
                    {
                        WindowManager.CheckLineNumbers(form, false, true);
                        linesDisabled = true;
                    }

                    pageTextBox.SelectedText = clipboardText; //pageTextBox.Paste(DataFormats.GetFormat(DataFormats.Text)); 
                    RefreshUndoRedoExternal(form);

                    if (linesDisabled)
                    {
                        WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("LineNumbersDisabled", className));
                    }
                }
                else if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || prefixToolStripTextBox.Focused
                    || suffixToolStripTextBox.Focused || pathTextBox.Focused)
                {
                    TextBox textBox;

                    if (TextBoxFactory(form, out textBox))
                    {
                        textBox.Paste();
                    }
                }
                else if (prefixToolStripComboBox.Focused)
                {
                    prefixToolStripComboBox.SelectedText = Clipboard.GetText();
                }
            }
            catch (ExternalException exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }

            ClipboardManager.AddContent(form);
        }

        internal static void PasteSpecial(Form1 form, SpecialPaste pasteType)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.SelectedTabPage);

            if (!Clipboard.ContainsText())
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ClipboardNotText", className));
            }

            String clipboardText = String.Empty;
            switch (pasteType)
            {
                case SpecialPaste.HTML:
                    clipboardText = Clipboard.GetText(TextDataFormat.Html);
                    break;
                case SpecialPaste.RTF:
                    clipboardText = Clipboard.GetText(TextDataFormat.Rtf);
                    break;
            }

            if (String.IsNullOrEmpty(clipboardText))
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoSpecialData", className));
                return;
            }

            try
            {
                if (pageTextBox.Focused)
                {
                    clipboardText = clipboardText.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
                    bool linesDisabled = false;

                    if (StringUtil.AreLinesTooMuchForPasteWithRowLines(pageTextBox.Text + clipboardText) && customLineNumbers.Visible)
                    {
                        WindowManager.CheckLineNumbers(form, false, true);
                        linesDisabled = true;
                    }

                    pageTextBox.SelectedText = clipboardText;
                    RefreshUndoRedoExternal(form);

                    if (linesDisabled)
                    {
                        WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("LineNumbersDisabled", className));
                    }
                }
            }
            catch (ExternalException exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }

            ClipboardManager.AddContent(form);
        }

        internal static void SwapWithClipboard(Form1 form)
        {
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;

            if (!Clipboard.ContainsText())
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ClipboardNotText", className));
            }

            try
            {
                if (pageTextBox.Focused && pageTextBox.SelectionLength > 0)
                {
                    String textClipboard = String.Empty;
                    if (Clipboard.ContainsText())
                    {
                        textClipboard = Clipboard.GetText();
                    }
                    Clipboard.SetDataObject(pageTextBox.SelectedText.Replace(ConstantUtil.newLine, Environment.NewLine), true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                    pageTextBox.SelectedText = textClipboard;
                    RefreshUndoRedoExternal(form);
                }
                else if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || prefixToolStripTextBox.Focused
                    || suffixToolStripTextBox.Focused)
                {
                    TextBox textBox;

                    if (TextBoxFactory(form, out textBox) && textBox.SelectionLength > 0)
                    {
                        String textClipboard = String.Empty;
                        if (Clipboard.ContainsText())
                        {
                            textClipboard = Clipboard.GetText();
                        }
                        Clipboard.SetDataObject(textBox.SelectedText, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                        textBox.SelectedText = textClipboard;
                    }
                }
                else if (prefixToolStripComboBox.Focused && prefixToolStripComboBox.SelectionLength > 0)
                {
                    String textClipboard = String.Empty;
                    if (Clipboard.ContainsText())
                    {
                        textClipboard = Clipboard.GetText();
                    }
                    Clipboard.SetDataObject(prefixToolStripComboBox.SelectedText, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                    prefixToolStripComboBox.SelectedText = textClipboard;
                }
            }
            catch (ExternalException exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }

            ClipboardManager.AddContent(form);
        }

        internal static void DeleteLine(Form1 form)
        {
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;

            if (pageTextBox.Focused)
            {
                StringUtil.SelectCurrentLines(pageTextBox);
                Delete(form);
            }
            else if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused)
            {
                TextBox textBox;
                TextBoxFactory(form, out textBox);

                StringUtil.SelectCurrentLinesTextBox(textBox);
                Delete(form);
            }
            else if (prefixToolStripComboBox.Focused)
            {
                prefixToolStripComboBox.SelectAll();
                Delete(form);
            }
        }

        internal static void Delete(Form1 form)
        {
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox pathTextBox = form.filePanel.pathTextBox;

            if (pageTextBox.Focused)
            {
                if (pageTextBox.SelectionLength == 0)
                {
                    pageTextBox.SelectionLength = 1;
                }

                pageTextBox.SelectedText = String.Empty;
                RefreshUndoRedoExternal(form);
            }
            else if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || prefixToolStripTextBox.Focused
                || suffixToolStripTextBox.Focused || pathTextBox.Focused)
            {
                TextBox textBox;

                if (TextBoxFactory(form, out textBox) && textBox.SelectionLength == 0)
                {
                    textBox.SelectionLength = 1;
                }

                textBox.SelectedText = String.Empty;
            }
            else if (prefixToolStripComboBox.Focused)
            {
                if (prefixToolStripComboBox.SelectionLength == 0)
                {
                    prefixToolStripComboBox.SelectionLength = 1;
                }

                prefixToolStripComboBox.SelectedText = String.Empty;
            }
        }

        internal static void SelectAll(Form1 form)
        {
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox pathTextBox = form.filePanel.pathTextBox;

            if (pageTextBox.Focused)
            {
                pageTextBox.SelectAll();
            }
            else if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || prefixToolStripTextBox.Focused
                || suffixToolStripTextBox.Focused || pathTextBox.Focused)
            {
                TextBox textBox;

                if (TextBoxFactory(form, out textBox))
                {
                    textBox.SelectAll();
                }
            }
            else if (prefixToolStripComboBox.Focused)
            {
                prefixToolStripComboBox.SelectAll();
            }
        }

        internal static void SelectCurrentLine(Form1 form)
        {
            ToolStripComboBox prefixToolStripComboBox = form.prefixToolStripComboBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox noteTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;

            if (pageTextBox.Focused)
            {
                StringUtil.SelectCurrentLines(pageTextBox);
            }
            else if (searchTextBox.Focused || replaceTextBox.Focused || noteTitleTextBox.Focused || nodeTextTextBox.Focused || prefixToolStripTextBox.Focused
                || suffixToolStripTextBox.Focused)
            {
                TextBox textBox;

                if (TextBoxFactory(form, out textBox))
                {
                    StringUtil.SelectCurrentLinesTextBox(textBox);
                }
            }
            else if (prefixToolStripComboBox.Focused)
            {
                prefixToolStripComboBox.SelectAll();
            }
        }

        internal static void SelectLinesFromRowAToRowB(Form1 form, int rowA, int rowB)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            StringUtil.SelectLinesFromRowAToRowB(pageTextBox, ReadRTBFirstCharIndexFromLine(form, rowA), ReadRTBFirstCharIndexFromLine(form, rowB), rowB);
        }

        internal static int ReadRTBLineNumbers(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String[] separator = { ConstantUtil.newLine };
            String[] lines = pageTextBox.Text.Split(separator, StringSplitOptions.None);

            return lines.Length;
        }

        internal static int ReadRTBFirstCharIndexFromLine(Form1 form, int line)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String[] separator = { ConstantUtil.newLine };
            String[] lines = pageTextBox.Text.Split(separator, StringSplitOptions.None);

            int beforechars = 0;
            for (int i = 0; i < line; i++)
            {
                beforechars = beforechars + lines[i].Length + ConstantUtil.newLine.Length;
            }

            return beforechars;
        }
        

        internal static int ReadRTBLineFromCharIndex(Form1 form, int charIndex)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String[] separator = { ConstantUtil.newLine };
            String[] lines = pageTextBox.Text.Split(separator, StringSplitOptions.None);

            int beforechars = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                beforechars = beforechars + lines[i].Length + ConstantUtil.newLine.Length;

                if (beforechars > charIndex)
                {
                    return i;
                }
            }

            return 0;
        }

        internal static void Rot13Transform(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            pageTextBox.SelectAll();
            pageTextBox.SelectedText = StringUtil.Rot13Transform(pageTextBox.Text);
            RefreshUndoRedoExternal(form);
        }

        internal static void PadToLeft(Form1 form1, PadText form)
        {
            NumericUpDown widthNumericUpDown = form.widthNumericUpDown;
            TextBox whiteCharacterTextBox = form.whiteCharacterTextBox;

            PadTo(form1, form, Convert.ToInt32(widthNumericUpDown.Value), whiteCharacterTextBox.Text[0], 1);
        }

        internal static void PadToRight(Form1 form1, PadText form)
        {
            NumericUpDown widthNumericUpDown = form.widthNumericUpDown;
            TextBox whiteCharacterTextBox = form.whiteCharacterTextBox;

            PadTo(form1, form, Convert.ToInt32(widthNumericUpDown.Value), whiteCharacterTextBox.Text[0], 2);
        }

        internal static String KeepInitialSpacesOnReturn(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String line = String.Empty;
            if (!String.IsNullOrEmpty(pageTextBox.Text))
            {
                line = pageTextBox.Lines[StringUtil.SelectCurrentLinesFirstIndex(pageTextBox)];
            }

            if (String.IsNullOrEmpty(line) || (!line.StartsWith(" ") && !line.StartsWith("\t")))
            {
                return String.Empty;
            }

            String initialSpaces = String.Empty;
            int index = 0;
            char lineChar = line[index];
            while (lineChar == ' ' || lineChar == '\t')
            {
                initialSpaces += lineChar;
                if (index == line.Length - 1)
                {
                    break;
                }
                lineChar = line[++index];
            }

            return initialSpaces;
        }

        internal static String KeepBulletListOnReturn(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String line = String.Empty;
            if (!String.IsNullOrEmpty(pageTextBox.Text))
            {
                line = pageTextBox.Lines[StringUtil.SelectCurrentLinesFirstIndex(pageTextBox)].TrimStart(new[] { ' ', '\t' });
            }

            if (String.IsNullOrEmpty(line))
            {
                return String.Empty;
            }

            String result = String.Empty;

            int bulletIndex;
            if (int.TryParse(line.Substring(0, 1), out bulletIndex))
            {
                int intLenght = 1;
                int intTemp;
                while (line.Length > intLenght && int.TryParse(line.Substring(intLenght, 1), out intTemp))
                {
                    intLenght++;

                    if (intLenght >= ConstantUtil.maxLenghtForBulletList)
                    {
                        break;
                    }
                }

                if ((line.Length >= intLenght + 2) && (line.Substring(intLenght, 2) == ") " || line.Substring(intLenght, 2) == ". " || line.Substring(intLenght, 2) == "- "))
                {
                    bulletIndex = int.Parse(line.Substring(0, intLenght));
                    result = String.Format("{0}{1}", bulletIndex + 1, line.Substring(intLenght, 1));

                    //spaces
                    int counter = intLenght + 1;
                    while (line[counter] == ' ' || line[counter] == '\t')
                    {
                        result += line[counter];
                        counter++;

                        if (counter >= line.Length)
                        {
                            break;
                        }
                    }
                }
            }
            if (line.StartsWith("- ")) //.TrimStart(new[] { ' ', '\t' })
            {
                result = line.Substring(0, 2);

                if (line.Length >= 3)
                {
                    //spaces
                    int counter = 2;
                    while (line[counter] == ' ' || line[counter] == '\t')
                    {
                        result += line[counter];
                        counter++;

                        if (counter >= line.Length)
                        {
                            break;
                        }
                    }
                }
            }

            return result;
        }

        internal static void InsertGUID(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            pageTextBox.SelectedText = Guid.NewGuid().ToString();
            RefreshUndoRedoExternal(form);
        }

        internal static void InsertRandomNumber(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            pageTextBox.SelectedText = new Random().Next().ToString();
            RefreshUndoRedoExternal(form);
        }

        internal static void InsertRowNumbers(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String result = String.Empty;
            String[] textArray = pageTextBox.Text.Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.None);

            for (int i = 0; i < textArray.Length; i++)
            {
                String rowText = textArray[i];

                if (i == textArray.Length - 1)
                {
                    result += (i + 1).ToString().PadLeft(8, '0') + " " + rowText;
                }
                else
                {
                    result += (i + 1).ToString().PadLeft(8, '0') + " " + rowText + ConstantUtil.newLine;
                }
            }

            pageTextBox.SelectAll();
            pageTextBox.SelectedText = result;
            RefreshUndoRedoExternal(form);
        }

        internal static void InsertColumnNumbers(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            pageTextBox.Select(0, 0);
            pageTextBox.SelectedText = ConstantUtil.columnsHeaderShort;
            RefreshUndoRedoExternal(form);
        }

        #endregion Generic Methods

        #region Generic Control Methods

        internal static void UndoControl(Control activeControl)
        {
            Type controlType = activeControl.GetType();
            if (controlType == typeof(TextBox) || controlType == typeof(CustomTextBox) || controlType == typeof(TextBoxMaskBox))
            {
                TextBox textBox = (TextBox)activeControl;

                if (!textBox.CanUndo)
                {
                    return;
                }
                textBox.Focus();
                textBox.Undo();
            }
            else if ((controlType == typeof(RichTextBox) || controlType == typeof(CustomRichTextBoxBase)) && controlType != typeof(CustomRichTextBox))
            {
                RichTextBox textBox = (RichTextBox)activeControl;

                if (!textBox.CanUndo)
                {
                    return;
                }
                textBox.Focus();
                textBox.Undo();
            }
        }

        internal static void CopyControl(Control activeControl)
        {
            Type controlType = activeControl.GetType();

            if (controlType == typeof(TextBox) || controlType == typeof(CustomTextBox) || controlType == typeof(TextBoxMaskBox))
            {
                TextBox textBox = (TextBox)activeControl;

                if (textBox.SelectionLength <= 0)
                {
                    return;
                }
                textBox.Focus();
                textBox.Copy();
            }
            else if ((controlType == typeof(RichTextBox) || controlType == typeof(CustomRichTextBoxBase)) && controlType != typeof(CustomRichTextBox))
            {
                RichTextBox textBox = (RichTextBox)activeControl;

                if (textBox.SelectionLength <= 0)
                {
                    return;
                }
                textBox.Focus();
                textBox.Copy();
            }
            else if (controlType == typeof(ComboBox) || controlType == typeof(CustomComboBox))
            {
                ComboBox comboBox = (ComboBox)activeControl;

                if (comboBox.SelectionLength <= 0)
                {
                    return;
                }
                comboBox.Focus();
                Clipboard.SetDataObject(comboBox.SelectedText, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
            }
            else if (controlType == typeof(NumericUpDown) || controlType == typeof(CustomNumericUpDown))
            {
                UpDownBase numericUpDown = (UpDownBase)activeControl;

                numericUpDown.Focus();
                numericUpDown.Select(0, numericUpDown.Text.Length);
                Clipboard.SetDataObject(numericUpDown.Text, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
            }
        }

        internal static void CutControl(Control activeControl)
        {
            Type controlType = activeControl.GetType();

            if (controlType == typeof(TextBox) || controlType == typeof(CustomTextBox) || controlType == typeof(TextBoxMaskBox))
            {
                TextBox textBox = (TextBox)activeControl;

                if (textBox.SelectionLength <= 0)
                {
                    return;
                }
                textBox.Focus();
                textBox.Cut();
            }
            else if ((controlType == typeof(RichTextBox) || controlType == typeof(CustomRichTextBoxBase)) && controlType != typeof(CustomRichTextBox))
            {
                RichTextBox textBox = (RichTextBox)activeControl;

                if (textBox.SelectionLength <= 0)
                {
                    return;
                }
                textBox.Focus();
                textBox.Cut();
            }
            else if (controlType == typeof(ComboBox) || controlType == typeof(CustomComboBox))
            {
                ComboBox comboBox = (ComboBox)activeControl;

                if (comboBox.SelectionLength <= 0)
                {
                    return;
                }
                comboBox.Focus();
                Clipboard.SetDataObject(comboBox.SelectedText, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
                comboBox.SelectedText = String.Empty;
            }
        }

        internal static void PasteControl(Control activeControl)
        {
            Type controlType = activeControl.GetType();

            if (controlType == typeof(TextBox) || controlType == typeof(CustomTextBox) || controlType == typeof(TextBoxMaskBox))
            {
                TextBox textBox = (TextBox)activeControl;

                if (!Clipboard.ContainsText())
                {
                    return;
                }
                textBox.Focus();
                textBox.Paste();
            }
            else if ((controlType == typeof(RichTextBox) || controlType == typeof(CustomRichTextBoxBase)) && controlType != typeof(CustomRichTextBox))
            {
                RichTextBox textBox = (RichTextBox)activeControl;

                if (!Clipboard.ContainsText())
                {
                    return;
                }

                String clipboardText = Clipboard.GetText(TextDataFormat.Text);
                textBox.Focus();
                textBox.SelectedText = clipboardText; //textBox.Paste(DataFormats.GetFormat(DataFormats.Text));
            }
            else if (controlType == typeof(ComboBox) || controlType == typeof(CustomComboBox))
            {
                ComboBox comboBox = (ComboBox)activeControl;

                if (!Clipboard.ContainsText())
                {
                    return;
                }
                comboBox.Focus();
                comboBox.SelectedText = Clipboard.GetText();
            }
            else if (controlType == typeof(NumericUpDown) || controlType == typeof(CustomNumericUpDown))
            {
                UpDownBase numericUpDown = (UpDownBase)activeControl;

                int number;
                if (!Clipboard.ContainsText())
                {
                    return;
                }
                if (!Int32.TryParse(Clipboard.GetText(), out number))
                {
                    return;
                }
                numericUpDown.Focus();
                numericUpDown.Select(0, numericUpDown.Text.Length);
                numericUpDown.Text = number.ToString();
            }
        }

        internal static void DeleteControl(Control activeControl)
        {
            Type controlType = activeControl.GetType();

            if (controlType == typeof(TextBox) || controlType == typeof(CustomTextBox) || controlType == typeof(TextBoxMaskBox))
            {
                TextBox textBox = (TextBox)activeControl;

                if (textBox.SelectionLength <= 0)
                {
                    return;
                }
                textBox.Focus();
                textBox.SelectedText = String.Empty;
            }
            else if ((controlType == typeof(RichTextBox) || controlType == typeof(CustomRichTextBoxBase)) && controlType != typeof(CustomRichTextBox))
            {
                RichTextBox textBox = (RichTextBox)activeControl;

                if (textBox.SelectionLength <= 0)
                {
                    return;
                }
                textBox.Focus();
                textBox.SelectedText = String.Empty;
            }
            else if (controlType == typeof(ComboBox) || controlType == typeof(CustomComboBox))
            {
                ComboBox comboBox = (ComboBox)activeControl;

                if (comboBox.SelectionLength <= 0)
                {
                    return;
                }
                comboBox.Focus();
                comboBox.SelectedText = String.Empty;
            }
        }

        internal static void SelectAllControl(Control activeControl)
        {
            Type controlType = activeControl.GetType();

            if (controlType == typeof(TextBox) || controlType == typeof(CustomTextBox) || controlType == typeof(TextBoxMaskBox))
            {
                TextBox textBox = (TextBox)activeControl;

                textBox.Focus();
                textBox.SelectAll();
            }
            else if ((controlType == typeof(RichTextBox) || controlType == typeof(CustomRichTextBoxBase)) && controlType != typeof(CustomRichTextBox))
            {
                RichTextBox textBox = (RichTextBox)activeControl;

                textBox.Focus();
                textBox.SelectAll();
            }
            else if (controlType == typeof(ComboBox) || controlType == typeof(CustomComboBox))
            {
                ComboBox comboBox = (ComboBox)activeControl;

                comboBox.Focus();
                comboBox.SelectAll();
            }
            else if (controlType == typeof(NumericUpDown) || controlType == typeof(CustomNumericUpDown))
            {
                UpDownBase numericUpDown = (UpDownBase)activeControl;

                numericUpDown.Focus();
                numericUpDown.Select(0, numericUpDown.Text.Length);
            }
        }

        #endregion Generic Control Methods

        #region RichTextBox Methods

        internal static void UndoRich(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (pageTextBox.CanUndo)
            {
                pageTextBox.IsUndoingRedoing = true;
                pageTextBox.Undo();
            }
            RefreshUndoRedoExternal(form);
        }

        internal static void UndoAllRich(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            pageTextBox.SuspendPainting();

            while (pageTextBox.CanUndo)
            {
                pageTextBox.IsUndoingRedoing = true;
                pageTextBox.Undo();
            }

            pageTextBox.ResumePainting();
            RefreshUndoRedoExternal(form);
        }

        internal static void RedoRich(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (pageTextBox.CanRedo)
            {
                pageTextBox.IsUndoingRedoing = true;
                pageTextBox.Redo();
            }
            RefreshUndoRedoExternal(form);
        }

        internal static void RedoAllRich(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            pageTextBox.SuspendPainting();

            while (pageTextBox.CanRedo)
            {
                pageTextBox.IsUndoingRedoing = true;
                pageTextBox.Redo();
            }

            pageTextBox.ResumePainting();
            RefreshUndoRedoExternal(form);
        }

        internal static void RefreshUndoRedoExternal(Form1 form)
        {
            RefreshUndo(form);
            RefreshRedo(form);
        }

        internal static void InsertDateTime(Form1 form, String datetime)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            pageTextBox.SelectedText = datetime; //String.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            RefreshUndoRedoExternal(form);
        }

        internal static void ToUppercase(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (pageTextBox.SelectionLength == 0)
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("ChangeCharsCase", className));
                return;
            }

            int startSelection = pageTextBox.SelectionStart;
            int lengthSelection = pageTextBox.SelectionLength;
            pageTextBox.SelectedText = pageTextBox.SelectedText.ToUpper();
            pageTextBox.Select(startSelection, lengthSelection);

            RefreshUndoRedoExternal(form);
        }

        internal static void ToLowercase(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (pageTextBox.SelectionLength == 0)
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("ChangeCharsCase", className));
                return;
            }

            int startSelection = pageTextBox.SelectionStart;
            int lengthSelection = pageTextBox.SelectionLength;
            pageTextBox.SelectedText = pageTextBox.SelectedText.ToLower();
            pageTextBox.Select(startSelection, lengthSelection);

            RefreshUndoRedoExternal(form);
        }

        internal static void ToInitialUppercase(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (pageTextBox.SelectionLength == 0)
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("ChangeCharsCase", className));
                return;
            }

            String selectedText = pageTextBox.SelectedText;
            String elaboratedText = String.Empty;

            if (pageTextBox.SelectionStart - 1 >= 0)
            {
                String previousChar = pageTextBox.Text[pageTextBox.SelectionStart - 1].ToString();

                if (previousChar == " " || previousChar == ConstantUtil.newLine || previousChar == "(" || previousChar == "[" || previousChar == "\"")
                {
                    elaboratedText += selectedText[0].ToString().ToUpper();
                }
                else
                {
                    elaboratedText += selectedText[0].ToString().ToLower();
                }
            }
            else
            {
                elaboratedText += selectedText[0].ToString().ToUpper();
            }

            for (int i = 1; i < selectedText.Length; i++)
            {
                String previousChar = selectedText[i - 1].ToString();

                if (previousChar == " " || previousChar == ConstantUtil.newLine || previousChar == "(" || previousChar == "[" || previousChar == "\"")
                {
                    elaboratedText += selectedText[i].ToString().ToUpper();
                }
                else
                {
                    elaboratedText += selectedText[i].ToString().ToLower();
                }
            }

            int startSelection = pageTextBox.SelectionStart;
            int lengthSelection = pageTextBox.SelectionLength;
            pageTextBox.SelectedText = elaboratedText;
            pageTextBox.Select(startSelection, lengthSelection);

            RefreshUndoRedoExternal(form);
        }

        internal static void IndentSelectedLines(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String tab = "\t";
            if (ConfigUtil.GetBoolParameter("SpacesInsteadTabs"))
            {
                tab = "       ";
            }

            if (pageTextBox.SelectionLength == 0)
            {
                pageTextBox.SelectedText = tab;
                return;
            }

            bool lastLineHasReturn = StringUtil.SelectCurrentLines(pageTextBox);
            int previousSelectionStart = pageTextBox.SelectionStart;
            int previousSelectionLength = pageTextBox.SelectionLength;
            int linesNumer = 0;
            String selectedText = pageTextBox.SelectedText;
            String[] separator = { ConstantUtil.newLine };
            String[] splittedFileContent = selectedText.Split(separator, StringSplitOptions.None);
            selectedText = String.Empty;

            for (int i = 0; i < splittedFileContent.Length; i++)
            {
                if (i != splittedFileContent.Length - 1)
                {
                    selectedText += splittedFileContent[i].Insert(0, tab) + ConstantUtil.newLine;
                    linesNumer++;
                }
                else
                {
                    if (!lastLineHasReturn)
                    {
                        selectedText += splittedFileContent[i].Insert(0, tab);
                        linesNumer++;
                    }
                }
            }

            pageTextBox.SelectedText = selectedText;
            pageTextBox.SelectionStart = previousSelectionStart;
            pageTextBox.SelectionLength = previousSelectionLength + linesNumer;

            RefreshUndoRedoExternal(form);
        }

        internal static void OutdentSelectedLines(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (String.IsNullOrEmpty(pageTextBox.Text))
            {
                return;
            }

            StringUtil.SelectCurrentLines(pageTextBox);
            int previousSelectionStart = pageTextBox.SelectionStart;
            int previousSelectionLength = pageTextBox.SelectionLength;
            int linesNumer = 0;
            String selectedText = pageTextBox.SelectedText;
            String[] separator = { ConstantUtil.newLine };
            String[] splittedFileContent = selectedText.Split(separator, StringSplitOptions.None);
            selectedText = String.Empty;

            for (int i = 0; i < splittedFileContent.Length; i++)
            {
                if (splittedFileContent[i].Length == 0 && i != splittedFileContent.Length - 1)
                {
                    selectedText = selectedText + ConstantUtil.newLine;
                    continue;
                }
                if (splittedFileContent[i].Length == 0 && i == splittedFileContent.Length - 1)
                {
                    continue;
                }
                
                if (i != splittedFileContent.Length - 1)
                {
                    if (splittedFileContent[i][0].ToString() == "\t")
                    {
                        selectedText = selectedText + splittedFileContent[i].Substring(1) + ConstantUtil.newLine;
                        linesNumer++;
                    }
                    else if (splittedFileContent[i].StartsWith("       "))
                    {
                        selectedText = selectedText + splittedFileContent[i].Substring(7) + ConstantUtil.newLine;
                        linesNumer = linesNumer + 7;
                    }
                    else
                    {
                        int j = 0;
                        while (j < splittedFileContent[i].Length && splittedFileContent[i][j] == ' ')
                        {
                            linesNumer++;
                            j++;
                        }
                        selectedText = selectedText + splittedFileContent[i].TrimStart() + ConstantUtil.newLine;
                    }
                }
                else
                {
                    if (splittedFileContent[i][0].ToString() == "\t")
                    {
                        selectedText = selectedText + splittedFileContent[i].Substring(1);
                        linesNumer++;
                    }
                    else if (splittedFileContent[i].StartsWith("       "))
                    {
                        selectedText = selectedText + splittedFileContent[i].Substring(7);
                        linesNumer = linesNumer + 7;
                    }
                    else
                    {
                        int j = 0;
                        while (j < splittedFileContent[i].Length && splittedFileContent[i][j] == ' ')
                        {
                            linesNumer++;
                            j++;
                        }

                        selectedText = selectedText + splittedFileContent[i].TrimStart();
                    }
                }
            }

            pageTextBox.SelectedText = selectedText;
            pageTextBox.SelectionStart = previousSelectionStart;
            pageTextBox.SelectionLength = previousSelectionLength - linesNumer;

            RefreshUndoRedoExternal(form);
        }

        internal static void InsertInitialString(Form1 form, String initialString)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool lastLineHasReturn = StringUtil.SelectCurrentLines(pageTextBox);
            int previousSelectionStart = pageTextBox.SelectionStart;
            int previousSelectionLength = pageTextBox.SelectionLength;
            int linesNumer = 0;
            String selectedText = pageTextBox.SelectedText;
            String[] separator = { ConstantUtil.newLine };
            String[] splittedFileContent = selectedText.Split(separator, StringSplitOptions.None);
            selectedText = String.Empty;

            if (splittedFileContent.Length == 0)
            {
                pageTextBox.SelectedText = initialString;
                linesNumer = linesNumer + initialString.Length;
            }

            for (int i = 0; i < splittedFileContent.Length; i++)
            {
                if (i != splittedFileContent.Length - 1)
                {
                    selectedText = selectedText + splittedFileContent[i].Insert(0, initialString) + ConstantUtil.newLine;
                    linesNumer = linesNumer + initialString.Length;
                }
                else
                {
                    if (!lastLineHasReturn)
                    {
                        selectedText = selectedText + splittedFileContent[i].Insert(0, initialString);
                        linesNumer = linesNumer + initialString.Length;
                    }
                }
            }

            pageTextBox.SelectedText = selectedText;
            pageTextBox.SelectionStart = previousSelectionStart;
            pageTextBox.SelectionLength = previousSelectionLength + linesNumer;

            RefreshUndoRedoExternal(form);
        }

        internal static void RemoveInitialString(Form1 form, String initialString)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool lastLineHasReturn = StringUtil.SelectCurrentLines(pageTextBox);
            int previousSelectionStart = pageTextBox.SelectionStart;
            int previousSelectionLength = pageTextBox.SelectionLength;
            int linesNumer = 0;
            String selectedText = pageTextBox.SelectedText;
            String[] separator = { ConstantUtil.newLine };
            String[] splittedFileContent = selectedText.Split(separator, StringSplitOptions.None);
            selectedText = String.Empty;

            for (int i = 0; i < splittedFileContent.Length; i++)
            {
                if (splittedFileContent[i].Length == 0 && i != splittedFileContent.Length - 1)
                {
                    selectedText = selectedText + ConstantUtil.newLine;
                    continue;
                }
                if (splittedFileContent[i].Length == 0 && i == splittedFileContent.Length - 1)
                {
                    continue;
                }
                
                if ((i == splittedFileContent.Length - 1 && lastLineHasReturn) || i != splittedFileContent.Length - 1)
                {
                    if (splittedFileContent[i].Length >= initialString.Length && splittedFileContent[i].Substring(0, initialString.Length) == initialString)
                    {
                        selectedText = selectedText + splittedFileContent[i].Substring(initialString.Length) + ConstantUtil.newLine;
                        linesNumer = linesNumer + initialString.Length;
                    }
                    else
                    {
                        selectedText = selectedText + splittedFileContent[i] + ConstantUtil.newLine;
                    }
                }
                else
                {
                    if (splittedFileContent[i].Length >= initialString.Length && splittedFileContent[i].Substring(0, initialString.Length) == initialString)
                    {
                        selectedText = selectedText + splittedFileContent[i].Substring(initialString.Length);
                        linesNumer = linesNumer + initialString.Length;
                    }
                    else
                    {
                        selectedText = selectedText + splittedFileContent[i];
                    }
                }
            }

            pageTextBox.SelectedText = selectedText;
            pageTextBox.SelectionStart = previousSelectionStart;
            pageTextBox.SelectionLength = previousSelectionLength - linesNumer;

            RefreshUndoRedoExternal(form);
        }

        internal static void ConvertChar(Form1 form, String charToReplace, String newChar)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            pageTextBox.Select(0, pageTextBox.Text.Length);
            pageTextBox.SelectedText = pageTextBox.Text.Replace(charToReplace, newChar);
            RefreshUndoRedoExternal(form);
        }

        internal static void MoveSelectedLineUp(Form1 form, int linesNumberToMoveUp)
        {
            int maximum;
            if (!CouldMoveUp(form, out maximum))
            {
                return;
            }
            
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool lastLineHasReturn = StringUtil.SelectCurrentLines(pageTextBox);
            int initialLine = ReadRTBLineFromCharIndex(form, pageTextBox.SelectionStart);

            if (initialLine == 0)
            {
                return;
            }

            int finalLineFirstCharPosition = ReadRTBFirstCharIndexFromLine(form, initialLine - linesNumberToMoveUp);

            String textToPaste = pageTextBox.SelectedText;
            if (!lastLineHasReturn)
            {
                textToPaste += ConstantUtil.newLine;
                pageTextBox.SelectionStart -= ConstantUtil.newLine.Length;
                pageTextBox.SelectionLength++;
            }

            pageTextBox.Cut();
            pageTextBox.SelectionStart = finalLineFirstCharPosition;
            pageTextBox.SelectionLength = 0;
            pageTextBox.SelectedText = textToPaste;

            pageTextBox.SelectionStart = finalLineFirstCharPosition;
            pageTextBox.SelectionLength = textToPaste.Length;

            RefreshUndoRedoExternal(form);
        }

        internal static void MoveSelectedLineDown(Form1 form, int linesNumberToMoveDown)
        {
            int maximum;
            if (!CouldMoveDown(form, out maximum))
            {
                return;
            }
            
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            StringUtil.SelectCurrentLines(pageTextBox);
            int initialLineStart = ReadRTBLineFromCharIndex(form, pageTextBox.SelectionStart);
            int initialLineEnd = ReadRTBLineFromCharIndex(form, pageTextBox.SelectionStart + pageTextBox.SelectionLength) - 1;

            if (initialLineEnd == pageTextBox.Lines.Length - 1)
            {
                return;
            }

            int finalLine = initialLineStart + linesNumberToMoveDown;

            String textToPaste = pageTextBox.SelectedText;
            pageTextBox.Cut();

            if (pageTextBox.Lines.Length < finalLine + 1)
            {
                pageTextBox.AppendText(ConstantUtil.newLine);
                textToPaste = textToPaste.Substring(0, textToPaste.Length - 1);
            }
            pageTextBox.Select(ReadRTBFirstCharIndexFromLine(form, finalLine), 0);
            pageTextBox.SelectedText = textToPaste;

            pageTextBox.Select(ReadRTBFirstCharIndexFromLine(form, finalLine), textToPaste.Length);

            RefreshUndoRedoExternal(form);
        }

        internal static void InsertFinalString(Form1 form, String finalString)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool lastLineHasReturn = StringUtil.SelectCurrentLines(pageTextBox);
            int previousSelectionStart = pageTextBox.SelectionStart;

            String selectedText = pageTextBox.SelectedText;
            String[] separator = { ConstantUtil.newLine };
            String[] splittedFileContent = selectedText.Split(separator, StringSplitOptions.None);
            selectedText = String.Empty;

            for (int i = 0; i < splittedFileContent.Length; i++)
            {
                String row = splittedFileContent[i];

                if (lastLineHasReturn && i >= splittedFileContent.Length - 1)
                {
                    continue;
                }

                if (i < splittedFileContent.Length - 1)
                {
                    selectedText += row.Insert(row.Length, finalString);
                    selectedText += ConstantUtil.newLine;
                }
                else
                {
                    selectedText += row.Insert(row.Length, finalString);
                }
            }

            pageTextBox.SelectedText = selectedText;
            pageTextBox.SelectionStart = previousSelectionStart;
            pageTextBox.SelectionLength = selectedText.Length;

            RefreshUndoRedoExternal(form);
        }

        internal static void RemoveFinalString(Form1 form, String finalString)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool lastLineHasReturn = StringUtil.SelectCurrentLines(pageTextBox);
            int previousSelectionStart = pageTextBox.SelectionStart;

            String selectedText = pageTextBox.SelectedText;
            String[] separator = { ConstantUtil.newLine };
            String[] splittedFileContent = selectedText.Split(separator, StringSplitOptions.None);
            selectedText = String.Empty;

            for (int i = 0; i < splittedFileContent.Length; i++)
            {
                String row = splittedFileContent[i];

                if (String.IsNullOrEmpty(row) && i < splittedFileContent.Length - 1)
                {
                    selectedText += ConstantUtil.newLine;
                    continue;
                }
                if (row == null)
                {
                    continue;
                }
                if (lastLineHasReturn && i >= splittedFileContent.Length - 1)
                {
                    continue;
                }

                if (row.EndsWith(finalString))
                {
                    selectedText += row.Substring(0, row.Length - finalString.Length);
                }
                else
                {
                    selectedText += row;
                }

                if (lastLineHasReturn || i < splittedFileContent.Length - 1)
                {
                    selectedText += ConstantUtil.newLine;
                }
            }

            pageTextBox.SelectedText = selectedText;
            pageTextBox.SelectionStart = previousSelectionStart;
            pageTextBox.SelectionLength = selectedText.Length;

            RefreshUndoRedoExternal(form);
        }

        internal static bool CouldMoveUp(Form1 form, out int maximum)
        {
            SplitContainer verticalSplitContainer = (SplitContainer)form.Controls["verticalSplitContainer"];
            XtraTabControl pagesTabControl = (XtraTabControl)verticalSplitContainer.Panel1.Controls["pagesTabControl"];
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            maximum = ReadRTBLineFromCharIndex(form, pageTextBox.SelectionStart);

            return maximum > 0;
        }

        internal static bool CouldMoveDown(Form1 form, out int maximum)
        {
            SplitContainer verticalSplitContainer = (SplitContainer)form.Controls["verticalSplitContainer"];
            XtraTabControl pagesTabControl = (XtraTabControl)verticalSplitContainer.Panel1.Controls["pagesTabControl"];
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            int selectionLength = pageTextBox.SelectionLength;

            if (pageTextBox.SelectedText.EndsWith(ConstantUtil.newLine))
            {
                selectionLength -= 1;
            }

            maximum = Math.Abs(ReadRTBLineFromCharIndex(form, pageTextBox.SelectionStart + selectionLength) - (pageTextBox.Lines.Length - 1));

            return maximum > 0 && pageTextBox.Lines.Length != 0;
        }

        internal static void MoveToFirstSensibleChar(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (String.IsNullOrEmpty(pageTextBox.Text))
            {
                return;
            }
            if (pageTextBox.SelectionStart > 0 && pageTextBox.Text[pageTextBox.SelectionStart - 1].ToString() == ConstantUtil.newLine && pageTextBox.SelectionStart == pageTextBox.Text.Length)
            {
                return;
            }

            pageTextBox.SelectionLength = 0;
            pageTextBox.SelectionStart = GetFirstSensibleChar(form);
        }

        internal static void SelectTillFirstSensibleChar(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (String.IsNullOrEmpty(pageTextBox.Text))
            {
                return;
            }
            if (pageTextBox.SelectionStart > 0 && pageTextBox.Text[pageTextBox.SelectionStart - 1].ToString() == ConstantUtil.newLine && pageTextBox.SelectionStart == pageTextBox.Text.Length)
            {
                return;
            }

            int initialPosition = pageTextBox.SelectionStart + pageTextBox.SelectionLength;
            int startPosition = GetFirstSensibleChar(form);
            pageTextBox.Select(initialPosition, -(initialPosition - startPosition));
        }

        internal static void ShowHiddenChars(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String textWithHiddenChars = pageTextBox.Text.Replace(ConstantUtil.newLine, "¶" + Environment.NewLine);
            textWithHiddenChars = textWithHiddenChars.Replace("\t", "¬");
            textWithHiddenChars = textWithHiddenChars.Replace(" ", "·");

            WindowManager.ShowContent(form, textWithHiddenChars);
        }

        internal static void RowSort(Form1 form, bool allText, bool descSort)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (String.IsNullOrEmpty(pageTextBox.Text))
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("TextEmpty", className));
                return;
            }

            if (allText)
            {
                pageTextBox.SelectAll();
            }
            else
            {
                SelectCurrentLine(form);
            }

            String[] linesToOrder = pageTextBox.SelectedText.Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(linesToOrder);
            if (descSort)
            {
                Array.Reverse(linesToOrder);
            }

            String linesOrdered = linesToOrder.Aggregate(String.Empty, (current, line) => current + (line + ConstantUtil.newLine));
            //foreach(String line in linesToOrder)
            //{
            //    linesOrdered += line + ConstantUtil.newLine;
            //}

            int brCounter = 0;
            for (int i = pageTextBox.SelectedText.Length - 1; i > 0; i--)
            {
                if (pageTextBox.SelectedText[i].ToString() == ConstantUtil.newLine)
                {
                    brCounter++;
                }
                else
                {
                    break;
                }
            }
            switch (brCounter)
            {
                case 0:
                    linesOrdered = linesOrdered.Substring(0, linesOrdered.Length - 1);
                    break;
                case 1:
                    break;
                default:
                    for (int i = 1; i < brCounter; i++)
                    {
                        linesOrdered = linesOrdered + ConstantUtil.newLine;
                    }
                    break;
            }

            pageTextBox.SelectedText = linesOrdered;
            RefreshUndoRedoExternal(form);
        }

        #endregion RichTextBox Methods

        #region Private Methods

        private static void RefreshUndo(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            ToolStripMenuItem undoToolStripMenuItem = form.undoToolStripMenuItem;
            ToolStripSplitButton undoToolStripButton = form.undoToolStripButton;
            ToolStripMenuItem undoToolStripMenuItem1 = form.undoToolStripMenuItem1;
            
            if (!pageTextBox.CanUndo)
            {
                String undoEmpty = LanguageUtil.GetCurrentLanguageString("undoToolStripButton", form.Name);
                
                undoToolStripMenuItem.Enabled = false;
                undoToolStripButton.Enabled = false;
                undoToolStripMenuItem1.Enabled = false;
                undoToolStripMenuItem.Text = undoEmpty;
                undoToolStripButton.Text = undoEmpty;
                undoToolStripMenuItem1.Text = undoEmpty;
            }
            else
            {
                undoToolStripMenuItem.Enabled = true;
                undoToolStripButton.Enabled = true;
                undoToolStripMenuItem1.Enabled = true;

                String undo = LanguageUtil.GetCurrentLanguageString("Undo", className);
                String lastAction = LanguageUtil.GetCurrentLanguageString("LastAction", className);
                String unknownLabel = LanguageUtil.GetCurrentLanguageString("Unknown", className);
                
                if (!String.IsNullOrEmpty(pageTextBox.UndoActionName))
                {
                    String undoActionName = pageTextBox.UndoActionName;
                    if (!LanguageUtil.InitialCapsUp())
                    {
                        undoActionName = pageTextBox.UndoActionName.ToLower();
                    }

                    undoToolStripMenuItem.Text = undo + " " + undoActionName.Replace(unknownLabel, lastAction);
                    undoToolStripButton.Text = undo + " " + undoActionName.Replace(unknownLabel, lastAction);
                    undoToolStripMenuItem1.Text = undo + " " + undoActionName.Replace(unknownLabel, lastAction);
                }
                else
                {
                    undoToolStripMenuItem.Text = String.Format("{0} {1}", undo, lastAction);
                    undoToolStripButton.Text = String.Format("{0} {1}", undo, lastAction);
                    undoToolStripMenuItem1.Text = String.Format("{0} {1}", undo, lastAction);
                }
            }
        }

        private static void RefreshRedo(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            ToolStripMenuItem redoToolStripMenuItem = form.redoToolStripMenuItem;
            ToolStripSplitButton redoToolStripButton = form.redoToolStripButton;
            ToolStripMenuItem redoToolStripMenuItem1 = form.redoToolStripMenuItem1;
            
            if (!pageTextBox.CanRedo)
            {
                String redoEmpty = LanguageUtil.GetCurrentLanguageString("redoToolStripButton", form.Name);
                
                redoToolStripMenuItem.Enabled = false;
                redoToolStripButton.Enabled = false;
                redoToolStripMenuItem1.Enabled = false;
                redoToolStripMenuItem.Text = redoEmpty;
                redoToolStripButton.Text = redoEmpty;
                redoToolStripMenuItem1.Text = redoEmpty;
            }
            else
            {
                redoToolStripMenuItem.Enabled = true;
                redoToolStripButton.Enabled = true;
                redoToolStripMenuItem1.Enabled = true;

                String redo = LanguageUtil.GetCurrentLanguageString("Redo", className);
                String lastAction = LanguageUtil.GetCurrentLanguageString("LastAction", className);
                String unknownLabel = LanguageUtil.GetCurrentLanguageString("Unknown", className);

                if (!String.IsNullOrEmpty(pageTextBox.RedoActionName))
                {
                    String redoActionName = pageTextBox.RedoActionName;
                    if (!LanguageUtil.InitialCapsUp())
                    {
                        redoActionName = pageTextBox.RedoActionName.ToLower();
                    }

                    redoToolStripMenuItem.Text = redo + " " + redoActionName.Replace(unknownLabel, lastAction);
                    redoToolStripButton.Text = redo + " " + redoActionName.Replace(unknownLabel, lastAction);
                    redoToolStripMenuItem1.Text = redo + " " + redoActionName.Replace(unknownLabel, lastAction);
                }
                else
                {
                    redoToolStripMenuItem.Text = String.Format("{0} {1}", redo, lastAction);
                    redoToolStripButton.Text = String.Format("{0} {1}", redo, lastAction);
                    redoToolStripMenuItem1.Text = String.Format("{0} {1}", redo, lastAction);
                }
            }
        }

        private static bool TextBoxFactory(Form1 form, out TextBox textBox)
        {
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            TextBox nodeTitleTextBox = form.notePanel.noteTitleTextBox;
            TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;
            TextBox calculationTextBox = form.calculatorPanel.calculationTextBox;
            TextBox calcTextBox = form.calculatorPanel.calcTextBox;
            ToolStripTextBox prefixToolStripTextBox = form.prefixToolStripTextBox;
            ToolStripTextBox suffixToolStripTextBox = form.suffixToolStripTextBox;
            TextBox pathTextBox = form.filePanel.pathTextBox;

            textBox = null;
            
            if (searchTextBox.Focused)
            {
                textBox = searchTextBox;
            }
            else if (replaceTextBox.Focused)
            {
                textBox = replaceTextBox;
            }
            else if (nodeTitleTextBox.Focused)
            {
                textBox = nodeTitleTextBox;
            }
            else if (nodeTextTextBox.Focused)
            {
                textBox = nodeTextTextBox;
            }
            else if (calculationTextBox.Focused)
            {
                textBox = calculationTextBox;
            }
            else if (calcTextBox.Focused)
            {
                textBox = calcTextBox;
            }
            else if (prefixToolStripTextBox.Focused)
            {
                textBox = prefixToolStripTextBox.TextBox;
            }
            else if (suffixToolStripTextBox.Focused)
            {
                textBox = suffixToolStripTextBox.TextBox;
            }
            else if (pathTextBox.Focused)
            {
                textBox = pathTextBox;
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Pad text to left or right.
        /// </summary>
        /// <param name="form1">Form1 form instance.</param>
        /// <param name="form">PadText form instance.</param>
        /// <param name="width">Spaces number to insert.</param>
        /// <param name="character">Fill character.</param>
        /// <param name="directrion">Direction: 1 - left, 2 - right.</param>
        private static void PadTo(Form1 form1, PadText form, int width, char character, int directrion)
        {
            XtraTabControl pagesTabControl = form1.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            RadioButton allTextRadioButton = form.allTextRadioButton;
            CheckBox absoluteWidthCheckBox = form.absoluteWidthCheckBox;

            if (allTextRadioButton.Checked)
            {
                pageTextBox.SelectAll();
            }
            else
            {
                StringUtil.SelectCurrentLines(pageTextBox);
            }

            bool textEndsWithReturn = (pageTextBox.SelectedText.EndsWith(ConstantUtil.newLine));

            String[] separator = { ConstantUtil.newLine };
            String[] textLines = pageTextBox.SelectedText.Split(separator, StringSplitOptions.None);
            String[] newTextLines = new String[textLines.Length];

            if (!absoluteWidthCheckBox.Checked)
            {
                width += textLines[StringUtil.GetLongerStringInArray(textLines)].Length;
            }

            switch (directrion)
            {
                case 1:
                    for (int i = 0; i < textLines.Length; i++)
                    {
                        newTextLines[i] = textLines[i].PadRight(width, character);
                    }
                    break;
                case 2:
                    for (int i = 0; i < textLines.Length; i++)
                    {
                        newTextLines[i] = textLines[i].PadLeft(width, character);
                    }
                    break;
                default:
                    for (int i = 0; i < textLines.Length; i++)
                    {
                        newTextLines[i] = textLines[i].PadRight(width, character);
                    }
                    break;
            }

            String result = String.Empty;
            for (int i = 0; i < newTextLines.Length; i++)
            {
                if (i == newTextLines.Length - 1 && !textEndsWithReturn)
                {
                    result += newTextLines[i];
                }
                else
                {
                    result += newTextLines[i] + ConstantUtil.newLine;
                }
            }

            pageTextBox.SelectedText = result;
            pageTextBox.DeselectAll();

            RefreshUndoRedoExternal(form1);
        }

        private static int GetFirstSensibleChar(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            int startPosition = pageTextBox.GetFirstCharIndexOfCurrentLine();
            int newPosition = startPosition;

            while (pageTextBox.Text[newPosition] == ' ' || pageTextBox.Text[newPosition] == '\t')
            {
                newPosition++;

                if (newPosition >= pageTextBox.Text.Length)
                {
                    break;
                }
            }

            return newPosition != pageTextBox.SelectionStart ? newPosition : startPosition;
        }

        #endregion Private Methods
    }
}
