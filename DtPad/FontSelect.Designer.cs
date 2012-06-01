namespace DtPad
{
    partial class FontSelect
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontSelect));
            this.sizeNumericUpDown = new Customs.CustomNumericUpDown();
            this.fontEdit = new DevExpress.XtraEditors.FontEdit();
            this.colorEdit = new DevExpress.XtraEditors.ColorEdit();
            this.fontLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.sizeListBox = new System.Windows.Forms.ListBox();
            this.boldCheckBox = new System.Windows.Forms.CheckBox();
            this.previewGroupBox = new System.Windows.Forms.GroupBox();
            this.previewTextBox = new System.Windows.Forms.RichTextBox();
            this.italicCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.effectsGroupBox = new System.Windows.Forms.GroupBox();
            this.underlinedCheckBox = new System.Windows.Forms.CheckBox();
            this.contentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fontEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).BeginInit();
            this.previewGroupBox.SuspendLayout();
            this.effectsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumericUpDown)).BeginInit();
            this.contentContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fontEdit
            // 
            this.fontEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fontEdit.Location = new System.Drawing.Point(58, 6);
            this.fontEdit.Name = "fontEdit";
            this.fontEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, global::DtPad.Languages.it.SearchInFiles_searchFolderComboBoxItems, 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, global::DtPad.Languages.it.SearchInFiles_searchFolderComboBoxItems, null, null, false)});
            this.fontEdit.Properties.DropDownRows = 15;
            this.fontEdit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.fontEdit.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.fontEdit.Properties.Sorted = true;
            this.fontEdit.Size = new System.Drawing.Size(240, 20);
            this.fontEdit.TabIndex = 1;
            this.fontEdit.Visible = false;
            this.fontEdit.SelectedIndexChanged += new System.EventHandler(this.fontEdit_SelectedIndexChanged);
            // 
            // colorEdit
            // 
            this.colorEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.colorEdit.EditValue = System.Drawing.Color.Empty;
            this.colorEdit.Location = new System.Drawing.Point(58, 32);
            this.colorEdit.Name = "colorEdit";
            this.colorEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, global::DtPad.Languages.it.SearchInFiles_searchFolderComboBoxItems, 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, global::DtPad.Languages.it.SearchInFiles_searchFolderComboBoxItems, null, null, false)});
            this.colorEdit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.colorEdit.Properties.ShowWebColors = false;
            this.colorEdit.Size = new System.Drawing.Size(134, 20);
            this.colorEdit.TabIndex = 3;
            this.colorEdit.EditValueChanged += new System.EventHandler(this.colorEdit_EditValueChanged);
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(12, 9);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(31, 13);
            this.fontLabel.TabIndex = 0;
            this.fontLabel.Text = "Font:";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(12, 35);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(34, 13);
            this.colorLabel.TabIndex = 2;
            this.colorLabel.Text = "Color:";
            // 
            // sizeLabel
            // 
            this.sizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(198, 35);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(30, 13);
            this.sizeLabel.TabIndex = 4;
            this.sizeLabel.Text = "Size:";
            // 
            // sizeListBox
            // 
            this.sizeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeListBox.FormattingEnabled = true;
            this.sizeListBox.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.sizeListBox.Location = new System.Drawing.Point(242, 52);
            this.sizeListBox.Name = "sizeListBox";
            this.sizeListBox.Size = new System.Drawing.Size(56, 82);
            this.sizeListBox.TabIndex = 6;
            this.sizeListBox.SelectedIndexChanged += new System.EventHandler(this.sizeListBox_SelectedIndexChanged);
            // 
            // boldCheckBox
            // 
            this.boldCheckBox.AutoSize = true;
            this.boldCheckBox.Location = new System.Drawing.Point(6, 19);
            this.boldCheckBox.Name = "boldCheckBox";
            this.boldCheckBox.Size = new System.Drawing.Size(47, 17);
            this.boldCheckBox.TabIndex = 0;
            this.boldCheckBox.Text = "Bold";
            this.boldCheckBox.UseVisualStyleBackColor = true;
            this.boldCheckBox.CheckedChanged += new System.EventHandler(this.boldCheckBox_CheckedChanged);
            // 
            // previewGroupBox
            // 
            this.previewGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.previewGroupBox.Controls.Add(this.previewTextBox);
            this.previewGroupBox.Location = new System.Drawing.Point(15, 140);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(283, 105);
            this.previewGroupBox.TabIndex = 8;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Preview";
            // 
            // previewTextBox
            // 
            this.previewTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.previewTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.previewTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.previewTextBox.DetectUrls = false;
            this.previewTextBox.Location = new System.Drawing.Point(6, 19);
            this.previewTextBox.Name = "previewTextBox";
            this.previewTextBox.Size = new System.Drawing.Size(271, 80);
            this.previewTextBox.TabIndex = 0;
            this.previewTextBox.Text = "This text is a font example";
            // 
            // italicCheckBox
            // 
            this.italicCheckBox.AutoSize = true;
            this.italicCheckBox.Location = new System.Drawing.Point(114, 19);
            this.italicCheckBox.Name = "italicCheckBox";
            this.italicCheckBox.Size = new System.Drawing.Size(48, 17);
            this.italicCheckBox.TabIndex = 1;
            this.italicCheckBox.Text = "Italic";
            this.italicCheckBox.UseVisualStyleBackColor = true;
            this.italicCheckBox.CheckedChanged += new System.EventHandler(this.italicCheckBox_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(227, 262);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(146, 262);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // effectsGroupBox
            // 
            this.effectsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.effectsGroupBox.Controls.Add(this.underlinedCheckBox);
            this.effectsGroupBox.Controls.Add(this.italicCheckBox);
            this.effectsGroupBox.Controls.Add(this.boldCheckBox);
            this.effectsGroupBox.Location = new System.Drawing.Point(15, 58);
            this.effectsGroupBox.Name = "effectsGroupBox";
            this.effectsGroupBox.Size = new System.Drawing.Size(217, 76);
            this.effectsGroupBox.TabIndex = 7;
            this.effectsGroupBox.TabStop = false;
            this.effectsGroupBox.Text = "Effects";
            // 
            // underlinedCheckBox
            // 
            this.underlinedCheckBox.AutoSize = true;
            this.underlinedCheckBox.Location = new System.Drawing.Point(6, 42);
            this.underlinedCheckBox.Name = "underlinedCheckBox";
            this.underlinedCheckBox.Size = new System.Drawing.Size(71, 17);
            this.underlinedCheckBox.TabIndex = 2;
            this.underlinedCheckBox.Text = "Underline";
            this.underlinedCheckBox.UseVisualStyleBackColor = true;
            this.underlinedCheckBox.CheckedChanged += new System.EventHandler(this.underlinedCheckBox_CheckedChanged);
            // 
            // sizeNumericUpDown
            // 
            this.sizeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeNumericUpDown.CustomContextMenuStrip = this.contentContextMenuStrip;
            this.sizeNumericUpDown.Location = new System.Drawing.Point(242, 33);
            this.sizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sizeNumericUpDown.Name = "sizeNumericUpDown";
            this.sizeNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.sizeNumericUpDown.TabIndex = 5;
            this.sizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sizeNumericUpDown.ValueChanged += new System.EventHandler(this.sizeNumericUpDown_ValueChanged);
            // 
            // contentContextMenuStrip
            // 
            this.contentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator29,
            this.selectAllToolStripMenuItem});
            this.contentContextMenuStrip.Name = "searchContextMenuStrip";
            this.contentContextMenuStrip.Size = new System.Drawing.Size(123, 76);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::DtPad.ToolbarResource.paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
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
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetButton.Location = new System.Drawing.Point(12, 262);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // FontSelect
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(314, 297);
            this.Controls.Add(this.sizeNumericUpDown);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.effectsGroupBox);
            this.Controls.Add(this.previewGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.sizeListBox);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.colorEdit);
            this.Controls.Add(this.fontEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Font";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FontSelect_HelpButtonClicked);
            ((System.ComponentModel.ISupportInitialize)(this.fontEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).EndInit();
            this.previewGroupBox.ResumeLayout(false);
            this.effectsGroupBox.ResumeLayout(false);
            this.effectsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumericUpDown)).EndInit();
            this.contentContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.ListBox sizeListBox;
        private System.Windows.Forms.GroupBox previewGroupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox effectsGroupBox;
        internal DevExpress.XtraEditors.FontEdit fontEdit;
        internal DevExpress.XtraEditors.ColorEdit colorEdit;
        internal System.Windows.Forms.CheckBox boldCheckBox;
        internal System.Windows.Forms.CheckBox italicCheckBox;
        internal System.Windows.Forms.CheckBox underlinedCheckBox;
        internal System.Windows.Forms.RichTextBox previewTextBox;
        internal Customs.CustomNumericUpDown sizeNumericUpDown;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ContextMenuStrip contentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    }
}
