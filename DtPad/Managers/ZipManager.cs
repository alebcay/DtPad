using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Utils;
using ICSharpCode.SharpZipLib.Zip;

namespace DtPad.Managers
{
    /// <summary>
    /// Zip (and even other formats) archive manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ZipManager
    {
        private const String className = "ZipManager";
        
        #region Internal Methods

        internal static void ReadZipContent(ZipExtract form, String fileNameAndPath, out bool isPasswordProtected)
        {
            DataGridView zipContentDataGridView = form.zipContentDataGridView;

            zipContentDataGridView.DataSource = GetZipContentList(fileNameAndPath, out isPasswordProtected);
            zipContentDataGridView.Sort(zipContentDataGridView.Columns[1], ListSortDirection.Ascending);
        }

        internal static void ExtractZipContent(Form1 form1, ZipExtract form, String fileNameAndPath, bool isPasswordProtected)
        {
            ToolStripStatusLabel toolStripStatusLabel = form1.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form1.toolStripProgressBar;
            DataGridView zipContentDataGridView = form.zipContentDataGridView;

            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
                                                              {
                                                                  Description = LanguageUtil.GetCurrentLanguageString("folderBrowserDialogDescription", className),
                                                                  RootFolder = Environment.SpecialFolder.Desktop,
                                                                  SelectedPath = FileUtil.GetInitialFolder(form1)
                                                              };

                if (folderBrowserDialog.ShowDialog(form) != DialogResult.OK)
                {
                    return;
                }

                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Visible = true;
                toolStripProgressBar.PerformStep();

                String selectedFilesRegExpression = SerializeSelectedFilesToExport(zipContentDataGridView.SelectedRows);
                toolStripProgressBar.PerformStep();

                FastZip zipFile = new FastZip();

                if (isPasswordProtected)
                {
                    WindowManager.ShowNameEntry(form);

                    if (String.IsNullOrEmpty(form.newObjectName))
                    {
                        toolStripProgressBar.Visible = false;
                        return;
                    }
                    
                    ZipFile testZip = null;
                    bool testResult;
                    try
                    {
                        testZip = new ZipFile(fileNameAndPath) { Password = form.newObjectName };
                        testResult = testZip.TestArchive(true, TestStrategy.FindFirstError, form1.Zip_Errors);
                    }
                    finally
                    {
                        if (testZip != null)
                        {
                            testZip.Close();
                        }
                    }

                    if (!testResult)
                    {
                        toolStripProgressBar.Visible = false;
                        return;
                    }

                    zipFile.Password = form.newObjectName;
                }

                toolStripProgressBar.PerformStep();

                FastZip.ConfirmOverwriteDelegate overDelegate = (PromptOverwrite);
                zipFile.ExtractZip(fileNameAndPath, folderBrowserDialog.SelectedPath, FastZip.Overwrite.Prompt, overDelegate, selectedFilesRegExpression, String.Empty, true);

                toolStripProgressBar.PerformStep();

                toolStripProgressBar.Visible = false;
                toolStripStatusLabel.Text = LanguageUtil.GetCurrentLanguageString("ExtractSuccess", className);
            }
            catch (Exception exception)
            {
                toolStripProgressBar.Visible = false;
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
        }

        internal static String GetZipContentListString(String fileNameAndPath)
        {
            ZipFile zipFile = null;
            String listString;

            try
            {
                zipFile = new ZipFile(fileNameAndPath);
                listString = String.Empty;

            for (int i = 0; i < zipFile.Count; i++)
            {
                ZipEntry zipEntry = zipFile[i];

                if (!zipEntry.IsFile)
                {
                    continue;
                }

                if (i >= zipFile.Count - 1)
                {
                    listString += zipEntry.Name;
                }
                else
                {
                    listString += zipEntry.Name + Environment.NewLine;
                }
            }
            }
            finally
            {
                if (zipFile != null)
                {
                    zipFile.Close();
                }
            }

            return listString;
        }

        internal static bool SaveAllFilesAsZip(Form1 form)
        {
            SaveFileDialog saveFileDialog = form.saveFileDialog;
            CustomXtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;

            if (TabManager.AreAllTabsEmptyAndWithoutFiles(form))
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoContent", className));
                return false;
            }

            //Save all files before to proceed
            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                if (!String.IsNullOrEmpty(ProgramUtil.GetFilenameTabPage(tabPage)) && !tabPage.Text.StartsWith("*"))
                {
                    continue;
                }

                if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("SaveAllFiles", className)) != DialogResult.Yes)
                {
                    return false;
                }

                if (!FileManager.SaveAllFiles(form))
                {
                    WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("FilesNotSaved", className));
                    return false;
                }

                break;
            }

            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;
            toolStripProgressBar.PerformStep();

            //Save file dialog
            saveFileDialog.InitialDirectory = FileUtil.GetInitialFolder(form);
            saveFileDialog.Filter = LanguageUtil.GetCurrentLanguageString("FileDialog", className);
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "*.zip";

            try
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    toolStripProgressBar.Visible = false;
                    return false;
                }

                toolStripProgressBar.PerformStep();
                String fileName = saveFileDialog.FileName;
                if (!fileName.EndsWith(".zip"))
                {
                    fileName += ".zip";
                }

                toolStripProgressBar.PerformStep();
                WriteZipFile(fileName, pagesTabControl.TabPages);

                toolStripProgressBar.PerformStep();
                toolStripStatusLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("Saved", className), fileName);
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

        #endregion Internal Methods

        #region Private Methods

        private static DataTable GetZipContentList(String fileNameAndPath, out bool isPasswordProtected)
        {
            isPasswordProtected = false;
            ZipFile zipFile = new ZipFile(fileNameAndPath);

            DataTable table = new DataTable();
            DataColumn column = new DataColumn(LanguageUtil.GetCurrentLanguageString("NameColumn", className), typeof(String));
            table.Columns.Add(column);
            column = new DataColumn(LanguageUtil.GetCurrentLanguageString("DirectoryColumn", className), typeof(String));
            table.Columns.Add(column);
            column = new DataColumn(LanguageUtil.GetCurrentLanguageString("OriginalSizeColumn", className), typeof(String));
            table.Columns.Add(column);
            column = new DataColumn(LanguageUtil.GetCurrentLanguageString("CompressedSizeColumn", className), typeof(String));
            table.Columns.Add(column);
            column = new DataColumn(LanguageUtil.GetCurrentLanguageString("DateTimeColumn", className), typeof(String));
            table.Columns.Add(column);
            column = new DataColumn(LanguageUtil.GetCurrentLanguageString("CanDecompressColumn", className), typeof(String));
            table.Columns.Add(column);

            foreach (ZipEntry zipEntry in zipFile)
            {
                if (!zipEntry.IsFile)
                {
                    continue;
                }

                if (zipEntry.IsCrypted)
                {
                    isPasswordProtected = true;
                }

                String zipEntryName = zipEntry.Name.Replace('/', '\\');
                String path = String.Empty;
                int lastPathPosition = zipEntryName.LastIndexOf('\\');
                if (lastPathPosition != -1)
                {
                    path = zipEntryName.Substring(0, lastPathPosition);
                }

                DataRow row = table.NewRow();
                row[0] = zipEntryName.Substring(lastPathPosition + 1);
                row[1] = path;
                row[2] = zipEntry.Size + " " + LanguageUtil.GetCurrentLanguageString("Bytes", className);
                row[3] = zipEntry.CompressedSize + " " + LanguageUtil.GetCurrentLanguageString("Bytes", className);
                row[4] = zipEntry.DateTime.ToString(LanguageUtil.GetDateTimeFormat());
                row[5] = zipEntry.CanDecompress ? LanguageUtil.GetCurrentLanguageString("Yes", className) : LanguageUtil.GetCurrentLanguageString("No", className);
                table.Rows.Add(row);
            }

            zipFile.Close();
            return table;
        }

        private static String SerializeSelectedFilesToExport(DataGridViewSelectedRowCollection selectedFilesToExport)
        {
            //@"DtPad\.exe\.config|DtPad\.exe\.ex|DtPad\.exe\.fv|DtPad\.exe\.no|DtPad\.exe\.rf|DtPad\.exe\.sh|DtPad\.exe\.to"
            String selectedFilesRegExpression = String.Empty;

            foreach (DataGridViewRow row in selectedFilesToExport)
            {
                if (!String.IsNullOrEmpty(selectedFilesRegExpression))
                {
                    selectedFilesRegExpression += "|";
                }

                selectedFilesRegExpression += row.Cells[0].Value.ToString().Replace(".", "\\.");
            }

            return selectedFilesRegExpression;
        }

        private static bool PromptOverwrite(String filename)
        {
            String shortFilename = StringUtil.CheckStringLength(filename, 50);
            String questionMessage = String.Format(LanguageUtil.GetCurrentLanguageString("OverwriteQuestion", className), shortFilename);

            return WindowManager.ShowQuestionBox(null, questionMessage) == DialogResult.Yes;
        }

        private static void WriteZipFile(String filename, XtraTabPageCollection tabPages)
        {
            ZipFile zipFile = ZipFile.Create(filename);
            zipFile.BeginUpdate();

            foreach (XtraTabPage tabPage in tabPages)
            {
                zipFile.Add(ProgramUtil.GetFilenameTabPage(tabPage), Path.GetFileName(ProgramUtil.GetFilenameTabPage(tabPage)));
            }

            zipFile.CommitUpdate();
            zipFile.Close();
        }

        #endregion Private Methods
    }
}
