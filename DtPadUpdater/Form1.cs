using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using DtPadUpdater.Managers;
using DtPadUpdater.Utils;

namespace DtPadUpdater
{
    /// <summary>
    /// Main DtPadUpdater form.
    /// </summary>
    /// <author>Marco Macciò</author>
    /// <remarks>
    /// 0) Intro
    /// 1) Info
    /// 2) Update
    /// </remarks>
    internal partial class Form1 : Form
    {
        private Thread newThread;
        private bool updaterClosed;
        private String changeLog;
        private delegate void ThreadCallBack();

        private readonly String executablePath = String.Empty;
        private String internalCulture;
        private bool isUserAdmin;

        internal Form1(String path)
        {
            InitializeComponent();
            executablePath = path;
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip, executablePath);
            SetLanguage();

            SetFamilyEdition();
        }

        #region Window Methods

        private void updateTextBox_TextChanged(object sender, EventArgs e)
        {
            updateTextBox.Select(updateTextBox.Text.Length, 0);
            updateTextBox.ScrollToCaret();
        }

        private void logoPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.X < 20 && e.Y < 20)
            {
                isUserAdmin = true;
                adminModeLabel.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (newThread != null && newThread.IsAlive)
            {
                updaterClosed = true;
                //newThread.Abort();
            }
        }

        #endregion Window Methods

        #region Button Methods

        private void linkLabel_MouseClick(object sender, MouseEventArgs e)
        {
            OtherManager.StartProcessBrowser(this, ConstantUtil.dtPadURL, executablePath, internalCulture);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (introPanel.Visible)
                {
                    introPanel.Visible = false;
                    infoPanel.Visible = true;
                    startButton.Text = LanguageUtil.GetCurrentLanguageString("StartUpdate", Name, internalCulture);
                    Refresh();

                    newThread = new Thread(CheckChangeLog);
                    newThread.IsBackground = true;
                    newThread.Start();
                }
                else if (infoPanel.Visible)
                {
                    infoPanel.Visible = false;
                    updatePanel.Visible = true;
                    startButton.Enabled = false;
                    startButton.Text = LanguageUtil.GetCurrentLanguageString("Updating", Name, internalCulture);
                    cancelButton.Enabled = false;
                    Refresh();

                    if (!UpdateManager.IsUpdaterVersionUpdated(executablePath, updateTextBox, internalCulture))
                    {
                        startButton.Visible = false;
                    }
                    else
                    {
                        String fromVersion;
                        String toVersion;

                        if (UpdateManager.UpdateProcess(this, executablePath, updateTextBox, updateProgressBar, internalCulture, out fromVersion, out toVersion))
                        {
                            UpdateManager.CommitUpdate(isUserAdmin, "ok", fromVersion, toVersion, executablePath, internalCulture);

                            startButton.Text = LanguageUtil.GetCurrentLanguageString("Start", Name, internalCulture);
                            startButton.Enabled = true;
                        }
                        else
                        {
                            UpdateManager.CommitUpdate(isUserAdmin, "ko", fromVersion, toVersion, executablePath, internalCulture);

                            startButton.Visible = false;
                        }
                    }

                    cancelButton.Text = LanguageUtil.GetCurrentLanguageString("Close", Name, internalCulture);
                    cancelButton.Enabled = true;
                }
                else
                {
                    OtherManager.StartProcess(this, "DtPad.exe", internalCulture);
                    Application.Exit();
                }
            }
            catch (Exception exception)
            {
                startButton.Visible = false;
                cancelButton.Text = LanguageUtil.GetCurrentLanguageString("Close", Name, internalCulture);
                cancelButton.Enabled = true;

                WindowManager.ShowErrorBox(this, exception.Message, exception, internalCulture);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(updateTextBox);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(updateTextBox);
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private void CheckChangeLog()
        {
            WebException exception;
            changeLog = UpdateManager.CheckChangeLog(executablePath, internalCulture, out exception);

            if (String.IsNullOrEmpty(changeLog) || exception != null)
            {
                Invoke(new ThreadCallBack(ShowError));
            }

            if (!updaterClosed)
            {
                Invoke(new ThreadCallBack(ShowChangeLog));
            }
        }

        private void ShowError()
        {
            whatIsInsideTextBox.Text = LanguageUtil.GetCurrentLanguageString("ErrorLoadingChangeLog", Name, internalCulture);
            progressBar.Visible = false;
            Refresh();
        }

        private void ShowChangeLog()
        {
            whatIsInsideTextBox.Text = changeLog;
            progressBar.Visible = false;
            Refresh();
        }

        private void SetLanguage()
        {
            internalCulture = LanguageUtil.GetReallyShortCulture(ConfigUtil.GetStringParameter("Language", "English", executablePath));
            LanguageUtil.SetCurrentLanguage(this, internalCulture);
        }

        private void SetFamilyEdition()
        {
            #if ReleaseFE
                homePictureBox.Visible = false;
                linkLabel.Visible = false;
                descriptionLabel.Text = LanguageUtil.GetCurrentLanguageString("descriptionLabel_FE", Name, internalCulture);
            #endif
        }

        #endregion Private Methods
    }
}
