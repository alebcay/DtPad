namespace DtPad
{
    partial class ReportBug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportBug));
            this.nameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.areaLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.errorMessageLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.areaComboBox = new System.Windows.Forms.ComboBox();
            this.errorMessageTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.requiredFieldsLabel = new System.Windows.Forms.Label();
            this.sendMeACopyCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(45, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name: *";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(12, 41);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(85, 13);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "E-mail address: *";
            // 
            // areaLabel
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.Location = new System.Drawing.Point(12, 67);
            this.areaLabel.Name = "areaLabel";
            this.areaLabel.Size = new System.Drawing.Size(60, 13);
            this.areaLabel.TabIndex = 4;
            this.areaLabel.Text = "Bug area: *";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 196);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(70, 13);
            this.descriptionLabel.TabIndex = 8;
            this.descriptionLabel.Text = "Description: *";
            // 
            // errorMessageLabel
            // 
            this.errorMessageLabel.AutoSize = true;
            this.errorMessageLabel.Location = new System.Drawing.Point(12, 94);
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.Size = new System.Drawing.Size(129, 13);
            this.errorMessageLabel.TabIndex = 6;
            this.errorMessageLabel.Text = "Error message (if present):";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(104, 12);
            this.nameTextBox.MaxLength = 100;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(251, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.Tag = "DontTranslate";
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTextBox.Location = new System.Drawing.Point(104, 38);
            this.emailTextBox.MaxLength = 100;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(251, 20);
            this.emailTextBox.TabIndex = 3;
            this.emailTextBox.Tag = "DontTranslate";
            this.emailTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.AcceptsReturn = true;
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(15, 212);
            this.descriptionTextBox.MaxLength = 650;
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(340, 126);
            this.descriptionTextBox.TabIndex = 9;
            this.descriptionTextBox.Tag = "DontTranslate";
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.descriptionTextBox_TextChanged);
            // 
            // areaComboBox
            // 
            this.areaComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.areaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaComboBox.FormattingEnabled = true;
            this.areaComboBox.Items.AddRange(new object[] {
            global::DtPad.Languages.ru.SearchPattern_historyComboBoxItems,
            "File",
            "Edit",
            "View",
            "Session",
            "Search",
            "Action",
            "Options",
            "Tools",
            "Window",
            "Help",
            "Other"});
            this.areaComboBox.Location = new System.Drawing.Point(104, 64);
            this.areaComboBox.Name = "areaComboBox";
            this.areaComboBox.Size = new System.Drawing.Size(251, 21);
            this.areaComboBox.TabIndex = 5;
            this.areaComboBox.SelectedIndexChanged += new System.EventHandler(this.areaComboBox_SelectedIndexChanged);
            // 
            // errorMessageTextBox
            // 
            this.errorMessageTextBox.AcceptsReturn = true;
            this.errorMessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorMessageTextBox.Location = new System.Drawing.Point(15, 110);
            this.errorMessageTextBox.MaxLength = 650;
            this.errorMessageTextBox.Multiline = true;
            this.errorMessageTextBox.Name = "errorMessageTextBox";
            this.errorMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorMessageTextBox.Size = new System.Drawing.Size(340, 74);
            this.errorMessageTextBox.TabIndex = 7;
            this.errorMessageTextBox.Tag = "DontTranslate";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(280, 374);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Enabled = false;
            this.sendButton.Image = global::DtPad.MessageBoxResource.ok;
            this.sendButton.Location = new System.Drawing.Point(171, 374);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(103, 23);
            this.sendButton.TabIndex = 12;
            this.sendButton.Text = "Send";
            this.sendButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sendButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // requiredFieldsLabel
            // 
            this.requiredFieldsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.requiredFieldsLabel.AutoSize = true;
            this.requiredFieldsLabel.Location = new System.Drawing.Point(12, 379);
            this.requiredFieldsLabel.Name = "requiredFieldsLabel";
            this.requiredFieldsLabel.Size = new System.Drawing.Size(84, 13);
            this.requiredFieldsLabel.TabIndex = 11;
            this.requiredFieldsLabel.Text = "* Required fields";
            // 
            // sendMeACopyCheckBox
            // 
            this.sendMeACopyCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendMeACopyCheckBox.AutoSize = true;
            this.sendMeACopyCheckBox.Location = new System.Drawing.Point(15, 345);
            this.sendMeACopyCheckBox.Name = "sendMeACopyCheckBox";
            this.sendMeACopyCheckBox.Size = new System.Drawing.Size(103, 17);
            this.sendMeACopyCheckBox.TabIndex = 10;
            this.sendMeACopyCheckBox.Text = "Send me a copy";
            this.sendMeACopyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReportBug
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(367, 407);
            this.Controls.Add(this.sendMeACopyCheckBox);
            this.Controls.Add(this.requiredFieldsLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.errorMessageTextBox);
            this.Controls.Add(this.areaComboBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.errorMessageLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.areaLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportBug";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bug Report";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ReportBug_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label areaLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label errorMessageLabel;
        internal System.Windows.Forms.TextBox nameTextBox;
        internal System.Windows.Forms.TextBox emailTextBox;
        internal System.Windows.Forms.TextBox descriptionTextBox;
        internal System.Windows.Forms.ComboBox areaComboBox;
        internal System.Windows.Forms.TextBox errorMessageTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label requiredFieldsLabel;
        internal System.Windows.Forms.CheckBox sendMeACopyCheckBox;
    }
}
