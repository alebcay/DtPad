namespace DtPad
{
    partial class MoveLines
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveLines));
            this.lineNumberLabel1 = new System.Windows.Forms.Label();
            this.lineNumberLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.upRadioButton = new System.Windows.Forms.RadioButton();
            this.downRadioButton = new System.Windows.Forms.RadioButton();
            this.lineLabel = new System.Windows.Forms.Label();
            this.moveUpPictureBox = new System.Windows.Forms.PictureBox();
            this.moveDownPictureBox = new System.Windows.Forms.PictureBox();
            this.lineNumericUpDown = new DtPad.Customs.CustomNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.moveUpPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveDownPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // lineNumberLabel1
            // 
            this.lineNumberLabel1.AutoSize = true;
            this.lineNumberLabel1.Location = new System.Drawing.Point(12, 9);
            this.lineNumberLabel1.Name = "lineNumberLabel1";
            this.lineNumberLabel1.Size = new System.Drawing.Size(100, 13);
            this.lineNumberLabel1.TabIndex = 0;
            this.lineNumberLabel1.Text = "Total rows number: ";
            // 
            // lineNumberLabel
            // 
            this.lineNumberLabel.AutoSize = true;
            this.lineNumberLabel.Location = new System.Drawing.Point(141, 9);
            this.lineNumberLabel.Name = "lineNumberLabel";
            this.lineNumberLabel.Size = new System.Drawing.Size(86, 13);
            this.lineNumberLabel.TabIndex = 1;
            this.lineNumberLabel.Tag = "DontTranslate";
            this.lineNumberLabel.Text = "lineNumberLabel";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(184, 132);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Close";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(64, 132);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(114, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Move";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // upRadioButton
            // 
            this.upRadioButton.AutoSize = true;
            this.upRadioButton.Checked = true;
            this.upRadioButton.Location = new System.Drawing.Point(146, 74);
            this.upRadioButton.Name = "upRadioButton";
            this.upRadioButton.Size = new System.Drawing.Size(67, 17);
            this.upRadioButton.TabIndex = 4;
            this.upRadioButton.TabStop = true;
            this.upRadioButton.Text = "Move up";
            this.upRadioButton.UseVisualStyleBackColor = true;
            this.upRadioButton.CheckedChanged += new System.EventHandler(this.upRadioButton_CheckedChanged);
            // 
            // downRadioButton
            // 
            this.downRadioButton.AutoSize = true;
            this.downRadioButton.Location = new System.Drawing.Point(146, 97);
            this.downRadioButton.Name = "downRadioButton";
            this.downRadioButton.Size = new System.Drawing.Size(81, 17);
            this.downRadioButton.TabIndex = 5;
            this.downRadioButton.Text = "Move down";
            this.downRadioButton.UseVisualStyleBackColor = true;
            // 
            // lineLabel
            // 
            this.lineLabel.AutoSize = true;
            this.lineLabel.Location = new System.Drawing.Point(12, 32);
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(179, 13);
            this.lineLabel.TabIndex = 2;
            this.lineLabel.Text = "Positions to move the selected rows:";
            // 
            // moveUpPictureBox
            // 
            this.moveUpPictureBox.Image = global::DtPad.ToolbarResource.arrow_up;
            this.moveUpPictureBox.Location = new System.Drawing.Point(124, 75);
            this.moveUpPictureBox.Name = "moveUpPictureBox";
            this.moveUpPictureBox.Size = new System.Drawing.Size(16, 16);
            this.moveUpPictureBox.TabIndex = 8;
            this.moveUpPictureBox.TabStop = false;
            this.moveUpPictureBox.Tag = "DontTranslate";
            // 
            // moveDownPictureBox
            // 
            this.moveDownPictureBox.Image = global::DtPad.ToolbarResource.arrow_down;
            this.moveDownPictureBox.Location = new System.Drawing.Point(124, 98);
            this.moveDownPictureBox.Name = "moveDownPictureBox";
            this.moveDownPictureBox.Size = new System.Drawing.Size(16, 16);
            this.moveDownPictureBox.TabIndex = 9;
            this.moveDownPictureBox.TabStop = false;
            this.moveDownPictureBox.Tag = "DontTranslate";
            // 
            // lineNumericUpDown
            // 
            this.lineNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineNumericUpDown.CustomContextMenuStrip = null;
            this.lineNumericUpDown.Location = new System.Drawing.Point(124, 48);
            this.lineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineNumericUpDown.Name = "lineNumericUpDown";
            this.lineNumericUpDown.Size = new System.Drawing.Size(135, 20);
            this.lineNumericUpDown.TabIndex = 3;
            this.lineNumericUpDown.Tag = "DontTranslate";
            this.lineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MoveLines
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(271, 167);
            this.Controls.Add(this.moveDownPictureBox);
            this.Controls.Add(this.moveUpPictureBox);
            this.Controls.Add(this.lineLabel);
            this.Controls.Add(this.upRadioButton);
            this.Controls.Add(this.downRadioButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.lineNumericUpDown);
            this.Controls.Add(this.lineNumberLabel);
            this.Controls.Add(this.lineNumberLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoveLines";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move Rows";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MoveLines_HelpButtonClicked);
            ((System.ComponentModel.ISupportInitialize)(this.moveUpPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveDownPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lineNumberLabel1;
        private System.Windows.Forms.Label lineNumberLabel;
        private Customs.CustomNumericUpDown lineNumericUpDown;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.RadioButton upRadioButton;
        private System.Windows.Forms.RadioButton downRadioButton;
        private System.Windows.Forms.Label lineLabel;
        private System.Windows.Forms.PictureBox moveUpPictureBox;
        private System.Windows.Forms.PictureBox moveDownPictureBox;
    }
}
