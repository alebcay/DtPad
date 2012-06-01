using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// GeneralControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class GeneralControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, bool isFormReloading)
        {
            String localized = LanguageUtil.GetCurrentLanguageString(control.Name, formName);
            if (!String.IsNullOrEmpty(localized))
            {
                control.Text = localized;
            }

            if (control.Controls.Count > 0)
            {
                LanguageUtil.CicleControls(formName, control.Controls, isFormReloading);
            }

            if (control.ContextMenuStrip != null)
            {
                LanguageUtil.CicleControls(formName, control.ContextMenuStrip.Items);
            }
        }

        #endregion Internal Methods
    }
}
