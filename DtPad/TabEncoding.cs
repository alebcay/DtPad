using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Tab encoding change DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class TabEncoding : Form
    {
        #region Windows Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);

            Form1 form = (Form1)Owner;
            XtraTabControl pagesTabControl = form.pagesTabControl;

            Encoding encoding = TabUtil.GetTabTextEncoding(pagesTabControl.SelectedTabPage);
            changeIntoComboBox.SelectedIndex = EncodingUtil.GetEncodingIndexFromType(encoding);
        }

        private void TabEncoding_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Windows Methods

        #region Button Methods

        private void saveButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            String encodingCodePage = EncodingUtil.GetEncodingCodePageFromIndex(changeIntoComboBox.SelectedIndex);

            pageTextBox.CustomEncoding = encodingCodePage;
            pageTextBox.CustomEncodingForced = true;
            
            FileManager.SaveFile(form, false);
            WindowManager.HiddenForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Button Methods
    }
}
