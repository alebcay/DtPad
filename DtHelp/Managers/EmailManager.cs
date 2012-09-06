using System;
using DtHelp.Utils;
using DtHelp.Validators;

namespace DtHelp.Managers
{
    /// <summary>
    /// E-mail send manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class EmailManager
    {
        private const String className = "EmailManager";

        #region Internal Methods

        internal static void SendBugReport(ReportBug form, String culture)
        {
            if (!RegularExpressionValidator.ValidateSingleString(form.emailTextBox.Text, RegularExpressionValidator.RegularExpression.Email))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("EmailInvalid", className, culture), culture);
                return;
            }

            String mailString = PrepareMailBugReport(form.sendMeACopyCheckBox.Checked, form.emailTextBox.Text, form.nameTextBox.Text, form.areaComboBox.SelectedItem.ToString(), form.errorMessageTextBox.Text, form.descriptionTextBox.Text, culture);
            OtherManager.StartProcess(form, mailString, culture);
        }

        #endregion Internal Methods

        #region Private Methods

        private static String PrepareMailBugReport(bool sendMeACopy, String email, String name, String area, String errorMessage, String description, String culture)
        {
            String mailString = String.Format("mailto:{0}?", ConstantUtil.myEmail);

            if (sendMeACopy)
            {
                mailString = mailString + "cc=" + email + "&";
            }

            String bugReportLabel = LanguageUtil.GetCurrentLanguageString("BugReport", className, culture);
            String nameLabel = LanguageUtil.GetCurrentLanguageString("Name", className, culture);
            String emailLabel = LanguageUtil.GetCurrentLanguageString("Email", className, culture);
            String areaLabel = LanguageUtil.GetCurrentLanguageString("Area", className, culture);
            String errorMessageLabel = LanguageUtil.GetCurrentLanguageString("ErrorMessage", className, culture);
            String descriptionLabel = LanguageUtil.GetCurrentLanguageString("Description", className, culture);

            mailString += "subject=[DtHelp] " + bugReportLabel + "&body=[DtHelp] " + bugReportLabel + "%0D%0D" + nameLabel + ": " + name + "%0D" + emailLabel + ": " + email + "%0D" + areaLabel + ": " + area + "%0D";

            if (!String.IsNullOrEmpty(errorMessage.Trim()))
            {
                mailString += errorMessageLabel + ": " + errorMessage + "%0D";
            }

            mailString += descriptionLabel + ": " + description;

            return mailString;
        }

        #endregion Private Methods
    }
}
