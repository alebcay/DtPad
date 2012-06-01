namespace DtPad.UserControls
{
    partial class FilePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilePanel));
            this.fileExplorerTreeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.fileContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.directoryContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openIntoWindowsExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.listFolderContentIntoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listFolderContentWithLenghtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listFolderContentWithPatternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listFolderContentWithPatternValueToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.includeSubdirectoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pathPanel = new DtPad.Customs.CustomPanel();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathGoButton = new System.Windows.Forms.Button();
            this.openSelectedFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.hiddenToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshDriveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileContextMenuStrip.SuspendLayout();
            this.directoryContextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.pathPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileExplorerTreeView
            // 
            this.fileExplorerTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileExplorerTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileExplorerTreeView.HideSelection = false;
            this.fileExplorerTreeView.ImageIndex = 0;
            this.fileExplorerTreeView.ImageList = this.imageList;
            this.fileExplorerTreeView.Location = new System.Drawing.Point(0, 53);
            this.fileExplorerTreeView.Name = "fileExplorerTreeView";
            this.fileExplorerTreeView.SelectedImageIndex = 0;
            this.fileExplorerTreeView.Size = new System.Drawing.Size(189, 97);
            this.fileExplorerTreeView.TabIndex = 2;
            this.fileExplorerTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.fileExplorerTreeView_BeforeCollapse);
            this.fileExplorerTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.fileExplorerTreeView_BeforeExpand);
            this.fileExplorerTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fileExplorerTreeView_AfterSelect);
            this.fileExplorerTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.fileExplorerTreeView_NodeMouseClick);
            this.fileExplorerTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.fileExplorerTreeView_NodeMouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "desktop.gif");
            this.imageList.Images.SetKeyName(1, "drive.gif");
            this.imageList.Images.SetKeyName(2, "cd.gif");
            this.imageList.Images.SetKeyName(3, "network.gif");
            this.imageList.Images.SetKeyName(4, "removable.gif");
            this.imageList.Images.SetKeyName(5, "folder.gif");
            this.imageList.Images.SetKeyName(6, "paper.gif");
            this.imageList.Images.SetKeyName(7, "prohibited.gif");
            this.imageList.Images.SetKeyName(8, "folder-hidden.gif");
            this.imageList.Images.SetKeyName(9, "paper-hidden.gif");
            this.imageList.Images.SetKeyName(10, "paper-img.gif");
            this.imageList.Images.SetKeyName(11, "paper-pdf.gif");
            this.imageList.Images.SetKeyName(12, "paper-doc.gif");
            this.imageList.Images.SetKeyName(13, "paper-xls.gif");
            this.imageList.Images.SetKeyName(14, "paper-ppt.gif");
            this.imageList.Images.SetKeyName(15, "paper-mdb.gif");
            this.imageList.Images.SetKeyName(16, "paper-mov.gif");
            this.imageList.Images.SetKeyName(17, "paper-txt.gif");
            // 
            // fileContextMenuStrip
            // 
            this.fileContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.filePropertiesToolStripMenuItem});
            this.fileContextMenuStrip.Name = "fileContextMenuStrip";
            this.fileContextMenuStrip.Size = new System.Drawing.Size(149, 48);
            // 
            // directoryContextMenuStrip
            // 
            this.directoryContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.openIntoWindowsExplorerToolStripMenuItem,
            this.toolStripSeparator2,
            this.listFolderContentIntoFileToolStripMenuItem,
            this.listFolderContentWithLenghtToolStripMenuItem,
            this.listFolderContentWithPatternToolStripMenuItem});
            this.directoryContextMenuStrip.Name = "directoryContextMenuStrip";
            this.directoryContextMenuStrip.Size = new System.Drawing.Size(245, 120);
            // 
            // openIntoWindowsExplorerToolStripMenuItem
            // 
            this.openIntoWindowsExplorerToolStripMenuItem.Name = "openIntoWindowsExplorerToolStripMenuItem";
            this.openIntoWindowsExplorerToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.openIntoWindowsExplorerToolStripMenuItem.Text = "Open Into Windows Explorer";
            this.openIntoWindowsExplorerToolStripMenuItem.Click += new System.EventHandler(this.openIntoWindowsExplorerToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(241, 6);
            // 
            // listFolderContentIntoFileToolStripMenuItem
            // 
            this.listFolderContentIntoFileToolStripMenuItem.Name = "listFolderContentIntoFileToolStripMenuItem";
            this.listFolderContentIntoFileToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.listFolderContentIntoFileToolStripMenuItem.Text = "List Folder Content";
            this.listFolderContentIntoFileToolStripMenuItem.Click += new System.EventHandler(this.listFolderContentIntoFileToolStripMenuItem_Click);
            // 
            // listFolderContentWithLenghtToolStripMenuItem
            // 
            this.listFolderContentWithLenghtToolStripMenuItem.Name = "listFolderContentWithLenghtToolStripMenuItem";
            this.listFolderContentWithLenghtToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.listFolderContentWithLenghtToolStripMenuItem.Text = "List Folder Content (With Sizes)";
            this.listFolderContentWithLenghtToolStripMenuItem.Click += new System.EventHandler(this.listFolderContentWithLenghtToolStripMenuItem_Click);
            // 
            // listFolderContentWithPatternToolStripMenuItem
            // 
            this.listFolderContentWithPatternToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listFolderContentWithPatternValueToolStripMenuItem,
            this.includeSubdirectoriesToolStripMenuItem,
            this.showSizeToolStripMenuItem,
            this.toolStripSeparator3,
            this.listToolStripMenuItem});
            this.listFolderContentWithPatternToolStripMenuItem.Name = "listFolderContentWithPatternToolStripMenuItem";
            this.listFolderContentWithPatternToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.listFolderContentWithPatternToolStripMenuItem.Text = "List Folder Content (With Filters)";
            // 
            // listFolderContentWithPatternValueToolStripMenuItem
            // 
            this.listFolderContentWithPatternValueToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listFolderContentWithPatternValueToolStripMenuItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listFolderContentWithPatternValueToolStripMenuItem.Name = "listFolderContentWithPatternValueToolStripMenuItem";
            this.listFolderContentWithPatternValueToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.listFolderContentWithPatternValueToolStripMenuItem.Text = "*.*";
            this.listFolderContentWithPatternValueToolStripMenuItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listFolderContentWithPatternValueToolStripMenuItem_KeyUp);
            // 
            // includeSubdirectoriesToolStripMenuItem
            // 
            this.includeSubdirectoriesToolStripMenuItem.CheckOnClick = true;
            this.includeSubdirectoriesToolStripMenuItem.Name = "includeSubdirectoriesToolStripMenuItem";
            this.includeSubdirectoriesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.includeSubdirectoriesToolStripMenuItem.Text = "Include Subdirectories";
            // 
            // showSizeToolStripMenuItem
            // 
            this.showSizeToolStripMenuItem.CheckOnClick = true;
            this.showSizeToolStripMenuItem.Name = "showSizeToolStripMenuItem";
            this.showSizeToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.showSizeToolStripMenuItem.Text = "Show Size";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.listToolStripMenuItem.Text = "Write List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSelectedFileToolStripButton,
            this.refreshToolStripButton,
            this.refreshDriveToolStripButton,
            this.toolStripSeparator1,
            this.hiddenToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(189, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // pathPanel
            // 
            this.pathPanel.BackColor = System.Drawing.Color.White;
            this.pathPanel.Controls.Add(this.pathTextBox);
            this.pathPanel.Controls.Add(this.pathGoButton);
            this.pathPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pathPanel.HorizontalLine = true;
            this.pathPanel.HorizontalLineOnTop = false;
            this.pathPanel.Location = new System.Drawing.Point(0, 25);
            this.pathPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.pathPanel.MarginBottomHorizontalLine = 4;
            this.pathPanel.MarginLeftHorizontalLine = 0;
            this.pathPanel.MarginTopHorizontalLine = 1;
            this.pathPanel.Name = "pathPanel";
            this.pathPanel.NotShowLine = false;
            this.pathPanel.Size = new System.Drawing.Size(189, 28);
            this.pathPanel.TabIndex = 1;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.pathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pathTextBox.Location = new System.Drawing.Point(3, 6);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(160, 13);
            this.pathTextBox.TabIndex = 0;
            this.pathTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pathTextBox_KeyUp);
            this.pathTextBox.Leave += new System.EventHandler(this.pathTextBox_Leave);
            this.pathTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pathTextBox_MouseDown);
            // 
            // pathGoButton
            // 
            this.pathGoButton.BackColor = System.Drawing.Color.White;
            this.pathGoButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pathGoButton.FlatAppearance.BorderSize = 0;
            this.pathGoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pathGoButton.Image = global::DtPad.ToolbarResource.move_down;
            this.pathGoButton.Location = new System.Drawing.Point(166, 0);
            this.pathGoButton.Name = "pathGoButton";
            this.pathGoButton.Size = new System.Drawing.Size(23, 28);
            this.pathGoButton.TabIndex = 1;
            this.pathGoButton.UseVisualStyleBackColor = false;
            this.pathGoButton.Click += new System.EventHandler(this.pathGoButton_Click);
            // 
            // openSelectedFileToolStripButton
            // 
            this.openSelectedFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openSelectedFileToolStripButton.Enabled = false;
            this.openSelectedFileToolStripButton.Image = global::DtPad.ToolbarResource.open;
            this.openSelectedFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openSelectedFileToolStripButton.Name = "openSelectedFileToolStripButton";
            this.openSelectedFileToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openSelectedFileToolStripButton.Text = "Open Selected File";
            this.openSelectedFileToolStripButton.Click += new System.EventHandler(this.openSelectedFileToolStripButton_Click);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::DtPad.ToolbarResource.convert;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolStripButton.Text = "Refresh Selected Folder";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // hiddenToolStripButton
            // 
            this.hiddenToolStripButton.CheckOnClick = true;
            this.hiddenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hiddenToolStripButton.Image = global::DtPad.ToolbarResource.layers;
            this.hiddenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hiddenToolStripButton.Name = "hiddenToolStripButton";
            this.hiddenToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.hiddenToolStripButton.Text = "Show Hidden Files/Folders";
            this.hiddenToolStripButton.CheckedChanged += new System.EventHandler(this.hiddenToolStripButton_CheckedChanged);
            // 
            // refreshDriveToolStripButton
            // 
            this.refreshDriveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshDriveToolStripButton.Image = global::DtPad.ToolbarResource.convert_all;
            this.refreshDriveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshDriveToolStripButton.Name = "refreshDriveToolStripButton";
            this.refreshDriveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshDriveToolStripButton.Text = "Refresh Drives";
            this.refreshDriveToolStripButton.Click += new System.EventHandler(this.refreshDriveToolStripButton_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::DtPad.ToolbarResource.open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // filePropertiesToolStripMenuItem
            // 
            this.filePropertiesToolStripMenuItem.Image = global::DtPad.ToolbarResource.diagram;
            this.filePropertiesToolStripMenuItem.Name = "filePropertiesToolStripMenuItem";
            this.filePropertiesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.filePropertiesToolStripMenuItem.Text = "File Properties";
            this.filePropertiesToolStripMenuItem.Click += new System.EventHandler(this.filePropertiesToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::DtPad.ToolbarResource.convert;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // FilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileExplorerTreeView);
            this.Controls.Add(this.pathPanel);
            this.Controls.Add(this.toolStrip);
            this.Name = "FilePanel";
            this.Size = new System.Drawing.Size(189, 150);
            this.Load += new System.EventHandler(this.FilePanel_Load);
            this.fileContextMenuStrip.ResumeLayout(false);
            this.directoryContextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.pathPanel.ResumeLayout(false);
            this.pathPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TreeView fileExplorerTreeView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip fileContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openIntoWindowsExplorerToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip directoryContextMenuStrip;
        internal System.Windows.Forms.ToolStripButton hiddenToolStripButton;
        internal System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton openSelectedFileToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem listFolderContentIntoFileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem filePropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listFolderContentWithLenghtToolStripMenuItem;
        private Customs.CustomPanel pathPanel;
        internal System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button pathGoButton;
        private System.Windows.Forms.ToolStripMenuItem listFolderContentWithPatternToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox listFolderContentWithPatternValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeSubdirectoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton refreshDriveToolStripButton;
    }
}
