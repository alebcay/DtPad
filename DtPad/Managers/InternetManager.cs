using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Utils;
using DtPad.Validators;

namespace DtPad.Managers
{
    /// <summary>
    /// Internet functions manager (ie. cache).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class InternetManager
    {
        private const String className = "InternetManager";

        #region Internal Methods

        internal static void ShowFileInBrowser(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            if (String.IsNullOrEmpty(ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Text))
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoContent", className));
                return;
            }

            String fileName = String.Format("{0}.html", Guid.NewGuid());
            String pathName = Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.internetCacheDirectoryName);

            if (!Directory.Exists(pathName))
            {
                Directory.CreateDirectory(pathName);
            }

            String fileAndPathName = Path.Combine(pathName, fileName);
            if (FileManager.SaveFileCoreWithEncoding(form, fileAndPathName) == false)
            {
                return;
            }

            OtherManager.StartProcessBrowser(form, fileAndPathName);
        }

        internal static void ClearInternetCache(Form form)
        {
            try
            {
                String controlTempPath = Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.internetCacheDirectoryName);
                if (!Directory.Exists(controlTempPath))
                {
                    return;
                }

                String[] files = Directory.GetFiles(controlTempPath);
                foreach (String file in files)
                {
                    if (file == Path.Combine(controlTempPath, ConstantUtil.internetCacheInfoFileName))
                    {
                        continue;
                    }

                    File.Delete(file);
                }
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
        }

        internal static void ConvertTextToHtml(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String tab = "\t";
            if (ConfigUtil.GetBoolParameter("SpacesInsteadTabs"))
            {
                tab = ConstantUtil.tabIntoSpaces;
            }

            String text = ConstantUtil.HtmlTags.Where(keyValuePair => keyValuePair.Value != "&nbsp;").Aggregate(pageTextBox.Text, (current, keyValuePair) => current.Replace(keyValuePair.Key, keyValuePair.Value));
            //foreach (KeyValuePair<String, String> keyValuePair in ConstantUtil.HtmlTags) //Tags
            //{
            //    if (keyValuePair.Value != "&nbsp;")
            //    {
            //        text = text.Replace(keyValuePair.Key, keyValuePair.Value);
            //    }
            //}

            text = "<p>" + text + "</p>";
            text = text.Replace("  ", "&nbsp;&nbsp;"); //Spaces
            text = text.Replace(ConstantUtil.newLine + ConstantUtil.newLine, "</p><p>"); //Paragraphs
            text = text.Replace(ConstantUtil.newLine, "<br />" + ConstantUtil.newLine); //Returns
            text = text.Replace("</p><p>", "</p>" + ConstantUtil.newLine + "<p>");
            pageTextBox.SelectAll();
            pageTextBox.SelectedText = text;
            pageTextBox.SelectAll();
            TextManager.IndentSelectedLines(form);
            TextManager.IndentSelectedLines(form);
            pageTextBox.SelectAll();

            pageTextBox.SelectedText = "<html>" + ConstantUtil.newLine + tab + "<head>" + ConstantUtil.newLine + tab + tab + "<title></title>" + ConstantUtil.newLine + tab +
                "</head>" + ConstantUtil.newLine + tab + "<body>" + ConstantUtil.newLine + pageTextBox.Text + ConstantUtil.newLine + tab + "</body>" + ConstantUtil.newLine + "</html>";

            TextManager.RefreshUndoRedoExternal(form);
        }

        internal static void ConvertHtmlToText(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String error;
            if (!XmlValidator.Validate(form, false, ValidationType.Schema, null, out error))
            {
                WindowManager.ShowAlertBox(form, error);
                return;
            }

            FormatManager.FormatXml(form, false, false);

            String text = ConstantUtil.HtmlTags.Aggregate(pageTextBox.Text, (current, keyValuePair) => current.Replace(keyValuePair.Value, keyValuePair.Value == "&nbsp;" ? " " : keyValuePair.Key));
            //String text = pageTextBox.Text;
            //foreach (KeyValuePair<String, String> keyValuePair in ConstantUtil.HtmlTags) //Tags
            //{
            //    text = text.Replace(keyValuePair.Value, keyValuePair.Value == "&nbsp;" ? " " : keyValuePair.Key);
            //}

            //HTML head
            text = text.Substring(text.IndexOf("<body>") + 6);

            //HTML lists tags
            text = text.Replace("<ul>", String.Empty).Replace("</ul>", String.Empty).Replace("<li>", "- ").Replace("<ol>", "- ").Replace("</li>", String.Empty);
        
            //Other HTML tags
            int startIndex = text.IndexOf("<");
            while (startIndex != -1)
            {
                int endIndex = text.IndexOf(">", startIndex) + 1;
                text = text.Remove(startIndex, endIndex - startIndex);

                startIndex = text.IndexOf("<");
            }

            pageTextBox.SelectAll();
            pageTextBox.SelectedText = text;
            pageTextBox.SelectAll();
            TextManager.OutdentSelectedLines(form);
            TextManager.OutdentSelectedLines(form);

            TextManager.RefreshUndoRedoExternal(form);
        }

        internal static bool OpenUrlSource(Form1 form, String url)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (!url.StartsWith("http://"))
            {
                url = "http://" + url;
            }

            WebClient webClient = null;
            String urlSource;
            try
            {
                webClient = ProxyUtil.InitWebClientProxy();
                webClient.Encoding = EncodingUtil.GetDefaultEncoding();
                urlSource = webClient.DownloadString(url);
            }
            catch (WebException)
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ErrorDownloading", className));
                return false;
            }
            finally
            {
                if (webClient != null)
                {
                    webClient.Dispose();
                }
            }

            if (String.IsNullOrEmpty(urlSource))
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("EmptySource", className));
                return false;
            }

            if (TabManager.IsCurrentTabInUse(form))
            {
                form.TabIdentity = TabManager.AddNewPage(form, form.TabIdentity);
                pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            }

            bool linesDisabled = false;
            if (ConfigUtil.GetBoolParameter("LineNumbersVisible") && StringUtil.AreLinesTooMuchForPasteWithRowLines_External(urlSource))
            {
                WindowManager.CheckLineNumbers(form, false, true);
                linesDisabled = true;
            }

            pageTextBox.SelectedText = urlSource;
            TextManager.RefreshUndoRedoExternal(form);

            if (linesDisabled)
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("LineNumbersDisabled", className));
            }

            return true;
        }

        #endregion Internal Methods
    }
}
