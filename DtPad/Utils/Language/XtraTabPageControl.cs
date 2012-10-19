using System;
using System.Windows.Forms;
using DevExpress.XtraTab;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// XtraTabPageControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class XtraTabPageControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, bool isFormReloading)
        {
            XtraTabPage controlTabPage = (XtraTabPage)control;

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
            if (!String.IsNullOrEmpty(toolTip)) // && !isFormReloading)
            {
                controlTabPage.Tooltip = toolTip;
            }
        }

        #endregion Internal Methods
    }
}
