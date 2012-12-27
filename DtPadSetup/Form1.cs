using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using DtPadSetup.Managers;
using DtPadSetup.Utils;

namespace DtPadSetup
{
    /// <summary>
    /// Main DtPadSetup form.
    /// </summary>
    /// <author>Marco Macciò</author>
    /// <remarks>
    /// 0) Intro
    /// 1) Language
    /// 2) Look & Feel
    /// 3) Window
    /// 4) Internet
    /// 5) Install
    /// 6) End
    /// </remarks>
    internal partial class Form1 : Form
    {
        internal Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        #region Windows Methods

        private void InitializeForm()
        {
            switch (LanguageUtil.GetReallyShortCulture(CultureInfo.CurrentCulture.Name))
            {
                case "en":
                    languageComboBox.SelectedIndex = 0;
                    break;
                case "it":
                    languageComboBox.SelectedIndex = 1;
                    break;
                case "fr":
                    languageComboBox.SelectedIndex = 2;
                    break;
                case "es":
                    languageComboBox.SelectedIndex = 3;
                    break;
                case "ru":
                    languageComboBox.SelectedIndex = 4;
                    break;

                default:
                    languageComboBox.SelectedIndex = 0;
                    break;
            }
        }

        private void lookAndFeelRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dotNetRadioButton.Checked)
            {
                lookAndFeelPictureBox.Image = ImageResource.style_office_2003;
            }
            else if (windowsRadioButton.Checked)
            {
                lookAndFeelPictureBox.Image = ImageResource.style_windows_xp;
            }
        }

        private void stayOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            stayOnTopPictureBox.Image = stayOnTopCheckBox.Checked ? ImageResource.stayontop_enable : ImageResource.stayontop_disable;
        }

        private void minimizeOnTrayIconCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            minimizeOnTrayIconPictureBox.Image = minimizeOnTrayIconCheckBox.Checked ? ImageResource.minimizetray_enable : ImageResource.minimizetray_disable;
        }

        private void linkContattiLabel_Click(object sender, EventArgs e)
        {
            OtherManager.StartProcess(this, ConstantUtil.dtPadContactURL, OptionManager.GetLanguage(this));
        }

        private void enableProxySettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OptionManager.CheckProxyStatusEnabled(this);
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            statusPictureBox.Visible = false;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            statusPictureBox.Visible = false;
        }

        private void domainTextBox_TextChanged(object sender, EventArgs e)
        {
            statusPictureBox.Visible = false;
        }

        private void destinationPathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (destinationPathTextBox.Text.Length > 2 && Char.IsLetter(destinationPathTextBox.Text[0]) && destinationPathTextBox.Text[1] == ':' && destinationPathTextBox.Text[2] == '\\')
            {
                nextButton.Enabled = true;
                InstallManager.RefreshInstallPanel(destinationPathTextBox, availableSpaceLabel1, requiredSpaceLabel1, languageComboBox, OptionManager.GetLanguage(this));
            }
            else
            {
                nextButton.Enabled = false;
                availableSpaceLabel1.Text = LanguageUtil.GetCurrentLanguageString("Unavailable", Name, OptionManager.GetLanguage(this));
            }
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLanguage(true);
        }

        private void contentContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem1.Enabled = ControlUtil.FocusedTextBoxCanUndo(sender);
        }

        #endregion Windows Methods

        #region Button Methods

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (introPanel.Visible)
            {
                introPanel.Visible = false;
                backButton.Visible = true;
                
                if (skipSettingsCheckBox.Checked)
                {
                    installPanel.Visible = true;
                    nextButton.Text = LanguageUtil.GetCurrentLanguageString("nextButtonInstall", Name, OptionManager.GetLanguage(this));
                    stepLabel.Text = LanguageUtil.GetCurrentLanguageString("InstallPhase", Name, OptionManager.GetLanguage(this));
                    stepPictureBox.Image = ImageResource.install_step_6;
                    InstallManager.InitInstallPanel(destinationPathTextBox, availableSpaceLabel1, requiredSpaceLabel1, languageComboBox, OptionManager.GetLanguage(this));
                }
                else
                {
                    languagePanel.Visible = true;
                    stepLabel.Text = LanguageUtil.GetCurrentLanguageString("LanguagePhase", Name, OptionManager.GetLanguage(this));
                    stepPictureBox.Image = ImageResource.install_step_2;
                }
            }
            else if (languagePanel.Visible)
            {
                languagePanel.Visible = false;
                lookAndFeelPanel.Visible = true;
                stepLabel.Text = LanguageUtil.GetCurrentLanguageString("LookAndFeelPhase", Name, OptionManager.GetLanguage(this));
                stepPictureBox.Image = ImageResource.install_step_3;
            }
            else if (lookAndFeelPanel.Visible)
            {
                lookAndFeelPanel.Visible = false;
                windowPanel.Visible = true;
                LookFeelUtil.SetLookAndFeel(this, contentContextMenuStrip);
                LookFeelUtil.SetLookAndFeel(this, contentContextMenuStrip1);
                stepLabel.Text = LanguageUtil.GetCurrentLanguageString("WindowPhase", Name, OptionManager.GetLanguage(this));
                stepPictureBox.Image = ImageResource.install_step_4;
            }
            else if (windowPanel.Visible)
            {
                windowPanel.Visible = false;
                internetPanel.Visible = true;
                stepLabel.Text = LanguageUtil.GetCurrentLanguageString("InternetPhase", Name, OptionManager.GetLanguage(this));
                stepPictureBox.Image = ImageResource.install_step_5;
            }
            else if (internetPanel.Visible)
            {
                internetPanel.Visible = false;
                installPanel.Visible = true;
                nextButton.Text = LanguageUtil.GetCurrentLanguageString("nextButtonInstall", Name, OptionManager.GetLanguage(this));
                stepLabel.Text = LanguageUtil.GetCurrentLanguageString("InstallPhase", Name, OptionManager.GetLanguage(this));
                stepPictureBox.Image = ImageResource.install_step_6;
                InstallManager.InitInstallPanel(destinationPathTextBox, availableSpaceLabel1, requiredSpaceLabel1, languageComboBox, OptionManager.GetLanguage(this));
            }
            else if (installPanel.Visible)
            {
                installPanel.Visible = false;
                endPanel.Visible = true;
                backButton.Visible = false;
                nextButton.Visible = false;
                cancelButton.Enabled = false;
                stepLabel.Text = LanguageUtil.GetCurrentLanguageString("EndPhase", Name, OptionManager.GetLanguage(this));
                stepPictureBox.Image = ImageResource.install_step_7;
                Refresh();

                if (InstallManager.InstallProcedure(this, installProgressBar, installTextBox, OptionManager.GetLanguage(this)))
                {
                    nextButton.Text = LanguageUtil.GetCurrentLanguageString("nextButtonStart", Name, OptionManager.GetLanguage(this));
                    nextButton.Visible = true;
                    nextButton.Click += nextButton_ClickEnd;
                    nextButton.Focus();
                }
                else
                {
                    backButton.Visible = true;
                }

                cancelButton.Text = LanguageUtil.GetCurrentLanguageString("cancelButtonExit", Name, OptionManager.GetLanguage(this));
                cancelButton.Enabled = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (languagePanel.Visible)
            {
                languagePanel.Visible = false;
                introPanel.Visible = true;
                backButton.Visible = false;
                stepLabel.Text = LanguageUtil.GetCurrentLanguageString("IntroPhase", Name, OptionManager.GetLanguage(this));
                stepPictureBox.Image = ImageResource.install_step_1;
            }
            else if (lookAndFeelPanel.Visible)
            {
                lookAndFeelPanel.Visible = false;
                languagePanel.Visible = true;
                stepLabel.Text = LanguageUtil.GetCurrentLanguageString("LanguagePhase", Name, OptionManager.GetLanguage(this));
                stepPictureBox.Image = ImageResource.install_step_2;
            }
            else if (windowPanel.Visible)
            {
                windowPanel.Visible = false;
                lookAndFeelPanel.Visible = true;
                stepLabel.Text = LanguageUtil.GetCurrentLanguageString("LookAndFeelPhase", Name, OptionManager.GetLanguage(this));
                stepPictureBox.Image = ImageResource.install_step_3;
            }
            else if (internetPanel.Visible)
            {
                internetPanel.Visible = false;
                windowPanel.Visible = true;
                stepLabel.Text = LanguageUtil.GetCurrentLanguageString("WindowPhase", Name, OptionManager.GetLanguage(this));
                stepPictureBox.Image = ImageResource.install_step_4;
            }
            else if (installPanel.Visible)
            {
                installPanel.Visible = false;
                
                if (skipSettingsCheckBox.Checked)
                {
                    introPanel.Visible = true;
                    backButton.Visible = false;
                    nextButton.Text = LanguageUtil.GetCurrentLanguageString("nextButton", Name, OptionManager.GetLanguage(this));
                    stepLabel.Text = LanguageUtil.GetCurrentLanguageString("IntroPhase", Name, OptionManager.GetLanguage(this));
                    stepPictureBox.Image = ImageResource.install_step_1;
                }
                else
                {
                    internetPanel.Visible = true;
                    nextButton.Text = LanguageUtil.GetCurrentLanguageString("nextButton", Name, OptionManager.GetLanguage(this));
                    stepLabel.Text = LanguageUtil.GetCurrentLanguageString("InternetPhase", Name, OptionManager.GetLanguage(this));
                    stepPictureBox.Image = ImageResource.install_step_5;
                }
            }
            else if (endPanel.Visible)
            {
                endPanel.Visible = false;
                installPanel.Visible = true;
                nextButton.Text = LanguageUtil.GetCurrentLanguageString("nextButtonInstall", Name, OptionManager.GetLanguage(this));
                nextButton.Visible = true;
                stepLabel.Text = LanguageUtil.GetCurrentLanguageString("InstallPhase", Name, OptionManager.GetLanguage(this));
                stepPictureBox.Image = ImageResource.install_step_6;
                InstallManager.InitInstallPanel(destinationPathTextBox, availableSpaceLabel1, requiredSpaceLabel1, languageComboBox, OptionManager.GetLanguage(this));
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = LanguageUtil.GetCurrentLanguageString("BrowseDescription", Name, OptionManager.GetLanguage(this));
            
            if (Directory.Exists(destinationPathTextBox.Text))
            {
                folderBrowserDialog.SelectedPath = destinationPathTextBox.Text;
            }
            else
            {
                folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }
            
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            destinationPathTextBox.Text = folderBrowserDialog.SelectedPath;
            InstallManager.RefreshInstallPanel(destinationPathTextBox, availableSpaceLabel1, requiredSpaceLabel1, languageComboBox, OptionManager.GetLanguage(this));
        }

        private void nextButton_ClickEnd(object sender, EventArgs e)
        {
            OtherManager.StartProcessWorkDirectory(this, Path.Combine(destinationPathTextBox.Text, "DtPad.exe"), destinationPathTextBox.Text, OptionManager.GetLanguage(this));
            Close();
        }

        private void testProxyButton_Click(object sender, EventArgs e)
        {
            statusPictureBox.Visible = true;
            OptionManager.CheckProxyStatus(this, OptionManager.GetLanguage(this));
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(installTextBox);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(installTextBox);
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.UndoControl(ControlUtil.GetFocusedControl(sender));
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.CutControl(ControlUtil.GetFocusedControl(sender));
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(ControlUtil.GetFocusedControl(sender));
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.PasteControl(ControlUtil.GetFocusedControl(sender));
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.DeleteControl(ControlUtil.GetFocusedControl(sender));
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(ControlUtil.GetFocusedControl(sender));
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private void SetLanguage(bool isFormReloading)
        {
            LanguageUtil.SetCurrentLanguage(this, OptionManager.GetLanguage(this), isFormReloading);
            LanguageUtil.SetCurrentLanguage(this, folderBrowserDialog, OptionManager.GetLanguage(this));
        }

        #endregion Private Methods
    }
}
