using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;
using DtPad.Validators;
using ICSharpCode.SharpZipLib.Zip;

namespace DtPad
{
    /// <summary>
    /// Main DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Form1 : CustomForm
    {
        private Thread newThread;
        private delegate void ThreadCallBack();

        internal Form1()
        {
            IsOpening = true;
            SplashWindow = WindowManager.ShowSplash();

            InitializeComponent();
            PreInitializeForm();
            InitializeForm();
            SetLanguage(false);
            OpenFiles(Environment.GetCommandLineArgs());
            IsOpening = false;
        }

        internal void OpenFiles(String[] commandLine)
        {
            ProgramUtil.DtPadStart(this, commandLine);
        }

        #region Window Methods

        private void InitializeForm()
        {
            WindowManager.CheckSearchReplacePanel(this, ConfigUtil.GetBoolParameter("SearchReplacePanelDisabled"), false);
            WindowManager.CheckWordWrap(this, ConfigUtil.GetBoolParameter("WordWrapDisabled"), false);
            WindowManager.CheckStayOnTop(this, ConfigUtil.GetBoolParameter("StayOnTopDisabled"), false);
            WindowManager.CheckToolbar(this, ConfigUtil.GetBoolParameter("ToolbarInvisible"), true, false);
            WindowManager.CheckStatusBar(this, ConfigUtil.GetBoolParameter("StatusBarInvisible"), true, false);
            WindowManager.CheckTrayIcon(this, ConfigUtil.GetBoolParameter("MinimizeOnTrayIconDisabled"), false);
            WindowManager.CheckDefaultEncoding(this, ConfigUtil.GetBoolParameter("DefaultEncoding"), false);
            WindowManager.CheckEncoding(this, ConfigUtil.GetIntParameter("Encoding"), false);
            WindowManager.CheckLineNumbers(this, ConfigUtil.GetBoolParameter("LineNumbersVisible"), false);

            bool verticalContainerInvisible = ConfigUtil.GetBoolParameter("InternalExplorerInvisible");
            verticalSplitContainer.Panel2Collapsed = verticalContainerInvisible;
            internalExplorerToolStripMenuItem.Checked = !verticalContainerInvisible;
            verticalContainerToolStripButton.Checked = !verticalContainerInvisible;
            if (!verticalSplitContainer.Panel2Collapsed)
            {
                NoteManager.GetNotesList(this);
            }
            if (searchReplacePanel.Visible)
            {
                searchPanel.caseCheckBox.Checked = ConfigUtil.GetBoolParameter("SearchCaseSensitive");
            }

            pageTextBox.Font = TextFont;
            customLineNumbers.Font = TextFont;
            pageTextBox.ForeColor = TextFontColor;
            pageTextBox.BackColor = TextBackgroundColor;
            customLineNumbers.BackColor = TextBackgroundColor;
            pageTextBox.DetectUrls = ConfigUtil.GetBoolParameter("HighlightURL");

            recentFilesToolStripMenuItem.DropDown.ItemAdded += recentFilesToolStripMenuItem_DropDown_ItemRefreshed;
            recentFilesToolStripMenuItem.DropDown.ItemRemoved += recentFilesToolStripMenuItem_DropDown_ItemRefreshed;
            favouriteFilesToolStripMenuItem.DropDown.ItemAdded += favouriteFilesToolStripMenuItem_DropDown_ItemRefreshed;
            favouriteFilesToolStripMenuItem.DropDown.ItemRemoved += favouriteFilesToolStripMenuItem_DropDown_ItemRefreshed;
            openToolStripSplitButton.DropDown.Enabled = openToolStripSplitButton.HasDropDownItems;
            //favouriteFilesToolStripDropDownButton.Enabled = favouriteFilesToolStripDropDownButton.HasDropDownItems;
            favouriteFilesToolStripDropDownButton.Enabled = FileListManager.ExistsFavouriteFile();

            LookFeelUtil.SetForm1LookAndFeel(this, true);

            OptionManager.CheckTabCloseButton(this, ConfigUtil.GetIntParameter("TabCloseButtonMode"));
            OptionManager.CheckTabPosition(this, ConfigUtil.GetIntParameter("TabPosition"));
            OptionManager.CheckTabOrientation(this, ConfigUtil.GetIntParameter("TabOrientation"));
            OptionManager.CheckTabMultiline(this, ConfigUtil.GetBoolParameter("TabMultiline"));

            ClipboardToggleManager.ToggleClipboardOnClick(this, true);
            SystemUtil.SetWindowsJumpList(this);
            SetFamilyEdition();

            WindowManager.CloseSplash(SplashWindow);
            //SplashWindow = null;

            pageTextBox.Select();
        }

        //[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        //[SecurityCritical]
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0x0F020;

            if (m.Msg != WM_SYSCOMMAND || m.WParam.ToInt32() != SC_MINIMIZE)
            {
                base.WndProc(ref m);
            }
            else if (!minimizeOnTrayIconToolStripMenuItem.Checked)
            {
                PreviousWindowState = WindowState;
                base.WndProc(ref m);
            }
            else
            {
                PreviousWindowState = WindowState;

                notifyIcon.Visible = true;
                Visible = false;

                String notifyIconText = "DtPad " + Environment.NewLine + TabManager.GetTabTitles(this, 5, false);
                if (notifyIconText.Length > ConstantUtil.maxLenghtTrayDescription)
                {
                    notifyIconText = notifyIconText.Substring(0, ConstantUtil.maxLenghtTrayDescription - 3) + "...";
                }
                notifyIcon.Text = notifyIconText;

                if (!ConfigUtil.GetBoolParameter("TrayBalloonTipShown"))
                {
                    notifyIcon.ShowBalloonTip(5);
                    ConfigUtil.UpdateParameter("TrayBalloonTipShown", true.ToString());
                }

                FileListManager.LoadTrayRecentFiles(this);
                recentFilesToolStripMenuItem1.Enabled = recentFilesToolStripMenuItem1.DropDownItems.Count != 0;
            }
        }

