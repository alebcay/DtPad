using System;
using System.Windows.Forms;
using DtHelp.Utils;
using DtHelp.Managers;

namespace DtHelp
{
    /// <summary>
    /// About DtHelp form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class About : Form
    {
        private String cultureInternal;
        
        #region Window Methods

        internal void InitializeForm(String culture)
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel((Form1)Owner, contentContextMenuStrip);
            cultureInternal = culture;
            SetLanguage();
            
            versionLabel.Text = String.Format("{0} - build {1}", AssemblyUtil.AssemblyVersion, AssemblyUtil.AssemblyConfiguration);
            closeButton.Focus();

            SetFamilyEdition();
        }

        #endregion Window Methods

        #region Buttons Methods

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        private void emailPictureBox_Click(object sender, EventArgs e)
        {
            OtherManager.StartProcess(this, String.Format("mailto:{0}", ConstantUtil.myEmail), cultureInternal);
        }

        private void websitePictureBox_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"];

            helpWebBrowser.Url = new Uri("http://www.diariotraduttore.com/");
        }

        private void rssPictureBox_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"];

            helpWebBrowser.Url = new Uri(ConstantUtil.dtFeedURL);
        }

        #endregion Buttons Methods

        #region ContextMenu Methods

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(descriptionTextBox);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(descriptionTextBox);
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this, cultureInternal);
            aboutToolTip.SetToolTip(emailPictureBox, LanguageUtil.GetCurrentLanguageString("emailPictureBoxToolTip", Name, cultureInternal));
            aboutToolTip.SetToolTip(websitePictureBox, LanguageUtil.GetCurrentLanguageString("websitePictureBoxToolTip", Name, cultureInternal));
            aboutToolTip.SetToolTip(rssPictureBox, LanguageUtil.GetCurrentLanguageString("rssPictureBoxToolTip", Name, cultureInternal));
        }

        private void SetFamilyEdition()
        {
            #if ReleaseFE
                titleLabel.Text = LanguageUtil.GetCurrentLanguageString("titleLabel_FE", Name, cultureInternal);
                createdByLabel.Text = LanguageUtil.GetCurrentLanguageString("createdByLabel_FE", Name, cultureInternal);
                websiteLabel1.Text = LanguageUtil.GetCurrentLanguageString("websiteLabel1_FE", Name, cultureInternal);
                websiteLabel.Text = LanguageUtil.GetCurrentLanguageString("websiteLabel_FE", Name, cultureInternal);

                emailPictureBox.Visible = false;
                websitePictureBox.Visible = false;
                rssPictureBox.Visible = false;
            #endif
        }

        #endregion Private Methods
    }
}
