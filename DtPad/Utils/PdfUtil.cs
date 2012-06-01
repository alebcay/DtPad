using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace DtPad.Utils
{
    /// <summary>
    /// Pdf reading class.
    /// </summary>
    /// <author>External source, Marco Macciò</author>
    internal static class PdfUtil
    {
        #region Internal Methods

        internal static void SaveText(String fileName, String fileTitle, String text)
        {
            Document document = new Document();
            FileStream fileStream = File.Create(fileName);
            PdfWriter.GetInstance(document, fileStream);

            document.Open();
            document.AddTitle(fileTitle);
            document.AddCreationDate();
            document.AddCreator("DtPad " + AssemblyUtil.AssemblyVersion);
            document.Add(new Paragraph(text));

            if (document.IsOpen())
            {
                document.CloseDocument();
            }
            fileStream.Dispose();
        }

        /// <summary>
        /// Extracts a text from a PDF file.
        /// </summary>
        /// <param name="fileName">The full path to the pdf file.</param>
        /// <param name="success">Indicate if operation was successfull.</param>
        /// <returns>The extracted text.</returns>
        internal static String ExtractText(String fileName, out bool success)
        {
            String result = String.Empty;
            PdfReader reader = null;
            success = false;

            try
            {
                reader = new PdfReader(fileName);
                PdfReaderContentParser parser = new PdfReaderContentParser(reader);
                SimpleTextExtractionStrategy strategy;

                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    strategy = parser.ProcessContent(page, new SimpleTextExtractionStrategy());
                    result += strategy.GetResultantText();
                }

                success = true;
                return result;
            }
            catch (Exception)
            {
                return String.Empty;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        #endregion Internal Methods
    }
}
