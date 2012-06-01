using System;
using DtPad.Utils;
using DtPad.Validators;

namespace DtPad.Managers
{
    /// <summary>
    /// E-mail send manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class EmailManager
    {
        private const String className = "EmailManager";
        
        #region Internal Methods

        internal static void SendBugReport(ReportBug form)
        {
            if (!RegularExpressionValidator.ValidateSingleString(form.emailTextBox.Text, RegularExpressionValidator.RegularExpression.Email))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("EmailInvalid", className));
                return;
            }

            String mailString = PrepareMailBugReport(form.sendMeACopyCheckBox.Checked, form.emailTextBox.Text, form.nameTextBox.Text,
                form.areaComboBox.SelectedItem.ToString(), form.errorMessageTextBox.Text, form.descriptionTextBox.Text);
            OtherManager.StartProcess(form, mailString);
        }

        #endregion Internal Methods

        #region Private Methods

        private static String PrepareMailBugReport(bool sendMeACopy, String email, String name, String area, String errorMessage, String description)
        {
            String mailString = String.Format("mailto:{0}?", ConstantUtil.myEmail);

            if (sendMeACopy)
            {
                mailString = mailString + "cc=" + email + "&";
            }

            String bugReportLabel = LanguageUtil.GetCurrentLanguageString("BugReport", className);
            String nameLabel = LanguageUtil.GetCurrentLanguageString("Name", className);
            String emailLabel = LanguageUtil.GetCurrentLanguageString("Email", className);
            String areaLabel = LanguageUtil.GetCurrentLanguageString("Area", className);
            String errorMessageLabel = LanguageUtil.GetCurrentLanguageString("ErrorMessage", className);
            String descriptionLabel = LanguageUtil.GetCurrentLanguageString("Description", className);

            mailString += "subject=[DtPad] " + bugReportLabel + "&body=[DtPad] " + bugReportLabel + "%0D%0D" + nameLabel + ": " + name
                + "%0D" + emailLabel + ": " + email + "%0D" + areaLabel + ": " + area + "%0D";

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
