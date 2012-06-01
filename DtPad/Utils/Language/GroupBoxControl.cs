using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// GroupBoxControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class GroupBoxControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, bool isFormReloading)
        {
            control.Text = LanguageUtil.GetCurrentLanguageString(control.Name, formName);
            LanguageUtil.CicleControls(formName, control.Controls, isFormReloading);
        }

        #endregion Internal Methods
    }
}
