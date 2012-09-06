using System.Collections.Generic;
using System.Windows.Forms;

namespace DtPad.Utils
{
    /// <summary>
    /// Look and feel util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class LookFeelUtil
    {
        internal enum ListViewView
        {
            LargeIcon = 0,
            SmallIcon = 1,
            List = 2,
            Tile = 3
        }

        #region Internal Methods

        internal static void SetLookAndFeel(ContextMenuStrip contextMenuStrip)
        {
            switch (ConfigUtil.GetIntParameter("LookAndFeel"))
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

        internal static void SetLookAndFeel(IEnumerable<ContextMenuStrip> contextMenuStripList)
        {
            foreach (ContextMenuStrip contextMenuStrip in contextMenuStripList)
            {
                switch (ConfigUtil.GetIntParameter("LookAndFeel"))
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
        }

        internal static void SetForm1LookAndFeel(Form1 form, bool firstLoad = false)
        {
            switch (ConfigUtil.GetIntParameter("LookAndFeel"))
            {
                case 0:
                    if (firstLoad)
                    {
                        return;
                    }

                    form.menuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.toolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.searchPanel.searchReplaceToolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.pageContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.trayContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.textBoxContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.searchContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.notePanel.noteToolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.notePanel.noteContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.internalExplorerContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.sessionToolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.calendarPanel.calendarToolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.calendarPanel.calendarContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.calculatorPanel.calculatorToolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.calculatorPanel.textMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.clipboardPanel.clipboardContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.clipboardPanel.clipboardToolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.tabPanel.tabToolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.searchInFilesPanel.searchInFilesToolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.searchInFilesPanel.searchInFilesContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.searchInFilesPanel.textMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.filePanel.fileContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.filePanel.directoryContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.filePanel.toolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;

                    break;
                case 1:
                    form.menuStrip.RenderMode = ToolStripRenderMode.System;
                    form.toolStrip.RenderMode = ToolStripRenderMode.System;
                    form.searchPanel.searchReplaceToolStrip.RenderMode = ToolStripRenderMode.System;
                    form.statusStrip.RenderMode = ToolStripRenderMode.System;
                    form.pageContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.trayContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.textBoxContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.searchContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.notePanel.noteToolStrip.RenderMode = ToolStripRenderMode.System;
                    form.notePanel.noteContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.internalExplorerContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.sessionToolStrip.RenderMode = ToolStripRenderMode.System;
                    form.calendarPanel.calendarToolStrip.RenderMode = ToolStripRenderMode.System;
                    form.calendarPanel.calendarContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.calculatorPanel.calculatorToolStrip.RenderMode = ToolStripRenderMode.System;
                    form.calculatorPanel.textMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.clipboardPanel.clipboardContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.clipboardPanel.clipboardToolStrip.RenderMode = ToolStripRenderMode.System;
                    form.tabPanel.tabToolStrip.RenderMode = ToolStripRenderMode.System;
                    form.searchInFilesPanel.searchInFilesToolStrip.RenderMode = ToolStripRenderMode.System;
                    form.searchInFilesPanel.searchInFilesContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.searchInFilesPanel.textMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.filePanel.fileContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.filePanel.directoryContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.filePanel.toolStrip.RenderMode = ToolStripRenderMode.System;

                    break;
            }
        }

        internal static void SetOptionsLookAndFeel(Options form)
        {
            switch (ConfigUtil.GetIntParameter("LookAndFeel"))
            {
                case 0:
                    form.contentContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.numberContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    break;
                case 1:
                    form.contentContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    form.numberContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                    break;

                default:
                    form.contentContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    form.numberContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    break;
            }
        }

        #endregion Internal Methods
    }
}
