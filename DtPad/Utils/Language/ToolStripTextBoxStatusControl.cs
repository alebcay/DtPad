using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// ToolStripTextBoxStatusControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ToolStripTextBoxStatusControl
    {
        #region Internal Methods

        internal static void ManageControl(ToolStripItem item, String formName)
        {
            String localizedText = LanguageUtil.GetCurrentLanguageString(item.Name, formName);
            if (!String.IsNullOrEmpty(localizedText))
            {
                item.Text = localizedText;
            }
        }

        #endregion Internal Methods
    }
}
