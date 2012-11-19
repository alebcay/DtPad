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
            ControlUtil.SetContextMenuStrip(this, new[] { wordTextBox, contentTextBox });

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
            OtherManager.StartProcessBrowser(this, ConstantUtil.dtPadURL + "wikipage?title=Dictionaries");
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
            WindowManager.CloseForm(this);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            contentTextBox.Text = String.Empty;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            //LanguageUtil.CicleControls(Name, contentContextMenuStrip.Items);
            //LanguageUtil.CicleControls(Name, contextMenuStrip1.Items);
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
                languageComboBox.Properties.Items.Remove(languageComboBox.Properties.Items.GetItem("Français"));
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
                WindowManager.ShowInfoBox(this, LanguageUtil.GetCurrentLanguageString("NoDictionaries", Name) + ConstantUtil.dtPadURL + "wikipage?title=Dictionaries");
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
