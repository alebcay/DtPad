using System;
using System.Windows.Forms;

namespace DtHelp.Utils.Language
{
    /// <summary>
    /// GroupBoxControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class GroupBoxControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, String culture)
        {
            control.Text = LanguageUtil.GetCurrentLanguageString(control.Name, formName, culture);
            LanguageUtil.CicleControls(formName, control.Controls, culture);
        }

        #endregion Internal Methods
    }
}
