namespace DtPad.UserControls
{
    partial class SearchInFilesPanel
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
            this.infoTextLabel = new Customs.CustomTextBox();
            this.infoDirLabel = new Customs.CustomTextBox();
            this.searchInFilesToolStrip = new System.Windows.Forms.ToolStrip();
            this.newSearchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.exportListToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pathBaseToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.searchInFilesListBox = new System.Windows.Forms.ListBox();
            this.searchInFilesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFileFullPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoPanel = new DtPad.Customs.CustomPanel();
            this.searchInFilesToolStrip.SuspendLayout();
            this.searchInFilesContextMenuStrip.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchInFilesToolStrip
            // 
            this.searchInFilesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSearchToolStripButton,
            this.toolStripSeparator2,
            this.openFileToolStripButton,
            this.exportListToolStripButton,
            this.toolStripSeparator1,
            this.clearToolStripButton,
            this.pathBaseToolStripLabel});
            this.searchInFilesToolStrip.Location = new System.Drawing.Point(0, 0);
            this.searchInFilesToolStrip.Name = "searchInFilesToolStrip";
            this.searchInFilesToolStrip.Size = new System.Drawing.Size(150, 25);
            this.searchInFilesToolStrip.TabIndex = 0;
            this.searchInFilesToolStrip.Text = "searchInFilesToolStrip";
            // 
            // newSearchToolStripButton
            // 
            this.newSearchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newSearchToolStripButton.Image = global::DtPad.ToolbarResource.search_in_files;
            this.newSearchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newSearchToolStripButton.Name = "newSearchToolStripButton";
            this.newSearchToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newSearchToolStripButton.Text = "New Search...";
            this.newSearchToolStripButton.Click += new System.EventHandler(this.newSearchToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // openFileToolStripButton
            // 
            this.openFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileToolStripButton.Enabled = false;
            this.openFileToolStripButton.Image = global::DtPad.ToolbarResource.open;
            this.openFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileToolStripButton.Name = "openFileToolStripButton";
            this.openFileToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openFileToolStripButton.Text = "Open Selected Files";
            this.openFileToolStripButton.Click += new System.EventHandler(this.openFileToolStripButton_Click);
            // 
            // exportListToolStripButton
            // 
            this.exportListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportListToolStripButton.Enabled = false;
            this.exportListToolStripButton.Image = global::DtPad.ToolbarResource.note_export;
            this.exportListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportListToolStripButton.Name = "exportListToolStripButton";
            this.exportListToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.exportListToolStripButton.Text = "Export Files List";
            this.exportListToolStripButton.Click += new System.EventHandler(this.exportListToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // clearToolStripButton
            // 
            this.clearToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearToolStripButton.Enabled = false;
            this.clearToolStripButton.Image = global::DtPad.ToolbarResource.bin;
            this.clearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearToolStripButton.Name = "clearToolStripButton";
            this.clearToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.clearToolStripButton.Text = "Clear List";
            this.clearToolStripButton.Click += new System.EventHandler(this.clearToolStripButton_Click);
            // 
            // pathBaseToolStripLabel
            // 
            this.pathBaseToolStripLabel.Name = "pathBaseToolStripLabel";
            this.pathBaseToolStripLabel.Size = new System.Drawing.Size(131, 15);
            this.pathBaseToolStripLabel.Text = "pathBaseToolStripLabel";
            this.pathBaseToolStripLabel.Visible = false;
            // 
            // searchInFilesListBox
            // 
            this.searchInFilesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchInFilesListBox.ContextMenuStrip = this.searchInFilesContextMenuStrip;
            this.searchInFilesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchInFilesListBox.FormattingEnabled = true;
            this.searchInFilesListBox.HorizontalScrollbar = true;
            this.searchInFilesListBox.Location = new System.Drawing.Point(0, 66);
            this.searchInFilesListBox.Name = "searchInFilesListBox";
            this.searchInFilesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.searchInFilesListBox.Size = new System.Drawing.Size(150, 160);
            this.searchInFilesListBox.TabIndex = 2;
            this.searchInFilesListBox.Tag = "DontTranslate";
            this.searchInFilesListBox.SelectedIndexChanged += new System.EventHandler(this.searchInFilesListBox_SelectedIndexChanged);
            this.searchInFilesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.searchInFilesListBox_MouseDoubleClick);
            this.searchInFilesListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.searchInFilesListBox_MouseDown);
            // 
            // searchInFilesContextMenuStrip
            // 
            this.searchInFilesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSelectedFilesToolStripMenuItem,
            this.copyFileFullPathToolStripMenuItem});
            this.searchInFilesContextMenuStrip.Name = "searchInFilesContextMenuStrip";
            this.searchInFilesContextMenuStrip.Size = new System.Drawing.Size(173, 48);
            // 
            // openSelectedFilesToolStripMenuItem
            // 
            this.openSelectedFilesToolStripMenuItem.Image = global::DtPad.ToolbarResource.open;
            this.openSelectedFilesToolStripMenuItem.Name = "openSelectedFilesToolStripMenuItem";
            this.openSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.openSelectedFilesToolStripMenuItem.Text = "Open File";
            this.openSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.openSelectedFilesToolStripMenuItem_Click);
            // 
            // copyFileFullPathToolStripMenuItem
            // 
            this.copyFileFullPathToolStripMenuItem.Name = "copyFileFullPathToolStripMenuItem";
            this.copyFileFullPathToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.copyFileFullPathToolStripMenuItem.Text = "Copy File Full Path";
            this.copyFileFullPathToolStripMenuItem.Click += new System.EventHandler(this.copyFileFullPathToolStripMenuItem_Click);
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.infoTextLabel);
            this.infoPanel.Controls.Add(this.infoDirLabel);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.ForeColor = System.Drawing.Color.SteelBlue;
            this.infoPanel.HorizontalLine = true;
            this.infoPanel.HorizontalLineOnTop = false;
            this.infoPanel.Location = new System.Drawing.Point(0, 25);
            this.infoPanel.MarginBottomHorizontalLine = 3;
            this.infoPanel.MarginLeftHorizontalLine = 0;
            this.infoPanel.MarginTopHorizontalLine = 1;
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.NotShowLine = false;
            this.infoPanel.Size = new System.Drawing.Size(150, 41);
            this.infoPanel.TabIndex = 1;
            // 
            // infoTextLabel
            // 
            this.infoTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTextLabel.BackColor = System.Drawing.Color.White;
            this.infoTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoTextLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.infoTextLabel.Location = new System.Drawing.Point(0, 22);
            this.infoTextLabel.Name = "infoTextLabel";
            this.infoTextLabel.ReadOnly = true;
            this.infoTextLabel.Size = new System.Drawing.Size(150, 13);
            this.infoTextLabel.TabIndex = 1;
            this.infoTextLabel.Tag = "DontTranslate";
            // 
            // infoDirLabel
            // 
            this.infoDirLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.infoDirLabel.BackColor = System.Drawing.Color.White;
            this.infoDirLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoDirLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.infoDirLabel.Location = new System.Drawing.Point(0, 5);
            this.infoDirLabel.Name = "infoDirLabel";
            this.infoDirLabel.ReadOnly = true;
            this.infoDirLabel.Size = new System.Drawing.Size(150, 13);
            this.infoDirLabel.TabIndex = 0;
            this.infoDirLabel.Tag = "DontTranslate";
            // 
            // SearchInFilesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.searchInFilesListBox);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.searchInFilesToolStrip);
            this.Name = "SearchInFilesPanel";
            this.Size = new System.Drawing.Size(150, 226);
            this.Load += new System.EventHandler(this.SearchInFilesPanel_Load);
            this.searchInFilesToolStrip.ResumeLayout(false);
            this.searchInFilesToolStrip.PerformLayout();
            this.searchInFilesContextMenuStrip.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip searchInFilesToolStrip;
        internal System.Windows.Forms.ListBox searchInFilesListBox;
        private System.Windows.Forms.ToolStripButton openFileToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton clearToolStripButton;
        internal System.Windows.Forms.ToolStripButton exportListToolStripButton;
        internal System.Windows.Forms.ToolStripLabel pathBaseToolStripLabel;
        internal System.Windows.Forms.ContextMenuStrip searchInFilesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openSelectedFilesToolStripMenuItem;
        private Customs.CustomPanel infoPanel;
        internal Customs.CustomTextBox infoTextLabel;
        internal Customs.CustomTextBox infoDirLabel;
        private System.Windows.Forms.ToolStripButton newSearchToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem copyFileFullPathToolStripMenuItem;
    }
}
