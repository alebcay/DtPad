using System;
using System.Globalization;
using System.Windows.Forms;
using DtPadSetup.MessageBoxes;
using DtPadSetup.Utils;

namespace DtPadSetup.Managers
{
    /// <summary>
    /// Window operations manager (ie. open new windows).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class WindowManager
    {
        private const String className = "WindowManager";
        
        #region Internal Methods

        internal static void ShowAlertBox(Form form, String message, String culture)
        {
            AlertO alertBox = new AlertO(form, message, culture);
            alertBox.ShowDialog(form);
        }

        internal static DialogResult ShowWarningBox(Form form, String message, String culture)
        {
            WarningYNC warningBox = new WarningYNC(form, message, culture);
            return warningBox.ShowDialog(form);
        }

        internal static DialogResult ShowErrorBox(Form form, String errorMessage, Exception exception, String culture)
        {
            ErrorO errorBox = new ErrorO(form, LanguageUtil.GetCurrentLanguageString("Exception", className, culture) + " " + Environment.NewLine + errorMessage + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("CommandExecution", className, culture), exception, culture);
            return errorBox.ShowDialog(form);
        }

        internal static void ShowAlertProgramBox(Form form, String message)
        {
            String culture = LanguageUtil.GetReallyShortCulture(CultureInfo.CurrentCulture.Name);

            AlertO alertBox = new AlertO(form, message, culture);
            alertBox.ShowDialog(form);
        }

        internal static DialogResult ShowErrorProgramBox(Form form, String errorMessage, Exception exception)
        {
            String culture = LanguageUtil.GetReallyShortCulture(CultureInfo.CurrentCulture.Name);

            ErrorO errorBox = new ErrorO(form, LanguageUtil.GetCurrentLanguageString("FatalException", className, culture) + " " + Environment.NewLine + errorMessage + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("ProgramExecution", className, culture), exception, culture);
            return errorBox.ShowDialog(form);
        }

        #endregion Internal Methods
    }
}
