using System;
using System.Windows.Forms;

namespace DtPadUpdater.Utils.Language
{
    /// <summary>
    /// ToolStripMenuItemControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ToolStripMenuItemControl
    {
        #region Internal Methods

        internal static void ManageControl(ToolStripItem item, String formName, String culture)
        {
            ToolStripMenuItem itemMenu = (ToolStripMenuItem)item;

            String localizedText = LanguageUtil.GetCurrentLanguageString(item.Name, formName, culture);
            if (!String.IsNullOrEmpty(localizedText))
            {
                item.Text = localizedText;
            }

            if (itemMenu.DropDownItems.Count > 0)
            {
                LanguageUtil.CicleControls(formName, itemMenu.DropDownItems, culture);
            }
        }

        #endregion Internal Methods
    }
}
