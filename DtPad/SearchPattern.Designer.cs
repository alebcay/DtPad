namespace DtPad
{
    partial class SearchPattern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchPattern));
            this.regularExpressionLabel = new System.Windows.Forms.Label();
            this.historyComboBox = new System.Windows.Forms.ComboBox();
            this.regularExpressionTextBox = new System.Windows.Forms.TextBox();
            this.historyLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.regularExpressionPictureBox = new System.Windows.Forms.PictureBox();
            this.searchPatternToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.clearHistoryButton = new System.Windows.Forms.Button();
            this.predefinedLabel = new System.Windows.Forms.Label();
            this.predefinedComboBox = new System.Windows.Forms.ComboBox();
            this.denyRegexCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.regularExpressionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // regularExpressionLabel
            // 
            this.regularExpressionLabel.AutoSize = true;
            this.regularExpressionLabel.Location = new System.Drawing.Point(12, 9);
            this.regularExpressionLabel.Name = "regularExpressionLabel";
            this.regularExpressionLabel.Size = new System.Drawing.Size(100, 13);
            this.regularExpressionLabel.TabIndex = 0;
            this.regularExpressionLabel.Text = "Regular expression:";
            // 
            // historyComboBox
            // 
            this.historyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.historyComboBox.FormattingEnabled = true;
            this.historyComboBox.Location = new System.Drawing.Point(12, 196);
            this.historyComboBox.Name = "historyComboBox";
            this.historyComboBox.Size = new System.Drawing.Size(323, 21);
            this.historyComboBox.TabIndex = 3;
            this.historyComboBox.Tag = "DontTranslate";
            this.historyComboBox.SelectedIndexChanged += new System.EventHandler(this.historyComboBox_SelectedIndexChanged);
            // 
            // regularExpressionTextBox
            // 
            this.regularExpressionTextBox.AcceptsReturn = true;
            this.regularExpressionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regularExpressionTextBox.Location = new System.Drawing.Point(12, 25);
            this.regularExpressionTextBox.Multiline = true;
            this.regularExpressionTextBox.Name = "regularExpressionTextBox";
            this.regularExpressionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.regularExpressionTextBox.Size = new System.Drawing.Size(352, 143);
            this.regularExpressionTextBox.TabIndex = 1;
            this.regularExpressionTextBox.Tag = "DontTranslate";
            this.regularExpressionTextBox.TextChanged += new System.EventHandler(this.regularExpressionTextBox_TextChanged);
            // 
            // historyLabel
            // 
            this.historyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.historyLabel.AutoSize = true;
            this.historyLabel.Location = new System.Drawing.Point(12, 180);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.Size = new System.Drawing.Size(42, 13);
            this.historyLabel.TabIndex = 2;
            this.historyLabel.Text = "History:";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Enabled = false;
            this.searchButton.Image = global::DtPad.MessageBoxResource.ok;
            this.searchButton.Location = new System.Drawing.Point(190, 280);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(93, 23);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = "Search";
            this.searchButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(289, 280);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Cancel";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // regularExpressionPictureBox
            // 
            this.regularExpressionPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.regularExpressionPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.regularExpressionPictureBox.Image = global::DtPad.ToolbarResource.info_blue;
            this.regularExpressionPictureBox.Location = new System.Drawing.Point(348, 6);
            this.regularExpressionPictureBox.Name = "regularExpressionPictureBox";
            this.regularExpressionPictureBox.Size = new System.Drawing.Size(16, 16);
            this.regularExpressionPictureBox.TabIndex = 14;
            this.regularExpressionPictureBox.TabStop = false;
            this.searchPatternToolTip.SetToolTip(this.regularExpressionPictureBox, "To know more about regular expressions, visit\r\nthis website: www.regular-expressi" +
        "ons.info");
            this.regularExpressionPictureBox.Click += new System.EventHandler(this.regularExpressionPictureBox_Click);
            // 
            // clearHistoryButton
            // 
            this.clearHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearHistoryButton.Image = global::DtPad.ToolbarResource.bin;
            this.clearHistoryButton.Location = new System.Drawing.Point(341, 194);
            this.clearHistoryButton.Name = "clearHistoryButton";
            this.clearHistoryButton.Size = new System.Drawing.Size(23, 23);
            this.clearHistoryButton.TabIndex = 4;
            this.searchPatternToolTip.SetToolTip(this.clearHistoryButton, "Clear");
            this.clearHistoryButton.UseVisualStyleBackColor = true;
            this.clearHistoryButton.Click += new System.EventHandler(this.clearHistoryButton_Click);
            // 
            // predefinedLabel
            // 
            this.predefinedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.predefinedLabel.AutoSize = true;
            this.predefinedLabel.Location = new System.Drawing.Point(12, 226);
            this.predefinedLabel.Name = "predefinedLabel";
            this.predefinedLabel.Size = new System.Drawing.Size(61, 13);
            this.predefinedLabel.TabIndex = 5;
            this.predefinedLabel.Text = "Predefined:";
            // 
            // predefinedComboBox
            // 
            this.predefinedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.predefinedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.predefinedComboBox.FormattingEnabled = true;
            this.predefinedComboBox.Items.AddRange(new object[] {
            global::DtPad.Languages.en.SearchPattern_historyComboBoxItems,
            "E-mail addresses",
            "IP addresses",
            "XML/HTML tags",
            "Capitalized words"});
            this.predefinedComboBox.Location = new System.Drawing.Point(87, 223);
            this.predefinedComboBox.Name = "predefinedComboBox";
            this.predefinedComboBox.Size = new System.Drawing.Size(248, 21);
            this.predefinedComboBox.TabIndex = 6;
            this.predefinedComboBox.Tag = "DontTranslate";
            this.predefinedComboBox.SelectedIndexChanged += new System.EventHandler(this.predefinedComboBox_SelectedIndexChanged);
            // 
            // denyRegexCheckBox
            // 
            this.denyRegexCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.denyRegexCheckBox.AutoSize = true;
            this.denyRegexCheckBox.Location = new System.Drawing.Point(15, 250);
            this.denyRegexCheckBox.Name = "denyRegexCheckBox";
            this.denyRegexCheckBox.Size = new System.Drawing.Size(139, 17);
            this.denyRegexCheckBox.TabIndex = 7;
            this.denyRegexCheckBox.Text = "Deny regular expression";
            this.denyRegexCheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(376, 314);
            this.Controls.Add(this.denyRegexCheckBox);
            this.Controls.Add(this.predefinedComboBox);
            this.Controls.Add(this.predefinedLabel);
            this.Controls.Add(this.clearHistoryButton);
            this.Controls.Add(this.regularExpressionPictureBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.historyLabel);
            this.Controls.Add(this.regularExpressionTextBox);
            this.Controls.Add(this.historyComboBox);
            this.Controls.Add(this.regularExpressionLabel);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(392, 352);
            this.Name = "SearchPattern";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search With Pattern";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SearchPattern_HelpButtonClicked);
            ((System.ComponentModel.ISupportInitialize)(this.regularExpressionPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label regularExpressionLabel;
        private System.Windows.Forms.TextBox regularExpressionTextBox;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.PictureBox regularExpressionPictureBox;
        private System.Windows.Forms.ToolTip searchPatternToolTip;
        internal System.Windows.Forms.ComboBox historyComboBox;
        private System.Windows.Forms.Button clearHistoryButton;
        private System.Windows.Forms.Label predefinedLabel;
        private System.Windows.Forms.ComboBox predefinedComboBox;
        private System.Windows.Forms.CheckBox denyRegexCheckBox;
    }
}
