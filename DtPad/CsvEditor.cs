using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Csv view DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    /// <remarks>http://www.codeproject.com/Articles/9258/A-Fast-CSV-Reader</remarks>
    internal partial class CsvEditor : Form
    {
        private const char standardDelimiter = ',';
        private const char standardQuote = '"';

        private char currentDelimiter;
        private char currentQuote;
        internal bool noAutomaticalActionForControls;
        private bool resetQuestionMade;
        private bool columnMovementDone;
        internal bool addingNewColumn;

        internal List<CsvUndoHistory> undoHistory = new List<CsvUndoHistory>();
        private List<int> selectedColumns = new List<int>();
        private List<int> selectedRows = new List<int>();

        internal DataTable startingData;

        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(new[] { customContextMenuStrip, gridViewContextMenuStrip });
            ControlUtil.SetContextMenuStrip(this, new[] { delimiterComboBox, quoteComboBox });
            SetLanguage();

            currentDelimiter = standardDelimiter;
            currentQuote = standardQuote;

            noAutomaticalActionForControls = true; //Needed until show event has ended

            delimiterComboBox.SelectedIndex = 1;
            quoteComboBox.SelectedIndex = 2;
            CsvManager.ReadCsv(this, headerCheckBox.Checked, currentDelimiter, currentQuote);

            startingData = ((DataTable)csvGridView.DataSource).Copy();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            noAutomaticalActionForControls = false; //Now I can free the flag
        }

        private void delimiterComboBox_TextChanged(object sender, EventArgs e)
        {
            if (noAutomaticalActionForControls || String.IsNullOrEmpty(delimiterComboBox.Text))
            {
                return;
            }

            if (undoHistory.Count > 0)
            {
                if (resetQuestionMade || (WindowManager.ShowQuestionBox(this, LanguageUtil.GetCurrentLanguageString("ResetChanges", Name)) != DialogResult.No))
                {
                    delimiterComboBox.SelectedIndex = delimiterComboBox.FindString(currentDelimiter.ToString());
                    resetQuestionMade = false;
                    return;
                }

                noAutomaticalActionForControls = true;
                resetQuestionMade = true;
                delimiterComboBox.SelectedIndex = delimiterComboBox.FindString(currentDelimiter.ToString());
                noAutomaticalActionForControls = false;

                return;
            }

            currentDelimiter = delimiterComboBox.Text[0];
            CsvManager.ReadCsv(this, headerCheckBox.Checked, currentDelimiter, currentQuote);
            //ClearUndo();
        }

        private void quoteComboBox_TextChanged(object sender, EventArgs e)
        {
            if (noAutomaticalActionForControls || String.IsNullOrEmpty(quoteComboBox.Text))
            {
                return;
            }

            if (undoHistory.Count > 0)
            {
                if (resetQuestionMade || (WindowManager.ShowQuestionBox(this, LanguageUtil.GetCurrentLanguageString("ResetChanges", Name)) != DialogResult.No))
                {
                    quoteComboBox.SelectedIndex = quoteComboBox.FindString(currentQuote.ToString());
                    resetQuestionMade = false;
                    return;
                }

                noAutomaticalActionForControls = true;
                resetQuestionMade = true;
                quoteComboBox.SelectedIndex = quoteComboBox.FindString(currentQuote.ToString());
                noAutomaticalActionForControls = false;

                return;
            }

            currentQuote = quoteComboBox.SelectedIndex != 1 ? quoteComboBox.Text[0] : '\0';
            CsvManager.ReadCsv(this, headerCheckBox.Checked, currentDelimiter, currentQuote);
            //ClearUndo();
        }

        private void headerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!noAutomaticalActionForControls)
            {
                if (undoHistory.Count > 0 && WindowManager.ShowQuestionBox(this, LanguageUtil.GetCurrentLanguageString("ResetChanges", Name)) == DialogResult.No)
                {
                    noAutomaticalActionForControls = true;
                    headerCheckBox.Checked = !headerCheckBox.Checked;
                    noAutomaticalActionForControls = false;

                    return;
                }

                CsvManager.ReadCsv(this, headerCheckBox.Checked, currentDelimiter, currentQuote);
                CsvManager.ClearUndo(this);
            }

            if (headerCheckBox.Checked)
            {
                addNewColumnToolStripTextBox.Enabled = true;
                addNewColumnToolStripButton.Enabled = CsvManager.IsNewColumnNameValorized(this);
            }
            else
            {
                addNewColumnToolStripTextBox.Enabled = false;
                addNewColumnToolStripButton.Enabled = true;
            }
        }

        private void addNewColumnToolStripTextBox_Enter(object sender, EventArgs e)
        {
            if (!CsvManager.IsNewColumnNameValorized(this))
            {
                addNewColumnToolStripTextBox.Text = String.Empty;
                addNewColumnToolStripTextBox.ForeColor = SystemColors.WindowText;
                addNewColumnToolStripTextBox.Font = new Font("Tahoma", 8.25F);
            }
        }

        private void addNewColumnToolStripTextBox_Leave(object sender, EventArgs e)
        {
            if (addNewColumnToolStripTextBox.Text == String.Empty)
            {
                addNewColumnToolStripTextBox.Font = new Font("Tahoma", 8.25F, FontStyle.Italic);
                addNewColumnToolStripTextBox.ForeColor = SystemColors.ControlDark;
                addNewColumnToolStripTextBox.Text = LanguageUtil.GetCurrentLanguageString("addNewColumnToolStripTextBox", Name);
            }
        }

        private void addNewColumnToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!headerCheckBox.Checked || (addNewColumnToolStripTextBox.Text != String.Empty && CsvManager.IsNewColumnNameValorized(this)))
            {
                addNewColumnToolStripButton.Enabled = true;
            }
            else
            {
                addNewColumnToolStripButton.Enabled = false;
            }
        }

        private void csvGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Index != e.Column.DisplayIndex && !columnMovementDone)
            {
                CsvManager.AddUndo(this);
                columnMovementDone = true;
            }
        }

        private void csvGridView_SelectionChanged(object sender, EventArgs e)
        {
            selectedColumns.Clear();
            selectedRows.Clear();

            if (csvGridView.AreAllCellsSelected(true))
            {
                foreach(DataGridViewColumn column in csvGridView.Columns)
                {
                    selectedColumns.Add(column.Index);
                }
                foreach (DataGridViewRow row in csvGridView.Rows)
                {
                    selectedRows.Add(row.Index);
                }
            }

            deleteSelectedColumnsToolStripButton.Enabled = (selectedColumns.Count > 0);
            deleteSelectedRowsToolStripButton.Enabled = (csvGridView.SelectedRows.Count > 0 || selectedRows.Count > 0);
        }

        private void csvGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!addingNewColumn)
            {
                CsvManager.AddUndo(this);
            }
        }

        private void csvGridView_Sorted(object sender, EventArgs e)
        {
            CsvManager.AddUndo(this);
        }

        private void csvGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            columnMovementDone = false;
        }

        private void CsvEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (undoHistory.Count > 0 && WindowManager.ShowQuestionBox(this, LanguageUtil.GetCurrentLanguageString("CloseConfirm", Name)) == DialogResult.Yes)
            {
                CsvManager.ClearUndo(this);
            }
            else if (undoHistory.Count == 0)
            {
                CsvManager.ClearUndo(this);
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion Window Methods

        #region Toolbar Methods

        private void undoToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            CsvManager.PerformUndo(this);
        }

        private void undoAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csvGridView.SuspendLayout();

            while (undoHistory.Count > 0)
            {
                CsvManager.PerformUndo(this);
            }

            csvGridView.ResumeLayout();
        }

        private void addNewColumnToolStripButton_Click(object sender, EventArgs e)
        {
            CsvManager.AddNewColumn(this);
        }

        private void currentColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumns.Clear();
            selectedColumns = CsvManager.SelectColumns(this, csvGridView.SelectedCells);
        }

        private void currentRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedRows.Clear();
            selectedRows = CsvManager.SelectRows(this, csvGridView.SelectedCells);
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csvGridView.SelectAll();
        }

        private void editHeaderToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.ShowCsvEditorHeader(this);
        }

        private void deleteSelectedColumnsToolStripButton_Click(object sender, EventArgs e)
        {
            CsvManager.DeleteSelectedColumns(this, selectedColumns);
        }

        private void deleteSelectedRowsToolStripButton_Click(object sender, EventArgs e)
        {
            CsvManager.DeleteSelectedRows(this, selectedRows);
        }

        private void cellWrapToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            csvGridView.DefaultCellStyle.WrapMode = cellWrapToolStripButton.Checked ? DataGridViewTriState.True : DataGridViewTriState.False;
            csvGridView.AutoResizeRows();
        }

        private void screenshotToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.TakeDataGridViewScreenshot(this);
        }

        #endregion Toolbar Methods

        #region Button Methods

        private void applyButton_Click(object sender, EventArgs e)
        {
            CsvManager.WriteCsv(this, currentQuote, currentDelimiter);
            CsvManager.ClearUndo(this);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region Context Menu Methods

        private void gridViewContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            deleteSelectedColumnsToolStripMenuItem.Enabled = deleteSelectedColumnsToolStripButton.Enabled;
            deleteSelectedRowsToolStripMenuItem.Enabled = deleteSelectedRowsToolStripButton.Enabled;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsvManager.PerformUndo(this);
        }

        private void selectCurrentColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumns.Clear();
            selectedColumns = CsvManager.SelectColumns(this, csvGridView.SelectedCells);
        }

        private void selectCurrentRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedRows.Clear();
            selectedRows = CsvManager.SelectRows(this, csvGridView.SelectedCells);
        }

        private void deleteSelectedColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsvManager.DeleteSelectedColumns(this, selectedColumns);
        }

        private void deleteSelectedRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsvManager.DeleteSelectedRows(this, selectedRows);
        }

        //private void insertOneRowUpToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    csvGridView.Rows.Insert(csvGridView.SelectedRows[0].Index, 1);
        //}

        //private void insertOneRowDownToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    csvGridView.Rows.Insert(csvGridView.SelectedRows[csvGridView.SelectedRows.Count - 1].Index + 1, 1);
        //}

        #endregion Context Menu Methods

        #region Custom Context Menu Methods

        private void customContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoCustomToolStripMenuItem.Enabled = addNewColumnToolStripTextBox.CanUndo;
        }

        private void undoCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewColumnToolStripTextBox.Undo();
        }

        private void cutCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewColumnToolStripTextBox.Cut();
        }

        private void copyCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewColumnToolStripTextBox.Copy();
        }

        private void pasteCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewColumnToolStripTextBox.Paste();
        }

        private void deleteCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewColumnToolStripTextBox.SelectedText = String.Empty;
        }

        private void selectAllCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewColumnToolStripTextBox.SelectAll();
        }

        #endregion Custom Context Menu Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, customContextMenuStrip.Items);
            addNewColumnToolStripTextBox.Text = LanguageUtil.GetCurrentLanguageString("addNewColumnToolStripTextBox", Name);
        }

        #endregion Private Methods
    }
}
