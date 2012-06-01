using System;
using System.IO;
using System.Text;
using System.Xml;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.Validators
{
    /// <summary>
    /// Xml validator.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class XmlValidator
    {
        private const String className = "XmlValidator";

        #region Internal Methods

        internal static bool Validate(Form1 form,  ValidationType type, bool showMessages = true, Encoding encoding = null)
        {
            String error;
            return Validate(form, showMessages, type, encoding, out error);
        }
        internal static bool Validate(Form1 form, bool showMessages, ValidationType type, Encoding encoding, out String error)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            error = String.Empty;

            Encoding fileEncoding = encoding ?? TabUtil.GetTabTextEncoding(pagesTabControl.SelectedTabPage);
            String text = pageTextBox.Text; //FormatManager.EncodeHTMLTagsForXMLValidation(pageTextBox.Text);

            byte[] byteArray = fileEncoding.GetBytes(text);
            MemoryStream contentStream = new MemoryStream(byteArray); 

            XmlReaderSettings settings = new XmlReaderSettings
                                             {
                                                 ValidationType = type,
                                                 IgnoreComments = true,
                                                 DtdProcessing = DtdProcessing.Parse //ProhibitDtd = false
                                             };

            String filename = ProgramUtil.GetFilenameTabPage(form.pagesTabControl.SelectedTabPage);
            XmlReader reader = !String.IsNullOrEmpty(filename) ? XmlReader.Create(contentStream, settings, filename) : XmlReader.Create(contentStream, settings);
            
            try
            {
                while (reader.Read())
                {
                }
            }
            catch (Exception exception)
            {
                error = String.Format(LanguageUtil.GetCurrentLanguageString("Error", className), exception.Message);
                if (showMessages)
                {
                    WindowManager.ShowAlertBox(form, error);
                }
                return false;
            }
            finally
            {
                contentStream.Dispose();
                reader.Close();
            }

            if (showMessages)
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("Success", className));
            }
            return true;
        }

        internal static void Normalize(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            pageTextBox.SelectAll();
            pageTextBox.SelectedText = FormatManager.EncodeHTMLTagsForXMLValidation(pageTextBox.Text);
            TextManager.RefreshUndoRedoExternal(form);
        }

        #endregion Internal Methods
    }
}
