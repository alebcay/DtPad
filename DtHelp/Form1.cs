using System;
using System.Globalization;
using System.Windows.Forms;
using DtHelp.Managers;
using DtHelp.Utils;

namespace DtHelp
{
    /// <summary>
    /// Main DtHelp form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Form1 : Form
    {
        private String guidePath;

        internal Form1(String[] args)
        {
            InitializeComponent();
            InitializeForm(args);
            SetLanguage(false);

            SetFamilyEdition();
        }

        #region Internal Instance Fields

        internal String Home { get; set; }

        internal String GuidePath
        {
            set { guidePath = value; }
        }

        #endregion Internal Instance Fields

        #region Window Methods

        private void InitializeForm(String[] args)
        {
            if (urlToolStripTextBox.TextBox != null)
            {
                urlToolStripTextBox.TextBox.ContextMenuStrip = urlContextMenuStrip;
            }
            
            helpWebBrowser.StatusTextChanged += helpWebBrowser_StatusTextChanged;
            
            switch (args.Length)
            {
                case 1:
                    GuideManager.ReadHelpGuide(this, args[0]);
                    break;
                default:
                    WindowManager.DisableInterface(this);
                    break;
            }

            HistoryManager.InitGoBack(this);
            HistoryManager.InitGoForward(this);

            office2003ToolStripMenuItem.Checked = true;
            searchPanel.Visible = false;

            if (helpWebBrowser.IsOffline)
            {
                connectionStatusToolStripStatusLabel.Image = ToolbarResource.disconnect;
                String text = LanguageUtil.GetCurrentLanguageString("connectionStatus_Disconnected", Name, OptionManager.GetLanguage(this));
                connectionStatusToolStripStatusLabel.Text = text;
                connectionStatusToolStripStatusLabel.ToolTipText = text;
            }
            else
            {
                connectionStatusToolStripStatusLabel.Image = ToolbarResource.connect;
                String text = LanguageUtil.GetCurrentLanguageString("connectionStatus_Connected", Name, OptionManager.GetLanguage(this));
                connectionStatusToolStripStatusLabel.Text = text;
                connectionStatusToolStripStatusLabel.ToolTipText = text;
            }

            switch (LanguageUtil.GetReallyShortCulture(CultureInfo.CurrentCulture.Name))
            {
                case "en":
                    englishToolStripMenuItem.Checked = true;
                    break;
                case "it":
                    italianoToolStripMenuItem.Checked = true;
                    break;
                default:
                    englishToolStripMenuItem.Checked = true;
                    break;
            }
        }

        internal void helpWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            HistoryManager.InitGoBack(this);
            HistoryManager.InitGoForward(this);
            NavigationManager.InitLoadingBar(this);

            if (String.IsNullOrEmpty(urlToolStripTextBox.Text))
            {
                return;
            }

            GuideManager.SelectNodePageFromNavigatedUrl(this, e.Url, guidePath);
        }

        internal void helpWebBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            NavigationManager.ProgressLoadingBar(this, e);
        }

        internal void helpWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            NavigationManager.CloseLoadingBar(this);
        }

        internal void helpWebBrowser_StatusTextChanged(object sender, EventArgs e)
        {
            browserStatusToolStripStatusLabel.Text = helpWebBrowser.StatusText;
        }

        private void indexTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GuideManager.ReadSelectedNodePage(this, guidePath);
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            TextManager.SetClipboardActivities(this);
        }

        #endregion Window Methods

        #region Menu Methods

        private void openGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.OpenGuide(this);
        }

        private void savePageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowSaveAs(this);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuideManager.CloseGuide(this, false);
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowPageSetup(this);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowPrintPreview(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowPrint(this);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowProperties(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.Undo(this);
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.Cut(this);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.Copy(this);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.Paste(this);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.Delete(this);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAll(this);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ToggleSearchPanel(this);
        }

        private void expandSelectedNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuideManager.Expand(this, false);
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuideManager.Expand(this, true);
        }

        private void collapseSelectedNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuideManager.Collapse(this, false);
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuideManager.Collapse(this, true);
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryManager.GoBack(this);
        }

        private void goForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryManager.GoForward(this);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryManager.Clear(this);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpWebBrowser.Refresh();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryManager.GoHome(this);
        }

        private void office2003ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionManager.SwitchRenderMode(this, sender);
        }

        private void windowsXPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionManager.SwitchRenderMode(this, sender);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionManager.SetEnglish(this);
            SetLanguage(true);
        }

        private void italianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionManager.SetItaliano(this);
            SetLanguage(true);
        }

        private void licenseAgreementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherManager.StartProcess(this, "License.txt", OptionManager.GetLanguage(this));
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowReportBug(this, OptionManager.GetLanguage(this));
        }

        private void diarioDiUnTraduttoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherManager.StartProcess(this, ConstantUtil.dtURL, OptionManager.GetLanguage(this));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.ShowAbout(this, OptionManager.GetLanguage(this));
        }

        #endregion Menu Methods

        #region Toolbar Methods

        private void goBackToolStripButton_Click(object sender, EventArgs e)
        {
            HistoryManager.GoBack(this);
        }

        private void goForwardToolStripButton_Click(object sender, EventArgs e)
        {
            HistoryManager.GoForward(this);
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            helpWebBrowser.Refresh();
        }

        private void homeToolStripButton_Click(object sender, EventArgs e)
        {
            HistoryManager.GoHome(this);
        }

        private void openGuideToolStripButton_Click(object sender, EventArgs e)
        {
            FileManager.OpenGuide(this);
        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.ToggleSearchPanel(this);
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.ShowPrint(this);
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            WindowManager.ShowAbout(this, OptionManager.GetLanguage(this));
        }

        #endregion Toolbar Methods

        #region Browser Context Methods

        private void goBackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HistoryManager.GoBack(this);
        }

        private void goForwardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HistoryManager.GoForward(this);
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.Copy(this);
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextManager.SelectAll(this);
        }

        #endregion Browser Context Methods

        #region URL Context Methods

        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextManager.Copy(this);
        }

        private void selectAllToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TextManager.SelectAll(this);
        }

        #endregion URL Context Methods

        #region Text Context Methods

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.Undo(this);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.Cut(this);
        }

        private void copyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            TextManager.Copy(this);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.Paste(this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.Delete(this);
        }

        private void selectAllToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            TextManager.SelectAll(this);
        }

        #endregion Text Context Methods

        #region Search Bar Methods

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchManager.Search(this);
        }

        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchManager.Search(this);
            }
        }

        #endregion Search Bar Methods

        #region Private Methods

        private void SetLanguage(bool isFormReloading)
        {
            LanguageUtil.SetCurrentLanguage(this, OptionManager.GetLanguage(this), isFormReloading);
            LanguageUtil.CicleControls(Name, browserContextMenuStrip.Items, OptionManager.GetLanguage(this));
            LanguageUtil.CicleControls(Name, urlContextMenuStrip.Items, OptionManager.GetLanguage(this));
            Width = Width + 1;
            Width = Width - 1;
        }

        private void SetFamilyEdition()
        {
            #if ReleaseFE
                diarioDiUnTraduttoreToolStripMenuItem.Visible = false;
            #endif
        }

        #endregion Private Methods
    }
}
