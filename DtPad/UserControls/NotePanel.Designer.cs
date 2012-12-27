namespace DtPad.UserControls
{
    partial class NotePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotePanel));
            this.nodeTextTextBox = new Customs.CustomTextBox();
            this.noteTitleTextBox = new Customs.CustomTextBox();
            this.noteToolStrip = new System.Windows.Forms.ToolStrip();
            this.addNoteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeNoteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveFirstToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveUpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveLastToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exportNotesToolStripSplitButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.xMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tXTFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.warningRemoveNoteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.noteSplitContainer = new System.Windows.Forms.SplitContainer();
            this.notesTreeView = new System.Windows.Forms.TreeView();
            this.noteImageList = new System.Windows.Forms.ImageList(this.components);
            this.noteGroupBox = new System.Windows.Forms.Panel();
            this.noteContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openOnEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackstandardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noteToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noteSplitContainer)).BeginInit();
            this.noteSplitContainer.Panel1.SuspendLayout();
            this.noteSplitContainer.Panel2.SuspendLayout();
            this.noteSplitContainer.SuspendLayout();
            this.noteGroupBox.SuspendLayout();
            this.noteContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // noteToolStrip
            // 
            this.noteToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNoteToolStripButton,
            this.removeNoteToolStripButton,
            this.toolStripSeparator1,
            this.moveFirstToolStripButton,
            this.moveUpToolStripButton,
            this.moveDownToolStripButton,
            this.moveLastToolStripButton,
            this.toolStripSeparator4,
            this.exportNotesToolStripSplitButton,
            this.toolStripSeparator2,
            this.warningRemoveNoteToolStripButton});
            this.noteToolStrip.Location = new System.Drawing.Point(0, 0);
            this.noteToolStrip.Name = "noteToolStrip";
            this.noteToolStrip.Size = new System.Drawing.Size(150, 25);
            this.noteToolStrip.TabIndex = 0;
            this.noteToolStrip.Text = "noteToolStrip";
            // 
            // addNoteToolStripButton
            // 
            this.addNoteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addNoteToolStripButton.Image = global::DtPad.ToolbarResource.plus_yellow;
            this.addNoteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNoteToolStripButton.Name = "addNoteToolStripButton";
            this.addNoteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addNoteToolStripButton.Text = "Add New Note";
            this.addNoteToolStripButton.Click += new System.EventHandler(this.addNoteToolStripButton_Click);
            // 
            // removeNoteToolStripButton
            // 
            this.removeNoteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeNoteToolStripButton.Image = global::DtPad.ToolbarResource.minus_yellow;
            this.removeNoteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeNoteToolStripButton.Name = "removeNoteToolStripButton";
            this.removeNoteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.removeNoteToolStripButton.Text = "Remove Selected Note";
            this.removeNoteToolStripButton.Click += new System.EventHandler(this.removeNoteToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // moveFirstToolStripButton
            // 
            this.moveFirstToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveFirstToolStripButton.Image = global::DtPad.ToolbarResource.move_first;
            this.moveFirstToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveFirstToolStripButton.Name = "moveFirstToolStripButton";
            this.moveFirstToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveFirstToolStripButton.Text = "Move As First";
            this.moveFirstToolStripButton.Click += new System.EventHandler(this.moveFirstToolStripButton_Click);
            // 
            // moveUpToolStripButton
            // 
            this.moveUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpToolStripButton.Image = global::DtPad.ToolbarResource.move_up;
            this.moveUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpToolStripButton.Name = "moveUpToolStripButton";
            this.moveUpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveUpToolStripButton.Text = "Move Up";
            this.moveUpToolStripButton.Click += new System.EventHandler(this.moveUpToolStripButton_Click);
            // 
            // moveDownToolStripButton
            // 
            this.moveDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownToolStripButton.Image = global::DtPad.ToolbarResource.move_down;
            this.moveDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownToolStripButton.Name = "moveDownToolStripButton";
            this.moveDownToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveDownToolStripButton.Text = "Move Down";
            this.moveDownToolStripButton.Click += new System.EventHandler(this.moveDownToolStripButton_Click);
            // 
            // moveLastToolStripButton
            // 
            this.moveLastToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveLastToolStripButton.Image = global::DtPad.ToolbarResource.move_last;
            this.moveLastToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveLastToolStripButton.Name = "moveLastToolStripButton";
            this.moveLastToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.moveLastToolStripButton.Text = "Move As Last";
            this.moveLastToolStripButton.Click += new System.EventHandler(this.moveLastToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // exportNotesToolStripSplitButton
            // 
            this.exportNotesToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportNotesToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLFileToolStripMenuItem,
            this.tXTFilesToolStripMenuItem});
            this.exportNotesToolStripSplitButton.Image = global::DtPad.ToolbarResource.note_export;
            this.exportNotesToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportNotesToolStripSplitButton.Name = "exportNotesToolStripSplitButton";
            this.exportNotesToolStripSplitButton.Size = new System.Drawing.Size(29, 20);
            this.exportNotesToolStripSplitButton.Text = "Export As...";
            // 
            // xMLFileToolStripMenuItem
            // 
            this.xMLFileToolStripMenuItem.Name = "xMLFileToolStripMenuItem";
            this.xMLFileToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.xMLFileToolStripMenuItem.Text = "Single XML File";
            this.xMLFileToolStripMenuItem.Click += new System.EventHandler(this.xMLFileToolStripMenuItem_Click);
            // 
            // tXTFilesToolStripMenuItem
            // 
            this.tXTFilesToolStripMenuItem.Name = "tXTFilesToolStripMenuItem";
            this.tXTFilesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.tXTFilesToolStripMenuItem.Text = "Multiple TXT Files";
            this.tXTFilesToolStripMenuItem.Click += new System.EventHandler(this.tXTFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // warningRemoveNoteToolStripButton
            // 
            this.warningRemoveNoteToolStripButton.Checked = true;
            this.warningRemoveNoteToolStripButton.CheckOnClick = true;
            this.warningRemoveNoteToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.warningRemoveNoteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.warningRemoveNoteToolStripButton.Image = global::DtPad.ToolbarResource.question_red;
            this.warningRemoveNoteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.warningRemoveNoteToolStripButton.Name = "warningRemoveNoteToolStripButton";
            this.warningRemoveNoteToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.warningRemoveNoteToolStripButton.Text = "Warning Removing Notes";
            this.warningRemoveNoteToolStripButton.CheckedChanged += new System.EventHandler(this.warningRemoveNoteToolStripButton_CheckedChanged);
            // 
            // noteSplitContainer
            // 
            this.noteSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.noteSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.noteSplitContainer.Name = "noteSplitContainer";
            this.noteSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // noteSplitContainer.Panel1
            // 
            this.noteSplitContainer.Panel1.Controls.Add(this.notesTreeView);
            // 
            // noteSplitContainer.Panel2
            // 
            this.noteSplitContainer.Panel2.Controls.Add(this.noteGroupBox);
            this.noteSplitContainer.Size = new System.Drawing.Size(150, 297);
            this.noteSplitContainer.SplitterDistance = 160;
            this.noteSplitContainer.TabIndex = 5;
            this.noteSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.noteSplitContainer_SplitterMoved);
            // 
            // notesTreeView
            // 
            this.notesTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.notesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notesTreeView.FullRowSelect = true;
            this.notesTreeView.HideSelection = false;
            this.notesTreeView.ImageIndex = 0;
            this.notesTreeView.ImageList = this.noteImageList;
            this.notesTreeView.Indent = 5;
            this.notesTreeView.Location = new System.Drawing.Point(0, 0);
            this.notesTreeView.Name = "notesTreeView";
            this.notesTreeView.SelectedImageIndex = 0;
            this.notesTreeView.ShowLines = false;
            this.notesTreeView.ShowPlusMinus = false;
            this.notesTreeView.ShowRootLines = false;
            this.notesTreeView.Size = new System.Drawing.Size(150, 160);
            this.notesTreeView.TabIndex = 0;
            this.notesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.notesTreeView_AfterSelect);
            this.notesTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.notesTreeView_NodeMouseClick);
            // 
            // noteImageList
            // 
            this.noteImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("noteImageList.ImageStream")));
            this.noteImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.noteImageList.Images.SetKeyName(0, "note.png");
            this.noteImageList.Images.SetKeyName(1, "note-orange.png");
            this.noteImageList.Images.SetKeyName(2, "note-red.png");
            this.noteImageList.Images.SetKeyName(3, "note-green.png");
            this.noteImageList.Images.SetKeyName(4, "note-blue.png");
            // 
            // noteGroupBox
            // 
            this.noteGroupBox.Controls.Add(this.nodeTextTextBox);
            this.noteGroupBox.Controls.Add(this.noteTitleTextBox);
            this.noteGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteGroupBox.Location = new System.Drawing.Point(0, 0);
            this.noteGroupBox.Name = "noteGroupBox";
            this.noteGroupBox.Size = new System.Drawing.Size(150, 133);
            this.noteGroupBox.TabIndex = 0;
            // 
            // nodeTextTextBox
            // 
            this.nodeTextTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.nodeTextTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nodeTextTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeTextTextBox.Location = new System.Drawing.Point(0, 20);
            this.nodeTextTextBox.Multiline = true;
            this.nodeTextTextBox.Name = "nodeTextTextBox";
            this.nodeTextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.nodeTextTextBox.Size = new System.Drawing.Size(150, 113);
            this.nodeTextTextBox.TabIndex = 1;
            this.nodeTextTextBox.Tag = "DontTranslate";
            this.nodeTextTextBox.Leave += new System.EventHandler(this.nodeTextTextBox_Leave);
            // 
            // noteTitleTextBox
            // 
            this.noteTitleTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.noteTitleTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.noteTitleTextBox.Location = new System.Drawing.Point(0, 0);
            this.noteTitleTextBox.Name = "noteTitleTextBox";
            this.noteTitleTextBox.Size = new System.Drawing.Size(150, 20);
            this.noteTitleTextBox.TabIndex = 0;
            this.noteTitleTextBox.Tag = "DontTranslate";
            this.noteTitleTextBox.Leave += new System.EventHandler(this.noteTitleTextBox_Leave);
            // 
            // noteContextMenuStrip
            // 
            this.noteContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem3,
            this.removeToolStripMenuItem,
            this.toolStripSeparator3,
            this.openOnEditorToolStripMenuItem,
            this.toolStripSeparator5,
            this.tagToolStripMenuItem});
            this.noteContextMenuStrip.Name = "noteContextMenuStrip";
            this.noteContextMenuStrip.Size = new System.Drawing.Size(155, 104);
            // 
            // newToolStripMenuItem3
            // 
            this.newToolStripMenuItem3.Image = global::DtPad.ToolbarResource.plus_yellow;
            this.newToolStripMenuItem3.Name = "newToolStripMenuItem3";
            this.newToolStripMenuItem3.Size = new System.Drawing.Size(154, 22);
            this.newToolStripMenuItem3.Text = "New";
            this.newToolStripMenuItem3.Click += new System.EventHandler(this.newToolStripMenuItem3_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::DtPad.ToolbarResource.minus_yellow;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // openOnEditorToolStripMenuItem
            // 
            this.openOnEditorToolStripMenuItem.Name = "openOnEditorToolStripMenuItem";
            this.openOnEditorToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openOnEditorToolStripMenuItem.Text = "Open on Editor";
            this.openOnEditorToolStripMenuItem.Click += new System.EventHandler(this.openOnEditorToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(151, 6);
            // 
            // tagToolStripMenuItem
            // 
            this.tagToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orangeToolStripMenuItem,
            this.redToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.blackstandardToolStripMenuItem});
            this.tagToolStripMenuItem.Name = "tagToolStripMenuItem";
            this.tagToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.tagToolStripMenuItem.Text = "Tag";
            // 
            // orangeToolStripMenuItem
            // 
            this.orangeToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.orangeToolStripMenuItem.Image = global::DtPad.ToolbarResource.note_orange;
            this.orangeToolStripMenuItem.Name = "orangeToolStripMenuItem";
            this.orangeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.orangeToolStripMenuItem.Text = "Orange";
            this.orangeToolStripMenuItem.Click += new System.EventHandler(this.orangeToolStripMenuItem_Click);
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.redToolStripMenuItem.Image = global::DtPad.ToolbarResource.note_red;
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.redToolStripMenuItem_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            this.greenToolStripMenuItem.Image = global::DtPad.ToolbarResource.note_green;
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.greenToolStripMenuItem.Text = "Green";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.blueToolStripMenuItem.Image = global::DtPad.ToolbarResource.note_blue;
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
            // 
            // blackstandardToolStripMenuItem
            // 
            this.blackstandardToolStripMenuItem.Image = global::DtPad.ToolbarResource.note;
            this.blackstandardToolStripMenuItem.Name = "blackstandardToolStripMenuItem";
            this.blackstandardToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.blackstandardToolStripMenuItem.Text = "Black (Standard)";
            this.blackstandardToolStripMenuItem.Click += new System.EventHandler(this.blackstandardToolStripMenuItem_Click);
            // 
            // NotePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.noteSplitContainer);
            this.Controls.Add(this.noteToolStrip);
            this.Name = "NotePanel";
            this.Size = new System.Drawing.Size(150, 322);
            this.Load += new System.EventHandler(this.NotePanel_Load);
            this.Resize += new System.EventHandler(this.NotePanel_Resize);
            this.noteToolStrip.ResumeLayout(false);
            this.noteToolStrip.PerformLayout();
            this.noteSplitContainer.Panel1.ResumeLayout(false);
            this.noteSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.noteSplitContainer)).EndInit();
            this.noteSplitContainer.ResumeLayout(false);
            this.noteGroupBox.ResumeLayout(false);
            this.noteGroupBox.PerformLayout();
            this.noteContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer noteSplitContainer;
        internal System.Windows.Forms.TreeView notesTreeView;
        private System.Windows.Forms.Panel noteGroupBox;
        internal Customs.CustomTextBox nodeTextTextBox;
        internal Customs.CustomTextBox noteTitleTextBox;
        private System.Windows.Forms.ToolStripButton addNoteToolStripButton;
        internal System.Windows.Forms.ToolStripButton removeNoteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton warningRemoveNoteToolStripButton;
        private System.Windows.Forms.ImageList noteImageList;
        internal System.Windows.Forms.ToolStrip noteToolStrip;
        internal System.Windows.Forms.ContextMenuStrip noteContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton exportNotesToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem xMLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tXTFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton moveFirstToolStripButton;
        internal System.Windows.Forms.ToolStripButton moveUpToolStripButton;
        internal System.Windows.Forms.ToolStripButton moveDownToolStripButton;
        internal System.Windows.Forms.ToolStripButton moveLastToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem openOnEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackstandardToolStripMenuItem;
    }
}
