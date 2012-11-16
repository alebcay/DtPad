using System;
using System.Windows.Forms;
using DtPad.Customs;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// Custom ComboBoxControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class CustomComboBoxControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName)
        {
            CustomComboBox controlCustomCombo = ((CustomComboBox)control);

            if (controlCustomCombo.CustomContextMenuStrip != null)
            {
                LanguageUtil.CicleControls(formName, controlCustomCombo.CustomContextMenuStrip.Items);
            }

            String items = LanguageUtil.GetCurrentLanguageString(String.Format("{0}Items", controlCustomCombo.Name), formName);
            if (String.IsNullOrEmpty(items))
            {
                return;
            }

            String[] itemsSplitted = items.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < controlCustomCombo.Items.Count; i++)
            {
                controlCustomCombo.Items[i] = itemsSplitted[i];
            }
        }

        #endregion Internal Methods
    }
}
