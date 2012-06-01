using System.Windows.Forms;

namespace DtHelp.Utils
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
            if (form.office2003ToolStripMenuItem.Checked)
            {
                contextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            }
            else if (form.windowsXPToolStripMenuItem.Checked)
            {
                contextMenuStrip.RenderMode = ToolStripRenderMode.System;
            }
        }

        //internal static void SetLookAndFeel(IEnumerable<ContextMenuStrip> contextMenuStripList)
        //{
        //    foreach (ContextMenuStrip contextMenuStrip in contextMenuStripList)
        //    {
        //        switch ()
        //        {
        //            case 0:
        //                contextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
        //                break;
        //            case 1:
        //                contextMenuStrip.RenderMode = ToolStripRenderMode.System;
        //                break;
        //        }
        //    }
        //}

        #endregion Internal Methods
    }
}
