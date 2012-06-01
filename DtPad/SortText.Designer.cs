namespace DtPad
{
    partial class SortText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortText));
            this.applyToLabel = new System.Windows.Forms.Label();
            this.selectedTextRadioButton = new System.Windows.Forms.RadioButton();
            this.allTextRadioButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.descCheckBox = new System.Windows.Forms.CheckBox();
            this.ascCheckBox = new System.Windows.Forms.CheckBox();
            this.sortTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // applyToLabel
            // 
            this.applyToLabel.AutoSize = true;
            this.applyToLabel.Location = new System.Drawing.Point(12, 40);
            this.applyToLabel.Name = "applyToLabel";
            this.applyToLabel.Size = new System.Drawing.Size(48, 13);
            this.applyToLabel.TabIndex = 3;
            this.applyToLabel.Text = "Apply to:";
            // 
            // selectedTextRadioButton
            // 
            this.selectedTextRadioButton.AutoSize = true;
            this.selectedTextRadioButton.Location = new System.Drawing.Point(115, 61);
            this.selectedTextRadioButton.Name = "selectedTextRadioButton";
            this.selectedTextRadioButton.Size = new System.Drawing.Size(87, 17);
            this.selectedTextRadioButton.TabIndex = 5;
            this.selectedTextRadioButton.Text = "Selected text";
            this.selectedTextRadioButton.UseVisualStyleBackColor = true;
            // 
            // allTextRadioButton
            // 
            this.allTextRadioButton.AutoSize = true;
            this.allTextRadioButton.Checked = true;
            this.allTextRadioButton.Location = new System.Drawing.Point(115, 38);
            this.allTextRadioButton.Name = "allTextRadioButton";
            this.allTextRadioButton.Size = new System.Drawing.Size(56, 17);
            this.allTextRadioButton.TabIndex = 4;
            this.allTextRadioButton.TabStop = true;
            this.allTextRadioButton.Text = "All text";
            this.allTextRadioButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(203, 93);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(122, 93);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // descCheckBox
            // 
            this.descCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.descCheckBox.AutoSize = true;
            this.descCheckBox.Image = global::DtPad.ToolbarResource.move_down;
            this.descCheckBox.Location = new System.Drawing.Point(200, 9);
            this.descCheckBox.Name = "descCheckBox";
            this.descCheckBox.Size = new System.Drawing.Size(58, 23);
            this.descCheckBox.TabIndex = 2;
            this.descCheckBox.Text = "Desc";
            this.descCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.descCheckBox.UseVisualStyleBackColor = true;
            this.descCheckBox.CheckedChanged += new System.EventHandler(this.descCheckBox_CheckedChanged);
            // 
            // ascCheckBox
            // 
            this.ascCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ascCheckBox.AutoSize = true;
            this.ascCheckBox.Checked = true;
            this.ascCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ascCheckBox.Image = global::DtPad.ToolbarResource.move_up;
            this.ascCheckBox.Location = new System.Drawing.Point(115, 9);
            this.ascCheckBox.Name = "ascCheckBox";
            this.ascCheckBox.Size = new System.Drawing.Size(51, 23);
            this.ascCheckBox.TabIndex = 1;
            this.ascCheckBox.Text = "Asc";
            this.ascCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ascCheckBox.UseVisualStyleBackColor = true;
            this.ascCheckBox.CheckedChanged += new System.EventHandler(this.ascCheckBox_CheckedChanged);
            // 
            // sortTypeLabel
            // 
            this.sortTypeLabel.AutoSize = true;
            this.sortTypeLabel.Location = new System.Drawing.Point(12, 14);
            this.sortTypeLabel.Name = "sortTypeLabel";
            this.sortTypeLabel.Size = new System.Drawing.Size(52, 13);
            this.sortTypeLabel.TabIndex = 0;
            this.sortTypeLabel.Text = "Sort type:";
            // 
            // SortText
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(291, 128);
            this.Controls.Add(this.descCheckBox);
            this.Controls.Add(this.ascCheckBox);
            this.Controls.Add(this.sortTypeLabel);
            this.Controls.Add(this.applyToLabel);
            this.Controls.Add(this.selectedTextRadioButton);
            this.Controls.Add(this.allTextRadioButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SortText";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sort Text";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SortText_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label applyToLabel;
        private System.Windows.Forms.RadioButton selectedTextRadioButton;
        private System.Windows.Forms.RadioButton allTextRadioButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox descCheckBox;
        private System.Windows.Forms.CheckBox ascCheckBox;
        private System.Windows.Forms.Label sortTypeLabel;
    }
}
