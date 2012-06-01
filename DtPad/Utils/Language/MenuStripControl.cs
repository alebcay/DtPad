using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// MenuStripControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class MenuStripControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName)
        {
            MenuStrip controlMenu = (MenuStrip)control;
            LanguageUtil.CicleControls(formName, controlMenu.Items);
        }

        #endregion Internal Methods
    }
}
