namespace DtPad
{
    partial class DatetimeSelect
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatetimeSelect));
            this.datetimeListBox = new System.Windows.Forms.ListBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.timeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.timeLabel = new System.Windows.Forms.Label();
            this.resetDatetimeButton = new System.Windows.Forms.Button();
            this.datetimeSelectToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // datetimeListBox
            // 
            this.datetimeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.datetimeListBox.FormattingEnabled = true;
            this.datetimeListBox.Location = new System.Drawing.Point(12, 58);
            this.datetimeListBox.Name = "datetimeListBox";
            this.datetimeListBox.Size = new System.Drawing.Size(302, 82);
            this.datetimeListBox.TabIndex = 6;
            this.datetimeListBox.SelectedIndexChanged += new System.EventHandler(this.datetimeListBox_SelectedIndexChanged);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(9, 42);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(155, 13);
            this.descriptionLabel.TabIndex = 5;
            this.descriptionLabel.Text = "Select datetime format to insert:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(239, 158);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(9, 16);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(33, 13);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Date:";
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateTimePicker.Location = new System.Drawing.Point(48, 12);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(95, 20);
            this.dateDateTimePicker.TabIndex = 1;
            this.dateDateTimePicker.ValueChanged += new System.EventHandler(this.dateDateTimePicker_ValueChanged);
            // 
            // timeDateTimePicker
            // 
            this.timeDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeDateTimePicker.Location = new System.Drawing.Point(199, 12);
            this.timeDateTimePicker.Name = "timeDateTimePicker";
            this.timeDateTimePicker.ShowUpDown = true;
            this.timeDateTimePicker.Size = new System.Drawing.Size(74, 20);
            this.timeDateTimePicker.TabIndex = 3;
            this.timeDateTimePicker.ValueChanged += new System.EventHandler(this.timeDateTimePicker_ValueChanged);
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(160, 16);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(33, 13);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "Time:";
            // 
            // resetDatetimeButton
            // 
            this.resetDatetimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetDatetimeButton.Image = global::DtPad.ToolbarResource.date_red;
            this.resetDatetimeButton.Location = new System.Drawing.Point(291, 11);
            this.resetDatetimeButton.Name = "resetDatetimeButton";
            this.resetDatetimeButton.Size = new System.Drawing.Size(23, 23);
            this.resetDatetimeButton.TabIndex = 4;
            this.datetimeSelectToolTip.SetToolTip(this.resetDatetimeButton, "Set today datetime");
            this.resetDatetimeButton.UseVisualStyleBackColor = true;
            this.resetDatetimeButton.Click += new System.EventHandler(this.resetDatetimeButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Enabled = false;
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(158, 158);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // DatetimeSelect
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(326, 193);
            this.Controls.Add(this.resetDatetimeButton);
            this.Controls.Add(this.timeDateTimePicker);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.dateDateTimePicker);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.datetimeListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatetimeSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datetime";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.DatetimeSelect_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.ListBox datetimeListBox;
        private System.Windows.Forms.DateTimePicker timeDateTimePicker;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button resetDatetimeButton;
        private System.Windows.Forms.ToolTip datetimeSelectToolTip;
    }
}
