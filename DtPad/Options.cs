using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Options DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Options : Form
    {
        private const int maxCharsFont = 40;
        private Font previousFont;
        private Color previousFontColor;
        private Color previousBackgroundColor;
        private bool previousHighlightURL;
        private String previousLanguage;
        private bool previousSendTo;
        private bool previousOpenWith;
        private bool previousJumpListActivated;

        #region Internal Instance Fields

        internal Font TextFont { get; set; }
        internal Color TextFontColor { get; set; }
        internal Color TextBackgroundColor { get; set; }

        #endregion Internal Instance Fields

        #region Window Methods

        internal void InitializeForm()
        {
            Form1 form = (Form1)Owner;
            
            InitializeComponent();
            LookFeelUtil.SetOptionsLookAndFeel(this);
            SetLanguage();

            optionsTreeView.ExpandAll();

            int settingFolder = ConfigUtil.GetIntParameter("SettingFolder");
            switch (settingFolder)
            {
                case 0:
                    lastUsedFolderRadioButton.Checked = false;
                    specificFolderRadioButton.Checked = true;
                    break;
                case 1:
                    lastUsedFolderRadioButton.Checked = true;
                    specificFolderRadioButton.Checked = false;
                    break;
            }
            specificFolderTextBox.Text = ConfigUtil.GetStringParameter("SpecificFolder");
            folderOpenedFileCheckBox.Checked = ConfigUtil.GetBoolParameter("OverrideFolderWithActiveFile");

            hostsConfiguratorCheckBox.Checked = ConfigUtil.GetBoolParameter("AutoOpenHostsConfigurator");
            hostsConfiguratorTabColorComboBox.SelectedIndex = ColorUtil.GetIndexFromTabColor(ConfigUtil.GetColorParameter("ColorHostsConfigurator"));
            showSearchPanelCheckBox.Checked = !ConfigUtil.GetBoolParameter("SearchReplacePanelDisabled");
            caseSensitiveCheckBox.Checked = ConfigUtil.GetBoolParameter("SearchCaseSensitive");
            loopAtEOFCheckBox.Checked = ConfigUtil.GetBoolParameter("SearchLoopAtEOF");
            highlightsResultsCheckBox.Checked = ConfigUtil.GetBoolParameter("SearchHighlightsResults");
            wordWrapCheckBox.Checked = !ConfigUtil.GetBoolParameter("WordWrapDisabled");
            recentFilesNumberNumericUpDown.Value = ConfigUtil.GetIntParameter("MaxNumRecentFile");
            searchHistoryNumericUpDown.Value = ConfigUtil.GetIntParameter("MaxNumSearchHistory");
            stayOnTopCheckBox.Checked = !ConfigUtil.GetBoolParameter("StayOnTopDisabled");
            toolbarCheckBox.Checked = !ConfigUtil.GetBoolParameter("ToolbarInvisible");
            statusBarCheckBox.Checked = !ConfigUtil.GetBoolParameter("StatusBarInvisible");
            minimizeOnTrayIconCheckBox.Checked = !ConfigUtil.GetBoolParameter("MinimizeOnTrayIconDisabled");
            internalExplorerCheckBox.Checked = !ConfigUtil.GetBoolParameter("InternalExplorerInvisible");
            tabCloseButtonOnComboBox.SelectedIndex = ConfigUtil.GetIntParameter("TabCloseButtonMode");
            tabPositionComboBox.SelectedIndex = ConfigUtil.GetIntParameter("TabPosition");
            tabOrientationComboBox.SelectedIndex = ConfigUtil.GetIntParameter("TabOrientation");
            tabMultilineCheckBox.Checked = ConfigUtil.GetBoolParameter("TabMultiline");
            lineNumbersCheckBox.Checked = ConfigUtil.GetBoolParameter("LineNumbersVisible");
            keepInitialSpacesOnReturnCheckBox.Checked = ConfigUtil.GetBoolParameter("KeepInitialSpacesOnReturn");
            keepBulletListOnReturnCheckBox.Checked = ConfigUtil.GetBoolParameter("KeepBulletListOnReturn");
            splashScreenCheckBox.Checked = ConfigUtil.GetBoolParameter("ShowSplashScreen");
            automaticSessionSaveCheckBox.Checked = ConfigUtil.GetBoolParameter("AutomaticSessionSave");
            hideLinesCheckBox.Checked = ConfigUtil.GetBoolParameter("CheckLineNumber");
            hideLinesNumericUpDown.Value = ConfigUtil.GetIntParameter("CheckLineNumberMax");
            previousJumpListActivated = ConfigUtil.GetBoolParameter("ActiveJumpList");
            dropboxRememberCheckBox.Checked = ConfigUtil.GetBoolParameter("RememberDropboxAccess");
            dropboxDeleteCheckBox.Checked = ConfigUtil.GetBoolParameter("EnableDropboxDelete");
            nullCharCheckBox.Checked = ConfigUtil.GetBoolParameter("IgnoreNullChar");
            jumpListCheckBox.Checked = previousJumpListActivated;

            hideLinesCheckBox.Enabled = lineNumbersCheckBox.Checked;
            hideLinesNumericUpDown.Enabled = hideLinesCheckBox.Checked && hideLinesCheckBox.Enabled;

            enableProxySettingsCheckBox.Checked = ConfigUtil.GetBoolParameter("ProxyEnabled");
            OptionManager.CheckProxyStatusEnabled(this);

            List<PasswordObject> passwordList = PasswordUtil.GetStringParameters(new[] { "ProxyUsername", "ProxyPassword", "ProxyDomain", "DropboxUsername", "DropboxPassword" });
            usernameTextBox.Text = (passwordList[0]).value;
            passwordTextBox.Text = CodingUtil.DecodeByte((passwordList[1]).value);
            domainTextBox.Text = (passwordList[2]).value;
            proxyHostTextBox.Text = ConfigUtil.GetStringParameter("ProxyHost");
            proxyPortNumericUpDown.Value = ConfigUtil.GetIntParameter("ProxyPort");

            TextFont = ConfigUtil.GetFontParameter("FontInUse");
            previousFont = TextFont;
            String[] argbFontColor = ConfigUtil.GetStringParameter("FontInUseColorARGB").Split(new[] { ';' });
            TextFontColor = Color.FromArgb(Convert.ToInt32(argbFontColor[0]), Convert.ToInt32(argbFontColor[1]), Convert.ToInt32(argbFontColor[2]), Convert.ToInt32(argbFontColor[3]));
            previousFontColor = TextFontColor;
            String[] argbBackgroundColor = ConfigUtil.GetStringParameter("BackgroundColorARGB").Split(new[] { ';' });
            TextBackgroundColor = Color.FromArgb(Convert.ToInt32(argbBackgroundColor[0]), Convert.ToInt32(argbBackgroundColor[1]), Convert.ToInt32(argbBackgroundColor[2]), Convert.ToInt32(argbBackgroundColor[3]));
            previousBackgroundColor = TextBackgroundColor;
            fontLabel1.Text = StringUtil.CheckStringLengthEnd(ConfigUtil.GetStringParameter("FontInUse"), maxCharsFont);
            fontColorTextBox.BackColor = TextFontColor;
            backgroundColorTextBox.BackColor = TextBackgroundColor;

            urlsCheckBox.Checked = ConfigUtil.GetBoolParameter("HighlightURL");
            previousHighlightURL = urlsCheckBox.Checked;
            defaultBrowserRadioButton.Checked = ConfigUtil.GetBoolParameter("UseDefaultBrowser");
            customBrowserRadioButton.Checked = !ConfigUtil.GetBoolParameter("UseDefaultBrowser");
            customBrowserTextBox.Text = ConfigUtil.GetStringParameter("CustomBrowserCommand");

            renderModeComboBox.SelectedIndex = ConfigUtil.GetIntParameter("LookAndFeel");
            languageComboBox.EditValue = ConfigUtil.GetStringParameter("Language");
            previousLanguage = languageComboBox.SelectedItem.ToString();
            useSelectedSettingsLanguageCheckBox.Checked = ConfigUtil.GetBoolParameter("TranslationUseSelect");
            sourceImageComboBoxEdit.EditValue = LanguageUtil.GetLongCultureForGoogleTranslator(ConfigUtil.GetStringParameter("Translation").Substring(0, 2));
            destinationImageComboBoxEdit.EditValue = LanguageUtil.GetLongCultureForGoogleTranslator(ConfigUtil.GetStringParameter("Translation").Substring(3, 2));

            OptionManager.SetListExtensions(this);

            useExistingCheckBox.Checked = ConfigUtil.GetBoolParameter("DefaultEncoding");
            defaultComboBox.SelectedIndex = ConfigUtil.GetIntParameter("Encoding");

            backupIncrementalCheckBox.Checked = ConfigUtil.GetBoolParameter("BackupIncremental");
            createBackupCheckBox.Checked = ConfigUtil.GetBoolParameter("BackupEnabled");
            backupExtensionTextBox.Text = ConfigUtil.GetStringParameter("BackupExtension");
            int backupLocation = ConfigUtil.GetIntParameter("BackupLocation");
            switch (backupLocation)
            {
                case 0:
                    backupEditedFileRadioButton.Checked = true;
                    backupCustomFolderRadioButton.Checked = false;
                    break;
                case 1:
                    backupEditedFileRadioButton.Checked = false;
                    backupCustomFolderRadioButton.Checked = true;
                    break;
            }
            int backupExtensionPosition = ConfigUtil.GetIntParameter("BackupExtensionPosition");
            switch (backupExtensionPosition)
            {
                case 0:
                    backupAddExtensionRadioButton.Checked = true;
                    backupReplaceExtensionRadioButton.Checked = false;
                    break;
                case 1:
                    backupAddExtensionRadioButton.Checked = false;
                    backupReplaceExtensionRadioButton.Checked = true;
                    break;
            }
            backupCustomFolderTextBox.Text = ConfigUtil.GetStringParameter("BackupLocationCustom");

            if (WindowManager.IsWindowInFullScreenMode(form))
            {
                stayOnTopCheckBox.Enabled = false;
            }

            sendToCheckBox.Checked = ShellManager.ExistsSendToLink();
            openWithCheckBox.Checked = ShellManager.ExistsOpenWithLink();
            previousSendTo = sendToCheckBox.Checked;
            previousOpenWith = openWithCheckBox.Checked;

            String autoFormatFiles = ConfigUtil.GetStringParameter("AutoFormatFiles");
            htmlCheckBox.Checked = autoFormatFiles.Contains(".html");
            xmlCheckBox.Checked = autoFormatFiles.Contains(".xml");

            int periodicVersionCheck = ConfigUtil.GetIntParameter("PeriodicVersionCheck");
            switch (periodicVersionCheck)
            {
                case 0:
                    enableAutomaticUpdateCheckBox.Checked = false;
                    frequencyAutomaticUpdateComboBox.Enabled = false;
                    break;
                case 1:
                case 2:
                    enableAutomaticUpdateCheckBox.Checked = true;
                    frequencyAutomaticUpdateComboBox.Enabled = true;
                    frequencyAutomaticUpdateComboBox.SelectedIndex = periodicVersionCheck - 1;
                    break;
            }
            
            lastCheckLabel.Text += " " + ConfigUtil.GetDateParameter("LastVersionCheck").ToString(LanguageUtil.GetShortDateTimeFormat());

            noteModeTabsCheckBox.Checked = ConfigUtil.GetBoolParameter("NoteModeTabs");
            noteModeSizeXNumericUpDown.Value = ConfigUtil.GetIntParameter("NoteModeSizeX");
            noteModeSizeYNumericUpDown.Value = ConfigUtil.GetIntParameter("NoteModeSizeY");
        }

        internal void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, numberContextMenuStrip.Items);
            optionsToolTip.SetToolTip(extensionsButton, LanguageUtil.GetCurrentLanguageString("extensionsButtonToolTip", Name));
            optionsToolTip.SetToolTip(infoProxyPictureBox, LanguageUtil.GetCurrentLanguageString("infoProxyPictureBoxToolTip", Name));
            optionsToolTip.SetToolTip(helpHideLinesPictureBox, LanguageUtil.GetCurrentLanguageString("helpHideLinesPictureBoxToolTip", Name));
            optionsToolTip.SetToolTip(switchButton, LanguageUtil.GetCurrentLanguageString("switchButtonToolTip", Name));

            previousLanguage = ConfigUtil.GetStringParameter("Language");
        }

        private void optionsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["fileNode"])
            {
                SetPanelVisible(filePanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["fileNode"].Nodes["encodingNode"])
            {
                SetPanelVisible(encodingPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["fileNode"].Nodes["openingNode"])
            {
                SetPanelVisible(openingPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["fileNode"].Nodes["savingNode"])
            {
                SetPanelVisible(savingPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["sessionNode"])
            {
                SetPanelVisible(sessionPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["searchNode"])
            {
                SetPanelVisible(searchPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["formatNode"])
            {
                SetPanelVisible(formatPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["languageNode"])
            {
                SetPanelVisible(languagePanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["tabNode"])
            {
                SetPanelVisible(tabPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["noteModeNode"])
            {
                SetPanelVisible(noteModePanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["viewNode"])
            {
                SetPanelVisible(viewPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["viewNode"].Nodes["lookAndFeelNode"])
            {
                SetPanelVisible(lookAndFeelPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["internetNode"])
            {
                SetPanelVisible(internetPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["internetNode"].Nodes["updateNode"])
            {
                SetPanelVisible(updatePanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["internetNode"].Nodes["dropboxNode"])
            {
                SetPanelVisible(dropboxPanel);
            }
            else if (optionsTreeView.SelectedNode == optionsTreeView.Nodes["shellNode"])
            {
                SetPanelVisible(shellPanel);
            }
        }

        private void enableProxySettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OptionManager.CheckProxyStatusEnabled(this);
        }

        private void defaultBrowserRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            customBrowserTextBox.Enabled = !defaultBrowserRadioButton.Checked;
            customBrowserButton.Enabled = !defaultBrowserRadioButton.Checked;
        }

        private void renderModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (renderModeComboBox.SelectedIndex)
            {
                case 0:
                    renderPictureBox.Image = WindowResource.style_office_2003;
                    break;
                case 1:
                    renderPictureBox.Image = WindowResource.style_windows_xp;
                    break;
            }
        }

        private void lastUsedFolderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            specificFolderTextBox.Enabled = !lastUsedFolderRadioButton.Checked;
            specificFolderButton.Enabled = !lastUsedFolderRadioButton.Checked;
        }

        private void Options_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void backupCustomFolderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            backupCustomFolderTextBox.Enabled = backupCustomFolderRadioButton.Checked;
            backupCustomFolderButton.Enabled = backupCustomFolderRadioButton.Checked;
        }

        private void hideLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hideLinesNumericUpDown.Enabled = hideLinesCheckBox.Checked;
        }

        private void lineNumbersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hideLinesCheckBox.Enabled = lineNumbersCheckBox.Checked;
            hideLinesNumericUpDown.Enabled = lineNumbersCheckBox.Checked && hideLinesCheckBox.Checked;
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

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = ControlUtil.FocusedTextBoxCanUndo(sender);
        }

        private void enableAutomaticUpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            frequencyAutomaticUpdateComboBox.Enabled = enableAutomaticUpdateCheckBox.Checked;
            frequencyAutomaticUpdateComboBox.SelectedItem = null;
        }

        private void hostsConfiguratorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hostsConfiguratorTabColorComboBox.Enabled = hostsConfiguratorCheckBox.Checked;
        }

        #endregion Window Methods

        #region Buttons Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            if (SaveOptions(true))
            {
                WindowManager.CloseForm(this);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            SaveOptions(false);
            Focus();
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            TabManager.FontPagesWithoutSave(this);

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
            fontLabel1.Text = StringUtil.CheckStringLengthEnd(tc.ConvertToString(TextFont), maxCharsFont);
            fontColorTextBox.BackColor = TextFontColor;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            TabManager.BackgroundPagesWithoutSave(this);
            backgroundColorTextBox.BackColor = TextBackgroundColor;
        }

        private void customBrowserButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            String pathAndFileName = FileUtil.GetFileNameAndPath(form, LanguageUtil.GetCurrentLanguageString("BrowserFileDialog", Name), 2, "*.exe"); //"All files (*.*)|*.*|Executable Files (*.exe)|*.exe"
            if (!String.IsNullOrEmpty(pathAndFileName))
            {
                customBrowserTextBox.Text = pathAndFileName;
            }
        }

        private void clearRecentFilesButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            FileListManager.ClearRecentFiles(form);
            Focus();
        }

        private void specificFolderButton_Click(object sender, EventArgs e)
        {
            FileUtil.GetDefaultPath(this);
        }

        private void extensionsButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            WindowManager.ShowExtensions(form);
            OptionManager.SetListExtensions(this);
        }

        private void backupCustomFolderButton_Click(object sender, EventArgs e)
        {
            FileUtil.GetBackupPath(this);
        }

        private void checkConnectionButton_Click(object sender, EventArgs e)
        {
            statusPictureBox.Visible = true;
            OptionManager.CheckProxyStatus(this);
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            object sourceLanguage = sourceImageComboBoxEdit.EditValue;
            sourceImageComboBoxEdit.EditValue = destinationImageComboBoxEdit.EditValue;
            destinationImageComboBoxEdit.EditValue = sourceLanguage;
        }

        #endregion Buttons Methods

        #region Private Methods

        private void SetPanelVisible(Control visiblePanel)
        {   
            filePanel.Visible = false;
            encodingPanel.Visible = false;
            openingPanel.Visible = false;
            savingPanel.Visible = false;
            sessionPanel.Visible = false;
            searchPanel.Visible = false;
            formatPanel.Visible = false;
            languagePanel.Visible = false;
            tabPanel.Visible = false;
            noteModePanel.Visible = false;
            viewPanel.Visible = false;
            lookAndFeelPanel.Visible = false;
            internetPanel.Visible = false;
            updatePanel.Visible = false;
            dropboxPanel.Visible = false;
            shellPanel.Visible = false;

            visiblePanel.Visible = true;
        }

        private bool SaveOptions(bool closeOptionsAfterSave)
        {
            if (enableProxySettingsCheckBox.Checked && (String.IsNullOrEmpty(usernameTextBox.Text) || String.IsNullOrEmpty(passwordTextBox.Text)))
            {
                WindowManager.ShowAlertBox(this, LanguageUtil.GetCurrentLanguageString("proxyWarning", Name));
                return false;
            }
            if (backupCustomFolderRadioButton.Checked && !Directory.Exists(backupCustomFolderTextBox.Text))
            {
                WindowManager.ShowAlertBox(this, LanguageUtil.GetCurrentLanguageString("backupLocationWarning", Name));
                return false;
            }
            if (String.IsNullOrEmpty(backupExtensionTextBox.Text))
            {
                WindowManager.ShowAlertBox(this, LanguageUtil.GetCurrentLanguageString("backupExtensionWarning", Name));
                return false;
            }

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));

            int settingFolder = 0;
            if (lastUsedFolderRadioButton.Checked)
            {
                settingFolder = 1;
            }
            int backupExtensionPosition = 0;
            if (backupReplaceExtensionRadioButton.Checked)
            {
                backupExtensionPosition = 1;
            }
            int backupLocation = 0;
            if (backupCustomFolderRadioButton.Checked)
            {
                backupLocation = 1;
            }

            int periodicVersionCheck = 0;
            if (enableAutomaticUpdateCheckBox.Checked && frequencyAutomaticUpdateComboBox.SelectedIndex == 0)
            {
                periodicVersionCheck = 1;
            }
            else if (enableAutomaticUpdateCheckBox.Checked && frequencyAutomaticUpdateComboBox.SelectedIndex == 1)
            {
                periodicVersionCheck = 2;
            }

            String[] parameterNames = { "SettingFolder", "SpecificFolder", "OverrideFolderWithActiveFile", "MaxNumRecentFile", "MaxNumSearchHistory", "StayOnTopDisabled",
                                          "ToolbarInvisible", "StatusBarInvisible", "MinimizeOnTrayIconDisabled", "LookAndFeel", "Language",
                                          "ProxyEnabled", "ProxyHost", "ProxyPort", "UseDefaultBrowser", "CustomBrowserCommand", "SearchReplacePanelDisabled",
                                          "SearchCaseSensitive", "SearchLoopAtEOF", "SearchHighlightsResults", "WordWrapDisabled", "FontInUse", "FontInUseColorARGB",
                                          "BackgroundColorARGB", "HighlightURL", "InternalExplorerInvisible", "TabCloseButtonMode", "TabPosition", "TabOrientation",
                                          "TabMultiline", "DefaultEncoding", "Encoding", "LineNumbersVisible", "BackupEnabled", "BackupExtension", "BackupExtensionPosition",
                                          "BackupLocation", "BackupLocationCustom", "BackupIncremental", "SpacesInsteadTabs", "KeepInitialSpacesOnReturn",
                                          "KeepBulletListOnReturn", "ShowSplashScreen", "AutomaticSessionSave", "Translation", "TranslationUseSelect", "CheckLineNumber",
                                          "CheckLineNumberMax", "AutoFormatFiles", "AutoOpenHostsConfigurator", "ColorHostsConfigurator", "PeriodicVersionCheck",
                                          "ActiveJumpList", "EnableDropboxDelete", "RememberDropboxAccess", "IgnoreNullChar", "NoteModeTabs", "NoteModeSizeX", "NoteModeSizeY" };
            
            String[] parameterValues = { settingFolder.ToString(), specificFolderTextBox.Text, folderOpenedFileCheckBox.Checked.ToString(),
                                           recentFilesNumberNumericUpDown.Value.ToString(), searchHistoryNumericUpDown.Value.ToString(),
                                           (!stayOnTopCheckBox.Checked).ToString(), (!toolbarCheckBox.Checked).ToString(), (!statusBarCheckBox.Checked).ToString(),
                                           (!minimizeOnTrayIconCheckBox.Checked).ToString(), renderModeComboBox.SelectedIndex.ToString(),
                                           languageComboBox.SelectedItem.ToString(), enableProxySettingsCheckBox.Checked.ToString(), proxyHostTextBox.Text,
                                           proxyPortNumericUpDown.Value.ToString(), defaultBrowserRadioButton.Checked.ToString(), customBrowserTextBox.Text,
                                           (!showSearchPanelCheckBox.Checked).ToString(), caseSensitiveCheckBox.Checked.ToString(), loopAtEOFCheckBox.Checked.ToString(),
                                           highlightsResultsCheckBox.Checked.ToString(), (!wordWrapCheckBox.Checked).ToString(), tc.ConvertToString(TextFont),
                                           FontManager.SetARGBString(TextFontColor), FontManager.SetARGBString(TextBackgroundColor), urlsCheckBox.Checked.ToString(),
                                           (!internalExplorerCheckBox.Checked).ToString(), tabCloseButtonOnComboBox.SelectedIndex.ToString(),
                                           tabPositionComboBox.SelectedIndex.ToString(), tabOrientationComboBox.SelectedIndex.ToString(),
                                           tabMultilineCheckBox.Checked.ToString(), useExistingCheckBox.Checked.ToString(),
                                           defaultComboBox.SelectedIndex.ToString(), lineNumbersCheckBox.Checked.ToString(), createBackupCheckBox.Checked.ToString(),
                                           backupExtensionTextBox.Text, backupExtensionPosition.ToString(), backupLocation.ToString(), backupCustomFolderTextBox.Text,
                                           backupIncrementalCheckBox.Checked.ToString(), useSpacesInsteadTabsCheckBox.Checked.ToString(),
                                           keepInitialSpacesOnReturnCheckBox.Checked.ToString(), keepBulletListOnReturnCheckBox.Checked.ToString(), 
                                           splashScreenCheckBox.Checked.ToString(), automaticSessionSaveCheckBox.Checked.ToString(),
                                           LanguageUtil.GetReallyShortCultureForGoogleTranslator(sourceImageComboBoxEdit.SelectedItem.ToString()) + "|" +
                                           LanguageUtil.GetReallyShortCultureForGoogleTranslator(destinationImageComboBoxEdit.SelectedItem.ToString()),
                                           useSelectedSettingsLanguageCheckBox.Checked.ToString(), hideLinesCheckBox.Checked.ToString(),
                                           hideLinesNumericUpDown.Value.ToString(), GetAutoFormatFilesString(), hostsConfiguratorCheckBox.Checked.ToString(),
                                           ColorUtil.GetColorFromTabInt(hostsConfiguratorTabColorComboBox.SelectedIndex).Name, periodicVersionCheck.ToString(),
                                           jumpListCheckBox.Checked.ToString(), dropboxDeleteCheckBox.Checked.ToString(), dropboxRememberCheckBox.Checked.ToString(),
                                           nullCharCheckBox.Checked.ToString(), noteModeTabsCheckBox.Checked.ToString(), noteModeSizeXNumericUpDown.Value.ToString(), noteModeSizeYNumericUpDown.Value.ToString() };

            String[] passwordNames = { "ProxyUsername", "ProxyPassword", "ProxyDomain" };
            String[] passwordValues = { usernameTextBox.Text, CodingUtil.EncodeString(passwordTextBox.Text), domainTextBox.Text };

            OptionManager.SaveOptionsGroup(parameterNames, parameterValues, passwordNames, passwordValues);
            OptionManager.RefreshOwner(this, closeOptionsAfterSave, previousFont, TextFont, previousFontColor, TextFontColor, previousBackgroundColor, TextBackgroundColor, previousHighlightURL, previousLanguage, previousJumpListActivated);
            SetShellIntegration();

            return true;
        }

        private void SetShellIntegration()
        {
            if (previousSendTo != sendToCheckBox.Checked)
            {
                if (sendToCheckBox.Checked)
                {
                    ShellManager.SetSendToLink();
                }
                else
                {
                    ShellManager.RemoveSendToLink();
                }
            }
            if (previousOpenWith != openWithCheckBox.Checked)
            {
                if (openWithCheckBox.Checked)
                {
                    ShellManager.SetOpenWithLink();
                }
                else
                {
                    ShellManager.RemoveOpenWithLink();
                }
            }
        }

        private String GetAutoFormatFilesString()
        {
            String autoFormatFiles = String.Empty;

            if (htmlCheckBox.Checked)
            {
                if (String.IsNullOrEmpty(autoFormatFiles))
                {
                    autoFormatFiles += ".html";
                }
                else
                {
                    autoFormatFiles += ";.html";
                }
            }

            if (xmlCheckBox.Checked)
            {
                if (String.IsNullOrEmpty(autoFormatFiles))
                {
                    autoFormatFiles += ".xml";
                }
                else
                {
                    autoFormatFiles += ";.xml";
                }
            }

            return autoFormatFiles;
        }

        #endregion Private Methods
    }
}
