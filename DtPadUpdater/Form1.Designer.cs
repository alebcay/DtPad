namespace DtPadUpdater
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.introPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.homePictureBox = new System.Windows.Forms.PictureBox();
            this.linkLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.updatePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.updateProgressBar = new System.Windows.Forms.ProgressBar();
            this.updateTextBox = new System.Windows.Forms.TextBox();
            this.contentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.whatIsInsideLabel = new System.Windows.Forms.Label();
            this.whatIsInsideTextBox = new System.Windows.Forms.TextBox();
            this.adminModeLabel = new System.Windows.Forms.Label();
            this.introPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homePictureBox)).BeginInit();
            this.updatePanel.SuspendLayout();
            this.contentContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // introPanel
            // 
            this.introPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.introPanel.Controls.Add(this.titleLabel);
            this.introPanel.Controls.Add(this.descriptionLabel);
            this.introPanel.Controls.Add(this.homePictureBox);
            this.introPanel.Controls.Add(this.linkLabel);
            this.introPanel.Location = new System.Drawing.Point(143, 12);
            this.introPanel.Name = "introPanel";
            this.introPanel.Size = new System.Drawing.Size(356, 282);
            this.introPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(3, 2);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(350, 23);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "DtPad Updater";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(3, 44);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(350, 192);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = resources.GetString("descriptionLabel.Text");
            // 
            // homePictureBox
            // 
            this.homePictureBox.Image = global::DtPadUpdater.ImageResource.home;
            this.homePictureBox.InitialImage = null;
            this.homePictureBox.Location = new System.Drawing.Point(6, 246);
            this.homePictureBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.homePictureBox.Name = "homePictureBox";
            this.homePictureBox.Size = new System.Drawing.Size(16, 16);
            this.homePictureBox.TabIndex = 3;
            this.homePictureBox.TabStop = false;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.linkLabel.Location = new System.Drawing.Point(28, 247);
            this.linkLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(103, 13);
            this.linkLabel.TabIndex = 2;
            this.linkLabel.Text = "dtpad.codeplex.com";
            this.linkLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.linkLabel_MouseClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(424, 315);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(321, 315);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(97, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Next >";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // updatePanel
            // 
            this.updatePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updatePanel.Controls.Add(this.updateProgressBar);
            this.updatePanel.Controls.Add(this.updateTextBox);
            this.updatePanel.Location = new System.Drawing.Point(143, 12);
            this.updatePanel.Name = "updatePanel";
            this.updatePanel.Size = new System.Drawing.Size(356, 282);
            this.updatePanel.TabIndex = 0;
            this.updatePanel.Visible = false;
            // 
            // updateProgressBar
            // 
            this.updateProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateProgressBar.Location = new System.Drawing.Point(3, 3);
            this.updateProgressBar.Name = "updateProgressBar";
            this.updateProgressBar.Size = new System.Drawing.Size(353, 23);
            this.updateProgressBar.TabIndex = 0;
            // 
            // updateTextBox
            // 
            this.updateTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.updateTextBox.Location = new System.Drawing.Point(3, 32);
            this.updateTextBox.Multiline = true;
            this.updateTextBox.Name = "updateTextBox";
            this.updateTextBox.ReadOnly = true;
            this.updateTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.updateTextBox.Size = new System.Drawing.Size(353, 250);
            this.updateTextBox.TabIndex = 1;
            this.updateTextBox.TextChanged += new System.EventHandler(this.updateTextBox_TextChanged);
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
            this.copyToolStripMenuItem.Image = global::DtPadUpdater.ImageResource.copy;
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
            this.logoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.logoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoPictureBox.Image = global::DtPadUpdater.ImageResource.banner_vertical;
            this.logoPictureBox.InitialImage = null;
            this.logoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(125, 282);
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.logoPictureBox_MouseDoubleClick);
            // 
            // infoPanel
            // 
            this.infoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoPanel.Controls.Add(this.progressBar);
            this.infoPanel.Controls.Add(this.whatIsInsideLabel);
            this.infoPanel.Controls.Add(this.whatIsInsideTextBox);
            this.infoPanel.Location = new System.Drawing.Point(143, 12);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(356, 282);
            this.infoPanel.TabIndex = 3;
            this.infoPanel.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(281, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(72, 18);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 4;
            // 
            // whatIsInsideLabel
            // 
            this.whatIsInsideLabel.AutoSize = true;
            this.whatIsInsideLabel.Location = new System.Drawing.Point(3, 3);
            this.whatIsInsideLabel.Name = "whatIsInsideLabel";
            this.whatIsInsideLabel.Size = new System.Drawing.Size(115, 13);
            this.whatIsInsideLabel.TabIndex = 2;
            this.whatIsInsideLabel.Text = "This update containes:";
            // 
            // whatIsInsideTextBox
            // 
            this.whatIsInsideTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.whatIsInsideTextBox.Location = new System.Drawing.Point(3, 28);
            this.whatIsInsideTextBox.Multiline = true;
            this.whatIsInsideTextBox.Name = "whatIsInsideTextBox";
            this.whatIsInsideTextBox.ReadOnly = true;
            this.whatIsInsideTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.whatIsInsideTextBox.Size = new System.Drawing.Size(353, 254);
            this.whatIsInsideTextBox.TabIndex = 1;
            this.whatIsInsideTextBox.Text = "Loading change log...\r\n\r\nIt is not necessary to wait for the change log before to" +
    " proceed.\r\nPress \"Start Update\" when you want to start the update.";
            // 
            // adminModeLabel
            // 
            this.adminModeLabel.AutoSize = true;
            this.adminModeLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.adminModeLabel.Location = new System.Drawing.Point(12, 297);
            this.adminModeLabel.Name = "adminModeLabel";
            this.adminModeLabel.Size = new System.Drawing.Size(10, 13);
            this.adminModeLabel.TabIndex = 4;
            this.adminModeLabel.Text = ".";
            this.adminModeLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 350);
            this.Controls.Add(this.adminModeLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.updatePanel);
            this.Controls.Add(this.introPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DtPad Updater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.introPanel.ResumeLayout(false);
            this.introPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homePictureBox)).EndInit();
            this.updatePanel.ResumeLayout(false);
            this.updatePanel.PerformLayout();
            this.contentContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Panel introPanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox homePictureBox;
        private System.Windows.Forms.Label linkLabel;
        private System.Windows.Forms.FlowLayoutPanel updatePanel;
        private System.Windows.Forms.ProgressBar updateProgressBar;
        private System.Windows.Forms.TextBox updateTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button cancelButton;
        internal System.Windows.Forms.ContextMenuStrip contentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label whatIsInsideLabel;
        internal System.Windows.Forms.TextBox whatIsInsideTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label adminModeLabel;
    }
}
