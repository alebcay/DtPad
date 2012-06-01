using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// ToolStripSplitButtonControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ToolStripSplitButtonControl
    {
        #region Internal Methods

        internal static void ManageControl(ToolStripItem item, String formName)
        {
            ToolStripSplitButton itemStripButton = (ToolStripSplitButton)item;

            String localizedText = LanguageUtil.GetCurrentLanguageString(itemStripButton.Name, formName);
            if (!String.IsNullOrEmpty(localizedText))
            {
                itemStripButton.Text = localizedText;
            }

            localizedText = LanguageUtil.GetCurrentLanguageString(String.Format("{0}ToolTip", itemStripButton.Name), formName);
            if (!String.IsNullOrEmpty(localizedText))
            {
                itemStripButton.ToolTipText = localizedText;
            }

            if (itemStripButton.HasDropDownItems)
            {
                LanguageUtil.CicleControls(formName, itemStripButton.DropDownItems);
            }
        }

        #endregion Internal Methods
    }
}
