using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// PanelMenuControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class PanelMenuControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, bool isFormReloading)
        {
            LanguageUtil.CicleControls(formName, control.Controls, isFormReloading);
        }

        #endregion Internal Methods
    }
}