        private void Form1_HandleCreated(object sender, EventArgs e)
        {
            if (!VersionCheckManager.IsPeriodicVersionCheckToRun())
            {
                return;
            }
            newThread = new Thread(CheckVersion);
            newThread.IsBackground = true;
            newThread.Start();
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            String[] parameterNames;
            String[] parameterValues;

            OtherManager.FocusOnEditor(this);

            if (NoteModeManager.IsWindowInNoteMode(this))
            {
                NoteModeManager.NoteModeOff(this);
                e.Cancel = true;
                return;
            }
            if (WindowManager.IsWindowInFullScreenMode(this))
            {
                WindowManager.CloseFullScreen(this);
            }

            switch (WindowState)
            {
                case FormWindowState.Maximized:
                    parameterNames = new String[1];
                    parameterValues = new String[1];
                    parameterNames[0] = "WindowState";
                    parameterValues[0] = WindowState.ToString();
                    break;
                case FormWindowState.Normal:
                    parameterNames = new String[3];
                    parameterValues = new String[3];
                    parameterNames[0] = "WindowState";
                    parameterValues[0] = WindowState.ToString();
                    parameterNames[1] = "WindowSizeX";
                    parameterValues[1] = Size.Width.ToString();
                    parameterNames[2] = "WindowSizeY";
                    parameterValues[2] = Size.Height.ToString();
                    break;
                default:
                    parameterNames = new String[1];
                    parameterValues = new String[1];
                    parameterNames[0] = "WindowState";
                    parameterValues[0] = FormWindowState.Normal.ToString();
                    break;
            }

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                if (!tabPage.Text.StartsWith("*"))
                {
                    continue;
                }

                TrayManager.RestoreFormIfIsInTray(this);

                DialogResult dialogResult = WindowManager.ShowQuestionCancelBox(this, LanguageUtil.GetCurrentLanguageString("Closing", Name));
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        if (!FileManager.SaveCloseAllFiles(this))
                        {
                            e.Cancel = true;
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }

                if (SessionManager.CheckSessionOnClosing(this, true) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

                ConfigUtil.UpdateParameters(parameterNames, parameterValues);
                ClipboardManager.ClearClipboardFile(this);
                InternetManager.ClearInternetCache(this);

                return;
            }

            if (SessionManager.CheckSessionOnClosing(this, true) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }

            ConfigUtil.UpdateParameters(parameterNames, parameterValues);
            ClipboardManager.ClearClipboardFile(this);
            InternetManager.ClearInternetCache(this);
        }

