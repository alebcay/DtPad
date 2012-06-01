using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Exceptions;
using DtPad.Utils;
using DtPad.Validators;

namespace DtPad.Managers
{
    /// <summary>
    /// Text format manager (ie. XML).
    /// </summary>
    /// <author>External source, Marco Macciò</author>
    internal static class FormatManager
    {
        private const String className = "FormatManager";

        internal enum TagType
        {
            [Description("XHTML tag")]
            XHTML,
            [Description("Standard tag forum")]
            Forum,
            [Description("Custom tag character")]
            Custom
        }

        internal enum TagExtension
        {
            [Description("Complete tag (es. <b></b>)")]
            Complete,
            [Description("Short tag (es. <br />)")]
            Short
        }

        #region Internal Methods

        internal static void FormatXml(Form1 form, bool validationFirst = true, bool indentation = true)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (validationFirst && !XmlValidator.Validate(form, ValidationType.Schema, false))
            {
                return;
            }

            int indentationNum = indentation ? 1 : 0;

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(pageTextBox.Text); //xd.LoadXml(EncodeHTMLTagsForXMLValidation(pageTextBox.Text));

            StringBuilder builder = new StringBuilder();
            using (StringWriter writer = new StringWriter(builder))
            { 
                using (XmlTextWriter xtw = new XmlTextWriter(writer))
                {
                    xtw.IndentChar = '\t';
                    xtw.Indentation = indentationNum;
                    xtw.Formatting = Formatting.Indented;
                    
                    xd.WriteTo(xtw);
                }

                pageTextBox.SelectAll();
                pageTextBox.SelectedText = builder.ToString(); //pageTextBox.SelectedText = DecodeHTMLTagsForXMLValidation(builder.ToString());
                TextManager.RefreshUndoRedoExternal(form);
            }
        }

        internal static String EncodeHTMLTagsForXMLValidation(String htmlText)
        {
            //foreach (KeyValuePair<String, String> keyValuePair in ConstantUtil.SmallHtmlTags)
            //{
            //    htmlText = htmlText.Replace(keyValuePair.Key, keyValuePair.Value);
            //}
            //return htmlText;

            return ConstantUtil.SmallHtmlTags.Aggregate(htmlText, (current, keyValuePair) => current.Replace(keyValuePair.Key, keyValuePair.Value));

            //return ConstantUtil.HtmlTags.Aggregate(htmlText, (current, keyValuePair) => current.Replace(keyValuePair.Value, XmlConvert.EncodeName(keyValuePair.Value)));
        }

        internal static void InsertTag(Form1 form, String tag, TagType type, TagExtension extension, String customTypeBegin = null, String customTypeEnd = null)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            switch (type)
            {
                case TagType.XHTML:
                    customTypeBegin = "<";
                    customTypeEnd = ">";
                    break;
                case TagType.Forum:
                    customTypeBegin = "[";
                    customTypeEnd = "]";
                    break;
            }

            if (String.IsNullOrEmpty(customTypeBegin) || String.IsNullOrEmpty(customTypeEnd))
            {
                throw new ParameterException(LanguageUtil.GetCurrentLanguageString("TagTypeEmpty", className));
            }

            String newSelection;
            int selectionStart = pageTextBox.SelectionStart;
            int insertionLength;

            switch (extension)
            {
                case TagExtension.Complete:
                    newSelection = customTypeBegin + tag + customTypeEnd + pageTextBox.SelectedText + customTypeBegin + "/" + tag + customTypeEnd;
                    insertionLength = newSelection.Length;

                    pageTextBox.SelectedText = newSelection;
                    pageTextBox.Select(selectionStart, insertionLength);
                    break;
                case TagExtension.Short:
                    newSelection = pageTextBox.SelectedText + customTypeBegin + tag + " /" + customTypeEnd;
                    insertionLength = newSelection.Length;

                    pageTextBox.SelectedText = newSelection;
                    pageTextBox.Select(selectionStart, insertionLength);
                    break;
            }

            TextManager.RefreshUndoRedoExternal(form);
        }

        #endregion Internal Methods

        //#region Private Methods

        //private static String DecodeHTMLTagsForXMLValidation(String xmlText)
        //{
        //    //foreach (KeyValuePair<String, String> keyValuePair in ConstantUtil.HtmlTags)
        //    //{
        //    //    xmlText = xmlText.Replace(XmlConvert.EncodeName(keyValuePair.Value), keyValuePair.Value);
        //    //}
        //    return ConstantUtil.HtmlTags.Aggregate(xmlText, (current, keyValuePair) => current.Replace(XmlConvert.EncodeName(keyValuePair.Value), keyValuePair.Value));
        //}

        //#endregion Private Methods
    }
}
