namespace DtPad
{
    partial class PadText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PadText));
            this.padToLabel = new System.Windows.Forms.Label();
            this.whiteCharacterLabel = new System.Windows.Forms.Label();
            this.whiteCharacterTextBox = new System.Windows.Forms.TextBox();
            this.widthLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.leftCheckBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.rightCheckBox = new System.Windows.Forms.CheckBox();
            this.allTextRadioButton = new System.Windows.Forms.RadioButton();
            this.selectedTextRadioButton = new System.Windows.Forms.RadioButton();
            this.applyToLabel = new System.Windows.Forms.Label();
            this.absoluteWidthCheckBox = new System.Windows.Forms.CheckBox();
            this.absoluteWidthPictureBox = new System.Windows.Forms.PictureBox();
            this.padTextToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.widthNumericUpDown = new DtPad.Customs.CustomNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.absoluteWidthPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // padToLabel
            // 
            this.padToLabel.AutoSize = true;
            this.padToLabel.Location = new System.Drawing.Point(12, 14);
            this.padToLabel.Name = "padToLabel";
            this.padToLabel.Size = new System.Drawing.Size(65, 13);
            this.padToLabel.TabIndex = 0;
            this.padToLabel.Text = "Align text to:";
            // 
            // whiteCharacterLabel
            // 
            this.whiteCharacterLabel.AutoSize = true;
            this.whiteCharacterLabel.Location = new System.Drawing.Point(12, 41);
            this.whiteCharacterLabel.Name = "whiteCharacterLabel";
            this.whiteCharacterLabel.Size = new System.Drawing.Size(84, 13);
            this.whiteCharacterLabel.TabIndex = 3;
            this.whiteCharacterLabel.Text = "Filling character:";
            // 
            // whiteCharacterTextBox
            // 
            this.whiteCharacterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.whiteCharacterTextBox.Location = new System.Drawing.Point(126, 38);
            this.whiteCharacterTextBox.MaxLength = 1;
            this.whiteCharacterTextBox.Name = "whiteCharacterTextBox";
            this.whiteCharacterTextBox.Size = new System.Drawing.Size(173, 20);
            this.whiteCharacterTextBox.TabIndex = 4;
            this.whiteCharacterTextBox.Tag = "DontTranslate";
            this.whiteCharacterTextBox.TextChanged += new System.EventHandler(this.whiteCharacterTextBox_TextChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(12, 66);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(38, 13);
            this.widthLabel.TabIndex = 5;
            this.widthLabel.Text = "Width:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(225, 177);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // leftCheckBox
            // 
            this.leftCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.leftCheckBox.AutoSize = true;
            this.leftCheckBox.Image = global::DtPad.ToolbarResource.move_left;
            this.leftCheckBox.Location = new System.Drawing.Point(126, 9);
            this.leftCheckBox.Name = "leftCheckBox";
            this.leftCheckBox.Size = new System.Drawing.Size(51, 23);
            this.leftCheckBox.TabIndex = 1;
            this.leftCheckBox.Text = "Left";
            this.leftCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.leftCheckBox.UseVisualStyleBackColor = true;
            this.leftCheckBox.CheckedChanged += new System.EventHandler(this.leftCheckBox_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Enabled = false;
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(126, 177);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(93, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "Align";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // rightCheckBox
            // 
            this.rightCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.rightCheckBox.AutoSize = true;
            this.rightCheckBox.Checked = true;
            this.rightCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rightCheckBox.Image = global::DtPad.ToolbarResource.move_right;
            this.rightCheckBox.Location = new System.Drawing.Point(211, 9);
            this.rightCheckBox.Name = "rightCheckBox";
            this.rightCheckBox.Size = new System.Drawing.Size(58, 23);
            this.rightCheckBox.TabIndex = 2;
            this.rightCheckBox.Text = "Right";
            this.rightCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rightCheckBox.UseVisualStyleBackColor = true;
            this.rightCheckBox.CheckedChanged += new System.EventHandler(this.rightCheckBox_CheckedChanged);
            // 
            // allTextRadioButton
            // 
            this.allTextRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allTextRadioButton.Checked = true;
            this.allTextRadioButton.Location = new System.Drawing.Point(126, 115);
            this.allTextRadioButton.Name = "allTextRadioButton";
            this.allTextRadioButton.Size = new System.Drawing.Size(173, 17);
            this.allTextRadioButton.TabIndex = 9;
            this.allTextRadioButton.TabStop = true;
            this.allTextRadioButton.Text = "All text";
            this.allTextRadioButton.UseVisualStyleBackColor = true;
            // 
            // selectedTextRadioButton
            // 
            this.selectedTextRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedTextRadioButton.Location = new System.Drawing.Point(126, 136);
            this.selectedTextRadioButton.Name = "selectedTextRadioButton";
            this.selectedTextRadioButton.Size = new System.Drawing.Size(173, 17);
            this.selectedTextRadioButton.TabIndex = 10;
            this.selectedTextRadioButton.Text = "Selected text";
            this.selectedTextRadioButton.UseVisualStyleBackColor = true;
            // 
            // applyToLabel
            // 
            this.applyToLabel.AutoSize = true;
            this.applyToLabel.Location = new System.Drawing.Point(12, 115);
            this.applyToLabel.Name = "applyToLabel";
            this.applyToLabel.Size = new System.Drawing.Size(48, 13);
            this.applyToLabel.TabIndex = 8;
            this.applyToLabel.Text = "Apply to:";
            // 
            // absoluteWidthCheckBox
            // 
            this.absoluteWidthCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.absoluteWidthCheckBox.Location = new System.Drawing.Point(126, 90);
            this.absoluteWidthCheckBox.Name = "absoluteWidthCheckBox";
            this.absoluteWidthCheckBox.Size = new System.Drawing.Size(151, 17);
            this.absoluteWidthCheckBox.TabIndex = 7;
            this.absoluteWidthCheckBox.Text = "Absolute width";
            this.absoluteWidthCheckBox.UseVisualStyleBackColor = true;
            // 
            // absoluteWidthPictureBox
            // 
            this.absoluteWidthPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.absoluteWidthPictureBox.Image = global::DtPad.ToolbarResource.info_blue;
            this.absoluteWidthPictureBox.Location = new System.Drawing.Point(283, 90);
            this.absoluteWidthPictureBox.Name = "absoluteWidthPictureBox";
            this.absoluteWidthPictureBox.Size = new System.Drawing.Size(16, 16);
            this.absoluteWidthPictureBox.TabIndex = 13;
            this.absoluteWidthPictureBox.TabStop = false;
            this.padTextToolTip.SetToolTip(this.absoluteWidthPictureBox, "If this option is activated, width value is added to maximum selected rows lenght" +
        ",\r\notherwise is considered as absolute value");
            // 
            // widthNumericUpDown
            // 
            this.widthNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.widthNumericUpDown.CustomContextMenuStrip = null;
            this.widthNumericUpDown.Location = new System.Drawing.Point(126, 64);
            this.widthNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.widthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumericUpDown.Name = "widthNumericUpDown";
            this.widthNumericUpDown.Size = new System.Drawing.Size(173, 20);
            this.widthNumericUpDown.TabIndex = 6;
            this.widthNumericUpDown.Tag = "DontTranslate";
            this.widthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PadText
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(312, 211);
            this.Controls.Add(this.absoluteWidthPictureBox);
            this.Controls.Add(this.absoluteWidthCheckBox);
            this.Controls.Add(this.applyToLabel);
            this.Controls.Add(this.selectedTextRadioButton);
            this.Controls.Add(this.allTextRadioButton);
            this.Controls.Add(this.rightCheckBox);
            this.Controls.Add(this.leftCheckBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.widthNumericUpDown);
            this.Controls.Add(this.whiteCharacterTextBox);
            this.Controls.Add(this.whiteCharacterLabel);
            this.Controls.Add(this.padToLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PadText";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Align Text";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.PadText_HelpButtonClicked);
            ((System.ComponentModel.ISupportInitialize)(this.absoluteWidthPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label padToLabel;
        private System.Windows.Forms.Label whiteCharacterLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        internal System.Windows.Forms.TextBox whiteCharacterTextBox;
        internal Customs.CustomNumericUpDown widthNumericUpDown;
        private System.Windows.Forms.CheckBox leftCheckBox;
        private System.Windows.Forms.CheckBox rightCheckBox;
        internal System.Windows.Forms.RadioButton allTextRadioButton;
        private System.Windows.Forms.RadioButton selectedTextRadioButton;
        private System.Windows.Forms.Label applyToLabel;
        internal System.Windows.Forms.CheckBox absoluteWidthCheckBox;
        private System.Windows.Forms.PictureBox absoluteWidthPictureBox;
        private System.Windows.Forms.ToolTip padTextToolTip;
    }
}
