using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Utils;
using LumenWorks.Framework.IO.Csv;

namespace DtPad.Managers
{
    /// <summary>
    /// Csv file manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class CsvManager
    {
        private const String className = "CsvManager";

        #region Read Methods

        internal static void ReadCsv(CsvEditor form, bool withHeader, char delimiter, char quote)
        {
            Form1 form1 = (Form1)form.Owner;
            XtraTabControl pagesTabControl = form1.pagesTabControl;
            DataGridView csvGridView = form.csvGridView;
            //ContextMenuStrip contentContextMenuStrip = form.contentContextMenuStrip;

            Encoding textEncoding = EncodingUtil.GetDefaultEncoding();
            String text = String.Empty;
            if (pagesTabControl != null)
            {
                textEncoding = TabUtil.GetTabTextEncoding(pagesTabControl.SelectedTabPage);
                text = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Text;
            }

            byte[] byteArray = textEncoding.GetBytes(text);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                try
                {
                    using (CachedCsvReader csv = new CachedCsvReader(new StreamReader(stream), withHeader, delimiter, quote, '\\', '#', ValueTrimmingOptions.UnquotedOnly))
                    {
                        csv.DefaultParseErrorAction = ParseErrorAction.AdvanceToNextLine;
                        csv.SkipEmptyLines = true;

                        if (String.IsNullOrEmpty(csv[0, 0]))
                        {
                            WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("NoResults", className));
                        }

                        //PutCsvReaderIntoDataGrid(csv, csvGridView);
                        csvGridView.Columns.Clear();
                        csvGridView.DataSource = ConvertCsvReaderToDataTable(csv);
                    }

                    //for (int i = 0; i < csvGridView.Rows.Count; i++)
                    //{
                    //    for (int j = 0; j < csvGridView.Rows[i].Cells.Count; j++)
                    //    {
                    //        csvGridView.Rows[i].Cells[j].ContextMenuStrip = contentContextMenuStrip;
                    //    }
                    //}
                }
                catch (Exception exception)
                {
                    WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ContentError", className), exception);
                }
            }

            csvGridView.Refresh();
        }

        private static DataTable ConvertCsvReaderToDataTable(CachedCsvReader csv)
        {
            DataTable csvDataTable = new DataTable();

            String[] csvHeaders = csv.GetFieldHeaders();
            if (csvHeaders.Length > 0)
            {
                foreach (String csvHeader in csvHeaders)
                {
                    csvDataTable.Columns.Add(csvHeader, typeof(String));
                }
            }
            else
            {
                for (int i = 0; i < csv.FieldCount; i++)
                {
                    csvDataTable.Columns.Add(String.Format(LanguageUtil.GetCurrentLanguageString("StandardColumnLabel", className), i), typeof(String));
                }
            }

            do
            {
                object[] csvRow = new object[csvDataTable.Columns.Count];

                for (int i = 0; i < csv.FieldCount; i++)
                {
                    csvRow[i] = csv[i];
                }

                csvDataTable.Rows.Add(csvRow);
            } while (csv.ReadNextRecord());

            return csvDataTable;
        }

        //private static void PutCsvReaderIntoDataGrid(CsvReader csv, DataGridView csvGridView)
        //{
        //    String[] csvHeaders = csv.GetFieldHeaders();
        //    if (csvHeaders.Length > 0)
        //    {
        //        foreach (String csvHeader in csvHeaders)
        //        {
        //            csvGridView.Columns.Add(csvHeader, csvHeader);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < csv.FieldCount; i++)
        //        {
        //            csvGridView.Columns.Add(String.Format(LanguageUtil.GetCurrentLanguageString("StandardColumnLabel", className), i), String.Format(LanguageUtil.GetCurrentLanguageString("StandardColumnLabel", className), i));
        //        }
        //    }

        //    do
        //    {
        //        object[] csvRow = new object[csvGridView.Columns.Count];

        //        for (int i = 0; i < csv.FieldCount; i++)
        //        {
        //            csvRow[i] = csv[i];
        //        }

        //        csvGridView.Rows.Add(csvRow);
        //    } while (csv.ReadNextRecord());
        //}

        #endregion Read Methods
        
        #region Write Methods

        internal static void WriteCsv(CsvEditor form, char quote, char delimiter)
        {
            Form1 form1 = (Form1)form.Owner;
            XtraTabControl pagesTabControl = form1.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            DataGridView csvGridView = form.csvGridView;
            CheckBox headerCheckBox = form.headerCheckBox;

            String finalText = String.Empty;
            String quoteStr = (quote == '\0') ? String.Empty : quote.ToString();

            if (headerCheckBox.Checked)
            {
                for (int i = 0; i < csvGridView.Columns.Count; i++)
                {
                    finalText += quoteStr + csvGridView.Columns[i].HeaderText + quoteStr + delimiter;
                }

                finalText = finalText.Substring(0, finalText.Length - 1) + ConstantUtil.newLine;
            }

            for (int i = 0; i < csvGridView.Rows.Count - 1; i++)
            {
                for (int j = 0; j < csvGridView.Rows[i].Cells.Count; j++)
                {
                    if (csvGridView.Rows[i].Cells[j].Value == null)
                    {
                        finalText += quoteStr + String.Empty + quoteStr + delimiter;
                    }
                    else
                    {
                        finalText += quoteStr + csvGridView.Rows[i].Cells[j].Value + quoteStr + delimiter;
                    }
                }

                finalText = finalText.Substring(0, finalText.Length - 1) + ConstantUtil.newLine;
            }

            finalText = finalText.Substring(0, finalText.Length - 1);

            pageTextBox.SelectAll();
            pageTextBox.SelectedText = finalText;
            TextManager.RefreshUndoRedoExternal(form1);
        }

        #endregion Write Methods

        #region Other Methods

        internal static void AddNewColumn(CsvEditor form)
        {
            DataGridView csvGridView = form.csvGridView;
            ToolStripTextBox addNewColumnToolStripTextBox = form.addNewColumnToolStripTextBox;

            if (addNewColumnToolStripTextBox.Enabled)
            {
                csvGridView.Columns.Add(addNewColumnToolStripTextBox.Text, addNewColumnToolStripTextBox.Text);
            }
            else
            {
                String columnName = String.Format(LanguageUtil.GetCurrentLanguageString("StandardColumnLabel", className), csvGridView.Columns.Count);
                csvGridView.Columns.Add(columnName, columnName);
            }
        }

        internal static bool IsNewColumnNameValorized(CsvEditor form)
        {
            ToolStripTextBox addNewColumnToolStripTextBox = form.addNewColumnToolStripTextBox;

            return addNewColumnToolStripTextBox.ForeColor != SystemColors.ControlDark;
        }

        #endregion Other Methods
    }
}
