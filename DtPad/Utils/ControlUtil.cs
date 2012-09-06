using System.Windows.Forms;
using DtPad.Customs;

namespace DtPad.Utils
{
    /// <summary>
    /// Controls util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ControlUtil
    {
        #region Internal Methods

        internal static Control GetFocusedControl(object sender)
        {
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                Control focusedControl = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
                focusedControl.Focus();

                return focusedControl;
            }
            if (sender.GetType() == typeof(TextBox) || sender.GetType() == typeof(CustomTextBox) || sender.GetType() == typeof(RichTextBox) || sender.GetType() == typeof(CustomRichTextBox) || sender.GetType() == typeof(CustomRichTextBoxBase))
            {
                Control focusedControl = (TextBoxBase)sender;
                return focusedControl;
            }

            return null;
        }

        internal static bool FocusedTextBoxCanUndo(object sender)
        {
            if (sender.GetType() == typeof(ContextMenuStrip))
            {
                Control focusedControl = ((ContextMenuStrip)sender).SourceControl;
                focusedControl.Focus();

                if (focusedControl.GetType() == typeof(TextBox) || focusedControl.GetType() == typeof(CustomTextBox))
                {
                    return ((TextBox) focusedControl).CanUndo;
                }
                if (focusedControl.GetType() == typeof(RichTextBox) || focusedControl.GetType() == typeof(CustomRichTextBox))
                {
                    return ((RichTextBox)focusedControl).CanUndo;
                }
            }

            return false;
        }

        #endregion Internal Methods
    }
}
