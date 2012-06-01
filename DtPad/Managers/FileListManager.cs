using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DtPad.Objects;
using DtPad.Utils;
using ComboBox = System.Windows.Forms.ComboBox;

namespace DtPad.Managers
{
    /// <summary>
    /// File list manager (recents, favoutites, search history, tools and sessions).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class FileListManager
    {
        private const String className = "FileListManager";
        private const int maxCharsNumber = 150;
        private enum FileType
        {
            [Description("Recent file")]
            Recent,
            [Description("Favourite file")]
            Favourite
        }

        #region Generic Internal Methods

        internal static void SaveFileList(String file, String content)
        {
            //StreamWriter textFileWriter = null;
            //try
            //{
            //    textFileWriter = File.CreateText(Path.Combine(ConstantUtil.ApplicationExecutionPath(), file));
            //    textFileWriter.Write(content);
            //}
            //finally
            //{
            //    if (textFileWriter != null)
            //    {
            //        textFileWriter.Close();
            //    }
            //}

            FileStream fileStream = null;
            StreamWriter textFile = null;

            try
            {
                fileStream = File.Create(Path.Combine(ConstantUtil.ApplicationExecutionPath(), file));
                textFile = new StreamWriter(fileStream, Encoding.Default);
                textFile.Write(content);
            }
            finally
            {
                if (textFile != null)
                {
                    textFile.Close();
                }
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        #endregion Generic Internal Methods

        #region Recent Files Methods

        internal static void SetNewRecentFile(Form1 form, String pathAndFileName)
        {
            int maxRecentFile = ConfigUtil.GetIntParameter("MaxNumRecentFile");
            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.rfFile));

            //Opening-saving file has already been censed into file
            if (fileContent.IndexOf(pathAndFileName + Environment.NewLine) >= 0)
            {
                fileContent = fileContent.Remove(fileContent.IndexOf(pathAndFileName + Environment.NewLine), pathAndFileName.Length + Environment.NewLine.Length);
            }

            String[] rows = fileContent.Replace(Environment.NewLine, ConstantUtil.newLine).Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Length >= maxRecentFile) //recentFilesToolStripMenuItem.DropDownItems.Count >= maxRecentFile
            {
                fileContent = String.Empty;

                for (int i = 0; i < maxRecentFile - 1; i++)
                {
                    fileContent += rows[i] + Environment.NewLine;
                }
            }

            fileContent = pathAndFileName + Environment.NewLine + fileContent;

            SaveFileList(ConstantUtil.rfFile, fileContent);
            LoadRecentFiles(form, true);
        }

