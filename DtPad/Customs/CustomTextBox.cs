using System;
using System.Windows.Forms;
using DtPad.Managers;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom TextBox (to use clipboard toggle manager).
    /// </summary>
    /// <author>Marco Macciò</author>
    public class CustomTextBox : TextBox
    {
        internal enum ReturnAction
        {
            InsertCR,
            StartSearch
        }

        #region Internal Instance Fields

        internal ReturnAction ReturnActionType { get; set; }

        #endregion Internal Instance Fields

        #region Protected Methods

        internal CustomTextBox()
        {
            ReturnActionType = ReturnAction.InsertCR;
        }

        protected override void OnEnter(EventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnEnter(e);
                return;
            }

            ClipboardToggleManager.ToggleClipboardOnClick(form, false);
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnLeave(e);
                return;
            }

            ClipboardToggleManager.DisableClipboardOnClick(form);
            base.OnLeave(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnKeyDown(e);
                return;
            }
            
            if (e.Control && e.KeyCode == Keys.X)
            {
                if (!ReadOnly)
                {
                    TextManager.CutControl(this);
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                TextManager.CopyControl(this);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (!ReadOnly)
                {
                    TextManager.PasteControl(this);
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            //else if (e.Control && e.KeyCode == Keys.L)
            //{
            //    TextManager.SelectCurrentLine(form);
            //    e.Handled = true;
            //    e.SuppressKeyPress = true;
            //}
            else if (e.Control && e.KeyCode == Keys.A)
            {
                TextManager.SelectAllControl(this);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if ((e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter) && !e.Shift && !e.Alt && !e.Control)
            {
                switch (ReturnActionType)
                {
                    case ReturnAction.StartSearch:
                        String initialText = Text;
                       
                        SearchManager.SearchNextFactory(form);

                        Text = initialText;
                        Select(TextLength, 0);
                        ScrollToCaret();

                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;

                    default:
                        base.OnKeyDown(e);
                        break;
                }
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            WindowManager.FocusOnRightClick(this, e);
            base.OnMouseDown(e);
        }

        #endregion Protected Methods
    }
}
