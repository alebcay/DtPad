using System;
using System.Windows.Forms;

namespace DtHelp.Managers
{
    internal static class HistoryManager
    {
        #region Internal Methods

        internal static void GoBack(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            ToolStripButton goBackToolStripButton = form.goBackToolStripButton;
            ToolStripMenuItem goBackToolStripMenuItem = form.goBackToolStripMenuItem;
            ToolStripMenuItem goBackToolStripMenuItem1 = form.goBackToolStripMenuItem1;
            
            helpWebBrowser.GoBack();
            goBackToolStripButton.Enabled = helpWebBrowser.CanGoBack;
            goBackToolStripMenuItem.Enabled = helpWebBrowser.CanGoBack;
            goBackToolStripMenuItem1.Enabled = helpWebBrowser.CanGoBack;
        }

        internal static void GoForward(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            ToolStripButton goForwardToolStripButton = form.goForwardToolStripButton;
            ToolStripMenuItem goForwardToolStripMenuItem = form.goForwardToolStripMenuItem;
            ToolStripMenuItem goForwardToolStripMenuItem1 = form.goForwardToolStripMenuItem1;

            helpWebBrowser.GoForward();
            goForwardToolStripButton.Enabled = helpWebBrowser.CanGoForward;
            goForwardToolStripMenuItem.Enabled = helpWebBrowser.CanGoForward;
            goForwardToolStripMenuItem1.Enabled = helpWebBrowser.CanGoForward;
        }

        internal static void GoHome(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            String home = form.Home;

            helpWebBrowser.Url = new Uri(home);
        }

        internal static void InitGoBack(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            ToolStripButton goBackToolStripButton = form.goBackToolStripButton;
            ToolStripMenuItem goBackToolStripMenuItem = form.goBackToolStripMenuItem;
            ToolStripMenuItem goBackToolStripMenuItem1 = form.goBackToolStripMenuItem1;

            goBackToolStripButton.Enabled = helpWebBrowser.CanGoBack;
            goBackToolStripMenuItem.Enabled = helpWebBrowser.CanGoBack;
            goBackToolStripMenuItem1.Enabled = helpWebBrowser.CanGoBack;
        }

        internal static void InitGoForward(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            ToolStripButton goForwardToolStripButton = form.goForwardToolStripButton;
            ToolStripMenuItem goForwardToolStripMenuItem = form.goForwardToolStripMenuItem;
            ToolStripMenuItem goForwardToolStripMenuItem1 = form.goForwardToolStripMenuItem1;

            goForwardToolStripButton.Enabled = helpWebBrowser.CanGoForward;
            goForwardToolStripMenuItem.Enabled = helpWebBrowser.CanGoForward;
            goForwardToolStripMenuItem1.Enabled = helpWebBrowser.CanGoForward;
        }

        internal static void Clear(Form1 form)
        {
            ToolStripTextBox urlToolStripTextBox = form.urlToolStripTextBox;

            String previuosUrl = urlToolStripTextBox.Text;
            GuideManager.ReplaceHelpWebBrowser(form);

            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            helpWebBrowser.Url = new Uri(previuosUrl);
        }

        #endregion Internal Methods
    }
}
