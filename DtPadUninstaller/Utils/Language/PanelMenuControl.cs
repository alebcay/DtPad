using System;
using System.Windows.Forms;

namespace DtPadUninstaller.Utils.Language
{
    /// <summary>
    /// PanelMenuControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class PanelMenuControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, String culture)
        {
            LanguageUtil.CicleControls(formName, control.Controls, culture);
        }

        #endregion Internal Methods
    }
}
