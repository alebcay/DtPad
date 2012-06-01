using System;
using System.Windows.Forms;

namespace DtPadUpdater.Utils.Language
{
    /// <summary>
    /// ToolStripControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ToolStripControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, String culture)
        {
            ToolStrip controlMenu = (ToolStrip)control;
            LanguageUtil.CicleControls(formName, controlMenu.Items, culture);
        }

        #endregion Internal Methods
    }
}
