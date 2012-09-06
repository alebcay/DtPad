namespace DtPadUpdater.MessageBoxes
{
    partial class ErrorO
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
            this.errorLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.copyErrorMessageToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.copyErrorDescriptionPictureBox = new System.Windows.Forms.PictureBox();
            this.errorPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.copyErrorDescriptionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(69, 13);
            this.errorLabel.MaximumSize = new System.Drawing.Size(550, 75);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(54, 13);
            this.errorLabel.TabIndex = 0;
            this.errorLabel.Text = "errorLabel";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(260, 67);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // copyErrorDescriptionPictureBox
            // 
            this.copyErrorDescriptionPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.copyErrorDescriptionPictureBox.Image = global::DtPadUpdater.ImageResource.copy;
            this.copyErrorDescriptionPictureBox.Location = new System.Drawing.Point(13, 74);
            this.copyErrorDescriptionPictureBox.Name = "copyErrorDescriptionPictureBox";
            this.copyErrorDescriptionPictureBox.Size = new System.Drawing.Size(16, 16);
            this.copyErrorDescriptionPictureBox.TabIndex = 4;
            this.copyErrorDescriptionPictureBox.TabStop = false;
            this.copyErrorDescriptionPictureBox.Click += new System.EventHandler(this.copyErrorDescriptionPictureBox_Click);
            // 
            // errorPictureBox
            // 
            this.errorPictureBox.Image = global::DtPadUpdater.ImageResource.error;
            this.errorPictureBox.Location = new System.Drawing.Point(13, 13);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(50, 50);
            this.errorPictureBox.TabIndex = 0;
            this.errorPictureBox.TabStop = false;
            // 
            // ErrorO
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 102);
            this.Controls.Add(this.copyErrorDescriptionPictureBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.errorPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorO";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            ((System.ComponentModel.ISupportInitialize)(this.copyErrorDescriptionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox errorPictureBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox copyErrorDescriptionPictureBox;
        private System.Windows.Forms.ToolTip copyErrorMessageToolTip;
    }
}
