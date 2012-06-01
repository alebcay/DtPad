namespace DtPad
{
    partial class DropboxFileDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropboxFileDialog));
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.contentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fseListView = new System.Windows.Forms.ListView();
            this.dropboxFileDialogContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.saveAsLabel = new System.Windows.Forms.Label();
            this.saveInLabel = new System.Windows.Forms.Label();
            this.saveAsComboBox = new System.Windows.Forms.ComboBox();
            this.dropboxFileDialogToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.superiorLevelButton = new System.Windows.Forms.Button();
            this.newFolderButton = new System.Windows.Forms.Button();
            this.positionLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.textMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewComboBox = new System.Windows.Forms.ComboBox();
            this.contentContextMenuStrip.SuspendLayout();
            this.dropboxFileDialogContextMenuStrip.SuspendLayout();
            this.textMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(12, 253);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(55, 13);
            this.fileNameLabel.TabIndex = 6;
            this.fileNameLabel.Text = "File name:";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.fileNameTextBox.Location = new System.Drawing.Point(87, 250);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(309, 20);
            this.fileNameTextBox.TabIndex = 7;
            this.fileNameTextBox.TextChanged += new System.EventHandler(this.fileNameTextBox_TextChanged);
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
            this.contentContextMenuStrip.Name = "searchContextMenuStrip";
            this.contentContextMenuStrip.Size = new System.Drawing.Size(129, 148);
            this.contentContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contentContextMenuStrip_Opening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::DtPad.ToolbarResource.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::DtPad.ToolbarResource.paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(125, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.selectAllToolStripMenuItem_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(408, 277);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // fseListView
            // 
            this.fseListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fseListView.ContextMenuStrip = this.dropboxFileDialogContextMenuStrip;
            this.fseListView.LabelEdit = true;
            this.fseListView.LargeImageList = this.imageListLarge;
            this.fseListView.Location = new System.Drawing.Point(12, 34);
            this.fseListView.MultiSelect = false;
            this.fseListView.Name = "fseListView";
            this.fseListView.Size = new System.Drawing.Size(471, 208);
            this.fseListView.SmallImageList = this.imageList;
            this.fseListView.TabIndex = 5;
            this.fseListView.UseCompatibleStateImageBehavior = false;
            this.fseListView.View = System.Windows.Forms.View.List;
            this.fseListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.fseListView_AfterLabelEdit);
            this.fseListView.ItemActivate += new System.EventHandler(this.fseListView_ItemActivate);
            this.fseListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.fseListView_ItemSelectionChanged);
            // 
            // dropboxFileDialogContextMenuStrip
            // 
            this.dropboxFileDialogContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1});
            this.dropboxFileDialogContextMenuStrip.Name = "dropboxFileDialogContextMenuStrip";
            this.dropboxFileDialogContextMenuStrip.Size = new System.Drawing.Size(153, 48);
            this.dropboxFileDialogContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.dropboxFileDialogContextMenuStrip_Opening);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = global::DtPad.ToolbarResource.delete;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // imageListLarge
            // 
            this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLarge.Images.SetKeyName(0, "folder-32.gif");
            this.imageListLarge.Images.SetKeyName(1, "paper-32.gif");
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.gif");
            this.imageList.Images.SetKeyName(1, "paper.gif");
            // 
            // saveAsLabel
            // 
            this.saveAsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveAsLabel.AutoSize = true;
            this.saveAsLabel.Location = new System.Drawing.Point(12, 282);
            this.saveAsLabel.Name = "saveAsLabel";
            this.saveAsLabel.Size = new System.Drawing.Size(49, 13);
            this.saveAsLabel.TabIndex = 8;
            this.saveAsLabel.Text = "Save as:";
            // 
            // saveInLabel
            // 
            this.saveInLabel.AutoSize = true;
            this.saveInLabel.Location = new System.Drawing.Point(12, 9);
            this.saveInLabel.Name = "saveInLabel";
            this.saveInLabel.Size = new System.Drawing.Size(46, 13);
            this.saveInLabel.TabIndex = 0;
            this.saveInLabel.Text = "Save in:";
            // 
            // saveAsComboBox
            // 
            this.saveAsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saveAsComboBox.FormattingEnabled = true;
            this.saveAsComboBox.Location = new System.Drawing.Point(87, 279);
            this.saveAsComboBox.Name = "saveAsComboBox";
            this.saveAsComboBox.Size = new System.Drawing.Size(309, 21);
            this.saveAsComboBox.TabIndex = 9;
            this.saveAsComboBox.SelectedIndexChanged += new System.EventHandler(this.saveAsComboBox_SelectedIndexChanged);
            // 
            // superiorLevelButton
            // 
            this.superiorLevelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.superiorLevelButton.Image = global::DtPad.ToolbarResource.folder_up;
            this.superiorLevelButton.Location = new System.Drawing.Point(431, 4);
            this.superiorLevelButton.Name = "superiorLevelButton";
            this.superiorLevelButton.Size = new System.Drawing.Size(23, 23);
            this.superiorLevelButton.TabIndex = 3;
            this.dropboxFileDialogToolTip.SetToolTip(this.superiorLevelButton, "Superior level");
            this.superiorLevelButton.UseVisualStyleBackColor = true;
            this.superiorLevelButton.Click += new System.EventHandler(this.superiorLevelButton_Click);
            // 
            // newFolderButton
            // 
            this.newFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newFolderButton.Image = global::DtPad.ToolbarResource.folder_plus;
            this.newFolderButton.Location = new System.Drawing.Point(460, 4);
            this.newFolderButton.Name = "newFolderButton";
            this.newFolderButton.Size = new System.Drawing.Size(23, 23);
            this.newFolderButton.TabIndex = 4;
            this.dropboxFileDialogToolTip.SetToolTip(this.newFolderButton, "Create new folder");
            this.newFolderButton.UseVisualStyleBackColor = true;
            this.newFolderButton.Click += new System.EventHandler(this.newFolderButton_Click);
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(70, 9);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(12, 13);
            this.positionLabel.TabIndex = 1;
            this.positionLabel.Text = "/";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Enabled = false;
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(408, 248);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Save";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // textMenuStrip
            // 
            this.textMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem2,
            this.toolStripSeparator2,
            this.selectAllToolStripMenuItem2});
            this.textMenuStrip.Name = "searchContextMenuStrip";
            this.textMenuStrip.Size = new System.Drawing.Size(153, 76);
            // 
            // copyToolStripMenuItem2
            // 
            this.copyToolStripMenuItem2.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem2.Name = "copyToolStripMenuItem2";
            this.copyToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem2.Text = "Copy";
            this.copyToolStripMenuItem2.Click += new System.EventHandler(DtPad.Customs.CustomEvents.copyToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // selectAllToolStripMenuItem2
            // 
            this.selectAllToolStripMenuItem2.Name = "selectAllToolStripMenuItem2";
            this.selectAllToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.selectAllToolStripMenuItem2.Text = "Select All";
            this.selectAllToolStripMenuItem2.Click += new System.EventHandler(DtPad.Customs.CustomEvents.selectAllToolStripMenuItem_Click);
            // 
            // viewComboBox
            // 
            this.viewComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.viewComboBox.FormattingEnabled = true;
            this.viewComboBox.Items.AddRange(new object[] {
            "Large icon",
            "Small icon",
            "List",
            "Tile"});
            this.viewComboBox.Location = new System.Drawing.Point(320, 5);
            this.viewComboBox.Name = "viewComboBox";
            this.viewComboBox.Size = new System.Drawing.Size(105, 21);
            this.viewComboBox.TabIndex = 2;
            this.viewComboBox.SelectedIndexChanged += new System.EventHandler(this.viewComboBox_SelectedIndexChanged);
            // 
            // DropboxFileDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(495, 312);
            this.Controls.Add(this.viewComboBox);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.saveAsComboBox);
            this.Controls.Add(this.superiorLevelButton);
            this.Controls.Add(this.saveInLabel);
            this.Controls.Add(this.newFolderButton);
            this.Controls.Add(this.saveAsLabel);
            this.Controls.Add(this.fseListView);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.fileNameLabel);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DropboxFileDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save File As";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.DropboxFileDialog_HelpButtonClicked);
            this.contentContextMenuStrip.ResumeLayout(false);
            this.dropboxFileDialogContextMenuStrip.ResumeLayout(false);
            this.textMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ContextMenuStrip contentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ListView fseListView;
        private System.Windows.Forms.Label saveAsLabel;
        private System.Windows.Forms.Label saveInLabel;
        private System.Windows.Forms.Button newFolderButton;
        private System.Windows.Forms.Button superiorLevelButton;
        private System.Windows.Forms.ComboBox saveAsComboBox;
        private System.Windows.Forms.ToolTip dropboxFileDialogToolTip;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.ContextMenuStrip textMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip dropboxFileDialogContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ComboBox viewComboBox;
        private System.Windows.Forms.ImageList imageListLarge;
    }
}
