﻿namespace DtPad
{
    partial class TabEncoding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabEncoding));
            this.encodingLabel = new System.Windows.Forms.Label();
            this.changeIntoComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // encodingLabel
            // 
            this.encodingLabel.AutoSize = true;
            this.encodingLabel.Location = new System.Drawing.Point(12, 12);
            this.encodingLabel.Name = "encodingLabel";
            this.encodingLabel.Size = new System.Drawing.Size(55, 13);
            this.encodingLabel.TabIndex = 0;
            this.encodingLabel.Text = "Encoding:";
            // 
            // changeIntoComboBox
            // 
            this.changeIntoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.changeIntoComboBox.FormattingEnabled = true;
            this.changeIntoComboBox.Items.AddRange(new object[] {
            "ASCII",
            "UTF-8",
            "UTF-8 Without BOM",
            "UTF-16 Little Endian",
            "UTF-16 Big Endian",
            "UTF-32 Little Endian"});
            this.changeIntoComboBox.Location = new System.Drawing.Point(88, 9);
            this.changeIntoComboBox.Name = "changeIntoComboBox";
            this.changeIntoComboBox.Size = new System.Drawing.Size(192, 21);
            this.changeIntoComboBox.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Image = global::DtPad.MessageBoxResource.ok;
            this.saveButton.Location = new System.Drawing.Point(111, 45);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(88, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Proceed";
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(205, 45);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // TabEncoding
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(292, 80);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.changeIntoComboBox);
            this.Controls.Add(this.encodingLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TabEncoding";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save With Encoding";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.TabEncoding_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label encodingLabel;
        private System.Windows.Forms.ComboBox changeIntoComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
