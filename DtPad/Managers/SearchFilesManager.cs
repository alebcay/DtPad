using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.UserControls;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// In files text search manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class SearchFilesManager
    {
        private const String className = "SearchFilesManager";

        #region Internal Methods

        internal static void SearchTextInFiles(SearchInFiles form, Delegate ThreadCallBackResult)
        {
            TextBox textToSearchTextBox = form.textToSearchTextBox;
            TextBox filenamePatternTextBox = form.filenamePatternTextBox;
            TextBox exclusionPatternTextBox = form.exclusionPatternTextBox;
            CheckBox searchSubdirsCheckBox = form.searchSubdirsCheckBox;
            CheckBox hiddenFilesCheckBox = form.hiddenFilesCheckBox;
            CheckBox caseSensitiveCheckBox = form.caseSensitiveCheckBox;
            
            String stringToSearch = textToSearchTextBox.Text;
            String directoryWhereStartToSearch = form.searchFolder;
            String filePattern = filenamePatternTextBox.Text;
            String filePatternNegative = exclusionPatternTextBox.Text;
            bool topDirectoryOnly = !searchSubdirsCheckBox.Checked;

            List<String> result = new List<String>();
            SearchOption searchOption = topDirectoryOnly ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories;
            IEnumerable<String> filesFounded = FileUtil.GetFiles(directoryWhereStartToSearch, filePattern, searchOption); //Directory.GetFiles(directoryWhereStartToSearch, filePattern, searchOption);

            if (!String.IsNullOrEmpty(filePatternNegative) && filePatternNegative != "*.*")
            {
                List<String> filesFoundedTemp = new List<String>();
                String[] negativeFilters = filePatternNegative.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (String fileName in filesFounded)
                {
                    String fileNameWithoutPath = Path.GetFileName(fileName);
                    bool shouldBeAdded = false;

                    foreach(String negativeFilter in negativeFilters)
                    {
                        String negativeFilterTrimmed = negativeFilter.Trim();
                        if ((negativeFilterTrimmed.StartsWith("*.") && fileNameWithoutPath.EndsWith(negativeFilterTrimmed.Substring(1))) || (fileNameWithoutPath == negativeFilterTrimmed))
                        {
                            shouldBeAdded = false;
                            break;
                        }
                        shouldBeAdded = true;
                    }

                    if (shouldBeAdded)
                    {
                        filesFoundedTemp.Add(fileName);
                    }
                }

                filesFounded = filesFoundedTemp;
            }

            foreach (String fileName in filesFounded)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                if (fileInfo.Attributes.ToString().Contains("Hidden") && !hiddenFilesCheckBox.Checked)
                {
                    continue;
                }
                
                String fileContents = FileUtil.ReadToEndWithEncoding(fileName);

                if (!caseSensitiveCheckBox.Checked)
                {
                    fileContents = fileContents.ToLower();
                    stringToSearch = stringToSearch.ToLower();
                }

                if (fileContents.Contains(stringToSearch))
                {
                    result.Add(fileName.Replace(directoryWhereStartToSearch + "\\", String.Empty)); //".."
                }
            }

            form.Invoke(ThreadCallBackResult, result);
        }

        internal static void GetPath(SearchInFiles form)
        {
            FolderBrowserDialog folderBrowserDialog = form.folderBrowserDialog;
            ComboBox searchFolderComboBox = form.searchFolderComboBox;

            folderBrowserDialog.Description = LanguageUtil.GetCurrentLanguageString("folderDialogDefault", className);

            if (Directory.Exists(searchFolderComboBox.Text))
            {
                folderBrowserDialog.SelectedPath = searchFolderComboBox.Text;
            }
            else
            {
                folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            }

            if (form.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                searchFolderComboBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        internal static void OpenSelectedFileItem(Form1 form, SearchInFilesPanel panel)
        {
            ListBox searchInFilesListBox = panel.searchInFilesListBox;
            
            String[] selectedFiles = new String[searchInFilesListBox.SelectedItems.Count];
            for (int i = 0; i < searchInFilesListBox.SelectedItems.Count; i++)
            {
                object selectedItem = searchInFilesListBox.SelectedItems[i];
                selectedFiles[i] = GetFileCompletePathName(panel, selectedItem.ToString()); //pathBaseToolStripLabel.Text + selectedItem.ToString().Substring(2);
            }

            FileManager.OpenFile(form, form.TabIdentity, selectedFiles);
        }

        internal static void CopyFileFullPath(SearchInFilesPanel panel)
        {
            ListBox searchInFilesListBox = panel.searchInFilesListBox;

            foreach (object selectedItem in searchInFilesListBox.SelectedItems)
            {
                Clipboard.SetDataObject(GetFileCompletePathName(panel, selectedItem.ToString()), true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
            }
        }

        internal static void ExportList(Form1 form, SearchInFilesPanel panel)
        {
            ListBox searchInFilesListBox = panel.searchInFilesListBox;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            //String result = String.Empty;
            //foreach (object item in searchInFilesListBox.Items)
            //{
            //    result += GetFileCompletePathName(panel, item.ToString()) + ConstantUtil.newLine;
            //}
            String result = searchInFilesListBox.Items.Cast<object>().Aggregate(String.Empty, (current, item) => current + (GetFileCompletePathName(panel, item.ToString()) + ConstantUtil.newLine));

            if (TabManager.IsCurrentTabInUse(form))
            {
                form.TabIdentity = TabManager.AddNewPage(form, form.TabIdentity);
                pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            }

            pageTextBox.SelectedText = result;
        }

        internal static void ClearList(Form1 form, SearchInFilesPanel panel)
        {
            ListBox searchInFilesListBox = panel.searchInFilesListBox;
            
            if (WindowManager.ShowQuestionCancelBox(form, LanguageUtil.GetCurrentLanguageString("SureToClean", className)) == DialogResult.Yes)
            {
                searchInFilesListBox.Items.Clear();
            }
        }

        internal static String GetFileCompletePathName(SearchInFilesPanel panel, String shortFileName)
        {
            ToolStripLabel pathBaseToolStripLabel = panel.pathBaseToolStripLabel;

            return Path.Combine(pathBaseToolStripLabel.Text, shortFileName); //.Substring(2);
        }

        #endregion Internal Methods
    }
}
