using System.Data;

namespace DtPad.Objects
{
    /// <summary>
    /// CSV editor undo history object.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class CsvUndoHistory
    {
        internal CsvUndoHistory(DataTable csvGridView, int delimiterComboBox, int quoteComboBox, bool headerCheckBox)
        {
            CsvGridView = csvGridView;
            DelimiterComboBox = delimiterComboBox;
            QuoteComboBox = quoteComboBox;
            HeaderCheckBox = headerCheckBox;
        }

        #region Internal Instance Properties

        internal DataTable CsvGridView { private set; get; }
        internal int DelimiterComboBox { private set; get; }
        internal int QuoteComboBox { private set; get; }
        internal bool HeaderCheckBox { private set; get; }

        #endregion Internal Instance Properties
    }
}
