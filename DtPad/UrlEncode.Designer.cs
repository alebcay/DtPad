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
            this.encodedURLTextBox = new System.Windows.Forms.TextBox();
            this.stringToEncodeLabel = new System.Windows.Forms.Label();
            this.encodedURLLabel = new System.Windows.Forms.Label();
            this.urlEncodeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.encodeButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stringToEncodeTextBox
            // 
            this.stringToEncodeTextBox.Location = new System.Drawing.Point(15, 25);
            this.stringToEncodeTextBox.Multiline = true;
            this.stringToEncodeTextBox.Name = "stringToEncodeTextBox";
            this.stringToEncodeTextBox.Size = new System.Drawing.Size(432, 72);
            this.stringToEncodeTextBox.TabIndex = 1;
            this.stringToEncodeTextBox.Tag = "DontTranslate";
            // 
            // encodedURLTextBox
            // 
            this.encodedURLTextBox.Location = new System.Drawing.Point(12, 132);
            this.encodedURLTextBox.Multiline = true;
            this.encodedURLTextBox.Name = "encodedURLTextBox";
            this.encodedURLTextBox.Size = new System.Drawing.Size(435, 72);
            this.encodedURLTextBox.TabIndex = 3;
            this.encodedURLTextBox.Tag = "DontTranslate";
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
        private System.Windows.Forms.Button decodeButton;
    }
}
