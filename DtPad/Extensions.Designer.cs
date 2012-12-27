namespace DtPad
{
    partial class Extensions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Extensions));
            this.extensionTreeView = new System.Windows.Forms.TreeView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.extensionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.extensionGroupBox1 = new System.Windows.Forms.GroupBox();
            this.extensionPictureBox = new System.Windows.Forms.PictureBox();
            this.defaultCheckBox = new System.Windows.Forms.CheckBox();
            this.extensionTextBox = new System.Windows.Forms.TextBox();
            this.extensionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.extensionToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.extensionPanel.SuspendLayout();
            this.extensionGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extensionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // extensionTreeView
            // 
            this.extensionTreeView.HideSelection = false;
            this.extensionTreeView.Location = new System.Drawing.Point(13, 13);
            this.extensionTreeView.Name = "extensionTreeView";
            this.extensionTreeView.Size = new System.Drawing.Size(161, 296);
            this.extensionTreeView.TabIndex = 0;
            this.extensionTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.extensionTreeView_AfterSelect);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(424, 315);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // extensionPanel
            // 
            this.extensionPanel.Controls.Add(this.extensionGroupBox1);
            this.extensionPanel.Location = new System.Drawing.Point(180, 13);
            this.extensionPanel.Name = "extensionPanel";
            this.extensionPanel.Size = new System.Drawing.Size(319, 296);
            this.extensionPanel.TabIndex = 1;
            // 
            // extensionGroupBox1
            // 
            this.extensionGroupBox1.Controls.Add(this.extensionPictureBox);
            this.extensionGroupBox1.Controls.Add(this.defaultCheckBox);
            this.extensionGroupBox1.Controls.Add(this.extensionTextBox);
            this.extensionGroupBox1.Controls.Add(this.extensionLabel);
            this.extensionGroupBox1.Controls.Add(this.descriptionTextBox);
            this.extensionGroupBox1.Controls.Add(this.descriptionLabel);
            this.extensionGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.extensionGroupBox1.Name = "extensionGroupBox1";
            this.extensionGroupBox1.Size = new System.Drawing.Size(316, 90);
            this.extensionGroupBox1.TabIndex = 0;
            this.extensionGroupBox1.TabStop = false;
            this.extensionGroupBox1.Text = "Settings";
            // 
            // extensionPictureBox
            // 
            this.extensionPictureBox.Image = global::DtPad.ToolbarResource.info_blue;
            this.extensionPictureBox.Location = new System.Drawing.Point(148, 43);
            this.extensionPictureBox.Name = "extensionPictureBox";
            this.extensionPictureBox.Size = new System.Drawing.Size(16, 16);
            this.extensionPictureBox.TabIndex = 5;
            this.extensionPictureBox.TabStop = false;
            this.extensionToolTip.SetToolTip(this.extensionPictureBox, "Insert only file extension (ie. txt)");
            // 
            // defaultCheckBox
            // 
            this.defaultCheckBox.AutoSize = true;
            this.defaultCheckBox.Location = new System.Drawing.Point(13, 66);
            this.defaultCheckBox.Name = "defaultCheckBox";
            this.defaultCheckBox.Size = new System.Drawing.Size(108, 17);
            this.defaultCheckBox.TabIndex = 4;
            this.defaultCheckBox.Text = "Default extension";
            this.defaultCheckBox.UseVisualStyleBackColor = true;
            this.defaultCheckBox.Leave += new System.EventHandler(this.defaultCheckBox_Leave);
            // 
            // extensionTextBox
            // 
            this.extensionTextBox.Location = new System.Drawing.Point(79, 40);
            this.extensionTextBox.Name = "extensionTextBox";
            this.extensionTextBox.Size = new System.Drawing.Size(63, 20);
            this.extensionTextBox.TabIndex = 3;
            this.extensionTextBox.Tag = "DontTranslate";
            this.extensionTextBox.Leave += new System.EventHandler(this.extensionTextBox_Leave);
            // 
            // extensionLabel
            // 
            this.extensionLabel.AutoSize = true;
            this.extensionLabel.Location = new System.Drawing.Point(10, 43);
            this.extensionLabel.Name = "extensionLabel";
            this.extensionLabel.Size = new System.Drawing.Size(56, 13);
            this.extensionLabel.TabIndex = 2;
            this.extensionLabel.Text = "Extension:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(79, 17);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(223, 20);
            this.descriptionTextBox.TabIndex = 1;
            this.descriptionTextBox.Tag = "DontTranslate";
            this.descriptionTextBox.Leave += new System.EventHandler(this.descriptionTextBox_Leave);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(10, 20);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Description:";
            // 
            // addButton
            // 
            this.addButton.Image = global::DtPad.ToolbarResource.plus;
            this.addButton.Location = new System.Drawing.Point(13, 315);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(23, 23);
            this.addButton.TabIndex = 2;
            this.extensionToolTip.SetToolTip(this.addButton, "Add new extension");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Image = global::DtPad.ToolbarResource.minus;
            this.removeButton.Location = new System.Drawing.Point(42, 315);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(23, 23);
            this.removeButton.TabIndex = 3;
            this.extensionToolTip.SetToolTip(this.removeButton, "Remove selected extension");
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Image = global::DtPad.ToolbarResource.move_down;
            this.moveDownButton.Location = new System.Drawing.Point(151, 315);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(23, 23);
            this.moveDownButton.TabIndex = 5;
            this.extensionToolTip.SetToolTip(this.moveDownButton, "Move selected extension down");
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Image = global::DtPad.ToolbarResource.move_up;
            this.moveUpButton.Location = new System.Drawing.Point(122, 315);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(23, 23);
            this.moveUpButton.TabIndex = 4;
            this.extensionToolTip.SetToolTip(this.moveUpButton, "Move selected extension up");
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // okButton
            // 
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(343, 315);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Extensions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 350);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.extensionPanel);
            this.Controls.Add(this.extensionTreeView);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Extensions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extensions";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Extensions_HelpButtonClicked);
            this.extensionPanel.ResumeLayout(false);
            this.extensionGroupBox1.ResumeLayout(false);
            this.extensionGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extensionPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FlowLayoutPanel extensionPanel;
        private System.Windows.Forms.GroupBox extensionGroupBox1;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label extensionLabel;
        private System.Windows.Forms.PictureBox extensionPictureBox;
        private System.Windows.Forms.ToolTip extensionToolTip;
        internal System.Windows.Forms.TreeView extensionTreeView;
        internal System.Windows.Forms.TextBox extensionTextBox;
        internal System.Windows.Forms.TextBox descriptionTextBox;
        internal System.Windows.Forms.CheckBox defaultCheckBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button okButton;
        internal System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
    }
}
