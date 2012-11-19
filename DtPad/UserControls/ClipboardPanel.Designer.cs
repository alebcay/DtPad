namespace DtPad.UserControls
{
    partial class ClipboardPanel
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
            this.clipboardToolStrip = new System.Windows.Forms.ToolStrip();
            this.clearClipboardToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.clipboardListBox = new System.Windows.Forms.ListBox();
            this.clipboardContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clipboardToolStrip.SuspendLayout();
            this.clipboardContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // clipboardToolStrip
            // 
            this.clipboardToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearClipboardToolStripButton});
            this.clipboardToolStrip.Location = new System.Drawing.Point(0, 0);
            this.clipboardToolStrip.Name = "clipboardToolStrip";
            this.clipboardToolStrip.Size = new System.Drawing.Size(150, 25);
            this.clipboardToolStrip.TabIndex = 0;
            this.clipboardToolStrip.Text = "toolStrip1";
            // 
            // clearClipboardToolStripButton
            // 
            this.clearClipboardToolStripButton.Image = global::DtPad.ToolbarResource.bin;
            this.clearClipboardToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearClipboardToolStripButton.Name = "clearClipboardToolStripButton";
            this.clearClipboardToolStripButton.Size = new System.Drawing.Size(109, 22);
            this.clearClipboardToolStripButton.Text = "Clear Clipboard";
            this.clearClipboardToolStripButton.Click += new System.EventHandler(this.clearClipboardToolStripButton_Click);
            // 
            // clipboardListBox
            // 
            this.clipboardListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clipboardListBox.ContextMenuStrip = this.clipboardContextMenuStrip;
            this.clipboardListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clipboardListBox.FormattingEnabled = true;
            this.clipboardListBox.Location = new System.Drawing.Point(0, 25);
            this.clipboardListBox.Name = "clipboardListBox";
            this.clipboardListBox.Size = new System.Drawing.Size(150, 125);
            this.clipboardListBox.TabIndex = 1;
            this.clipboardListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.clipboardListBox_MouseDoubleClick);
            this.clipboardListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clipboardListBox_MouseDown);
            // 
            // clipboardContextMenuStrip
            // 
            this.clipboardContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.toolStripSeparator1,
            this.showAllContentToolStripMenuItem});
            this.clipboardContextMenuStrip.Name = "clipboardContextMenuStrip";
            this.clipboardContextMenuStrip.Size = new System.Drawing.Size(167, 76);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // showAllContentToolStripMenuItem
            // 
            this.showAllContentToolStripMenuItem.Name = "showAllContentToolStripMenuItem";
            this.showAllContentToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.showAllContentToolStripMenuItem.Text = "Show All Content";
            this.showAllContentToolStripMenuItem.Click += new System.EventHandler(this.showAllContentToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // ClipboardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clipboardListBox);
            this.Controls.Add(this.clipboardToolStrip);
            this.Name = "ClipboardPanel";
            this.clipboardToolStrip.ResumeLayout(false);
            this.clipboardToolStrip.PerformLayout();
            this.clipboardContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton clearClipboardToolStripButton;
        internal System.Windows.Forms.ListBox clipboardListBox;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllContentToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip clipboardContextMenuStrip;
        internal System.Windows.Forms.ToolStrip clipboardToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
