﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom RichTextBox (to use clipboard toggle manager and other custom functions).
    /// </summary>
    /// <author>Marco Macciò, Derek Morin, external source</author>
    public class CustomRichTextBox : CustomRichTextBoxBase
    {
        private bool ctrlFlag;
        const uint WM_MOUSEWHEEL = 0x20A;
        //const uint WM_VSCROLL = 0x115;
        //const uint SB_LINEUP = 0;
        //const uint SB_LINEDOWN = 1;

        //[DllImport("user32.dll")]
        //public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        #region Public Instance Fields

        [Category("Behavior"), Browsable(true), DisplayName("CustomInsertMode")]
        public String CustomInsertMode { get; set; }

        /* filenameTabPage
           zoomTabPage
           modifiedTabPage
           originalTabPage
           encodingTabPage
           encodingForcedTabPage */

        //[Category("Behavior"), DisplayName("CustomFileName")]
        //internal String CustomFileName { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("CustomZoom")]
        public int CustomZoom { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("CustomModified")]
        public bool CustomModified { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("CustomOriginal")]
        public String CustomOriginal { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("CustomEncoding")]
        public String CustomEncoding { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("CustomEncodingForced")]
        public bool CustomEncodingForced { get; set; }

        #endregion Public Instance Fields

        #region Internal Instance Fields

        internal bool IsHighlighting { private get; set; }
        internal bool IsUnderlining { private get; set; }
        internal bool IsUndoingRedoing { private get; set; }

        #endregion Public Instance Fields

        #region Suspend-Resume Painting

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, ref Point lParam);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, IntPtr lParam);

        const int WM_USER = 0x400;
        const int WM_SETREDRAW = 0x000B;
        const int EM_GETEVENTMASK = WM_USER + 59;
        const int EM_SETEVENTMASK = WM_USER + 69;
        const int EM_GETSCROLLPOS = WM_USER + 221;
        const int EM_SETSCROLLPOS = WM_USER + 222;

        Point _ScrollPoint;
        bool _Painting = true;
        IntPtr _EventMask;
        int _SuspendIndex;
        int _SuspendLength;

        public void SuspendPainting()
        {
            if (!_Painting)
            {
                return;
            }

            _SuspendIndex = SelectionStart;
            _SuspendLength = SelectionLength;

            SendMessage(Handle, EM_GETSCROLLPOS, 0, ref _ScrollPoint);
            SendMessage(Handle, WM_SETREDRAW, 0, IntPtr.Zero);

            _EventMask = SendMessage(Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
            _Painting = false;
        }

        public void ResumePainting()
        {
            if (_Painting)
            {
                return;
            }

            Select(_SuspendIndex, _SuspendLength);

            SendMessage(Handle, EM_SETSCROLLPOS, 0, ref _ScrollPoint);
            SendMessage(Handle, EM_SETEVENTMASK, 0, _EventMask);
            SendMessage(Handle, WM_SETREDRAW, 1, IntPtr.Zero);

            _Painting = true;
            Invalidate();
        }

        #endregion Suspend-Resume Painting

        #region Protected Methods

        protected override void WndProc(ref Message m)
        {
            switch ((uint)m.Msg)
            {
                case WM_MOUSEWHEEL:
                    Intercept(ref m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
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

            ctrlFlag = false;
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

            ctrlFlag = e.Control;

            if (e.KeyCode == Keys.Enter)
            {
                String result = String.Empty;
                if (form.KeepBulletListOnReturn)
                {
                    result = TextManager.KeepBulletListOnReturn(form);
                }
                if (!String.IsNullOrEmpty(result) || form.KeepInitialSpacesOnReturn)
                {
                    result = TextManager.KeepInitialSpacesOnReturn(form) + result;
                }
                SelectedText = String.Format("{0}{1}", ConstantUtil.newLine, result);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Shift && e.KeyCode == Keys.Tab)
            {
                TextManager.OutdentSelectedLines(form);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                TextManager.IndentSelectedLines(form);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                TextManager.UndoRich(form);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                TextManager.RedoRich(form);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                TextManager.Cut(form);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                TextManager.Copy(form);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                TextManager.Paste(form);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Insert)
            {
                TabManager.InsertMode(form);
                base.OnKeyDown(e);
            }
            else if (e.Control && e.KeyCode == Keys.L)
            {
                TextManager.SelectCurrentLine(form);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (!e.Control && e.Shift && e.KeyCode == Keys.Home)
            {
                TextManager.SelectTillFirstSensibleChar(form);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (!e.Control && !e.Shift && e.KeyCode == Keys.Home)
            {
                TextManager.MoveToFirstSensibleChar(form);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnKeyUp(e);
                return;
            }

            ctrlFlag = false;

            TabManager.TabKeyUp(form);
            base.OnKeyUp(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnMouseUp(e);
                return;
            }

            TabManager.TabKeyUp(form);
            base.OnMouseUp(e);
        }

        protected override void OnLinkClicked(LinkClickedEventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnLinkClicked(e);
                return;
            }
            
            OtherManager.StartProcessBrowser(form, e.LinkText);
            base.OnLinkClicked(e);
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnDragDrop(e);
                return;
            }

            foreach (String fileName in (String[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (Directory.Exists(fileName))
                {
                    form.TabIdentity = FileManager.OpenFile(form, form.TabIdentity, Directory.GetFiles(fileName, "*.*", SearchOption.TopDirectoryOnly));
                }
                else
                {
                    form.TabIdentity = FileManager.OpenFile(form, form.TabIdentity, new[] { fileName });
                }
            }
            base.OnDragDrop(e);
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
            base.OnDragEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            WindowManager.FocusOnRightClick(this, e);
            base.OnMouseDown(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnTextChanged(e);
                return;
            }

            if (!IsUndoingRedoing && RichTextBoxUtil.ContainsUnderlineText(this))
            {
                if (IsUnderlining)
                {
                    IsUnderlining = false;
                }
                else
                {
                    DictionaryManager.ClearTextCorrectness(this);
                }
            }
            if (!IsUndoingRedoing && RichTextBoxUtil.ContainsHighlightText(this))
            {
                if (IsHighlighting)
                {
                    IsHighlighting = false;
                }
                else
                {
                    StringUtil.ClearHighlightsResults(this);
                }
            }

            if (IsUndoingRedoing)
            {
                IsUndoingRedoing = false;
            }

            TabManager.TabTextChange(form);
            TextManager.RefreshUndoRedoExternal(form);
            base.OnTextChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnFontChanged(e);
                return;
            }

            ColumnRulerManager.UpdatePanelFont(form);
            base.OnFontChanged(e);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnFontChanged(e);
                return;
            }

            ColumnRulerManager.UpdatePanelFont(form);
            base.OnFontChanged(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            ctrlFlag = false;

            base.OnLostFocus(e);
        }

        #endregion Protected Methods

        #region Private Methods

        private void Intercept(ref Message m)
        {
            long delta = (long)m.WParam >> 16 & 0xFF;

            if (ctrlFlag)
            {
                if ((delta >> 7) == 1)
                {
                    TabManager.SetZoomFromMouse((Form1)FindForm(), -1);
                }
                else
                {
                    TabManager.SetZoomFromMouse((Form1)FindForm(), 1);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
            //else
            //{
            //    if ((delta >> 7) == 1)
            //    {
            //        SendMessage(m.HWnd, WM_VSCROLL, (IntPtr)SB_LINEDOWN, (IntPtr)0);
            //    }
            //    else
            //    {
            //        SendMessage(m.HWnd, WM_VSCROLL, (IntPtr)SB_LINEUP, (IntPtr)0);
            //    }
            //}
        }

        #endregion Private Methods
    }
}
