namespace DtPad.UserControls
{
    partial class TabPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabPanel));
            this.tabToolStrip = new System.Windows.Forms.ToolStrip();
            this.moveTabFirstToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveTabUpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveTabDownToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveTabLastToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sortTabsAlphabeticallyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabExplorerTreeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabToolStrip
            // 
            this.tabToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveTabFirstToolStripButton,
            this.moveTabUpToolStripButton,
            this.moveTabDownToolStripButton,
            this.moveTabLastToolStripButton,
            this.toolStripSeparator1,
            this.closeAllToolStripButton,
            this.toolStripSeparator2,
            this.sortTabsAlphabeticallyToolStripButton});
            this.tabToolStrip.Location = new System.Drawing.Point(0, 0);
            this.tabToolStrip.Name = "tabToolStrip";
            this.tabToolStrip.Size = new System.Drawing.Size(150, 25);
            this.tabToolStrip.TabIndex = 0;
            this.tabToolStrip.Text = "tabToolStrip";
            // 
            // moveTabFirstToolStripButton
            // 
            this.moveTabFirstToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveTabFirstToolStripButton.Enabled = false;
            this.moveTabFirstToolStripButton.Image = global::DtPad.ToolbarResource.move_first;
            this.moveTabFirstToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveTabFirstToolStripButton.Name = "moveTabFirstToolStripButton";
            this.moveTabFirstToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveTabFirstToolStripButton.Text = "Move First";
            this.moveTabFirstToolStripButton.Click += new System.EventHandler(this.moveTabFirstToolStripButton_Click);
            // 
            // moveTabUpToolStripButton
            // 
            this.moveTabUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveTabUpToolStripButton.Enabled = false;
            this.moveTabUpToolStripButton.Image = global::DtPad.ToolbarResource.move_up;
            this.moveTabUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveTabUpToolStripButton.Name = "moveTabUpToolStripButton";
            this.moveTabUpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveTabUpToolStripButton.Text = "Move Up";
            this.moveTabUpToolStripButton.Click += new System.EventHandler(this.moveTabUpToolStripButton_Click);
            // 
            // moveTabDownToolStripButton
            // 
            this.moveTabDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveTabDownToolStripButton.Enabled = false;
            this.moveTabDownToolStripButton.Image = global::DtPad.ToolbarResource.move_down;
            this.moveTabDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveTabDownToolStripButton.Name = "moveTabDownToolStripButton";
            this.moveTabDownToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveTabDownToolStripButton.Text = "Move Down";
            this.moveTabDownToolStripButton.Click += new System.EventHandler(this.moveTabDownToolStripButton_Click);
            // 
            // moveTabLastToolStripButton
            // 
            this.moveTabLastToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveTabLastToolStripButton.Enabled = false;
            this.moveTabLastToolStripButton.Image = global::DtPad.ToolbarResource.move_last;
            this.moveTabLastToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveTabLastToolStripButton.Name = "moveTabLastToolStripButton";
            this.moveTabLastToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveTabLastToolStripButton.Text = "Move Last";
            this.moveTabLastToolStripButton.Click += new System.EventHandler(this.moveTabLastToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // closeAllToolStripButton
            // 
            this.closeAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeAllToolStripButton.Image = global::DtPad.ToolbarResource.minus_more;
            this.closeAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeAllToolStripButton.Name = "closeAllToolStripButton";
            this.closeAllToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.closeAllToolStripButton.Text = "Close All";
            this.closeAllToolStripButton.Click += new System.EventHandler(this.closeAllToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // sortTabsAlphabeticallyToolStripButton
            // 
            this.sortTabsAlphabeticallyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sortTabsAlphabeticallyToolStripButton.Image = global::DtPad.ToolbarResource.sort;
            this.sortTabsAlphabeticallyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortTabsAlphabeticallyToolStripButton.Name = "sortTabsAlphabeticallyToolStripButton";
            this.sortTabsAlphabeticallyToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.sortTabsAlphabeticallyToolStripButton.Text = "Sort Tabs Alphabetically";
            this.sortTabsAlphabeticallyToolStripButton.Click += new System.EventHandler(this.sortTabsAlphabeticallyToolStripButton_Click);
            // 
            // tabExplorerTreeView
            // 
            this.tabExplorerTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabExplorerTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabExplorerTreeView.FullRowSelect = true;
            this.tabExplorerTreeView.ImageIndex = 0;
            this.tabExplorerTreeView.ImageList = this.imageList;
            this.tabExplorerTreeView.Indent = 5;
            this.tabExplorerTreeView.Location = new System.Drawing.Point(0, 25);
            this.tabExplorerTreeView.Name = "tabExplorerTreeView";
            this.tabExplorerTreeView.SelectedImageIndex = 0;
            this.tabExplorerTreeView.ShowLines = false;
            this.tabExplorerTreeView.ShowPlusMinus = false;
            this.tabExplorerTreeView.ShowRootLines = false;
            this.tabExplorerTreeView.Size = new System.Drawing.Size(150, 125);
            this.tabExplorerTreeView.TabIndex = 1;
            this.tabExplorerTreeView.Tag = "DontTranslate";
            this.tabExplorerTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tabExplorerTreeView_NodeMouseClick);
            this.tabExplorerTreeView.LostFocus += new System.EventHandler(this.tabExplorerTreeView_LostFocus);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "paper.png");
            this.imageList.Images.SetKeyName(1, "paper-edit.png");
            this.imageList.Images.SetKeyName(2, "lock-blue.png");
            this.imageList.Images.SetKeyName(3, "lock-yellow.png");
            // 
            // TabPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabExplorerTreeView);
            this.Controls.Add(this.tabToolStrip);
            this.Name = "TabPanel";
            this.tabToolStrip.ResumeLayout(false);
            this.tabToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip tabToolStrip;
        internal System.Windows.Forms.TreeView tabExplorerTreeView;
        internal System.Windows.Forms.ToolStripButton moveTabFirstToolStripButton;
        internal System.Windows.Forms.ToolStripButton moveTabUpToolStripButton;
        internal System.Windows.Forms.ToolStripButton moveTabDownToolStripButton;
        internal System.Windows.Forms.ToolStripButton moveTabLastToolStripButton;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sortTabsAlphabeticallyToolStripButton;
        private System.Windows.Forms.ToolStripButton closeAllToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
