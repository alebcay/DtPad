using System;
using System.Windows.Forms;
using DtPadUpdater.Managers;
using DtPadUpdater.Utils;

namespace DtPadUpdater
{
    /// <summary>
    /// Main DtPadUpdater form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Form1 : Form
    {
        private readonly String executablePath = String.Empty;
        private String internalCulture;
        
        internal Form1(String path)
        {
            InitializeComponent();
            executablePath = path;
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip, executablePath);
            SetLanguage();

            SetFamilyEdition();
        }

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
                        if (UpdateManager.UpdateProcess(this, executablePath, updateTextBox, updateProgressBar, internalCulture))
                        {
                            startButton.Text = LanguageUtil.GetCurrentLanguageString("Start", Name, internalCulture);
                            startButton.Enabled = true;
                        }
                        else
                        {
                            startButton.Visible = false;
                        }

                        updateTextBox.Select(updateTextBox.Text.Length - 1, 0);
                        updateTextBox.ScrollToCaret();
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
