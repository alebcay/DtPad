using System;
using System.Text;
using DevExpress.XtraTab;
using DtPad.Customs;

namespace DtPad.Utils
{
    /// <summary>
    /// Tab management util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TabUtil
    {
        #region Internal Methods

        internal static Encoding GetTabTextEncoding(XtraTabPage tabPage)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(tabPage);
            
            Encoding fileEncoding;
            bool encodingForced = Convert.ToBoolean(pageTextBox.CustomEncodingForced);

            if ((encodingForced && !String.IsNullOrEmpty(pageTextBox.CustomEncoding)) || (EncodingUtil.IsEncodingDefaultEnabled() && !String.IsNullOrEmpty(pageTextBox.CustomEncoding)))
            {
                fileEncoding = Encoding.GetEncoding(Convert.ToInt32(pageTextBox.CustomEncoding));
            }
            else
            {
                fileEncoding = EncodingUtil.GetDefaultEncoding();
            }

            return fileEncoding;
        }

        internal static void SetTabTextEncoding(XtraTabPage tabPage, Encoding tabEncoding)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(tabPage);

            pageTextBox.CustomEncoding = tabEncoding.CodePage.ToString();
        }

        internal static bool IsTabPageModified(XtraTabPage tabPage)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(tabPage);

            return pageTextBox.CustomModified;
        }

        #endregion Internal Methods
    }
}
