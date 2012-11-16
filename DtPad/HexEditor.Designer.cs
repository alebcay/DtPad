namespace DtPad
{
    partial class HexEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HexEditor));
            this.hexBox = new Be.Windows.Forms.HexBox();
            this.textMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyHexadecimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeButton = new System.Windows.Forms.Button();
            this.textMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // hexBox
            // 
            this.hexBox.AllowDrop = true;
            this.hexBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hexBox.ContextMenuStrip = this.textMenuStrip;
            this.hexBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox.HexCasing = Be.Windows.Forms.HexCasing.Lower;
            //this.hexBox.LineInfoForeColor = System.Drawing.Color.Gray;
            this.hexBox.LineInfoVisible = true;
            this.hexBox.Location = new System.Drawing.Point(12, 12);
            this.hexBox.Name = "hexBox";
            this.hexBox.ReadOnly = true;
            this.hexBox.SelectionBackColor = System.Drawing.Color.Navy;
            this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox.Size = new System.Drawing.Size(718, 300);
            this.hexBox.StringViewVisible = true;
            this.hexBox.TabIndex = 0;
            this.hexBox.UseFixedBytesPerLine = false;
            this.hexBox.VScrollBarVisible = true;
            // 
            // textMenuStrip
            // 
            this.textMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem2,
            this.copyHexadecimalToolStripMenuItem,
            this.toolStripSeparator29,
            this.selectAllToolStripMenuItem2});
            this.textMenuStrip.Name = "searchContextMenuStrip";
            this.textMenuStrip.Size = new System.Drawing.Size(174, 76);
            // 
            // copyToolStripMenuItem2
            // 
            this.copyToolStripMenuItem2.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem2.Name = "copyToolStripMenuItem2";
            this.copyToolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.copyToolStripMenuItem2.Text = "Copy Text";
            this.copyToolStripMenuItem2.Click += new System.EventHandler(this.copyToolStripMenuItem2_Click);
            // 
            // copyHexadecimalToolStripMenuItem
            // 
            this.copyHexadecimalToolStripMenuItem.Name = "copyHexadecimalToolStripMenuItem";
            this.copyHexadecimalToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.copyHexadecimalToolStripMenuItem.Text = "Copy Hexadecimal";
            this.copyHexadecimalToolStripMenuItem.Click += new System.EventHandler(this.copyHexadecimalToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(170, 6);
            // 
            // selectAllToolStripMenuItem2
            // 
            this.selectAllToolStripMenuItem2.Name = "selectAllToolStripMenuItem2";
            this.selectAllToolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.selectAllToolStripMenuItem2.Text = "Select All";
            this.selectAllToolStripMenuItem2.Click += new System.EventHandler(this.selectAllToolStripMenuItem2_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(655, 328);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // HexEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(742, 363);
            this.Controls.Add(this.hexBox);
            this.Controls.Add(this.closeButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(597, 38);
            this.Name = "HexEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hexadecimal";
            this.textMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Be.Windows.Forms.HexBox hexBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ContextMenuStrip textMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem copyHexadecimalToolStripMenuItem;
    }
}
