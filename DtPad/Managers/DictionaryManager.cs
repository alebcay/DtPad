using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DtPad.Customs;
using DtPad.Utils;
using NHunspell;

namespace DtPad.Managers
{
    /// <summary>
    /// Dictionary and thesaurus manager.
    /// </summary>
    /// <author>Marco Macciò, external source</author>
    internal static class DictionaryManager
    {
        private const String className = "DictionaryManager";

        #region Internal Methods

        internal static void OpenDictionaryWindow(Form1 form, CustomXtraTabControl pagesTabControl)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (!pageTextBox.SelectedText.TrimStart().TrimEnd().Contains(" "))
            {
                WindowManager.ShowDictionary(form, pageTextBox.SelectedText);
            }
            else
            {
                WindowManager.ShowDictionary(form);
            }
        }

        internal static void CheckWordCorrectness(TextBox wordTextBox, String languageSign, TextBox contentTextBox)
        {
            String word = wordTextBox.Text.Trim();

            if (String.IsNullOrEmpty(word))
            {
                return;
            }

            if (!String.IsNullOrEmpty(contentTextBox.Text))
            {
                contentTextBox.Text += "----------------------------" + Environment.NewLine;
            }
            contentTextBox.Text += "[" + DateTime.Now.ToLongTimeString() + "] ";

            using (Hunspell hunspell = new Hunspell(ConstantUtil.ApplicationExecutionPath() + "\\Languages\\" + languageSign + ".aff", ConstantUtil.ApplicationExecutionPath() + "\\Languages\\" + languageSign + ".dic"))
            {
                bool correct = hunspell.Spell(word);
                String correctness;

                if (correct)
                {
                    wordTextBox.BackColor = Color.LightGreen;
                    correctness = LanguageUtil.GetCurrentLanguageString("Correct", className);
                }
                else
                {
                    wordTextBox.BackColor = Color.Tomato;
                    correctness = LanguageUtil.GetCurrentLanguageString("Uncorrect", className);
                }
                contentTextBox.Text += String.Format(LanguageUtil.GetCurrentLanguageString("Word", className), word, correctness) + Environment.NewLine;

                //Uncorrect word, search suggestions
                if (!correct)
                {
                    List<String> suggestions = hunspell.Suggest(word);
                    contentTextBox.Text += String.Format(LanguageUtil.GetCurrentLanguageString("Tips", className, suggestions.Count), suggestions.Count) + Environment.NewLine;

                    foreach (String suggestion in suggestions)
                    {
                        contentTextBox.Text += String.Format(LanguageUtil.GetCurrentLanguageString("Tip", className), suggestion) + Environment.NewLine;
                    }

                    return;
                }

                //Correct word, search meanings and synonyms
                MyThes thes = new MyThes(ConstantUtil.ApplicationExecutionPath() + "\\Languages\\" + languageSign + "_th.dat");
                ThesResult tr = thes.Lookup(word, hunspell);

                if ((tr == null) || (tr.IsGenerated))
                {
                    return;
                }

                foreach (ThesMeaning meaning in tr.Meanings)
                {
                    contentTextBox.Text += String.Format(LanguageUtil.GetCurrentLanguageString("Meaning", className), meaning.Description) + Environment.NewLine;

                    foreach (String synonym in meaning.Synonyms)
                    {
                        contentTextBox.Text += String.Format(LanguageUtil.GetCurrentLanguageString("Synonym", className), synonym) + Environment.NewLine;
                    }
                }
            }
        }

        internal static bool ExistsDictionary(String languageSign)
        {
            return (File.Exists(Path.Combine(ConstantUtil.ApplicationExecutionPath(), "Languages\\" + languageSign + ".aff")) &&
                File.Exists(Path.Combine(ConstantUtil.ApplicationExecutionPath(), "Languages\\" + languageSign + ".dic"))) &&
                File.Exists(Path.Combine(ConstantUtil.ApplicationExecutionPath(), "Languages\\" + languageSign + "_th.dat"));
        }

        internal static void CheckTextCorrectness(Form1 form, String languageSign)
        {
            if (!ExistsDictionary(languageSign))
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoDictionary", className) + ConstantUtil.dtPadURL + "wikipage?title=Dictionaries");
                return;
            }

            CustomXtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (RichTextBoxUtil.ContainsUnderlineText(pageTextBox))
            {
                ClearTextCorrectness(pageTextBox);
            }

