using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Open web page source DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class UrlEntry : Form
    {
        private bool favouriteMode;

        #region Window Methods

        internal void InitializeForm(bool addFavourite)
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            FileListManager.LoadRecentURLs(this);
            favouriteMode = addFavourite;

            if (favouriteMode)
            {
                HelpButton = false;
                Text = LanguageUtil.GetCurrentLanguageString("Title_FavouriteMode", Name);
            }
        }

        private void UrlEntry_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void urlAddressComboBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !(String.IsNullOrEmpty(urlAddressComboBox.Text) || urlAddressComboBox.Text == "http://");
        }

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = ControlUtil.FocusedTextBoxCanUndo(sender);
        }

        #endregion Window Methods

        #region Button Methods

        private void clearHistoryButton_Click(object sender, EventArgs e)
        {
            FileListManager.ClearRecentURLs(this);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!urlAddressComboBox.Text.StartsWith("http://"))
            {
                urlAddressComboBox.Text = String.Format("http://{0}", urlAddressComboBox.Text);
            }

            if (favouriteMode)
            {
                Favourites form = (Favourites)Owner;
                Form1 form1 = (Form1)form.Owner;

                ListBox favouritesListBox = form.favouritesListBox;
                FileListManager.SetNewFavouriteFile(form1, ConstantUtil.urlPrefix + urlAddressComboBox.Text);

                favouritesListBox.Items.Clear();
                form.InitializeForm(true);
                favouritesListBox.SelectedIndex = favouritesListBox.Items.Count - 1;

                WindowManager.CloseForm(this);
            }
            else
            {
                Form1 form = (Form1)Owner;

                okButton.Enabled = false;
                cancelButton.Enabled = false;
                Refresh();

                if (InternetManager.OpenUrlSource(form, urlAddressComboBox.Text))
                {
                    FileListManager.SetNewRecentURL(this, urlAddressComboBox.Text);
                    WindowManager.CloseForm(this);
                }
                else
                {
                    okButton.Enabled = true;
                    cancelButton.Enabled = true;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            urlEntryToolTip.SetToolTip(clearHistoryButton, LanguageUtil.GetCurrentLanguageString("clearHistoryButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
