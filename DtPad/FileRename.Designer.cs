namespace DtPad
{
    partial class FileRename
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileRename));
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileNameValueLabel = new System.Windows.Forms.TextBox();
            this.renameToLabel = new System.Windows.Forms.Label();
            this.renameToTextBox = new System.Windows.Forms.TextBox();
            this.renameButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.folderValueLabel = new System.Windows.Forms.TextBox();
            this.folderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(12, 9);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(55, 13);
            this.fileNameLabel.TabIndex = 0;
            this.fileNameLabel.Text = "File name:";
            // 
            // fileNameValueLabel
            // 
            this.fileNameValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameValueLabel.BackColor = System.Drawing.SystemColors.Control;
            this.fileNameValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileNameValueLabel.Location = new System.Drawing.Point(80, 9);
            this.fileNameValueLabel.Name = "fileNameValueLabel";
            this.fileNameValueLabel.ReadOnly = true;
            this.fileNameValueLabel.Size = new System.Drawing.Size(320, 13);
            this.fileNameValueLabel.TabIndex = 1;
            this.fileNameValueLabel.Tag = "DontTranslate";
            this.fileNameValueLabel.Text = "fileNameValueLabel";
            // 
            // renameToLabel
            // 
            this.renameToLabel.AutoSize = true;
            this.renameToLabel.Location = new System.Drawing.Point(12, 56);
            this.renameToLabel.Name = "renameToLabel";
            this.renameToLabel.Size = new System.Drawing.Size(62, 13);
            this.renameToLabel.TabIndex = 4;
            this.renameToLabel.Text = "Rename to:";
            // 
            // renameToTextBox
            // 
            this.renameToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renameToTextBox.Location = new System.Drawing.Point(80, 53);
            this.renameToTextBox.Name = "renameToTextBox";
            this.renameToTextBox.Size = new System.Drawing.Size(327, 20);
            this.renameToTextBox.TabIndex = 5;
            this.renameToTextBox.Tag = "DontTranslate";
            this.renameToTextBox.TextChanged += new System.EventHandler(this.renameToTextBox_TextChanged);
            // 
            // renameButton
            // 
            this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.renameButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.renameButton.Enabled = false;
            this.renameButton.Image = global::DtPad.MessageBoxResource.ok;
            this.renameButton.Location = new System.Drawing.Point(214, 87);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(116, 23);
            this.renameButton.TabIndex = 6;
            this.renameButton.Text = "Rename";
            this.renameButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.renameButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(332, 87);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // folderValueLabel
            // 
            this.folderValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderValueLabel.BackColor = System.Drawing.SystemColors.Control;
            this.folderValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.folderValueLabel.Location = new System.Drawing.Point(80, 31);
            this.folderValueLabel.Name = "folderValueLabel";
            this.folderValueLabel.ReadOnly = true;
            this.folderValueLabel.Size = new System.Drawing.Size(320, 13);
            this.folderValueLabel.TabIndex = 3;
            this.folderValueLabel.Tag = "DontTranslate";
            this.folderValueLabel.Text = "folderValueLabel";
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(12, 31);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(39, 13);
            this.folderLabel.TabIndex = 2;
            this.folderLabel.Text = "Folder:";
            // 
            // FileRename
            // 
            this.AcceptButton = this.renameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(419, 122);
            this.Controls.Add(this.folderValueLabel);
            this.Controls.Add(this.folderLabel);
            this.Controls.Add(this.renameToTextBox);
            this.Controls.Add(this.renameToLabel);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.fileNameValueLabel);
            this.Controls.Add(this.fileNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileRename";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Rename";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FileRename_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox fileNameValueLabel;
        private System.Windows.Forms.Label renameToLabel;
        private System.Windows.Forms.TextBox renameToTextBox;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox folderValueLabel;
        private System.Windows.Forms.Label folderLabel;
    }
}
