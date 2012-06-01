using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// TabPageControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TabPageControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, bool isFormReloading)
        {
            TabPage controlTabPage = (TabPage)control;

            controlTabPage.Text = LanguageUtil.GetCurrentLanguageString(controlTabPage.Name, formName);

            if (controlTabPage.Controls.Count > 0)
            {
                LanguageUtil.CicleControls(formName, controlTabPage.Controls, isFormReloading);
            }

            if (controlTabPage.ContextMenuStrip != null)
            {
                LanguageUtil.CicleControls(formName, controlTabPage.ContextMenuStrip.Items);
            }

            String toolTip = LanguageUtil.GetCurrentLanguageString(String.Format("{0}ToolTip", controlTabPage.Name), formName);
            if (!String.IsNullOrEmpty(toolTip))
            {
                controlTabPage.ToolTipText = toolTip;
            }
        }

        #endregion Internal Methods
    }
}
