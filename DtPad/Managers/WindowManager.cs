using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DtControls;
using DtPad.Customs;
using DtPad.MessageBoxes;
using DtPad.Utils;
using DtPad.Validators;

namespace DtPad.Managers
{
    /// <summary>
    /// Window operations manager (ie. open new windows).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class WindowManager
    {
        private const String className = "WindowManager";

        #region Close Methods

        //internal static void CloseForm(Form1 form)
        //{
        //    //NotifyIcon notifyIcon = form.notifyIcon;

        //    //if (notifyIcon != null)
        //    //{
        //    //    TrayManager.RestoreFormFromTray(form, form.PreviousWindowState);
        //    //}
        //    //if (IsWindowInFullScreenMode(form))
        //    //{
        //    //    CloseFullScreen(form);
        //    //}

        //    form.Close();
        //}

        internal static void CloseForm(Form form)
        {
            form.Close();
        }

        internal static void CloseSplash(Splash splash)
        {
            if (!ConfigUtil.GetBoolParameter("ShowSplashScreen"))
            {
                return;
            }
            Application.DoEvents();

            splash.Close();
        }

        #endregion Close Methods

        #region Show Methods

        internal static Splash ShowSplash()
        {
            if (!ConfigUtil.GetBoolParameter("ShowSplashScreen"))
            {
                return null;
            }
            
            Splash splash = new Splash();

            splash.InitializeForm();
            splash.Show();
            Application.DoEvents();

            return splash;
        }

        internal static void ShowWelcome(Form form, bool forceToView = false)
        {
            if (!forceToView && ConfigUtil.GetBoolParameter("WelcomeShown"))
            {
                return;
            }

            Welcome welcomeWindow = new Welcome { Owner = form };

            welcomeWindow.InitializeForm();
            welcomeWindow.ShowDialog(form);
        }

        internal static void ShowFileListOpen(Form form)
        {
            FileListOpen fileListOpenWindow = new FileListOpen { Owner = form };

            fileListOpenWindow.InitializeForm();
            fileListOpenWindow.ShowDialog(form);
        }

        internal static void ShowGoToLine(Form form)
        {
            GoToLine goToLineWindow = new GoToLine { Owner = form };

            goToLineWindow.InitializeForm();
            goToLineWindow.ShowDialog(form);
        }

        internal static void ShowSelectLines(Form form)
        {
            SelectLines selectLinesWindow = new SelectLines { Owner = form };

            selectLinesWindow.InitializeForm();
            selectLinesWindow.ShowDialog(form);
        }

        internal static DialogResult ShowInternalBrowser(Form form, String url)
        {
            InternalBrowser internalBrowserWindow = new InternalBrowser { Owner = form };

            internalBrowserWindow.InitializeForm(url);
            return internalBrowserWindow.ShowDialog(form);
        }

        internal static void ShowDictionary(Form form, String word = null)
        {
            Dictionary dictionaryWindow = new Dictionary { Owner = form };

            dictionaryWindow.InitializeForm(word);
            dictionaryWindow.Show(form);
        }

        internal static void ShowOptions(Form form)
        {
            Options optionsWindow = new Options { Owner = form };

            optionsWindow.InitializeForm();
            optionsWindow.ShowDialog(form);
        }

        internal static void ShowDatetimeSelectWindow(Form form, DateTime? datetime = null)
        {
            DatetimeSelect datetimeSelectWindow = new DatetimeSelect { Owner = form };

            datetimeSelectWindow.InitializeForm(datetime);
            datetimeSelectWindow.ShowDialog(form);
        }

        internal static void ShowAbout(Form form)
        {
            About aboutWindow = new About { Owner = form };

            aboutWindow.InitializeForm();
            aboutWindow.ShowDialog(form);
        }

        internal static void ShowStatistics(Form form)
        {
            Statistics statisticsWindow = new Statistics { Owner = form };

            statisticsWindow.InitializeForm();
            statisticsWindow.ShowDialog(form);
        }

        internal static void ShowFileProperties(Form form, String fileName, bool sessionFile = false)
        {
            FileProperties filePropertiesWindow = new FileProperties { Owner = form };

            filePropertiesWindow.InitializeForm(fileName, sessionFile);
            filePropertiesWindow.ShowDialog(form);
        }

        internal static void ShowVersionCheck(Form form)
        {
            VersionCheck versionCheckWindow = new VersionCheck { Owner = form };

            versionCheckWindow.InitializeForm();
            versionCheckWindow.ShowDialog(form);
        }

        internal static void ShowMergeTabs(Form form)
        {
            MergeTabs mergeTabsWindow = new MergeTabs { Owner = form };

            mergeTabsWindow.InitializeForm();
            mergeTabsWindow.ShowDialog(form);
        }

        internal static void ShowReportBug(Form form)
        {
            ReportBug reportBugWindow = new ReportBug { Owner = form };

            reportBugWindow.InitializeForm();
            reportBugWindow.ShowDialog(form);
        }

        internal static void ShowFavourites(Form form)
        {
            Favourites favouritesWindow = new Favourites { Owner = form };

            favouritesWindow.InitializeForm(false);
            favouritesWindow.ShowDialog(form);
        }

        internal static void ShowMoveLines(Form form)
        {
            MoveLines moveLinesWindow = new MoveLines { Owner = form };

            moveLinesWindow.InitializeForm();
            moveLinesWindow.ShowDialog(form);
        }

        internal static void ShowExtensions(Form form)
        {
            Extensions extensionsWindow = new Extensions { Owner = form };

            extensionsWindow.InitializeForm();
            extensionsWindow.ShowDialog(form);
        }

        internal static void ShowTools(Form form)
        {
            Tools toolsWindow = new Tools { Owner = form };

            toolsWindow.InitializeForm();
            toolsWindow.ShowDialog(form);
        }

        internal static void ShowTemplates(Form form)
        {
            Templates templatesWindow = new Templates { Owner = form };

            templatesWindow.InitializeForm();
            templatesWindow.ShowDialog(form);
        }

        internal static void ShowContent(Form form, String content, bool helpMode = false)
        {
            ShowContent contentWindow = new ShowContent { Owner = form };

            contentWindow.InitializeForm(content, helpMode);
            contentWindow.Show(form);
        }

        internal static void ShowZipExtract(Form form, String fileNameAndPath)
        {
            ZipExtract zipExtract = new ZipExtract { Owner = form };

            zipExtract.InitializeForm(fileNameAndPath);
            zipExtract.ShowDialog(form);
        }

        internal static void ShowSpecialChars(Form form)
        {
            CharSelect specialCharsWindow = new CharSelect { Owner = form };

            specialCharsWindow.InitializeForm(CharSelect.CharType.Standard);
            specialCharsWindow.Show(form);
        }

        internal static void ShowTagEntry(Form form)
        {
            TagEntry tagEntryWindow = new TagEntry { Owner = form };

            tagEntryWindow.InitializeForm();
            tagEntryWindow.Show(form);
        }

        internal static void ShowHtmlTags(Form form)
        {
            CharSelect specialCharsWindow = new CharSelect { Owner = form };

            specialCharsWindow.InitializeForm(CharSelect.CharType.Html);
            specialCharsWindow.Show(form);
        }

        internal static DialogResult ShowFontSelect(Form form)
        {
            FontSelect fontSelect = new FontSelect { Owner = form };

            fontSelect.InitializeForm();
            return fontSelect.ShowDialog(form);
        }

        internal static void ShowColorSelect(Form form, Color color)
        {
            ColorSelect colorSelect = new ColorSelect { Owner = form };

            colorSelect.InitializeForm(color);
            colorSelect.ShowDialog(form);
        }

        internal static void ShowUrlEntry(Form form, bool addFavourite = false)
        {
            UrlEntry urlEntry = new UrlEntry { Owner = form };

            urlEntry.InitializeForm(addFavourite);
            urlEntry.ShowDialog(form);
        }

        internal static void ShowDropboxFileDialog(Form form, DropboxFileDialog.WindowType windowType)
        {
            DropboxFileDialog dropboxFileDialog = new DropboxFileDialog
                                                      {
                                                          Owner = form,
                                                          windowType = windowType
                                                      };

            if (dropboxFileDialog.InitializeForm())
            {
                dropboxFileDialog.ShowDialog(form);
            }
        }

        internal static void ShowNameEntry(Form form)
        {
            NameEntry nameEntry = new NameEntry { Owner = form };

            nameEntry.InitializeForm();
            nameEntry.ShowDialog(form);
        }

        internal static void ShowPadText(Form form)
        {
            PadText padText = new PadText { Owner = form };

            padText.InitializeForm();
            padText.ShowDialog(form);
        }

        internal static void ShowSortText(Form form)
        {
            SortText sortText = new SortText { Owner = form };

            sortText.InitializeForm();
            sortText.ShowDialog(form);
        }

        internal static void ShowTabEncoding(Form form)
        {
            TabEncoding tabEncoding = new TabEncoding { Owner = form };

            tabEncoding.InitializeForm();
            tabEncoding.ShowDialog(form);
        }

        internal static void ShowFileCompare(Form form)
        {
            FileCompare fileCompare = new FileCompare { Owner = form };

            fileCompare.InitializeForm();
            fileCompare.ShowDialog(form);
        }

        internal static void ShowFileRename(Form form, FileRename.FileTypes fileTypeToRename, String fileNameAndPath)
        {
            FileRename fileRename = new FileRename { Owner = form };

            fileRename.InitializeForm(fileTypeToRename, fileNameAndPath);
            fileRename.ShowDialog(form);
        }

        internal static void ShowHexEditor(Form1 form)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            if (String.IsNullOrEmpty(pageTextBox.Text))
            {
                ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("TextEmpty", className));
                return;
            }
            
