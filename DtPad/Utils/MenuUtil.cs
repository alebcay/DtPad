using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;

namespace DtPad.Utils
{
    /// <summary>
    /// Menus util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class MenuUtil
    {
        #region Internal Methods

        internal static void SetPageTextBoxContextMenu(Form1 form, IEnumerable<ToolStripMenuItem> items)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            foreach(ToolStripMenuItem item in items)
            {
                item.Enabled = !String.IsNullOrEmpty(pageTextBox.SelectedText);
            }
        }

        #endregion Internal Methods
    }
}
