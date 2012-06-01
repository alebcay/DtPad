using System;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Internal browser DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class InternalBrowser : Form
    {
        #region Window Methods

        internal void InitializeForm(String url)
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);

            DialogResult = DialogResult.Cancel;
            webBrowser.Url = new Uri(url);
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            progressBar.Visible = true;
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            progressBar.Visible = false;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!webBrowser.Url.AbsoluteUri.StartsWith(ConstantUtil.dropboxAuthUrl))
            {
                return;
            }

            //proceedButton.Text = LanguageUtil.GetCurrentLanguageString(String.Format("{0}_Proceed", proceedButton.Name), Name);
            //proceedButton.Image = MessageBoxResource.ok;
            //proceedButton.DialogResult = DialogResult.OK;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion Window Methods
    }
}
