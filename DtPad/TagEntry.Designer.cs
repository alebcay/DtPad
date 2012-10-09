namespace DtPad
{
    partial class TagEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagEntry));
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.extensionGroupBox = new System.Windows.Forms.GroupBox();
            this.xhtmlRadioButton = new System.Windows.Forms.RadioButton();
            this.forumRadioButton = new System.Windows.Forms.RadioButton();
            this.customRadioButton = new System.Windows.Forms.RadioButton();
            this.customTextBox1 = new System.Windows.Forms.TextBox();
            this.contentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeRadioButton = new System.Windows.Forms.RadioButton();
            this.shortRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.customTextBox2 = new System.Windows.Forms.TextBox();
            this.tagTextBox = new System.Windows.Forms.TextBox();
            this.tagLabel = new System.Windows.Forms.Label();
            this.typeGroupBox.SuspendLayout();
            this.extensionGroupBox.SuspendLayout();
            this.contentContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.Controls.Add(this.customTextBox2);
            this.typeGroupBox.Controls.Add(this.customTextBox1);
            this.typeGroupBox.Controls.Add(this.customRadioButton);
            this.typeGroupBox.Controls.Add(this.forumRadioButton);
            this.typeGroupBox.Controls.Add(this.xhtmlRadioButton);
            this.typeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.Size = new System.Drawing.Size(170, 120);
            this.typeGroupBox.TabIndex = 0;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "Type";
            // 
            // extensionGroupBox
            // 
            this.extensionGroupBox.Controls.Add(this.shortRadioButton);
            this.extensionGroupBox.Controls.Add(this.completeRadioButton);
            this.extensionGroupBox.Location = new System.Drawing.Point(188, 12);
            this.extensionGroupBox.Name = "extensionGroupBox";
            this.extensionGroupBox.Size = new System.Drawing.Size(170, 70);
            this.extensionGroupBox.TabIndex = 1;
            this.extensionGroupBox.TabStop = false;
            this.extensionGroupBox.Text = "Extension";
            // 
            // xhtmlRadioButton
            // 
            this.xhtmlRadioButton.AutoSize = true;
            this.xhtmlRadioButton.Checked = true;
            this.xhtmlRadioButton.Location = new System.Drawing.Point(6, 19);
            this.xhtmlRadioButton.Name = "xhtmlRadioButton";
            this.xhtmlRadioButton.Size = new System.Drawing.Size(82, 17);
            this.xhtmlRadioButton.TabIndex = 0;
            this.xhtmlRadioButton.TabStop = true;
            this.xhtmlRadioButton.Text = "XML/HTML (<, >)";
            this.xhtmlRadioButton.UseVisualStyleBackColor = true;
            // 
            // forumRadioButton
            // 
            this.forumRadioButton.AutoSize = true;
            this.forumRadioButton.Location = new System.Drawing.Point(6, 43);
            this.forumRadioButton.Name = "forumRadioButton";
            this.forumRadioButton.Size = new System.Drawing.Size(54, 17);
            this.forumRadioButton.TabIndex = 1;
            this.forumRadioButton.Text = "Forum ([, ])";
            this.forumRadioButton.UseVisualStyleBackColor = true;
            // 
            // customRadioButton
            // 
            this.customRadioButton.AutoSize = true;
            this.customRadioButton.Location = new System.Drawing.Point(6, 66);
            this.customRadioButton.Name = "customRadioButton";
            this.customRadioButton.Size = new System.Drawing.Size(112, 17);
            this.customRadioButton.TabIndex = 2;
            this.customRadioButton.Text = "Custom (start/end)";
            this.customRadioButton.UseVisualStyleBackColor = true;
            this.customRadioButton.CheckedChanged += new System.EventHandler(this.customRadioButton_CheckedChanged);
            // 
            // customTextBox1
            // 
            this.customTextBox1.ContextMenuStrip = this.contentContextMenuStrip;
            this.customTextBox1.Enabled = false;
            this.customTextBox1.Location = new System.Drawing.Point(22, 89);
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Size = new System.Drawing.Size(66, 20);
            this.customTextBox1.TabIndex = 3;
            // 
            // contentContextMenuStrip
            // 
            this.contentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator29,
            this.selectAllToolStripMenuItem});
            this.contentContextMenuStrip.Name = "contentContextMenuStrip";
            this.contentContextMenuStrip.Size = new System.Drawing.Size(153, 170);
            this.contentContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contentContextMenuStrip_Opening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::DtPad.ToolbarResource.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::DtPad.ToolbarResource.paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(149, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.selectAllToolStripMenuItem_Click);
            // 
            // completeRadioButton
            // 
            this.completeRadioButton.AutoSize = true;
            this.completeRadioButton.Checked = true;
            this.completeRadioButton.Location = new System.Drawing.Point(6, 19);
            this.completeRadioButton.Name = "completeRadioButton";
            this.completeRadioButton.Size = new System.Drawing.Size(133, 17);
            this.completeRadioButton.TabIndex = 0;
            this.completeRadioButton.TabStop = true;
            this.completeRadioButton.Text = "Complete (ie. <b></b>)";
            this.completeRadioButton.UseVisualStyleBackColor = true;
            // 
            // shortRadioButton
            // 
            this.shortRadioButton.AutoSize = true;
            this.shortRadioButton.Location = new System.Drawing.Point(6, 42);
            this.shortRadioButton.Name = "shortRadioButton";
            this.shortRadioButton.Size = new System.Drawing.Size(102, 17);
            this.shortRadioButton.TabIndex = 1;
            this.shortRadioButton.Text = "Short (ie. <br />)";
            this.shortRadioButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Enabled = false;
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(202, 146);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Insert";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(283, 146);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // customTextBox2
            // 
            this.customTextBox2.ContextMenuStrip = this.contentContextMenuStrip;
            this.customTextBox2.Enabled = false;
            this.customTextBox2.Location = new System.Drawing.Point(94, 89);
            this.customTextBox2.Name = "customTextBox2";
            this.customTextBox2.Size = new System.Drawing.Size(66, 20);
            this.customTextBox2.TabIndex = 4;
            // 
            // tagTextBox
            // 
            this.tagTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.tagTextBox.Location = new System.Drawing.Point(243, 101);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(115, 20);
            this.tagTextBox.TabIndex = 3;
            this.tagTextBox.TextChanged += new System.EventHandler(this.tagTextBox_TextChanged);
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.Location = new System.Drawing.Point(191, 104);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(29, 13);
            this.tagLabel.TabIndex = 2;
            this.tagLabel.Text = "Tag:";
            // 
            // TagEntry
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(370, 179);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.tagTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.extensionGroupBox);
            this.Controls.Add(this.typeGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagEntry";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tag Entry";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.TagEntry_HelpButtonClicked);
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            this.extensionGroupBox.ResumeLayout(false);
            this.extensionGroupBox.PerformLayout();
            this.contentContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox typeGroupBox;
        private System.Windows.Forms.TextBox customTextBox1;
        private System.Windows.Forms.RadioButton customRadioButton;
        private System.Windows.Forms.RadioButton forumRadioButton;
        private System.Windows.Forms.RadioButton xhtmlRadioButton;
        private System.Windows.Forms.GroupBox extensionGroupBox;
        private System.Windows.Forms.RadioButton shortRadioButton;
        private System.Windows.Forms.RadioButton completeRadioButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox customTextBox2;
        private System.Windows.Forms.TextBox tagTextBox;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.ContextMenuStrip contentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    }
}
