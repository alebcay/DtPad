namespace DtPad
{
    partial class Dictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dictionary));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.wordTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchButton = new System.Windows.Forms.Button();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.contentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageImageList = new System.Windows.Forms.ImageList(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.languageLabel = new System.Windows.Forms.Label();
            this.wordLabel = new System.Windows.Forms.Label();
            this.languageComboBox = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.dictionariesLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.verifyAllButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.contentContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languageComboBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // wordTextBox
            // 
            this.wordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordTextBox.ContextMenuStrip = this.contextMenuStrip1;
            this.wordTextBox.Location = new System.Drawing.Point(76, 12);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(391, 20);
            this.wordTextBox.TabIndex = 1;
            this.wordTextBox.TextChanged += new System.EventHandler(this.wordTextBox_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator2,
            this.cutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator29,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "searchContextMenuStrip";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 148);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::DtPad.ToolbarResource.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.cutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::DtPad.ToolbarResource.copy;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(DtPad.Customs.CustomEvents.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::DtPad.ToolbarResource.paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem2.Text = "Select All";
            this.toolStripMenuItem2.Click += new System.EventHandler(DtPad.Customs.CustomEvents.selectAllToolStripMenuItem_Click);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(473, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // contentTextBox
            // 
            this.contentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.contentTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.contentTextBox.Location = new System.Drawing.Point(12, 75);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.ReadOnly = true;
            this.contentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.contentTextBox.Size = new System.Drawing.Size(536, 186);
            this.contentTextBox.TabIndex = 5;
            this.contentTextBox.TextChanged += new System.EventHandler(this.contentTextBox_TextChanged);
            this.contentTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.contentTextBox_KeyDown);
            // 
            // contentContextMenuStrip
            // 
            this.contentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.toolStripSeparator1,
            this.selectAllToolStripMenuItem});
            this.contentContextMenuStrip.Name = "contentContextMenuStrip";
            this.contentContextMenuStrip.Size = new System.Drawing.Size(129, 54);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.copyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.selectAllToolStripMenuItem_Click);
            // 
            // languageImageList
            // 
            this.languageImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("languageImageList.ImageStream")));
            this.languageImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.languageImageList.Images.SetKeyName(0, "flag-eng.png");
            this.languageImageList.Images.SetKeyName(1, "flag-ita.png");
            this.languageImageList.Images.SetKeyName(2, "flag-fra.png");
            this.languageImageList.Images.SetKeyName(3, "flag-esp.png");
            this.languageImageList.Images.SetKeyName(4, "flag-ger.png");
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(473, 277);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Close";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(9, 41);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(58, 13);
            this.languageLabel.TabIndex = 3;
            this.languageLabel.Text = "Language:";
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Location = new System.Drawing.Point(9, 15);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(36, 13);
            this.wordLabel.TabIndex = 0;
            this.wordLabel.Text = "Word:";
            // 
            // languageComboBox
            // 
            this.languageComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.languageComboBox.EditValue = "English";
            this.languageComboBox.Location = new System.Drawing.Point(76, 38);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, global::DtPad.Languages.it.SearchInFiles_searchFolderComboBoxItems, 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, global::DtPad.Languages.it.SearchInFiles_searchFolderComboBoxItems, null, null, false)});
            this.languageComboBox.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("English", "English", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Italiano", "Italiano", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Française", "Française", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Español", "Español", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Deutsch", "Deutsch", 4)});
            this.languageComboBox.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.languageComboBox.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.languageComboBox.Properties.SmallImages = this.languageImageList;
            this.languageComboBox.Size = new System.Drawing.Size(391, 20);
            this.languageComboBox.TabIndex = 4;
            // 
            // dictionariesLabel
            // 
            this.dictionariesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dictionariesLabel.AutoSize = true;
            this.dictionariesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dictionariesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dictionariesLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dictionariesLabel.Location = new System.Drawing.Point(9, 282);
            this.dictionariesLabel.Name = "dictionariesLabel";
            this.dictionariesLabel.Size = new System.Drawing.Size(194, 13);
            this.dictionariesLabel.TabIndex = 6;
            this.dictionariesLabel.Text = "Click here to download new dictionaries";
            this.dictionariesLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dictionariesLabel_MouseClick);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Image = global::DtPad.ToolbarResource.bin;
            this.clearButton.Location = new System.Drawing.Point(347, 277);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(104, 23);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear results";
            this.clearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // verifyAllButton
            // 
            this.verifyAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.verifyAllButton.Image = global::DtPad.MessageBoxResource.ok;
            this.verifyAllButton.Location = new System.Drawing.Point(217, 277);
            this.verifyAllButton.Name = "verifyAllButton";
            this.verifyAllButton.Size = new System.Drawing.Size(124, 23);
            this.verifyAllButton.TabIndex = 7;
            this.verifyAllButton.Text = "Verify all text";
            this.verifyAllButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.verifyAllButton.UseVisualStyleBackColor = true;
            this.verifyAllButton.Click += new System.EventHandler(this.verifyAllButton_Click);
            // 
            // Dictionary
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(560, 312);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.dictionariesLabel);
            this.Controls.Add(this.wordLabel);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.verifyAllButton);
            this.Controls.Add(this.wordTextBox);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(576, 200);
            this.Name = "Dictionary";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dictionary and Thesaurus";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Dictionary_HelpButtonClicked);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contentContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.languageComboBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.ContextMenuStrip contentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ImageList languageImageList;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label wordLabel;
        private DevExpress.XtraEditors.ImageComboBoxEdit languageComboBox;
        private System.Windows.Forms.Label dictionariesLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button verifyAllButton;
    }
}