            bool textCorrectness = true;
            RichTextBox tempRichTextBox = new RichTextBox { BackColor = pageTextBox.BackColor }; //Temporary RichTextBox to avoid too much undo/redo into buffer
            pageTextBox.SuspendPainting();
            tempRichTextBox.Rtf = pageTextBox.Rtf;

            //Method 1: char parse (more accurate, slower)
            using (Hunspell hunspell = new Hunspell(ConstantUtil.ApplicationExecutionPath() + "\\Languages\\" + languageSign + ".aff", ConstantUtil.ApplicationExecutionPath() + "\\Languages\\" + languageSign + ".dic"))
            {
                int wordStart = 0;
                StringBuilder word = new StringBuilder(String.Empty);
                StringBuilder text = new StringBuilder(pageTextBox.Text);

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '\'' || (!Char.IsWhiteSpace(text[i]) && !Char.IsPunctuation(text[i]) && !Char.IsSymbol(text[i]) && !Char.IsSeparator(text[i])))
                    {
                        word.Append(text[i]);

                        if (i < text.Length - 1)
                        {
                            continue;
                        }
                    }

                    if (!hunspell.Spell(word.ToString()) && !String.IsNullOrEmpty(word.ToString().Trim()))
                    {
                        tempRichTextBox.Select(wordStart, word.Length);
                        tempRichTextBox.SelectionFont = new Font(pageTextBox.Font, FontStyle.Underline);
                        tempRichTextBox.SelectionColor = (pageTextBox.BackColor == Color.Red) ? Color.Yellow : Color.Red;
                        textCorrectness = false;
                    }

                    word = new StringBuilder(String.Empty);
                    wordStart = i + 1;
                }
            }

            //Method 2: word parse (less accurate, faster)
            //String[] wordsList = pageTextBox.Text.Split(new[] { ' ', Convert.ToChar(ConstantUtil.newLine), '\t', '/', '\\', '.', '?', ';', ',', ':', '(', ')', '[', ']', '{', '}', '\\', '|', '/', '!', '"', '\'', '=' }, StringSplitOptions.RemoveEmptyEntries);
            //List<String> wordsAlreadySeen = new List<String>();

            //using (Hunspell hunspell = new Hunspell(ConstantUtil.ApplicationExecutionPath() + "\\Languages\\" + languageSign + ".aff", ConstantUtil.ApplicationExecutionPath() + "\\Languages\\" + languageSign + ".dic"))
            //{
            //    foreach (String word in wordsList)
            //    {
            //        if (wordsAlreadySeen.Contains(word))
            //        {
            //            continue;
            //        }
            //        wordsAlreadySeen.Add(word);

            //        if (hunspell.Spell(word))
            //        {
            //            continue;
            //        }

            //        int i = 0;
            //        while (i != -1 && (i = pageTextBox.Text.IndexOf(word, i)) != -1)
            //        {
            //            tempRichTextBox.Select(i, word.Length);
            //            tempRichTextBox.SelectionFont = new Font(pageTextBox.Font, FontStyle.Underline);
            //            tempRichTextBox.SelectionColor = (pageTextBox.BackColor == Color.Red) ? Color.Yellow : Color.Red;

            //            i += word.Length;
            //        }
            //    }
            //}

            pageTextBox.IsUnderlining = true;
            RichTextBoxUtil.ReplaceRTFContent(pageTextBox, tempRichTextBox);

            pageTextBox.ResumePainting();
            tempRichTextBox.Dispose();
            TextManager.RefreshUndoRedoExternal(form);

            if (textCorrectness)
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("TextCorrect", className));
            }
        }

        internal static void ClearTextCorrectness(CustomRichTextBox pageTextBox)
        {
            RichTextBox tempRichTextBox = new RichTextBox(); //Temporary RichTextBox to avoid too much undo/redo into buffer

            pageTextBox.SuspendPainting();

            tempRichTextBox.Rtf = pageTextBox.Rtf;
            tempRichTextBox.SelectAll();
            tempRichTextBox.Font = new Font(pageTextBox.Font, FontStyle.Regular);
            tempRichTextBox.SelectionBackColor = tempRichTextBox.BackColor;

            RichTextBoxUtil.ReplaceRTFContent(pageTextBox, tempRichTextBox);
            pageTextBox.ResumePainting();

            tempRichTextBox.Dispose();
        }

        #endregion Internal Methods
    }
}
