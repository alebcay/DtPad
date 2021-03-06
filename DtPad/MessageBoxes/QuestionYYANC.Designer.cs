namespace DtPad.MessageBoxes
{
    partial class QuestionYYANC
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
            this.questionPictureBox = new System.Windows.Forms.PictureBox();
            this.questionLabel = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.yesToAllButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.questionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // questionPictureBox
            // 
            this.questionPictureBox.Image = global::DtPad.MessageBoxResource.question;
            this.questionPictureBox.Location = new System.Drawing.Point(13, 13);
            this.questionPictureBox.Name = "questionPictureBox";
            this.questionPictureBox.Size = new System.Drawing.Size(50, 50);
            this.questionPictureBox.TabIndex = 0;
            this.questionPictureBox.TabStop = false;
            this.questionPictureBox.Tag = "DontTranslate";
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(69, 13);
            this.questionLabel.MaximumSize = new System.Drawing.Size(550, 75);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(73, 13);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Tag = "DontTranslate";
            this.questionLabel.Text = "questionLabel";
            // 
            // yesButton
            // 
            this.yesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.yesButton.Image = global::DtPad.MessageBoxResource.ok;
            this.yesButton.Location = new System.Drawing.Point(69, 67);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Yes";
            this.yesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // yesToAllButton
            // 
            this.yesToAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.yesToAllButton.Location = new System.Drawing.Point(150, 67);
            this.yesToAllButton.Name = "yesToAllButton";
            this.yesToAllButton.Size = new System.Drawing.Size(75, 23);
            this.yesToAllButton.TabIndex = 3;
            this.yesToAllButton.Text = "Yes To All";
            this.yesToAllButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.yesToAllButton.UseVisualStyleBackColor = true;
            this.yesToAllButton.Click += new System.EventHandler(this.yesToAllButton_Click);
            // 
            // noButton
            // 
            this.noButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.noButton.Location = new System.Drawing.Point(231, 67);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 2;
            this.noButton.Text = "No";
            this.noButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(312, 67);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // QuestionYYANC
            // 
            this.AcceptButton = this.yesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(399, 102);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesToAllButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.questionPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionYYANC";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Question";
            ((System.ComponentModel.ISupportInitialize)(this.questionPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox questionPictureBox;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Button yesButton;
		private System.Windows.Forms.Button yesToAllButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
