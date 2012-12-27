using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Datetime selection DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class DatetimeSelect : Form
    {
        #region Window Methods

        internal void InitializeForm(DateTime? datetime)
        {
            InitializeComponent();
            SetLanguage();
            ResetDatetime(datetime);
        }

        private void datetimeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckOKButton();
        }

        private void DatetimeSelect_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
            CheckOKButton();
        }

        private void dateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SetDatetimeFormats(dateDateTimePicker.Value, timeDateTimePicker.Value);
            CheckOKButton();
        }

        private void timeDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SetDatetimeFormats(dateDateTimePicker.Value, timeDateTimePicker.Value);
            CheckOKButton();
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            TextManager.InsertDateTime(form, datetimeListBox.SelectedItem.ToString());
            WindowManager.CloseForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void resetDatetimeButton_Click(object sender, EventArgs e)
        {
            ResetDatetime(null);
            CheckOKButton();
        }

        #endregion Button Methods

        #region Private Methods

        private void SetDatetimeFormats(DateTime date, DateTime time)
        {
            DateTime datetime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond);

            //datetimeListBox.Items.Clear();

            //List<String> datesList = new List<String>(datetime.GetDateTimeFormats('d', LanguageUtil.GetInfoCulture()));
            //datesList.AddRange(new List<String>(datetime.GetDateTimeFormats('D', LanguageUtil.GetInfoCulture())));
            //datesList.AddRange(new List<String>(datetime.GetDateTimeFormats('f', LanguageUtil.GetInfoCulture())));
            //datesList.AddRange(new List<String>(datetime.GetDateTimeFormats('F', LanguageUtil.GetInfoCulture())));

            //foreach(String dateItem in datesList)
            //{
            //    if (!datetimeListBox.Items.Contains(dateItem))
            //    {
            //        datetimeListBox.Items.Add(dateItem);
            //    }
            //}

            datetimeListBox.Items.Clear();
            datetimeListBox.Items.Add(String.Format("{0}", datetime.ToShortDateString()));
            datetimeListBox.Items.Add(String.Format("{0}", datetime.ToLongDateString()));
            datetimeListBox.Items.Add(String.Format("{0}", datetime.ToShortTimeString()));
            datetimeListBox.Items.Add(String.Format("{0}", datetime.ToLongTimeString()));
            datetimeListBox.Items.Add(String.Format("{0} {1}", datetime.ToShortDateString(), datetime.ToShortTimeString()));
            datetimeListBox.Items.Add(String.Format("{0} {1}", datetime.ToLongDateString(), datetime.ToLongTimeString()));
        }

        private void ResetDatetime(DateTime? datetime)
        {
            DateTime datetimeNow = (datetime == null) ? DateTime.Now : Convert.ToDateTime(datetime);

            dateDateTimePicker.Value = datetimeNow;
            timeDateTimePicker.Value = datetimeNow;
            SetDatetimeFormats(dateDateTimePicker.Value, timeDateTimePicker.Value);
        }

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            datetimeSelectToolTip.SetToolTip(resetDatetimeButton, LanguageUtil.GetCurrentLanguageString("resetDatetimeButtonToolTip", Name));
        }

        private void CheckOKButton()
        {
            okButton.Enabled = datetimeListBox.SelectedItems.Count == 1;
        }

        #endregion Private Methods
    }
}
