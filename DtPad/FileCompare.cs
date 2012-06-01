using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Compare tabs inside DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class FileCompare : Form
    {
        private String[] itemValues;

        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);

            Form1 form = (Form1)Owner;

            itemValues = new String[form.pagesTabControl.TabPages.Count];

            for (int i = 0; i < form.pagesTabControl.TabPages.Count; i++)
            {
                XtraTabPage tabPage = form.pagesTabControl.TabPages[i];
                tabPagesListBox.Items.Add(String.Format("{0} - {1}", i + 1, tabPage.Text));
                itemValues[i] = tabPage.Name;
            }
        }

        private void tabPagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            compareButton.Enabled = tabPagesListBox.SelectedItems.Count == 2;
        }

        private void FileCompare_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void compareButton_Click(object sender, EventArgs e)
        {
            TabManager.CompareTabText(this, itemValues);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Button Methods
    }
}
