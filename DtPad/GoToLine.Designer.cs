namespace DtPad
{
    partial class GoToLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoToLine));
            this.lineNumberLabel1 = new System.Windows.Forms.Label();
            this.lineNumberLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.lineCurrentLabel = new System.Windows.Forms.Label();
            this.lineCurrentLabel1 = new System.Windows.Forms.Label();
            this.lineNumericUpDown = new DtPad.Customs.CustomNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.lineNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // lineNumberLabel1
            // 
            this.lineNumberLabel1.AutoSize = true;
            this.lineNumberLabel1.Location = new System.Drawing.Point(13, 31);
            this.lineNumberLabel1.Name = "lineNumberLabel1";
            this.lineNumberLabel1.Size = new System.Drawing.Size(97, 13);
            this.lineNumberLabel1.TabIndex = 2;
            this.lineNumberLabel1.Text = "Total rows number:";
            // 
            // lineNumberLabel
            // 
            this.lineNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineNumberLabel.AutoSize = true;
            this.lineNumberLabel.Location = new System.Drawing.Point(120, 31);
            this.lineNumberLabel.Name = "lineNumberLabel";
            this.lineNumberLabel.Size = new System.Drawing.Size(86, 13);
            this.lineNumberLabel.TabIndex = 3;
            this.lineNumberLabel.Tag = "DontTranslate";
            this.lineNumberLabel.Text = "lineNumberLabel";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(123, 96);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(42, 96);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Go";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // lineCurrentLabel
            // 
            this.lineCurrentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineCurrentLabel.AutoSize = true;
            this.lineCurrentLabel.Location = new System.Drawing.Point(120, 13);
            this.lineCurrentLabel.Name = "lineCurrentLabel";
            this.lineCurrentLabel.Size = new System.Drawing.Size(83, 13);
            this.lineCurrentLabel.TabIndex = 1;
            this.lineCurrentLabel.Tag = "DontTranslate";
            this.lineCurrentLabel.Text = "lineCurrentLabel";
            // 
            // lineCurrentLabel1
            // 
            this.lineCurrentLabel1.AutoSize = true;
            this.lineCurrentLabel1.Location = new System.Drawing.Point(13, 13);
            this.lineCurrentLabel1.Name = "lineCurrentLabel1";
            this.lineCurrentLabel1.Size = new System.Drawing.Size(64, 13);
            this.lineCurrentLabel1.TabIndex = 0;
            this.lineCurrentLabel1.Text = "Current row:";
            // 
            // lineNumericUpDown
            // 
            this.lineNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineNumericUpDown.CustomContextMenuStrip = null;
            this.lineNumericUpDown.Location = new System.Drawing.Point(16, 54);
            this.lineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineNumericUpDown.Name = "lineNumericUpDown";
            this.lineNumericUpDown.Size = new System.Drawing.Size(177, 20);
            this.lineNumericUpDown.TabIndex = 4;
            this.lineNumericUpDown.Tag = "DontTranslate";
            this.lineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // GoToLine
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(210, 131);
            this.Controls.Add(this.lineCurrentLabel1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.lineNumericUpDown);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.lineNumberLabel1);
            this.Controls.Add(this.lineNumberLabel);
            this.Controls.Add(this.lineCurrentLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoToLine";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Go To Line";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.GoToLine_HelpButtonClicked);
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
        private System.Windows.Forms.Label lineCurrentLabel;
        private System.Windows.Forms.Label lineCurrentLabel1;
    }
}
