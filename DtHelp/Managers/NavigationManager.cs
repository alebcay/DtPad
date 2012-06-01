using System;
using System.Windows.Forms;

namespace DtHelp.Managers
{
    /// <summary>
    /// Browser navigation manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class NavigationManager
    {
        #region Internal Methods

        internal static void InitLoadingBar(Form1 form)
        {
            ToolStripProgressBar helpBrowserToolStripProgressBar = form.helpBrowserToolStripProgressBar;
            ToolStripTextBox urlToolStripTextBox = form.urlToolStripTextBox;

            if (!urlToolStripTextBox.Text.Contains("#"))
            {
                helpBrowserToolStripProgressBar.Visible = true;
            }
        }

        internal static void ProgressLoadingBar(Form1 form, WebBrowserProgressChangedEventArgs e)
        {
            ToolStripProgressBar helpBrowserToolStripProgressBar = form.helpBrowserToolStripProgressBar;

            helpBrowserToolStripProgressBar.Maximum = Convert.ToInt32(e.MaximumProgress);
            helpBrowserToolStripProgressBar.Value = Convert.ToInt32(e.CurrentProgress);
        }

        internal static void CloseLoadingBar(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            ToolStripTextBox urlToolStripTextBox = form.urlToolStripTextBox;
            ToolStripProgressBar helpBrowserToolStripProgressBar = form.helpBrowserToolStripProgressBar;

            helpBrowserToolStripProgressBar.Visible = false;
            urlToolStripTextBox.Text = helpWebBrowser.Url.ToString();
        }

        #endregion Internal Methods
    }
}
