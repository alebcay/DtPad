using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Show and manage extraction of archive files content.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class ZipExtract : StringForm
    {
        private String privateFileNameAndPath;
        private bool isPasswordProtected;
        
        #region Window Methods

        internal void InitializeForm(String fileNameAndPath)
        {
            privateFileNameAndPath = fileNameAndPath;
            
            InitializeComponent();
            filenameLabel.Text = StringUtil.CheckStringLength(privateFileNameAndPath, 63);
            ZipManager.ReadZipContent(this, privateFileNameAndPath, out isPasswordProtected);
            SetLanguage();
        }

        private void ZipExtract_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            zipContentDataGridView.SelectAll();
        }

        private void copyArchiveContentPictureBox_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(ZipManager.GetZipContentListString(privateFileNameAndPath), true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
        }

        private void extractSelectedFilesButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            ZipManager.ExtractZipContent(form, this, privateFileNameAndPath, isPasswordProtected);
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
            zipExtractToolTip.SetToolTip(copyArchiveContentPictureBox, LanguageUtil.GetCurrentLanguageString("copyArchiveContentPictureBoxToolTip", Name));
        }

        #endregion Private Methods
    }
}
