using System.Windows.Forms;

namespace DtPadUpdater.Managers
{
    /// <summary>
    /// Text operations manager (ie. undo/redo, paste).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TextManager
    {
        #region Generic Control Methods

        internal static void CopyControl(Control activeControl)
        {
            if (activeControl.GetType() != typeof(TextBox))
            {
                return;
            }

            TextBox textBox = (TextBox)activeControl;

            if (textBox.SelectionLength <= 0)
            {
                return;
            }
            textBox.Focus();
            textBox.Copy();
        }

        internal static void SelectAllControl(Control activeControl)
        {
            if (activeControl.GetType() != typeof(TextBox))
            {
                return;
            }

            TextBox textBox = (TextBox)activeControl;
            textBox.Focus();
            textBox.SelectAll();
        }

        #endregion Generic Control Methods
    }
}
