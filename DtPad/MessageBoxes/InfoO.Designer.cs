namespace DtPad.MessageBoxes
{
    partial class InfoO
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
            this.infoPictureBox = new System.Windows.Forms.PictureBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.infoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPictureBox
            // 
            this.infoPictureBox.Image = global::DtPad.MessageBoxResource.info;
            this.infoPictureBox.Location = new System.Drawing.Point(13, 13);
            this.infoPictureBox.Name = "infoPictureBox";
            this.infoPictureBox.Size = new System.Drawing.Size(50, 50);
            this.infoPictureBox.TabIndex = 0;
            this.infoPictureBox.TabStop = false;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(69, 13);
            this.infoLabel.MaximumSize = new System.Drawing.Size(550, 75);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(50, 13);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "infoLabel";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(260, 67);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // InfoO
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(347, 102);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.infoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoO";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Information";
            ((System.ComponentModel.ISupportInitialize)(this.infoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox infoPictureBox;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button okButton;
    }
}
