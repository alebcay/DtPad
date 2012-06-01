using System;
using System.Windows.Forms;

namespace DtPadUninstaller.Utils.Language
{
    /// <summary>
    /// TabPageControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TabPageControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, String culture)
        {
            TabPage controlTabPage = (TabPage)control;

            controlTabPage.Text = LanguageUtil.GetCurrentLanguageString(controlTabPage.Name, formName, culture);

            if (controlTabPage.Controls.Count > 0)
            {
                LanguageUtil.CicleControls(formName, controlTabPage.Controls, culture);
            }

            if (controlTabPage.ContextMenuStrip != null)
            {
                LanguageUtil.CicleControls(formName, controlTabPage.ContextMenuStrip.Items, culture);
            }

            String toolTip = LanguageUtil.GetCurrentLanguageString(String.Format("{0}ToolTip", controlTabPage.Name), formName, culture);
            if (!String.IsNullOrEmpty(toolTip))
            {
                controlTabPage.ToolTipText = toolTip;
            }
        }

        #endregion Internal Methods
    }
}
