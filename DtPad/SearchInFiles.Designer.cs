﻿namespace DtPad
{
    internal partial class SearchInFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchInFiles));
            this.textToSearchLabel = new System.Windows.Forms.Label();
            this.textToSearchTextBox = new System.Windows.Forms.TextBox();
            this.filenamePatternTextBox = new System.Windows.Forms.TextBox();
            this.filenamePatternLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.searchFolderButton = new System.Windows.Forms.Button();
            this.searchFolderLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.searchSubdirsCheckBox = new System.Windows.Forms.CheckBox();
            this.searchInProgressLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.searchInProgressPictureBox = new System.Windows.Forms.PictureBox();
            this.searchFolderComboBox = new DtPad.Customs.CustomComboBox();
            this.hiddenFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.filenamePatternPictureBox = new System.Windows.Forms.PictureBox();
            this.searchInFilesToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.exclusionPatternPictureBox = new System.Windows.Forms.PictureBox();
            this.caseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.resizeButton = new System.Windows.Forms.Button();
            this.exclusionPatternTextBox = new System.Windows.Forms.TextBox();
            this.exclusionPatternLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.searchInProgressPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filenamePatternPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exclusionPatternPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textToSearchLabel
            // 
            this.textToSearchLabel.AutoSize = true;
            this.textToSearchLabel.Location = new System.Drawing.Point(12, 15);
            this.textToSearchLabel.Name = "textToSearchLabel";
            this.textToSearchLabel.Size = new System.Drawing.Size(78, 13);
            this.textToSearchLabel.TabIndex = 0;
            this.textToSearchLabel.Text = "Text to search:";
            // 
            // textToSearchTextBox
            // 
            this.textToSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textToSearchTextBox.Location = new System.Drawing.Point(136, 12);
            this.textToSearchTextBox.Name = "textToSearchTextBox";
            this.textToSearchTextBox.Size = new System.Drawing.Size(362, 20);
            this.textToSearchTextBox.TabIndex = 1;
            this.textToSearchTextBox.Tag = "DontTranslate";
            // 
            // filenamePatternTextBox
            // 
            this.filenamePatternTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenamePatternTextBox.Location = new System.Drawing.Point(136, 38);
            this.filenamePatternTextBox.Name = "filenamePatternTextBox";
            this.filenamePatternTextBox.Size = new System.Drawing.Size(340, 20);
            this.filenamePatternTextBox.TabIndex = 3;
            this.filenamePatternTextBox.Tag = "DontTranslate";
            this.filenamePatternTextBox.Text = "*.*";
            // 
            // filenamePatternLabel
            // 
            this.filenamePatternLabel.AutoSize = true;
            this.filenamePatternLabel.Location = new System.Drawing.Point(12, 41);
            this.filenamePatternLabel.Name = "filenamePatternLabel";
            this.filenamePatternLabel.Size = new System.Drawing.Size(88, 13);
            this.filenamePatternLabel.TabIndex = 2;
            this.filenamePatternLabel.Text = "Filename pattern:";
            // 
            // searchFolderButton
            // 
            this.searchFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchFolderButton.Location = new System.Drawing.Point(468, 88);
            this.searchFolderButton.Name = "searchFolderButton";
            this.searchFolderButton.Size = new System.Drawing.Size(30, 23);
            this.searchFolderButton.TabIndex = 8;
            this.searchFolderButton.Text = "...";
            this.searchFolderButton.UseVisualStyleBackColor = true;
            this.searchFolderButton.Click += new System.EventHandler(this.searchFolderButton_Click);
            // 
            // searchFolderLabel
            // 
            this.searchFolderLabel.AutoSize = true;
            this.searchFolderLabel.Location = new System.Drawing.Point(12, 93);
            this.searchFolderLabel.Name = "searchFolderLabel";
            this.searchFolderLabel.Size = new System.Drawing.Size(73, 13);
            this.searchFolderLabel.TabIndex = 6;
            this.searchFolderLabel.Text = "Search folder:";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(324, 196);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(98, 23);
            this.okButton.TabIndex = 13;
            this.okButton.Text = "Search";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // searchSubdirsCheckBox
            // 
            this.searchSubdirsCheckBox.AutoSize = true;
            this.searchSubdirsCheckBox.Checked = true;
            this.searchSubdirsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchSubdirsCheckBox.Location = new System.Drawing.Point(136, 116);
            this.searchSubdirsCheckBox.Name = "searchSubdirsCheckBox";
            this.searchSubdirsCheckBox.Size = new System.Drawing.Size(139, 17);
            this.searchSubdirsCheckBox.TabIndex = 9;
            this.searchSubdirsCheckBox.Text = "Search in subdirectories";
            this.searchSubdirsCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchInProgressLabel
            // 
            this.searchInProgressLabel.AutoSize = true;
            this.searchInProgressLabel.Location = new System.Drawing.Point(38, 201);
            this.searchInProgressLabel.Name = "searchInProgressLabel";
            this.searchInProgressLabel.Size = new System.Drawing.Size(104, 13);
            this.searchInProgressLabel.TabIndex = 12;
            this.searchInProgressLabel.Text = "Search in progress...";
            this.searchInProgressLabel.Visible = false;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(424, 196);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 14;
            this.closeButton.Text = "Close";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // searchInProgressPictureBox
            // 
            this.searchInProgressPictureBox.Image = global::DtPad.ToolbarResource.loading;
            this.searchInProgressPictureBox.Location = new System.Drawing.Point(15, 199);
            this.searchInProgressPictureBox.Name = "searchInProgressPictureBox";
            this.searchInProgressPictureBox.Size = new System.Drawing.Size(16, 16);
            this.searchInProgressPictureBox.TabIndex = 11;
            this.searchInProgressPictureBox.TabStop = false;
            this.searchInProgressPictureBox.Tag = "DontTranslate";
            this.searchInProgressPictureBox.Visible = false;
            // 
            // searchFolderComboBox
            // 
            this.searchFolderComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchFolderComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchFolderComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.searchFolderComboBox.CustomContextMenuStrip = null;
            this.searchFolderComboBox.FormattingEnabled = true;
            this.searchFolderComboBox.Location = new System.Drawing.Point(136, 90);
            this.searchFolderComboBox.Name = "searchFolderComboBox";
            this.searchFolderComboBox.Size = new System.Drawing.Size(326, 21);
            this.searchFolderComboBox.TabIndex = 7;
            this.searchFolderComboBox.TextChanged += new System.EventHandler(this.searchFolderComboBox_TextChanged);
            // 
            // hiddenFilesCheckBox
            // 
            this.hiddenFilesCheckBox.AutoSize = true;
            this.hiddenFilesCheckBox.Location = new System.Drawing.Point(136, 139);
            this.hiddenFilesCheckBox.Name = "hiddenFilesCheckBox";
            this.hiddenFilesCheckBox.Size = new System.Drawing.Size(117, 17);
            this.hiddenFilesCheckBox.TabIndex = 10;
            this.hiddenFilesCheckBox.Text = "Include hidden files";
            this.hiddenFilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // filenamePatternPictureBox
            // 
            this.filenamePatternPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filenamePatternPictureBox.Image = global::DtPad.ToolbarResource.info_blue;
            this.filenamePatternPictureBox.Location = new System.Drawing.Point(482, 40);
            this.filenamePatternPictureBox.Name = "filenamePatternPictureBox";
            this.filenamePatternPictureBox.Size = new System.Drawing.Size(16, 16);
            this.filenamePatternPictureBox.TabIndex = 12;
            this.filenamePatternPictureBox.TabStop = false;
            this.searchInFilesToolTip.SetToolTip(this.filenamePatternPictureBox, "Insert patterns separated by commas without spaces (ie. *.txt,*.dts)");
            // 
            // exclusionPatternPictureBox
            // 
            this.exclusionPatternPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exclusionPatternPictureBox.Image = global::DtPad.ToolbarResource.info_blue;
            this.exclusionPatternPictureBox.Location = new System.Drawing.Point(482, 66);
            this.exclusionPatternPictureBox.Name = "exclusionPatternPictureBox";
            this.exclusionPatternPictureBox.Size = new System.Drawing.Size(16, 16);
            this.exclusionPatternPictureBox.TabIndex = 17;
            this.exclusionPatternPictureBox.TabStop = false;
            this.searchInFilesToolTip.SetToolTip(this.exclusionPatternPictureBox, "Insert patterns separated by commas without spaces (ie. *.txt,*.dts)");
            // 
            // caseSensitiveCheckBox
            // 
            this.caseSensitiveCheckBox.AutoSize = true;
            this.caseSensitiveCheckBox.Location = new System.Drawing.Point(136, 162);
            this.caseSensitiveCheckBox.Name = "caseSensitiveCheckBox";
            this.caseSensitiveCheckBox.Size = new System.Drawing.Size(94, 17);
            this.caseSensitiveCheckBox.TabIndex = 11;
            this.caseSensitiveCheckBox.Text = "Case sensitive";
            this.caseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // resizeButton
            // 
            this.resizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resizeButton.Image = global::DtPad.ToolbarResource.arrow_right;
            this.resizeButton.Location = new System.Drawing.Point(475, 139);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(23, 23);
            this.resizeButton.TabIndex = 15;
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // exclusionPatternTextBox
            // 
            this.exclusionPatternTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exclusionPatternTextBox.Location = new System.Drawing.Point(136, 64);
            this.exclusionPatternTextBox.Name = "exclusionPatternTextBox";
            this.exclusionPatternTextBox.Size = new System.Drawing.Size(340, 20);
            this.exclusionPatternTextBox.TabIndex = 5;
            this.exclusionPatternTextBox.Tag = "DontTranslate";
            // 
            // exclusionPatternLabel
            // 
            this.exclusionPatternLabel.AutoSize = true;
            this.exclusionPatternLabel.Location = new System.Drawing.Point(12, 67);
            this.exclusionPatternLabel.Name = "exclusionPatternLabel";
            this.exclusionPatternLabel.Size = new System.Drawing.Size(91, 13);
            this.exclusionPatternLabel.TabIndex = 4;
            this.exclusionPatternLabel.Text = "Exclusion pattern:";
            // 
            // SearchInFiles
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(511, 232);
            this.Controls.Add(this.exclusionPatternPictureBox);
            this.Controls.Add(this.exclusionPatternTextBox);
            this.Controls.Add(this.exclusionPatternLabel);
            this.Controls.Add(this.filenamePatternPictureBox);
            this.Controls.Add(this.caseSensitiveCheckBox);
            this.Controls.Add(this.resizeButton);
            this.Controls.Add(this.searchInProgressPictureBox);
            this.Controls.Add(this.hiddenFilesCheckBox);
            this.Controls.Add(this.searchFolderComboBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.searchInProgressLabel);
            this.Controls.Add(this.searchSubdirsCheckBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.filenamePatternTextBox);
            this.Controls.Add(this.searchFolderLabel);
            this.Controls.Add(this.searchFolderButton);
            this.Controls.Add(this.filenamePatternLabel);
            this.Controls.Add(this.textToSearchTextBox);
            this.Controls.Add(this.textToSearchLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchInFiles";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search In Files";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SearchInFiles_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchInFiles_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.searchInProgressPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filenamePatternPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exclusionPatternPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textToSearchLabel;
        private System.Windows.Forms.Label filenamePatternLabel;
        private System.Windows.Forms.Button searchFolderButton;
        private System.Windows.Forms.Label searchFolderLabel;
        internal System.Windows.Forms.TextBox textToSearchTextBox;
        internal System.Windows.Forms.TextBox filenamePatternTextBox;
        internal System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        internal System.Windows.Forms.CheckBox searchSubdirsCheckBox;
        private System.Windows.Forms.Label searchInProgressLabel;
        private System.Windows.Forms.PictureBox searchInProgressPictureBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button closeButton;
        internal Customs.CustomComboBox searchFolderComboBox;
        internal System.Windows.Forms.CheckBox hiddenFilesCheckBox;
        private System.Windows.Forms.PictureBox filenamePatternPictureBox;
        private System.Windows.Forms.ToolTip searchInFilesToolTip;
        internal System.Windows.Forms.CheckBox caseSensitiveCheckBox;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.PictureBox exclusionPatternPictureBox;
        internal System.Windows.Forms.TextBox exclusionPatternTextBox;
        private System.Windows.Forms.Label exclusionPatternLabel;
    }
}
