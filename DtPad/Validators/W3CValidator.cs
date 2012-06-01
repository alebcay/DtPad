using System;
using System.IO;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.Validators
{
    /// <summary>
    /// W3C validator.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class W3CValidator
    {
        private const String className = "W3CValidator";

        #region Internal Methods

        internal static void ValidateHtml(Form1 form)
        {
            Validate(form, ConstantUtil.w3cHtmlValidation, LanguageUtil.GetCurrentLanguageString("TitleHtml", className));
        }

        internal static void ValidateCss(Form1 form)
        {
            Validate(form, ConstantUtil.w3cCssValidation, LanguageUtil.GetCurrentLanguageString("TitleCss", className));
        }

        #endregion Internal Methods

        #region Private Methods

        private static void Validate(Form1 form, String validation, String title)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            if (String.IsNullOrEmpty(pageTextBox.Text))
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

            String text = String.Format(validation, title, pageTextBox.Text, LanguageUtil.GetCurrentLanguageString("Validate", className));

            String fileAndPathName = Path.Combine(pathName, fileName);
            if (FileManager.SaveFileCoreWithEncoding(null, fileAndPathName, text) == false)
            {
                return;
            }

            OtherManager.StartProcessBrowser(form, fileAndPathName);
        }

        #endregion Private Methods
    }
}
