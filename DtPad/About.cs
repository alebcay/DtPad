using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// About DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class About : Form
    {
        private Thread newThread;
        private bool aboutClosed;
        private delegate void ThreadCallBack();
        
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            versionLabel.Text = String.Format("{0} - build {1}", AssemblyUtil.AssemblyVersion, AssemblyUtil.AssemblyConfiguration);

            SetFamilyEdition();
            closeButton.Focus();
            Refresh();

            newThread = new Thread(CheckVersion);
            newThread.IsBackground = true;
            newThread.Start();
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (newThread != null && newThread.IsAlive)
            {
                aboutClosed = true;
                //newThread.Abort();
            }
        }

        #endregion Window Methods

        #region Buttons Methods

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void emailPictureBox_Click(object sender, EventArgs e)
        {
            OtherManager.StartProcess(this, String.Format("mailto:{0}", ConstantUtil.myEmail));
        }

        private void websitePictureBox_Click(object sender, EventArgs e)
        {
            OtherManager.StartProcessBrowser(this, ConstantUtil.dtPadURL);
        }

        private void rssPictureBox_Click(object sender, EventArgs e)
        {
            OtherManager.StartProcessBrowser(this, ConstantUtil.dtFeedURL);
        }

        private void versionCheckLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = (Form1)Owner;

            Hide();
            Application.DoEvents();
            WindowManager.ShowVersionCheck(form);
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

        private void CheckVersion()
        {
            WebException exception;
            bool isDtPadUpdated = VersionCheckManager.IsDtPadUpdated(out exception);

            if (isDtPadUpdated || exception != null)
            {
                return;
            }

            if (!aboutClosed)
            {
                Invoke(new ThreadCallBack(ShowMessage));
            }
        }

        private void ShowMessage()
        {
            versionCheckPictureBox.Visible = true;
            versionCheckLinkLabel.Visible = true;
            Refresh();
        }

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            aboutToolTip.SetToolTip(emailPictureBox, LanguageUtil.GetCurrentLanguageString("emailPictureBoxToolTip", Name));
            aboutToolTip.SetToolTip(websitePictureBox, LanguageUtil.GetCurrentLanguageString("websitePictureBoxToolTip", Name));
            aboutToolTip.SetToolTip(rssPictureBox, LanguageUtil.GetCurrentLanguageString("rssPictureBoxToolTip", Name));
        }

        private void SetFamilyEdition()
        {
            #if ReleaseFE
                titleLabel.Text = LanguageUtil.GetCurrentLanguageString("titleLabel_FE", Name);
                websiteLabel1.Text = LanguageUtil.GetCurrentLanguageString("websiteLabel1_FE", Name);
                websiteLabel.Text = LanguageUtil.GetCurrentLanguageString("websiteLabel_FE", Name);
                createdByLabel.Text = LanguageUtil.GetCurrentLanguageString("createdByLabel_FE", Name);

                websitePictureBox.Visible = false;
                rssPictureBox.Visible = false;
                emailPictureBox.Visible = false;
            #endif
        }

        #endregion Private Methods
    }
}
