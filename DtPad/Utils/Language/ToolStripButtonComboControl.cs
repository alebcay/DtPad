using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// ToolStripButtonComboControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ToolStripButtonComboControl
    {
        #region Internal Methods

        internal static void ManageControl(ToolStripItem item, String formName)
        {
            String localizedText = LanguageUtil.GetCurrentLanguageString(item.Name, formName);
            if (!String.IsNullOrEmpty(localizedText))
            {
                item.Text = localizedText;
            }

            localizedText = LanguageUtil.GetCurrentLanguageString(String.Format("{0}ToolTip", item.Name), formName);
            if (!String.IsNullOrEmpty(localizedText))
            {
                item.ToolTipText = localizedText;
            }
        }

        #endregion Internal Methods
    }
}
