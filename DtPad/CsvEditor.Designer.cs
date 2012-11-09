namespace DtPad
{
    partial class CsvEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CsvEditor));
            this.csvGridView = new System.Windows.Forms.DataGridView();
            this.gridViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectedRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeButton = new System.Windows.Forms.Button();
            this.delimiterLabel = new System.Windows.Forms.Label();
            this.headerCheckBox = new System.Windows.Forms.CheckBox();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.quoteComboBox = new System.Windows.Forms.ComboBox();
            this.quoteLabel = new System.Windows.Forms.Label();
            this.delimiterComboBox = new System.Windows.Forms.ComboBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.csvEditorToolStrip = new System.Windows.Forms.ToolStrip();
            this.undoToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.undoAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertOneRowUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertOneRowDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.csvGridView)).BeginInit();
            this.gridViewContextMenuStrip.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.csvEditorToolStrip.SuspendLayout();
            this.contentContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // csvGridView
            // 
            this.csvGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.csvGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.csvGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.csvGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.csvGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.csvGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.csvGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csvGridView.ContextMenuStrip = this.gridViewContextMenuStrip;
            this.csvGridView.Location = new System.Drawing.Point(12, 28);
            this.csvGridView.Name = "csvGridView";
            this.csvGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.csvGridView.Size = new System.Drawing.Size(552, 376);
            this.csvGridView.TabIndex = 0;
            this.csvGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.csvGridView_DataBindingComplete);
            // 
            // gridViewContextMenuStrip
            // 
            this.gridViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteSelectedRowsToolStripMenuItem,
            this.insertOneRowUpToolStripMenuItem,
            this.insertOneRowDownToolStripMenuItem});
            this.gridViewContextMenuStrip.Name = "gridViewContextMenuStrip";
            this.gridViewContextMenuStrip.Size = new System.Drawing.Size(191, 120);
            this.gridViewContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.gridViewContextMenuStrip_Opening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = global::DtPad.ToolbarResource.arrow_left;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.undoToolStripMenuItem.Text = "Undo Last Action";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // deleteSelectedRowsToolStripMenuItem
            // 
            this.deleteSelectedRowsToolStripMenuItem.Name = "deleteSelectedRowsToolStripMenuItem";
            this.deleteSelectedRowsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.deleteSelectedRowsToolStripMenuItem.Text = "Delete Selected Row/s";
            this.deleteSelectedRowsToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedRowsToolStripMenuItem_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(422, 463);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(142, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // delimiterLabel
            // 
            this.delimiterLabel.AutoSize = true;
            this.delimiterLabel.Location = new System.Drawing.Point(6, 23);
            this.delimiterLabel.Name = "delimiterLabel";
            this.delimiterLabel.Size = new System.Drawing.Size(50, 13);
            this.delimiterLabel.TabIndex = 0;
            this.delimiterLabel.Text = "Delimiter:";
            // 
            // headerCheckBox
            // 
            this.headerCheckBox.AutoSize = true;
            this.headerCheckBox.Location = new System.Drawing.Point(268, 23);
            this.headerCheckBox.Name = "headerCheckBox";
            this.headerCheckBox.Size = new System.Drawing.Size(99, 17);
            this.headerCheckBox.TabIndex = 2;
            this.headerCheckBox.Text = "Header present";
            this.headerCheckBox.UseVisualStyleBackColor = true;
            this.headerCheckBox.CheckedChanged += new System.EventHandler(this.headerCheckBox_CheckedChanged);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsGroupBox.Controls.Add(this.quoteComboBox);
            this.settingsGroupBox.Controls.Add(this.quoteLabel);
            this.settingsGroupBox.Controls.Add(this.delimiterComboBox);
            this.settingsGroupBox.Controls.Add(this.delimiterLabel);
            this.settingsGroupBox.Controls.Add(this.headerCheckBox);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 410);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(404, 77);
            this.settingsGroupBox.TabIndex = 1;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "File configuration";
            // 
            // quoteComboBox
            // 
            this.quoteComboBox.FormattingEnabled = true;
            this.quoteComboBox.Items.AddRange(new object[] {
            global::DtPad.Languages.it.SearchInFiles_searchFolderComboBoxItems,
            "\" (quotes)",
            "\' (single quote)"});
            this.quoteComboBox.Location = new System.Drawing.Point(76, 47);
            this.quoteComboBox.MaxLength = 1;
            this.quoteComboBox.Name = "quoteComboBox";
            this.quoteComboBox.Size = new System.Drawing.Size(141, 21);
            this.quoteComboBox.TabIndex = 4;
            this.quoteComboBox.TextChanged += new System.EventHandler(this.quoteComboBox_TextChanged);
            // 
            // quoteLabel
            // 
            this.quoteLabel.AutoSize = true;
            this.quoteLabel.Location = new System.Drawing.Point(6, 50);
            this.quoteLabel.Name = "quoteLabel";
            this.quoteLabel.Size = new System.Drawing.Size(39, 13);
            this.quoteLabel.TabIndex = 3;
            this.quoteLabel.Text = "Quote:";
            // 
            // delimiterComboBox
            // 
            this.delimiterComboBox.FormattingEnabled = true;
            this.delimiterComboBox.Items.AddRange(new object[] {
            global::DtPad.Languages.it.SearchInFiles_searchFolderComboBoxItems,
            ", (comma)",
            ". (dot)",
            "; (semicolon)",
            "- (dash)"});
            this.delimiterComboBox.Location = new System.Drawing.Point(76, 20);
            this.delimiterComboBox.MaxLength = 1;
            this.delimiterComboBox.Name = "delimiterComboBox";
            this.delimiterComboBox.Size = new System.Drawing.Size(141, 21);
            this.delimiterComboBox.TabIndex = 1;
            this.delimiterComboBox.TextChanged += new System.EventHandler(this.delimiterComboBox_TextChanged);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Enabled = false;
            this.applyButton.Image = global::DtPad.MessageBoxResource.ok;
            this.applyButton.Location = new System.Drawing.Point(422, 433);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(142, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply changes";
            this.applyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.applyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // csvEditorToolStrip
            // 
            this.csvEditorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripSplitButton});
            this.csvEditorToolStrip.Location = new System.Drawing.Point(0, 0);
            this.csvEditorToolStrip.Name = "csvEditorToolStrip";
            this.csvEditorToolStrip.Size = new System.Drawing.Size(576, 25);
            this.csvEditorToolStrip.TabIndex = 4;
            this.csvEditorToolStrip.Text = "toolStrip1";
            // 
            // undoToolStripSplitButton
            // 
            this.undoToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoAllToolStripMenuItem});
            this.undoToolStripSplitButton.Image = global::DtPad.ToolbarResource.arrow_left;
            this.undoToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolStripSplitButton.Name = "undoToolStripSplitButton";
            this.undoToolStripSplitButton.Size = new System.Drawing.Size(32, 22);
            this.undoToolStripSplitButton.Text = "Undo Last Action";
            this.undoToolStripSplitButton.ButtonClick += new System.EventHandler(this.undoToolStripSplitButton_ButtonClick);
            // 
            // undoAllToolStripMenuItem
            // 
            this.undoAllToolStripMenuItem.Name = "undoAllToolStripMenuItem";
            this.undoAllToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.undoAllToolStripMenuItem.Text = "Undo All";
            this.undoAllToolStripMenuItem.Click += new System.EventHandler(this.undoAllToolStripMenuItem_Click);
            // 
            // contentContextMenuStrip
            // 
            this.contentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator29,
            this.selectAllToolStripMenuItem});
            this.contentContextMenuStrip.Name = "searchContextMenuStrip";
            this.contentContextMenuStrip.Size = new System.Drawing.Size(123, 120);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::DtPad.ToolbarResource.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::DtPad.ToolbarResource.paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
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
            // 
            // insertOneRowUpToolStripMenuItem
            // 
            this.insertOneRowUpToolStripMenuItem.Name = "insertOneRowUpToolStripMenuItem";
            this.insertOneRowUpToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.insertOneRowUpToolStripMenuItem.Text = "Insert One Row Up";
            this.insertOneRowUpToolStripMenuItem.Click += new System.EventHandler(this.insertOneRowUpToolStripMenuItem_Click);
            // 
            // insertOneRowDownToolStripMenuItem
            // 
            this.insertOneRowDownToolStripMenuItem.Name = "insertOneRowDownToolStripMenuItem";
            this.insertOneRowDownToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.insertOneRowDownToolStripMenuItem.Text = "Insert One Row Down";
            this.insertOneRowDownToolStripMenuItem.Click += new System.EventHandler(this.insertOneRowDownToolStripMenuItem_Click);
            // 
            // CsvEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 498);
            this.Controls.Add(this.csvEditorToolStrip);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.csvGridView);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(538, 337);
            this.Name = "CsvEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CsvEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.csvGridView)).EndInit();
            this.gridViewContextMenuStrip.ResumeLayout(false);
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.csvEditorToolStrip.ResumeLayout(false);
            this.csvEditorToolStrip.PerformLayout();
            this.contentContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label delimiterLabel;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.ComboBox delimiterComboBox;
        private System.Windows.Forms.ComboBox quoteComboBox;
        private System.Windows.Forms.Label quoteLabel;
        private System.Windows.Forms.Button applyButton;
        internal System.Windows.Forms.DataGridView csvGridView;
        internal System.Windows.Forms.CheckBox headerCheckBox;
        private System.Windows.Forms.ContextMenuStrip gridViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip csvEditorToolStrip;
        private System.Windows.Forms.ToolStripSplitButton undoToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem undoAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip contentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem insertOneRowUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertOneRowDownToolStripMenuItem;
    }
}
