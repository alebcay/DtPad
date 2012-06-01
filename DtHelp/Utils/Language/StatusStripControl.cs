using System;
using System.Windows.Forms;

namespace DtHelp.Utils.Language
{
    /// <summary>
    /// StatusStripControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class StatusStripControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, String culture)
        {
            StatusStrip controlMenu = (StatusStrip)control;
            LanguageUtil.CicleControls(formName, controlMenu.Items, culture);
        }

        #endregion Internal Methods
    }
}
