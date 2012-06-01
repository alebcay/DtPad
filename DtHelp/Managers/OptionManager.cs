using System;
using System.Windows.Forms;

namespace DtHelp.Managers
{
    /// <summary>
    /// Options manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class OptionManager
    {
        #region Internal Methods

        internal static void SwitchRenderMode(Form1 form, object sender)
        {
            ToolStripMenuItem office2003ToolStripMenuItem = form.office2003ToolStripMenuItem;
            ToolStripMenuItem windowsXPToolStripMenuItem = form.windowsXPToolStripMenuItem;
            ToolStrip toolStrip = form.toolStrip;
            ContextMenuStrip browserContextMenuStrip = form.browserContextMenuStrip;
            MenuStrip menuStrip = form.menuStrip;
            ContextMenuStrip urlContextMenuStrip = form.urlContextMenuStrip;
            ContextMenuStrip textContextMenuStrip = form.textContextMenuStrip;

            if (sender == office2003ToolStripMenuItem)
            {
                office2003ToolStripMenuItem.Checked = true;
                windowsXPToolStripMenuItem.Checked = false;
                
                toolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                browserContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                menuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                urlContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                textContextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            }
            else if (sender == windowsXPToolStripMenuItem)
            {
                office2003ToolStripMenuItem.Checked = false;
                windowsXPToolStripMenuItem.Checked = true;
                
                toolStrip.RenderMode = ToolStripRenderMode.System;
                browserContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                menuStrip.RenderMode = ToolStripRenderMode.System;
                urlContextMenuStrip.RenderMode = ToolStripRenderMode.System;
                textContextMenuStrip.RenderMode = ToolStripRenderMode.System;
            }

            form.Refresh();
        }

        internal static void SetEnglish(Form1 form)
        {
            ToolStripMenuItem italianoToolStripMenuItem = form.italianoToolStripMenuItem;
            ToolStripMenuItem englishToolStripMenuItem = form.englishToolStripMenuItem;

            if (!italianoToolStripMenuItem.Checked)
            {
                return;
            }

            italianoToolStripMenuItem.Checked = false;
            englishToolStripMenuItem.Checked = true;
        }

        internal static void SetItaliano(Form1 form)
        {
            ToolStripMenuItem italianoToolStripMenuItem = form.italianoToolStripMenuItem;
            ToolStripMenuItem englishToolStripMenuItem = form.englishToolStripMenuItem;

            if (!englishToolStripMenuItem.Checked)
            {
                return;
            }

            englishToolStripMenuItem.Checked = false;
            italianoToolStripMenuItem.Checked = true;
        }

        internal static String GetLanguage(Form1 form)
        {
            ToolStripMenuItem italianoToolStripMenuItem = form.italianoToolStripMenuItem;
            //ToolStripMenuItem englishToolStripMenuItem = form.englishToolStripMenuItem;

            return italianoToolStripMenuItem.Checked ? "it" : "en";
        }

        #endregion Internal Methods
    }
}
