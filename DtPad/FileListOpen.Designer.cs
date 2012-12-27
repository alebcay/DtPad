namespace DtPad
{
    partial class FileListOpen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileListOpen));
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.fileListLabel = new System.Windows.Forms.Label();
            this.pasteFromClipboardButton = new System.Windows.Forms.Button();
            this.fileListOpenToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contentTextBox
            // 
            this.contentTextBox.AcceptsReturn = true;
            this.contentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.contentTextBox.Location = new System.Drawing.Point(12, 25);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.contentTextBox.Size = new System.Drawing.Size(412, 174);
            this.contentTextBox.TabIndex = 1;
            this.contentTextBox.Tag = "DontTranslate";
            this.contentTextBox.TextChanged += new System.EventHandler(this.contentTextBox_TextChanged);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(349, 213);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Cancel";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // fileListLabel
            // 
            this.fileListLabel.AutoSize = true;
            this.fileListLabel.Location = new System.Drawing.Point(12, 9);
            this.fileListLabel.Name = "fileListLabel";
            this.fileListLabel.Size = new System.Drawing.Size(234, 13);
            this.fileListLabel.TabIndex = 0;
            this.fileListLabel.Text = "Copy here the file list to open (each file in a line):";
            // 
            // pasteFromClipboardButton
            // 
            this.pasteFromClipboardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pasteFromClipboardButton.Image = global::DtPad.ToolbarResource.paste;
            this.pasteFromClipboardButton.Location = new System.Drawing.Point(15, 213);
            this.pasteFromClipboardButton.Name = "pasteFromClipboardButton";
            this.pasteFromClipboardButton.Size = new System.Drawing.Size(23, 23);
            this.pasteFromClipboardButton.TabIndex = 2;
            this.fileListOpenToolTip.SetToolTip(this.pasteFromClipboardButton, "Paste from clipboard");
            this.pasteFromClipboardButton.UseVisualStyleBackColor = true;
            this.pasteFromClipboardButton.Click += new System.EventHandler(this.pasteFromClipboardButton_Click);
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Enabled = false;
            this.openButton.Image = global::DtPad.MessageBoxResource.ok;
            this.openButton.Location = new System.Drawing.Point(268, 213);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "Open";
            this.openButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.openButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // FileListOpen
            // 
            this.AcceptButton = this.openButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(436, 248);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.pasteFromClipboardButton);
            this.Controls.Add(this.fileListLabel);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.closeButton);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FileListOpen";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File List Opening";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label fileListLabel;
        private System.Windows.Forms.Button pasteFromClipboardButton;
        private System.Windows.Forms.ToolTip fileListOpenToolTip;
        private System.Windows.Forms.Button openButton;
    }
}