        private void toolsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (!ToolsFirstLoadExecuted)
            {
                FileListManager.LoadTools(this);
            }
        }

        private void favouriteFilesToolStripDropDownButton_DropDownOpening(object sender, EventArgs e)
        {
            FileListManager.LoadFavouriteFiles(this, false, true);
        }

        private void openToolStripSplitButton_DropDownOpening(object sender, EventArgs e)
        {
            FileListManager.LoadRecentFiles(this, false, true);
        }

        private void favouriteFilesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            FileListManager.LoadFavouriteFiles(this, false);
        }

        private void recentFilesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            FileListManager.LoadRecentFiles(this, false);
        }

        private void recentSessionsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            FileListManager.LoadRecentSessions(this, false);
        }

        private void verticalTabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page == fileExplorerTabPage)
            {
                FileExplorerManager.LoadFileTree(this, false);
            }
            else if (e.Page == clipboardTabPage)
            {
                ClipboardManager.GetClipboardList(this, false);
            }
            else if (e.Page == tabExplorerTabPage)
            {
                ExplorerManager.InitializeTabExplorer(this);
            }
        }

        private void pagesTabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            CustomRichTextBox selectedPageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            TabManager.TabSelection(this);
            TextManager.RefreshUndoRedoExternal(this);
            TabManager.ZoomSelect(this, selectedPageTextBox.CustomZoom);
            TabManager.TabKeyUp(this);
            ExplorerManager.SelectTreeNodeFromTabControl(this, pagesTabControl.SelectedTabPage.Name);
            ClipboardToggleManager.ToggleClipboardOnClick(this, false);
        }

        private void pagesTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs eDevExpress = (ClosePageButtonEventArgs)e;
            pagesTabControl.SelectedTabPage = (XtraTabPage)eDevExpress.Page;
            TabManager.ClosePage(this);
        }

        internal void favouriteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String fileName = sender.ToString();
            if (fileName.StartsWith(ConstantUtil.sessionPrefix))
            {
                fileName = fileName.Substring(ConstantUtil.sessionPrefix.Length);
            }

            TabIdentity = FileManager.OpenFile(this, TabIdentity, new[] { fileName });
        }

        internal void recentFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabIdentity = FileManager.OpenFile(this, TabIdentity, new[] { sender.ToString() });
        }

        internal void recentSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionManager.OpenSession(this, sender.ToString());
        }

        internal void historyToolStripDropDownButton_Click(object sender, EventArgs e)
        {
            searchPanel.searchTextBox.Text = ((ToolStripMenuItem)sender).Tag.ToString();
            SearchManager.SearchNextFactory(this);
        }

        internal void recentFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabIdentity = FileManager.OpenFile(this, TabIdentity, new[] { sender.ToString() });
            TrayManager.RestoreFormFromTray(this, PreviousWindowState);
        }

        private void recentFilesToolStripMenuItem_DropDown_ItemRefreshed(object sender, ToolStripItemEventArgs e)
        {
            FileListManager.LoadSplitRecentFiles(this);
        }

        private void favouriteFilesToolStripMenuItem_DropDown_ItemRefreshed(object sender, ToolStripItemEventArgs e)
        {
            FileListManager.LoadSplitFavouriteFiles(this);
        }

        private void prefixToolStripTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (prefixToolStripTextBox.Text != LanguageUtil.GetCurrentLanguageString("prefixToolStripTextBox", Name))
            {
                return;
            }

            prefixToolStripTextBox.Text = String.Empty;
            prefixToolStripTextBox.ForeColor = SystemColors.WindowText;
        }

        private void prefixToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(prefixToolStripTextBox.Text))
            {
                return;
            }

            prefixToolStripTextBox.Text = LanguageUtil.GetCurrentLanguageString("prefixToolStripTextBox", Name);
            prefixToolStripTextBox.ForeColor = SystemColors.ControlDark;
        }

        private void prefixToolStripComboBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(prefixToolStripComboBox.Text) && prefixToolStripComboBox.Text != LanguageUtil.GetCurrentLanguageString("prefixToolStripComboBox", Name))
            {
                prefixToolStripButton.Enabled = true;
                removePrefixToolStripMenuItem1.Enabled = true;
                insertSuffixToolStripMenuItem.Enabled = true;
                removeSuffixToolStripMenuItem1.Enabled = true;
            }
            else
            {
                prefixToolStripButton.Enabled = false;
                removePrefixToolStripMenuItem1.Enabled = false;
                insertSuffixToolStripMenuItem.Enabled = false;
                removeSuffixToolStripMenuItem1.Enabled = false;
            }
        }

        private void prefixToolStripComboBox_Enter(object sender, EventArgs e)
        {
            ClipboardToggleManager.ToggleClipboardOnClick(this, false);

            if (prefixToolStripComboBox.Text != LanguageUtil.GetCurrentLanguageString("prefixToolStripComboBox", Name))
            {
                return;
            }

            prefixToolStripComboBox.Text = String.Empty;
            prefixToolStripComboBox.ForeColor = SystemColors.WindowText;
            prefixToolStripComboBox.Font = new Font("Tahoma", 8.25F);
        }

        private void prefixToolStripComboBox_Leave(object sender, EventArgs e)
        {
            ClipboardToggleManager.DisableClipboardOnClick(this);

            if (!String.IsNullOrEmpty(prefixToolStripComboBox.Text))
            {
                return;
            }

            prefixToolStripComboBox.Text = LanguageUtil.GetCurrentLanguageString("prefixToolStripComboBox", Name);
            prefixToolStripComboBox.ForeColor = SystemColors.ControlDark;
            prefixToolStripComboBox.Font = new Font("Tahoma", 8.25F, FontStyle.Italic);
        }

        private void suffixToolStripTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (suffixToolStripTextBox.Text != LanguageUtil.GetCurrentLanguageString("suffixToolStripTextBox", Name))
            {
                return;
            }

            suffixToolStripTextBox.Text = String.Empty;
            suffixToolStripTextBox.ForeColor = SystemColors.WindowText;
        }

        private void suffixToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(suffixToolStripTextBox.Text))
            {
                return;
            }

            suffixToolStripTextBox.Text = LanguageUtil.GetCurrentLanguageString("suffixToolStripTextBox", Name);
            suffixToolStripTextBox.ForeColor = SystemColors.ControlDark;
        }

        internal void filenameTabPage_TextChanged(object sender, EventArgs e)
        {
            Label localFilenameTabPage = (Label)sender;

            XtraTabPage tabPage = (XtraTabPage)localFilenameTabPage.Parent;
            tabPage.Tooltip = localFilenameTabPage.Text;
        }

        internal void newToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem newToolToolStripMenuItem = (ToolStripMenuItem)sender;

            OtherManager.StartProcessInfoWithInit(this, newToolToolStripMenuItem.ToolTipText, newToolToolStripMenuItem.Tag.ToString(),
            ToolManager.GetProcessWindowStyleFromRun(newToolToolStripMenuItem.AccessibleDescription));
        }

        private void verticalContainerToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.CheckInternalExplorer(this, !verticalContainerToolStripButton.Checked, true);
        }

        private void internalExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.CheckInternalExplorer(this, !internalExplorerToolStripMenuItem.Checked, true);
        }

        internal void tabPage_TextChanged(object sender, EventArgs e)
        {
            ExplorerManager.TabPage_TextChanged(this, sender);
        }

        private void zoomTrackBarControl_EditValueChanged(object sender, EventArgs e)
        {
            TabManager.ZoomSelect(this, null);
        }

        private void useOriginalToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            WindowManager.CheckDefaultEncoding(this, useOriginalToolStripMenuItem.Checked, true);
        }

        private void defaultToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            WindowManager.CheckEncoding(this, e.ClickedItem, true);
        }

        private void pagesTabControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TabManager.TabMouseDoubleClick(this, e);
        }

        private void statisticsToolStripDropDownButton_DropDownOpening(object sender, EventArgs e)
        {
            TabManager.RefreshStatistics(this);
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            ClipboardToggleManager.ToggleClipboard(this);
        }

        private void searchContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            ClipboardToggleManager.ToggleUndoOnTextBox(this);
        }

        private void prefixToolStripTextBox_Enter(object sender, EventArgs e)
        {
            ClipboardToggleManager.ToggleClipboardOnClick(this, false);
        }

        private void prefixToolStripTextBox_Leave(object sender, EventArgs e)
        {
            ClipboardToggleManager.DisableClipboardOnClick(this);
        }

        private void suffixToolStripTextBox_Enter(object sender, EventArgs e)
        {
            ClipboardToggleManager.ToggleClipboardOnClick(this, false);
        }

        private void suffixToolStripTextBox_Leave(object sender, EventArgs e)
        {
            ClipboardToggleManager.DisableClipboardOnClick(this);
        }

        private void templatesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            FileListManager.LoadTemplates(this);
        }

        private void templatesToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            TemplateManager.ClearTemplatesMenu(this);
        }

        private void useDefaultToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            SessionManager.UseDefaultAspectChanged(this);
        }

        private void closeButtonToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SessionManager.OnlyOneDropDownItemCheckedOnce(this, closeButtonToolStripMenuItem, (ToolStripMenuItem)e.ClickedItem);
        }

        private void tabPositionToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SessionManager.OnlyOneDropDownItemCheckedOnce(this, tabPositionToolStripMenuItem, (ToolStripMenuItem)e.ClickedItem);
        }

        private void tabOrientationToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SessionManager.OnlyOneDropDownItemCheckedOnce(this, tabOrientationToolStripMenuItem, (ToolStripMenuItem)e.ClickedItem);
        }

        internal void Zip_Errors(TestStatus test, String error)
        {
            if (test.ErrorCount <= 0 || String.IsNullOrEmpty(error))
            {
                return;
            }
            if (!error.EndsWith("."))
            {
                error += ".";
            }

            WindowManager.ShowAlertBox(this, LanguageUtil.GetCurrentLanguageString("ZipError", Name) + Environment.NewLine + error);
        }

        private void viewToolStripMenuItem_Opening(object sender, EventArgs e)
        {
            hostsFileConfiguratorToolStripMenuItem.Checked = CustomFilesManager.IsHostsSectionPanelOpen(this);
            annotationPanelToolStripMenuItem.Checked = CustomFilesManager.IsAnnotationPanelOpen(this);
            columnNumbersToolStripMenuItem2.Checked = ColumnRulerManager.IsPanelOpen(this);
        }

        internal void sessionImageToolStripButton_Click(object sender, EventArgs e)
        {
            TabManager.SelectTabByOpenedFileName(this, sender.ToString());
        }

        private void pagesTabControl_CustomHeaderButtonClick(object sender, CustomHeaderButtonEventArgs e)
        {
            if (!verticalContainerToolStripButton.Checked)
            {
                WindowManager.CheckInternalExplorer(this, !verticalContainerToolStripButton.Checked, true);
            }

            verticalTabControl.SelectedTabPage = tabExplorerTabPage;
        }

        private void dictionaryToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            dictionaryClearToolStripMenuItem.Enabled = RichTextBoxUtil.ContainsUnderlineText(ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage));
        }

        #endregion Window Methods

        #region Clipboard Methods

        private void prefixToolStripComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            WindowManager.FocusOnRightClick(prefixToolStripComboBox, e);
        }

        #endregion Clipboard Methods

        #region Menu Methods

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabIdentity = TabManager.AddNewPage(this, TabIdentity);
        }

        private void newAndPasteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ProgramUtil.OpenNewTabAndPaste(this);
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabManager.ClosePage(this);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.CloseAllPages(this);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabIdentity = FileManager.OpenFile(this, TabIdentity);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.SaveFile(this, false);
        }

        private void saveWithEncodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowTabEncoding(this);
        }

        private void saveWithBackupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileManager.SaveFile(this, false, true);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.SaveFile(this, true);
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.SaveAllFiles(this);
        }

        private void saveAllAsZipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZipManager.SaveAllFilesAsZip(this);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFileRename(this, FileRename.FileTypes.Text, ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage));
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.ReloadFile(this, TabIdentity);
        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument = PrintManager.PageSetup(this, PrintDocument);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument = PrintManager.PrintPreview(this, PrintDocument);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument = PrintManager.Print(this, PrintDocument);
        }

        private void filePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFileProperties(this, ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage));
        }

        private void addCurrentFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileListManager.SetNewFavouriteFile(this, ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage));
        }

        private void manageFavouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFavourites(this);
        }

        private void clearFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileListManager.ClearRecentFiles(this);
        }

        private void clearObsoleteFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileListManager.ClearObsoleteRecentFiles(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.UndoRich(this);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.RedoRich(this);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.Cut(this);
        }

        private void cutAppendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CutAppend(this);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.Copy(this);
        }

        private void copyAppendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyAppend(this);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.Paste(this);
        }

        private void pasteSpecialHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.PasteSpecial(this, TextManager.SpecialPaste.HTML);
        }

        private void pasteSpecialRtfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.PasteSpecial(this, TextManager.SpecialPaste.HTML);
        }

        private void swapWithClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SwapWithClipboard(this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.Delete(this);
        }

        private void deleteLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.DeleteLine(this);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAll(this);
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowGoToLine(this);
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowDatetimeSelectWindow(this);
        }

        private void toUppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ToUppercase(this);
        }

        private void toLowercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ToLowercase(this);
        }

        private void toInitialUppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ToInitialUppercase(this);
        }

        private void showSearchPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.CheckSearchReplacePanel(this, showSearchPanelToolStripMenuItem.Checked, true);
        }

        private void findFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchManager.SearchFirstFactory(this);
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchManager.SearchNextFactory(this);
        }

        private void findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchManager.SearchPreviousFactory(this);
        }

        private void findLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchManager.SearchLastFactory(this);
        }

        private void countOccurencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchManager.SearchCountFactory(this);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchManager.ReplaceNextFactory(this);
        }

        private void replacePreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchManager.ReplacePreviousFactory(this);
        }

        private void replaceAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceManager.ReplaceAll(this); //SearchManager.ReplaceAllFactory(this);
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowMergeTabs(this);
        }

        private void appendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.AppendFileContent(this);
        }

        private void indentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.IndentSelectedLines(this);
        }

        private void outdentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.OutdentSelectedLines(this);
        }

        private void tabSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ConvertChar(this, "\t", ConstantUtil.tabIntoSpaces);
        }

        private void spacesTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ConvertChar(this, ConstantUtil.tabIntoSpaces, "\t");
        }

        private void tabToReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ConvertChar(this, "\t", ConstantUtil.newLine);
        }

        private void returnToSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ConvertChar(this, ConstantUtil.newLine, " ");
        }

        private void returnToTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ConvertChar(this, ConstantUtil.newLine, "\t");
        }

        private void doubleTabToTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ConvertChar(this, "\t\t", "\t");
        }

        private void doubleSpacesSpacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ConvertChar(this, "  ", " ");
        }

        private void doubleReturnToReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ConvertChar(this, String.Format("{0}{1}", ConstantUtil.newLine, ConstantUtil.newLine), ConstantUtil.newLine);
        }

        private void addPrefixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(prefixToolStripTextBox.Text) || prefixToolStripTextBox.Text == LanguageUtil.GetCurrentLanguageString("prefixToolStripTextBox", Name))
            {
                WindowManager.ShowInfoBox(this, LanguageUtil.GetCurrentLanguageString("SpecifyPrefix", Name));
                return;
            }

            TextManager.InsertInitialString(this, prefixToolStripTextBox.Text);
        }

        private void removePrefixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(prefixToolStripTextBox.Text) || prefixToolStripTextBox.Text == LanguageUtil.GetCurrentLanguageString("prefixToolStripTextBox", Name))
            {
                WindowManager.ShowInfoBox(this, LanguageUtil.GetCurrentLanguageString("SpecifyPrefix", Name));
                return;
            }

            TextManager.RemoveInitialString(this, prefixToolStripTextBox.Text);
        }

        private void addSuffixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(suffixToolStripTextBox.Text) || suffixToolStripTextBox.Text == LanguageUtil.GetCurrentLanguageString("suffixToolStripTextBox", Name))
            {
                WindowManager.ShowInfoBox(this, LanguageUtil.GetCurrentLanguageString("SpecifySuffix", Name));
                return;
            }
            
            TextManager.InsertFinalString(this, suffixToolStripTextBox.Text);
        }

        private void removeSuffixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(suffixToolStripTextBox.Text) || suffixToolStripTextBox.Text == LanguageUtil.GetCurrentLanguageString("prefixToolStripTextBox", Name))
            {
                WindowManager.ShowInfoBox(this, LanguageUtil.GetCurrentLanguageString("SpecifySuffix", Name));
                return;
            }

            TextManager.RemoveFinalString(this, suffixToolStripTextBox.Text);
        }

        private void selectedLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowMoveLines(this);
        }

        private void oneLineUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.MoveSelectedLineUp(this, 1);
        }

        private void oneLineDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.MoveSelectedLineDown(this, 1);
        }

        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.CheckDefaultEncoding(this, true, true);
            WindowManager.CheckEncoding(this, 2, true);
        }

        private void fileExtensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowExtensions(this);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowOptions(this);
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.CheckWordWrap(this, wordWrapToolStripMenuItem.Checked, true);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.FontPages(this);
        }

        private void exportPreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportExportManager.ExportOptions(this);
        }

        private void importPreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportExportManager.ImportOptions(this);
        }

        internal void addNewToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowTools(this);
        }

        private void nextTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.MoveToNextTab(this);
        }

        private void previousTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.MoveToPreviousTab(this);
        }

        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.CheckToolbar(this, toolbarToolStripMenuItem.Checked, false, true);
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.CheckStatusBar(this, statusBarToolStripMenuItem.Checked, false, true);
        }

        private void promptWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherManager.StartProcess(this, "cmd.exe");
        }

        private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.CheckStayOnTop(this, stayOnTopToolStripMenuItem.Checked, true);
        }

        private void minimizeOnTrayIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.CheckTrayIcon(this, minimizeOnTrayIconToolStripMenuItem.Checked, true);
        }

        private void readmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabIdentity = FileManager.OpenFile(this, TabIdentity, new[] { Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.readme) }, false);
        }

        private void licenseAgreementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabIdentity = FileManager.OpenFile(this, TabIdentity, new[] { Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.license) }, false);
        }

        private void checkForNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowVersionCheck(this);
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowReportBug(this);
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowStatistics(this);
        }

        private void diarioDiUnTraduttoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherManager.StartProcessBrowser(this, ConstantUtil.dtURL);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowAbout(this);
        }

        private void lineNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.CheckLineNumbers(this, !lineNumbersToolStripMenuItem.Checked, true);
        }

        private void columnNumbersToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ColumnRulerManager.TogglePanel(this);
        }

        private void resetWindowLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ResetMainWindow(this);
        }

        private void textToHTMLPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternetManager.ConvertTextToHtml(this);
        }

        private void htmlToTextPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternetManager.ConvertHtmlToText(this);
        }

        private void rOT13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.Rot13Transform(this);
        }

        private void toggleReadonlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.ToggleReadonly(this);
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.DeleteFile(this);
        }

        private void saveAsPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.SaveAsPdf(this);
        }

        private void showFileInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternetManager.ShowFileInBrowser(this);
        }

        private void focusOnEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherManager.FocusOnEditor(this);
        }

        private void closeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SessionManager.CloseSession(this);
        }

        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SessionManager.OpenSession(this);
        }

        private void saveToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SessionManager.SaveSession(this, false);
        }

        private void saveAsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SessionManager.SaveSession(this, true);
        }

        private void exportAsZipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionManager.ExportSessionAsZip(this);
        }

        internal void sessionPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFileProperties(this, sessionImageToolStripButton.DropDownItems[0].Text, true);
        }

        private void clearSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileListManager.ClearRecentSessions(this);
        }

        private void clearObsoleteSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileListManager.ClearObsoleteRecentSessions(this);
        }

        private void insertSpecialCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowSpecialChars(this);
        }

        private void takeTabScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.TakeTabControlScreenshot(this);
        }

        private void sortTabsAlphabeticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.SortTabsAlphabetically(this);
        }

        private void padTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowPadText(this);
        }

        private void sortTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowSortText(this);
        }

        private void showTabAsNoteOnTopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NoteModeManager.NoteModeOn(this);
        }

        private void compareTabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFileCompare(this);
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlValidator.Validate(this, ValidationType.DTD);
        }

        private void xMLSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlValidator.Validate(this, ValidationType.Schema);
        }

        private void w3CHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            W3CValidator.ValidateHtml(this);
        }

        private void w3CCSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            W3CValidator.ValidateCss(this);
        }

        internal void addNewTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowTemplates(this);
        }

        internal void newTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemplateManager.GetTemplate(this, ((ToolStripMenuItem)sender).Tag.ToString());
        }

        private void welcomeScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowWelcome(this, true);
        }

        private void exadecimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowHexEditor(this);
        }

        private void duplicateLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchManager.SearchDuplicatedLines(this);
        }

        private void linesWithoutDuplidatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchManager.SearchLinesWithoutDuplicated(this);
        }

        private void gUIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.InsertGUID(this);
        }

        private void randomNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.InsertRandomNumber(this);
        }

        private void tagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowTagEntry(this);
        }

        private void rowNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.InsertRowNumbers(this);
        }

        private void columnNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.InsertColumnNumbers(this);
        }

        private void selectCurrentLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectCurrentLine(this);
        }

        private void selectLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowSelectLines(this);
        }

        private void renameSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFileRename(this, FileRename.FileTypes.Session, sessionImageToolStripButton.DropDownItems[0].Text);
        }

        private void favouriteSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileListManager.SetNewFavouriteFile(this, ConstantUtil.sessionPrefix + sessionImageToolStripButton.DropDownItems[0].Text);
        }

        private void listFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionManager.ListSessionFiles(this);
        }

        private void emailAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegularExpressionValidator.Validate(this, RegularExpressionValidator.RegularExpression.Email);
        }

        private void hTMLTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegularExpressionValidator.Validate(this, RegularExpressionValidator.RegularExpression.HtmlTag);
        }

        private void iPAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegularExpressionValidator.Validate(this, RegularExpressionValidator.RegularExpression.Ip);
        }

        private void capitalizedWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegularExpressionValidator.Validate(this, RegularExpressionValidator.RegularExpression.CapitalizedWords);
        }

        private void xMLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormatManager.FormatXml(this);
        }

        private void customPatternsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowSearchPattern(this);
        }

        private void searchInFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowSearchInFiles(this);
        }

        private void xmlTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowXmlEditor(this);
        }

        private void showHiddenCharsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.ShowHiddenChars(this);
        }

        private void dictionaryWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DictionaryManager.OpenDictionaryWindow(this, pagesTabControl);
        }

        private void dictionaryTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DictionaryManager.CheckTextCorrectness(this, LanguageUtil.GetReallyShortCulture());
        }

        private void dictionaryClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DictionaryManager.ClearTextCorrectness(ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage));
        }

        private void translateSelectedTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InternetServicesManager.ShowGoogleTranslation(this);
        }

        private void searchInGoogleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternetServicesManager.SearchTextInGoogle(this, InternetServicesManager.SearchProvider.Google);
        }

        private void searchInWikipediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternetServicesManager.SearchTextInGoogle(this, InternetServicesManager.SearchProvider.Wikipedia);
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.CloseFullScreen(this);
        }

        private void fullScreenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFullScreen(this);
        }

        private void hTMLTableTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowHtmlTags(this);
        }

        private void urlEncoderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowUrlEncode(this);
        }

        private void normalizeXMLToolStripMenuItemClick(object sender, EventArgs e)
        {
            XmlValidator.Normalize(this);
        }

        internal void hostsFileConfiguratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomFilesManager.ToggleHostsSectionPanel(this);
        }

        internal void annotationPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomFilesManager.ToggleAnnotationPanel(this);
        }

        internal void helpHostsFileConfiguratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomFilesManager.ShowHostsHelp(this);
        }

        internal void helpAnnotationPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomFilesManager.ShowAnnotationHelp(this);
        }

        internal void wordWrapAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomFilesManager.CheckAnnotationWordWrap(this, (ToolStripMenuItem)sender);
        }

        private void openWebPageSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowUrlEntry(this);
        }

        private void fileOnDropboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowDropboxFileDialog(this, DropboxFileDialog.WindowType.Save);
        }

        private void openFileOnDropboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowDropboxFileDialog(this, DropboxFileDialog.WindowType.Open);
        }

        #endregion Menu Methods

        #region Toolbar Methods

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            TabIdentity = TabManager.AddNewPage(this, TabIdentity);
        }

        private void closeToolStripButton_Click(object sender, EventArgs e)
        {
            TabManager.ClosePage(this);
            TextManager.RefreshUndoRedoExternal(this);
        }

        private void openToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            TabIdentity = FileManager.OpenFile(this, TabIdentity);
        }

        private void openFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFileListOpen(this);
        }

        private void saveToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            FileManager.SaveFile(this, false);
        }

        private void saveWithEncodingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowManager.ShowTabEncoding(this);
        }

        private void saveWithBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.SaveFile(this, false, true);
        }

        private void saveAsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FileManager.SaveFile(this, true);
        }

        private void saveAllToolStripButton_Click(object sender, EventArgs e)
        {
            FileManager.SaveAllFiles(this);
        }

        private void dropboxToolStripDropDownButton_DropDownOpening(object sender, EventArgs e)
        {
            logoutFromDropboxToolStripMenuItem.Enabled = DropboxManager.IsCloudStorageOpen(DropboxCloudStorage);
        }

        private void openFromDropboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowDropboxFileDialog(this, DropboxFileDialog.WindowType.Open);
        }

        private void saveOnDropboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowDropboxFileDialog(this, DropboxFileDialog.WindowType.Save);
        }

        private void logoutFromDropboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DropboxManager.CloseCouldStorage(this, DropboxCloudStorage);
        }

        private void undoToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            TextManager.UndoRich(this);
        }

        private void undoAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.UndoAllRich(this);
        }

        private void redoToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            TextManager.RedoRich(this);
        }

        private void redoAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.RedoAllRich(this);
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            TextManager.Cut(this);
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            TextManager.Copy(this);
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            TextManager.Paste(this);
        }

        private void outdentToolStripButton_Click(object sender, EventArgs e)
        {
            TextManager.OutdentSelectedLines(this);
        }

        private void indentToolStripButton_Click(object sender, EventArgs e)
        {
            TextManager.IndentSelectedLines(this);
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            PrintDocument = PrintManager.Print(this, PrintDocument);
        }

        private void showSearchPanelToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.CheckSearchReplacePanel(this, showSearchPanelToolStripMenuItem.Checked, true);
        }

        private void mergeTabsToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.ShowMergeTabs(this);
        }

        private void appendFileToolStripButton_Click(object sender, EventArgs e)
        {
            FileManager.AppendFileContent(this);
        }

        private void moveLinesUpDownToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            WindowManager.ShowMoveLines(this);
        }

        private void oneLineUpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.MoveSelectedLineUp(this, 1);
        }

        private void oneLineDownToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.MoveSelectedLineDown(this, 1);
        }

        private void prefixToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(prefixToolStripComboBox.Text))
            {
                return;
            }
            if (!prefixToolStripComboBox.Items.Contains(prefixToolStripComboBox.Text))
            {
                prefixToolStripComboBox.Items.Add(prefixToolStripComboBox.Text);
            }

            TextManager.InsertInitialString(this, prefixToolStripComboBox.Text);
        }

        private void removePrefixToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(prefixToolStripComboBox.Text))
            {
                return;
            }
            if (!prefixToolStripComboBox.Items.Contains(prefixToolStripComboBox.Text))
            {
                prefixToolStripComboBox.Items.Add(prefixToolStripComboBox.Text);
            }

            TextManager.RemoveInitialString(this, prefixToolStripComboBox.Text);
        }

        private void insertSuffixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(prefixToolStripComboBox.Text))
            {
                return;
            }
            if (!prefixToolStripComboBox.Items.Contains(prefixToolStripComboBox.Text))
            {
                prefixToolStripComboBox.Items.Add(prefixToolStripComboBox.Text);
            }

            TextManager.InsertFinalString(this, prefixToolStripComboBox.Text);
        }

        private void removeSuffixToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(prefixToolStripComboBox.Text))
            {
                return;
            }
            if (!prefixToolStripComboBox.Items.Contains(prefixToolStripComboBox.Text))
            {
                prefixToolStripComboBox.Items.Add(prefixToolStripComboBox.Text);
            }

            TextManager.RemoveFinalString(this, prefixToolStripComboBox.Text);
        }

        private void dictionaryToolStripButton_Click(object sender, EventArgs e)
        {
            DictionaryManager.OpenDictionaryWindow(this, pagesTabControl);
        }

        private void searchInFilesToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.ShowSearchInFiles(this);
        }

        private void optionsToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.ShowOptions(this);
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.ShowAbout(this);
        }

        private void stayOnTopToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.CheckStayOnTop(this, stayOnTopToolStripButton.Checked, true);
        }

        private void lineNumbersToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.CheckLineNumbers(this, !lineNumbersToolStripMenuItem.Checked, true);
        }

        private void wordWrapToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.CheckWordWrap(this, wordWrapToolStripButton.Checked, true);
        }

        private void insertSpecialCharToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.ShowSpecialChars(this);
        }

        private void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowXmlEditor(this);
        }

        private void validationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            XmlValidator.Validate(this, ValidationType.DTD);
        }

        private void validationSchemaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            XmlValidator.Validate(this, ValidationType.Schema);
        }

        private void formatToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormatManager.FormatXml(this);
        }

        private void normalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlValidator.Normalize(this);
        }

        private void insertTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowTagEntry(this);
        }

        private void tagsTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowHtmlTags(this);
        }

        #endregion Toolbar Methods

        #region Session Toolbar Methods

        private void closeSessionToolStripButton_Click(object sender, EventArgs e)
        {
            SessionManager.CloseSession(this);
        }

        private void saveSessionToolStripButton_Click(object sender, EventArgs e)
        {
            SessionManager.SaveSession(this, false);
        }

        private void exportAsZipToolStripButton_Click(object sender, EventArgs e)
        {
            SessionManager.ExportSessionAsZip(this);
        }

        private void renameSessionToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFileRename(this, FileRename.FileTypes.Session, sessionImageToolStripButton.DropDownItems[0].Text);
        }

        private void favouriteSessionToolStripButton_Click(object sender, EventArgs e)
        {
            FileListManager.SetNewFavouriteFile(this, ConstantUtil.sessionPrefix + sessionImageToolStripButton.DropDownItems[0].Text);
        }

        #endregion Session Toolbar Methods

        #region Tray Methods

        private void restoreDtPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrayManager.RestoreFormFromTray(this, PreviousWindowState);
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProgramUtil.OpenNewTab(this);
        }

        private void newAndPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramUtil.OpenNewTabAndPaste(this);
        }
        
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProgramUtil.OpenFile(this);
        }

        private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TrayManager.RestoreFormFromTray(this, PreviousWindowState);
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Tray Methods

        #region Tab Context Methods

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TabIdentity = TabManager.AddNewPage(this, TabIdentity);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.ClosePage(this);
        }

        private void closeAllButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.CloseAllPagesButThis(this);
        }

        private void closeAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabManager.CloseAllPages(this);
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileManager.SaveFile(this, false);
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileManager.SaveFile(this, true);
        }

        private void renameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFileRename(this, FileRename.FileTypes.Text, ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage));
        }

        private void copyFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.CopyFileName(this);
        }

        private void copyFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.CopyFullPath(this);
        }

        private void openFileFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.OpenFileFolder(this);
        }

        private void openFileFolderPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.OpenFileFolderPrompt(this);
        }

        private void showTabAsNoteOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteModeManager.NoteModeOn(this);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowFileProperties(this, ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage));
        }

        private void setTabColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabManager.SetTabColor(pagesTabControl.SelectedTabPage, ((ToolStripMenuItem)sender).ForeColor);
        }

        #endregion Tab Context Methods

        #region TextBox Context Methods

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.Undo(this);
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.RedoRich(this);
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.Cut(this);
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.Copy(this);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.Paste(this);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.Delete(this);
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.SelectAll(this);
        }

        private void goToToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowManager.ShowGoToLine(this);
        }

        private void dictionaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DictionaryManager.OpenDictionaryWindow(this, pagesTabControl);
        }

        private void translateSelectedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternetServicesManager.ShowGoogleTranslation(this);
        }

        private void searchInGoogleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InternetServicesManager.SearchTextInGoogle(this, InternetServicesManager.SearchProvider.Google);
        }

        private void searchInWikipediaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InternetServicesManager.SearchTextInGoogle(this, InternetServicesManager.SearchProvider.Wikipedia);
        }

        #endregion TextBox Context Methods

        #region Search Context Methods

        private void undoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextManager.Undo(this);
        }

        private void cutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextManager.Cut(this);
        }

        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextManager.Copy(this);
        }

        private void pasteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextManager.Paste(this);
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextManager.Delete(this);
        }

        private void selectAllToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextManager.SelectAll(this);
        }

        #endregion Search Context Methods

        #region Internal Explorer Context Methods

        private void closeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            WindowManager.CheckInternalExplorer(this, !verticalContainerToolStripButton.Checked, true);
        }

        #endregion Internal Explorer Context Methods

        #region Multilanguage Methods

        internal void SetLanguage(bool isFormReloading)
        {
            LanguageUtil.SetCurrentLanguage(this, isFormReloading);

            notifyIcon.BalloonTipText = LanguageUtil.GetCurrentLanguageString("notifyIconBalloonTipText", Name);

            //LanguageUtil.CicleControls(Name, notifyIcon.ContextMenuStrip.Items);
            LanguageUtil.CicleControls(Name, pageContextMenuStrip.Items);
            LanguageUtil.CicleControls(Name, trayContextMenuStrip.Items);
            LanguageUtil.CicleControls(Name, textBoxContextMenuStrip.Items);
            LanguageUtil.CicleControls(Name, searchContextMenuStrip.Items);
            LanguageUtil.CicleControls(Name, internalExplorerContextMenuStrip.Items);

            //if (!verticalSplitContainer.Panel2Collapsed)
            //{
            notePanel.SetLanguage();
            clipboardPanel.SetLanguage();
            calculatorPanel.SetLanguage();
            filePanel.SetLanguage();
            tabPanel.SetLanguage();
            calendarPanel.SetLanguage();
            searchInFilesPanel.SetLanguage();
            //}
            searchPanel.SetLanguage();
        }

        #endregion Multilanguage Methods

        #region Version Check Methods

        private void CheckVersion()
        {
            WebException exception;

            if (VersionCheckManager.IsDtPadUpdated(out exception))
            {
				ConfigUtil.UpdateParameter("TryLastVersionCheck", "0");
            	ConfigUtil.UpdateParameter("LastVersionCheck", String.Format("{0}-{1}-{2}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day));
                return;
            }

            int tryCheck = ConfigUtil.GetIntParameter("TryLastVersionCheck");
            if (exception != null && tryCheck < 2)
            {
                ConfigUtil.UpdateParameter("TryLastVersionCheck", (tryCheck + 1).ToString());
                return;
            }
            if (exception != null)
            {
                WindowManager.ShowErrorBox(this, LanguageUtil.GetCurrentLanguageString("CheckVersionException", Name), exception);
            }

            ConfigUtil.UpdateParameter("TryLastVersionCheck", "0");
            ConfigUtil.UpdateParameter("LastVersionCheck", String.Format("{0}-{1}-{2}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day));

            if (exception == null)
            {
                Invoke(new ThreadCallBack(ShowMessage));
            }
        }

        private void ShowMessage()
        {
            if (WindowManager.ShowWarningBox(this, LanguageUtil.GetCurrentLanguageString("OutdatedVersion", Name)) == DialogResult.Yes)
            {
                WindowManager.ShowVersionCheck(this);
            }
        }

        #endregion Version Check Methods

        #region Private Methods

        private void SetFamilyEdition()
        {
            #if ReleaseFE
                diarioDiUnTraduttoreToolStripMenuItem.Visible = false;
            #endif
        }

        #endregion Private Methods
    }
}
