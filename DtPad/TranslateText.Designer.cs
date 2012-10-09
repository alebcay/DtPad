namespace DtPad
{
    partial class TranslateText
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranslateText));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.destinationImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.languageImageList = new System.Windows.Forms.ImageList(this.components);
            this.sourceImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.destinationLanguageLabel = new System.Windows.Forms.Label();
            this.sourceLanguageLabel = new System.Windows.Forms.Label();
            this.translateButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.switchButton = new System.Windows.Forms.Button();
            this.translateTextToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.destinationImageComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageComboBoxEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // destinationImageComboBoxEdit
            // 
            this.destinationImageComboBoxEdit.EditValue = "Italiano";
            this.destinationImageComboBoxEdit.Location = new System.Drawing.Point(91, 29);
            this.destinationImageComboBoxEdit.Name = "destinationImageComboBoxEdit";
            this.destinationImageComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, global::DtPad.Languages.it.SearchPattern_historyComboBoxItems, 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, global::DtPad.Languages.it.SearchPattern_historyComboBoxItems, null, null, false)});
            this.destinationImageComboBoxEdit.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("English", "English", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Italiano", "Italiano", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Français", "Français", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Español", "Español", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Deutsch", "Deutsch", 4)});
            this.destinationImageComboBoxEdit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.destinationImageComboBoxEdit.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.destinationImageComboBoxEdit.Properties.SmallImages = this.languageImageList;
            this.destinationImageComboBoxEdit.Size = new System.Drawing.Size(194, 20);
            this.destinationImageComboBoxEdit.TabIndex = 3;
            // 
            // languageImageList
            // 
            this.languageImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("languageImageList.ImageStream")));
            this.languageImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.languageImageList.Images.SetKeyName(0, "flag-eng.png");
            this.languageImageList.Images.SetKeyName(1, "flag-ita.png");
            this.languageImageList.Images.SetKeyName(2, "flag-fra.png");
            this.languageImageList.Images.SetKeyName(3, "flag-esp.png");
            this.languageImageList.Images.SetKeyName(4, "flag-ger.png");
            // 
            // sourceImageComboBoxEdit
            // 
            this.sourceImageComboBoxEdit.EditValue = "English";
            this.sourceImageComboBoxEdit.Location = new System.Drawing.Point(91, 6);
            this.sourceImageComboBoxEdit.Name = "sourceImageComboBoxEdit";
            this.sourceImageComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, global::DtPad.Languages.it.SearchPattern_historyComboBoxItems, 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, global::DtPad.Languages.it.SearchPattern_historyComboBoxItems, null, null, false)});
            this.sourceImageComboBoxEdit.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("English", "English", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Italiano", "Italiano", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Français", "Français", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Español", "Español", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Deutsch", "Deutsch", 4)});
            this.sourceImageComboBoxEdit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.sourceImageComboBoxEdit.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.sourceImageComboBoxEdit.Properties.SmallImages = this.languageImageList;
            this.sourceImageComboBoxEdit.Size = new System.Drawing.Size(194, 20);
            this.sourceImageComboBoxEdit.TabIndex = 1;
            // 
            // destinationLanguageLabel
            // 
            this.destinationLanguageLabel.AutoSize = true;
            this.destinationLanguageLabel.Location = new System.Drawing.Point(12, 32);
            this.destinationLanguageLabel.Name = "destinationLanguageLabel";
            this.destinationLanguageLabel.Size = new System.Drawing.Size(63, 13);
            this.destinationLanguageLabel.TabIndex = 2;
            this.destinationLanguageLabel.Text = "Destination:";
            // 
            // sourceLanguageLabel
            // 
            this.sourceLanguageLabel.AutoSize = true;
            this.sourceLanguageLabel.Location = new System.Drawing.Point(12, 9);
            this.sourceLanguageLabel.Name = "sourceLanguageLabel";
            this.sourceLanguageLabel.Size = new System.Drawing.Size(44, 13);
            this.sourceLanguageLabel.TabIndex = 0;
            this.sourceLanguageLabel.Text = "Source:";
            // 
            // translateButton
            // 
            this.translateButton.Image = global::DtPad.MessageBoxResource.ok;
            this.translateButton.Location = new System.Drawing.Point(159, 64);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(75, 23);
            this.translateButton.TabIndex = 5;
            this.translateButton.Text = "Translate";
            this.translateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.translateButton.UseVisualStyleBackColor = true;
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(240, 64);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // switchButton
            // 
            this.switchButton.Image = global::DtPad.ToolbarResource._switch;
            this.switchButton.Location = new System.Drawing.Point(293, 16);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(23, 23);
            this.switchButton.TabIndex = 4;
            this.switchButton.UseVisualStyleBackColor = true;
            this.switchButton.Click += new System.EventHandler(this.switchButton_Click);
            // 
            // TranslateText
            // 
            this.AcceptButton = this.translateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(327, 99);
            this.Controls.Add(this.switchButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.destinationImageComboBoxEdit);
            this.Controls.Add(this.sourceImageComboBoxEdit);
            this.Controls.Add(this.destinationLanguageLabel);
            this.Controls.Add(this.sourceLanguageLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TranslateText";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Translate Text";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.TranslateText_HelpButtonClicked);
            ((System.ComponentModel.ISupportInitialize)(this.destinationImageComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageComboBoxEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label destinationLanguageLabel;
        private System.Windows.Forms.Label sourceLanguageLabel;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ImageList languageImageList;
        private DevExpress.XtraEditors.ImageComboBoxEdit destinationImageComboBoxEdit;
        private DevExpress.XtraEditors.ImageComboBoxEdit sourceImageComboBoxEdit;
        private System.Windows.Forms.Button switchButton;
        private System.Windows.Forms.ToolTip translateTextToolTip;
    }
}
