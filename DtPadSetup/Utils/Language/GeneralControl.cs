using System;
using System.Windows.Forms;

namespace DtPadSetup.Utils.Language
{
    /// <summary>
    /// GeneralControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class GeneralControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, String culture)
        {
            String localized = LanguageUtil.GetCurrentLanguageString(control.Name, formName, culture);
            if (!String.IsNullOrEmpty(localized))
            {
                control.Text = localized;
            }

            if (control.Controls.Count > 0)
            {
                LanguageUtil.CicleControls(formName, control.Controls, culture);
            }

            if (control.ContextMenuStrip != null)
            {
                LanguageUtil.CicleControls(formName, control.ContextMenuStrip.Items, culture);
            }
        }

        #endregion Internal Methods
    }
}
