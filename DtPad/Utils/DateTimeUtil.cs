using System;
using DtPad.Exceptions;

namespace DtPad.Utils
{
    /// <summary>
    /// Datetime util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class DateTimeUtil
    {
        private const String className = "DateTimeUtil";

        #region Internal Methods

        internal static String GetTodayDateAsString(String format)
        {
            switch (format)
            {
                case "yyyyMMdd":
                    return String.Format("{0}{1}{2}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                default:
                    throw new DateTimeException(LanguageUtil.GetCurrentLanguageString("DateTimeFormatWrong", className));
            }
        }

        #endregion Internal Methods
    }
}
