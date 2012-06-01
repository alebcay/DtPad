using System.Windows.Forms;

namespace DtPadSetup.Utils
{
    /// <summary>
    /// Look and feel util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class LookFeelUtil
    {
        #region Internal Methods

        internal static void SetLookAndFeel(Form1 form, ContextMenuStrip contextMenuStrip)
        {
            if (form.dotNetRadioButton.Checked)
            {
                contextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            }
            else if (form.windowsRadioButton.Checked)
            {
                contextMenuStrip.RenderMode = ToolStripRenderMode.System;
            }
        }

        #endregion Internal Methods
    }
}
