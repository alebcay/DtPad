using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.Validators
{
    /// <summary>
    /// Regular expressions used by DtPad.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class RegularExpressionValidator
    {
        private const String className = "RegularExpressionValidator";

        internal enum RegularExpression
        {
            [Description("E-mail regular expression validator")]
            Email,
            [Description("HTML tag regular expression validator")]
            HtmlTag,
            [Description("IP regular expression validator")]
            Ip,
            [Description("Capitalized words regular expression validator")]
            CapitalizedWords
        }

        #region Internal Instance Constants

        internal const String EmailRegEx = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        internal const String HtmlTagRegEx = @"<(.|\n)+?>";
        internal const String IpRegEx = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";
        internal const String CapitalizedWords = @"\b[A-Z][A-Z]+";

        #endregion Internal Instance Constants

        #region Internal Methods

        internal static void Validate(Form1 form, RegularExpression regularExpression)
        {
            switch (regularExpression)
            {
                case RegularExpression.Email:
                    Generic(form, EmailRegEx, false);
                    break;
                case RegularExpression.HtmlTag:
                    Generic(form, HtmlTagRegEx, false);
                    break;
                case RegularExpression.Ip:
                    Generic(form, IpRegEx, false);
                    break;
                case RegularExpression.CapitalizedWords:
                    Generic(form, CapitalizedWords, false);
                    break;
            }
        }

        internal static bool Validate(Form1 form, String regularExpression, bool denyRule)
        {
            return Generic(form, regularExpression, denyRule);
        }

        internal static bool ValidateSingleString(String stringToCheck, RegularExpression regularExpression)
        {
            bool result = false;

            switch (regularExpression)
            {
                case RegularExpression.Email:
                    result = Regex.IsMatch(stringToCheck, EmailRegEx);
                    break;
                case RegularExpression.HtmlTag:
                    result = Regex.IsMatch(stringToCheck, HtmlTagRegEx);
                    break;
                case RegularExpression.Ip:
                    result = Regex.IsMatch(stringToCheck, IpRegEx);
                    break;
                case RegularExpression.CapitalizedWords:
                    result = Regex.IsMatch(stringToCheck, CapitalizedWords);
                    break;
            }

            return result;
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool Generic(Form1 form, String regularExpression, bool denyRule)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            try
            {
                if (!Regex.IsMatch(pageTextBox.Text, regularExpression))
                {
                    WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoResultFounded", className));
                    return false;
                }
            }
            catch (ArgumentException exception)
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("InvalidRegex", className) + Environment.NewLine + exception.Message.Substring(0, 1).ToUpper() + exception.Message.Substring(1));
                return false;
            }

            Match matches = Regex.Match(pageTextBox.Text, regularExpression);
            String result = matches.Value + Environment.NewLine;
            matches = matches.NextMatch();

            while (matches.Success)
            {
                result += matches.Value + Environment.NewLine;
                matches = matches.NextMatch();
            }

            if (denyRule)
            {
                String temp = pageTextBox.Text;
                result = result.Replace(Environment.NewLine, ConstantUtil.newLine);

                temp = result.Split(new[] {Convert.ToChar(ConstantUtil.newLine)}, StringSplitOptions.RemoveEmptyEntries).Aggregate(temp, (current, email) => current.Replace(email, String.Empty));
                //foreach (String email in result.Split(new[] { Convert.ToChar(ConstantUtil.newLine) }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    temp = temp.Replace(email, String.Empty);
                //}

                result = temp;
            }

            result = LanguageUtil.GetCurrentLanguageString("ResultFounded", className) + Environment.NewLine + Environment.NewLine + result;
            WindowManager.ShowContent(form, result);

            return true;
        }

        #endregion Private Methods
    }
}