            HexEditor hexEditor = new HexEditor { Owner = form };

            hexEditor.InitializeForm();
            hexEditor.Show(form);
        }

        internal static void ShowXmlEditor(Form1 form)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            if (String.IsNullOrEmpty(pageTextBox.Text))
            {
                ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("TextEmpty", className));
                return;
            }

            String error;
            if (!XmlValidator.Validate(form, false, ValidationType.Schema, null, out error))
            {
                ShowAlertBox(form, error);
                return;
            }

            XmlEditor fileRename = new XmlEditor { Owner = form };

            fileRename.InitializeForm();
            fileRename.Show(form);
        }

        internal static void ShowCsvEditor(Form1 form)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            if (String.IsNullOrEmpty(pageTextBox.Text))
            {
                ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("TextEmpty", className));
                return;
            }

            CsvEditor csvEditor = new CsvEditor { Owner = form };

            csvEditor.InitializeForm();
            csvEditor.ShowDialog(form);
        }

        internal static void ShowCsvEditorHeader(Form form)
        {
            CsvEditorHeader csvEditorHeader = new CsvEditorHeader { Owner = form };

            csvEditorHeader.InitializeForm();
            csvEditorHeader.ShowDialog(form);
        }

        internal static void ShowSearchPattern(Form form)
        {
            SearchPattern searchPattern = new SearchPattern { Owner = form };

            searchPattern.InitializeForm();
            searchPattern.ShowDialog(form);
        }

        internal static void ShowSearchInFiles(Form form)
        {
            SearchInFiles searchInFiles = new SearchInFiles { Owner = form };

            searchInFiles.InitializeForm();
            searchInFiles.Show(form);
            searchInFiles.Focus();
        }

        internal static void ShowUrlEncode(Form form)
        {
            UrlEncode urlEncode = new UrlEncode { Owner = form };

            urlEncode.InitializeForm();
            urlEncode.Show(form);
        }

        internal static DialogResult ShowTranslateText(Form form)
        {
            TranslateText translateText = new TranslateText { Owner = form };

            translateText.InitializeForm();
            return translateText.ShowDialog(form);
        }

        internal static void ShowTabsSwitch(Form form)
        {
            TabsSwitch tabsSwitch = new TabsSwitch { Owner = form };

            tabsSwitch.InitializeForm();
            tabsSwitch.ShowDialog(form);
        }

        internal static void ShowErrorBox(Form form, String errorMessage, Exception exception)
        {
            LogUtil log = new LogUtil(MethodBase.GetCurrentMethod());
            log.errorLog(errorMessage, exception);
            
            ErrorOR errorBox = new ErrorOR(form, LanguageUtil.GetCurrentLanguageString("Exception", className) + Environment.NewLine + errorMessage, exception);
            errorBox.ShowDialog(form);
        }

        internal static void ShowErrorProgramBox(Form form, String errorMessage, Exception exception)
        {
            LogUtil log = new LogUtil(MethodBase.GetCurrentMethod());
            log.fatalLog(errorMessage, exception);
            
            ErrorO errorBox = new ErrorO(form, LanguageUtil.GetCurrentLanguageString("FatalException", className) + Environment.NewLine + errorMessage, exception);
            errorBox.ShowDialog(form);
        }

        internal static void ShowInfoBox(Form form, String message)
        {
            InfoO infoBox = new InfoO(form, message);
            infoBox.ShowDialog(form);
        }

        internal static void ShowAlertBox(Form form, String message)
        {
            AlertO alertBox = new AlertO(form, message);
            alertBox.ShowDialog(form);
        }

        internal static DialogResult ShowQuestionBox(Form form, String message)
        {
            QuestionYN questionBox = new QuestionYN(form, message);
            return questionBox.ShowDialog(form);
        }

        internal static DialogResult ShowQuestionCancelBox(Form form, String message)
        {
            QuestionYNC questionCancelBox = new QuestionYNC(form, message);
            return questionCancelBox.ShowDialog(form);
        }

        internal static DialogResult ShowQuestionCancelNoAllBox(Form form, String message)
        {
            QuestionYNNAC questionCancelNoAllBox = new QuestionYNNAC(form, message);
            return questionCancelNoAllBox.ShowDialog(form);
        }

        internal static DialogResult ShowQuestionCancelYesAllBox(Form form, String message)
        {
            QuestionYYANC questionCancelYesAllBox = new QuestionYYANC(form, message);
            return questionCancelYesAllBox.ShowDialog(form);
        }

        internal static DialogResult ShowWarningBox(Form form, String message)
        {
            WarningYNC warningBox = new WarningYNC(form, message);
            return warningBox.ShowDialog(form);
        }

        #endregion Show Methods

        #region Check Methods

        internal static void CheckStayOnTop(Form1 form, bool checkStatus, bool refreshConfig)
        {
            ToolStripMenuItem stayOnTopToolStripMenuItem = form.stayOnTopToolStripMenuItem;
            ToolStripButton stayOnTopToolStripButton = form.stayOnTopToolStripButton;

            form.TopMost = !checkStatus;
            stayOnTopToolStripButton.Checked = !checkStatus;
            stayOnTopToolStripMenuItem.Checked = !checkStatus;
            UpdateConfigParameter("StayOnTopDisabled", checkStatus.ToString(), refreshConfig);
        }

        internal static void CheckSearchReplacePanel(Form1 form, bool checkStatus, bool refreshConfig)
        {
            ToolStripButton showSearchPanelToolStripButton = form.showSearchPanelToolStripButton;
            ToolStripMenuItem showSearchPanelToolStripMenuItem = form.showSearchPanelToolStripMenuItem;
            Panel searchReplacePanel = form.searchReplacePanel;
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            ToolStripButton highlightsResultsToolStripButton = form.searchPanel.highlightsResultsToolStripButton;

            highlightsResultsToolStripButton.Checked = ConfigUtil.GetBoolParameter("SearchHighlightsResults");
            searchReplacePanel.Visible = !checkStatus;
            showSearchPanelToolStripButton.Checked = !checkStatus;
            showSearchPanelToolStripMenuItem.Checked = !checkStatus;
            UpdateConfigParameter("SearchReplacePanelDisabled", checkStatus.ToString(), refreshConfig);

            switch(ConfigUtil.GetIntParameter("SearchReturn"))
            {
                case 0:
                    form.searchPanel.searchTextBox.ReturnActionType = CustomTextBox.ReturnAction.StartSearch;
                    form.searchPanel.replaceTextBox.ReturnActionType = CustomTextBox.ReturnAction.StartSearch;
                    break;
                case 1:
                    form.searchPanel.searchTextBox.ReturnActionType = CustomTextBox.ReturnAction.InsertCR;
                    form.searchPanel.replaceTextBox.ReturnActionType = CustomTextBox.ReturnAction.InsertCR;
                    break;
            }

            if (checkStatus) // && !form.IsOpening)
            {
                //if (refreshConfig)
                //{
                //    StringUtil.ClearHighlightsResults(form);
                //}
                return;
            }

            FileListManager.LoadSearchHistory(form);
            searchTextBox.Focus();
            searchTextBox.SelectAll();
        }

        internal static void CheckSearchCaseSensitive(bool checkStatus, CheckBox caseCheckBox, bool refreshConfig)
        {
            caseCheckBox.Checked = checkStatus;
            UpdateConfigParameter("SearchCaseSensitive", checkStatus.ToString(), refreshConfig);
        }

        internal static void CheckSearchLoop(bool checkStatus, CheckBox loopCheckBox, bool refreshConfig)
        {
            loopCheckBox.Checked = checkStatus;
            UpdateConfigParameter("SearchLoopAtEOF", checkStatus.ToString(), refreshConfig);
        }

        internal static void CheckTrayIcon(Form1 form, bool checkStatus, bool refreshConfig)
        {
            ToolStripMenuItem minimizeOnTrayIconToolStripMenuItem = form.minimizeOnTrayIconToolStripMenuItem;

            minimizeOnTrayIconToolStripMenuItem.Checked = !checkStatus;
            UpdateConfigParameter("MinimizeOnTrayIconDisabled", checkStatus.ToString(), refreshConfig);
        }

        internal static void CheckWordWrap(Form1 form, bool checkStatus, bool refreshConfig)
        {
            ToolStripMenuItem wordWrapToolStripMenuItem = form.wordWrapToolStripMenuItem;
            ToolStripButton wordWrapToolStripButton = form.wordWrapToolStripButton;
            XtraTabControl pagesTabControl = form.pagesTabControl;

            wordWrapToolStripMenuItem.Checked = !checkStatus;
            wordWrapToolStripButton.Checked = !checkStatus;
            UpdateConfigParameter("WordWrapDisabled", checkStatus.ToString(), refreshConfig);

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(tabPage);
                pageTextBox.WordWrap = !checkStatus;
            }

            ProgramUtil.GetCustomLineNumbers(pagesTabControl.SelectedTabPage).Refresh();
        }

        internal static void CheckToolbar(Form1 form, bool checkStatus, bool loadForm, bool refreshConfig)
        {
            ToolStrip toolStrip = form.toolStrip;
            ToolStripMenuItem toolbarToolStripMenuItem = form.toolbarToolStripMenuItem;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            
            if (checkStatus)
            {
                toolStrip.Visible = false;
                toolbarToolStripMenuItem.Checked = false;
                form.Height = form.Height - toolStrip.Height;
                pagesTabControl.Location = new Point(pagesTabControl.Location.X, pagesTabControl.Location.Y - toolStrip.Height);
            }
            else
            {
                if (!loadForm)
                {
                    form.Height = form.Height + toolStrip.Height;
                    pagesTabControl.Location = new Point(pagesTabControl.Location.X, pagesTabControl.Location.Y + toolStrip.Height);
                }

                toolStrip.Visible = true;
                toolbarToolStripMenuItem.Checked = true;
            }

            form.Refresh();
            UpdateConfigParameter("ToolbarInvisible", checkStatus.ToString(), refreshConfig);
        }

        internal static void CheckStatusBar(Form1 form, bool checkStatus, bool loadForm, bool refreshConfig)
        {
            StatusStrip statusStrip = form.statusStrip;
            ToolStripMenuItem statusBarToolStripMenuItem = form.statusBarToolStripMenuItem;
            ZoomTrackBarControl zoomTrackBarControl = form.zoomTrackBarControl;
            PictureBox zoomPictureBox = form.zoomPictureBox;
            
            if (checkStatus)
            {
                zoomPictureBox.Visible = false;
                zoomTrackBarControl.Visible = false;
                statusStrip.Visible = false;
                statusBarToolStripMenuItem.Checked = false;
                form.Height = form.Height - statusStrip.Height;
            }
            else
            {
                if (!loadForm)
                {
                    form.Height = form.Height + statusStrip.Height;
                }

                statusStrip.Visible = true;
                zoomPictureBox.Visible = true;
                zoomTrackBarControl.Visible = true;
                statusBarToolStripMenuItem.Checked = true;
            }

            form.Refresh();
            UpdateConfigParameter("StatusBarInvisible", checkStatus.ToString(), refreshConfig);
        }

        internal static void CheckInternalExplorer(Form1 form, bool checkStatus, bool refreshConfig)
        {
            SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            ToolStripButton verticalContainerToolStripButton = form.verticalContainerToolStripButton;
            ToolStripMenuItem internalExplorerToolStripMenuItem = form.internalExplorerToolStripMenuItem;
            ToolStripButton moveTabUpToolStripButton = form.tabPanel.moveTabUpToolStripButton;
            ToolStripButton moveTabDownToolStripButton = form.tabPanel.moveTabDownToolStripButton;

            verticalSplitContainer.Panel2Collapsed = !checkStatus;

            if (checkStatus)
            {
                ExplorerManager.InitializeTabExplorer(form);
                NoteManager.GetNotesList(form);
                ClipboardManager.GetClipboardList(form, false);
                FileExplorerManager.LoadFileTree(form, false);

                verticalContainerToolStripButton.Checked = true;
                internalExplorerToolStripMenuItem.Checked = true;
            }
            else
            {
                ExplorerManager.ClearTabExplorer(form);
                NoteManager.ClearNotes(form);
                ClipboardManager.ClearClipboardList(form);
                FileExplorerManager.ClearFileTree(form);

                verticalContainerToolStripButton.Checked = false;
                internalExplorerToolStripMenuItem.Checked = false;
                moveTabUpToolStripButton.Enabled = false;
                moveTabDownToolStripButton.Enabled = false;
            }

            UpdateConfigParameter("InternalExplorerInvisible", (!checkStatus).ToString(), refreshConfig);
        }

        internal static void CheckDefaultEncoding(Form1 form, bool checkStatus, bool refreshConfig)
        {
            ToolStripMenuItem useOriginalToolStripMenuItem = form.useOriginalToolStripMenuItem;

            useOriginalToolStripMenuItem.Checked = checkStatus;
            UpdateConfigParameter("DefaultEncoding", checkStatus.ToString(), refreshConfig);
        }

        internal static void CheckEncoding(Form1 form, ToolStripItem clickedItem, bool refreshConfig)
        {
            ToolStripMenuItem aSCIIToolStripMenuItem = form.aSCIIToolStripMenuItem;
            ToolStripMenuItem uTF8ToolStripMenuItem = form.uTF8ToolStripMenuItem;
            ToolStripMenuItem uTF16LittleEndianToolStripMenuItem = form.uTF16LittleEndianToolStripMenuItem;
            ToolStripMenuItem uTF16BigEndianToolStripMenuItem = form.uTF16BigEndianToolStripMenuItem;
            ToolStripMenuItem uTF32LittleEndianToolStripMenuItem = form.uTF32LittleEndianToolStripMenuItem;
            
            switch (clickedItem.Name)
            {
                case "aSCIIToolStripMenuItem":
                    uTF8ToolStripMenuItem.Checked = false;
                    uTF16LittleEndianToolStripMenuItem.Checked = false;
                    uTF16BigEndianToolStripMenuItem.Checked = false;
                    uTF32LittleEndianToolStripMenuItem.Checked = false;

                    UpdateConfigParameter("Encoding", "0", refreshConfig);
                    break;
                case "uTF8ToolStripMenuItem":
                    aSCIIToolStripMenuItem.Checked = false;
                    uTF16LittleEndianToolStripMenuItem.Checked = false;
                    uTF16BigEndianToolStripMenuItem.Checked = false;
                    uTF32LittleEndianToolStripMenuItem.Checked = false;

                    UpdateConfigParameter("Encoding", "1", refreshConfig);
                    break;
                case "uTF16LittleEndianToolStripMenuItem":
                    aSCIIToolStripMenuItem.Checked = false;
                    uTF8ToolStripMenuItem.Checked = false;
                    uTF16BigEndianToolStripMenuItem.Checked = false;
                    uTF32LittleEndianToolStripMenuItem.Checked = false;

                    UpdateConfigParameter("Encoding", "4", refreshConfig);
                    break;
                case "uTF16BigEndianToolStripMenuItem":
                    aSCIIToolStripMenuItem.Checked = false;
                    uTF8ToolStripMenuItem.Checked = false;
                    uTF16LittleEndianToolStripMenuItem.Checked = false;
                    uTF32LittleEndianToolStripMenuItem.Checked = false;

                    UpdateConfigParameter("Encoding", "2", refreshConfig);
                    break;
                case "uTF32LittleEndianToolStripMenuItem":
                    aSCIIToolStripMenuItem.Checked = false;
                    uTF8ToolStripMenuItem.Checked = false;
                    uTF16LittleEndianToolStripMenuItem.Checked = false;
                    uTF16BigEndianToolStripMenuItem.Checked = false;

                    UpdateConfigParameter("Encoding", "3", refreshConfig);
                    break;

                default:
                    aSCIIToolStripMenuItem.Checked = false;
                    uTF16LittleEndianToolStripMenuItem.Checked = false;
                    uTF16BigEndianToolStripMenuItem.Checked = false;
                    uTF32LittleEndianToolStripMenuItem.Checked = false;

                    UpdateConfigParameter("Encoding", "1", refreshConfig);
                    break;
            }
        }

        internal static void CheckEncoding(Form1 form, int clickedItem, bool refreshConfig)
        {
            ToolStripMenuItem aSCIIToolStripMenuItem = form.aSCIIToolStripMenuItem;
            ToolStripMenuItem uTF8ToolStripMenuItem = form.uTF8ToolStripMenuItem;
            ToolStripMenuItem uTF16LittleEndianToolStripMenuItem = form.uTF16LittleEndianToolStripMenuItem;
            ToolStripMenuItem uTF16BigEndianToolStripMenuItem = form.uTF16BigEndianToolStripMenuItem;
            ToolStripMenuItem uTF32LittleEndianToolStripMenuItem = form.uTF32LittleEndianToolStripMenuItem;

            switch (clickedItem)
            {
                case 0:
                    aSCIIToolStripMenuItem.Checked = true;
                    uTF8ToolStripMenuItem.Checked = false;
                    uTF16LittleEndianToolStripMenuItem.Checked = false;
                    uTF16BigEndianToolStripMenuItem.Checked = false;
                    uTF32LittleEndianToolStripMenuItem.Checked = false;
                    
                    UpdateConfigParameter("Encoding", "0", refreshConfig);
                    break;
                case 1:
                    aSCIIToolStripMenuItem.Checked = false;
                    uTF8ToolStripMenuItem.Checked = true;
                    uTF16LittleEndianToolStripMenuItem.Checked = false;
                    uTF16BigEndianToolStripMenuItem.Checked = false;
                    uTF32LittleEndianToolStripMenuItem.Checked = false;

                    UpdateConfigParameter("Encoding", "1", refreshConfig);
                    break;
                case 2:
                    aSCIIToolStripMenuItem.Checked = false;
                    uTF8ToolStripMenuItem.Checked = false;
                    uTF16LittleEndianToolStripMenuItem.Checked = false;
                    uTF16BigEndianToolStripMenuItem.Checked = true;
                    uTF32LittleEndianToolStripMenuItem.Checked = false;

                    UpdateConfigParameter("Encoding", "2", refreshConfig);
                    break;
                case 3:
                    aSCIIToolStripMenuItem.Checked = false;
                    uTF8ToolStripMenuItem.Checked = false;
                    uTF16LittleEndianToolStripMenuItem.Checked = false;
                    uTF16BigEndianToolStripMenuItem.Checked = false;
                    uTF32LittleEndianToolStripMenuItem.Checked = true;

                    UpdateConfigParameter("Encoding", "3", refreshConfig);
                    break;
                case 4:
                    aSCIIToolStripMenuItem.Checked = false;
                    uTF8ToolStripMenuItem.Checked = false;
                    uTF16LittleEndianToolStripMenuItem.Checked = true;
                    uTF16BigEndianToolStripMenuItem.Checked = false;
                    uTF32LittleEndianToolStripMenuItem.Checked = false;

                    UpdateConfigParameter("Encoding", "4", refreshConfig);
                    break;

                default:
                    aSCIIToolStripMenuItem.Checked = false;
                    uTF8ToolStripMenuItem.Checked = true;
                    uTF16LittleEndianToolStripMenuItem.Checked = false;
                    uTF16BigEndianToolStripMenuItem.Checked = false;
                    uTF32LittleEndianToolStripMenuItem.Checked = false;

                    UpdateConfigParameter("Encoding", "1", refreshConfig);
                    break;
            }
        }

        internal static void CheckLineNumbers(Form1 form, bool checkStatus, bool refreshConfig)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripMenuItem lineNumbersToolStripMenuItem = form.lineNumbersToolStripMenuItem;
            ToolStripButton lineNumbersToolStripButton = form.lineNumbersToolStripButton;

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(tabPage);
                customLineNumbers.Visible = checkStatus;

                ColumnRulerManager.UpdatePanelAppearance(tabPage, checkStatus);

                if (!checkStatus)
                {
                    continue;
                }

                customLineNumbers.Size = new Size(customLineNumbers.Size.Width + 1, customLineNumbers.Size.Height);
                customLineNumbers.Size = new Size(customLineNumbers.Size.Width - 1, customLineNumbers.Size.Height);
            }

            lineNumbersToolStripMenuItem.Checked = checkStatus;
            lineNumbersToolStripButton.Checked = checkStatus;

            UpdateConfigParameter("LineNumbersVisible", checkStatus.ToString(), refreshConfig);
        }

        internal static void ResetMainWindow(Form1 form)
        {
            if (ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("SureResetWindow", className)) == DialogResult.No)
            {
                return;
            }

            CheckInternalExplorer(form, true, true);
            CheckLineNumbers(form, true, true);
            CheckSearchReplacePanel(form, true, true);
            CheckStatusBar(form, false, true, true);
            CheckStayOnTop(form, true, true);
            CheckToolbar(form, false, true, true);
            CheckTrayIcon(form, true, true);
            CheckWordWrap(form, false, true);
        }

        #endregion Check Methods

        #region Focus Methods

        internal static void FocusOnRightClick(TextBoxBase textBox, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                textBox.Focus();
            }
        }

        internal static void FocusOnRightClick(ToolStripComboBox comboBox, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                comboBox.Focus();
            }
        }

        #endregion Other Methods

        #region Full Screen Methods

        internal static void ShowFullScreen(Form1 form)
        {
            if (NoteModeManager.IsWindowInNoteMode(form))
            {
                return;
            }
            if (IsWindowInFullScreenMode(form))
            {
                CloseFullScreen(form);
                return;
            }
            
            ToolStripMenuItem fullscreenToolStripMenuItem = form.fullscreenToolStripMenuItem;
            ToolStripMenuItem showTabAsNoteOnTopToolStripMenuItem1 = form.showTabAsNoteOnTopToolStripMenuItem1;
            ToolStripMenuItem showTabAsNoteOnTopToolStripMenuItem = form.showTabAsNoteOnTopToolStripMenuItem;
            ToolStripButton stayOnTopToolStripButton = form.stayOnTopToolStripButton;
            ToolStripMenuItem stayOnTopToolStripMenuItem = form.stayOnTopToolStripMenuItem;
            StatusStrip statusStrip = form.statusStrip;

            if (form.WindowState != FormWindowState.Maximized)
            {
                ConfigUtil.UpdateParameters(new[] { "WindowState", "WindowSizeX", "WindowSizeY" }, new[] { form.WindowState.ToString(), form.Width.ToString(), form.Height.ToString() });
            }
            else
            {
                ConfigUtil.UpdateParameter("WindowState", form.WindowState.ToString());
            }

            form.WindowState = FormWindowState.Normal;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopMost = true;

            form.Size = new Size(Screen.FromControl(form).WorkingArea.Width, Screen.FromControl(form).WorkingArea.Height);
            form.SetDesktopLocation(0, 0);
            
            fullscreenToolStripMenuItem.Visible = true;
            showTabAsNoteOnTopToolStripMenuItem1.Enabled = false;
            showTabAsNoteOnTopToolStripMenuItem.Enabled = false;
            stayOnTopToolStripButton.Enabled = false;
            stayOnTopToolStripMenuItem.Enabled = false;
            statusStrip.SizingGrip = false;
        }

        internal static void CloseFullScreen(Form1 form)
        {
            ToolStripMenuItem fullscreenToolStripMenuItem = form.fullscreenToolStripMenuItem;
            ToolStripMenuItem showTabAsNoteOnTopToolStripMenuItem1 = form.showTabAsNoteOnTopToolStripMenuItem1;
            ToolStripMenuItem showTabAsNoteOnTopToolStripMenuItem = form.showTabAsNoteOnTopToolStripMenuItem;
            ToolStripButton stayOnTopToolStripButton = form.stayOnTopToolStripButton;
            ToolStripMenuItem stayOnTopToolStripMenuItem = form.stayOnTopToolStripMenuItem;
            StatusStrip statusStrip = form.statusStrip;

            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.TopMost = !ConfigUtil.GetBoolParameter("StayOnTopDisabled");

            form.Size = new Size(ConfigUtil.GetIntParameter("WindowSizeX"), ConfigUtil.GetIntParameter("WindowSizeY"));
            form.SetDesktopLocation(50, 50);
            form.WindowState = ConfigUtil.GetStringParameter("WindowState") == "Maximized" ? FormWindowState.Maximized : FormWindowState.Normal;

            fullscreenToolStripMenuItem.Visible = false;
            showTabAsNoteOnTopToolStripMenuItem1.Enabled = true;
            showTabAsNoteOnTopToolStripMenuItem.Enabled = true;
            stayOnTopToolStripButton.Enabled = true;
            stayOnTopToolStripMenuItem.Enabled = true;
            statusStrip.SizingGrip = true;
        }

        internal static bool IsWindowInFullScreenMode(Form1 form)
        {
            return form.FormBorderStyle == FormBorderStyle.None;
        }

        #endregion Full Screen Methods

        #region Screenshots Methods

        internal static void TakeTabControlScreenshot(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            Rectangle screenshotArea = pagesTabControl.RectangleToScreen(pagesTabControl.ClientRectangle);
            //Rectangle bounds = pagesTabControl.Bounds;

            using (Bitmap screenshot = new Bitmap(screenshotArea.Width, screenshotArea.Height))
            {
                using (Graphics graphic = Graphics.FromImage(screenshot))
                {
                    graphic.CopyFromScreen(new Point(screenshotArea.Left, screenshotArea.Top), Point.Empty, screenshotArea.Size);
                }
                Clipboard.SetImage(screenshot);
            }

            ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("ScreenshotInClipboard", className));
        }

        internal static void TakeDataGridViewScreenshot(CsvEditor form)
        {
            DataGridView csvGridView = form.csvGridView;

            csvGridView.ClearSelection();
            csvGridView.Refresh();

            int columnsSize = csvGridView.Columns.Cast<DataGridViewColumn>().Sum(column => column.Width);
            //int columnsSize = 0;
            //foreach (DataGridViewColumn column in csvGridView.Columns)
            //{
            //    columnsSize += column.Width;
            //}

            Rectangle screenshotArea = new Rectangle(
                csvGridView.PointToScreen(new Point(csvGridView.ClientRectangle.Location.X + csvGridView.RowHeadersWidth, csvGridView.ClientRectangle.Location.Y)),
                new Size(columnsSize, csvGridView.Height));

            using (Bitmap screenshot = new Bitmap(screenshotArea.Width, screenshotArea.Height))
            {
                using (Graphics graphic = Graphics.FromImage(screenshot))
                {
                    graphic.CopyFromScreen(new Point(screenshotArea.Left, screenshotArea.Top), Point.Empty, screenshotArea.Size);
                }
                Clipboard.SetImage(screenshot);
            }

            ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("ScreenshotInClipboard", className));
        }

        #endregion Screenshots Methods

        #region Private Methods

        private static void UpdateConfigParameter(String parameterName, String parameterValue, bool refreshConfig)
        {
            if (refreshConfig)
            {
                ConfigUtil.UpdateParameter(parameterName, parameterValue);
            }
        }

        #endregion Private Methods
    }
}
