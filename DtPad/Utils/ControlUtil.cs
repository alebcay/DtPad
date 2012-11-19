using System.Collections.Generic;
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
                //focusedControl.Focus();

                if (focusedControl.GetType() == typeof(TextBox) || focusedControl.GetType() == typeof(CustomTextBox))
                {
                    return ((TextBox)focusedControl).CanUndo;
                }
                if (focusedControl.GetType() == typeof(RichTextBox) || focusedControl.GetType() == typeof(CustomRichTextBox))
                {
                    return ((RichTextBox)focusedControl).CanUndo;
                }
                //if (focusedControl.GetType() == typeof(ComboBox))
                //{
                //    return ((ComboBox)focusedControl).und;
                //}
            }

            return false;
        }

        internal static bool FocusedControlIsReadonly(object sender)
        {
            if (sender.GetType() == typeof(ContextMenuStrip))
            {
                Control focusedControl = ((ContextMenuStrip)sender).SourceControl;
                //focusedControl.Focus();

                if (focusedControl.GetType() == typeof(TextBox) || focusedControl.GetType() == typeof(CustomTextBox))
                {
                    return ((TextBox)focusedControl).ReadOnly;
                }
                if (focusedControl.GetType() == typeof(RichTextBox) || focusedControl.GetType() == typeof(CustomRichTextBox))
                {
                    return ((RichTextBox)focusedControl).ReadOnly;
                }
            }

            return false;
        }

        internal static void SetContextMenuStrip(Form form, Control control)
        {
            SetContextMenuStrip(form, new[] { control });
        }
        internal static void SetContextMenuStrip(Form form, IEnumerable<Control> controls)
        {
            Form1 form1 = (Form1)form.Owner;

            foreach (Control control in controls)
            {
                if (control is CustomComboBox)
                {
                    ((CustomComboBox)control).CustomContextMenuStrip = form1.commonStandardContextMenuStrip;
                }
                else if (control is CustomNumericUpDown)
                {
                    ((CustomNumericUpDown)control).CustomContextMenuStrip = form1.commonStandardContextMenuStrip;
                }
                else
                {
                    control.ContextMenuStrip = form1.commonStandardContextMenuStrip;
                }
            }

            form1.commonStandardContextMenuStrip.Show();
            form1.commonStandardContextMenuStrip.Close();
        }

        internal static void SetContextMenuStrip(Form1 form, ToolStripComboBox control)
        {
            control.ComboBox.ContextMenuStrip = form.commonStandardContextMenuStrip;

            //form1.commonStandardContextMenuStrip.Show();
            //form1.commonStandardContextMenuStrip.Close();
        }

        internal static void SetContextMenuStrip(UserControl userControl, Control control)
        {
            SetContextMenuStrip(userControl, new[] { control });
        }
        internal static void SetContextMenuStrip(UserControl userControl, IEnumerable<Control> controls)
        {
            Form1 form1 = (Form1)userControl.ParentForm;

            foreach (Control control in controls)
            {
                if (control is CustomComboBox)
                {
                    ((CustomComboBox)control).CustomContextMenuStrip = form1.commonStandardContextMenuStrip;
                }
                else
                {
                    control.ContextMenuStrip = form1.commonStandardContextMenuStrip;
                }
            }

            form1.commonStandardContextMenuStrip.Show();
            form1.commonStandardContextMenuStrip.Close();
        }

        #endregion Internal Methods
    }
}
