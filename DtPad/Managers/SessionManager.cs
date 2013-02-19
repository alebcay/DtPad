using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Exceptions;
using DtPad.Utils;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace DtPad.Managers
{
    /// <summary>
    /// Session manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class SessionManager
    {
        private const String className = "SessionManager";
        private const int startPositionToReadSessionFiles = 2;
        private static bool stopImportSession;
        private static bool yesAllImportSession;

        #region Internal Methods

        internal static void OpenSession(Form1 form, String fileName = null)
        {
            CustomXtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStrip sessionToolStrip = form.sessionToolStrip;
            ToolStripButton sessionToolStripButton = form.sessionToolStripButton;
            ToolStripMenuItem closeToolStripMenuItem3 = form.closeToolStripMenuItem3;
            ToolStripMenuItem saveToolStripMenuItem2 = form.saveToolStripMenuItem2;
            ToolStripMenuItem exportAsZipToolStripMenuItem = form.exportAsZipToolStripMenuItem;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            OpenFileDialog openFileDialog = form.openFileDialog;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;
            //SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            ToolStripMenuItem renameSessionToolStripMenuItem = form.renameSessionToolStripMenuItem;
            ToolStripMenuItem favouriteSessionToolStripMenuItem = form.favouriteSessionToolStripMenuItem;
            ToolStripMenuItem listFilesToolStripMenuItem = form.listFilesToolStripMenuItem;
            ToolStripMenuItem aspectToolStripMenuItem = form.aspectToolStripMenuItem;
            ToolStripMenuItem useDefaultToolStripMenuItem = form.useDefaultToolStripMenuItem;
            ToolStripMenuItem closeButtonToolStripMenuItem = form.closeButtonToolStripMenuItem;
            ToolStripMenuItem tabPositionToolStripMenuItem = form.tabPositionToolStripMenuItem;
            ToolStripMenuItem tabOrientationToolStripMenuItem = form.tabOrientationToolStripMenuItem;
            ToolStripMenuItem sessionPropertiesToolStripMenuItem = form.sessionPropertiesToolStripMenuItem;

            try
            {
                bool isASessionOpened = IsASessionOpened(form);
                if (isASessionOpened && WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("AlreadyOpen", className)) != DialogResult.Yes)
                {
                    return;
                }
                if (isASessionOpened)
                {
                    CloseSession(form);
                }

                if (String.IsNullOrEmpty(fileName))
                {
                    openFileDialog.InitialDirectory = FileUtil.GetInitialFolder(form);
                    openFileDialog.Multiselect = false;
                    openFileDialog.Filter = LanguageUtil.GetCurrentLanguageString("FileDialog", className);
                    openFileDialog.FilterIndex = 0;
                    openFileDialog.FileName = "*.dps";
                    
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    fileName = openFileDialog.FileName;
                }

                if (!File.Exists(fileName))
                {
                    WindowManager.ShowAlertBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("FileNotExisting", className), fileName));
                    return;
                }
                if (FileUtil.IsFileInUse(fileName))
                {
                    WindowManager.ShowAlertBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("FileInUse", className), fileName));
                    return;
                }
                if (pagesTabControl.TabPages.Count > 1 && TabManager.AreAllTabsEmpty(form))
                {
                    if (!TabManager.CloseAllPages(form))
                    {
                        return;
                    }
                }

                bool loadTotallyFailed;
                String sessionName = ReadSessionXML(form, fileName, out loadTotallyFailed);
                toolStripProgressBar.Visible = false;

                if (loadTotallyFailed)
                {
                    return;
                }

                sessionToolStrip.Visible = true;
                sessionToolStripButton.Text = sessionName;
                closeToolStripMenuItem3.Enabled = true;
                saveToolStripMenuItem2.Enabled = true;
                exportAsZipToolStripMenuItem.Enabled = true;
                renameSessionToolStripMenuItem.Enabled = true;
                favouriteSessionToolStripMenuItem.Enabled = true;
                listFilesToolStripMenuItem.Enabled = true;
                aspectToolStripMenuItem.Enabled = true;
                useDefaultToolStripMenuItem.Enabled = true;
                sessionPropertiesToolStripMenuItem.Enabled = true;

                if (!useDefaultToolStripMenuItem.Checked)
                {
                    closeButtonToolStripMenuItem.Enabled = true;
                    tabPositionToolStripMenuItem.Enabled = true;
                    tabOrientationToolStripMenuItem.Enabled = true;

                    OptionManager.CheckTabCloseButton(form, GetDropDownIndexChecked(closeButtonToolStripMenuItem));
                    OptionManager.CheckTabPosition(form, GetDropDownIndexChecked(tabPositionToolStripMenuItem));
                    OptionManager.CheckTabOrientation(form, GetDropDownIndexChecked(tabOrientationToolStripMenuItem));
                }
                else
                {
                    closeButtonToolStripMenuItem.Enabled = false;
                    tabPositionToolStripMenuItem.Enabled = false;
                    tabOrientationToolStripMenuItem.Enabled = false;
                }

                ConfigUtil.UpdateParameter("LastUserFolder", Path.GetDirectoryName(fileName));
                FileListManager.SetNewRecentSession(form, fileName);

                //verticalSplitContainer.Panel1.Padding = new Padding(0);
                toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("Opened", className), sessionToolStripButton.Text);
            }
            catch (Exception exception)
            {
                OptionManager.CheckTabCloseButton(form, ConfigUtil.GetIntParameter("TabCloseButtonMode"));
                OptionManager.CheckTabPosition(form, ConfigUtil.GetIntParameter("TabPosition"));
                OptionManager.CheckTabOrientation(form, ConfigUtil.GetIntParameter("TabOrientation"));
                
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
        }

        internal static void CloseSession(Form1 form)
        {
            ToolStrip sessionToolStrip = form.sessionToolStrip;
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;
            ToolStripButton sessionToolStripButton = form.sessionToolStripButton;
            ToolStripMenuItem closeToolStripMenuItem3 = form.closeToolStripMenuItem3;
            ToolStripMenuItem saveToolStripMenuItem2 = form.saveToolStripMenuItem2;
            ToolStripMenuItem exportAsZipToolStripMenuItem = form.exportAsZipToolStripMenuItem;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            //SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripMenuItem renameSessionToolStripMenuItem = form.renameSessionToolStripMenuItem;
            ToolStripMenuItem favouriteSessionToolStripMenuItem = form.favouriteSessionToolStripMenuItem;
            ToolStripMenuItem listFilesToolStripMenuItem = form.listFilesToolStripMenuItem;
            ToolStripMenuItem aspectToolStripMenuItem = form.aspectToolStripMenuItem;
            ToolStripMenuItem useDefaultToolStripMenuItem = form.useDefaultToolStripMenuItem;
            ToolStripMenuItem closeButtonToolStripMenuItem = form.closeButtonToolStripMenuItem;
            ToolStripMenuItem tabPositionToolStripMenuItem = form.tabPositionToolStripMenuItem;
            ToolStripMenuItem tabOrientationToolStripMenuItem = form.tabOrientationToolStripMenuItem;
            ToolStripMenuItem sessionPropertiesToolStripMenuItem = form.sessionPropertiesToolStripMenuItem;

            if (CheckSessionOnClosing(form, true) == DialogResult.Cancel)
            {
                return;
            }

            for (int i = startPositionToReadSessionFiles; i < sessionImageToolStripButton.DropDownItems.Count; i++)
            {
                foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
                {
                    if (ProgramUtil.GetFilenameTabPage(tabPage) != sessionImageToolStripButton.DropDownItems[i].Text)
                    {
                        continue;
                    }

                    pagesTabControl.SelectedTabPage = tabPage;
                    TabManager.ClosePage(form);
                    break;
                }
            }

            sessionImageToolStripButton.DropDownItems.Clear();
            sessionToolStrip.Visible = false;
            closeToolStripMenuItem3.Enabled = false;
            saveToolStripMenuItem2.Enabled = false;
            exportAsZipToolStripMenuItem.Enabled = false;
            renameSessionToolStripMenuItem.Enabled = false;
            favouriteSessionToolStripMenuItem.Enabled = false;
            listFilesToolStripMenuItem.Enabled = false;
            aspectToolStripMenuItem.Enabled = false;
            sessionPropertiesToolStripMenuItem.Enabled = false;

            if (!useDefaultToolStripMenuItem.Checked)
            {
                OptionManager.CheckTabCloseButton(form, ConfigUtil.GetIntParameter("TabCloseButtonMode"));
                OptionManager.CheckTabPosition(form, ConfigUtil.GetIntParameter("TabPosition"));
                OptionManager.CheckTabOrientation(form, ConfigUtil.GetIntParameter("TabOrientation"));
            }

            useDefaultToolStripMenuItem.Enabled = false;
            closeButtonToolStripMenuItem.Enabled = false;
            tabPositionToolStripMenuItem.Enabled = false;
            tabOrientationToolStripMenuItem.Enabled = false;

            //verticalSplitContainer.Panel1.Padding = new Padding(3, 0, 0, 0);
            toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("Closed", className), sessionToolStripButton.Text);
        }

        internal static bool SaveSession(Form1 form, bool forcedSaveAs)
        {
            ToolStrip sessionToolStrip = form.sessionToolStrip;
            ToolStripButton sessionToolStripButton = form.sessionToolStripButton;
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;
            ToolStripMenuItem closeToolStripMenuItem3 = form.closeToolStripMenuItem3;
            ToolStripMenuItem saveToolStripMenuItem2 = form.saveToolStripMenuItem2;
            ToolStripMenuItem exportAsZipToolStripMenuItem = form.exportAsZipToolStripMenuItem;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            SaveFileDialog saveFileDialog = form.saveFileDialog;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;
            //SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            ToolStripMenuItem renameSessionToolStripMenuItem = form.renameSessionToolStripMenuItem;
            ToolStripMenuItem favouriteSessionToolStripMenuItem = form.favouriteSessionToolStripMenuItem;
            ToolStripMenuItem listFilesToolStripMenuItem = form.listFilesToolStripMenuItem;
            ToolStripMenuItem aspectToolStripMenuItem = form.aspectToolStripMenuItem;
            ToolStripMenuItem useDefaultToolStripMenuItem = form.useDefaultToolStripMenuItem;
            ToolStripMenuItem closeButtonToolStripMenuItem = form.closeButtonToolStripMenuItem;
            ToolStripMenuItem tabPositionToolStripMenuItem = form.tabPositionToolStripMenuItem;
            ToolStripMenuItem tabOrientationToolStripMenuItem = form.tabOrientationToolStripMenuItem;
            ToolStripMenuItem sessionPropertiesToolStripMenuItem = form.sessionPropertiesToolStripMenuItem;

            int tabsFillWithText = 0;

            foreach (XtraTabPage tabPage in form.pagesTabControl.TabPages)
            {
                if (TabUtil.IsTabPageModified(tabPage) && !String.IsNullOrEmpty(ProgramUtil.GetPageTextBox(tabPage).Text))
                {
                    tabsFillWithText++;
                    
                    if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("SaveAllFiles", className)) != DialogResult.Yes)
                    {
                        return false;
                    }
                    if (!FileManager.SaveAllFiles(form, false))
                    {
                        WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("SaveAllFilesFailed", className));
                        return false;
                    }

                    if (forcedSaveAs)
                    {
                        WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("SaveSession", className));
                    }
                    break;
                }
                
                if (!String.IsNullOrEmpty(ProgramUtil.GetPageTextBox(tabPage).Text))
                {
                    tabsFillWithText++;
                }
            }

            if (tabsFillWithText == 0)
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoContent", className));
                return false;
            }

            saveFileDialog.InitialDirectory = FileUtil.GetInitialFolder(form);
            saveFileDialog.Filter = LanguageUtil.GetCurrentLanguageString("FileDialog", className);
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "*.dps";

            try
            {
                String fileName;
                
                if (!forcedSaveAs)
                {
                    fileName = sessionImageToolStripButton.DropDownItems[0].Text;
                }
                else
                {
                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }

                    fileName = saveFileDialog.FileName;
                    if (!fileName.EndsWith(".dps"))
                    {
                        fileName += ".dps";
                    }
                }

                String sessionName = WriteSessionXML(form, fileName);

                toolStripProgressBar.Visible = false;
                sessionToolStrip.Visible = true;
                sessionToolStripButton.Text = sessionName;
                closeToolStripMenuItem3.Enabled = true;
                saveToolStripMenuItem2.Enabled = true;
                exportAsZipToolStripMenuItem.Enabled = true;
                renameSessionToolStripMenuItem.Enabled = true;
                favouriteSessionToolStripMenuItem.Enabled = true;
                listFilesToolStripMenuItem.Enabled = true;
                aspectToolStripMenuItem.Enabled = true;
                useDefaultToolStripMenuItem.Enabled = true;
                sessionPropertiesToolStripMenuItem.Enabled = true;

                if (!useDefaultToolStripMenuItem.Checked)
                {
                    closeButtonToolStripMenuItem.Enabled = true;
                    tabPositionToolStripMenuItem.Enabled = true;
                    tabOrientationToolStripMenuItem.Enabled = true;
                }
                else
                {
                    closeButtonToolStripMenuItem.Enabled = false;
                    tabPositionToolStripMenuItem.Enabled = false;
                    tabOrientationToolStripMenuItem.Enabled = false;
                }

                ConfigUtil.UpdateParameter("LastUserFolder", Path.GetDirectoryName(fileName));
                FileListManager.SetNewRecentSession(form, fileName);

                //verticalSplitContainer.Panel1.Padding = new Padding(0);
                toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("Saved", className), sessionToolStripButton.Text);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
                return false;
            }

            return true;
        }

        internal static DialogResult CheckSessionOnClosing(Form1 form, bool cancel)
        {
            if (!IsASessionOpened(form))
            {
                return DialogResult.OK;
            }

            if (IsOpenedSessionModified(form))
            {
                //If automatic savings is enable it proceed
                if (ConfigUtil.GetBoolParameter("AutomaticSessionSave"))
                {
                    bool saved = SaveSession(form, false);
                    return saved ? DialogResult.OK : DialogResult.Cancel;
                }

                switch (ShowQuestion(form, cancel))
                {
                    case DialogResult.Yes:
                        bool saved = SaveSession(form, false);
                        return saved ? DialogResult.OK : DialogResult.Cancel;
                    case DialogResult.No:
                        return DialogResult.OK;
                    case DialogResult.Cancel:
                        return DialogResult.Cancel;
                }
            }
            else
            {
                bool saved = SaveSession(form, false);
                return saved ? DialogResult.OK : DialogResult.Cancel;
            }

            return DialogResult.OK;
        }

        internal static void RenameSession(Form1 form, String newName)
        {
            ToolStripButton sessionToolStripButton = form.sessionToolStripButton;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;

            try
            {
                if (!newName.EndsWith(".dps"))
                {
                    newName += ".dps";
                }
                String actualName = sessionImageToolStripButton.DropDownItems[0].Text;
                newName = Path.Combine(Path.GetDirectoryName(actualName), newName);

                //Rename session name
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(actualName);
                XmlNodeList nodeSession = xmldoc.GetElementsByTagName("session");

                if (nodeSession.Count != 1)
                {
                    throw new SessionException(String.Format(LanguageUtil.GetCurrentLanguageString("MoreSession", className), Path.GetFileNameWithoutExtension(actualName)));
                }

                XmlNode nodeFile = nodeSession[0];
                nodeFile.Attributes["name"].Value = Path.GetFileNameWithoutExtension(newName);
                xmldoc.Save(actualName);

                //Rename file name
                File.Move(actualName, newName);

                //Rename form
                sessionToolStripButton.Text = Path.GetFileNameWithoutExtension(newName);
                sessionImageToolStripButton.DropDownItems[0].Text = newName;

                toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("Renamed", className), sessionToolStripButton.Text);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
        }

        internal static void ListSessionFiles(Form1 form)
        {
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;

            String filesList = String.Empty;
            for (int i = startPositionToReadSessionFiles; i < sessionImageToolStripButton.DropDownItems.Count; i++)
            {
                filesList += sessionImageToolStripButton.DropDownItems[i].Text + Environment.NewLine;
            }

            WindowManager.ShowContent(form, filesList);
        }
        
        internal static void UseDefaultAspectChanged(Form1 form)
        {
            ToolStripMenuItem useDefaultToolStripMenuItem = form.useDefaultToolStripMenuItem;
            ToolStripMenuItem closeButtonToolStripMenuItem = form.closeButtonToolStripMenuItem;
            ToolStripMenuItem tabPositionToolStripMenuItem = form.tabPositionToolStripMenuItem;
            ToolStripMenuItem tabOrientationToolStripMenuItem = form.tabOrientationToolStripMenuItem;

            if (useDefaultToolStripMenuItem.Checked)
            {
                closeButtonToolStripMenuItem.Enabled = false;
                tabPositionToolStripMenuItem.Enabled = false;
                tabOrientationToolStripMenuItem.Enabled = false;

                OptionManager.CheckTabCloseButton(form, ConfigUtil.GetIntParameter("TabCloseButtonMode"));
                OptionManager.CheckTabPosition(form, ConfigUtil.GetIntParameter("TabPosition"));
                OptionManager.CheckTabOrientation(form, ConfigUtil.GetIntParameter("TabOrientation"));
            }
            else
            {
                closeButtonToolStripMenuItem.Enabled = true;
                tabPositionToolStripMenuItem.Enabled = true;
                tabOrientationToolStripMenuItem.Enabled = true;

                OptionManager.CheckTabCloseButton(form, GetDropDownIndexChecked(closeButtonToolStripMenuItem));
                OptionManager.CheckTabPosition(form, GetDropDownIndexChecked(tabPositionToolStripMenuItem));
                OptionManager.CheckTabOrientation(form, GetDropDownIndexChecked(tabOrientationToolStripMenuItem));
            }
        }

        internal static void OnlyOneDropDownItemCheckedOnce(Form1 form, ToolStripDropDownItem toolStripDropDownItem, ToolStripMenuItem toolStripMenuItem)
        {
            ToolStripMenuItem closeButtonToolStripMenuItem = form.closeButtonToolStripMenuItem;
            ToolStripMenuItem tabPositionToolStripMenuItem = form.tabPositionToolStripMenuItem;
            ToolStripMenuItem tabOrientationToolStripMenuItem = form.tabOrientationToolStripMenuItem;
            
            for (int i = 0; i < toolStripDropDownItem.DropDownItems.Count; i++)
            {
                ToolStripMenuItem child = (ToolStripMenuItem)toolStripDropDownItem.DropDownItems[i];
                if (child != toolStripMenuItem)
                {
                    child.Checked = false;
                    continue;
                }

                child.Checked = true;
                    
                if (toolStripDropDownItem == closeButtonToolStripMenuItem)
                {
                    OptionManager.CheckTabCloseButton(form, i);
                }
                else if (toolStripDropDownItem == tabPositionToolStripMenuItem)
                {
                    OptionManager.CheckTabPosition(form, i);
                }
                else if (toolStripDropDownItem == tabOrientationToolStripMenuItem)
                {
                    OptionManager.CheckTabOrientation(form, i);
                }
            }
        }

        #endregion Internal Methods

        #region Check Methods

        internal static bool IsASessionOpened(Form1 form)
        {
            //ToolStrip sessionToolStrip = form.sessionToolStrip;
            ToolStripMenuItem closeToolStripMenuItem3 = form.closeToolStripMenuItem3;

            return closeToolStripMenuItem3.Enabled;
        }

        private static bool IsOpenedSessionModified(Form1 form)
        {
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;
            XtraTabControl pagesTabControl = form.pagesTabControl;

            //First control: session files are opened?
            for (int i = startPositionToReadSessionFiles; i < sessionImageToolStripButton.DropDownItems.Count; i++)
            {
                XtraTabPage tabPage;
                if (FileUtil.IsFileAlreadyOpen(form, sessionImageToolStripButton.DropDownItems[i].Text, out tabPage))
                {
                    continue;
                }

                return true;
            }

            //Second control: opened files are saved into session?
            for (int i = 0; i < pagesTabControl.TabPages.Count; i++)
            {
                if (String.IsNullOrEmpty(ProgramUtil.GetPageTextBox(pagesTabControl.TabPages[i]).Text) || IsFileAlreadyInSession(form, ProgramUtil.GetFilenameTabPage(pagesTabControl.TabPages[i])))
                {
                    continue;
                }

                return true;
            }

            return false;
        }

        internal static void FileRenamed(Form1 form, String oldName, String newName)
        {
            if (!IsASessionOpened(form))
            {
                return;
            }
            
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;

            foreach (ToolStripItem item in sessionImageToolStripButton.DropDownItems)
            {
                if (item.Text != oldName)
                {
                    continue;
                }

                item.Text = newName;
                break;
            }

            //sessionImageToolStripButton.DropDownItems[sessionImageToolStripButton.DropDownItems.IndexOfKey(oldName)].Text = newName;
        }

        #endregion Check Methods

        #region Import-Export Methods

        internal static void ExportSessionAsZip(Form1 form)
        {
            SaveFileDialog saveFileDialog = form.saveFileDialog;
            CustomXtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;
            ToolStripButton sessionToolStripButton = form.sessionToolStripButton;
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;

            if (IsOpenedSessionModified(form))
            {
                if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("SaveSessionForExport", className)) != DialogResult.Yes)
                {
                    return;
                }

                if (!SaveSession(form, false))
                {
                    return;
                }
            }

            if (!SessionContainsOnlySubFiles(form))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("NoExport", className));
                return;
            }

            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;
            toolStripProgressBar.PerformStep();

            //Save file dialog
            saveFileDialog.InitialDirectory = FileUtil.GetInitialFolder(form);
            saveFileDialog.Filter = LanguageUtil.GetCurrentLanguageString("ExportFileDialog", className);
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = sessionToolStripButton + ".zip";

            try
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    toolStripProgressBar.Visible = false;
                    return;
                }

                toolStripProgressBar.PerformStep();
                String fileName = saveFileDialog.FileName;
                if (!fileName.EndsWith(".zip"))
                {
                    fileName += ".zip";
                }

                toolStripProgressBar.PerformStep();
                ZipManager.WriteZipFile(fileName, pagesTabControl.TabPages, new FileInfo(sessionImageToolStripButton.DropDownItems[0].Text).DirectoryName, new List<String> { sessionImageToolStripButton.DropDownItems[0].Text });

                toolStripProgressBar.PerformStep();
                toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("ExportSaved", className), fileName);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
            finally
            {
                toolStripProgressBar.Visible = false;
            }
        }

        internal static void ImportSessionFromZip(Form1 form)
        {
            OpenFileDialog openFileDialog = form.openFileDialog;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;

            openFileDialog.InitialDirectory = ConstantUtil.ApplicationExecutionPath();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = String.Format("{0} (*.zip)|*.zip", LanguageUtil.GetCurrentLanguageString("ExportSessionDescription", className)); //DtPad session archive (*.zip)|*.zip
            openFileDialog.FileName = "*.zip";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            String dpsFileName = String.Empty;
            ZipFile toImportFile = null;

            try
            {
                toImportFile = new ZipFile(openFileDialog.FileName);

                foreach (ZipEntry zipEntry in toImportFile)
                {
                    if (!zipEntry.Name.EndsWith(".dps"))
                    {
                        continue;
                    }

                    dpsFileName = zipEntry.Name;
                    break;
                }

                if (String.IsNullOrEmpty(dpsFileName))
                {
                    WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ArchiveNotExport", className));
                    return;
                }
            }
            finally
            {
                if (toImportFile != null)
                {
                    toImportFile.Close();
                }
            }

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
                                                          {
                                                              Description = LanguageUtil.GetCurrentLanguageString("folderBrowserDialogDescription", className),
                                                              RootFolder = Environment.SpecialFolder.MyDocuments,
                                                              SelectedPath = FileUtil.GetInitialFolder(form)
                                                          };

            if (folderBrowserDialog.ShowDialog(form) != DialogResult.OK)
            {
                return;
            }

            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;

            FastZipEvents events = new FastZipEvents { ProcessFile = ProcessFileMethod };
            FastZip importFile = new FastZip(events);

            toolStripProgressBar.PerformStep();

            importFile.ExtractZip(openFileDialog.FileName, folderBrowserDialog.SelectedPath, FastZip.Overwrite.Prompt, OverwritePrompt, String.Empty, String.Empty, true);
            yesAllImportSession = false;

            if (stopImportSession)
            {
                toolStripProgressBar.PerformStep();
                toolStripProgressBar.PerformStep();

                toolStripProgressBar.Visible = false;
                return;
            }

            toolStripProgressBar.PerformStep();

            String importStatus = String.Format(LanguageUtil.GetCurrentLanguageString("ImportStatusLabel", className), openFileDialog.FileName);

            toolStripProgressBar.PerformStep();
            toolStripProgressBar.PerformStep();

            toolStripStatusLabel.Text = importStatus;
            WindowManager.ShowInfoBox(form, importStatus + "!");

            toolStripProgressBar.Visible = false;

            OpenSession(form, Path.Combine(folderBrowserDialog.SelectedPath, dpsFileName));
        }

        private static bool OverwritePrompt(String fileName)
        {
            if (yesAllImportSession)
            {
                stopImportSession = false;
                return true;
            }

            switch (WindowManager.ShowQuestionCancelYesAllBox(null, String.Format(LanguageUtil.GetCurrentLanguageString("ImportOverwrite", className), fileName)))
            {
                case DialogResult.Cancel:
                    stopImportSession = true;
                    return true;
                case DialogResult.Yes:
                    stopImportSession = false;
                    return true;
                case DialogResult.Retry:
                    stopImportSession = false;
                    yesAllImportSession = true;
                    return true;
                case DialogResult.No:
                    stopImportSession = false;
                    return false;
                
                default:
                    stopImportSession = true;
                    return true;
            }
        }

        private static void ProcessFileMethod(object sender, ScanEventArgs args)
        {
            if (stopImportSession)
            {
                args.ContinueRunning = false;
            }
        }

        #endregion Import-Export Methods

        #region Private Methods

        private static String ReadSessionXML(Form1 form, String fileName, out bool loadTotallyFailed)
        {
            CustomXtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;
            ToolStripMenuItem useDefaultToolStripMenuItem = form.useDefaultToolStripMenuItem;
            ToolStripMenuItem closeButtonToolStripMenuItem = form.closeButtonToolStripMenuItem;
            ToolStripMenuItem tabPositionToolStripMenuItem = form.tabPositionToolStripMenuItem;
            ToolStripMenuItem tabOrientationToolStripMenuItem = form.tabOrientationToolStripMenuItem;

            loadTotallyFailed = false;
            int selectedTab = 0;
            int existingTabs = 0;

            if (pagesTabControl.TabPages.Count > 1 || !String.IsNullOrEmpty(ProgramUtil.GetPageTextBox(pagesTabControl.TabPages[0]).Text) || !String.IsNullOrEmpty(ProgramUtil.GetFilenameTabPage(pagesTabControl.TabPages[0])))
            {
                existingTabs = pagesTabControl.TabPages.Count;
            }

            sessionImageToolStripButton.DropDownItems.Clear();
            sessionImageToolStripButton.DropDownItems.Add(fileName);
            sessionImageToolStripButton.DropDownItems[0].Image = ToolbarResource.diagram;
            sessionImageToolStripButton.DropDownItems[0].Click += form.sessionPropertiesToolStripMenuItem_Click;
            sessionImageToolStripButton.DropDownItems.Add(new ToolStripSeparator());
            
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(fileName);

            XmlNodeList nodeFileList = xmldoc.GetElementsByTagName("file");

            if (nodeFileList.Count == 0)
            {
                throw new SessionException(LanguageUtil.GetCurrentLanguageString("Empty", className));
            }

            String[] fileNames = new String[nodeFileList.Count];
            KnownColor[] tabColors = new KnownColor[nodeFileList.Count];
            for (int i = 0; i < nodeFileList.Count; i++)
            {
                XmlNode nodeFile = nodeFileList[i];

                String path = nodeFile.Attributes["path"].Value;
                path = FileUtil.EvaluateAbsolutePath(Path.GetDirectoryName(fileName), path);

                fileNames[i] = Path.Combine(path, nodeFile.Attributes["name"].Value);
                sessionImageToolStripButton.DropDownItems.Add(fileNames[i]);
                sessionImageToolStripButton.DropDownItems[sessionImageToolStripButton.DropDownItems.Count - 1].Click += form.sessionImageToolStripButton_Click;

                if (!File.Exists(fileNames[i]))
                {
                    sessionImageToolStripButton.DropDownItems[sessionImageToolStripButton.DropDownItems.Count - 1].Enabled = false;
                }

                try
                {
                    if (Convert.ToBoolean(nodeFile.Attributes["open"].Value))
                    {
                        selectedTab = i;
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    tabColors[i] = (KnownColor)Enum.Parse(typeof(KnownColor), nodeFile.Attributes["tabcolor"].Value, true);
                }
                catch (Exception)
                {
                    tabColors[i] = KnownColor.Black;
                }
            }

            List<String> errors;
            form.TabIdentity = FileManager.OpenFile(form, form.TabIdentity, fileNames, false, false, out errors);
            
            if (errors.Count == 0)
            {
                pagesTabControl.SelectedTabPageIndex = selectedTab;

                for (int j = 0; j < pagesTabControl.TabPages.Count - existingTabs; j++)
                {
                    TabManager.SetTabColor(pagesTabControl.TabPages[j + existingTabs], Color.FromKnownColor(tabColors[j])); //pagesTabControl.TabPages[j].Appearance.Header.ForeColor = Color.FromKnownColor(tabColors[j]);
                }
            }
            else
            {
                String errorMessage = LanguageUtil.GetCurrentLanguageString("openingErrors", className) + Environment.NewLine;
                for (int i = 0; i < errors.Count; i++)
                {
                    if (i == errors.Count - 1)
                    {
                        errorMessage += errors[i];
                        continue;
                    }

                    errorMessage += errors[i] + Environment.NewLine;
                }

                WindowManager.ShowContent(form, errorMessage);

                if (errors.Count == fileNames.Length)
                {
                    loadTotallyFailed = true;
                }
            }

            if (xmldoc.GetElementsByTagName("session")[0].Attributes["aspect"].Value == "default")
            {
                useDefaultToolStripMenuItem.Checked = true;
            }
            else
            {
                useDefaultToolStripMenuItem.Checked = false;

                CheckDropDownIndex(closeButtonToolStripMenuItem, Convert.ToInt32(xmldoc.GetElementsByTagName("session")[0].Attributes["button"].Value));
                CheckDropDownIndex(tabPositionToolStripMenuItem, Convert.ToInt32(xmldoc.GetElementsByTagName("session")[0].Attributes["position"].Value));
                CheckDropDownIndex(tabOrientationToolStripMenuItem, Convert.ToInt32(xmldoc.GetElementsByTagName("session")[0].Attributes["orientation"].Value));
            }

            return xmldoc.GetElementsByTagName("session")[0].Attributes["name"].Value;
        }

        private static String WriteSessionXML(Form1 form, String fileName)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;
            ToolStripMenuItem useDefaultToolStripMenuItem = form.useDefaultToolStripMenuItem;
            ToolStripMenuItem closeButtonToolStripMenuItem = form.closeButtonToolStripMenuItem;
            ToolStripMenuItem tabPositionToolStripMenuItem = form.tabPositionToolStripMenuItem;
            ToolStripMenuItem tabOrientationToolStripMenuItem = form.tabOrientationToolStripMenuItem;

            sessionImageToolStripButton.DropDownItems.Clear();
            String newSessionName = Path.GetFileNameWithoutExtension(fileName);

            FileListManager.SaveFileList(fileName, ConstantUtil.defaultSessionFileContent);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(fileName);

            if (xmldoc.DocumentElement == null)
            {
                throw new XmlException(String.Format(LanguageUtil.GetCurrentLanguageString("XmlDocError", className), Path.GetFileName(fileName)));
            }

            xmldoc.DocumentElement.SetAttribute("name", newSessionName);
            xmldoc.DocumentElement.SetAttribute("aspect", useDefaultToolStripMenuItem.Checked ? "default" : "custom");
            xmldoc.DocumentElement.SetAttribute("button", GetDropDownIndexChecked(closeButtonToolStripMenuItem).ToString());
            xmldoc.DocumentElement.SetAttribute("position", GetDropDownIndexChecked(tabPositionToolStripMenuItem).ToString());
            xmldoc.DocumentElement.SetAttribute("orientation", GetDropDownIndexChecked(tabOrientationToolStripMenuItem).ToString());

            sessionImageToolStripButton.DropDownItems.Add(fileName);
            sessionImageToolStripButton.DropDownItems[0].Image = ToolbarResource.diagram;
            sessionImageToolStripButton.DropDownItems[0].Click += form.sessionPropertiesToolStripMenuItem_Click;
            sessionImageToolStripButton.DropDownItems.Add(new ToolStripSeparator());
            
            foreach (XtraTabPage tabControl in pagesTabControl.TabPages)
            {
                String fileNameTab = ProgramUtil.GetFilenameTabPage(tabControl);

                if (String.IsNullOrEmpty(ProgramUtil.GetPageTextBox(tabControl).Text) && String.IsNullOrEmpty(fileNameTab))
                {
                    continue;
                }

                XmlElement newFile = xmldoc.CreateElement("file");

                String relativePath = FileUtil.EvaluateRelativePath(Path.GetDirectoryName(fileName), Path.GetDirectoryName(fileNameTab));
                newFile.SetAttribute("path", relativePath);
                newFile.SetAttribute("name", Path.GetFileName(fileNameTab));
                newFile.SetAttribute("tabcolor", TabManager.GetTabColor(tabControl).ToKnownColor().ToString()); //newFile.SetAttribute("tabcolor", tabControl.Appearance.Header.ForeColor.ToKnownColor().ToString());
                if (pagesTabControl.SelectedTabPage == tabControl)
                {
                    newFile.SetAttribute("open", true.ToString());
                }

                if (xmldoc.DocumentElement == null)
                {
                    throw new XmlException(String.Format(LanguageUtil.GetCurrentLanguageString("XmlDocError", className), Path.GetFileName(fileName)));
                }
                
                xmldoc.DocumentElement.AppendChild(newFile);
                sessionImageToolStripButton.DropDownItems.Add(fileNameTab);
                sessionImageToolStripButton.DropDownItems[sessionImageToolStripButton.DropDownItems.Count - 1].Click += form.sessionImageToolStripButton_Click;
            }

            xmldoc.Save(fileName);
            //WindowManager.ShowInfoBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("SaveSuccesfull", className), newSessionName));

            return newSessionName;
        }

        private static DialogResult ShowQuestion(Form form, bool cancel)
        {
            if (cancel)
            {
                return WindowManager.ShowQuestionCancelBox(form, LanguageUtil.GetCurrentLanguageString("ClosingWindow", className));
            }
            return WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("ClosingWindow", className));
        }

        private static bool IsFileAlreadyInSession(Form1 form, String fileName)
        {
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;

            for (int i = startPositionToReadSessionFiles; i < sessionImageToolStripButton.DropDownItems.Count; i++)
            {
                if (sessionImageToolStripButton.DropDownItems[i].Text.Equals(fileName))
                {
                    return true;
                }
            }

            return false;
        }

        private static int GetDropDownIndexChecked(ToolStripDropDownItem toolStripMenuItem)
        {
            for (int i = 0; i < toolStripMenuItem.DropDownItems.Count; i++)
            {
                ToolStripMenuItem child = (ToolStripMenuItem)toolStripMenuItem.DropDownItems[i];
                if (child.Checked)
                {
                    return i;
                }
            }

            return 0;
        }

        private static void CheckDropDownIndex(ToolStripDropDownItem toolStripMenuItem, int index)
        {
            for (int i = 0; i < toolStripMenuItem.DropDownItems.Count; i++)
            {
                ToolStripMenuItem child = (ToolStripMenuItem)toolStripMenuItem.DropDownItems[i];
                child.Checked = i == index;
            }
        }

        private static bool SessionContainsOnlySubFiles(Form1 form)
        {
            ToolStripDropDownButton sessionImageToolStripButton = form.sessionImageToolStripButton;

            for (int i = startPositionToReadSessionFiles; i < sessionImageToolStripButton.DropDownItems.Count; i++)
            {
                String filePath = new FileInfo(sessionImageToolStripButton.DropDownItems[i].Text).DirectoryName;
                String sessionPath = new FileInfo(sessionImageToolStripButton.DropDownItems[0].Text).DirectoryName;

                if (!filePath.StartsWith(sessionPath))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion Private Methods
    }
}
