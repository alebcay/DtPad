using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// ListViewControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ListViewControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName)
        {
            if (control.ContextMenuStrip != null)
            {
                LanguageUtil.CicleControls(formName, control.ContextMenuStrip.Items);
            }
        }

        #endregion Internal Methods
    }
}
