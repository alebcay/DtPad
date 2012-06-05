namespace DtHelp
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.titleLabel = new System.Windows.Forms.Label();
            this.versionLabel1 = new System.Windows.Forms.Label();
            this.createdByLabel1 = new System.Windows.Forms.Label();
            this.emailPictureBox = new System.Windows.Forms.PictureBox();
            this.websiteLabel1 = new System.Windows.Forms.Label();
            this.websitePictureBox = new System.Windows.Forms.PictureBox();
            this.rssPictureBox = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.createdByLabel = new System.Windows.Forms.Label();
            this.websiteLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.contentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.aboutToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.emailPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.websitePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rssPictureBox)).BeginInit();
            this.contentContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(143, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(56, 16);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "DtHelp";
            // 
            // versionLabel1
            // 
            this.versionLabel1.AutoSize = true;
            this.versionLabel1.Location = new System.Drawing.Point(143, 40);
            this.versionLabel1.Name = "versionLabel1";
            this.versionLabel1.Size = new System.Drawing.Size(48, 13);
            this.versionLabel1.TabIndex = 1;
            this.versionLabel1.Text = "Version: ";
            // 
            // createdByLabel1
            // 
            this.createdByLabel1.AutoSize = true;
            this.createdByLabel1.Location = new System.Drawing.Point(143, 70);
            this.createdByLabel1.Name = "createdByLabel1";
            this.createdByLabel1.Size = new System.Drawing.Size(61, 13);
            this.createdByLabel1.TabIndex = 3;
            this.createdByLabel1.Text = "Created by:";
            // 
            // emailPictureBox
            // 
            this.emailPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emailPictureBox.Image = global::DtHelp.ToolbarResource.email;
            this.emailPictureBox.InitialImage = null;
            this.emailPictureBox.Location = new System.Drawing.Point(328, 70);
            this.emailPictureBox.Name = "emailPictureBox";
            this.emailPictureBox.Size = new System.Drawing.Size(16, 16);
            this.emailPictureBox.TabIndex = 3;
            this.emailPictureBox.TabStop = false;
            this.aboutToolTip.SetToolTip(this.emailPictureBox, "Write an e-mail to DtPad\'s author");
            this.emailPictureBox.Click += new System.EventHandler(this.emailPictureBox_Click);
            // 
            // websiteLabel1
            // 
            this.websiteLabel1.AutoSize = true;
            this.websiteLabel1.Location = new System.Drawing.Point(143, 100);
            this.websiteLabel1.Name = "websiteLabel1";
            this.websiteLabel1.Size = new System.Drawing.Size(49, 13);
            this.websiteLabel1.TabIndex = 5;
            this.websiteLabel1.Text = "Website:";
            // 
            // websitePictureBox
            // 
            this.websitePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.websitePictureBox.Image = global::DtHelp.ToolbarResource.home;
            this.websitePictureBox.InitialImage = null;
            this.websitePictureBox.Location = new System.Drawing.Point(321, 100);
            this.websitePictureBox.Name = "websitePictureBox";
            this.websitePictureBox.Size = new System.Drawing.Size(16, 16);
            this.websitePictureBox.TabIndex = 5;
            this.websitePictureBox.TabStop = false;
            this.aboutToolTip.SetToolTip(this.websitePictureBox, "Visit DtPad\'s author homepage");
            this.websitePictureBox.Click += new System.EventHandler(this.websitePictureBox_Click);
            // 
            // rssPictureBox
            // 
            this.rssPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rssPictureBox.Image = global::DtHelp.ToolbarResource.rss;
            this.rssPictureBox.InitialImage = null;
            this.rssPictureBox.Location = new System.Drawing.Point(343, 100);
            this.rssPictureBox.Name = "rssPictureBox";
            this.rssPictureBox.Size = new System.Drawing.Size(16, 16);
            this.rssPictureBox.TabIndex = 6;
            this.rssPictureBox.TabStop = false;
            this.aboutToolTip.SetToolTip(this.rssPictureBox, "Read RSS feed of diariotraduttore.com");
            this.rssPictureBox.Click += new System.EventHandler(this.rssPictureBox_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(215, 39);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(67, 13);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "versionLabel";
            // 
            // createdByLabel
            // 
            this.createdByLabel.AutoSize = true;
            this.createdByLabel.Location = new System.Drawing.Point(215, 70);
            this.createdByLabel.Name = "createdByLabel";
            this.createdByLabel.Size = new System.Drawing.Size(107, 13);
            this.createdByLabel.TabIndex = 4;
            this.createdByLabel.Text = "Marco \"Cav\" Macciò";
            // 
            // websiteLabel
            // 
            this.websiteLabel.AutoSize = true;
            this.websiteLabel.Location = new System.Drawing.Point(215, 100);
            this.websiteLabel.Name = "websiteLabel";
            this.websiteLabel.Size = new System.Drawing.Size(100, 13);
            this.websiteLabel.TabIndex = 6;
            this.websiteLabel.Text = "diariotraduttore.com";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.descriptionTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.descriptionTextBox.Location = new System.Drawing.Point(146, 130);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(275, 95);
            this.descriptionTextBox.TabIndex = 7;
            this.descriptionTextBox.TabStop = false;
            // 
            // contentContextMenuStrip
            // 
            this.contentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.toolStripSeparator29,
            this.selectAllToolStripMenuItem});
            this.contentContextMenuStrip.Name = "searchContextMenuStrip";
            this.contentContextMenuStrip.Size = new System.Drawing.Size(123, 54);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DtHelp.ToolbarResource.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(119, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoPictureBox.Image = global::DtHelp.WindowResource.banner_vertical;
            this.logoPictureBox.InitialImage = null;
            this.logoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(125, 213);
            this.logoPictureBox.TabIndex = 11;
            this.logoPictureBox.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(346, 246);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // About
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 281);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.websiteLabel);
            this.Controls.Add(this.createdByLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.rssPictureBox);
            this.Controls.Add(this.websitePictureBox);
            this.Controls.Add(this.websiteLabel1);
            this.Controls.Add(this.emailPictureBox);
            this.Controls.Add(this.createdByLabel1);
            this.Controls.Add(this.versionLabel1);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.emailPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.websitePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rssPictureBox)).EndInit();
            this.contentContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label versionLabel1;
        private System.Windows.Forms.Label createdByLabel1;
        private System.Windows.Forms.PictureBox emailPictureBox;
        private System.Windows.Forms.Label websiteLabel1;
        private System.Windows.Forms.PictureBox websitePictureBox;
        private System.Windows.Forms.PictureBox rssPictureBox;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label createdByLabel;
        private System.Windows.Forms.Label websiteLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ToolTip aboutToolTip;
        internal System.Windows.Forms.ContextMenuStrip contentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    }
}
