using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Objects;
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

        #region Column Methods

        internal static void AddNewColumn(CsvEditor form)
        {
            DataGridView csvGridView = form.csvGridView;
            ToolStripTextBox addNewColumnToolStripTextBox = form.addNewColumnToolStripTextBox;

            if (addNewColumnToolStripTextBox.Enabled)
            {
                ((DataTable)csvGridView.DataSource).Columns.Add(addNewColumnToolStripTextBox.Text, typeof(String));
                //csvGridView.Columns.Add(addNewColumnToolStripTextBox.Text, addNewColumnToolStripTextBox.Text);
            }
            else
            {
                String columnName = String.Format(LanguageUtil.GetCurrentLanguageString("StandardColumnLabel", className), csvGridView.Columns.Count);
                ((DataTable)csvGridView.DataSource).Columns.Add(columnName, typeof(String));
                //csvGridView.Columns.Add(columnName, columnName);
            }

            csvGridView.CurrentCell = csvGridView.Rows[0].Cells[csvGridView.Columns.Count - 1];
            SelectColumns(form, csvGridView.CurrentCell);
        }

        internal static bool IsNewColumnNameValorized(CsvEditor form)
        {
            ToolStripTextBox addNewColumnToolStripTextBox = form.addNewColumnToolStripTextBox;

            return addNewColumnToolStripTextBox.ForeColor != SystemColors.ControlDark;
        }

        internal static DataTable MoveColumn(CsvEditor form, int startingIndex, int endingIndex)
        {
            DataGridView csvGridView = form.csvGridView;

            DataTable modifiedCsvDataTable = ((DataTable)csvGridView.DataSource).Copy();
            modifiedCsvDataTable.Columns[startingIndex].SetOrdinal(endingIndex);

            return modifiedCsvDataTable;
        }

        internal static List<int> SelectColumns(CsvEditor form, DataGridViewSelectedCellCollection selectedCells)
        {
            DataGridView csvGridView = form.csvGridView;
            ToolStripButton deleteSelectedColumnsToolStripButton = form.deleteSelectedColumnsToolStripButton;

            csvGridView.ClearSelection();
            List<int> columnIndexes = new List<int>();

            foreach (DataGridViewCell cell in selectedCells)
            {
                for (int i = 0; i < csvGridView.RowCount; i++)
                {
                    csvGridView[cell.ColumnIndex, i].Selected = true;
                }

                columnIndexes.Add(cell.ColumnIndex);
            }

            deleteSelectedColumnsToolStripButton.Enabled = true;
            return columnIndexes;
        }
        private static void SelectColumns(CsvEditor form, DataGridViewCell cell)
        {
            DataGridView csvGridView = form.csvGridView;
            ToolStripButton deleteSelectedColumnsToolStripButton = form.deleteSelectedColumnsToolStripButton;

            csvGridView.ClearSelection();
            for (int i = 0; i < csvGridView.RowCount; i++)
            {
                csvGridView[cell.ColumnIndex, i].Selected = true;
            }

            deleteSelectedColumnsToolStripButton.Enabled = true;
        }

        internal static void DeleteSelectedColumns(CsvEditor form, List<int> selectedColumns)
        {
            DataGridView csvGridView = form.csvGridView;

            DataTable modifiedCsvDataTable = ((DataTable)csvGridView.DataSource).Copy();
            selectedColumns.Sort();
            int[] selectedColumnsCopy = new int[selectedColumns.Count];
            selectedColumns.CopyTo(selectedColumnsCopy);

            for (int i = selectedColumnsCopy.Length - 1; i >= 0; i--)
            {
                modifiedCsvDataTable.Columns.RemoveAt(selectedColumnsCopy[i]);
                csvGridView.Columns.RemoveAt(selectedColumnsCopy[i]);
            }

            AddUndo(form, modifiedCsvDataTable);
        }

        #endregion Column Methods

        #region Row Methods

        internal static List<int> SelectRows(CsvEditor form, DataGridViewSelectedCellCollection selectedCells)
        {
            DataGridView csvGridView = form.csvGridView;
            ToolStripButton deleteSelectedRowsToolStripButton = form.deleteSelectedRowsToolStripButton;

            csvGridView.ClearSelection();
            List<int> rowsIndexes = new List<int>();

            foreach (DataGridViewCell cell in selectedCells)
            {
                for (int i = 0; i < csvGridView.ColumnCount; i++)
                {
                    csvGridView[i, cell.RowIndex].Selected = true;
                }

                rowsIndexes.Add(cell.RowIndex);
            }

            deleteSelectedRowsToolStripButton.Enabled = true;
            return rowsIndexes;
        }

        internal static void DeleteSelectedRows(CsvEditor form, List<int> selectedRows)
        {
            DataGridView csvGridView = form.csvGridView;

            if (csvGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in csvGridView.SelectedRows)
                {
                    if (!selectedRow.IsNewRow)
                    {
                        csvGridView.Rows.RemoveAt(selectedRow.Index);
                    }
                }
            }
            else if (selectedRows.Count > 0)
            {
                DataTable modifiedCsvDataTable = ((DataTable)csvGridView.DataSource).Copy();
                selectedRows.Sort();
                int[] selectedRowsCopy = new int[selectedRows.Count];
                selectedRows.CopyTo(selectedRowsCopy);

                for (int i = selectedRowsCopy.Length - 1; i >= 0; i--)
                {
                    modifiedCsvDataTable.Rows.RemoveAt(selectedRowsCopy[i]);
                    csvGridView.Rows.RemoveAt(selectedRowsCopy[i]);
                }

                AddUndo(form, modifiedCsvDataTable);
            }
        }

        #endregion Row Methods

        #region Clipboard Methods

        internal static void AddUndo(CsvEditor form, DataTable dataSource = null)
        {
            DataGridView csvGridView = form.csvGridView;
            ComboBox delimiterComboBox = form.delimiterComboBox;
            ComboBox quoteComboBox = form.quoteComboBox;
            CheckBox headerCheckBox = form.headerCheckBox;

            if (form.noAutomaticalActionForControls)
            {
                return;
            }

            if (dataSource == null)
            {
                dataSource = ((DataTable)csvGridView.DataSource).Copy();
            }

            //if (form.undoHistory.Count == 0 || !(form.undoHistory[form.undoHistory.Count - 1].CsvGridView.Equals(csvGridView.DataSource)))
            //{
            form.undoHistory.Add(new CsvUndoHistory(dataSource, delimiterComboBox.SelectedIndex, quoteComboBox.SelectedIndex, headerCheckBox.Checked));
            ManageApplyButton(form);
            //}
        }

        internal static void PerformUndo(CsvEditor form)
        {
            DataGridView csvGridView = form.csvGridView;
            ComboBox delimiterComboBox = form.delimiterComboBox;
            ComboBox quoteComboBox = form.quoteComboBox;
            CheckBox headerCheckBox = form.headerCheckBox;

            form.noAutomaticalActionForControls = true;

            csvGridView.Columns.Clear();
            csvGridView.DataSource = form.undoHistory[form.undoHistory.Count - 2].CsvGridView.Copy();
            delimiterComboBox.SelectedIndex = form.undoHistory[form.undoHistory.Count - 2].DelimiterComboBox;
            quoteComboBox.SelectedIndex = form.undoHistory[form.undoHistory.Count - 2].QuoteComboBox;
            headerCheckBox.Checked = form.undoHistory[form.undoHistory.Count - 2].HeaderCheckBox;

            form.undoHistory.RemoveAt(form.undoHistory.Count - 1);

            form.noAutomaticalActionForControls = false;

            ManageApplyButton(form);
        }

        internal static void ClearUndo(CsvEditor form)
        {
            Button applyButton = form.applyButton;
            ToolStripSplitButton undoToolStripSplitButton = form.undoToolStripSplitButton;
            ToolStripMenuItem undoToolStripMenuItem = form.undoToolStripMenuItem;

            undoToolStripSplitButton.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            applyButton.Enabled = false;

            form.undoHistory.RemoveRange(1, form.undoHistory.Count - 1);
        }

        internal static void ManageApplyButton(CsvEditor form)
        {
            Button applyButton = form.applyButton;
            ToolStripSplitButton undoToolStripSplitButton = form.undoToolStripSplitButton;
            ToolStripMenuItem undoToolStripMenuItem = form.undoToolStripMenuItem;

            if (form.undoHistory.Count > 1) // || currentDelimiter != standardDelimiter || currentQuote != standardQuote)
            {
                applyButton.Enabled = true;
                undoToolStripSplitButton.Enabled = true;
                undoToolStripMenuItem.Enabled = true;
            }
            else
            {
                applyButton.Enabled = false;
                undoToolStripSplitButton.Enabled = false;
                undoToolStripMenuItem.Enabled = false;
            }
        }

        #endregion Clipboard Methods
    }
}
