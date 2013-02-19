using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using DtControls;
using DtPad.Customs;
using DtPad.Exceptions;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Tab open and events manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TabManager
    {
        private const String className = "TabManager";

        #region Internal Methods

        internal static XtraTabPage GetXtraTabPageFromName(XtraTabControl pagesTabControl, String name)
        {
            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                if (tabPage.Name == name)
                {
                    return tabPage;
                }
            }

            return null;
        }

        internal static bool IsCurrentTabInUse(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            return !String.IsNullOrEmpty(pageTextBox.Text) || !String.IsNullOrEmpty(ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage));
        }

        internal static int AddNewPage(Form1 form, int tabIdentity)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripMenuItem wordWrapToolStripMenuItem = form.wordWrapToolStripMenuItem;
            ToolStripMenuItem lineNumbersToolStripMenuItem = form.lineNumbersToolStripMenuItem;
            ContextMenuStrip textBoxContextMenuStrip = form.textBoxContextMenuStrip;

            bool rowNumbersVisibile = lineNumbersToolStripMenuItem.Checked;
            bool wordWrapEnabled = wordWrapToolStripMenuItem.Checked;
            if (form.WindowMode == CustomForm.WindowModeEnum.Note)
            {
                rowNumbersVisibile = false;
                wordWrapEnabled = true;
            }

            String newTabTitle = LanguageUtil.GetCurrentLanguageString("tabPage1", form.Name);

            tabIdentity++;
            String newTabPageName = String.Format("tabPage{0}", tabIdentity);

            XtraTabPage newTabPageControl = new XtraTabPage
                                                {
                                                    ImageIndex = 0,
                                                    Name = newTabPageName,
                                                    Padding = new Padding(3),
                                                    Text = newTabTitle,
                                                    Tooltip = newTabTitle
                                                };
            //newTabPageControl.Appearance.Header.ForeColor = Color.Black;
            //newTabPageControl.Appearance.PageClient.BackColor = Color.White;
            newTabPageControl.TextChanged += form.tabPage_TextChanged;

            CustomRichTextBox newTabPageTextBox = new CustomRichTextBox
                                                      {
                                                          AcceptsTab = true,
                                                          AllowDrop = true,
                                                          AutoWordSelection = false,
                                                          BackColor = form.TextBackgroundColor,
                                                          BorderStyle = BorderStyle.None,
                                                          ContextMenuStrip = textBoxContextMenuStrip,
                                                          CustomEncodingForced = false,
                                                          CustomInsertMode = "INS",
                                                          CustomModified = false,
                                                          CustomOriginal = String.Empty.GetHashCode().ToString(),
                                                          CustomZoom = 100,
                                                          DetectUrls = ConfigUtil.GetBoolParameter("HighlightURL"),
                                                          Dock = DockStyle.Fill,
                                                          Font = form.TextFont,
                                                          ForeColor = form.TextFontColor,
                                                          HideSelection = false,
                                                          //Multiline = true,
                                                          Name = "pageTextBox",
                                                          //ScrollBars = RichTextBoxScrollBars.Both,
                                                          Text = String.Empty,
                                                          WordWrap = wordWrapEnabled
                                                      };
            newTabPageControl.Controls.Add(newTabPageTextBox);

            CustomLineNumbers customLineNumbers = new CustomLineNumbers
                                                      {
                                                          AutoSizing = true,
                                                          BackColor = form.TextBackgroundColor,
                                                          BackgroundGradient_AlphaColor = Color.FromArgb(0, 0, 0, 0),
                                                          BackgroundGradient_BetaColor = SystemColors.Window,
                                                          BackgroundGradient_Direction = LinearGradientMode.Horizontal,
                                                          BorderLines_Color = Color.DeepSkyBlue,
                                                          BorderLines_Style = DashStyle.Solid,
                                                          BorderLines_Thickness = 1F,
                                                          Dock = DockStyle.Left,
                                                          DockSide = CustomLineNumbers.LineNumberDockSide.Left,
                                                          Font = form.TextFont,
                                                          ForeColor = SystemColors.AppWorkspace,
                                                          GridLines_Color = Color.DeepSkyBlue,
                                                          GridLines_Style = DashStyle.Solid,
                                                          GridLines_Thickness = 1F,
                                                          LineNrs_Alignment = ContentAlignment.TopRight,
                                                          LineNrs_AntiAlias = false,
                                                          LineNrs_ClippedByItemRectangle = true,
                                                          LineNrs_Offset = new Size(0, 0),
                                                          Location = new Point(3, 3),
                                                          Margin = new Padding(0),
                                                          MarginLines_Color = Color.DeepSkyBlue,
                                                          MarginLines_Side = CustomLineNumbers.LineNumberDockSide.Right,
                                                          MarginLines_Style = DashStyle.Dash,
                                                          MarginLines_Thickness = 1F,
                                                          MinimumSize = new Size(47, 0),
                                                          Name = "customLineNumbers",
                                                          Padding = new Padding(0, 0, 7, 0),
                                                          ParentRichTextBox = newTabPageTextBox,
                                                          Show_LineNrs = true,
                                                          Show_MarginLines = true,
                                                          Size = new Size(47, 308),
                                                          TabIndex = 2,
                                                          Visible = rowNumbersVisibile
                                                      };
            newTabPageControl.Controls.Add(customLineNumbers);

            Label newTabPageLabel = new Label
                                        {
                                            AutoSize = true,
                                            Location = new Point(3, 3),
                                            Name = "filenameTabPage",
                                            Size = new Size(0, 13),
                                            Visible = false
                                        };
            newTabPageLabel.TextChanged += form.filenameTabPage_TextChanged;
            newTabPageControl.Controls.Add(newTabPageLabel);

            pagesTabControl.TabPages.Add(newTabPageControl);
            pagesTabControl.SelectedTabPage = newTabPageControl;

            ExplorerManager.AddNodeToTabExplorer(form, newTabPageControl.Text, newTabPageControl.Name, 0, 0);
            OtherManager.FocusOnEditor(form);
            WindowModeManager.AddRelaxModeMargins(form);

            return tabIdentity;
        }

        internal static bool CloseAllPages(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            int pageCount = pagesTabControl.TabPages.Count;
            bool closeAll = false;
            bool moreTabs = (pageCount > 1);

            for (int i = 0; i < pageCount; i++)
            {
                if (!ClosePage(form, !closeAll, moreTabs, out closeAll))
                {
                    return false;
                }
            }

            return true;
        }

        internal static void CloseAllPagesButThis(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            XtraTabPage selectedTab = pagesTabControl.SelectedTabPage;
            int pageCount = pagesTabControl.TabPages.Count;
            bool closeAll = false;
            bool moreTabs = (pageCount > 2);

            if (pageCount <= 1)
            {
                return;
            }

            for (int i = 0; i < pageCount - 1; i++)
            {
                if (pagesTabControl.SelectedTabPage == selectedTab && pagesTabControl.SelectedTabPageIndex + 1 < pagesTabControl.TabPages.Count)
                {
                    pagesTabControl.SelectedTabPageIndex = pagesTabControl.SelectedTabPageIndex + 1;
                }
                else if (pagesTabControl.SelectedTabPage == selectedTab)
                {
                    pagesTabControl.SelectedTabPageIndex = 0;
                }

                //ClosePage(form);
                if (!ClosePage(form, !closeAll, moreTabs, out closeAll))
                {
                    return;
                }
            }
        }

        internal static void ClosePage(Form1 form, bool showMessages = true)
        {
            bool closeAll;
            ClosePage(form, showMessages, false, out closeAll);
        }
        private static bool ClosePage(Form1 form, bool showMessages, bool moreTabs, out bool closeAll)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            closeAll = false;

            if (showMessages && TabUtil.IsTabPageModified(pagesTabControl.SelectedTabPage))
            {
                if (moreTabs)
                {
                    DialogResult dialogResult = WindowManager.ShowQuestionCancelNoAllBox(form, LanguageUtil.GetCurrentLanguageString("SaveUntitled", className));

                    if ((dialogResult == DialogResult.Cancel) || (dialogResult == DialogResult.Yes && !FileManager.SaveFile(form, false)))
                    {
                        return false;
                    }
                    if (dialogResult == DialogResult.Retry)
                    {
                        closeAll = true;
                    }
                }
                else
                {
                    DialogResult dialogResult = WindowManager.ShowQuestionCancelBox(form, LanguageUtil.GetCurrentLanguageString("SaveUntitled", className));

                    if ((dialogResult == DialogResult.Cancel) || (dialogResult == DialogResult.Yes && !FileManager.SaveFile(form, false)))
                    {
                        return false;
                    }
                }
            }
            else if (!showMessages)
            {
                closeAll = true;
            }

            CustomPanel sectionsPanel = ProgramUtil.GetSectionsPanel(pagesTabControl.SelectedTabPage);
            CustomPanel annotationPanel = ProgramUtil.GetAnnotationPanel(pagesTabControl.SelectedTabPage);

            if (sectionsPanel != null)
            {
                pagesTabControl.SelectedTabPage.Controls.Remove(sectionsPanel);
            }
            if (annotationPanel != null)
            {
                pagesTabControl.SelectedTabPage.Controls.Remove(annotationPanel);
            }

            if (pagesTabControl.TabPages.Count > 1)
            {
                String selectedTabName = pagesTabControl.SelectedTabPage.Name;
                int selectedTabIndex = pagesTabControl.SelectedTabPageIndex;

                pagesTabControl.TabPages.Remove(pagesTabControl.SelectedTabPage);
                ExplorerManager.RemoveNodeToTabExplorer(form, selectedTabName);

                pagesTabControl.SelectedTabPage = selectedTabIndex < pagesTabControl.TabPages.Count ? pagesTabControl.TabPages[selectedTabIndex] : pagesTabControl.TabPages[pagesTabControl.TabPages.Count - 1];

                if (String.IsNullOrEmpty(ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage)))
                {
                    ToggleTabFileTools(form, false);
                }
                OtherManager.FocusOnEditor(form);
            }
            else
            {
                ResetTab(form);
            }

            return true;
        }

        internal static void ResetTab(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.SelectedTabPage);

            if (ColumnRulerManager.IsPanelOpen(form))
            {
                ColumnRulerManager.TogglePanel(form);
            }

            String newTabTitle = LanguageUtil.GetCurrentLanguageString("tabPage1", form.Name);

            SetTabColor(pagesTabControl.SelectedTabPage, Color.Black); //pagesTabControl.SelectedTabPage.Appearance.Header.ForeColor = Color.Black;
            pagesTabControl.SelectedTabPage.Appearance.Header.Reset();
            pageTextBox.Text = String.Empty;
            pagesTabControl.SelectedTabPage.ImageIndex = 0;
            pagesTabControl.SelectedTabPage.Text = newTabTitle;
            pagesTabControl.SelectedTabPage.Tooltip = newTabTitle;
            form.Text = String.Format("DtPad - {0}", newTabTitle);
            ProgramUtil.SetFilenameTabPage(pagesTabControl.SelectedTabPage, String.Empty);
            pageTextBox.CustomZoom = 100;
            pageTextBox.CustomModified = false;
            pageTextBox.CustomOriginal = String.Empty.GetHashCode().ToString();
            pageTextBox.CustomEncoding = String.Empty;
            pageTextBox.CustomEncodingForced = false;
            customLineNumbers.Width = customLineNumbers.MinimumSize.Width;
            ZoomSelect(form, 100);
            pageTextBox.ClearUndo();

            TextManager.RefreshUndoRedoExternal(form);

            if (String.IsNullOrEmpty(ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage)))
            {
                ToggleTabFileTools(form, false);
            }
            OtherManager.FocusOnEditor(form);
        }

        internal static void GoToLine(Form1 form, int row)
        {
            ToolStripStatusLabel rowToolStripStatusLabel1 = form.rowToolStripStatusLabel1;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            pageTextBox.Select(TextManager.ReadRTBFirstCharIndexFromLine(form, row - 1), 0);
            rowToolStripStatusLabel1.Text = row.ToString();
        }

        internal static void FontPages(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            DialogResult dialogResult = WindowManager.ShowFontSelect(form);
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(tabPage);

                pageTextBox.Font = form.TextFont;
                pageTextBox.ForeColor = form.TextFontColor;
                ProgramUtil.GetCustomLineNumbers(tabPage).Font = form.TextFont;
            }

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
            ConfigUtil.UpdateParameter("FontInUse", tc.ConvertToString(form.TextFont));
            ConfigUtil.UpdateParameter("FontInUseColorARGB", FontManager.SetARGBString(form.TextFontColor));
        }

        internal static void FontPagesWithoutSave(Options form)
        {
            //DialogResult dialogResult = WindowManager.ShowFontSelect(form);
            //if (dialogResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            WindowManager.ShowFontSelect(form);
        }

        internal static void BackgroundPagesWithoutSave(Options form)
        {
            WindowManager.ShowColorSelect(form, form.TextBackgroundColor);
        }

        internal static void MoveToNextTab(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            if (pagesTabControl.TabPages.Count > pagesTabControl.SelectedTabPageIndex + 1)
            {
                pagesTabControl.SelectedTabPageIndex = pagesTabControl.SelectedTabPageIndex + 1;
            }
            else
            {
                pagesTabControl.SelectedTabPageIndex = 0;
            }
        }

        internal static void MoveToPreviousTab(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            if (pagesTabControl.SelectedTabPageIndex > 0)
            {
                pagesTabControl.SelectedTabPageIndex = pagesTabControl.SelectedTabPageIndex - 1;
            }
            else
            {
                pagesTabControl.SelectedTabPageIndex = pagesTabControl.TabPages.Count - 1;
            }
        }

        internal static void MergeTab(Form1 form, String[] selectedTabNames, bool indicateMerge, String markSeparation)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;

            bool linesDisabled = false;
            int previousMaximum = toolStripProgressBar.Maximum;
            int previousStep = toolStripProgressBar.Step;
            toolStripProgressBar.Maximum = selectedTabNames.Length + 1;
            toolStripProgressBar.Step = 1;
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;

            if (indicateMerge)
            {
                ConfigUtil.UpdateParameter("MergeTabSeparation", markSeparation.Replace(ConstantUtil.newLine, "\\r\\n"));
            }

            XtraTabPage firstTab = GetXtraTabPageFromName(pagesTabControl, selectedTabNames[0]);

            for (int i = 1; i < selectedTabNames.Length; i++)
            {
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(firstTab);

                if (indicateMerge)
                {
                    pageTextBox.Text = pageTextBox.Text + ConstantUtil.newLine + markSeparation + ConstantUtil.newLine + ProgramUtil.GetPageTextBox(GetXtraTabPageFromName(pagesTabControl, selectedTabNames[i])).Text;
                }
                else
                {
                    pageTextBox.Text = pageTextBox.Text + ConstantUtil.newLine + ProgramUtil.GetPageTextBox(GetXtraTabPageFromName(pagesTabControl, selectedTabNames[i])).Text;
                }

                if (linesDisabled != true && ConfigUtil.GetBoolParameter("LineNumbersVisible") && StringUtil.AreLinesTooMuchForPasteWithRowLines(pageTextBox.Text))
                {
                    WindowManager.CheckLineNumbers(form, false, true);
                    linesDisabled = true;
                }

                pagesTabControl.TabPages.Remove(GetXtraTabPageFromName(pagesTabControl, selectedTabNames[i]));
                toolStripProgressBar.PerformStep();
            }

            toolStripStatusLabel.Text = String.Format("{0} {1}", selectedTabNames.Length, LanguageUtil.GetCurrentLanguageString("TabMerged", className));
            toolStripProgressBar.PerformStep();
            toolStripProgressBar.Visible = false;
            toolStripProgressBar.Maximum = previousMaximum;
            toolStripProgressBar.Step = previousStep;

            if (linesDisabled)
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("LineNumbersDisabled", className));
            }
        }

        internal static void ZoomSelect(Form1 form, int? zoom)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ZoomTrackBarControl zoomTrackBarControl = form.zoomTrackBarControl;
            CustomRichTextBox currentPageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            int zoomInt;
            if (zoom == null)
            {
                zoomInt = GetZoomFromTrackBar(zoomTrackBarControl);
            }
            else
            {
                zoomInt = Convert.ToInt32(zoom);
                SetTrackBarFromZoom(zoomTrackBarControl, zoomInt);
            }

            ColumnRulerManager.SetZoom(pagesTabControl.SelectedTabPage, zoomInt);

            currentPageTextBox.ZoomFactor = (float)zoomInt / 100;
            currentPageTextBox.CustomZoom = zoomInt;
        }

        internal static void SetZoomFromMouse(Form1 form, int wheelScrolls)
        {
            ZoomTrackBarControl zoomTrackBarControl = form.zoomTrackBarControl;

            if ((wheelScrolls < 0 && zoomTrackBarControl.Value > zoomTrackBarControl.Properties.Minimum) || (wheelScrolls > 0 && zoomTrackBarControl.Value < zoomTrackBarControl.Properties.Maximum))
            {
                zoomTrackBarControl.Value += wheelScrolls;
            }
        }

        internal static void CopyFileName(Form1 form)
        {
            String fileName = Path.GetFileName(ProgramUtil.GetFilenameTabPage(form.pagesTabControl.SelectedTabPage));

            if (!String.IsNullOrEmpty(fileName))
            {
                Clipboard.SetDataObject(fileName, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
            }
        }

        internal static void CopyFullPath(Form1 form)
        {
            Clipboard.SetDataObject(ProgramUtil.GetFilenameTabPage(form.pagesTabControl.SelectedTabPage), true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
        }

        internal static void OpenFileFolder(Form1 form)
        {
            String fileName = ProgramUtil.GetFilenameTabPage(form.pagesTabControl.SelectedTabPage);
            ProcessStartInfo processStartInfo = new ProcessStartInfo("explorer.exe") { Arguments = String.Format("/select, {0}", fileName) };
            OtherManager.StartProcessInfo(form, processStartInfo);
        }

        internal static void OpenFileFolderPrompt(Form1 form)
        {
            String fileName = ProgramUtil.GetFilenameTabPage(form.pagesTabControl.SelectedTabPage);
            String workingDrive = Path.GetPathRoot(Path.GetDirectoryName(fileName));
            if (String.IsNullOrEmpty(workingDrive))
            {
                workingDrive = @"C:\";
            }

            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe")
                                                    {
                                                        WorkingDirectory = workingDrive,
                                                        Arguments = String.Format("/k \"cd {0}", Path.GetDirectoryName(fileName))
                                                    };
            OtherManager.StartProcessInfo(form, processStartInfo);
        }

        internal static void MoveTabFirstOrUp(Form1 form, bool first = false)
        {
            TreeView tabExplorerTreeView = form.tabPanel.tabExplorerTreeView;
            XtraTabControl pagesTabControl = form.pagesTabControl;

            //Move tree node
            TreeNode selectedNode = tabExplorerTreeView.SelectedNode;
            int selectedNodeIndex = selectedNode.Index;

            if (selectedNodeIndex <= 0)
            {
                return;
            }

            tabExplorerTreeView.Nodes.Remove(selectedNode);
            tabExplorerTreeView.Nodes.Insert(first ? 0 : selectedNodeIndex - 1, selectedNode); //selectedNodeIndex - 1, selectedNode);

            tabExplorerTreeView.SelectedNode = selectedNode;

            //Move tab
            XtraTabPage selectedTabPage = GetXtraTabPageFromName(pagesTabControl, tabExplorerTreeView.SelectedNode.Name.Substring(ConstantUtil.tabNodePrefix.Length));
            int selectedTabPageIndex = pagesTabControl.TabPages.IndexOf(selectedTabPage);

            pagesTabControl.TabPages.Remove(selectedTabPage);
            pagesTabControl.TabPages.Insert(first ? 0 : selectedTabPageIndex - 1, selectedTabPage); //selectedTabPageIndex - 1, selectedTabPage);

            //Focus
            pagesTabControl.SelectedTabPage = selectedTabPage;
            tabExplorerTreeView.Focus();
            tabExplorerTreeView.SelectedNode = selectedNode; //tabExplorerTreeView.Nodes[selectedTabPageIndex - 1];

            ToggleTabMoveButtons(form, tabExplorerTreeView.SelectedNode, tabExplorerTreeView.Nodes.Count);
        }

        internal static void MoveTabDownOrLast(Form1 form, bool last = false)
        {
            TreeView tabExplorerTreeView = form.tabPanel.tabExplorerTreeView;
            XtraTabControl pagesTabControl = form.pagesTabControl;

            //Move tree node
            TreeNode selectedNode = tabExplorerTreeView.SelectedNode;
            int selectedNodeIndex = selectedNode.Index;

            if (selectedNodeIndex >= tabExplorerTreeView.Nodes.Count - 1)
            {
                return;
            }

            tabExplorerTreeView.Nodes.Remove(selectedNode);
            tabExplorerTreeView.Nodes.Insert(last ? tabExplorerTreeView.Nodes.Count : selectedNodeIndex + 1, selectedNode); //selectedNodeIndex + 1, selectedNode);

            tabExplorerTreeView.SelectedNode = selectedNode;

            //Move tab
            XtraTabPage selectedTabPage = GetXtraTabPageFromName(pagesTabControl, tabExplorerTreeView.SelectedNode.Name.Substring(ConstantUtil.tabNodePrefix.Length));
            int selectedTabPageIndex = pagesTabControl.TabPages.IndexOf(selectedTabPage);

            pagesTabControl.TabPages.Remove(selectedTabPage);
            pagesTabControl.TabPages.Insert(last ? tabExplorerTreeView.Nodes.Count - 1 : selectedTabPageIndex + 1, selectedTabPage); //selectedTabPageIndex + 1, selectedTabPage);

            //Focus
            pagesTabControl.SelectedTabPage = selectedTabPage;
            tabExplorerTreeView.Focus();
            tabExplorerTreeView.SelectedNode = selectedNode; //tabExplorerTreeView.Nodes[selectedTabPageIndex + 1];

            ToggleTabMoveButtons(form, tabExplorerTreeView.SelectedNode, tabExplorerTreeView.Nodes.Count);
        }

        internal static void SortTabsAlphabetically(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripButton moveTabFirstToolStripButton = form.tabPanel.moveTabFirstToolStripButton;
            ToolStripButton moveTabUpToolStripButton = form.tabPanel.moveTabUpToolStripButton;
            ToolStripButton moveTabDownToolStripButton = form.tabPanel.moveTabDownToolStripButton;
            ToolStripButton moveTabLastToolStripButton = form.tabPanel.moveTabLastToolStripButton;

            if (pagesTabControl.TabPages.Count <= 1)
            {
                return;
            }

            XtraTabPageCollection tabPages = pagesTabControl.TabPages;
            List<TabPageObject> tabList = new List<TabPageObject>();

            for (int i = 0; i < tabPages.Count; i++)
            {
                tabList.Add(new TabPageObject(tabPages[i].Text, tabPages[i].Name, i, tabPages[i]));
            }
            tabList.Sort();

            for (int i = 0; i < tabList.Count; i++)
            {
                TabPageObject tabPageObject = tabList[i];
                pagesTabControl.TabPages.Move(i, tabPageObject.TabPage);
            }

            moveTabFirstToolStripButton.Enabled = false;
            moveTabUpToolStripButton.Enabled = false;
            moveTabDownToolStripButton.Enabled = false;
            moveTabLastToolStripButton.Enabled = false;

            ExplorerManager.InitializeTabExplorer(form);
        }

        internal static void ToggleTabFileTools(Form1 form, bool enabled)
        {
            ToolStripMenuItem reloadToolStripMenuItem = form.reloadToolStripMenuItem;
            ToolStripMenuItem toggleReadonlyToolStripMenuItem = form.toggleReadonlyToolStripMenuItem;
            ToolStripMenuItem deleteFileToolStripMenuItem = form.deleteFileToolStripMenuItem;
            ToolStripMenuItem filePropertiesToolStripMenuItem = form.filePropertiesToolStripMenuItem;
            ToolStripMenuItem saveWithBackupToolStripMenuItem = form.saveWithBackupToolStripMenuItem;
            ToolStripMenuItem saveWithBackupToolStripMenuItem1 = form.saveWithBackupToolStripMenuItem1;
            ToolStripMenuItem copyFileNameToolStripMenuItem = form.copyFileNameToolStripMenuItem;
            ToolStripMenuItem copyFullPathToolStripMenuItem = form.copyFullPathToolStripMenuItem;
            ToolStripMenuItem openFileFolderToolStripMenuItem = form.openFileFolderToolStripMenuItem;
            ToolStripMenuItem addCurrentFileToolStripMenuItem = form.addCurrentFileToolStripMenuItem;
            ToolStripMenuItem openFileFolderPromptToolStripMenuItem = form.openFileFolderPromptToolStripMenuItem;
            ToolStripMenuItem renameToolStripMenuItem = form.renameToolStripMenuItem;
            ToolStripMenuItem renameToolStripMenuItem1 = form.renameToolStripMenuItem1;
            ToolStripMenuItem propertiesToolStripMenuItem = form.propertiesToolStripMenuItem;

            reloadToolStripMenuItem.Enabled = enabled;
            toggleReadonlyToolStripMenuItem.Enabled = enabled;
            deleteFileToolStripMenuItem.Enabled = enabled;
            filePropertiesToolStripMenuItem.Enabled = enabled;
            saveWithBackupToolStripMenuItem.Enabled = enabled;
            saveWithBackupToolStripMenuItem1.Enabled = enabled;
            copyFileNameToolStripMenuItem.Enabled = enabled;
            copyFullPathToolStripMenuItem.Enabled = enabled;
            openFileFolderToolStripMenuItem.Enabled = enabled;
            addCurrentFileToolStripMenuItem.Enabled = enabled;
            openFileFolderPromptToolStripMenuItem.Enabled = enabled;
            renameToolStripMenuItem.Enabled = enabled;
            renameToolStripMenuItem1.Enabled = enabled;
            propertiesToolStripMenuItem.Enabled = enabled;
        }

        internal static void CompareTabText(FileCompare form, String[] itemValues)
        {
            Form1 form1 = (Form1)form.Owner;
            XtraTabControl pagesTabControl = form1.pagesTabControl;
            ListBox tabPagesListBox = form.tabPagesListBox;
            CheckBox caseSensitiveCheckBox = form.caseSensitiveCheckBox;

            if (tabPagesListBox.SelectedIndices.Count != 2)
            {
                throw new TabException(LanguageUtil.GetCurrentLanguageString("ErrorCompare", className));
            }

            String[] selectedTabNames = new String[tabPagesListBox.SelectedIndices.Count];
            for (int i = 0; i < tabPagesListBox.SelectedIndices.Count; i++)
            {
                selectedTabNames[i] = itemValues[tabPagesListBox.SelectedIndices[i]];
            }

            XtraTabPage tabPage1 = GetXtraTabPageFromName(pagesTabControl, selectedTabNames[0]);
            XtraTabPage tabPage2 = GetXtraTabPageFromName(pagesTabControl, selectedTabNames[1]);

            CustomRichTextBox pageTextBox1 = ProgramUtil.GetPageTextBox(tabPage1);
            CustomRichTextBox pageTextBox2 = ProgramUtil.GetPageTextBox(tabPage2);

            String text1 = pageTextBox1.Text;
            String text2 = pageTextBox2.Text;

            if (!caseSensitiveCheckBox.Checked)
            {
                text1 = text1.ToLower();
                text2 = text2.ToLower();
            }

            if (text1 == text2)
            {
                WindowManager.ShowInfoBox(form1, LanguageUtil.GetCurrentLanguageString("TabEquals", className));
            }
            else if (text1.Replace(ConstantUtil.newLine, String.Empty) == text2.Replace(ConstantUtil.newLine, String.Empty))
            {
                WindowManager.ShowAlertBox(form1, LanguageUtil.GetCurrentLanguageString("TabAlmostEquals_Returns", className));
            }
            else if (text1.Replace(" ", String.Empty).Replace("\t", String.Empty) == text2.Replace(" ", String.Empty).Replace("\t", String.Empty))
            {
                WindowManager.ShowAlertBox(form1, LanguageUtil.GetCurrentLanguageString("TabAlmostEquals_Spaces", className));
            }
            else if (text1.Replace(ConstantUtil.newLine, String.Empty).Replace(" ", String.Empty).Replace("\t", String.Empty) == text2.Replace(ConstantUtil.newLine, String.Empty).Replace(" ", String.Empty).Replace("\t", String.Empty))
            {
                WindowManager.ShowAlertBox(form1, LanguageUtil.GetCurrentLanguageString("TabAlmostEquals_ReturnsAndSpaces", className));
            }
            else
            {
                WindowManager.ShowAlertBox(form1, LanguageUtil.GetCurrentLanguageString("TabDifferents", className));
            }
        }

        internal static void InsertMode(Form1 form)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            ToolStripStatusLabel insertModeToolStripStatusLabel = form.insertModeToolStripStatusLabel;

            if (pageTextBox.CustomInsertMode == "INS")
            {
                insertModeToolStripStatusLabel.Text = "OVR";
                pageTextBox.CustomInsertMode = "OVR";
            }
            else
            {
                insertModeToolStripStatusLabel.Text = "INS";
                pageTextBox.CustomInsertMode = "INS";
            }
        }

        internal static String GetTabTitles(Form1 form, int maxNumberOfTitles, bool endsWithDotsIfTooMuchTitles)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            bool dotsOnEnd = true;
            if (maxNumberOfTitles > pagesTabControl.TabPages.Count)
            {
                maxNumberOfTitles = pagesTabControl.TabPages.Count;
                dotsOnEnd = false;
            }

            String titles = String.Empty;
            for (int i = 0; i < maxNumberOfTitles; i++)
            {
                XtraTabPage tabPage = pagesTabControl.TabPages[i];

                if (i < maxNumberOfTitles - 1)
                {
                    titles += "- " + tabPage.Text + Environment.NewLine;
                }
                else
                {
                    titles += "- " + tabPage.Text;
                }
            }

            if (dotsOnEnd && endsWithDotsIfTooMuchTitles)
            {
                titles += Environment.NewLine + "...";
            }

            return titles;
        }

        internal static void SetTabColor(XtraTabPage tabPage, Color newColor)
        {
            if (newColor == Color.Black)
            {
                tabPage.Appearance.Header.BackColor = Color.Transparent;
                tabPage.Appearance.HeaderActive.BackColor = Color.Transparent;
            }
            else
            {
                tabPage.Appearance.Header.BackColor = newColor;
                tabPage.Appearance.HeaderActive.BackColor = newColor;
            }
        }

        internal static Color GetTabColor(XtraTabPage tabPage)
        {
            Color actualColor = tabPage.Appearance.Header.BackColor;
            return (actualColor == Color.Transparent || actualColor.Name == "0") ? Color.Black : actualColor;
        }

        internal static bool AreAllTabsEmpty(Form1 form)
        {
            CustomXtraTabControl pagesTabControl = form.pagesTabControl;

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                if (!String.IsNullOrEmpty(ProgramUtil.GetPageTextBox(tabPage).Text))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool AreAllTabsEmptyAndWithoutFiles(Form1 form)
        {
            CustomXtraTabControl pagesTabControl = form.pagesTabControl;

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                if (!String.IsNullOrEmpty(ProgramUtil.GetPageTextBox(tabPage).Text) || !String.IsNullOrEmpty(ProgramUtil.GetFilenameTabPage(tabPage)))
                {
                    return false;
                }
            }

            return true;
        }

        internal static void ToggleTabMoveButtons(Form1 form, TreeNode node, int count)
        {
            ToolStripButton moveTabFirstToolStripButton = form.tabPanel.moveTabFirstToolStripButton;
            ToolStripButton moveTabUpToolStripButton = form.tabPanel.moveTabUpToolStripButton;
            ToolStripButton moveTabDownToolStripButton = form.tabPanel.moveTabDownToolStripButton;
            ToolStripButton moveTabLastToolStripButton = form.tabPanel.moveTabLastToolStripButton;

            if (node.Index == 0)
            {
                moveTabFirstToolStripButton.Enabled = false;
                moveTabUpToolStripButton.Enabled = false;
            }
            else
            {
                moveTabFirstToolStripButton.Enabled = true;
                moveTabUpToolStripButton.Enabled = true;
            }

            if (node.Index == count - 1)
            {
                moveTabDownToolStripButton.Enabled = false;
                moveTabLastToolStripButton.Enabled = false;
            }
            else
            {
                moveTabDownToolStripButton.Enabled = true;
                moveTabLastToolStripButton.Enabled = true;
            }
        }

        #endregion Internal Methods

        #region Event Methods

        internal static void MouseUpOnTab(Form1 form, MouseEventArgs e)
        {
            CustomXtraTabControl pagesTabControl = form.pagesTabControl;

            PropertyInfo tabProperties = pagesTabControl.GetType().GetProperty("ViewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
            BaseTabControlViewInfo tabViewInfo = tabProperties.GetValue(pagesTabControl, null) as BaseTabControlViewInfo;
            if (tabViewInfo != null && !tabViewInfo.SelectedTabPageViewInfo.Bounds.Contains(e.Location))
            {
                return;
            }

            switch (e.Button)
            {
                case MouseButtons.Middle:
                    ClosePage(form);
                    break;
            }
        }

        internal static void TabSelection(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Select();
            form.Text = String.Format("DtPad - {0}", pagesTabControl.SelectedTabPage.Text);

            bool enabled = !String.IsNullOrEmpty(ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage));

            ToggleTabFileTools(form, enabled);
            ReadInsertMode(form);
        }

        internal static void TabTextChange(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (pageTextBox.Text.GetHashCode().ToString() != pageTextBox.CustomOriginal && !TabUtil.IsTabPageModified(pagesTabControl.SelectedTabPage))
            {
                pagesTabControl.SelectedTabPage.ImageIndex = pagesTabControl.SelectedTabPage.ImageIndex + 1;
                pagesTabControl.SelectedTabPage.Text = String.Format("*{0}", pagesTabControl.SelectedTabPage.Text);
                pageTextBox.CustomModified = true;
            }
            else if ((pageTextBox.Text.GetHashCode().ToString() == pageTextBox.CustomOriginal && TabUtil.IsTabPageModified(pagesTabControl.SelectedTabPage)) || String.IsNullOrEmpty(pageTextBox.Text) && String.IsNullOrEmpty(pageTextBox.CustomOriginal))
            {
                switch (pagesTabControl.SelectedTabPage.ImageIndex)
                {
                    case 1:
                        pagesTabControl.SelectedTabPage.ImageIndex = 0;
                        break;
                    case 3:
                        pagesTabControl.SelectedTabPage.ImageIndex = 2;
                        break;
                }
                pagesTabControl.SelectedTabPage.Text = String.Format("{0}", pagesTabControl.SelectedTabPage.Text.Substring(1));
                pageTextBox.CustomModified = false;
            }

            form.Text = String.Format("DtPad - {0}", pagesTabControl.SelectedTabPage.Text);
        }

        internal static void TabKeyUp(Form1 form)
        {
            ToolStripStatusLabel rowToolStripStatusLabel1 = form.rowToolStripStatusLabel1;

            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            rowToolStripStatusLabel1.Text = (TextManager.ReadRTBLineFromCharIndex(form, pageTextBox.GetFirstCharIndexOfCurrentLine()) + 1).ToString();
        }

        internal static void RefreshStatistics(Form1 form)
        {
            ToolStripMenuItem charactersStatToolStripMenuItem = form.charactersStatToolStripMenuItem;
            ToolStripMenuItem rowsStatToolStripMenuItem = form.rowsStatToolStripMenuItem;
            ToolStripMenuItem columnsStatToolStripMenuItem = form.columnsStatToolStripMenuItem;
            ToolStripMenuItem wordsStatToolStripMenuItem = form.wordsStatToolStripMenuItem;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            charactersStatToolStripMenuItem.Text = LanguageUtil.GetCurrentLanguageString("charactersStatToolStripMenuItem", form.Name) + " " + pageTextBox.Text.Replace(ConstantUtil.newLine, String.Empty).Replace("\t", String.Empty).Length;

            int rowNumbers = pageTextBox.Lines.Length;
            if (rowNumbers == 0)
            {
                rowNumbers = 1;
            }
            rowsStatToolStripMenuItem.Text = LanguageUtil.GetCurrentLanguageString("rowsStatToolStripMenuItem", form.Name) + " " + rowNumbers;

            String[] separator = { ConstantUtil.newLine };
            //String[] lines = pageTextBox.Text.Split(separator, StringSplitOptions.None);
            //foreach (String line in lines)
            //{
            //    if (line.Length > columnNumbers)
            //    {
            //        columnNumbers = line.Length;
            //    }
            //}
            String[] lines = pageTextBox.Text.Split(separator, StringSplitOptions.None);
            int columnNumbers = lines.Select(line => line.Length).Concat(new[] { 0 }).Max();

            columnsStatToolStripMenuItem.Text = LanguageUtil.GetCurrentLanguageString("columnsStatToolStripMenuItem", form.Name) + " " + columnNumbers;

            String[] separator2 = { " ", ConstantUtil.newLine };
            wordsStatToolStripMenuItem.Text = LanguageUtil.GetCurrentLanguageString("wordsStatToolStripMenuItem", form.Name) + " " + pageTextBox.Text.Split(separator2, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        internal static void TabMouseDoubleClick(Form1 form, MouseEventArgs e)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            PropertyInfo tabProperties = pagesTabControl.GetType().GetProperty("ViewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
            BaseTabControlViewInfo tabViewInfo = tabProperties.GetValue(pagesTabControl, null) as BaseTabControlViewInfo;

            if (tabViewInfo != null && tabViewInfo.HeaderInfo.ButtonsBounds.Contains(e.Location))
            {
                return;
            }
            if (e.Button != MouseButtons.Left || form.WindowMode == CustomForm.WindowModeEnum.Note)
            {
                return;
            }
            form.TabIdentity = AddNewPage(form, form.TabIdentity);
        }

        internal static void SelectTabByOpenedFileName(Form1 form, String fileName)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                if (ProgramUtil.GetFilenameTabPage(tabPage) != fileName)
                {
                    continue;
                }

                pagesTabControl.SelectedTabPage = tabPage;
                return;
            }
        }

        #endregion Event Methods

        #region Private Methods

        private static int GetZoomFromTrackBar(TrackBarControl zoomTrackBarControl)
        {
            switch (zoomTrackBarControl.Value)
            {
                case 0:
                    return 50;
                case 1:
                    return 75;
                case 2:
                    return 100;
                case 3:
                    return 150; //125
                case 4:
                    return 200; //150

                default:
                    return 100;
            }
        }

        private static void SetTrackBarFromZoom(TrackBarControl zoomTrackBarControl, int zoomInt)
        {
            switch (zoomInt)
            {
                case 50:
                    zoomTrackBarControl.Value = 0;
                    break;
                case 75:
                    zoomTrackBarControl.Value = 1;
                    break;
                case 100:
                    zoomTrackBarControl.Value = 2;
                    break;
                case 150: //125
                    zoomTrackBarControl.Value = 3;
                    break;
                case 200: //150
                    zoomTrackBarControl.Value = 4;
                    break;

                default:
                    zoomTrackBarControl.Value = 2;
                    break;
            }
        }

        private static void ReadInsertMode(Form1 form)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            ToolStripStatusLabel insertModeToolStripStatusLabel = form.insertModeToolStripStatusLabel;

            insertModeToolStripStatusLabel.Text = pageTextBox.CustomInsertMode;
        }

        #endregion Private Methods

        //internal static void HideTabBar(Form1 form)
        //{
        //    XtraTabControl pagesTabControl = form.pagesTabControl;

        //    pagesTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        //}
    }
}
