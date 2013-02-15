using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DtControls;
using DtPad.Customs;
using DtPad.Objects;
using DtPad.Utils;
using ComboBox = System.Windows.Forms.ComboBox;

namespace DtPad.Managers
{
    /// <summary>
    /// Options manager.
    /// </summary>
    /// <author>Marco Macciò, Derek Morin</author>
    internal static class OptionManager
    {
        private const String className = "OptionManager";

        #region Internal Methods

        internal static void CheckProxyStatus(Options form)
        {
            PictureBox statusPictureBox = form.statusPictureBox;

            statusPictureBox.Image = !CheckProxyStatusReturn(form) ? ToolbarResource.minus : ToolbarResource.confirm;
        }

        internal static void CheckProxyStatusEnabled(Options form)
        {
            CheckBox enableProxySettingsCheckBox = form.enableProxySettingsCheckBox;
            TextBox usernameTextBox = form.usernameTextBox;
            TextBox passwordTextBox = form.passwordTextBox;
            TextBox confirmTextBox = form.domainTextBox;
            TextBox proxyHostTextBox = form.proxyHostTextBox;
            CustomNumericUpDown proxyPortNumericUpDown = form.proxyPortNumericUpDown;
            PictureBox statusPictureBox = form.statusPictureBox;
            Button checkConnectionButton = form.checkConnectionButton;

            if (!enableProxySettingsCheckBox.Checked)
            {
                usernameTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
                confirmTextBox.Enabled = false;
                proxyHostTextBox.Enabled = false;
                proxyPortNumericUpDown.Enabled = false;
                statusPictureBox.Visible = false;
                checkConnectionButton.Enabled = false;
            }
            else
            {
                usernameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                confirmTextBox.Enabled = true;
                proxyHostTextBox.Enabled = true;
                proxyPortNumericUpDown.Enabled = true;
                checkConnectionButton.Enabled = true;
            }
        }

        internal static void SaveOptionsGroup(String[] parameterNames, String[] parameterValues, String[] passwordNames, String[] passwordValues)
        {
            ConfigUtil.UpdateParameters(parameterNames, parameterValues);
            PasswordUtil.UpdateParameters(passwordNames, passwordValues);
        }

