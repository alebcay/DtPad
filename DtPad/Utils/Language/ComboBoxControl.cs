using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// ComboBoxControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ComboBoxControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName)
        {
            if (control.ContextMenuStrip != null)
            {
                LanguageUtil.CicleControls(formName, control.ContextMenuStrip.Items);
            }

            String items = LanguageUtil.GetCurrentLanguageString(String.Format("{0}Items", control.Name), formName);
            if (String.IsNullOrEmpty(items))
            {
                return;
            }

            String[] itemsSplitted = items.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            ComboBox controlCombo = (ComboBox)control;

            for (int i = 0; i < controlCombo.Items.Count; i++)
            {
                controlCombo.Items[i] = itemsSplitted[i];
            }
        }

        #endregion Internal Methods
    }
}
