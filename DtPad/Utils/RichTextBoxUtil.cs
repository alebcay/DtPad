using System.Windows.Forms;
using DtPad.Customs;

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

            if (destination is CustomRichTextBox)
            {
                ((CustomRichTextBox)destination).SuspendPainting();
            }

            destination.SelectAll();
            source.SelectAll();
            destination.SelectedRtf = source.SelectedRtf;

            if (destination is CustomRichTextBox)
            {
                ((CustomRichTextBox)destination).ResumePainting();
            }
        }

        internal static bool ContainsUnderlineText(RichTextBox richTextBox)
        {
            return richTextBox.Rtf.Contains(@"\cf0\ulnone");
        }

        internal static bool ContainsHighlightText(RichTextBox richTextBox)
        {
            return richTextBox.Rtf.Contains(@"\highlight2");
        }

        internal static void CheckAllTextSelected(TextBoxBase textBox)
        {
            if (textBox.SelectionStart != 0 || textBox.SelectionLength != textBox.Text.Length)
            {
                return;
            }

            textBox.Select(0, 0);
        }

        #endregion Internal Methods
    }
}
