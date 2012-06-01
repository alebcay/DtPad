namespace DtPad
{
    partial class UrlEncode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrlEncode));
            this.stringToEncodeTextBox = new System.Windows.Forms.TextBox();
            this.contentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.encodedURLTextBox = new System.Windows.Forms.TextBox();
            this.stringToEncodeLabel = new System.Windows.Forms.Label();
            this.encodedURLLabel = new System.Windows.Forms.Label();
            this.urlEncodeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.encodeButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.contentContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // stringToEncodeTextBox
            // 
            this.stringToEncodeTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.stringToEncodeTextBox.Location = new System.Drawing.Point(15, 25);
            this.stringToEncodeTextBox.Multiline = true;
            this.stringToEncodeTextBox.Name = "stringToEncodeTextBox";
            this.stringToEncodeTextBox.Size = new System.Drawing.Size(432, 72);
            this.stringToEncodeTextBox.TabIndex = 1;
            // 
            // contentContextMenuStrip
            // 
            this.contentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem2});
            this.contentContextMenuStrip.Name = "searchContextMenuStrip";
            this.contentContextMenuStrip.Size = new System.Drawing.Size(129, 148);
            this.contentContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contentContextMenuStrip_Opening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::DtPad.ToolbarResource.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.cutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::DtPad.ToolbarResource.copy;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(DtPad.Customs.CustomEvents.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::DtPad.ToolbarResource.paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(125, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem2.Text = "Select All";
            this.toolStripMenuItem2.Click += new System.EventHandler(DtPad.Customs.CustomEvents.selectAllToolStripMenuItem_Click);
            // 
            // encodedURLTextBox
            // 
            this.encodedURLTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.encodedURLTextBox.Location = new System.Drawing.Point(12, 132);
            this.encodedURLTextBox.Multiline = true;
            this.encodedURLTextBox.Name = "encodedURLTextBox";
            this.encodedURLTextBox.Size = new System.Drawing.Size(435, 72);
            this.encodedURLTextBox.TabIndex = 3;
            // 
            // stringToEncodeLabel
            // 
            this.stringToEncodeLabel.AutoSize = true;
            this.stringToEncodeLabel.Location = new System.Drawing.Point(12, 9);
            this.stringToEncodeLabel.Name = "stringToEncodeLabel";
            this.stringToEncodeLabel.Size = new System.Drawing.Size(79, 13);
            this.stringToEncodeLabel.TabIndex = 0;
            this.stringToEncodeLabel.Text = "Decoded URL:";
            // 
            // encodedURLLabel
            // 
            this.encodedURLLabel.AutoSize = true;
            this.encodedURLLabel.Location = new System.Drawing.Point(12, 116);
            this.encodedURLLabel.Name = "encodedURLLabel";
            this.encodedURLLabel.Size = new System.Drawing.Size(78, 13);
            this.encodedURLLabel.TabIndex = 2;
            this.encodedURLLabel.Text = "Encoded URL:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(372, 220);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Close";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // encodeButton
            // 
            this.encodeButton.Image = global::DtPad.ToolbarResource._switch;
            this.encodeButton.Location = new System.Drawing.Point(424, 103);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(23, 23);
            this.encodeButton.TabIndex = 5;
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
            // 
            // decodeButton
            // 
            this.decodeButton.Image = global::DtPad.ToolbarResource.switch_b;
            this.decodeButton.Location = new System.Drawing.Point(395, 103);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(23, 23);
            this.decodeButton.TabIndex = 4;
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // UrlEncode
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 255);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.encodeButton);
            this.Controls.Add(this.stringToEncodeTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.stringToEncodeLabel);
            this.Controls.Add(this.encodedURLTextBox);
            this.Controls.Add(this.encodedURLLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrlEncode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "URL Encoder";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.UrlEncode_HelpButtonClicked);
            this.contentContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox stringToEncodeTextBox;
        private System.Windows.Forms.TextBox encodedURLTextBox;
        private System.Windows.Forms.Label stringToEncodeLabel;
        private System.Windows.Forms.Label encodedURLLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.ToolTip urlEncodeToolTip;
        private System.Windows.Forms.ContextMenuStrip contentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button decodeButton;
    }
}
