namespace DtPad
{
    partial class VersionCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionCheck));
            this.statusLabel1 = new System.Windows.Forms.Label();
            this.checkProgressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.updateButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.warningPictureBox = new System.Windows.Forms.PictureBox();
            this.warningToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.newVersionPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.checkProgressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newVersionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // statusLabel1
            // 
            this.statusLabel1.AutoSize = true;
            this.statusLabel1.Location = new System.Drawing.Point(13, 13);
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(40, 13);
            this.statusLabel1.TabIndex = 0;
            this.statusLabel1.Text = "Status:";
            // 
            // checkProgressBar
            // 
            this.checkProgressBar.Location = new System.Drawing.Point(13, 40);
            this.checkProgressBar.Name = "checkProgressBar";
            this.checkProgressBar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkProgressBar.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.checkProgressBar.Properties.ShowTitle = true;
            this.checkProgressBar.Properties.Step = 25;
            this.checkProgressBar.Size = new System.Drawing.Size(267, 23);
            this.checkProgressBar.TabIndex = 2;
            // 
            // updateButton
            // 
            this.updateButton.Enabled = false;
            this.updateButton.Image = global::DtPad.MessageBoxResource.ok;
            this.updateButton.Location = new System.Drawing.Point(124, 79);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Update";
            this.updateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(55, 13);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(61, 13);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "statusLabel";
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(205, 79);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // warningPictureBox
            // 
            this.warningPictureBox.Cursor = System.Windows.Forms.Cursors.Help;
            this.warningPictureBox.Image = global::DtPad.ToolbarResource.question_red;
            this.warningPictureBox.InitialImage = null;
            this.warningPictureBox.Location = new System.Drawing.Point(16, 84);
            this.warningPictureBox.Name = "warningPictureBox";
            this.warningPictureBox.Size = new System.Drawing.Size(16, 16);
            this.warningPictureBox.TabIndex = 6;
            this.warningPictureBox.TabStop = false;
            this.warningToolTip.SetToolTip(this.warningPictureBox, "If you are using a proxy, try to set it on options window");
            this.warningPictureBox.Visible = false;
            this.warningPictureBox.MouseLeave += new System.EventHandler(this.warningPictureBox_MouseLeave);
            // 
            // newVersionPictureBox
            // 
            this.newVersionPictureBox.Image = global::DtPad.ToolbarResource.info_blue;
            this.newVersionPictureBox.InitialImage = null;
            this.newVersionPictureBox.Location = new System.Drawing.Point(264, 10);
            this.newVersionPictureBox.Name = "newVersionPictureBox";
            this.newVersionPictureBox.Size = new System.Drawing.Size(16, 16);
            this.newVersionPictureBox.TabIndex = 7;
            this.newVersionPictureBox.TabStop = false;
            this.newVersionPictureBox.Visible = false;
            // 
            // VersionCheck
            // 
            this.AcceptButton = this.updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(292, 114);
            this.Controls.Add(this.newVersionPictureBox);
            this.Controls.Add(this.warningPictureBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.checkProgressBar);
            this.Controls.Add(this.statusLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionCheck";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Version Check";
            ((System.ComponentModel.ISupportInitialize)(this.checkProgressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newVersionPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel1;
        private DevExpress.XtraEditors.ProgressBarControl checkProgressBar;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.PictureBox warningPictureBox;
        private System.Windows.Forms.ToolTip warningToolTip;
        private System.Windows.Forms.PictureBox newVersionPictureBox;
    }
}