        internal static void LoadRecentFiles(Form1 form, bool forceLoad, bool shortUrl = false)
        {
            ToolStripMenuItem recentFilesToolStripMenuItem = form.recentFilesToolStripMenuItem;

            if (!forceLoad && recentFilesToolStripMenuItem.DropDownItems.Count > 3)
            {
                return;
            }
            
            while (recentFilesToolStripMenuItem.DropDownItems.Count > 3)
            {
                recentFilesToolStripMenuItem.DropDownItems.Remove(recentFilesToolStripMenuItem.DropDownItems[3]);
            }

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.rfFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                String text = splittedFileContentString;

                if (shortUrl)
                {
                    text = StringUtil.CheckStringLength(text, maxCharsNumber);
                }

                recentFilesToolStripMenuItem.DropDownItems.Add(text, null, form.recentFileToolStripMenuItem_Click);
            }
        }

        internal static void ClearRecentFiles(Form1 form)
        {
            ToolStripMenuItem recentFilesToolStripMenuItem = form.recentFilesToolStripMenuItem;

            if (recentFilesToolStripMenuItem.DropDownItems.Count <= 3)
            {
                return;
            }

            if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("ClearHistoryRecentFiles", className)) != DialogResult.Yes)
            {
                return;
            }

            SaveFileList(ConstantUtil.rfFile, String.Empty);
            LoadRecentFiles(form, true);
        }

        internal static void ClearObsoleteRecentFiles(Form1 form)
        {
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripMenuItem recentFilesToolStripMenuItem = form.recentFilesToolStripMenuItem;

            if (recentFilesToolStripMenuItem.DropDownItems.Count <= 3)
            {
                return;
            }

            if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("ClearObsoleteRecentFiles", className)) != DialogResult.Yes)
            {
                return;
            }

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.rfFile));
            String newFileContent = String.Empty;
            int removedOccurences = 0;
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                FileInfo fileInfo = new FileInfo(splittedFileContentString);

                if (fileInfo.Exists)
                {
                    newFileContent += splittedFileContentString + Environment.NewLine;
                }
                else
                {
                    removedOccurences++;
                }
            }

            SaveFileList(ConstantUtil.rfFile, newFileContent);
            toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("ObsoleteFilesRemoved", className, removedOccurences), removedOccurences);
            LoadRecentFiles(form, true);
        }

        internal static void RefreshRecentFiles(Form1 form)
        {
            int maxRecentFile = ConfigUtil.GetIntParameter("MaxNumRecentFile");

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.rfFile));
            String[] rows = fileContent.Replace(Environment.NewLine, ConstantUtil.newLine).Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length >= maxRecentFile)
            {
                fileContent = String.Empty;

                for (int i = 0; i < maxRecentFile; i++)
                {
                    fileContent += rows[i] + Environment.NewLine;
                }
            }

            SaveFileList(ConstantUtil.rfFile, fileContent);
            LoadRecentFiles(form, true);
        }

        internal static void LoadTrayRecentFiles(Form1 form)
        {
            ToolStripMenuItem recentFilesToolStripMenuItem1 = (ToolStripMenuItem)form.trayContextMenuStrip.Items["recentFilesToolStripMenuItem1"];

            while (recentFilesToolStripMenuItem1.DropDownItems.Count > 0)
            {
                recentFilesToolStripMenuItem1.DropDownItems.Remove(recentFilesToolStripMenuItem1.DropDownItems[0]);
            }

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.rfFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                recentFilesToolStripMenuItem1.DropDownItems.Add(splittedFileContentString, null, form.recentFileToolStripMenuItem1_Click);
            }
        }

        internal static void LoadSplitRecentFiles(Form1 form)
        {
            ToolStripSplitButton openToolStripSplitButton = form.openToolStripSplitButton;

            LoadButtonFiles(form, openToolStripSplitButton, ConstantUtil.rfFile, FileType.Recent);
            openToolStripSplitButton.DropDown.Enabled = openToolStripSplitButton.HasDropDownItems;
        }

        #endregion Recent Files Methods

        #region Favourite Files Methods

        internal static bool ExistsFavouriteFile()
        {
            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.fvFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            return splittedFileContent.Length > 0;
        }

        internal static void SetNewFavouriteFile(Form1 form, String pathAndFileName)
        {
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            
            String fileContent;

            if (FavouriteManager.IsFileFavourite(pathAndFileName, out fileContent))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("AlreadyFavourite", className));
                return;
            }

            fileContent = fileContent + pathAndFileName + Environment.NewLine;

            SaveFileList(ConstantUtil.fvFile, fileContent);
            LoadFavouriteFiles(form, true);

            if (pathAndFileName.StartsWith(ConstantUtil.sessionPrefix))
            {
                pathAndFileName = pathAndFileName.Substring(ConstantUtil.sessionPrefix.Length);
            }
            FileInfo fileInfo = new FileInfo(pathAndFileName);
            String addedFavourite = String.Format(LanguageUtil.GetCurrentLanguageString("AddedFavourite", className), fileInfo.Name);

            toolStripStatusLabel.Text = addedFavourite.EndsWith(".") ? addedFavourite.Substring(0, addedFavourite.Length - 1) : addedFavourite;
            WindowManager.ShowInfoBox(form, addedFavourite);
        }

        internal static void LoadFavouriteFiles(Form1 form, bool forceLoad, bool shortUrl = false)
        {
            ToolStripMenuItem favouriteFilesToolStripMenuItem = form.favouriteFilesToolStripMenuItem;

            if (!forceLoad && favouriteFilesToolStripMenuItem.DropDownItems.Count > 3)
            {
                return;
            }

            while (favouriteFilesToolStripMenuItem.DropDownItems.Count > 3)
            {
                favouriteFilesToolStripMenuItem.DropDownItems.Remove(favouriteFilesToolStripMenuItem.DropDownItems[3]);
            }

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.fvFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                Image icon = null;
                String text = splittedFileContentString;

                if (splittedFileContentString.StartsWith("[S] "))
                {
                    icon = ToolbarResource.session_small;
                    text = text.Substring(4);
                }
                if (shortUrl)
                {
                    text = StringUtil.CheckStringLength(text, maxCharsNumber);
                }

                favouriteFilesToolStripMenuItem.DropDownItems.Add(text, icon, form.favouriteFileToolStripMenuItem_Click);
            }
        }

        internal static void LoadFavouriteWindowFiles(Favourites form)
        {
            ListBox favouritesListBox = form.favouritesListBox;

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.fvFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                favouritesListBox.Items.Add(splittedFileContentString); //StringUtil.CheckStringLength(splittedFileContentString, 60)
            }
        }

        internal static void DeleteExistingFavouriteFile(Form1 form, int filePosition)
        {
            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.fvFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            fileContent = splittedFileContent.Where((t, i) => i != filePosition).Aggregate(String.Empty, (current, t) => current + t + Environment.NewLine);
            //for (int i = 0; i < splittedFileContent.Length; i++)
            //{
            //    if (i != filePosition)
            //    {
            //        fileContent = fileContent + splittedFileContent[i] + Environment.NewLine;
            //    }
            //}

            SaveFileList(ConstantUtil.fvFile, fileContent);
            LoadFavouriteFiles(form, true);
        }

        internal static void LoadSplitFavouriteFiles(Form1 form)
        {
            ToolStripDropDownButton favouriteFilesToolStripDropDownButton = form.favouriteFilesToolStripDropDownButton;

            LoadButtonFiles(form, favouriteFilesToolStripDropDownButton, ConstantUtil.fvFile, FileType.Favourite);
            favouriteFilesToolStripDropDownButton.Enabled = favouriteFilesToolStripDropDownButton.HasDropDownItems;
        }

        internal static void CreateFileFromListBox(Favourites form)
        {
            ListBox favouritesListBox = form.favouritesListBox;

            String fileContent = favouritesListBox.Items.Cast<object>().Aggregate(String.Empty, (current, favourite) => current + (favourite + Environment.NewLine));
            //String fileContent = String.Empty;
            //foreach (object favourite in favouritesListBox.Items)
            //{
            //    fileContent += favourite + Environment.NewLine;
            //}

            SaveFileList(ConstantUtil.fvFile, fileContent);
        }

        #endregion Favourite Files Methods

        #region Search History Methods

        internal static void SetNewSearchHistory(Form1 form, String searchText)
        {
            int maxSearchHistory = ConfigUtil.GetIntParameter("MaxNumSearchHistory");
            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.shFile));

            if (fileContent.IndexOf(searchText + Environment.NewLine) >= 0)
            {
                return; //Opening-saving file has already been censed into file
            }

            String[] rows = fileContent.Replace(Environment.NewLine, ConstantUtil.newLine).Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length >= maxSearchHistory) //historyToolStripDropDownButton.DropDownItems.Count >= maxRecentFile
            {
                fileContent = String.Empty;

                for (int i = 0; i < maxSearchHistory - 1; i++)
                {
                    fileContent += rows[i] + Environment.NewLine;
                }
            }

            fileContent = searchText + Environment.NewLine + fileContent;

            SaveFileList(ConstantUtil.shFile, fileContent);
            LoadSearchHistory(form);
        }

        internal static void LoadSearchHistory(Form1 form)
        {
            ToolStripDropDownButton historyToolStripDropDownButton = form.searchPanel.historyToolStripDropDownButton;

            while (historyToolStripDropDownButton.DropDownItems.Count > 2)
            {
                historyToolStripDropDownButton.DropDownItems.Remove(historyToolStripDropDownButton.DropDownItems[2]);
            }

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.shFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem
                                                {
                                                    Text = StringUtil.CheckStringLengthEnd(splittedFileContentString.Replace(ConstantUtil.newLine, "\\n"), 50),
                                                    Tag = splittedFileContentString.Replace(ConstantUtil.newLine, Environment.NewLine),
                                                    ToolTipText = splittedFileContentString
                                                };
                newItem.Click += form.historyToolStripDropDownButton_Click;

                historyToolStripDropDownButton.DropDownItems.Add(newItem);
            }
        }

        internal static void ClearSearchHistory(Form1 form)
        {
            SaveFileList(ConstantUtil.shFile, String.Empty);
            LoadSearchHistory(form);
        }

        internal static void RefreshSearchHistory(Form1 form)
        {
            int maxNumSearchHistory = ConfigUtil.GetIntParameter("MaxNumSearchHistory");

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.shFile));
            String[] rows = fileContent.Replace(Environment.NewLine, ConstantUtil.newLine).Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length >= maxNumSearchHistory)
            {
                fileContent = String.Empty;

                for (int i = 0; i < maxNumSearchHistory; i++)
                {
                    fileContent += rows[i] + Environment.NewLine;
                }
            }

            SaveFileList(ConstantUtil.shFile, fileContent);
            LoadSearchHistory(form);
        }

        #endregion Search History Methods

        #region Tools Methods

        internal static void LoadTools(Form1 form)
        {
            ToolStripMenuItem toolsToolStripMenuItem = form.toolsToolStripMenuItem;

            ToolStripMenuItem emptyToolStripMenuItem = new ToolStripMenuItem
                                                           {
                                                               Enabled = false,
                                                               Name = "emptyToolStripMenuItem",
                                                               Size = new Size(152, 22),
                                                               Text = LanguageUtil.GetCurrentLanguageString("emptyToolStripMenuItem", form.Name)
                                                           };

            ToolStripSeparator toolStripSeparator11 = new ToolStripSeparator
                                                          {
                                                              Name = "toolStripSeparator11",
                                                              Size = new Size(149, 6)
                                                          };

            ToolStripMenuItem addNewToolToolStripMenuItem = new ToolStripMenuItem
                                                                {
                                                                    Image = ToolbarResource.tag,
                                                                    Name = "addNewToolToolStripMenuItem",
                                                                    Size = new Size(152, 22),
                                                                    Text = LanguageUtil.GetCurrentLanguageString("addNewToolToolStripMenuItem", form.Name) //manageToolStripMenuItem
                                                                };
            addNewToolToolStripMenuItem.Click += form.addNewToolToolStripMenuItem_Click;

            ToolObjectList toolObjectList = ToolManager.GetToolObjectListFromToFile(form);
            if (toolObjectList.Count == 0)
            {
                toolsToolStripMenuItem.DropDownItems.Clear();
                toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { emptyToolStripMenuItem, toolStripSeparator11, addNewToolToolStripMenuItem });
            }
            else
            {
                toolsToolStripMenuItem.DropDownItems.Clear();
                
                foreach (ToolObject toolObject in toolObjectList)
                {
                    String toolStripMenuItemName = String.Format("{0}ToolStripMenuItem", toolObject.Description.ToLower());
                    ToolStripMenuItem newToolToolStripMenuItem = new ToolStripMenuItem
                                                                     {
                                                                         Name = toolStripMenuItemName,
                                                                         Text = toolObject.Description,
                                                                         ToolTipText = toolObject.CommandLine,
                                                                         Tag = toolObject.WorkingFolder,
                                                                         AccessibleDescription = toolObject.Run.ToString()
                                                                     };
                    newToolToolStripMenuItem.Click += form.newToolToolStripMenuItem_Click;
                    toolsToolStripMenuItem.DropDownItems.Add(newToolToolStripMenuItem);
                }

                toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator11, addNewToolToolStripMenuItem });
            }

            form.ToolsFirstLoadExecuted = true;
        }

        #endregion Tools Methods

        #region Templates Methods

        internal static void LoadTemplates(Form1 form)
        {
            ToolStripMenuItem templatesToolStripMenuItem = form.templatesToolStripMenuItem;

            ToolStripMenuItem emptyTemplateToolStripMenuItem = new ToolStripMenuItem
                                                                   {
                                                                       Enabled = false,
                                                                       Name = "emptyTemplateToolStripMenuItem",
                                                                       Size = new Size(152, 22),
                                                                       Text = LanguageUtil.GetCurrentLanguageString("emptyTemplateToolStripMenuItem", "Form1")
                                                                   };

            ToolStripSeparator toolStripSeparator56 = new ToolStripSeparator
                                                          {
                                                              Name = "toolStripSeparator56",
                                                              Size = new Size(149, 6)
                                                          };

            ToolStripMenuItem addNewTemplateToolStripMenuItem = new ToolStripMenuItem
                                                                {
                                                                    Name = "addNewTemplateToolStripMenuItem",
                                                                    Size = new Size(152, 22),
                                                                    Text = LanguageUtil.GetCurrentLanguageString("addNewTemplateToolStripMenuItem", "Form1")
                                                                };
            addNewTemplateToolStripMenuItem.Click += form.addNewTemplateToolStripMenuItem_Click;

            TemplateObjectList templateObjectList = TemplateManager.GetTemplateObjectListFromTmFile(form);
            if (templateObjectList.Count == 0)
            {
                templatesToolStripMenuItem.DropDownItems.Clear();
                templatesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { emptyTemplateToolStripMenuItem, toolStripSeparator56, addNewTemplateToolStripMenuItem });
            }
            else
            {
                templatesToolStripMenuItem.DropDownItems.Clear();

                foreach (TemplateObject templateObject in templateObjectList)
                {
                    String toolStripMenuItemName = String.Format("{0}ToolStripMenuItem", templateObject.Description.ToLower());
                    ToolStripMenuItem newToolToolStripMenuItem = new ToolStripMenuItem
                                                                     {
                                                                         Name = toolStripMenuItemName,
                                                                         Text = templateObject.Description,
                                                                         ToolTipText = templateObject.Description,
                                                                         Tag = templateObject.Text
                                                                     };
                    newToolToolStripMenuItem.Click += form.newTemplateToolStripMenuItem_Click;
                    templatesToolStripMenuItem.DropDownItems.Add(newToolToolStripMenuItem);
                }

                templatesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator56, addNewTemplateToolStripMenuItem });
            }
        }

        #endregion Tools Methods

        #region Sessions Methods

        internal static void SetNewRecentSession(Form1 form, String pathAndFileName)
        {
            int maxRecentFile = ConfigUtil.GetIntParameter("MaxNumRecentFile");
            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.rsFile));

            //Opening-saving file has already been censed into file
            if (fileContent.IndexOf(pathAndFileName + Environment.NewLine) >= 0)
            {
                fileContent = fileContent.Remove(fileContent.IndexOf(pathAndFileName + Environment.NewLine), pathAndFileName.Length + Environment.NewLine.Length);
            }

            String[] rows = fileContent.Replace(Environment.NewLine, ConstantUtil.newLine).Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length >= maxRecentFile) //recentSessionsToolStripMenuItem.DropDownItems.Count >= maxRecentFile
            {
                fileContent = String.Empty;

                for (int i = 0; i < maxRecentFile - 1; i++)
                {
                    fileContent += rows[i] + Environment.NewLine;
                }
            }

            fileContent = pathAndFileName + Environment.NewLine + fileContent;

            SaveFileList(ConstantUtil.rsFile, fileContent);
            LoadRecentSessions(form, true);
        }

        internal static void LoadRecentSessions(Form1 form, bool forceLoad)
        {
            ToolStripMenuItem recentSessionsToolStripMenuItem = form.recentSessionsToolStripMenuItem;

            if (!forceLoad && recentSessionsToolStripMenuItem.DropDownItems.Count > 3)
            {
                return;
            }

            while (recentSessionsToolStripMenuItem.DropDownItems.Count > 3)
            {
                recentSessionsToolStripMenuItem.DropDownItems.Remove(recentSessionsToolStripMenuItem.DropDownItems[3]);
            }

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.rsFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                recentSessionsToolStripMenuItem.DropDownItems.Add(splittedFileContentString, ToolbarResource.session_small, form.recentSessionToolStripMenuItem_Click);
            }
        }

        internal static void ClearRecentSessions(Form1 form)
        {
            ToolStripMenuItem recentSessionsToolStripMenuItem = form.recentSessionsToolStripMenuItem;

            if (recentSessionsToolStripMenuItem.DropDownItems.Count <= 3)
            {
                return;
            }

            if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("ClearHistoryRecentSessions", className)) != DialogResult.Yes)
            {
                return;
            }

            SaveFileList(ConstantUtil.rsFile, String.Empty);
            LoadRecentSessions(form, true);
        }

        internal static void ClearObsoleteRecentSessions(Form1 form)
        {
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripMenuItem recentSessionsToolStripMenuItem = form.recentSessionsToolStripMenuItem;

            if (recentSessionsToolStripMenuItem.DropDownItems.Count <= 3)
            {
                return;
            }

            if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("ClearObsoleteRecentSessions", className)) != DialogResult.Yes)
            {
                return;
            }

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.rsFile));
            String newFileContent = String.Empty;
            int removedOccurences = 0;
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                FileInfo fileInfo = new FileInfo(splittedFileContentString);

                if (fileInfo.Exists)
                {
                    newFileContent += splittedFileContentString + Environment.NewLine;
                }
                else
                {
                    removedOccurences++;
                }
            }

            SaveFileList(ConstantUtil.rsFile, newFileContent);
            toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("ObsoleteSessionsRemoved", className, removedOccurences), removedOccurences);
            LoadRecentSessions(form, true);
        }

        #endregion Sessions Methods

        #region Patterns Methods

        internal static void SetNewRecentPattern(SearchPattern form, String regularExpression)
        {
            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.rpFile));

            //Opening-saving patterns has already been censed into file
            if (fileContent.IndexOf(regularExpression + Environment.NewLine) >= 0)
            {
                fileContent = fileContent.Remove(fileContent.IndexOf(regularExpression + Environment.NewLine), regularExpression.Length + Environment.NewLine.Length);
            }

            fileContent = regularExpression + Environment.NewLine + fileContent;

            SaveFileList(ConstantUtil.rpFile, fileContent);
            LoadRecentPatterns(form);
        }

        internal static void LoadRecentPatterns(SearchPattern form)
        {
            ComboBox historyComboBox = form.historyComboBox;

            historyComboBox.Items.Clear();
            historyComboBox.Items.Add(String.Empty);

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.rpFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                historyComboBox.Items.Add(splittedFileContentString);
            }
        }

        internal static void ClearRecentPatterns(SearchPattern form)
        {
            if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("ClearHistoryRecentPatterns", className)) != DialogResult.Yes)
            {
                return;
            }

            SaveFileList(ConstantUtil.rpFile, String.Empty);
            LoadRecentPatterns(form);
        }

        #endregion Patterns Methods

        #region Search In Files History Methods

        internal static void SetNewRecentSearchInFilesDirs(SearchInFiles form, String path)
        {
            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.sfFile));

            const int maxRecentFolders = 10;

            //Opening-saving patterns has already been censed into file
            if (fileContent.IndexOf(path + Environment.NewLine) >= 0)
            {
                fileContent = fileContent.Remove(fileContent.IndexOf(path + Environment.NewLine), path.Length + Environment.NewLine.Length);
            }

            String[] rows = fileContent.Replace(Environment.NewLine, ConstantUtil.newLine).Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length >= maxRecentFolders)
            {
                fileContent = String.Empty;
                
                for (int i = 0; i < maxRecentFolders - 1; i++)
                {
                    fileContent += rows[i] + Environment.NewLine;
                } 
            }

            fileContent = path + Environment.NewLine + fileContent;

            SaveFileList(ConstantUtil.sfFile, fileContent);
            LoadRecentSearchInFilesDirs(form);
        }

        internal static void LoadRecentSearchInFilesDirs(SearchInFiles form)
        {
            ComboBox searchFolderComboBox = form.searchFolderComboBox;

            searchFolderComboBox.Items.Clear();
            searchFolderComboBox.Items.Add(String.Empty);

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.sfFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                searchFolderComboBox.Items.Add(splittedFileContentString);
            }
        }

        #endregion Search In Files History Methods

        #region Recent URLs Methods

        internal static void SetNewRecentURL(UrlEntry form, String urlAddress)
        {
            int maxRecentURLs = ConfigUtil.GetIntParameter("MaxNumRecentFile");
            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.ruFile));

            //Opening-saving file has already been censed into file
            if (fileContent.IndexOf(urlAddress + Environment.NewLine) >= 0)
            {
                fileContent = fileContent.Remove(fileContent.IndexOf(urlAddress + Environment.NewLine), urlAddress.Length + Environment.NewLine.Length);
            }

            String[] rows = fileContent.Replace(Environment.NewLine, ConstantUtil.newLine).Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length >= maxRecentURLs)
            {
                fileContent = String.Empty;

                for (int i = 0; i < maxRecentURLs - 1; i++)
                {
                    fileContent += rows[i] + Environment.NewLine;
                }
            }

            fileContent = urlAddress + Environment.NewLine + fileContent;

            SaveFileList(ConstantUtil.ruFile, fileContent);
            LoadRecentURLs(form);
        }

        internal static void LoadRecentURLs(UrlEntry form)
        {
            ComboBoxEdit urlAddressTextBox = form.urlAddressTextBox;

            urlAddressTextBox.Properties.Items.Clear();
            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.ruFile));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                urlAddressTextBox.Properties.Items.Add(splittedFileContentString);
            }
        }

        internal static void ClearRecentURLs(UrlEntry form)
        {
            SaveFileList(ConstantUtil.ruFile, String.Empty);
            LoadRecentURLs(form);
        }

        #endregion Recent URLs Methods

        #region Private Methods

        private static void LoadButtonFiles(Form1 form, ToolStripDropDownItem toolStripMenuItem, String file, FileType fileType)
        {
            while (toolStripMenuItem.DropDownItems.Count > 0)
            {
                toolStripMenuItem.DropDownItems.Remove(toolStripMenuItem.DropDownItems[0]);
            }

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), file));
            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String splittedFileContentString in splittedFileContent)
            {
                switch (fileType)
                {
                    case FileType.Recent:
                        toolStripMenuItem.DropDownItems.Add(StringUtil.CheckStringLength(splittedFileContentString, maxCharsNumber), null, form.recentFileToolStripMenuItem_Click);
                        break;
                    case FileType.Favourite:
                        Image icon = null;
                        String text = splittedFileContentString;

                        if (splittedFileContentString.StartsWith("[S] "))
                        {
                            icon = ToolbarResource.session_small;
                            text = text.Substring(4);
                        }

                        toolStripMenuItem.DropDownItems.Add(StringUtil.CheckStringLength(text, maxCharsNumber), icon, form.favouriteFileToolStripMenuItem_Click);
                        break;
                }
            }
        }

        #endregion Private Methods
    }
}
