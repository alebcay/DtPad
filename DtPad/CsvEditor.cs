using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private bool noAutomaticalActionForControls;

        private List<CsvUndoHistory> undoHistory;

        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);
            currentDelimiter = standardDelimiter;
            currentQuote = standardQuote;

            noAutomaticalActionForControls = true;

            delimiterComboBox.SelectedIndex = 1;
            quoteComboBox.SelectedIndex = 1;
            CsvManager.ReadCsv(this, headerCheckBox.Checked, currentDelimiter, currentQuote);

            noAutomaticalActionForControls = false;

            undoHistory = new List<CsvUndoHistory>();
            AddUndo();

            noAutomaticalActionForControls = true; //Needed until show event has ended
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            noAutomaticalActionForControls = false; //Now I can free the flag
        }

        private void csvGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AddUndo();
        }

        private void delimiterComboBox_TextChanged(object sender, EventArgs e)
        {
            if (noAutomaticalActionForControls || String.IsNullOrEmpty(delimiterComboBox.Text))
            {
                return;
            }

            currentDelimiter = delimiterComboBox.Text[0];
            CsvManager.ReadCsv(this, headerCheckBox.Checked, currentDelimiter, currentQuote);
        }

        private void quoteComboBox_TextChanged(object sender, EventArgs e)
        {
            if (noAutomaticalActionForControls || String.IsNullOrEmpty(quoteComboBox.Text))
            {
                return;
            }

            currentQuote = quoteComboBox.Text[0];
            CsvManager.ReadCsv(this, headerCheckBox.Checked, currentDelimiter, currentQuote);
        }

        private void headerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!noAutomaticalActionForControls)
            {
                CsvManager.ReadCsv(this, headerCheckBox.Checked, currentDelimiter, currentQuote);
            }
        }

        private void CsvEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            undoHistory.Clear();
        }

        #endregion Window Methods

        #region Toolbar Methods

        private void undoToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            PerformUndo();
        }

        private void undoAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csvGridView.SuspendLayout();

            while (undoHistory.Count > 1)
            {
                PerformUndo();
            }

            csvGridView.ResumeLayout();
        }

        #endregion Toolbar Methods

        #region Button Methods

        private void applyButton_Click(object sender, EventArgs e)
        {
            CsvManager.WriteCsv(this, currentQuote, currentDelimiter);
            WindowManager.CloseForm(this);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (undoHistory.Count > 1 && WindowManager.ShowQuestionBox(this, LanguageUtil.GetCurrentLanguageString("CloseConfirm", Name)) == DialogResult.Yes)
            {
                WindowManager.CloseForm(this);
            }
            else if (undoHistory.Count <= 1)
            {
                WindowManager.CloseForm(this);
            }
        }

        #endregion Button Methods

        #region Context Menu Methods

        private void gridViewContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            deleteSelectedRowsToolStripMenuItem.Enabled = (csvGridView.SelectedRows.Count > 0);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformUndo();
        }

        private void deleteSelectedRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in csvGridView.SelectedRows)
            {
                csvGridView.Rows.RemoveAt(selectedRow.Index);
            }
        }

        #endregion Context Menu Methods

        #region Private Methods

        private void PerformUndo()
        {
            noAutomaticalActionForControls = true;

            csvGridView.DataSource = undoHistory[undoHistory.Count - 2].CsvGridView.Copy();
            delimiterComboBox.SelectedIndex = undoHistory[undoHistory.Count - 2].DelimiterComboBox;
            quoteComboBox.SelectedIndex = undoHistory[undoHistory.Count - 2].QuoteComboBox;
            headerCheckBox.Checked = undoHistory[undoHistory.Count - 2].HeaderCheckBox;

            undoHistory.RemoveAt(undoHistory.Count - 1);

            noAutomaticalActionForControls = false;

            ManageApplyButton();
        }

        private void AddUndo()
        {
            if (noAutomaticalActionForControls)
            {
                return;
            }

            undoHistory.Add(new CsvUndoHistory(((DataTable)csvGridView.DataSource).Copy(), delimiterComboBox.SelectedIndex, quoteComboBox.SelectedIndex, headerCheckBox.Checked));
            ManageApplyButton();
        }

        private void ManageApplyButton()
        {
            if (undoHistory.Count > 1) // || currentDelimiter != standardDelimiter || currentQuote != standardQuote)
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

        #endregion Private Methods

        private void insertOneRowUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csvGridView.Rows.Insert(csvGridView.SelectedRows[0].Index, 1);
        }

        private void insertOneRowDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csvGridView.Rows.Insert(csvGridView.SelectedRows[csvGridView.SelectedRows.Count].Index, 1);
        }
    }
}
