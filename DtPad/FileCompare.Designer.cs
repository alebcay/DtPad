namespace DtPad
{
    partial class FileCompare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileCompare));
            this.tabPagesListBox = new System.Windows.Forms.ListBox();
            this.selectTabsLabel = new System.Windows.Forms.Label();
            this.compareButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.caseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
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
            this.tabPagesListBox.Size = new System.Drawing.Size(419, 212);
            this.tabPagesListBox.TabIndex = 1;
            this.tabPagesListBox.Tag = "DontTranslate";
            this.tabPagesListBox.SelectedIndexChanged += new System.EventHandler(this.tabPagesListBox_SelectedIndexChanged);
            // 
            // selectTabsLabel
            // 
            this.selectTabsLabel.AutoSize = true;
            this.selectTabsLabel.Location = new System.Drawing.Point(9, 13);
            this.selectTabsLabel.Name = "selectTabsLabel";
            this.selectTabsLabel.Size = new System.Drawing.Size(139, 13);
            this.selectTabsLabel.TabIndex = 0;
            this.selectTabsLabel.Text = "Select two tabs to compare:";
            // 
            // compareButton
            // 
            this.compareButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compareButton.Enabled = false;
            this.compareButton.Image = global::DtPad.MessageBoxResource.ok;
            this.compareButton.Location = new System.Drawing.Point(240, 290);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(111, 23);
            this.compareButton.TabIndex = 3;
            this.compareButton.Text = "Compare";
            this.compareButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.compareButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(357, 290);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // caseSensitiveCheckBox
            // 
            this.caseSensitiveCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.caseSensitiveCheckBox.AutoSize = true;
            this.caseSensitiveCheckBox.Location = new System.Drawing.Point(12, 258);
            this.caseSensitiveCheckBox.Name = "caseSensitiveCheckBox";
            this.caseSensitiveCheckBox.Size = new System.Drawing.Size(94, 17);
            this.caseSensitiveCheckBox.TabIndex = 2;
            this.caseSensitiveCheckBox.Text = "Case sensitive";
            this.caseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // FileCompare
            // 
            this.AcceptButton = this.compareButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(444, 325);
            this.Controls.Add(this.caseSensitiveCheckBox);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.selectTabsLabel);
            this.Controls.Add(this.tabPagesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileCompare";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compare Tabs";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FileCompare_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListBox tabPagesListBox;
        private System.Windows.Forms.Label selectTabsLabel;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.Button closeButton;
        internal System.Windows.Forms.CheckBox caseSensitiveCheckBox;
    }
}
