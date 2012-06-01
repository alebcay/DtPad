using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using DtPadUninstaller.MessageBoxes;
using DtPadUninstaller.Utils;

namespace DtPadUninstaller.Managers
{
    /// <summary>
    /// Window operations manager (ie. open new windows).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class WindowManager
    {
        private const String className = "WindowManager";

        #region Close Methods

        internal static void CloseForm(Form form)
        {
            form.Close();
        }

        #endregion Close Methods

        #region Show Methods

        internal static void ShowErrorBox(Form form, String errorMessage, Exception exception, String culture)
        {
            LogUtil log = new LogUtil(MethodBase.GetCurrentMethod());
            log.errorLog(errorMessage, exception);

            ErrorO errorBox = new ErrorO(form, LanguageUtil.GetCurrentLanguageString("Exception", className, culture) + " " + Environment.NewLine + errorMessage + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("CommandExecution", className, culture), exception, culture);
            errorBox.ShowDialog(form);
        }

        internal static void ShowErrorProgramBox(Form form, String errorMessage, Exception exception)
        {
            LogUtil log = new LogUtil(MethodBase.GetCurrentMethod());
            log.fatalLog(errorMessage, exception);

            String culture = LanguageUtil.GetReallyShortCulture(CultureInfo.CurrentCulture.Name);

            ErrorO errorBox = new ErrorO(form, LanguageUtil.GetCurrentLanguageString("FatalException", className, culture) + " " + Environment.NewLine + errorMessage + Environment.NewLine + LanguageUtil.GetCurrentLanguageString("ProgramExecution", className, culture), exception, culture);
            errorBox.ShowDialog(form);
        }

        internal static void ShowAlertProgramBox(Form form, String message, String culture)
        {
            AlertO alertBox = new AlertO(form, message, culture);
            alertBox.ShowDialog(form);
        }

        internal static DialogResult ShowQuestionBox(Form form, String message, String culture)
        {
            QuestionYN alertBox = new QuestionYN(form, message, culture);
            return alertBox.ShowDialog(form);
        }

        #endregion Show Methods
    }
}
