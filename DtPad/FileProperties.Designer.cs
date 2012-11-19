namespace DtPad
{
    partial class FileProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileProperties));
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.creationDateLabel1 = new System.Windows.Forms.Label();
            this.directoryLabel1 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.TextBox();
            this.directoryLabel = new System.Windows.Forms.TextBox();
            this.creationDateLabel = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.lastUpdateLabel1 = new System.Windows.Forms.Label();
            this.lastAccessLabel1 = new System.Windows.Forms.Label();
            this.readonlyLabel1 = new System.Windows.Forms.Label();
            this.sizeLabel1 = new System.Windows.Forms.Label();
            this.lastUpdateLabel = new System.Windows.Forms.TextBox();
            this.lastAccessLabel = new System.Windows.Forms.TextBox();
            this.readonlyLabel = new System.Windows.Forms.TextBox();
            this.sizeLabel = new System.Windows.Forms.TextBox();
            this.directoryToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.nameToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.encodingLabel1 = new System.Windows.Forms.Label();
            this.encodingLabel = new System.Windows.Forms.TextBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.filePropertiesToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel1
            // 
            this.nameLabel1.AutoSize = true;
            this.nameLabel1.Location = new System.Drawing.Point(12, 9);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nameLabel1.Size = new System.Drawing.Size(38, 13);
            this.nameLabel1.TabIndex = 0;
            this.nameLabel1.Text = "Name:";
            // 
            // creationDateLabel1
            // 
            this.creationDateLabel1.AutoSize = true;
            this.creationDateLabel1.Location = new System.Drawing.Point(12, 32);
            this.creationDateLabel1.Name = "creationDateLabel1";
            this.creationDateLabel1.Size = new System.Drawing.Size(73, 13);
            this.creationDateLabel1.TabIndex = 2;
            this.creationDateLabel1.Text = "Creation date:";
            // 
            // directoryLabel1
            // 
            this.directoryLabel1.AutoSize = true;
            this.directoryLabel1.Location = new System.Drawing.Point(12, 101);
            this.directoryLabel1.Name = "directoryLabel1";
            this.directoryLabel1.Size = new System.Drawing.Size(52, 13);
            this.directoryLabel1.TabIndex = 8;
            this.directoryLabel1.Text = "Directory:";
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.nameLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameLabel.Location = new System.Drawing.Point(110, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.ReadOnly = true;
            this.nameLabel.Size = new System.Drawing.Size(261, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "nameLabel";
            this.nameLabel.MouseLeave += new System.EventHandler(this.nameLabel_MouseLeave);
            // 
            // directoryLabel
            // 
            this.directoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryLabel.BackColor = System.Drawing.SystemColors.Control;
            this.directoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.directoryLabel.Location = new System.Drawing.Point(110, 101);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.ReadOnly = true;
            this.directoryLabel.Size = new System.Drawing.Size(306, 13);
            this.directoryLabel.TabIndex = 9;
            this.directoryLabel.Text = "directoryLabel";
            this.directoryLabel.MouseLeave += new System.EventHandler(this.directoryLabel_MouseLeave);
            // 
            // creationDateLabel
            // 
            this.creationDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creationDateLabel.BackColor = System.Drawing.SystemColors.Control;
            this.creationDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.creationDateLabel.Location = new System.Drawing.Point(110, 32);
            this.creationDateLabel.Name = "creationDateLabel";
            this.creationDateLabel.ReadOnly = true;
            this.creationDateLabel.Size = new System.Drawing.Size(261, 13);
            this.creationDateLabel.TabIndex = 3;
            this.creationDateLabel.Text = "creationDateLabel";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(344, 191);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 17;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // lastUpdateLabel1
            // 
            this.lastUpdateLabel1.AutoSize = true;
            this.lastUpdateLabel1.Location = new System.Drawing.Point(12, 55);
            this.lastUpdateLabel1.Name = "lastUpdateLabel1";
            this.lastUpdateLabel1.Size = new System.Drawing.Size(66, 13);
            this.lastUpdateLabel1.TabIndex = 4;
            this.lastUpdateLabel1.Text = "Last update:";
            // 
            // lastAccessLabel1
            // 
            this.lastAccessLabel1.AutoSize = true;
            this.lastAccessLabel1.Location = new System.Drawing.Point(12, 78);
            this.lastAccessLabel1.Name = "lastAccessLabel1";
            this.lastAccessLabel1.Size = new System.Drawing.Size(67, 13);
            this.lastAccessLabel1.TabIndex = 6;
            this.lastAccessLabel1.Text = "Last access:";
            // 
            // readonlyLabel1
            // 
            this.readonlyLabel1.AutoSize = true;
            this.readonlyLabel1.Location = new System.Drawing.Point(12, 124);
            this.readonlyLabel1.Name = "readonlyLabel1";
            this.readonlyLabel1.Size = new System.Drawing.Size(58, 13);
            this.readonlyLabel1.TabIndex = 10;
            this.readonlyLabel1.Text = "Read-only:";
            // 
            // sizeLabel1
            // 
            this.sizeLabel1.AutoSize = true;
            this.sizeLabel1.Location = new System.Drawing.Point(12, 147);
            this.sizeLabel1.Name = "sizeLabel1";
            this.sizeLabel1.Size = new System.Drawing.Size(64, 13);
            this.sizeLabel1.TabIndex = 12;
            this.sizeLabel1.Text = "Size (bytes):";
            // 
            // lastUpdateLabel
            // 
            this.lastUpdateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastUpdateLabel.BackColor = System.Drawing.SystemColors.Control;
            this.lastUpdateLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastUpdateLabel.Location = new System.Drawing.Point(110, 55);
            this.lastUpdateLabel.Name = "lastUpdateLabel";
            this.lastUpdateLabel.ReadOnly = true;
            this.lastUpdateLabel.Size = new System.Drawing.Size(261, 13);
            this.lastUpdateLabel.TabIndex = 5;
            this.lastUpdateLabel.Text = "lastUpdateLabel";
            // 
            // lastAccessLabel
            // 
            this.lastAccessLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastAccessLabel.BackColor = System.Drawing.SystemColors.Control;
            this.lastAccessLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastAccessLabel.Location = new System.Drawing.Point(110, 78);
            this.lastAccessLabel.Name = "lastAccessLabel";
            this.lastAccessLabel.ReadOnly = true;
            this.lastAccessLabel.Size = new System.Drawing.Size(261, 13);
            this.lastAccessLabel.TabIndex = 7;
            this.lastAccessLabel.Text = "lastAccessLabel";
            // 
            // readonlyLabel
            // 
            this.readonlyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readonlyLabel.BackColor = System.Drawing.SystemColors.Control;
            this.readonlyLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.readonlyLabel.Location = new System.Drawing.Point(110, 124);
            this.readonlyLabel.Name = "readonlyLabel";
            this.readonlyLabel.ReadOnly = true;
            this.readonlyLabel.Size = new System.Drawing.Size(261, 13);
            this.readonlyLabel.TabIndex = 11;
            this.readonlyLabel.Text = "readonlyLabel";
            // 
            // sizeLabel
            // 
            this.sizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.sizeLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sizeLabel.Location = new System.Drawing.Point(110, 147);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.ReadOnly = true;
            this.sizeLabel.Size = new System.Drawing.Size(261, 13);
            this.sizeLabel.TabIndex = 13;
            this.sizeLabel.Text = "sizeLabel";
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox.Location = new System.Drawing.Point(387, 9);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox.TabIndex = 15;
            this.iconPictureBox.TabStop = false;
            // 
            // encodingLabel1
            // 
            this.encodingLabel1.AutoSize = true;
            this.encodingLabel1.Location = new System.Drawing.Point(12, 170);
            this.encodingLabel1.Name = "encodingLabel1";
            this.encodingLabel1.Size = new System.Drawing.Size(55, 13);
            this.encodingLabel1.TabIndex = 14;
            this.encodingLabel1.Text = "Encoding:";
            // 
            // encodingLabel
            // 
            this.encodingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.encodingLabel.BackColor = System.Drawing.SystemColors.Control;
            this.encodingLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.encodingLabel.Location = new System.Drawing.Point(110, 170);
            this.encodingLabel.Name = "encodingLabel";
            this.encodingLabel.ReadOnly = true;
            this.encodingLabel.Size = new System.Drawing.Size(261, 13);
            this.encodingLabel.TabIndex = 15;
            this.encodingLabel.Text = "encodingLabel";
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.Image = global::DtPad.ToolbarResource.copy;
            this.copyButton.Location = new System.Drawing.Point(15, 191);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(23, 23);
            this.copyButton.TabIndex = 16;
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // FileProperties
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 226);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.encodingLabel);
            this.Controls.Add(this.encodingLabel1);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.readonlyLabel);
            this.Controls.Add(this.lastAccessLabel);
            this.Controls.Add(this.lastUpdateLabel);
            this.Controls.Add(this.sizeLabel1);
            this.Controls.Add(this.readonlyLabel1);
            this.Controls.Add(this.lastAccessLabel1);
            this.Controls.Add(this.lastUpdateLabel1);
            this.Controls.Add(this.creationDateLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.directoryLabel1);
            this.Controls.Add(this.creationDateLabel1);
            this.Controls.Add(this.nameLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Properties";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel1;
        private System.Windows.Forms.Label creationDateLabel1;
        private System.Windows.Forms.Label directoryLabel1;
        private System.Windows.Forms.TextBox nameLabel;
        private System.Windows.Forms.TextBox directoryLabel;
        private System.Windows.Forms.TextBox creationDateLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label lastUpdateLabel1;
        private System.Windows.Forms.Label lastAccessLabel1;
        private System.Windows.Forms.Label readonlyLabel1;
        private System.Windows.Forms.Label sizeLabel1;
        private System.Windows.Forms.TextBox lastUpdateLabel;
        private System.Windows.Forms.TextBox lastAccessLabel;
        private System.Windows.Forms.TextBox readonlyLabel;
        private System.Windows.Forms.TextBox sizeLabel;
        private System.Windows.Forms.ToolTip directoryToolTip;
        private System.Windows.Forms.ToolTip nameToolTip;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label encodingLabel1;
        private System.Windows.Forms.TextBox encodingLabel;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.ToolTip filePropertiesToolTip;
    }
}