        internal static void RefreshOwner(Options form, bool closeOptionsAfterSave, Font previousFont, Font font, Color previousFontColor, Color fontColor, Color previousBackgroundColor, Color backgroundColor, bool previousHighlightURL, String previousLanguage, bool previousJumpListActivated)
        {
            Form1 form1 = (Form1)form.Owner;

            XtraTabControl pagesTabControl = form1.pagesTabControl;
            CheckBox caseCheckBox = form1.searchPanel.caseCheckBox;
            CheckBox loopCheckBox = form1.searchPanel.loopCheckBox;
            ToolStrip sessionToolStrip = form1.sessionToolStrip;
            ToolStripMenuItem useDefaultToolStripMenuItem = form1.useDefaultToolStripMenuItem;

            CheckBox showSearchPanelCheckBox = form.showSearchPanelCheckBox;
            CheckBox wordWrapCheckBox = form.wordWrapCheckBox;
            CheckBox stayOnTopCheckBox = form.stayOnTopCheckBox;
            CheckBox toolbarCheckBox = form.toolbarCheckBox;
            CheckBox statusBarCheckBox = form.statusBarCheckBox;
            CheckBox minimizeOnTrayIconCheckBox = form.minimizeOnTrayIconCheckBox;
            CheckBox caseSensitiveCheckBox = form.caseSensitiveCheckBox;
            CheckBox loopAtEOFCheckBox = form.loopAtEOFCheckBox;
            CheckBox urlsCheckBox = form.urlsCheckBox;
            ImageComboBoxEdit languageComboBox = form.languageComboBox;
            CheckBox internalExplorerCheckBox = form.internalExplorerCheckBox;
            ComboBox tabCloseButtonOnComboBox = form.tabCloseButtonOnComboBox;
            ComboBox tabPositionComboBox = form.tabPositionComboBox;
            ComboBox tabOrientationComboBox = form.tabOrientationComboBox;
            CheckBox tabMultilineCheckBox = form.tabMultilineCheckBox;
            CheckBox useExistingCheckBox = form.useExistingCheckBox;
            ComboBox defaultComboBox = form.defaultComboBox;
            CheckBox lineNumbersCheckBox = form.lineNumbersCheckBox;
            CheckBox keepInitialSpacesOnReturnCheckBox = form.keepInitialSpacesOnReturnCheckBox;
            CheckBox keepBulletListOnReturnCheckBox = form.keepBulletListOnReturnCheckBox;
            CheckBox jumpListCheckBox = form.jumpListCheckBox;

            WindowManager.CheckSearchReplacePanel(form1, showSearchPanelCheckBox.Checked, true); //form1.searchPanel.Visible
            WindowManager.CheckWordWrap(form1, !wordWrapCheckBox.Checked, false);

            if (WindowManager.IsWindowInFullScreenMode(form1))
            {
                WindowManager.CheckStayOnTop(form1, !stayOnTopCheckBox.Checked, false);
            }
            WindowManager.CheckToolbar(form1, !toolbarCheckBox.Checked, true, false);
            WindowManager.CheckStatusBar(form1, !statusBarCheckBox.Checked, true, false);
            WindowManager.CheckTrayIcon(form1, !minimizeOnTrayIconCheckBox.Checked, false);
            WindowManager.CheckSearchCaseSensitive(caseSensitiveCheckBox.Checked, caseCheckBox, false);
            WindowManager.CheckSearchLoop(loopAtEOFCheckBox.Checked, loopCheckBox, false);
            WindowManager.CheckInternalExplorer(form1, internalExplorerCheckBox.Checked, false);
            WindowManager.CheckDefaultEncoding(form1, useExistingCheckBox.Checked, false);
            WindowManager.CheckEncoding(form1, defaultComboBox.SelectedIndex, false);
            WindowManager.CheckLineNumbers(form1, lineNumbersCheckBox.Checked, false);
            FileListManager.RefreshRecentFiles(form1);
            FileListManager.RefreshSearchHistory(form1);

            if ((previousJumpListActivated != jumpListCheckBox.Checked) && !jumpListCheckBox.Checked)
            {
                SystemUtil.ClearWindowsJumpList(form1);
            }
            else if ((previousJumpListActivated != jumpListCheckBox.Checked) && jumpListCheckBox.Checked)
            {
                SystemUtil.SetWindowsJumpList(form1);
            }

            //If session is open and don't use default aspect, it will do nothing
            if (!sessionToolStrip.Visible || (sessionToolStrip.Visible && useDefaultToolStripMenuItem.Checked))
            {
                CheckTabCloseButton(form1, tabCloseButtonOnComboBox.SelectedIndex);
                CheckTabPosition(form1, tabPositionComboBox.SelectedIndex);
                CheckTabOrientation(form1, tabOrientationComboBox.SelectedIndex);
            }

            CheckTabMultiline(form1, tabMultilineCheckBox.Checked);
            form1.KeepInitialSpacesOnReturn = keepInitialSpacesOnReturnCheckBox.Checked;
            form1.KeepBulletListOnReturn = keepBulletListOnReturnCheckBox.Checked;

            if (!previousFont.Equals(font) || previousFontColor != fontColor || previousBackgroundColor != backgroundColor || previousHighlightURL != urlsCheckBox.Checked)
            {
                foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
                {
                    CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(tabPage);
                    CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(tabPage);

                    pageTextBox.Font = font;
                    customLineNumbers.Font = font;
                    pageTextBox.ForeColor = fontColor;
                    pageTextBox.BackColor = backgroundColor;
                    customLineNumbers.BackColor = backgroundColor;
                    pageTextBox.DetectUrls = urlsCheckBox.Checked;
                }

                form1.SetMainFont(font);
                form1.TextFontColor = fontColor;
                form1.TextBackgroundColor = backgroundColor;
            }

            LookFeelUtil.SetForm1LookAndFeel(form1);
            //if (!closeOptionsAfterSave)
            //{
            //    LookFeelUtil.SetOptionsLookAndFeel(form);
            //}

            if (previousLanguage == languageComboBox.SelectedItem.ToString())
            {
                return;
            }

            ConfigUtil.UpdateParameter("RecreateJumpList", true.ToString());
            if (!closeOptionsAfterSave)
            {
                form.SetLanguage();
            }
            form1.SetLanguage(true);
        }

        internal static void SetListExtensions(Options form)
        {
            ListBox extensionListBox = form.extensionListBox;

            ExtensionObjectList extensionObjectList = ExtensionManager.GetExtensionObjectListFromExFile();
            extensionListBox.Items.Clear();
            foreach (ExtensionObject extensionObject in extensionObjectList)
            {
                extensionListBox.Items.Add(String.Format("{0} (*.{1})", extensionObject.Description, extensionObject.Extension));
            }
        }

        internal static void CheckTabCloseButton(Form1 form, int tabCloseButtonMode)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            switch (tabCloseButtonMode)
            {
                case 0:
                    pagesTabControl.HeaderButtons = TabButtons.Close | TabButtons.Default;
                    pagesTabControl.ClosePageButtonShowMode = ClosePageButtonShowMode.InTabControlHeader;
                    break;
                case 1:
                    pagesTabControl.HeaderButtons = TabButtons.Close | TabButtons.Default;
                    pagesTabControl.ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders;
                    break;
                case 2:
                    pagesTabControl.HeaderButtons = TabButtons.Close | TabButtons.Default;
                    pagesTabControl.ClosePageButtonShowMode = ClosePageButtonShowMode.InActiveTabPageHeader;
                    break;
                case 3:
                    pagesTabControl.HeaderButtons = TabButtons.Default;
                    pagesTabControl.ClosePageButtonShowMode = ClosePageButtonShowMode.Default;
                    break;

                default:
                    pagesTabControl.HeaderButtons = TabButtons.Close | TabButtons.Default;
                    pagesTabControl.ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders;
                    break;
            }
        }

