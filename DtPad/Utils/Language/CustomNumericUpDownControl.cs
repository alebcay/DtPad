using System;
using System.Windows.Forms;
using DtPad.Customs;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// CustomNumericUpDownControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class CustomNumericUpDownControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName)
        {
            CustomNumericUpDown controlCustomNumeric = ((CustomNumericUpDown)control);

            if (controlCustomNumeric.CustomContextMenuStrip != null)
            {
                LanguageUtil.CicleControls(formName, controlCustomNumeric.CustomContextMenuStrip.Items);
            }
        }

        #endregion Internal Methods
    }
}
