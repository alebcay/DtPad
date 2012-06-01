namespace DtPad
{
    partial class ZipExtract
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZipExtract));
            this.zipContentDataGridView = new System.Windows.Forms.DataGridView();
            this.zipContentLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.extractSelectedFilesButton = new System.Windows.Forms.Button();
            this.filenameLabel1 = new System.Windows.Forms.Label();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.copyArchiveContentPictureBox = new System.Windows.Forms.PictureBox();
            this.zipExtractToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.zipContentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.copyArchiveContentPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // zipContentDataGridView
            // 
            this.zipContentDataGridView.AllowUserToAddRows = false;
            this.zipContentDataGridView.AllowUserToDeleteRows = false;
            this.zipContentDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zipContentDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.zipContentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zipContentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.zipContentDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.zipContentDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.zipContentDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zipContentDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.zipContentDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.zipContentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zipContentDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.zipContentDataGridView.Location = new System.Drawing.Point(16, 48);
            this.zipContentDataGridView.Name = "zipContentDataGridView";
            this.zipContentDataGridView.RowHeadersVisible = false;
            this.zipContentDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.zipContentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.zipContentDataGridView.ShowCellErrors = false;
            this.zipContentDataGridView.ShowEditingIcon = false;
            this.zipContentDataGridView.ShowRowErrors = false;
            this.zipContentDataGridView.Size = new System.Drawing.Size(507, 249);
            this.zipContentDataGridView.TabIndex = 3;
            // 
            // zipContentLabel
            // 
            this.zipContentLabel.AutoSize = true;
            this.zipContentLabel.Location = new System.Drawing.Point(13, 32);
            this.zipContentLabel.Name = "zipContentLabel";
            this.zipContentLabel.Size = new System.Drawing.Size(101, 13);
            this.zipContentLabel.TabIndex = 2;
            this.zipContentLabel.Text = "Archive file content:";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(448, 312);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // extractSelectedFilesButton
            // 
            this.extractSelectedFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.extractSelectedFilesButton.AutoSize = true;
            this.extractSelectedFilesButton.Location = new System.Drawing.Point(310, 312);
            this.extractSelectedFilesButton.Name = "extractSelectedFilesButton";
            this.extractSelectedFilesButton.Size = new System.Drawing.Size(132, 23);
            this.extractSelectedFilesButton.TabIndex = 4;
            this.extractSelectedFilesButton.Text = "Extract Selected Files";
            this.extractSelectedFilesButton.UseVisualStyleBackColor = true;
            this.extractSelectedFilesButton.Click += new System.EventHandler(this.extractSelectedFilesButton_Click);
            // 
            // filenameLabel1
            // 
            this.filenameLabel1.AutoSize = true;
            this.filenameLabel1.Location = new System.Drawing.Point(13, 9);
            this.filenameLabel1.Name = "filenameLabel1";
            this.filenameLabel1.Size = new System.Drawing.Size(55, 13);
            this.filenameLabel1.TabIndex = 0;
            this.filenameLabel1.Text = "File name:";
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(74, 9);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(72, 13);
            this.filenameLabel.TabIndex = 1;
            this.filenameLabel.Text = "filenameLabel";
            // 
            // copyArchiveContentPictureBox
            // 
            this.copyArchiveContentPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.copyArchiveContentPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.copyArchiveContentPictureBox.Image = global::DtPad.ToolbarResource.copy;
            this.copyArchiveContentPictureBox.Location = new System.Drawing.Point(16, 318);
            this.copyArchiveContentPictureBox.Name = "copyArchiveContentPictureBox";
            this.copyArchiveContentPictureBox.Size = new System.Drawing.Size(16, 16);
            this.copyArchiveContentPictureBox.TabIndex = 6;
            this.copyArchiveContentPictureBox.TabStop = false;
            this.copyArchiveContentPictureBox.Click += new System.EventHandler(this.copyArchiveContentPictureBox_Click);
            // 
            // ZipExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(535, 346);
            this.Controls.Add(this.copyArchiveContentPictureBox);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.filenameLabel1);
            this.Controls.Add(this.extractSelectedFilesButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.zipContentLabel);
            this.Controls.Add(this.zipContentDataGridView);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(459, 330);
            this.Name = "ZipExtract";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archive Extraction";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ZipExtract_HelpButtonClicked);
            ((System.ComponentModel.ISupportInitialize)(this.zipContentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.copyArchiveContentPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label zipContentLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button extractSelectedFilesButton;
        internal System.Windows.Forms.DataGridView zipContentDataGridView;
        private System.Windows.Forms.Label filenameLabel1;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.PictureBox copyArchiveContentPictureBox;
        private System.Windows.Forms.ToolTip zipExtractToolTip;
    }
}
