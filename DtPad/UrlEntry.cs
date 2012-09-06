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
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();

            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();
            FileListManager.LoadRecentURLs(this);
        }

        private void UrlEntry_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void urlAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !(String.IsNullOrEmpty(urlAddressTextBox.Text) || urlAddressTextBox.Text == "http://");
        }

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = urlAddressTextBox.CanUndo;
        }

        #endregion Window Methods

        #region Button Methods

        private void clearHistoryButton_Click(object sender, EventArgs e)
        {
            FileListManager.ClearRecentURLs(this);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            if (!urlAddressTextBox.Text.StartsWith("http://"))
            {
                urlAddressTextBox.Text = String.Format("http://{0}", urlAddressTextBox.Text);
            }

            okButton.Enabled = false;
            cancelButton.Enabled = false;
            Refresh();

            if (InternetManager.OpenUrlSource(form, urlAddressTextBox.Text))
            {
                FileListManager.SetNewRecentURL(this, urlAddressTextBox.Text);
                WindowManager.CloseForm(this);
            }
            else
            {
                okButton.Enabled = true;
                cancelButton.Enabled = true;
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
