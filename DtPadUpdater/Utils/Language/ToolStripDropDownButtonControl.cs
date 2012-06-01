using System;
using System.Windows.Forms;

namespace DtPadUpdater.Utils.Language
{
    /// <summary>
    /// ToolStripDropDownButtonControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ToolStripDropDownButtonControl
    {
        #region Internal Methods

        internal static void ManageControl(ToolStripItem item, String formName, String culture)
        {
            ToolStripDropDownButton itemDropDownButton = (ToolStripDropDownButton)item;

            String localizedText = LanguageUtil.GetCurrentLanguageString(itemDropDownButton.Name, formName, culture);
            if (!String.IsNullOrEmpty(localizedText))
            {
                itemDropDownButton.Text = localizedText;
            }

            localizedText = LanguageUtil.GetCurrentLanguageString(String.Format("{0}ToolTip", itemDropDownButton.Name), formName, culture);
            if (!String.IsNullOrEmpty(localizedText))
            {
                itemDropDownButton.ToolTipText = localizedText;
            }

            if (itemDropDownButton.HasDropDownItems)
            {
                LanguageUtil.CicleControls(formName, itemDropDownButton.DropDownItems, culture);
            }
        }

        #endregion Internal Methods
    }
}
