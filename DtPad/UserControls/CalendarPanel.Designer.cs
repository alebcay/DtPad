namespace DtPad.UserControls
{
    partial class CalendarPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.calendarContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarToolStrip = new System.Windows.Forms.ToolStrip();
            this.weekNumbersToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.insertDatetimeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.monthCalendar1 = new Customs.CustomMonthCalendar();
            this.customPanel2 = new Customs.CustomPanel();
            this.monthCalendar2 = new Customs.CustomMonthCalendar();
            this.customPanel3 = new Customs.CustomPanel();
            this.monthCalendar3 = new Customs.CustomMonthCalendar();
            this.calendarContextMenuStrip.SuspendLayout();
            this.calendarToolStrip.SuspendLayout();
            this.customPanel2.SuspendLayout();
            this.customPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendarContextMenuStrip
            // 
            this.calendarContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToTodayToolStripMenuItem});
            this.calendarContextMenuStrip.Name = "calendarContextMenuStrip";
            this.calendarContextMenuStrip.Size = new System.Drawing.Size(145, 26);
            // 
            // goToTodayToolStripMenuItem
            // 
            this.goToTodayToolStripMenuItem.Name = "goToTodayToolStripMenuItem";
            this.goToTodayToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.goToTodayToolStripMenuItem.Text = "Go to Today";
            this.goToTodayToolStripMenuItem.Click += new System.EventHandler(this.goToTodayToolStripMenuItem_Click);
            // 
            // calendarToolStrip
            // 
            this.calendarToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weekNumbersToolStripButton,
            this.toolStripSeparator1,
            this.insertDatetimeToolStripButton});
            this.calendarToolStrip.Location = new System.Drawing.Point(0, 0);
            this.calendarToolStrip.Name = "calendarToolStrip";
            this.calendarToolStrip.Size = new System.Drawing.Size(157, 25);
            this.calendarToolStrip.TabIndex = 0;
            this.calendarToolStrip.Text = "calendarToolStrip";
            // 
            // weekNumbersToolStripButton
            // 
            this.weekNumbersToolStripButton.CheckOnClick = true;
            this.weekNumbersToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.weekNumbersToolStripButton.Image = global::DtPad.ToolbarResource.numbers;
            this.weekNumbersToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.weekNumbersToolStripButton.Name = "weekNumbersToolStripButton";
            this.weekNumbersToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.weekNumbersToolStripButton.Text = "Show Week Numbers";
            this.weekNumbersToolStripButton.CheckedChanged += new System.EventHandler(this.weekNumbersToolStripButton_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // insertDatetimeToolStripButton
            // 
            this.insertDatetimeToolStripButton.Image = global::DtPad.ToolbarResource.date;
            this.insertDatetimeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.insertDatetimeToolStripButton.Name = "insertDatetimeToolStripButton";
            this.insertDatetimeToolStripButton.Size = new System.Drawing.Size(114, 22);
            this.insertDatetimeToolStripButton.Text = "Insert Datetime...";
            this.insertDatetimeToolStripButton.Click += new System.EventHandler(this.insertDatetimeToolStripButton_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.ActiveMonth.Month = 3;
            this.monthCalendar1.ActiveMonth.Year = 2012;
            this.monthCalendar1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.monthCalendar1.ContextMenuStrip = this.calendarContextMenuStrip;
            this.monthCalendar1.Culture = new System.Globalization.CultureInfo("it-IT");
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar1.Footer.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.monthCalendar1.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar1.Footer.Format = Pabo.Calendar.mcTodayFormat.Long;
            this.monthCalendar1.Footer.TextColor = System.Drawing.Color.White;
            this.monthCalendar1.Header.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.monthCalendar1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar1.Header.TextColor = System.Drawing.Color.White;
            this.monthCalendar1.Header.YearSelectors = true;
            this.monthCalendar1.ImageList = null;
            this.monthCalendar1.Location = new System.Drawing.Point(0, 194);
            this.monthCalendar1.MaxDate = new System.DateTime(2020, 11, 5, 12, 22, 3, 156);
            this.monthCalendar1.MinDate = new System.DateTime(2000, 11, 5, 12, 22, 3, 156);
            this.monthCalendar1.Month.BackgroundImage = null;
            this.monthCalendar1.Month.Colors.Focus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(67)))), ((int)(((byte)(197)))));
            this.monthCalendar1.Month.Colors.Focus.Border = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar1.Month.Colors.Selected.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar1.Month.Colors.Selected.Border = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(49)))), ((int)(((byte)(142)))));
            this.monthCalendar1.Month.Colors.Weekend.BackColor1 = System.Drawing.Color.LightGray;
            this.monthCalendar1.Month.Colors.Weekend.Saturday = false;
            this.monthCalendar1.Month.Colors.Weekend.Sunday = true;
            this.monthCalendar1.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.SelectionMode = Pabo.Calendar.mcSelectionMode.One;
            this.monthCalendar1.ShowFooter = false;
            this.monthCalendar1.ShowTrailingDates = false;
            this.monthCalendar1.Size = new System.Drawing.Size(157, 0);
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.TodayColor = System.Drawing.Color.OrangeRed;
            this.monthCalendar1.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.Weekdays.TextColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar1.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.Weeknumbers.TextColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar1.DayDoubleClick += new Pabo.Calendar.DayClickEventHandler(this.monthCalendar1_DayDoubleClick);
            this.monthCalendar1.MonthChanged += new Pabo.Calendar.MonthChangedEventHandler(this.monthCalendar1_MonthChanged);
            this.monthCalendar1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.monthCalendar1_MouseClick);
            // 
            // customPanel2
            // 
            this.customPanel2.Controls.Add(this.monthCalendar2);
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customPanel2.Location = new System.Drawing.Point(0, 151);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(157, 189);
            this.customPanel2.TabIndex = 2;
            this.customPanel2.NotShowLine = true;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.ActiveMonth.Month = 4;
            this.monthCalendar2.ActiveMonth.Year = 2012;
            this.monthCalendar2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.monthCalendar2.ContextMenuStrip = this.calendarContextMenuStrip;
            this.monthCalendar2.Culture = new System.Globalization.CultureInfo("it-IT");
            this.monthCalendar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.monthCalendar2.Footer.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.monthCalendar2.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar2.Footer.Format = Pabo.Calendar.mcTodayFormat.Long;
            this.monthCalendar2.Footer.TextColor = System.Drawing.Color.White;
            this.monthCalendar2.Header.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.monthCalendar2.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar2.Header.MonthContextMenu = false;
            this.monthCalendar2.Header.MonthSelectors = false;
            this.monthCalendar2.Header.TextColor = System.Drawing.Color.White;
            this.monthCalendar2.ImageList = null;
            this.monthCalendar2.Location = new System.Drawing.Point(0, 6);
            this.monthCalendar2.MaxDate = new System.DateTime(2020, 11, 5, 12, 22, 3, 156);
            this.monthCalendar2.MinDate = new System.DateTime(2000, 11, 5, 12, 22, 3, 156);
            this.monthCalendar2.Month.BackgroundImage = null;
            this.monthCalendar2.Month.Colors.Focus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(67)))), ((int)(((byte)(197)))));
            this.monthCalendar2.Month.Colors.Focus.Border = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar2.Month.Colors.Selected.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar2.Month.Colors.Selected.Border = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(49)))), ((int)(((byte)(142)))));
            this.monthCalendar2.Month.Colors.Weekend.BackColor1 = System.Drawing.Color.LightGray;
            this.monthCalendar2.Month.Colors.Weekend.Saturday = false;
            this.monthCalendar2.Month.Colors.Weekend.Sunday = true;
            this.monthCalendar2.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar2.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.SelectionMode = Pabo.Calendar.mcSelectionMode.None;
            this.monthCalendar2.ShowHeader = false;
            this.monthCalendar2.ShowTrailingDates = false;
            this.monthCalendar2.Size = new System.Drawing.Size(157, 183);
            this.monthCalendar2.TabIndex = 1;
            this.monthCalendar2.TodayColor = System.Drawing.Color.OrangeRed;
            this.monthCalendar2.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar2.Weekdays.TextColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar2.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar2.Weeknumbers.TextColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // customPanel3
            // 
            this.customPanel3.Controls.Add(this.monthCalendar3);
            this.customPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.customPanel3.Location = new System.Drawing.Point(0, 25);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(157, 169);
            this.customPanel3.TabIndex = 2;
            this.customPanel3.Visible = false;
            this.customPanel3.NotShowLine = true;
            // 
            // monthCalendar3
            // 
            this.monthCalendar3.ActiveMonth.Month = 2;
            this.monthCalendar3.ActiveMonth.Year = 2012;
            this.monthCalendar3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.monthCalendar3.ContextMenuStrip = this.calendarContextMenuStrip;
            this.monthCalendar3.Culture = new System.Globalization.CultureInfo("it-IT");
            this.monthCalendar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthCalendar3.Footer.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.monthCalendar3.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar3.Footer.Format = Pabo.Calendar.mcTodayFormat.Long;
            this.monthCalendar3.Footer.TextColor = System.Drawing.Color.White;
            this.monthCalendar3.Header.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.monthCalendar3.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar3.Header.MonthContextMenu = false;
            this.monthCalendar3.Header.MonthSelectors = false;
            this.monthCalendar3.Header.TextColor = System.Drawing.Color.White;
            this.monthCalendar3.ImageList = null;
            this.monthCalendar3.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar3.MaxDate = new System.DateTime(2020, 11, 5, 12, 22, 3, 156);
            this.monthCalendar3.MinDate = new System.DateTime(2000, 11, 5, 12, 22, 3, 156);
            this.monthCalendar3.Month.BackgroundImage = null;
            this.monthCalendar3.Month.Colors.Focus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(67)))), ((int)(((byte)(197)))));
            this.monthCalendar3.Month.Colors.Focus.Border = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar3.Month.Colors.Selected.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar3.Month.Colors.Selected.Border = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(49)))), ((int)(((byte)(142)))));
            this.monthCalendar3.Month.Colors.Weekend.BackColor1 = System.Drawing.Color.LightGray;
            this.monthCalendar3.Month.Colors.Weekend.Saturday = false;
            this.monthCalendar3.Month.Colors.Weekend.Sunday = true;
            this.monthCalendar3.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar3.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar3.Name = "monthCalendar3";
            this.monthCalendar3.SelectionMode = Pabo.Calendar.mcSelectionMode.None;
            this.monthCalendar3.ShowFooter = false;
            this.monthCalendar3.ShowHeader = false;
            this.monthCalendar3.ShowTrailingDates = false;
            this.monthCalendar3.Size = new System.Drawing.Size(157, 163);
            this.monthCalendar3.TabIndex = 1;
            this.monthCalendar3.TodayColor = System.Drawing.Color.OrangeRed;
            this.monthCalendar3.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar3.Weekdays.TextColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar3.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar3.Weeknumbers.TextColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // CalendarPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.customPanel2);
            this.Controls.Add(this.customPanel3);
            this.Controls.Add(this.calendarToolStrip);
            this.Name = "CalendarPanel";
            this.Size = new System.Drawing.Size(157, 340);
            this.SizeChanged += new System.EventHandler(this.CalendarPanel_SizeChanged);
            this.calendarContextMenuStrip.ResumeLayout(false);
            this.calendarToolStrip.ResumeLayout(false);
            this.calendarToolStrip.PerformLayout();
            this.customPanel2.ResumeLayout(false);
            this.customPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Customs.CustomMonthCalendar monthCalendar1;
        private Customs.CustomPanel customPanel2;
        internal Customs.CustomMonthCalendar monthCalendar2;
        private Customs.CustomPanel customPanel3;
        internal Customs.CustomMonthCalendar monthCalendar3;
        private System.Windows.Forms.ToolStripButton insertDatetimeToolStripButton;
        internal System.Windows.Forms.ToolStrip calendarToolStrip;
        private System.Windows.Forms.ToolStripButton weekNumbersToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ContextMenuStrip calendarContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem goToTodayToolStripMenuItem;
    }
}
