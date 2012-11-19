namespace DtPad
{
    partial class Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            this.closeButton = new System.Windows.Forms.Button();
            this.memoryLabel = new System.Windows.Forms.TextBox();
            this.memoryLabel1 = new System.Windows.Forms.Label();
            this.frameworkVersionLabel = new System.Windows.Forms.TextBox();
            this.processorsLabel = new System.Windows.Forms.TextBox();
            this.machineNameLabel = new System.Windows.Forms.TextBox();
            this.workingDirectoryLabel = new System.Windows.Forms.TextBox();
            this.frameworkVersionLabel1 = new System.Windows.Forms.Label();
            this.processorsLabel1 = new System.Windows.Forms.Label();
            this.machineNameLabel1 = new System.Windows.Forms.Label();
            this.workingDirectoryLabel1 = new System.Windows.Forms.Label();
            this.domainLabel = new System.Windows.Forms.TextBox();
            this.osLabel = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.TextBox();
            this.osLabel1 = new System.Windows.Forms.Label();
            this.domainLabel1 = new System.Windows.Forms.Label();
            this.usernameLabel1 = new System.Windows.Forms.Label();
            this.directoryToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.refreshButton = new System.Windows.Forms.Button();
            this.statisticsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.copyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(333, 191);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 18;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // memoryLabel
            // 
            this.memoryLabel.BackColor = System.Drawing.SystemColors.Control;
            this.memoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.memoryLabel.Location = new System.Drawing.Point(158, 170);
            this.memoryLabel.Name = "memoryLabel";
            this.memoryLabel.ReadOnly = true;
            this.memoryLabel.Size = new System.Drawing.Size(250, 13);
            this.memoryLabel.TabIndex = 15;
            this.memoryLabel.Text = "memoryLabel";
            // 
            // memoryLabel1
            // 
            this.memoryLabel1.AutoSize = true;
            this.memoryLabel1.Location = new System.Drawing.Point(12, 170);
            this.memoryLabel1.Name = "memoryLabel1";
            this.memoryLabel1.Size = new System.Drawing.Size(110, 13);
            this.memoryLabel1.TabIndex = 14;
            this.memoryLabel1.Text = "Memory (working set):";
            // 
            // frameworkVersionLabel
            // 
            this.frameworkVersionLabel.BackColor = System.Drawing.SystemColors.Control;
            this.frameworkVersionLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.frameworkVersionLabel.Location = new System.Drawing.Point(158, 147);
            this.frameworkVersionLabel.Name = "frameworkVersionLabel";
            this.frameworkVersionLabel.ReadOnly = true;
            this.frameworkVersionLabel.Size = new System.Drawing.Size(250, 13);
            this.frameworkVersionLabel.TabIndex = 13;
            this.frameworkVersionLabel.Text = "frameworkVersionLabel";
            // 
            // processorsLabel
            // 
            this.processorsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.processorsLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.processorsLabel.Location = new System.Drawing.Point(158, 124);
            this.processorsLabel.Name = "processorsLabel";
            this.processorsLabel.ReadOnly = true;
            this.processorsLabel.Size = new System.Drawing.Size(250, 13);
            this.processorsLabel.TabIndex = 11;
            this.processorsLabel.Text = "processorsLabel";
            // 
            // machineNameLabel
            // 
            this.machineNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.machineNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.machineNameLabel.Location = new System.Drawing.Point(158, 78);
            this.machineNameLabel.Name = "machineNameLabel";
            this.machineNameLabel.ReadOnly = true;
            this.machineNameLabel.Size = new System.Drawing.Size(250, 13);
            this.machineNameLabel.TabIndex = 7;
            this.machineNameLabel.Text = "machineNameLabel";
            // 
            // workingDirectoryLabel
            // 
            this.workingDirectoryLabel.BackColor = System.Drawing.SystemColors.Control;
            this.workingDirectoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.workingDirectoryLabel.Location = new System.Drawing.Point(158, 55);
            this.workingDirectoryLabel.Name = "workingDirectoryLabel";
            this.workingDirectoryLabel.ReadOnly = true;
            this.workingDirectoryLabel.Size = new System.Drawing.Size(250, 13);
            this.workingDirectoryLabel.TabIndex = 5;
            this.workingDirectoryLabel.Text = "workingDirectoryLabel";
            // 
            // frameworkVersionLabel1
            // 
            this.frameworkVersionLabel1.AutoSize = true;
            this.frameworkVersionLabel1.Location = new System.Drawing.Point(12, 147);
            this.frameworkVersionLabel1.Name = "frameworkVersionLabel1";
            this.frameworkVersionLabel1.Size = new System.Drawing.Size(96, 13);
            this.frameworkVersionLabel1.TabIndex = 12;
            this.frameworkVersionLabel1.Text = ".NET CLR version:";
            // 
            // processorsLabel1
            // 
            this.processorsLabel1.AutoSize = true;
            this.processorsLabel1.Location = new System.Drawing.Point(12, 124);
            this.processorsLabel1.Name = "processorsLabel1";
            this.processorsLabel1.Size = new System.Drawing.Size(62, 13);
            this.processorsLabel1.TabIndex = 10;
            this.processorsLabel1.Text = "Processors:";
            // 
            // machineNameLabel1
            // 
            this.machineNameLabel1.AutoSize = true;
            this.machineNameLabel1.Location = new System.Drawing.Point(12, 78);
            this.machineNameLabel1.Name = "machineNameLabel1";
            this.machineNameLabel1.Size = new System.Drawing.Size(84, 13);
            this.machineNameLabel1.TabIndex = 6;
            this.machineNameLabel1.Text = "Computer name:";
            // 
            // workingDirectoryLabel1
            // 
            this.workingDirectoryLabel1.AutoSize = true;
            this.workingDirectoryLabel1.Location = new System.Drawing.Point(12, 55);
            this.workingDirectoryLabel1.Name = "workingDirectoryLabel1";
            this.workingDirectoryLabel1.Size = new System.Drawing.Size(93, 13);
            this.workingDirectoryLabel1.TabIndex = 4;
            this.workingDirectoryLabel1.Text = "Working directory:";
            // 
            // domainLabel
            // 
            this.domainLabel.BackColor = System.Drawing.SystemColors.Control;
            this.domainLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.domainLabel.Location = new System.Drawing.Point(158, 32);
            this.domainLabel.Name = "domainLabel";
            this.domainLabel.ReadOnly = true;
            this.domainLabel.Size = new System.Drawing.Size(250, 13);
            this.domainLabel.TabIndex = 3;
            this.domainLabel.Text = "domainLabel";
            // 
            // osLabel
            // 
            this.osLabel.BackColor = System.Drawing.SystemColors.Control;
            this.osLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.osLabel.Location = new System.Drawing.Point(158, 101);
            this.osLabel.Name = "osLabel";
            this.osLabel.ReadOnly = true;
            this.osLabel.Size = new System.Drawing.Size(250, 13);
            this.osLabel.TabIndex = 9;
            this.osLabel.Text = "osLabel";
            // 
            // usernameLabel
            // 
            this.usernameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.usernameLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameLabel.Location = new System.Drawing.Point(158, 9);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.ReadOnly = true;
            this.usernameLabel.Size = new System.Drawing.Size(250, 13);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "usernameLabel";
            // 
            // osLabel1
            // 
            this.osLabel1.AutoSize = true;
            this.osLabel1.Location = new System.Drawing.Point(12, 101);
            this.osLabel1.Name = "osLabel1";
            this.osLabel1.Size = new System.Drawing.Size(91, 13);
            this.osLabel1.TabIndex = 8;
            this.osLabel1.Text = "Operative system:";
            // 
            // domainLabel1
            // 
            this.domainLabel1.AutoSize = true;
            this.domainLabel1.Location = new System.Drawing.Point(12, 32);
            this.domainLabel1.Name = "domainLabel1";
            this.domainLabel1.Size = new System.Drawing.Size(46, 13);
            this.domainLabel1.TabIndex = 2;
            this.domainLabel1.Text = "Domain:";
            // 
            // usernameLabel1
            // 
            this.usernameLabel1.AutoSize = true;
            this.usernameLabel1.Location = new System.Drawing.Point(12, 9);
            this.usernameLabel1.Name = "usernameLabel1";
            this.usernameLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.usernameLabel1.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel1.TabIndex = 0;
            this.usernameLabel1.Text = "Username:";
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Image = global::DtPad.ToolbarResource.convert;
            this.refreshButton.Location = new System.Drawing.Point(15, 191);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(23, 23);
            this.refreshButton.TabIndex = 16;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.Image = global::DtPad.ToolbarResource.copy;
            this.copyButton.Location = new System.Drawing.Point(44, 191);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(23, 23);
            this.copyButton.TabIndex = 17;
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // Statistics
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 226);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.memoryLabel);
            this.Controls.Add(this.memoryLabel1);
            this.Controls.Add(this.frameworkVersionLabel);
            this.Controls.Add(this.processorsLabel);
            this.Controls.Add(this.machineNameLabel);
            this.Controls.Add(this.workingDirectoryLabel);
            this.Controls.Add(this.frameworkVersionLabel1);
            this.Controls.Add(this.processorsLabel1);
            this.Controls.Add(this.machineNameLabel1);
            this.Controls.Add(this.workingDirectoryLabel1);
            this.Controls.Add(this.domainLabel);
            this.Controls.Add(this.osLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.osLabel1);
            this.Controls.Add(this.domainLabel1);
            this.Controls.Add(this.usernameLabel1);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Statistics";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Statistics_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox memoryLabel;
        private System.Windows.Forms.Label memoryLabel1;
        private System.Windows.Forms.TextBox frameworkVersionLabel;
        private System.Windows.Forms.TextBox processorsLabel;
        private System.Windows.Forms.TextBox machineNameLabel;
        private System.Windows.Forms.TextBox workingDirectoryLabel;
        private System.Windows.Forms.Label frameworkVersionLabel1;
        private System.Windows.Forms.Label processorsLabel1;
        private System.Windows.Forms.Label machineNameLabel1;
        private System.Windows.Forms.Label workingDirectoryLabel1;
        private System.Windows.Forms.TextBox domainLabel;
        private System.Windows.Forms.TextBox osLabel;
        private System.Windows.Forms.TextBox usernameLabel;
        private System.Windows.Forms.Label osLabel1;
        private System.Windows.Forms.Label domainLabel1;
        private System.Windows.Forms.Label usernameLabel1;
        private System.Windows.Forms.ToolTip directoryToolTip;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ToolTip statisticsToolTip;
        private System.Windows.Forms.Button copyButton;
    }
}
