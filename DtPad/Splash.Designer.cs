namespace DtPad
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.splashPanel = new System.Windows.Forms.Panel();
            this.doNotShowCheckBox = new System.Windows.Forms.CheckBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.splashPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splashPanel
            // 
            this.splashPanel.BackColor = System.Drawing.SystemColors.Window;
            this.splashPanel.BackgroundImage = global::DtPad.WindowResource.splash_screen;
            this.splashPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splashPanel.Controls.Add(this.doNotShowCheckBox);
            this.splashPanel.Controls.Add(this.titleLabel);
            this.splashPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splashPanel.Location = new System.Drawing.Point(0, 0);
            this.splashPanel.Name = "splashPanel";
            this.splashPanel.Size = new System.Drawing.Size(298, 191);
            this.splashPanel.TabIndex = 0;
            // 
            // doNotShowCheckBox
            // 
            this.doNotShowCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doNotShowCheckBox.AutoSize = true;
            this.doNotShowCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.doNotShowCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.doNotShowCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.doNotShowCheckBox.Location = new System.Drawing.Point(158, 165);
            this.doNotShowCheckBox.Name = "doNotShowCheckBox";
            this.doNotShowCheckBox.Size = new System.Drawing.Size(127, 17);
            this.doNotShowCheckBox.TabIndex = 1;
            this.doNotShowCheckBox.Text = "Do not show anymore";
            this.doNotShowCheckBox.UseVisualStyleBackColor = false;
            this.doNotShowCheckBox.Click += new System.EventHandler(this.doNotShowCheckBox_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(16, 136);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(97, 24);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "loading...";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 191);
            this.Controls.Add(this.splashPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Splash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.splashPanel.ResumeLayout(false);
            this.splashPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox doNotShowCheckBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel splashPanel;
    }
}
