using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using DtHelp.MessageBoxes;
using DtHelp.Utils;

namespace DtHelp.Managers
{
    /// <summary>
    /// Window operations manager (ie. open new windows).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class WindowManager
    {
        private const String className = "WindowManager";

        #region Close Methods

        internal static void HiddenForm(Form form)
        {
            form.Dispose();
        }

        #endregion Close Methods

        #region Show Methods

        internal static void ShowReportBug(Form form, String culture)
        {
            ReportBug reportBugWindow = new ReportBug();

            reportBugWindow.Owner = form;
            reportBugWindow.InitializeForm(culture);
            reportBugWindow.ShowDialog(form);
        }

        internal static void ShowAbout(Form form, String culture)
        {
            About aboutWindow = new About();

            aboutWindow.Owner = form;
            aboutWindow.InitializeForm(culture);
            aboutWindow.ShowDialog(form);
        }

        internal static void ShowAlertBox(Form form, String alertMessage, String culture)
        {
            AlertO errorBox = new AlertO(form, alertMessage, culture);
            errorBox.ShowDialog(form);
        }

        internal static DialogResult ShowErrorBox(Form form, String errorMessage, Exception exception, String culture)
        {
            LogUtil log = new LogUtil(MethodBase.GetCurrentMethod());
            log.errorLog(errorMessage, exception);

            ErrorOR errorBox = new ErrorOR(form, LanguageUtil.GetCurrentLanguageString("Exception", className, culture) + " " + Environment.NewLine + errorMessage + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("CommandExecution", className, culture), exception, culture);
            return errorBox.ShowDialog(form);
        }

        internal static DialogResult ShowErrorProgramBox(Form form, String errorMessage, Exception exception)
        {
            LogUtil log = new LogUtil(MethodBase.GetCurrentMethod());
            log.fatalLog(errorMessage, exception);
            
            String culture = LanguageUtil.GetReallyShortCulture(CultureInfo.CurrentCulture.Name);

            ErrorO errorBox = new ErrorO(form, LanguageUtil.GetCurrentLanguageString("FatalException", className, culture) + " " + Environment.NewLine + errorMessage + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("ProgramExecution", className, culture), exception, culture);
            return errorBox.ShowDialog(form);
        }

        internal static void ShowSaveAs(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;

            helpWebBrowser.ShowSaveAsDialog();
        }

        internal static void ShowPageSetup(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;

            helpWebBrowser.ShowPageSetupDialog();
        }

        internal static void ShowPrintPreview(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;

            helpWebBrowser.ShowPrintPreviewDialog();
        }

        internal static void ShowPrint(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;

            helpWebBrowser.ShowPrintDialog();
        }

        internal static void ShowProperties(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;

            helpWebBrowser.ShowPropertiesDialog();
        }

        #endregion Show Methods

        #region Other Methods

        internal static void DisableInterface(Form1 form)
        {
            SetInterface(form, false);
        }

        internal static void EnableInterface(Form1 form)
        {
            SetInterface(form, true);
        }

        internal static void ToggleSearchPanel(Form1 form)
        {
            Panel searchPanel = form.searchPanel;
            ToolStripMenuItem searchToolStripMenuItem = form.searchToolStripMenuItem;
            ToolStripButton searchToolStripButton = form.searchToolStripButton;
            TextBox searchTextBox = form.searchTextBox;

            searchPanel.Visible = !searchPanel.Visible;
            searchToolStripMenuItem.Checked = searchPanel.Visible;
            searchToolStripButton.Checked = searchPanel.Visible;
            searchTextBox.Focus();
        }

        #endregion Other Methods

        #region Private Methods

        private static void SetInterface(Form1 form, bool enabled)
        {
            ToolStripButton homeToolStripButton = form.homeToolStripButton;
            ToolStripMenuItem homeToolStripMenuItem = form.homeToolStripMenuItem;
            ToolStripButton printToolStripButton = form.printToolStripButton;
            ToolStripMenuItem saveAsToolStripMenuItem = form.saveAsToolStripMenuItem;
            ToolStripMenuItem pageSetupToolStripMenuItem = form.pageSetupToolStripMenuItem;
            ToolStripMenuItem printPreviewToolStripMenuItem = form.printPreviewToolStripMenuItem;
            ToolStripMenuItem printToolStripMenuItem = form.printToolStripMenuItem;
            ToolStripMenuItem propertiesToolStripMenuItem = form.propertiesToolStripMenuItem;
            ToolStripButton refreshToolStripButton = form.refreshToolStripButton;
            ToolStripMenuItem refreshToolStripMenuItem = form.refreshToolStripMenuItem;
            ToolStripMenuItem expandAllToolStripMenuItem = form.expandAllToolStripMenuItem;
            ToolStripMenuItem collapseAllToolStripMenuItem = form.collapseAllToolStripMenuItem;
            ToolStripMenuItem expandSelectedNodeToolStripMenuItem = form.expandSelectedNodeToolStripMenuItem;
            ToolStripMenuItem collapseSelectedNodeToolStripMenuItem = form.collapseSelectedNodeToolStripMenuItem;
            ToolStripMenuItem closeToolStripMenuItem = form.closeToolStripMenuItem;
            ToolStripMenuItem clearToolStripMenuItem = form.clearToolStripMenuItem;

            homeToolStripButton.Enabled = enabled;
            homeToolStripMenuItem.Enabled = enabled;
            printToolStripButton.Enabled = enabled;
            saveAsToolStripMenuItem.Enabled = enabled;
            pageSetupToolStripMenuItem.Enabled = enabled;
            printPreviewToolStripMenuItem.Enabled = enabled;
            printToolStripMenuItem.Enabled = enabled;
            propertiesToolStripMenuItem.Enabled = enabled;
            refreshToolStripButton.Enabled = enabled;
            refreshToolStripMenuItem.Enabled = enabled;
            expandAllToolStripMenuItem.Enabled = enabled;
            collapseAllToolStripMenuItem.Enabled = enabled;
            expandSelectedNodeToolStripMenuItem.Enabled = enabled;
            collapseSelectedNodeToolStripMenuItem.Enabled = enabled;
            closeToolStripMenuItem.Enabled = enabled;
            clearToolStripMenuItem.Enabled = enabled;
        }

        #endregion Private Methods
    }
}
