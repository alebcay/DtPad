using System;
using System.Windows.Forms;

namespace DtPadSetup.Managers
{
    /// <summary>
    /// Text operations manager (ie. undo/redo, paste).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TextManager
    {
        #region Generic Control Methods

        internal static void UndoControl(Control activeControl)
        {
            if (activeControl.GetType() != typeof(TextBox))
            {
                return;
            }

            TextBox textBox = (TextBox)activeControl;

            if (!textBox.CanUndo)
            {
                return;
            }
            textBox.Focus();
            textBox.Undo();
        }

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

        internal static void CutControl(Control activeControl)
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
            textBox.Cut();
        }

        internal static void PasteControl(Control activeControl)
        {
            if (activeControl.GetType() != typeof(TextBox))
            {
                return;
            }

            TextBox textBox = (TextBox)activeControl;
            textBox.Focus();
            textBox.Paste();
        }

        internal static void DeleteControl(Control activeControl)
        {
            if (activeControl.GetType() != typeof(TextBox))
            {
                return;
            }

            TextBox textBox = (TextBox)activeControl;

            if (textBox.SelectionLength == 0)
            {
                textBox.SelectionLength = 1;
            }
            textBox.Focus();
            textBox.SelectedText = String.Empty;
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
