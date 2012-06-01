using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Special char selection DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class CharSelect : Form
    {
        const int minCharIndex = 161; //128
        const int maxCharIndex = 383;

        internal enum CharType
        {
            [Description("Special characters")]
            Standard,
            [Description("HTML tag for special characters")]
            Html
        }

        #region Window Methods

        internal void InitializeForm(CharType charType)
        {
            InitializeComponent();

            switch (charType)
            {
                case CharType.Standard:
                    InitializeChars();
                    break;
                case CharType.Html:
                    InitializeHtml();
                    break;
            }

            LanguageUtil.SetCurrentLanguage(this);
        }

        private void charsDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Object selectedChar = charsDataGridView[e.ColumnIndex, e.RowIndex].Value;

            if (selectedChar == null)
            {
                return;
            }

            Clipboard.SetDataObject(selectedChar.ToString(), true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
            clipboardedLabel.Text = selectedChar.ToString();
        }

        private void CharSelect_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods}

        #region Button Methods

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void InitializeChars()
        {
            int rowCounterTable = charsDataGridView.Rows.Add();
            int columnCounterTable = 0;

            charsDataGridView[columnCounterTable, rowCounterTable].Value = "€";
            columnCounterTable++;

            for (int i = minCharIndex; i < maxCharIndex; i++)
            {
                char c = Convert.ToChar(i, CultureInfo.CurrentCulture);

                if (char.IsControl(c))
                {
                    continue;
                }

                charsDataGridView[columnCounterTable, rowCounterTable].Value = c.ToString();
                columnCounterTable++;

                if ((i >= maxCharIndex - 1) || (columnCounterTable != charsDataGridView.Columns.Count))
                {
                    continue;
                }

                rowCounterTable = charsDataGridView.Rows.Add();
                columnCounterTable = 0;
            }

            charsDataGridView.Update();
        }

        private void InitializeHtml()
        {
            charsDataGridView.ColumnCount = 2;

            foreach(KeyValuePair<String, String> keyValuePair in ConstantUtil.HtmlTags)
            {
                int rowCounterTable = charsDataGridView.Rows.Add();
                charsDataGridView[0, rowCounterTable].Value = keyValuePair.Key;
                charsDataGridView[1, rowCounterTable].Value = keyValuePair.Value;
            }

            foreach (KeyValuePair<String, String> keyValuePair in ConstantUtil.HtmlTagsNumbers)
            {
                int rowCounterTable = charsDataGridView.Rows.Add();
                charsDataGridView[0, rowCounterTable].Value = keyValuePair.Key;
                charsDataGridView[1, rowCounterTable].Value = keyValuePair.Value;
            }
        }

        #endregion Private Methods
    }
}
