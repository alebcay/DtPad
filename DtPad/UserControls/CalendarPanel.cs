using System;
using System.Globalization;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;
using Pabo.Calendar;

namespace DtPad.UserControls
{
    /// <summary>
    /// Calendar user control.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class CalendarPanel : UserControl
    {
        internal CalendarPanel()
        {
            InitializeComponent();

            monthCalendar1.Culture = LanguageUtil.GetInfoCulture();
            monthCalendar2.Culture = LanguageUtil.GetInfoCulture();
            monthCalendar3.Culture = LanguageUtil.GetInfoCulture();

            monthCalendar1.ActiveMonth.Month = DateTime.Today.Month;
            monthCalendar1.ActiveMonth.Year = DateTime.Today.Year;
            
            insertDatetimeToolStripButton.Enabled = monthCalendar1.SelectedDates.Count != 0;

            CheckPreviuosMonth();
        }

        #region Window Methods

        private void weekNumbersToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            monthCalendar1.ShowWeeknumbers = weekNumbersToolStripButton.Checked;
            monthCalendar2.ShowWeeknumbers = weekNumbersToolStripButton.Checked;
            monthCalendar3.ShowWeeknumbers = weekNumbersToolStripButton.Checked;
        }

        private void goToTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            monthCalendar1.SelectDate(DateTime.Today);
        }

        private void CalendarPanel_SizeChanged(object sender, EventArgs e)
        {
            CheckPreviuosMonth();
        }

        private void monthCalendar1_MonthChanged(object sender, MonthChangedEventArgs e)
        {
            if (monthCalendar1.ActiveMonth.Month < 12)
            {
                monthCalendar2.ActiveMonth.Month = monthCalendar1.ActiveMonth.Month + 1;
                monthCalendar2.ActiveMonth.Year = monthCalendar1.ActiveMonth.Year;
            }
            else
            {
                monthCalendar2.ActiveMonth.Month = 1;
                monthCalendar2.ActiveMonth.Year = monthCalendar1.ActiveMonth.Year + 1;
            }

            if (monthCalendar1.ActiveMonth.Month > 1)
            {
                monthCalendar3.ActiveMonth.Month = monthCalendar1.ActiveMonth.Month - 1;
                monthCalendar3.ActiveMonth.Year = monthCalendar1.ActiveMonth.Year;
            }
            else
            {
                monthCalendar3.ActiveMonth.Month = 12;
                monthCalendar3.ActiveMonth.Year = monthCalendar1.ActiveMonth.Year - 1;
            }
        }

        private void monthCalendar1_DayDoubleClick(object sender, DayClickEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            DateTime selectedDate = Convert.ToDateTime(e.Date, CultureInfo.CurrentCulture);

            if (selectedDate.Month == monthCalendar1.ActiveMonth.Month)
            {
                WindowManager.ShowDatetimeSelectWindow(form, selectedDate);
            }

            monthCalendar1.SelectDate(selectedDate);
        }

        private void monthCalendar1_MouseClick(object sender, MouseEventArgs e)
        {
            insertDatetimeToolStripButton.Enabled = monthCalendar1.SelectedDates.Count != 0;
        }

        #endregion Window Methods

        #region Button Methods

        private void insertDatetimeToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            if (monthCalendar1.SelectedDates[0].Month == monthCalendar1.ActiveMonth.Month)
            {
                WindowManager.ShowDatetimeSelectWindow(form, monthCalendar1.SelectedDates[0]);
            }
        }

        #endregion Button Methods

        #region Multilanguage Methods

        internal void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, calendarContextMenuStrip.Items);
        }

        #endregion Multilanguage Methods

        #region Private Methods

        private void CheckPreviuosMonth()
        {
            //if (!Visible)
            //{
            //    return;
            //}

            customPanel3.Visible = Height >= 203 + (customPanel2.Height + customPanel3.Height); //183

            if (Height < 203 + customPanel2.Height)
            {
                customPanel2.Visible = false;
                monthCalendar1.ShowFooter = true;
            }
            else
            {
                customPanel2.Visible = true;
                monthCalendar1.ShowFooter = false;
            }
        }

        #endregion Private Methods
    }
}
