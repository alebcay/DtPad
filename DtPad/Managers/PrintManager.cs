using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Print manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class PrintManager
    {
        #region Internal Methods

        internal static CustomPrintDocument Print(Form1 form, CustomPrintDocument customPrintDocument)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            PrintDialog printDialog = form.printDialog;

            customPrintDocument = SetCustomPrintDocument(pageTextBox, customPrintDocument);
            printDialog.Document = customPrintDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                customPrintDocument = SetCustomPrintDocument(pageTextBox, customPrintDocument, printDialog.PrinterSettings.PrintRange == PrintRange.Selection);
                printDialog.Document = customPrintDocument;
                printDialog.Document.Print();
            }

            return customPrintDocument;
        }

        internal static CustomPrintDocument PrintPreview(Form1 form, CustomPrintDocument customPrintDocument)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            PrintPreviewDialog printPreviewDialog = form.printPreviewDialog;

            customPrintDocument = SetCustomPrintDocument(pageTextBox, customPrintDocument);
            printPreviewDialog.Document = customPrintDocument;
            printPreviewDialog.ShowDialog();

            return customPrintDocument;
        }

        internal static CustomPrintDocument PageSetup(Form1 form, CustomPrintDocument customPrintDocument)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            PageSetupDialog pageSetupDialog = form.pageSetupDialog;

            customPrintDocument = SetCustomPrintDocument(pageTextBox, customPrintDocument);
            pageSetupDialog.Document = customPrintDocument;
            pageSetupDialog.ShowDialog();

            return customPrintDocument;
        }

        #endregion Internal Methods

        #region Private Methods

        private static CustomPrintDocument SetCustomPrintDocument(TextBoxBase pageTextBox, CustomPrintDocument customPrintDocument, bool allowSelection = false)
        {
            customPrintDocument.Text = allowSelection ? pageTextBox.SelectedText : pageTextBox.Text;
            customPrintDocument.Font = new Font("Arial", 10);

            return customPrintDocument;
        }

        #endregion Private Methods
    }
}