        internal static void CheckTabPosition(Form1 form, int tabPosition)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            switch (tabPosition)
            {
                case 0:
                    pagesTabControl.HeaderLocation = TabHeaderLocation.Top;
                    break;
                case 1:
                    pagesTabControl.HeaderLocation = TabHeaderLocation.Right;
                    break;
                case 2:
                    pagesTabControl.HeaderLocation = TabHeaderLocation.Bottom;
                    break;
                case 3:
                    pagesTabControl.HeaderLocation = TabHeaderLocation.Left;
                    break;

                default:
                    pagesTabControl.HeaderLocation = TabHeaderLocation.Top;
                    break;
            }
        }

        internal static void CheckTabOrientation(Form1 form, int tabOrientation)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            switch (tabOrientation)
            {
                case 0:
                    pagesTabControl.HeaderOrientation = TabOrientation.Horizontal;
                    break;
                case 1:
                    pagesTabControl.HeaderOrientation = TabOrientation.Vertical;
                    break;

                default:
                    pagesTabControl.HeaderOrientation = TabOrientation.Horizontal;
                    break;
            }
        }

        internal static void CheckTabMultiline(Form1 form, bool tabMultiline)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            pagesTabControl.MultiLine = tabMultiline ? DefaultBoolean.True : DefaultBoolean.False;
        }

        internal static bool ResetOptions(Options form, Font previousFont, Color previousFontColor, Color previousBackgroundColor, bool previousHighlightURL, String previousLanguage, bool previousJumpListActivated)
        {
            DialogResult proceed = WindowManager.ShowWarningBox(form, LanguageUtil.GetCurrentLanguageString("SureReset", className));
            if (proceed == DialogResult.No || proceed == DialogResult.Cancel)
            {
                return false;
            }

            form.Cursor = Cursors.WaitCursor;

            Font textFont = null;
            Color textFontColor = Color.Black;
            Color textBackgroundColor = Color.White;

            foreach (KeyValuePair<String, String> keyValuePair in ConstantUtil.AppConfigDefaults)
            {
                ConfigUtil.UpdateParameter(keyValuePair.Key, keyValuePair.Value, true);

                switch (keyValuePair.Key)
                {
                    case "FontInUse":
                        textFont = ConfigUtil.GetFontParameter("FontInUse");
                        break;
                    case "FontInUseColorARGB":
                        String[] argbFontColor = keyValuePair.Value.Split(new[] { ';' });
                        textFontColor = Color.FromArgb(Convert.ToInt32(argbFontColor[0]), Convert.ToInt32(argbFontColor[1]), Convert.ToInt32(argbFontColor[2]), Convert.ToInt32(argbFontColor[3]));
                        break;
                    case "BackgroundColorARGB":
                        String[] argbBackgroundColor = keyValuePair.Value.Split(new[] { ';' });
                        textBackgroundColor = Color.FromArgb(Convert.ToInt32(argbBackgroundColor[0]), Convert.ToInt32(argbBackgroundColor[1]), Convert.ToInt32(argbBackgroundColor[2]), Convert.ToInt32(argbBackgroundColor[3]));
                        break;
                }
            }

            RefreshOwner(form, true, previousFont, textFont, previousFontColor, textFontColor, previousBackgroundColor, textBackgroundColor, previousHighlightURL, previousLanguage, previousJumpListActivated);

            return true;
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool CheckProxyStatusReturn(Options form)
        {
            CheckBox enableProxySettingsCheckBox = form.enableProxySettingsCheckBox;
            TextBox usernameTextBox = form.usernameTextBox;
            TextBox passwordTextBox = form.passwordTextBox;
            TextBox domainTextBox = form.domainTextBox;
            const int timeout = 10;

            if (!enableProxySettingsCheckBox.Checked || String.IsNullOrEmpty(passwordTextBox.Text) || String.IsNullOrEmpty(passwordTextBox.Text))
            {
                return false;
            }

            try
            {
                WebRequest webRequest = WebRequest.Create("http://www.google.com/");
                webRequest = ProxyUtil.InitWebRequestProxy(webRequest, true, usernameTextBox.Text, passwordTextBox.Text, domainTextBox.Text);
                webRequest.Timeout = timeout * 1000;
                return true;
            }
            catch (TimeoutException)
            {
                WindowManager.ShowAlertBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("ConnectionTimeout", className), timeout));
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion Private Methods
    }
}
