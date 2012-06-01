using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Translation manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class InternetServicesManager
    {
        private const String className = "InternetServicesManager";

        internal enum SearchProvider
        {
            Google,
            Wikipedia
        }

        #region Internal Methods

        internal static void ShowGoogleTranslation(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (String.IsNullOrEmpty(pageTextBox.SelectedText))
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoTextSelected", className));
                return;
            }
            
            if (!ConfigUtil.GetBoolParameter("TranslationUseSelect"))
            {
                if (WindowManager.ShowTranslateText(form) == DialogResult.Cancel)
                {
                    return;
                }
            }

            String languagePair = ConfigUtil.GetStringParameter("Translation");
            bool success;
            String result = TranslateText(form, languagePair, out success);

            if (success)
            {
                WindowManager.ShowContent(form, result);
            }
        }

        internal static void SearchTextInGoogle(Form1 form, SearchProvider provider)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (String.IsNullOrEmpty(pageTextBox.SelectedText))
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoTextSelected", className));
                return;
            }

            MakeSearch(form, provider, pageTextBox.SelectedText.Replace(" ", "+"));
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Translate text using Google Translate
        /// </summary>
        /// <param name="form">Form1</param>
        /// <param name="languagePair">Language pair (ie. "en|it")</param>
        /// <param name="success">Successfull operation flag</param>
        /// <returns>Translated string</returns>
        private static String TranslateText(Form1 form, String languagePair, out bool success)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            success = true;
            String input = pageTextBox.SelectedText.Replace(ConstantUtil.newLine, " ");
            //String url = String.Format("http://www.google.{0}/translate_t?hl=en&ie=UTF8&text={1}&langpair={2}", LanguageUtil.GetDomainExtension(), input, languagePair);
            //String url = String.Format("http://translate.google.com/#{0}|{1}", languagePair, Uri.EscapeDataString(input));
            String url = String.Format("http://translate.google.com/?sl={0}&tl={1}&q={2}", languagePair.Substring(0, 2), languagePair.Substring(3, 2), Uri.EscapeDataString(input));
            String result;

            WebClient webClient = null;
            //webClient.Encoding = FileManager.GetTabTextEncoding(pageTextBox.CustomEncoding);

            try
            {
                webClient = ProxyUtil.InitWebClientProxy();
                result = webClient.DownloadString(url);
            }
            catch (Exception)
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("Error", className));
                success = false;
                return input;
            }
            finally
            {
                if (webClient != null)
                {
                    webClient.Dispose();
                }
            }

            int startIndex = result.IndexOf(">", result.IndexOf("<span", result.IndexOf("id=result_box"))) + 1;
            int endIndex = result.IndexOf("<", startIndex);

            String returnValue = result.Substring(startIndex, endIndex - startIndex);

            while (result.IndexOf("<span", endIndex) < result.IndexOf("<div", endIndex))
            {
                startIndex = result.IndexOf(">", result.IndexOf("<span", endIndex)) + 1;
                endIndex = result.IndexOf("<", startIndex);

                returnValue += result.Substring(startIndex, endIndex - startIndex);
            }

            //=== Method 1
            //foreach (KeyValuePair<String, String> keyValuePair in ConstantUtil.HtmlCharSet)
            //{
            //    returnValue = returnValue.Replace(keyValuePair.Key, keyValuePair.Value);
            //}
            //return ConstantUtil.HtmlCharSet.Aggregate(returnValue, (current, keyValuePair) => current.Replace(keyValuePair.Key, keyValuePair.Value));

            //=== Method 2
            //foreach (KeyValuePair<String, String> keyValuePair in ConstantUtil.HtmlTags)
            //{
            //    returnValue = returnValue.Replace(keyValuePair.Value, keyValuePair.Key);
            //}
            //foreach (KeyValuePair<String, String> keyValuePair in ConstantUtil.HtmlTagsNumbers)
            //{
            //    returnValue = returnValue.Replace(keyValuePair.Value, keyValuePair.Key);
            //}
            returnValue = ConstantUtil.HtmlTags.Aggregate(returnValue, (current, keyValuePair) => current.Replace(keyValuePair.Value, keyValuePair.Key));
            return ConstantUtil.HtmlTagsNumbers.Aggregate(returnValue, (current, keyValuePair) => current.Replace(keyValuePair.Value, keyValuePair.Key));
        }

        private static void MakeSearch(Form1 form, SearchProvider provider, String search)
        {
            switch (provider)
            {
                case SearchProvider.Google:
                    OtherManager.StartProcessBrowser(form, String.Format("http://www.google.{0}/search?as_q={1}", LanguageUtil.GetDomainExtension(), search));
                    break;
                case SearchProvider.Wikipedia:
                    OtherManager.StartProcessBrowser(form, String.Format("http://{0}.wikipedia.org/w/index.php?search={1}", LanguageUtil.GetReallyShortCulture(), search));
                    break;
            }
        }

        #endregion Private Methods
    }
}
