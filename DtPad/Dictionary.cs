using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    public partial class Dictionary : Form
    {
        private bool existsDictionaries = true;

        #region Window Methods

        internal void InitializeForm(String word)
        {
            InitializeComponent();
            SetLanguage();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            LookFeelUtil.SetLookAndFeel(contextMenuStrip1);
            contentTextBox.Font = ConfigUtil.GetFontParameter("FontInUse");

            //languageComboBox.EditValue = ConfigUtil.GetStringParameter("Language");
            CheckDictionaries();

            if (String.IsNullOrEmpty(word) || !existsDictionaries)
            {
                searchButton.Enabled = false;
                return;
            }

            wordTextBox.Text = word;
            wordTextBox.Select(0, 0);
            DictionaryManager.CheckWordCorrectness(wordTextBox, LanguageUtil.GetReallyShortCultureForGoogleTranslator(languageComboBox.SelectedItem.ToString()), contentTextBox);
        }

        private void wordTextBox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = (existsDictionaries && !String.IsNullOrEmpty(wordTextBox.Text));
            wordTextBox.BackColor = Color.White;
        }

        private void dictionariesLabel_MouseClick(object sender, MouseEventArgs e)
        {
            OtherManager.StartProcessBrowser(this, ConstantUtil.dtPadURL + "#dizionari");
        }

        private void contentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                contentTextBox.SelectAll();
            }
        }

        private void contentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(contentTextBox.Text))
            {
                return;
            }
            contentTextBox.Select(contentTextBox.Text.Length - 1, 0);
            contentTextBox.ScrollToCaret();
        }

        private void Dictionary_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = wordTextBox.CanUndo;
        }

        #endregion Window Methods

        #region Button Methods

        private void searchButton_Click(object sender, EventArgs e)
        {
            wordTextBox.Select(0, 0);
            DictionaryManager.CheckWordCorrectness(wordTextBox, LanguageUtil.GetReallyShortCultureForGoogleTranslator(languageComboBox.SelectedItem.ToString()), contentTextBox);
        }

        private void verifyAllButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            DictionaryManager.CheckTextCorrectness(form, LanguageUtil.GetReallyShortCultureForGoogleTranslator(languageComboBox.SelectedItem.ToString()));
            WindowManager.HiddenForm(this);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            contentTextBox.Text = String.Empty;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, contentContextMenuStrip.Items);
            LanguageUtil.CicleControls(Name, contextMenuStrip1.Items);
        }

        private void CheckDictionaries()
        {
            if (!DictionaryManager.ExistsDictionary("de"))
            {
                languageComboBox.Properties.Items.Remove(languageComboBox.Properties.Items.GetItem("Deutsch"));
            }
            if (!DictionaryManager.ExistsDictionary("es"))
            {
                languageComboBox.Properties.Items.Remove(languageComboBox.Properties.Items.GetItem("Español"));
            }
            if (!DictionaryManager.ExistsDictionary("fr"))
            {
                languageComboBox.Properties.Items.Remove(languageComboBox.Properties.Items.GetItem("Française"));
            }
            if (!DictionaryManager.ExistsDictionary("it"))
            {
                languageComboBox.Properties.Items.Remove(languageComboBox.Properties.Items.GetItem("Italiano"));
            }
            if (!DictionaryManager.ExistsDictionary("en"))
            {
                languageComboBox.Properties.Items.Remove(languageComboBox.Properties.Items.GetItem("English"));
            }

            if (languageComboBox.Properties.Items.Count == 0)
            {
                existsDictionaries = false;
                WindowManager.ShowInfoBox(this, LanguageUtil.GetCurrentLanguageString("NoDictionaries", Name) + ConstantUtil.dtPadURL + "#dizionari");
                return;
            }

            languageComboBox.EditValue = ConfigUtil.GetStringParameter("Language");
            if (languageComboBox.SelectedItem == null)
            {
                languageComboBox.EditValue = languageComboBox.Properties.Items[0];
            }
        }

        #endregion Private Methods
    }
}
