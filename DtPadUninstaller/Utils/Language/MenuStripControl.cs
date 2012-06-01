using System;
using System.Windows.Forms;

namespace DtPadUninstaller.Utils.Language
{
    /// <summary>
    /// MenuStripControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class MenuStripControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, String culture)
        {
            MenuStrip controlMenu = (MenuStrip)control;
            LanguageUtil.CicleControls(formName, controlMenu.Items, culture);
        }

        #endregion Internal Methods
    }
}
