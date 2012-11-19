namespace DtPad
{
    partial class MergeTabs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeTabs));
            this.tabPagesListBox = new System.Windows.Forms.ListBox();
            this.markSeparationCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectTabsLabel = new System.Windows.Forms.Label();
            this.markSeparationTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.mergeTabsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // tabPagesListBox
            // 
            this.tabPagesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPagesListBox.FormattingEnabled = true;
            this.tabPagesListBox.Location = new System.Drawing.Point(12, 29);
            this.tabPagesListBox.Name = "tabPagesListBox";
            this.tabPagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.tabPagesListBox.Size = new System.Drawing.Size(286, 160);
            this.tabPagesListBox.TabIndex = 1;
            this.tabPagesListBox.SelectedIndexChanged += new System.EventHandler(this.tabPagesListBox_SelectedIndexChanged);
            // 
            // markSeparationCheckBox
            // 
            this.markSeparationCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.markSeparationCheckBox.AutoSize = true;
            this.markSeparationCheckBox.Location = new System.Drawing.Point(12, 195);
            this.markSeparationCheckBox.Name = "markSeparationCheckBox";
            this.markSeparationCheckBox.Size = new System.Drawing.Size(169, 17);
            this.markSeparationCheckBox.TabIndex = 4;
            this.markSeparationCheckBox.Text = "Mark separation between tabs";
            this.markSeparationCheckBox.UseVisualStyleBackColor = true;
            this.markSeparationCheckBox.CheckedChanged += new System.EventHandler(this.markSeparationCheckBox_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(252, 297);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectTabsLabel
            // 
            this.selectTabsLabel.AutoSize = true;
            this.selectTabsLabel.Location = new System.Drawing.Point(9, 13);
            this.selectTabsLabel.Name = "selectTabsLabel";
            this.selectTabsLabel.Size = new System.Drawing.Size(165, 13);
            this.selectTabsLabel.TabIndex = 0;
            this.selectTabsLabel.Text = "Select tabs to merge (minimum 2):";
            // 
            // markSeparationTextBox
            // 
            this.markSeparationTextBox.AcceptsReturn = true;
            this.markSeparationTextBox.AcceptsTab = true;
            this.markSeparationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.markSeparationTextBox.Enabled = false;
            this.markSeparationTextBox.Location = new System.Drawing.Point(12, 219);
            this.markSeparationTextBox.Multiline = true;
            this.markSeparationTextBox.Name = "markSeparationTextBox";
            this.markSeparationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.markSeparationTextBox.Size = new System.Drawing.Size(312, 63);
            this.markSeparationTextBox.TabIndex = 5;
            this.markSeparationTextBox.Text = "\r\n========== MERGE ==========\r\n";
            this.markSeparationTextBox.WordWrap = false;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Enabled = false;
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(165, 297);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(81, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Merge";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownButton.Image = global::DtPad.ToolbarResource.move_down;
            this.moveDownButton.Location = new System.Drawing.Point(304, 58);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(23, 23);
            this.moveDownButton.TabIndex = 3;
            this.mergeTabsToolTip.SetToolTip(this.moveDownButton, "Move selected tab down");
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpButton.Image = global::DtPad.ToolbarResource.move_up;
            this.moveUpButton.Location = new System.Drawing.Point(304, 29);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(23, 23);
            this.moveUpButton.TabIndex = 2;
            this.mergeTabsToolTip.SetToolTip(this.moveUpButton, "Move selected tab up");
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // MergeTabs
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(336, 330);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.markSeparationTextBox);
            this.Controls.Add(this.selectTabsLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.markSeparationCheckBox);
            this.Controls.Add(this.tabPagesListBox);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MergeTabs";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merge Tabs";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MergeTabs_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListBox tabPagesListBox;
        internal System.Windows.Forms.CheckBox markSeparationCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label selectTabsLabel;
        internal System.Windows.Forms.TextBox markSeparationTextBox;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.ToolTip mergeTabsToolTip;
    }
}
