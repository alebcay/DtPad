using System;
using System.Windows.Forms;

namespace DtHelp.Utils.Language
{
    /// <summary>
    /// ComboBoxControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ComboBoxControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, String culture)
        {
            String items = LanguageUtil.GetCurrentLanguageString(String.Format("{0}Items", control.Name), formName, culture);
            String[] split = { Environment.NewLine };
            String[] itemsSplitted = items.Split(split, StringSplitOptions.None);

            ComboBox controlCombo = (ComboBox)control;

            for (int i = 0; i < controlCombo.Items.Count; i++)
            {
                controlCombo.Items[i] = itemsSplitted[i];
            }
        }

        #endregion Internal Methods
    }
}
