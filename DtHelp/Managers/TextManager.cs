using System;
using System.Windows.Forms;
using DtHelp.Customs;

namespace DtHelp.Managers
{
    /// <summary>
    /// Text operations manager (ie. copy, select all).
    /// </summary>
    /// <author>Marco Macciò</author>
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms533049.aspx"/>
    internal static class TextManager
    {
        #region Internal Methods

        internal static void Undo(Form1 form)
        {
            TextBox searchTextBox = form.searchTextBox;

            if (searchTextBox.Focused)
            {
                searchTextBox.Undo();
            }
        }

        internal static void Copy(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            CustomToolStripTextBox urlToolStripTextBox = form.urlToolStripTextBox;
            TextBox searchTextBox = form.searchTextBox;

            if (urlToolStripTextBox.Focused && !String.IsNullOrEmpty(urlToolStripTextBox.SelectedText))
            {
                urlToolStripTextBox.Copy();
            }
            else if (searchTextBox.Focused && !String.IsNullOrEmpty(searchTextBox.SelectedText))
            {
                searchTextBox.Copy();
            }
            else if (helpWebBrowser.Document != null)
            {
                helpWebBrowser.Document.ExecCommand("Copy", false, null);
            }
        }

        internal static void Cut(Form1 form)
        {
            TextBox searchTextBox = form.searchTextBox;

            if (searchTextBox.Focused)
            {
                searchTextBox.Cut();
            }
        }

        internal static void Paste(Form1 form)
        {
            TextBox searchTextBox = form.searchTextBox;

            if (searchTextBox.Focused)
            {
                searchTextBox.Paste();
            }
        }

        internal static void Delete(Form1 form)
        {
            TextBox searchTextBox = form.searchTextBox;

            if (searchTextBox.Focused && !String.IsNullOrEmpty(searchTextBox.SelectedText))
            {
                searchTextBox.SelectedText = String.Empty;
            }
        }

        internal static void SelectAll(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            CustomToolStripTextBox urlToolStripTextBox = form.urlToolStripTextBox;
            TextBox searchTextBox = form.searchTextBox;

            if (urlToolStripTextBox.Focused)
            {
                urlToolStripTextBox.SelectAll();
            }
            else if (searchTextBox.Focused)
            {
                searchTextBox.SelectAll();
            }
            else if (helpWebBrowser.Document != null)
            {
                helpWebBrowser.Document.ExecCommand("SelectAll", false, null);
            }
        }

        internal static void SetClipboardActivities(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            CustomToolStripTextBox urlToolStripTextBox = form.urlToolStripTextBox;
            TextBox searchTextBox = form.searchTextBox;
            ToolStripMenuItem undoToolStripMenuItem1 = form.undoToolStripMenuItem1;
            ToolStripMenuItem cutToolStripMenuItem1 = form.cutToolStripMenuItem1;
            ToolStripMenuItem copyToolStripMenuItem = form.copyToolStripMenuItem;
            ToolStripMenuItem pasteToolStripMenuItem1 = form.pasteToolStripMenuItem1;
            ToolStripMenuItem deleteToolStripMenuItem1 = form.deleteToolStripMenuItem1;
            ToolStripMenuItem selectAllToolStripMenuItem = form.selectAllToolStripMenuItem;

            if (urlToolStripTextBox.Focused || (helpWebBrowser.Document != null && helpWebBrowser.Focused))
            {
                undoToolStripMenuItem1.Enabled = false;
                cutToolStripMenuItem1.Enabled = false;
                copyToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem1.Enabled = false;
                deleteToolStripMenuItem1.Enabled = false;
                selectAllToolStripMenuItem.Enabled = true;
            }
            else if (searchTextBox.Focused)
            {
                undoToolStripMenuItem1.Enabled = true;
                cutToolStripMenuItem1.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem1.Enabled = true;
                deleteToolStripMenuItem1.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
            }
            else
            {
                undoToolStripMenuItem1.Enabled = false;
                cutToolStripMenuItem1.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem1.Enabled = false;
                deleteToolStripMenuItem1.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
            }
        }

        #endregion Internal Methods

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

            if (textBox.SelectionLength > 0)
            {
                textBox.Focus();
                textBox.Cut();
            }
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
