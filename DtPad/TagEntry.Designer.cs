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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagEntry));
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.customTextBox2 = new System.Windows.Forms.TextBox();
            this.customTextBox1 = new System.Windows.Forms.TextBox();
            this.customRadioButton = new System.Windows.Forms.RadioButton();
            this.forumRadioButton = new System.Windows.Forms.RadioButton();
            this.xhtmlRadioButton = new System.Windows.Forms.RadioButton();
            this.extensionGroupBox = new System.Windows.Forms.GroupBox();
            this.shortRadioButton = new System.Windows.Forms.RadioButton();
            this.completeRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tagTextBox = new System.Windows.Forms.TextBox();
            this.tagLabel = new System.Windows.Forms.Label();
            this.typeGroupBox.SuspendLayout();
            this.extensionGroupBox.SuspendLayout();
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
            this.typeGroupBox.Size = new System.Drawing.Size(188, 120);
            this.typeGroupBox.TabIndex = 0;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "Type";
            // 
            // customTextBox2
            // 
            this.customTextBox2.Enabled = false;
            this.customTextBox2.Location = new System.Drawing.Point(105, 89);
            this.customTextBox2.Name = "customTextBox2";
            this.customTextBox2.Size = new System.Drawing.Size(77, 20);
            this.customTextBox2.TabIndex = 4;
            this.customTextBox2.Tag = "DontTranslate";
            // 
            // customTextBox1
            // 
            this.customTextBox1.Enabled = false;
            this.customTextBox1.Location = new System.Drawing.Point(22, 89);
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Size = new System.Drawing.Size(77, 20);
            this.customTextBox1.TabIndex = 3;
            this.customTextBox1.Tag = "DontTranslate";
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
            // forumRadioButton
            // 
            this.forumRadioButton.AutoSize = true;
            this.forumRadioButton.Location = new System.Drawing.Point(6, 43);
            this.forumRadioButton.Name = "forumRadioButton";
            this.forumRadioButton.Size = new System.Drawing.Size(75, 17);
            this.forumRadioButton.TabIndex = 1;
            this.forumRadioButton.Text = "Forum ([, ])";
            this.forumRadioButton.UseVisualStyleBackColor = true;
            // 
            // xhtmlRadioButton
            // 
            this.xhtmlRadioButton.AutoSize = true;
            this.xhtmlRadioButton.Checked = true;
            this.xhtmlRadioButton.Location = new System.Drawing.Point(6, 19);
            this.xhtmlRadioButton.Name = "xhtmlRadioButton";
            this.xhtmlRadioButton.Size = new System.Drawing.Size(109, 17);
            this.xhtmlRadioButton.TabIndex = 0;
            this.xhtmlRadioButton.TabStop = true;
            this.xhtmlRadioButton.Text = "XML/HTML (<, >)";
            this.xhtmlRadioButton.UseVisualStyleBackColor = true;
            // 
            // extensionGroupBox
            // 
            this.extensionGroupBox.Controls.Add(this.shortRadioButton);
            this.extensionGroupBox.Controls.Add(this.completeRadioButton);
            this.extensionGroupBox.Location = new System.Drawing.Point(206, 12);
            this.extensionGroupBox.Name = "extensionGroupBox";
            this.extensionGroupBox.Size = new System.Drawing.Size(191, 70);
            this.extensionGroupBox.TabIndex = 1;
            this.extensionGroupBox.TabStop = false;
            this.extensionGroupBox.Text = "Extension";
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
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Enabled = false;
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(225, 146);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(91, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Insert";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(322, 146);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tagTextBox
            // 
            this.tagTextBox.Location = new System.Drawing.Point(282, 101);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(115, 20);
            this.tagTextBox.TabIndex = 3;
            this.tagTextBox.Tag = "DontTranslate";
            this.tagTextBox.TextChanged += new System.EventHandler(this.tagTextBox_TextChanged);
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.Location = new System.Drawing.Point(209, 104);
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
            this.ClientSize = new System.Drawing.Size(409, 179);
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
    }
}
