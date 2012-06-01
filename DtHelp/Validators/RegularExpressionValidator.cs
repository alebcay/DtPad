using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace DtHelp.Validators
{
    /// <summary>
    /// Regular expressions used by DtHelp.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class RegularExpressionValidator
    {
        internal enum RegularExpression
        {
            [Description("E-mail regular expression validator")]
            Email
        }

        #region Private Instance Constants

        private const String EmailRegEx = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        #endregion Private Instance Constants

        #region Internal Methods

        internal static bool ValidateSingleString(String stringToCheck, RegularExpression regularExpression)
        {
            bool result = false;

            switch (regularExpression)
            {
                case RegularExpression.Email:
                    result = Regex.IsMatch(stringToCheck, EmailRegEx);
                    break;               
            }

            return result;
        }

        #endregion Internal Methods
    }
}
