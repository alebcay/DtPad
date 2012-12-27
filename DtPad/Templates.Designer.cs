namespace DtPad
{
    partial class Templates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Templates));
            this.okButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.toolPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolGroupBox1 = new System.Windows.Forms.GroupBox();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.templateTreeView = new System.Windows.Forms.TreeView();
            this.templateToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.toolPanel.SuspendLayout();
            this.toolGroupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // removeButton
            // 
            this.removeButton.Image = global::DtPad.ToolbarResource.minus;
            this.removeButton.Location = new System.Drawing.Point(41, 315);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(23, 23);
            this.removeButton.TabIndex = 3;
            this.templateToolTip.SetToolTip(this.removeButton, "Remove selected template");
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = global::DtPad.ToolbarResource.plus;
            this.addButton.Location = new System.Drawing.Point(12, 315);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(23, 23);
            this.addButton.TabIndex = 2;
            this.templateToolTip.SetToolTip(this.addButton, "Add new template");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // toolPanel
            // 
            this.toolPanel.Controls.Add(this.toolGroupBox1);
            this.toolPanel.Location = new System.Drawing.Point(179, 12);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(320, 297);
            this.toolPanel.TabIndex = 1;
            // 
            // toolGroupBox1
            // 
            this.toolGroupBox1.Controls.Add(this.textTextBox);
            this.toolGroupBox1.Controls.Add(this.textLabel);
            this.toolGroupBox1.Controls.Add(this.descriptionTextBox);
            this.toolGroupBox1.Controls.Add(this.descriptionLabel);
            this.toolGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.toolGroupBox1.Name = "toolGroupBox1";
            this.toolGroupBox1.Size = new System.Drawing.Size(317, 293);
            this.toolGroupBox1.TabIndex = 0;
            this.toolGroupBox1.TabStop = false;
            this.toolGroupBox1.Text = "Settings";
            // 
            // textTextBox
            // 
            this.textTextBox.AcceptsReturn = true;
            this.textTextBox.AcceptsTab = true;
            this.textTextBox.Location = new System.Drawing.Point(13, 59);
            this.textTextBox.Multiline = true;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textTextBox.Size = new System.Drawing.Size(291, 222);
            this.textTextBox.TabIndex = 3;
            this.textTextBox.Tag = "DontTranslate";
            this.textTextBox.Leave += new System.EventHandler(this.textTextBox_Leave);
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(10, 43);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(31, 13);
            this.textLabel.TabIndex = 2;
            this.textLabel.Text = "Text:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(92, 17);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(212, 20);
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
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(424, 315);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // templateTreeView
            // 
            this.templateTreeView.HideSelection = false;
            this.templateTreeView.Location = new System.Drawing.Point(12, 12);
            this.templateTreeView.Name = "templateTreeView";
            this.templateTreeView.Size = new System.Drawing.Size(161, 296);
            this.templateTreeView.TabIndex = 0;
            this.templateTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.templateTreeView_AfterSelect);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Image = global::DtPad.ToolbarResource.move_down;
            this.moveDownButton.Location = new System.Drawing.Point(150, 315);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(23, 23);
            this.moveDownButton.TabIndex = 5;
            this.templateToolTip.SetToolTip(this.moveDownButton, "Move selected template down");
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Image = global::DtPad.ToolbarResource.move_up;
            this.moveUpButton.Location = new System.Drawing.Point(121, 315);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(23, 23);
            this.moveUpButton.TabIndex = 4;
            this.templateToolTip.SetToolTip(this.moveUpButton, "Move selected template up");
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // Templates
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(511, 350);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.toolPanel);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.templateTreeView);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Templates";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Templates";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Templates_HelpButtonClicked);
            this.toolPanel.ResumeLayout(false);
            this.toolGroupBox1.ResumeLayout(false);
            this.toolGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        internal System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.FlowLayoutPanel toolPanel;
        private System.Windows.Forms.GroupBox toolGroupBox1;
        private System.Windows.Forms.Label textLabel;
        internal System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button cancelButton;
        internal System.Windows.Forms.TreeView templateTreeView;
        internal System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.ToolTip templateToolTip;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
    }
}
