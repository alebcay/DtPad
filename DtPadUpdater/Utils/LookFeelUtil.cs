using System;
using System.Windows.Forms;

namespace DtPadUpdater.Utils
{
    /// <summary>
    /// Look and feel util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class LookFeelUtil
    {
        #region Internal Methods

        internal static void SetLookAndFeel(ContextMenuStrip contextMenuStrip, String executablePath)
        {
            switch (ConfigUtil.GetIntParameter("LookAndFeel", 0, executablePath))
            {
                case 0:
                    contextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    break;
                case 1:
                    contextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    break;

                default:
                    contextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    break;
            }
        }

        #endregion Internal Methods
    }
}
