using System;
using System.Windows.Forms;

namespace DtHelp.Managers
{
    /// <summary>
    /// Text search in HTML manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class SearchManager
    {
        private const String startHighlight = "<SPAN style=\"BACKGROUND-COLOR: yellow\" id=1C9B56C725084efa9A2B82DA15F15947>"; //"<span id=\"searchHighlight\" style=\"background-color:yellow;\">";
        private const String endHighlight = "</SPAN>";

        #region Internal Methods

        internal static void Search(Form1 form)
        {
            TextBox searchTextBox = form.searchTextBox;
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;

            HtmlDocument document = helpWebBrowser.Document;
            document = ClearSearchInHtml(document);

            if (document == null || document.Body == null || String.IsNullOrEmpty(searchTextBox.Text))
            {
                return;
            }

            String textWhereToSearch = document.Body.InnerHtml.ToLower();
            String textToSearch = searchTextBox.Text.ToLower();

            int positionSearchedText = textWhereToSearch.IndexOf(textToSearch);
            if (positionSearchedText != -1)
            {
                document.Body.InnerHtml = FindStringInHtml(document.Body.InnerHtml, textWhereToSearch, textToSearch, 0);
            }

            return;
        }

        #endregion Internal Methods

        #region Private Methods

        private static String FindStringInHtml(String originalText, String textWhereToSearch, String textToSearch, int startIndex)
        {
            int foundIndex = textWhereToSearch.IndexOf(textToSearch, startIndex);

            if (foundIndex == -1)
            {
                return originalText;
            }

            int firstMajorIndex = textWhereToSearch.IndexOf(">", foundIndex + textToSearch.Length);
            int firstMinorIndex = textWhereToSearch.IndexOf("<", foundIndex + textToSearch.Length);

            if (firstMajorIndex != -1 && firstMinorIndex >= firstMajorIndex)
            {
                return FindStringInHtml(originalText, textWhereToSearch, textToSearch, foundIndex + textToSearch.Length);
            }

            originalText = originalText.Insert(foundIndex, startHighlight).Insert(foundIndex + textToSearch.Length + startHighlight.Length, endHighlight);
            textWhereToSearch = textWhereToSearch.Insert(foundIndex, startHighlight).Insert(foundIndex + textToSearch.Length + startHighlight.Length, endHighlight);

            return FindStringInHtml(originalText, textWhereToSearch, textToSearch, foundIndex + textToSearch.Length + startHighlight.Length + endHighlight.Length);
        }

        private static HtmlDocument ClearSearchInHtml(HtmlDocument document)
        {
            if (document == null || document.Body == null)
            {
                return document;
            }
            
            while (document.Body.InnerHtml.IndexOf(startHighlight) != -1)
            {
                int startIndex = document.Body.InnerHtml.IndexOf(startHighlight);
                document.Body.InnerHtml = document.Body.InnerHtml.Remove(startIndex, startHighlight.Length);

                int endIndex = document.Body.InnerHtml.IndexOf(endHighlight, startIndex);
                document.Body.InnerHtml = document.Body.InnerHtml.Remove(endIndex, endHighlight.Length);
            }

            return document;
        }

        #endregion Private Methods
    }
}
