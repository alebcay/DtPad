using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Version check to update DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class VersionCheck : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            SetLanguage();
            StartUpdate();
        }

        private void warningPictureBox_MouseLeave(object sender, EventArgs e)
        {
            warningToolTip.Active = false;
            warningToolTip.Active = true;
        }

        #endregion Window Methods

        #region Button Methods

        private void updateButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;
            
            String errorMessage;
            statusLabel.Text = LanguageUtil.GetCurrentLanguageString("statusLabelUpdater", Name); //"Checking for new updater..."
            Refresh();
            
            if (!VersionCheckManager.UpdaterCheck(out errorMessage))
            {
                warningPictureBox.Visible = true;
                statusLabel.Text = errorMessage;
                return;
            }

            statusLabel.Text = LanguageUtil.GetCurrentLanguageString("statusLabelClosing", Name); //"Closing open tabs..."
            Refresh();

            TabManager.CloseAllPages(form);
            ProcessStartInfo processInfo = new ProcessStartInfo("DtPadUpdater.exe", "-nocheck");
            OtherManager.StartProcessInfo(this, processInfo);
            Application.Exit();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void StartUpdate()
        {
            Owner.Refresh();

            warningPictureBox.Visible = false;

            checkProgressBar.EditValue = 0;
            updateButton.Enabled = false;
            statusLabel.Text = LanguageUtil.GetCurrentLanguageString("statusLabelConnection", Name); //"Establishing connection..."
            Refresh();

            String actualVersion = AssemblyUtil.AssemblyVersion;

            checkProgressBar.PerformStep();

			WebClient webClient = null;
            String finalVersion;

            checkProgressBar.PerformStep();

            try
            {
                webClient = ProxyUtil.InitWebClientProxy();
                statusLabel.Text = LanguageUtil.GetCurrentLanguageString("statusLabelDownload", Name); //"Downloading last version informations..."
                Refresh();

				String repository = ConstantUtil.repository;
                #if ReleaseFE
                    repository = ConstantUtil.repositoryFE;
                #endif

                finalVersion = webClient.DownloadString(String.Format("{0}dtpad-lastversion.log", repository));
            }
            catch (WebException)
            {
                checkProgressBar.EditValue = 0;
                statusLabel.Text = LanguageUtil.GetCurrentLanguageString("statusLabelError", Name); //"Connection error."
                warningPictureBox.Visible = true;
                updateButton.Enabled = false;
                return;
            }
            finally
            {
                if (webClient != null)
                {
                    webClient.Dispose();
                }
            }

            checkProgressBar.PerformStep();


            if (actualVersion == finalVersion)
            {
                statusLabel.Text = LanguageUtil.GetCurrentLanguageString("statusLabelOk", Name); //"Your DtPad version is up to date!"
            }
            else
            {
                statusLabel.Text = LanguageUtil.GetCurrentLanguageString("statusLabelOld", Name); //"Your DtPad version is to update!"
                newVersionPictureBox.Visible = true;
                updateButton.Enabled = true;
            }

            checkProgressBar.PerformStep();
        }

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            warningToolTip.SetToolTip(warningPictureBox, LanguageUtil.GetCurrentLanguageString("warningPictureBoxToolTip", Name));
        }

        #endregion Private Methods
    }
}
