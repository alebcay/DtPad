namespace DtHelp.MessageBoxes
{
    partial class AlertO
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
            this.alertPictureBox = new System.Windows.Forms.PictureBox();
            this.alertLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.alertPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // alertPictureBox
            // 
            this.alertPictureBox.Image = global::DtHelp.MessageBoxResource.warning;
            this.alertPictureBox.Location = new System.Drawing.Point(13, 13);
            this.alertPictureBox.Name = "alertPictureBox";
            this.alertPictureBox.Size = new System.Drawing.Size(50, 50);
            this.alertPictureBox.TabIndex = 0;
            this.alertPictureBox.TabStop = false;
            // 
            // alertLabel
            // 
            this.alertLabel.AutoSize = true;
            this.alertLabel.Location = new System.Drawing.Point(69, 13);
            this.alertLabel.MaximumSize = new System.Drawing.Size(550, 75);
            this.alertLabel.Name = "alertLabel";
            this.alertLabel.Size = new System.Drawing.Size(53, 13);
            this.alertLabel.TabIndex = 0;
            this.alertLabel.Text = "alertLabel";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(260, 67);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AlertO
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 102);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.alertLabel);
            this.Controls.Add(this.alertPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertO";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alert";
            ((System.ComponentModel.ISupportInitialize)(this.alertPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox alertPictureBox;
        private System.Windows.Forms.Label alertLabel;
        private System.Windows.Forms.Button okButton;
    }
}
