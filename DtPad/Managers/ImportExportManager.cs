using System;
using System.IO;
using System.Windows.Forms;
using DtPad.Utils;
using ICSharpCode.SharpZipLib.Zip;

namespace DtPad.Managers
{
    /// <summary>
    /// Import and export processes manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ImportExportManager
    {
        private const String className = "ImportExportManager";

        #region Options Methods

        internal static void ExportOptions(Form1 form)
        {
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
                                                          {
                                                              Description = LanguageUtil.GetCurrentLanguageString("folderBrowserDialogDescription", className),
                                                              RootFolder = Environment.SpecialFolder.Desktop,
                                                              SelectedPath = FileUtil.GetInitialFolder(form)
                                                          };

            if (folderBrowserDialog.ShowDialog(form) != DialogResult.OK)
            {
                return;
            }

            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;
            
            String zipFileName = String.Format("{0}_{1}_{2}.{3}", ConstantUtil.exportOptionsFileName, AssemblyUtil.AssemblyVersion.Replace(".", String.Empty), DateTimeUtil.GetTodayDateAsString("yyyyMMdd"), ConstantUtil.exportFileExtension);

            toolStripProgressBar.PerformStep();

            FastZip exportFile = new FastZip();
            exportFile.CreateZip(Path.Combine(folderBrowserDialog.SelectedPath, zipFileName), ConstantUtil.ApplicationExecutionPath(), true,
                @"DtPad\.exe\.config|DtPad\.exe\.ex|DtPad\.exe\.fv|DtPad\.exe\.no|DtPad\.exe\.rf|DtPad\.exe\.rp|DtPad\.exe\.rs|DtPad\.exe\.sf|DtPad\.exe\.sh|DtPad\.exe\.tm|DtPad\.exe\.to|DtPad\.exe\.ru");
            
            toolStripProgressBar.PerformStep();

            ZipFile exportedFile = null;
            try
            {
                exportedFile = new ZipFile(Path.Combine(folderBrowserDialog.SelectedPath, zipFileName));
                exportedFile.BeginUpdate();
                exportedFile.SetComment("DtPad - " + AssemblyUtil.AssemblyVersion);
                exportedFile.CommitUpdate();
            }
            finally
            {
                if (exportedFile != null)
                {
                    exportedFile.Close();
                }
            }

            toolStripProgressBar.PerformStep();

            String exportStatus = String.Format("{0} \"{1}\" {2}", LanguageUtil.GetCurrentLanguageString("ExportStatusLabel1", className), zipFileName, LanguageUtil.GetCurrentLanguageString("ExportStatusLabel2", className));

            toolStripProgressBar.PerformStep();

            toolStripStatusLabel.Text = exportStatus;
            WindowManager.ShowInfoBox(form, exportStatus + "!");

            toolStripProgressBar.Visible = false;
        }

        internal static void ImportOptions(Form1 form)
        {
            OpenFileDialog openFileDialog = form.openFileDialog;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            ToolStripProgressBar toolStripProgressBar = form.toolStripProgressBar;

            openFileDialog.InitialDirectory = ConstantUtil.ApplicationExecutionPath();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = String.Format("{0} (*.{1})|*.{1}", LanguageUtil.GetCurrentLanguageString("ExportFileDescription", className), ConstantUtil.exportFileExtension); //DtPad Export files (*.dpe)|*.dpe

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            ZipFile toImportFile = null;
            try
            {
                toImportFile = new ZipFile(openFileDialog.FileName);

            if (toImportFile.ZipFileComment != AssemblyUtil.AssemblyVersion)
            {
                if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("WarningImport", className)) == DialogResult.No)
                {
                    return;
                }
            }
            }
            finally
            {
                if (toImportFile != null)
                {
            toImportFile.Close();
                }
            }

            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;

            FastZip importFile = new FastZip();
            toolStripProgressBar.PerformStep();

            importFile.ExtractZip(openFileDialog.FileName, ConstantUtil.ApplicationExecutionPath(), FastZip.Overwrite.Always, null, String.Empty, String.Empty, true);

            toolStripProgressBar.PerformStep();

            String importStatus = String.Format("{0} \"{1}\" {2}", LanguageUtil.GetCurrentLanguageString("ImportStatusLabel1", className), openFileDialog.FileName, LanguageUtil.GetCurrentLanguageString("ImportStatusLabel2", className));

            toolStripProgressBar.PerformStep();
            toolStripProgressBar.PerformStep();

            toolStripStatusLabel.Text = importStatus;
            WindowManager.ShowInfoBox(form, importStatus + "!");

            toolStripProgressBar.Visible = false;
        }

        #endregion Options Methods
    }
}
