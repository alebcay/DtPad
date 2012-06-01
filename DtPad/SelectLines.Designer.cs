namespace DtPad
{
    partial class SelectLines
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectLines));
            this.lineNumberLabel = new System.Windows.Forms.Label();
            this.lineNumberLabel1 = new System.Windows.Forms.Label();
            this.lineFromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lineToNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lineFromNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineToNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // lineNumberLabel
            // 
            this.lineNumberLabel.AutoSize = true;
            this.lineNumberLabel.Location = new System.Drawing.Point(90, 13);
            this.lineNumberLabel.Name = "lineNumberLabel";
            this.lineNumberLabel.Size = new System.Drawing.Size(86, 13);
            this.lineNumberLabel.TabIndex = 1;
            this.lineNumberLabel.Text = "lineNumberLabel";
            // 
            // lineNumberLabel1
            // 
            this.lineNumberLabel1.AutoSize = true;
            this.lineNumberLabel1.Location = new System.Drawing.Point(13, 13);
            this.lineNumberLabel1.Name = "lineNumberLabel1";
            this.lineNumberLabel1.Size = new System.Drawing.Size(73, 13);
            this.lineNumberLabel1.TabIndex = 0;
            this.lineNumberLabel1.Text = "Lines number:";
            // 
            // lineFromNumericUpDown
            // 
            this.lineFromNumericUpDown.Location = new System.Drawing.Point(65, 39);
            this.lineFromNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineFromNumericUpDown.Name = "lineFromNumericUpDown";
            this.lineFromNumericUpDown.Size = new System.Drawing.Size(114, 20);
            this.lineFromNumericUpDown.TabIndex = 3;
            this.lineFromNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lineToNumericUpDown
            // 
            this.lineToNumericUpDown.Location = new System.Drawing.Point(65, 65);
            this.lineToNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineToNumericUpDown.Name = "lineToNumericUpDown";
            this.lineToNumericUpDown.Size = new System.Drawing.Size(114, 20);
            this.lineToNumericUpDown.TabIndex = 5;
            this.lineToNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(13, 41);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(33, 13);
            this.fromLabel.TabIndex = 2;
            this.fromLabel.Text = "From:";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(13, 67);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(23, 13);
            this.toLabel.TabIndex = 4;
            this.toLabel.Text = "To:";
            // 
            // okButton
            // 
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(28, 100);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(109, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SelectLines
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(196, 138);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.lineToNumericUpDown);
            this.Controls.Add(this.lineFromNumericUpDown);
            this.Controls.Add(this.lineNumberLabel);
            this.Controls.Add(this.lineNumberLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectLines";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select lines";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SelectLines_HelpButtonClicked);
            ((System.ComponentModel.ISupportInitialize)(this.lineFromNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineToNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lineNumberLabel;
        private System.Windows.Forms.Label lineNumberLabel1;
        private System.Windows.Forms.NumericUpDown lineFromNumericUpDown;
        private System.Windows.Forms.NumericUpDown lineToNumericUpDown;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
