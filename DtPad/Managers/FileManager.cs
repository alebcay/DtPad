using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AppLimit.CloudComputing.SharpBox;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Exceptions;
using DtPad.Utils;
using DtPad.Validators;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.VisualBasic.FileIO;

namespace DtPad.Managers
{
    /// <summary>
    /// File open and save manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class FileManager
    {
        private const String className = "FileManager";

        private enum UpdatePhase
        {
            Begin = 0,
            End = 1
        }

        #region Internal Methods

        internal static int OpenFile(Form1 form, int tabIdentity)
        {
            List<String> errors;
            return OpenFile(form, tabIdentity, null, true, out errors);
        }
        internal static int OpenFile(Form1 form, int tabIdentity, String[] specificFileNames)
        {
            List<String> errors;
            return OpenFile(form, tabIdentity, specificFileNames, true, out errors);
        }
        internal static int OpenFile(Form1 form, int tabIdentity, String[] specificFileNames, bool saveNewRecentFile)
        {
            List<String> errors;
            return OpenFile(form, tabIdentity, specificFileNames, true, saveNewRecentFile, out errors);
        }
        internal static int OpenFile(Form1 form, int tabIdentity, String[] specificFileNames, bool showMessages, bool saveNewRecentFile, out List<String> errors)
        {
            CustomXtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;
            OpenFileDialog openFileDialog = form.openFileDialog;

            bool isWindowsHostsFile = false;
            int localTabIdentity = tabIdentity;
            errors = new List<String>();

            openFileDialog.InitialDirectory = FileUtil.GetInitialFolder(form);
            openFileDialog.Multiselect = true;
            SetFileDialogFilter(openFileDialog);

            TrayManager.RestoreFormIfIsInTray(form);
            //form.BringToFront();
            //Application.DoEvents();
            
            try
            {
                String[] fileNames;
                
                if (specificFileNames == null || specificFileNames.Length <= 0)
                {
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return tabIdentity;
                    }

                    fileNames = openFileDialog.FileNames;
                }
                else
                {
                    fileNames = specificFileNames;
                }

                //Verify if file is a DtPad session
                if (fileNames.Length == 1 && fileNames[0].EndsWith(".dps"))
                {
                    SessionManager.OpenSession(form, fileNames[0]);
                    return form.TabIdentity;
                }

                Application.DoEvents();
                toolStripProgressBar.Value = 0;

                foreach (String fileName in fileNames)
                {
                    //Verify if file is Windows hosts file
                    if (fileName.Contains(@"drivers\etc\hosts"))
                    {
                        if (!SystemUtil.IsUserAdministrator())
                        {
                            WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("UserNotAdmin", className));
                        }

                        isWindowsHostsFile = true;
                    }

                    if (!showMessages)
                    {
                        if (!File.Exists(fileName))
                        {
                            errors.Add(String.Format(LanguageUtil.GetCurrentLanguageString("NoMessageFileNotExists", className), fileName));
                            continue;
                        }
                        if (FileUtil.IsFileInUse(fileName))
                        {
                            errors.Add(String.Format(LanguageUtil.GetCurrentLanguageString("NoMessageFileInUse", className), fileName));
                            continue;
                        }
                        if (FileUtil.IsFileTooLargeForDtPad(fileName))
                        {
                            errors.Add(String.Format(LanguageUtil.GetCurrentLanguageString("NoMessageFileTooHeavy", className), fileName));
                            continue;
                        }
                    }
                    else if (!File.Exists(fileName))
                    {
                        WindowManager.ShowAlertBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("FileNotExisting", className), fileName));
                        continue;
                    }
                    else if (FileUtil.IsFileInUse(fileName))
                    {
                        WindowManager.ShowAlertBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("FileInUse", className), fileName));
                        continue;
                    }
                    if (FileUtil.IsFileTooLargeForDtPad(fileName))
                    {
                        WindowManager.ShowAlertBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("FileTooHeavy", className), fileName));
                        continue;
                    }

                    //Cycle and check if the file is already open, in which case I select its tab and continue with the next one
                    XtraTabPage tabPage;
                    if (FileUtil.IsFileAlreadyOpen(form, fileName, out tabPage))
                    {
                        pagesTabControl.SelectedTabPage = tabPage;
                        toolStripProgressBar.PerformStep();
                        toolStripProgressBar.PerformStep();
                        toolStripProgressBar.PerformStep();
                        toolStripProgressBar.PerformStep();
                        toolStripProgressBar.Visible = false;
                        continue;
                    }

                    //Verify if file is an archive
                    try
                    {
                        ZipFile file = null;
                        bool isZipFile;

                        try
                        {
                            file = new ZipFile(fileName);
                            isZipFile = file.TestArchive(false, TestStrategy.FindFirstError, form.Zip_Errors);
                        }
                        finally
                        {
                            if (file != null)
                            {
                                file.Close();
                            }
                        }

                        if (isZipFile)
                        {
                            WindowManager.ShowZipExtract(form, fileName);
                            continue;
                        }
                    }
                    catch (ZipException)
                    {
                    }

                    toolStripProgressBar.Visible = true;
                    toolStripProgressBar.PerformStep();

                    String fileContents;
                    Encoding fileEncoding;
                    bool anonymousFile = false;

                    //Verify if file is a PDF
                    if (fileName.EndsWith(".pdf"))
                    {
                        bool success;
                        fileContents = PdfUtil.ExtractText(fileName, out success);

                        if (!success)
                        {
                            WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("InvalidPdf", className));
                            return tabIdentity;
                        }

                        fileEncoding = EncodingUtil.GetDefaultEncoding();
                        anonymousFile = true;
                    }
                    else
                    {
                        fileContents = FileUtil.ReadToEndWithEncoding(fileName, out fileEncoding);
                    }

                    bool favouriteFile = FavouriteManager.IsFileFavourite(fileName);
                    if (!favouriteFile && saveNewRecentFile)
                    {
                        ConfigUtil.UpdateParameter("LastUserFolder", Path.GetDirectoryName(fileName));
                        FileListManager.SetNewRecentFile(form, fileName);
                    }
                    toolStripProgressBar.PerformStep();

                    CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                    if (!String.IsNullOrEmpty(pageTextBox.Text) || !String.IsNullOrEmpty(ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage)))
                    {
                        localTabIdentity = TabManager.AddNewPage(form, localTabIdentity);
                    }
                    toolStripProgressBar.PerformStep();

                    //Row number check
                    WindowManager.CheckLineNumbersForTextLenght(form, fileContents);
                    
                    FileInfo fileInfo = new FileInfo(fileName);

                    pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

                    //Verify if file is a tweet file
                    if (fileName.EndsWith(".tweet") && !ColumnRulerManager.IsPanelOpen(form))
                    {
                        ColumnRulerManager.TogglePanel(form);
                    }

                    pageTextBox.Text = fileContents.Replace(Environment.NewLine, ConstantUtil.newLine);
                    pageTextBox.CustomOriginal = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Text.GetHashCode().ToString();
                    pageTextBox.CustomEncoding = fileEncoding.CodePage.ToString();

                    if (!anonymousFile)
                    {
                        String fileNameWithoutPath = Path.GetFileName(fileName);

                        pageTextBox.CustomModified = false;
                        ProgramUtil.SetFilenameTabPage(pagesTabControl.SelectedTabPage, fileName);
                        pagesTabControl.SelectedTabPage.ImageIndex = fileInfo.IsReadOnly ? 2 : 0;
                        pagesTabControl.SelectedTabPage.Text = fileNameWithoutPath;
                        pagesTabControl.SelectedTabPage.Tooltip = fileName;
                        pagesTabControl.SelectedTabPage.TooltipTitle = fileNameWithoutPath;
                        form.Text = String.Format("DtPad - {0}", fileNameWithoutPath);
                        TabManager.ToggleTabFileTools(form, true);
                    }
                    else
                    {
                        pageTextBox.CustomModified = true;
                    }

                    toolStripStatusLabel.Text = String.Format("{0} \"{1}\" {2}", LanguageUtil.GetCurrentLanguageString("File", className), Path.GetFileName(fileName), LanguageUtil.GetCurrentLanguageString("Opened", className));
                    toolStripProgressBar.PerformStep();

                    tabIdentity = localTabIdentity;

                    if (!String.IsNullOrEmpty(fileInfo.Extension) && ConfigUtil.GetStringParameter("AutoFormatFiles").Contains(fileInfo.Extension))
                    {
                        FormatManager.FormatXml(form);
                    }

                    if (ConfigUtil.GetBoolParameter("AutoOpenHostsConfigurator") && isWindowsHostsFile)
                    {
                        pagesTabControl.SelectedTabPage.Appearance.Header.ForeColor = ConfigUtil.GetColorParameter("ColorHostsConfigurator");
                        CustomFilesManager.OpenHostsSectionPanel(form);
                        isWindowsHostsFile = false;
                    }
                }
            }
            catch (Exception exception)
            {
                TabManager.ToggleTabFileTools(form, false);

                toolStripProgressBar.Visible = false;
                toolStripProgressBar.Value = 0;

                if (showMessages)
                {
                    WindowManager.ShowErrorBox(form, exception.Message, exception);
                }
            }
            finally
            {
                toolStripProgressBar.Visible = false;
                toolStripProgressBar.Value = 0;
            }

            return tabIdentity;
        }

        internal static bool OpenFileFromDropbox(Form1 form1, Form form, String fileName, String directoryName)
        {
            XtraTabControl pagesTabControl = form1.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form1.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form1.toolStripProgressBar;

            try
            {
                Application.DoEvents();
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Visible = true;
                toolStripProgressBar.PerformStep();

                bool fileExists;
                String content = DropboxManager.GetFileFromDropbox(DropboxManager.GetDirectory(form1, directoryName), fileName, out fileExists);
                toolStripProgressBar.PerformStep();

                if (!fileExists)
                {
                    WindowManager.ShowAlertBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("openingFileNotExists", className), fileName, directoryName));
                    return false;
                }
                if (String.IsNullOrEmpty(content))
                {
                    WindowManager.ShowInfoBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("openingFileEmpty", className), fileName));
                    return false;
                }
                toolStripProgressBar.PerformStep();

                form1.LastDropboxFolder = directoryName;
                if (!String.IsNullOrEmpty(ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Text))
                {
                    form1.TabIdentity = TabManager.AddNewPage(form1, form1.TabIdentity);
                }
                ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Text = content;
                toolStripStatusLabel.Text = String.Format("{0} \"{1}\" {2}", LanguageUtil.GetCurrentLanguageString("File", className), fileName, LanguageUtil.GetCurrentLanguageString("OpenedFromDropbox", className));
                toolStripProgressBar.PerformStep();
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
                return false;
            }
            finally
            {
                toolStripProgressBar.Visible = false;
            }

            return true;
        }

        internal static bool SaveFile(Form1 form, bool forceSaveAs, bool forceBackup = false)
        {
            return SaveFile(true, form, forceSaveAs, forceBackup);
        }
        private static bool SaveFile(bool saveNewRecentFile, Form1 form, bool forceSaveAs, bool forceBackup, bool savingAll = false)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;
            SaveFileDialog saveFileDialog = form.saveFileDialog;
            
            try
            {
                String fileName;

                if (String.IsNullOrEmpty(ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage)) || forceSaveAs)
                {
                    saveFileDialog.InitialDirectory = FileUtil.GetInitialFolder(form);
                    SetFileDialogFilter(saveFileDialog);

                    TabsUpdate(pagesTabControl, savingAll, UpdatePhase.End); //Useful to save all execution
                    DialogResult saveNewResult = saveFileDialog.ShowDialog();
                    TabsUpdate(pagesTabControl, savingAll, UpdatePhase.Begin); //Useful to save all execution

                    if (saveNewResult != DialogResult.OK) 
                    {
                        toolStripProgressBar.Visible = false;
                        return false;
                    }

                    fileName = saveFileDialog.FileName;
                }
                else
                {
                    fileName = ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage);
                }

                //Check that fileName is not already opened into another tab
                foreach(XtraTabPage tabPage in pagesTabControl.TabPages)
                {
                    if (tabPage == pagesTabControl.SelectedTabPage || ProgramUtil.GetFilenameTabPage(tabPage) != fileName)
                    {
                        continue;
                    }

                    pagesTabControl.SelectedTabPage = tabPage;

                    TabsUpdate(pagesTabControl, savingAll, UpdatePhase.End); //Useful to save all execution
                    WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("FileAlreadyOpen", className));
                    TabsUpdate(pagesTabControl, savingAll, UpdatePhase.Begin); //Useful to save all execution

                    return false;
                }

                bool favouriteFile = FavouriteManager.IsFileFavourite(fileName);

                Application.DoEvents();
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Visible = true;

                toolStripProgressBar.PerformStep();

                if (!favouriteFile)
                {
                    ConfigUtil.UpdateParameter("LastUserFolder", Path.GetDirectoryName(fileName));
                }

                FileInfo fileInfo = new FileInfo(fileName);
                if (fileInfo.IsReadOnly && fileInfo.Exists)
                {
                    toolStripProgressBar.Visible = false;

                    TabsUpdate(pagesTabControl, savingAll, UpdatePhase.End); //Useful to save all execution
                    WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("SavingReadonly", className));
                    TabsUpdate(pagesTabControl, savingAll, UpdatePhase.Begin); //Useful to save all execution

                    return SaveFile(form, true);
                }

                bool backupConfigActive = ConfigUtil.GetBoolParameter("BackupEnabled");
                if ((!String.IsNullOrEmpty(ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage)) && !forceSaveAs) && (forceBackup || backupConfigActive))
                {
                    TabsUpdate(pagesTabControl, savingAll, UpdatePhase.End); //Useful to save all execution
                    bool saved = BackupFileOnSaving(form, fileName);
                    TabsUpdate(pagesTabControl, savingAll, UpdatePhase.Begin); //Useful to save all execution

                    if (saved == false)  
                    {
                        toolStripProgressBar.Visible = false;
                        return false;
                    }
                }

                toolStripProgressBar.PerformStep();
                if (SaveFileCoreWithEncoding(form, fileName, savingAll) == false)
                {
                    toolStripProgressBar.Visible = false;
                    return false;
                }

                if (!favouriteFile && saveNewRecentFile)
                {
                    FileListManager.SetNewRecentFile(form, fileName);
                }

                if (CustomFilesManager.IsHostsSectionPanelOpen(form))
                {
                    CustomFilesManager.GetSections(form, false);
                }
                toolStripProgressBar.PerformStep();

                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

                ProgramUtil.SetFilenameTabPage(pagesTabControl.SelectedTabPage, fileName);
                pagesTabControl.SelectedTabPage.ImageIndex = 0;
                pagesTabControl.SelectedTabPage.Text = Path.GetFileName(fileName);
                pageTextBox.CustomModified = false;
                pageTextBox.CustomOriginal = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Text.GetHashCode().ToString();
                form.Text = String.Format("DtPad - {0}", Path.GetFileName(fileName));
                toolStripStatusLabel.Text = String.Format("{0} \"{1}\" {2}", LanguageUtil.GetCurrentLanguageString("File", className), Path.GetFileName(fileName), LanguageUtil.GetCurrentLanguageString("Saved", className));
                TabManager.ToggleTabFileTools(form, true);

                toolStripProgressBar.PerformStep();
                toolStripProgressBar.Visible = false;
            }
            catch (Exception exception)
            {
                TabManager.ToggleTabFileTools(form, false);
                toolStripProgressBar.Visible = false;

                TabsUpdate(pagesTabControl, savingAll, UpdatePhase.End); //Useful to save all execution
                WindowManager.ShowErrorBox(form, exception.Message, exception);
                TabsUpdate(pagesTabControl, savingAll, UpdatePhase.Begin); //Useful to save all execution

                return false;
            }

            return true;
        }

        internal static bool SaveFileOnDropbox(Form1 form1, Form form, String fileName, String directoryName)
        {
            XtraTabControl pagesTabControl = form1.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form1.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form1.toolStripProgressBar;

            ICloudDirectoryEntry directory = DropboxManager.GetDirectory(form1, directoryName);

            try
            {
                Application.DoEvents();
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Visible = true;
                toolStripProgressBar.PerformStep();

                if (DropboxManager.ExistsChildOnDropbox(directory, fileName))
                {
                    if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("OverwriteFileOnDropbox", className)) != DialogResult.Yes)
                    {
                        return false;
                    }
                }

                //Encoding fileEncoding = TabUtil.GetTabTextEncoding(pagesTabControl.SelectedTabPage);
                toolStripProgressBar.PerformStep();

                DropboxManager.SaveFileOnDropbox(form1, directory, fileName, ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Text); //, fileEncoding);
                toolStripProgressBar.PerformStep();

                form1.LastDropboxFolder = directoryName;
                toolStripStatusLabel.Text = String.Format("{0} \"{1}\" {2}", LanguageUtil.GetCurrentLanguageString("File", className), Path.GetFileName(fileName), LanguageUtil.GetCurrentLanguageString("SavedOnDropbox", className));
                toolStripProgressBar.PerformStep();

                toolStripProgressBar.Visible = false;
            }
            catch (Exception exception)
            {
                toolStripProgressBar.Visible = false;
                WindowManager.ShowErrorBox(form, exception.Message, exception);
                return false;
            }

            return true;
        }

        internal static bool SaveAllFiles(Form1 form, bool saveNewRecentFile = true)
        {
            CustomXtraTabControl pagesTabControl = form.pagesTabControl;

            XtraTabPage startTabPage = pagesTabControl.SelectedTabPage;
            bool fullSuccess = true;

            try
            {
                pagesTabControl.BeginUpdate();
                foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
                {
                    if (!TabUtil.IsTabPageModified(tabPage))
                    {
                        continue;
                    }

                    pagesTabControl.SelectedTabPage = tabPage;

                    if (!SaveFile(saveNewRecentFile, form, false, false, true))
                    {
                        fullSuccess = false;
                    }
                }
            }
            finally
            {
                pagesTabControl.SelectedTabPage = startTabPage;
                pagesTabControl.EndUpdate();
            }

            return fullSuccess;
        }

        internal static bool SaveCloseAllFiles(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            bool result = true;
            int counter = 0;
            XtraTabPage[] tabPages = new XtraTabPage[pagesTabControl.TabPages.Count];

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                pagesTabControl.SelectedTabPage = tabPage;
                if (String.IsNullOrEmpty(ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Text))
                {
                    tabPages[counter] = tabPage;
                    counter++;
                    continue;
                }

                if (SaveFile(form, false))
                {
                    tabPages[counter] = tabPage;
                    counter++;
                }
                else
                {
                    result = false;
                }
            }

            for (int i = 0; i < counter; i++)
            {
                pagesTabControl.TabPages.Remove(tabPages[i]);
            }

            return result;
        }

        internal static bool SaveAsPdf(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            SaveFileDialog saveFileDialog = form.saveFileDialog;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;

            if (String.IsNullOrEmpty(pageTextBox.Text))
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoTextForPDF", className));
                return false;
            }

            try
            {
                saveFileDialog.InitialDirectory = FileUtil.GetInitialFolder(form);
                saveFileDialog.Filter = LanguageUtil.GetCurrentLanguageString("PDFFile", className); //"PDF document (*.pdf)|*.pdf";
                saveFileDialog.FilterIndex = 0;

                String filenameTabPage = ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage);
                if (String.IsNullOrEmpty(filenameTabPage))
                {
                    saveFileDialog.FileName = "*.pdf";
                }
                else if (filenameTabPage.Contains("."))
                {
                    saveFileDialog.FileName = filenameTabPage.Substring(0, filenameTabPage.LastIndexOf('.')) + ".pdf";
                }
                else
                {
                    saveFileDialog.FileName = filenameTabPage + ".pdf";
                }

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    toolStripProgressBar.Visible = false;
                    return false;
                }

                Application.DoEvents();
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Visible = true;

                String fileName = saveFileDialog.FileName;
                toolStripProgressBar.PerformStep();

                ConfigUtil.UpdateParameter("LastUserFolder", Path.GetDirectoryName(fileName));
                FileInfo fileInfo = new FileInfo(fileName);
                if (fileInfo.IsReadOnly && fileInfo.Exists)
                {
                    toolStripProgressBar.Visible = false;
                    WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("SavingReadonly", className));
                    return SaveAsPdf(form);
                }

                toolStripProgressBar.PerformStep();
                String fileTitle = fileName.Substring(0, fileName.LastIndexOf(".pdf"));

                //Document document = new Document();
                //FileStream fileStream = File.Create(fileName);
                //PdfWriter.GetInstance(document, fileStream);

                //document.Open();
                //document.AddTitle(fileTitle);
                //document.AddCreationDate();
                //document.AddCreator("DtPad " + AssemblyUtil.AssemblyVersion);
                //document.Add(new Paragraph(pageTextBox.Text));
                
                //if (document.IsOpen())
                //{
                //    document.CloseDocument();
                //}
                //fileStream.Dispose();
                PdfUtil.SaveText(fileName, fileTitle, pageTextBox.Text);

                toolStripProgressBar.PerformStep();
                toolStripStatusLabel.Text = String.Format("{0} \"{1}\" {2}", LanguageUtil.GetCurrentLanguageString("File", className), Path.GetFileName(fileName), LanguageUtil.GetCurrentLanguageString("Saved", className));

                toolStripProgressBar.PerformStep();
                toolStripProgressBar.Visible = false;

                OtherManager.StartProcess(form, fileName);
                saveFileDialog.FileName = "*.txt";
                return true;
            }
            catch (Exception exception)
            {
                toolStripProgressBar.Visible = false;
                saveFileDialog.FileName = "*.txt";
                WindowManager.ShowErrorBox(form, exception.Message, exception);
                return false;
            }
        }

        internal static void AppendFileContent(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            OpenFileDialog openFileDialog = form.openFileDialog;
            
            try
            {
                openFileDialog.InitialDirectory = FileUtil.GetInitialFolder(form);
                SetFileDialogFilter(openFileDialog);
                
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    toolStripProgressBar.Visible = false;
                    return;
                }
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Visible = true;
                toolStripProgressBar.PerformStep();

                ConfigUtil.UpdateParameter("LastUserFolder", Path.GetDirectoryName(openFileDialog.FileName));
                toolStripProgressBar.PerformStep();

                String fileContents = FileUtil.ReadToEndWithEncoding(openFileDialog.FileName);
                toolStripProgressBar.PerformStep();

                pageTextBox.AppendText(fileContents);
                TextManager.RefreshUndoRedoExternal(form);

                toolStripStatusLabel.Text = String.Format("{0} \"{1}\" {2}", LanguageUtil.GetCurrentLanguageString("File", className), Path.GetFileName(openFileDialog.FileName), LanguageUtil.GetCurrentLanguageString("Appended", className));
                toolStripProgressBar.PerformStep();
                toolStripProgressBar.Visible = false;
            }
            catch (Exception exception)
            {
                toolStripProgressBar.Visible = false;
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
        }

        internal static void ReloadFile(Form1 form, int tabIdentity)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            if (pagesTabControl.SelectedTabPage.Text.StartsWith("*"))
            {
                if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("Reload", className)) != DialogResult.Yes)
                {
                    return;
                }
            }

            String[] filenames = new[] { ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage) };
            TabManager.ResetTab(form);
            OpenFile(form, tabIdentity, filenames);
        }

        internal static void ToggleReadonly(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            String fileName = ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage);
            FileInfo fileInfo = new FileInfo(fileName);

            if (fileInfo.IsReadOnly && fileInfo.Exists)
            {
                File.SetAttributes(fileName, FileAttributes.Normal);
                toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("ReadonlyNo", className), Path.GetFileName(fileName));
            }
            else if (!fileInfo.IsReadOnly && fileInfo.Exists)
            {
                File.SetAttributes(fileName, FileAttributes.ReadOnly);
                toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("ReadonlyYes", className), Path.GetFileName(fileName));
            }
            else
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoFileToReadonly", className));
            }

            switch (pagesTabControl.SelectedTabPage.ImageIndex)
            {
                case 0:
                    pagesTabControl.SelectedTabPage.ImageIndex = 2;
                    break;
                case 1:
                    pagesTabControl.SelectedTabPage.ImageIndex = 3;
                    break;
                case 2:
                    pagesTabControl.SelectedTabPage.ImageIndex = 0;
                    break;
                case 3:
                    pagesTabControl.SelectedTabPage.ImageIndex = 1;
                    break;
            }
        }

        internal static bool SaveFileCoreWithEncoding(Form1 form, String fileName, bool savingAll = false)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            return SaveFileCoreWithEncoding(form, fileName, ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Text, savingAll);
        }
        internal static bool SaveFileCoreWithEncoding(Form1 form, String fileName, String text, bool savingAll = false)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            bool success = true;
            FileStream fileStream = null;
            StreamWriter textFile = null;

            try
            {
                Encoding fileEncoding = EncodingUtil.GetDefaultEncoding();

                if (pagesTabControl != null)
                {
                    fileEncoding = TabUtil.GetTabTextEncoding(pagesTabControl.SelectedTabPage);
                }

                if (fileName.EndsWith(".xml"))
                {
                    try
                    {
                        byte[] byteArray = fileEncoding.GetBytes(text);
                        Encoding xmlEncoding;

                        using (MemoryStream stream = new MemoryStream(byteArray))
                        {
                            using (XmlTextReader xmlreader = new XmlTextReader(stream))
                            {
                                xmlreader.MoveToContent();
                                xmlEncoding = xmlreader.Encoding;
                            }
                        }

                        if (fileEncoding.GetType() != xmlEncoding.GetType())
                        {
                            TabsUpdate(pagesTabControl, savingAll, UpdatePhase.End); //Useful to save all execution
                            WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("EncodingXmlToSave", className));
                            TabsUpdate(pagesTabControl, savingAll, UpdatePhase.Begin); //Useful to save all execution

                            fileEncoding = xmlEncoding;
                        }

                        if (!XmlValidator.Validate(form, ValidationType.DTD, false, fileEncoding))
                        {
                            throw new FakeException();
                        }
                    }
                    catch (Exception)
                    {
                        TabsUpdate(pagesTabControl, savingAll, UpdatePhase.End); //Useful to save all execution
                        DialogResult questionResult = WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("InvalidXmlToSave", className));
                        TabsUpdate(pagesTabControl, savingAll, UpdatePhase.Begin); //Useful to save all execution

                        if (questionResult == DialogResult.No)
                        {
                            throw;
                        }
                    }

                    //if (!XmlValidator.Validate(form, ValidationType.DTD, false))
                    //{
                    //    if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("InvalidXmlToSave", className)) == DialogResult.No)
                    //    {
                    //        throw new FakeException();
                    //    }
                    //}
                    //else
                    //{
                    //    byte[] byteArray = fileEncoding.GetBytes(text);
                    //    Encoding xmlEncoding;

                    //    using (var stream = new MemoryStream(byteArray))
                    //    {
                    //        using (var xmlreader = new XmlTextReader(stream))
                    //        {
                    //            xmlreader.MoveToContent();
                    //            xmlEncoding = xmlreader.Encoding;
                    //        }
                    //    }

                    //    if (fileEncoding.GetType() != xmlEncoding.GetType())
                    //    {
                    //        WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("EncodingXmlToSave", className));
                    //        fileEncoding = xmlEncoding;
                    //    }
                    //}
                }

                fileStream = File.Create(fileName);
                textFile = new StreamWriter(fileStream, fileEncoding);
                textFile.Write(text.Replace(ConstantUtil.newLine, Environment.NewLine));

                TabUtil.SetTabTextEncoding(pagesTabControl.SelectedTabPage, fileEncoding);
            }
            catch (UnauthorizedAccessException)
            {
                Form form1 = null;
                if (pagesTabControl != null)
                {
                    form1 = pagesTabControl.FindForm();
                }

                WindowManager.ShowAlertBox(form1, LanguageUtil.GetCurrentLanguageString("UnauthorizedAccess", className));
                success = false;
            }
            catch (FakeException)
            {
                success = false;
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

            return success;
        }

        internal static void RenameFile(Form1 form, String newName)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            String fileName = ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage);
            if (String.IsNullOrEmpty(fileName) || Path.GetFileName(fileName) == newName)
            {
                return;
            }
            FileInfo fileInfo = new FileInfo(fileName);
            if (fileInfo.IsReadOnly)
            {
                if (WindowManager.ShowQuestionCancelBox(form, LanguageUtil.GetCurrentLanguageString("RemoveReadonlyToRename", className)) == DialogResult.Yes)
                {
                    ToggleReadonly(form);
                }
                else
                {
                    return;
                }
            }

            String newFileName = Path.Combine(Path.GetDirectoryName(fileName), newName);
            
            ProgramUtil.SetFilenameTabPage(pagesTabControl.SelectedTabPage, newFileName);
            pagesTabControl.SelectedTabPage.Text = newName;
            form.Text = String.Format("DtPad - {0}", newName);

            if (File.Exists(fileName))
            {
                File.Move(fileName, newFileName);
            }
            else
            {
                SaveFile(form, false);
            }

            SessionManager.FileRenamed(form, fileName, newFileName);
            FileListManager.SetNewRecentFile(form, newFileName);
            toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("FileRenamed", className), fileName, newName);
        }

        internal static void DeleteFile(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            String fileName = ProgramUtil.GetFilenameTabPage(pagesTabControl.SelectedTabPage);
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }

            if (WindowManager.ShowQuestionCancelBox(form, String.Format(LanguageUtil.GetCurrentLanguageString("SureDeleteFile", className), fileName)) != DialogResult.Yes)
            {
                return;
            }

            FileInfo fileInfo = new FileInfo(fileName);
            if (fileInfo.IsReadOnly)
            {
                ToggleReadonly(form);
            }

            FileSystem.DeleteFile(fileName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin); //File.Delete(fileName);
            toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("FileDeleted", className), fileName);

            TabManager.ClosePage(form, false);
        }

		#endregion Internal Methods

        #region Private Methods

        private static int OpenFile(Form1 form, int tabIdentity, String[] specificFileNames, bool showMessages, out List<String> errors)
        {
            return OpenFile(form, tabIdentity, specificFileNames, showMessages, true, out errors);
        }

        private static void SetFileDialogFilter(FileDialog fileDialog)
        {
            int defaultExtension;
            String defaultExtensionShortString;

            fileDialog.Filter = ExtensionManager.GetFileDialogFilter(out defaultExtension, out defaultExtensionShortString);

            if (defaultExtension != -1)
            {
                fileDialog.FilterIndex = defaultExtension + 1;
            }
            fileDialog.FileName = defaultExtensionShortString;
        }

        private static bool BackupFileOnSaving(Form1 form, String pathAndFileName)
        {
            FolderBrowserDialog folderBrowserDialog = form.folderBrowserDialog;
            
            String backupFileName;
            switch (ConfigUtil.GetIntParameter("BackupExtensionPosition"))
            {
                case 0:
                    backupFileName = Path.GetFileName(pathAndFileName) + ".bak";
                    break;
                case 1:
                    backupFileName = Path.GetFileNameWithoutExtension(pathAndFileName) + ".bak";
                    break;

                default:
                    backupFileName = Path.GetFileName(pathAndFileName) + ".bak";
                    break;
            }

            String backupPath;
            switch (ConfigUtil.GetIntParameter("BackupLocation"))
            {
                case 0:
                    backupPath = Path.GetDirectoryName(pathAndFileName);
                    break;
                case 1:
                    backupPath = ConfigUtil.GetStringParameter("BackupLocationCustom");
                    break;

                default:
                    backupPath = Path.GetDirectoryName(pathAndFileName);
                    break;
            }

            if (String.IsNullOrEmpty(backupPath) || !Directory.Exists(backupPath))
            {
                folderBrowserDialog.Description = LanguageUtil.GetCurrentLanguageString("folderDialogBackup", className);
                if (folderBrowserDialog.ShowDialog(form) != DialogResult.OK)
                {
                    return false;
                }
                backupPath = folderBrowserDialog.SelectedPath;
            }

            if (ConfigUtil.GetBoolParameter("BackupIncremental"))
            {
                int increment = Directory.GetFiles(backupPath, "backupFileName").Length;
                while (File.Exists(Path.Combine(backupPath, backupFileName + increment)))
                {
                    increment++;
                }
                backupFileName += increment;
            }

            File.Copy(pathAndFileName, Path.Combine(backupPath, backupFileName), true);

            return true;
        }

        private static void TabsUpdate(XtraTabControl pagesTabControl, bool savingAll, UpdatePhase phase)
        {
            if (!savingAll)
            {
                return;
            }

            switch (phase)
            {
                case UpdatePhase.Begin:
                    pagesTabControl.BeginUpdate();
                    break;
                case UpdatePhase.End:
                    pagesTabControl.EndUpdate();
                    break;
            }
        }

        #endregion Private Methods
    }
}
