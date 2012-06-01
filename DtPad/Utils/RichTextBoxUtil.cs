using System.Windows.Forms;

namespace DtPad.Utils
{
    /// <summary>
    /// RichTextBox functions util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class RichTextBoxUtil
    {
        #region Internal Methods

        internal static void ReplaceRTFContent(RichTextBox destination, RichTextBox source)
        {
            if (destination.Rtf == source.Rtf)
            {
                return;
            }

            destination.SelectAll();
            source.SelectAll();
            destination.SelectedRtf = source.SelectedRtf;

            //destination.SelectAll();
            //destination.SelectedRtf = source.Rtf;

            //source.SelectAll();
            //destination.Rtf = source.SelectedRtf;
        }

        internal static bool ContainsUnderlineText(RichTextBox richTextBox)
        {
            return richTextBox.Rtf.Contains(@"\cf0\ulnone");
        }

        internal static bool ContainsHighlightText(RichTextBox richTextBox)
        {
            return richTextBox.Rtf.Contains(@"\highlight2");
        }

        #endregion Internal Methods
    }
}
