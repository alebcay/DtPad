using System.Windows.Forms;

namespace DtPadSetup.Utils
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

            return null;
        }

        internal static bool FocusedTextBoxCanUndo(object sender)
        {
            if (sender.GetType() == typeof(ContextMenuStrip))
            {
                Control focusedControl = ((ContextMenuStrip)sender).SourceControl;
                focusedControl.Focus();

                if (focusedControl.GetType() == typeof(TextBox))
                {
                    return ((TextBox)focusedControl).CanUndo;
                }
                if (focusedControl.GetType() == typeof(RichTextBox))
                {
                    return ((RichTextBox)focusedControl).CanUndo;
                }
            }

            return false;
        }

        #endregion Internal Methods
    }
}
