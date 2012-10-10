namespace DtPad
{
    partial class Options
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
            System.Windows.Forms.TreeNode treeNode91 = new System.Windows.Forms.TreeNode("Encoding");
            System.Windows.Forms.TreeNode treeNode92 = new System.Windows.Forms.TreeNode("Opening");
            System.Windows.Forms.TreeNode treeNode93 = new System.Windows.Forms.TreeNode("Saving");
            System.Windows.Forms.TreeNode treeNode94 = new System.Windows.Forms.TreeNode("File", new System.Windows.Forms.TreeNode[] {
            treeNode91,
            treeNode92,
            treeNode93});
            System.Windows.Forms.TreeNode treeNode95 = new System.Windows.Forms.TreeNode("Session");
            System.Windows.Forms.TreeNode treeNode96 = new System.Windows.Forms.TreeNode("Search");
            System.Windows.Forms.TreeNode treeNode97 = new System.Windows.Forms.TreeNode("Format");
            System.Windows.Forms.TreeNode treeNode98 = new System.Windows.Forms.TreeNode("Language");
            System.Windows.Forms.TreeNode treeNode99 = new System.Windows.Forms.TreeNode("Tab");
            System.Windows.Forms.TreeNode treeNode100 = new System.Windows.Forms.TreeNode("Look & Feel");
            System.Windows.Forms.TreeNode treeNode101 = new System.Windows.Forms.TreeNode("View", new System.Windows.Forms.TreeNode[] {
            treeNode100});
            System.Windows.Forms.TreeNode treeNode102 = new System.Windows.Forms.TreeNode("Updates");
            System.Windows.Forms.TreeNode treeNode103 = new System.Windows.Forms.TreeNode("Dropbox");
            System.Windows.Forms.TreeNode treeNode104 = new System.Windows.Forms.TreeNode("Internet", new System.Windows.Forms.TreeNode[] {
            treeNode102,
            treeNode103});
            System.Windows.Forms.TreeNode treeNode105 = new System.Windows.Forms.TreeNode("Shell Integration");
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.optionsTreeView = new System.Windows.Forms.TreeView();
            this.searchPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.searchGroupBox1 = new System.Windows.Forms.GroupBox();
            this.highlightsResultsCheckBox = new System.Windows.Forms.CheckBox();
            this.searchHistoryNumericUpDown = new DtPad.Customs.CustomNumericUpDown();
            this.numberContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchHistoryLabel = new System.Windows.Forms.Label();
            this.loopAtEOFCheckBox = new System.Windows.Forms.CheckBox();
            this.caseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.showSearchPanelCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.formatPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.formatGroupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundColorTextBox = new System.Windows.Forms.TextBox();
            this.fontColorTextBox = new System.Windows.Forms.TextBox();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.backgroundColorLabel = new System.Windows.Forms.Label();
            this.fontColorLabel = new System.Windows.Forms.Label();
            this.fontLabel1 = new System.Windows.Forms.Label();
            this.fontLabel = new System.Windows.Forms.Label();
            this.fontButton = new System.Windows.Forms.Button();
            this.wordWrapCheckBox = new System.Windows.Forms.CheckBox();
            this.formatGroupBox2 = new System.Windows.Forms.GroupBox();
            this.keepBulletListOnReturnLabel2 = new System.Windows.Forms.Label();
            this.keepBulletListOnReturnLabel = new System.Windows.Forms.Label();
            this.urlsCheckBox = new System.Windows.Forms.CheckBox();
            this.keepBulletListOnReturnCheckBox = new System.Windows.Forms.CheckBox();
            this.useSpacesInsteadTabsCheckBox = new System.Windows.Forms.CheckBox();
            this.keepInitialSpacesOnReturnCheckBox = new System.Windows.Forms.CheckBox();
            this.languageGroupBox1 = new System.Windows.Forms.GroupBox();
            this.languageComboBox = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.languageImageList = new System.Windows.Forms.ImageList(this.components);
            this.languageLabel = new System.Windows.Forms.Label();
            this.viewPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.viewGroupBox1 = new System.Windows.Forms.GroupBox();
            this.splashScreenCheckBox = new System.Windows.Forms.CheckBox();
            this.minimizeOnTrayIconCheckBox = new System.Windows.Forms.CheckBox();
            this.stayOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.viewGroupBox2 = new System.Windows.Forms.GroupBox();
            this.statusBarCheckBox = new System.Windows.Forms.CheckBox();
            this.toolbarCheckBox = new System.Windows.Forms.CheckBox();
            this.viewGroupBox3 = new System.Windows.Forms.GroupBox();
            this.hideLinesNumericUpDown = new DtPad.Customs.CustomNumericUpDown();
            this.helpHideLinesPictureBox = new System.Windows.Forms.PictureBox();
            this.hideLinesCheckBox = new System.Windows.Forms.CheckBox();
            this.lineNumbersCheckBox = new System.Windows.Forms.CheckBox();
            this.internalExplorerCheckBox = new System.Windows.Forms.CheckBox();
            this.tabCloseButtonOnComboBox = new System.Windows.Forms.ComboBox();
            this.closeTabButtonOnLabel = new System.Windows.Forms.Label();
            this.internetPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.internetGroupBox1 = new System.Windows.Forms.GroupBox();
            this.proxyPortNumericUpDown = new DtPad.Customs.CustomNumericUpDown();
            this.proxyHostTextBox = new System.Windows.Forms.TextBox();
            this.contentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proxyPortLabel = new System.Windows.Forms.Label();
            this.proxyHostLabel = new System.Windows.Forms.Label();
            this.checkConnectionButton = new System.Windows.Forms.Button();
            this.infoProxyPictureBox = new System.Windows.Forms.PictureBox();
            this.statusPictureBox = new System.Windows.Forms.PictureBox();
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.domainLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.enableProxySettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.internetGroupBox2 = new System.Windows.Forms.GroupBox();
            this.customBrowserButton = new System.Windows.Forms.Button();
            this.customBrowserTextBox = new System.Windows.Forms.TextBox();
            this.customBrowserRadioButton = new System.Windows.Forms.RadioButton();
            this.defaultBrowserRadioButton = new System.Windows.Forms.RadioButton();
            this.lookAndFeelPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lookAndFeelGroupBox1 = new System.Windows.Forms.GroupBox();
            this.renderPictureBox = new System.Windows.Forms.PictureBox();
            this.renderModeComboBox = new System.Windows.Forms.ComboBox();
            this.renderModeLabel = new System.Windows.Forms.Label();
            this.filePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.fileGroupBox1 = new System.Windows.Forms.GroupBox();
            this.folderOpenedFileCheckBox = new System.Windows.Forms.CheckBox();
            this.specificFolderButton = new System.Windows.Forms.Button();
            this.specificFolderTextBox = new System.Windows.Forms.TextBox();
            this.specificFolderRadioButton = new System.Windows.Forms.RadioButton();
            this.lastUsedFolderRadioButton = new System.Windows.Forms.RadioButton();
            this.fileGroupBox2 = new System.Windows.Forms.GroupBox();
            this.extensionsButton = new System.Windows.Forms.Button();
            this.extensionLabel = new System.Windows.Forms.Label();
            this.extensionListBox = new System.Windows.Forms.ListBox();
            this.clearRecentFilesButton = new System.Windows.Forms.Button();
            this.recentFilesNumberNumericUpDown = new DtPad.Customs.CustomNumericUpDown();
            this.recentFilesNumberLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.okButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.optionsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.encodingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.encodingGroupBox1 = new System.Windows.Forms.GroupBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.defaultComboBox = new System.Windows.Forms.ComboBox();
            this.defaultLabel = new System.Windows.Forms.Label();
            this.useExistingCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabGroupBox1 = new System.Windows.Forms.GroupBox();
            this.tabMultilineCheckBox = new System.Windows.Forms.CheckBox();
            this.tabOrientationComboBox = new System.Windows.Forms.ComboBox();
            this.tabOrientationLabel = new System.Windows.Forms.Label();
            this.tabPositionComboBox = new System.Windows.Forms.ComboBox();
            this.tabPositionLabel = new System.Windows.Forms.Label();
            this.savingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.savingGroupBox1 = new System.Windows.Forms.GroupBox();
            this.backupIncrementalCheckBox = new System.Windows.Forms.CheckBox();
            this.backupReplaceExtensionRadioButton = new System.Windows.Forms.RadioButton();
            this.backupAddExtensionRadioButton = new System.Windows.Forms.RadioButton();
            this.backupExtensionTextBox = new System.Windows.Forms.TextBox();
            this.backupExtensionLabel = new System.Windows.Forms.Label();
            this.createBackupCheckBox = new System.Windows.Forms.CheckBox();
            this.backupGroupBox2 = new System.Windows.Forms.GroupBox();
            this.backupCustomFolderTextBox = new System.Windows.Forms.TextBox();
            this.backupCustomFolderRadioButton = new System.Windows.Forms.RadioButton();
            this.backupCustomFolderButton = new System.Windows.Forms.Button();
            this.backupEditedFileRadioButton = new System.Windows.Forms.RadioButton();
            this.sessionPanel = new System.Windows.Forms.Panel();
            this.sessionGroupBox1 = new System.Windows.Forms.GroupBox();
            this.automaticSessionSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.languagePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.languageGroupBox2 = new System.Windows.Forms.GroupBox();
            this.switchButton = new System.Windows.Forms.Button();
            this.noteLanguageLabel = new System.Windows.Forms.Label();
            this.useSelectedSettingsLanguageCheckBox = new System.Windows.Forms.CheckBox();
            this.destinationImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.sourceImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.destinationLanguageLabel = new System.Windows.Forms.Label();
            this.sourceLanguageLabel = new System.Windows.Forms.Label();
            this.shellPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.shellGroupBox1 = new System.Windows.Forms.GroupBox();
            this.jumpListCheckBox = new System.Windows.Forms.CheckBox();
            this.openWithCheckBox = new System.Windows.Forms.CheckBox();
            this.sendToCheckBox = new System.Windows.Forms.CheckBox();
            this.openingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.openingGroupBox1 = new System.Windows.Forms.GroupBox();
            this.xmlCheckBox = new System.Windows.Forms.CheckBox();
            this.htmlCheckBox = new System.Windows.Forms.CheckBox();
            this.autoFormatLabel = new System.Windows.Forms.Label();
            this.openingGroupBox2 = new System.Windows.Forms.GroupBox();
            this.hostsConfiguratorTabColorComboBox = new System.Windows.Forms.ComboBox();
            this.hostsConfiguratorTabColorLabel = new System.Windows.Forms.Label();
            this.hostsConfiguratorCheckBox = new System.Windows.Forms.CheckBox();
            this.openingGroupBox3 = new System.Windows.Forms.GroupBox();
            this.nullCharCheckBox = new System.Windows.Forms.CheckBox();
            this.updatePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.updateGroupBox1 = new System.Windows.Forms.GroupBox();
            this.lastCheckLabel = new System.Windows.Forms.Label();
            this.frequencyAutomaticUpdateLabel = new System.Windows.Forms.Label();
            this.frequencyAutomaticUpdateComboBox = new System.Windows.Forms.ComboBox();
            this.enableAutomaticUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.dropboxPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dropboxGroupBox1 = new System.Windows.Forms.GroupBox();
            this.dropboxDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.dropboxRememberCheckBox = new System.Windows.Forms.CheckBox();
            this.searchPanel.SuspendLayout();
            this.searchGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchHistoryNumericUpDown)).BeginInit();
            this.numberContextMenuStrip.SuspendLayout();
            this.formatPanel.SuspendLayout();
            this.formatGroupBox1.SuspendLayout();
            this.formatGroupBox2.SuspendLayout();
            this.languageGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languageComboBox.Properties)).BeginInit();
            this.viewPanel.SuspendLayout();
            this.viewGroupBox1.SuspendLayout();
            this.viewGroupBox2.SuspendLayout();
            this.viewGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hideLinesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpHideLinesPictureBox)).BeginInit();
            this.internetPanel.SuspendLayout();
            this.internetGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proxyPortNumericUpDown)).BeginInit();
            this.contentContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoProxyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPictureBox)).BeginInit();
            this.internetGroupBox2.SuspendLayout();
            this.lookAndFeelPanel.SuspendLayout();
            this.lookAndFeelGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renderPictureBox)).BeginInit();
            this.filePanel.SuspendLayout();
            this.fileGroupBox1.SuspendLayout();
            this.fileGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentFilesNumberNumericUpDown)).BeginInit();
            this.encodingPanel.SuspendLayout();
            this.encodingGroupBox1.SuspendLayout();
            this.tabPanel.SuspendLayout();
            this.tabGroupBox1.SuspendLayout();
            this.savingPanel.SuspendLayout();
            this.savingGroupBox1.SuspendLayout();
            this.backupGroupBox2.SuspendLayout();
            this.sessionPanel.SuspendLayout();
            this.sessionGroupBox1.SuspendLayout();
            this.languagePanel.SuspendLayout();
            this.languageGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destinationImageComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageComboBoxEdit.Properties)).BeginInit();
            this.shellPanel.SuspendLayout();
            this.shellGroupBox1.SuspendLayout();
            this.openingPanel.SuspendLayout();
            this.openingGroupBox1.SuspendLayout();
            this.openingGroupBox2.SuspendLayout();
            this.openingGroupBox3.SuspendLayout();
            this.updatePanel.SuspendLayout();
            this.updateGroupBox1.SuspendLayout();
            this.dropboxPanel.SuspendLayout();
            this.dropboxGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsTreeView
            // 
            this.optionsTreeView.Location = new System.Drawing.Point(13, 13);
            this.optionsTreeView.Name = "optionsTreeView";
            treeNode91.Name = "encodingNode";
            treeNode91.Text = "Encoding";
            treeNode92.Name = "openingNode";
            treeNode92.Text = "Opening";
            treeNode93.Name = "savingNode";
            treeNode93.Text = "Saving";
            treeNode94.Name = "fileNode";
            treeNode94.Text = "File";
            treeNode95.Name = "sessionNode";
            treeNode95.Text = "Session";
            treeNode96.Name = "searchNode";
            treeNode96.Text = "Search";
            treeNode97.Name = "formatNode";
            treeNode97.Text = "Format";
            treeNode98.Name = "languageNode";
            treeNode98.Text = "Language";
            treeNode99.Name = "tabNode";
            treeNode99.Text = "Tab";
            treeNode100.Name = "lookAndFeelNode";
            treeNode100.Text = "Look & Feel";
            treeNode101.Name = "viewNode";
            treeNode101.Text = "View";
            treeNode102.Name = "updateNode";
            treeNode102.Text = "Updates";
            treeNode103.Name = "dropboxNode";
            treeNode103.Text = "Dropbox";
            treeNode104.Name = "internetNode";
            treeNode104.Text = "Internet";
            treeNode105.Name = "shellNode";
            treeNode105.Text = "Shell Integration";
            this.optionsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode94,
            treeNode95,
            treeNode96,
            treeNode97,
            treeNode98,
            treeNode99,
            treeNode101,
            treeNode104,
            treeNode105});
            this.optionsTreeView.Size = new System.Drawing.Size(131, 287);
            this.optionsTreeView.TabIndex = 0;
            this.optionsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.optionsTreeView_AfterSelect);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.searchGroupBox1);
            this.searchPanel.Location = new System.Drawing.Point(150, 13);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(349, 287);
            this.searchPanel.TabIndex = 6;
            this.searchPanel.Visible = false;
            // 
            // searchGroupBox1
            // 
            this.searchGroupBox1.Controls.Add(this.highlightsResultsCheckBox);
            this.searchGroupBox1.Controls.Add(this.searchHistoryNumericUpDown);
            this.searchGroupBox1.Controls.Add(this.searchHistoryLabel);
            this.searchGroupBox1.Controls.Add(this.loopAtEOFCheckBox);
            this.searchGroupBox1.Controls.Add(this.caseSensitiveCheckBox);
            this.searchGroupBox1.Controls.Add(this.showSearchPanelCheckBox);
            this.searchGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.searchGroupBox1.Name = "searchGroupBox1";
            this.searchGroupBox1.Size = new System.Drawing.Size(346, 147);
            this.searchGroupBox1.TabIndex = 0;
            this.searchGroupBox1.TabStop = false;
            this.searchGroupBox1.Text = "Search Panel";
            // 
            // highlightsResultsCheckBox
            // 
            this.highlightsResultsCheckBox.AutoSize = true;
            this.highlightsResultsCheckBox.Location = new System.Drawing.Point(10, 122);
            this.highlightsResultsCheckBox.Name = "highlightsResultsCheckBox";
            this.highlightsResultsCheckBox.Size = new System.Drawing.Size(105, 17);
            this.highlightsResultsCheckBox.TabIndex = 5;
            this.highlightsResultsCheckBox.Text = "Highlights results";
            this.highlightsResultsCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchHistoryNumericUpDown
            // 
            this.searchHistoryNumericUpDown.CustomContextMenuStrip = this.numberContextMenuStrip;
            this.searchHistoryNumericUpDown.Location = new System.Drawing.Point(120, 92);
            this.searchHistoryNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.searchHistoryNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.searchHistoryNumericUpDown.Name = "searchHistoryNumericUpDown";
            this.searchHistoryNumericUpDown.Size = new System.Drawing.Size(44, 20);
            this.searchHistoryNumericUpDown.TabIndex = 4;
            this.searchHistoryNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numberContextMenuStrip
            // 
            this.numberContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1,
            this.toolStripSeparator2,
            this.selectAllToolStripMenuItem1});
            this.numberContextMenuStrip.Name = "searchContextMenuStrip";
            this.numberContextMenuStrip.Size = new System.Drawing.Size(123, 76);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Image = global::DtPad.ToolbarResource.paste;
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(DtPad.Customs.CustomEvents.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
            // 
            // selectAllToolStripMenuItem1
            // 
            this.selectAllToolStripMenuItem1.Name = "selectAllToolStripMenuItem1";
            this.selectAllToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem1.Text = "Select All";
            this.selectAllToolStripMenuItem1.Click += new System.EventHandler(DtPad.Customs.CustomEvents.selectAllToolStripMenuItem_Click);
            // 
            // searchHistoryLabel
            // 
            this.searchHistoryLabel.AutoSize = true;
            this.searchHistoryLabel.Location = new System.Drawing.Point(6, 94);
            this.searchHistoryLabel.Name = "searchHistoryLabel";
            this.searchHistoryLabel.Size = new System.Drawing.Size(77, 13);
            this.searchHistoryLabel.TabIndex = 3;
            this.searchHistoryLabel.Text = "Search history:";
            // 
            // loopAtEOFCheckBox
            // 
            this.loopAtEOFCheckBox.AutoSize = true;
            this.loopAtEOFCheckBox.Location = new System.Drawing.Point(10, 66);
            this.loopAtEOFCheckBox.Name = "loopAtEOFCheckBox";
            this.loopAtEOFCheckBox.Size = new System.Drawing.Size(141, 17);
            this.loopAtEOFCheckBox.TabIndex = 2;
            this.loopAtEOFCheckBox.Text = "Loop at end of file (EOF)";
            this.loopAtEOFCheckBox.UseVisualStyleBackColor = true;
            // 
            // caseSensitiveCheckBox
            // 
            this.caseSensitiveCheckBox.AutoSize = true;
            this.caseSensitiveCheckBox.Location = new System.Drawing.Point(10, 43);
            this.caseSensitiveCheckBox.Name = "caseSensitiveCheckBox";
            this.caseSensitiveCheckBox.Size = new System.Drawing.Size(94, 17);
            this.caseSensitiveCheckBox.TabIndex = 1;
            this.caseSensitiveCheckBox.Text = "Case sensitive";
            this.caseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // showSearchPanelCheckBox
            // 
            this.showSearchPanelCheckBox.AutoSize = true;
            this.showSearchPanelCheckBox.Location = new System.Drawing.Point(10, 20);
            this.showSearchPanelCheckBox.Name = "showSearchPanelCheckBox";
            this.showSearchPanelCheckBox.Size = new System.Drawing.Size(117, 17);
            this.showSearchPanelCheckBox.TabIndex = 0;
            this.showSearchPanelCheckBox.Text = "Show search panel";
            this.showSearchPanelCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(343, 315);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // formatPanel
            // 
            this.formatPanel.Controls.Add(this.formatGroupBox1);
            this.formatPanel.Controls.Add(this.formatGroupBox2);
            this.formatPanel.Location = new System.Drawing.Point(150, 13);
            this.formatPanel.Name = "formatPanel";
            this.formatPanel.Size = new System.Drawing.Size(349, 287);
            this.formatPanel.TabIndex = 7;
            this.formatPanel.Visible = false;
            // 
            // formatGroupBox1
            // 
            this.formatGroupBox1.Controls.Add(this.backgroundColorTextBox);
            this.formatGroupBox1.Controls.Add(this.fontColorTextBox);
            this.formatGroupBox1.Controls.Add(this.backgroundButton);
            this.formatGroupBox1.Controls.Add(this.backgroundColorLabel);
            this.formatGroupBox1.Controls.Add(this.fontColorLabel);
            this.formatGroupBox1.Controls.Add(this.fontLabel1);
            this.formatGroupBox1.Controls.Add(this.fontLabel);
            this.formatGroupBox1.Controls.Add(this.fontButton);
            this.formatGroupBox1.Controls.Add(this.wordWrapCheckBox);
            this.formatGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.formatGroupBox1.Name = "formatGroupBox1";
            this.formatGroupBox1.Size = new System.Drawing.Size(346, 118);
            this.formatGroupBox1.TabIndex = 0;
            this.formatGroupBox1.TabStop = false;
            this.formatGroupBox1.Text = "Text";
            // 
            // backgroundColorTextBox
            // 
            this.backgroundColorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundColorTextBox.Enabled = false;
            this.backgroundColorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorTextBox.Location = new System.Drawing.Point(89, 87);
            this.backgroundColorTextBox.Name = "backgroundColorTextBox";
            this.backgroundColorTextBox.ReadOnly = true;
            this.backgroundColorTextBox.Size = new System.Drawing.Size(52, 17);
            this.backgroundColorTextBox.TabIndex = 7;
            // 
            // fontColorTextBox
            // 
            this.fontColorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fontColorTextBox.Enabled = false;
            this.fontColorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontColorTextBox.Location = new System.Drawing.Point(89, 64);
            this.fontColorTextBox.Name = "fontColorTextBox";
            this.fontColorTextBox.ReadOnly = true;
            this.fontColorTextBox.Size = new System.Drawing.Size(52, 17);
            this.fontColorTextBox.TabIndex = 5;
            // 
            // backgroundButton
            // 
            this.backgroundButton.Image = global::DtPad.ToolbarResource.color;
            this.backgroundButton.Location = new System.Drawing.Point(306, 86);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(30, 23);
            this.backgroundButton.TabIndex = 8;
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.AutoSize = true;
            this.backgroundColorLabel.Location = new System.Drawing.Point(10, 89);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(68, 13);
            this.backgroundColorLabel.TabIndex = 6;
            this.backgroundColorLabel.Text = "Background:";
            // 
            // fontColorLabel
            // 
            this.fontColorLabel.AutoSize = true;
            this.fontColorLabel.Location = new System.Drawing.Point(10, 66);
            this.fontColorLabel.Name = "fontColorLabel";
            this.fontColorLabel.Size = new System.Drawing.Size(34, 13);
            this.fontColorLabel.TabIndex = 4;
            this.fontColorLabel.Text = "Color:";
            // 
            // fontLabel1
            // 
            this.fontLabel1.AutoSize = true;
            this.fontLabel1.Location = new System.Drawing.Point(40, 43);
            this.fontLabel1.Name = "fontLabel1";
            this.fontLabel1.Size = new System.Drawing.Size(57, 13);
            this.fontLabel1.TabIndex = 2;
            this.fontLabel1.Text = "fontLabel1";
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(10, 43);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(31, 13);
            this.fontLabel.TabIndex = 1;
            this.fontLabel.Text = "Font:";
            // 
            // fontButton
            // 
            this.fontButton.Image = global::DtPad.ToolbarResource.font;
            this.fontButton.Location = new System.Drawing.Point(306, 39);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(30, 23);
            this.fontButton.TabIndex = 3;
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // wordWrapCheckBox
            // 
            this.wordWrapCheckBox.AutoSize = true;
            this.wordWrapCheckBox.Location = new System.Drawing.Point(10, 20);
            this.wordWrapCheckBox.Name = "wordWrapCheckBox";
            this.wordWrapCheckBox.Size = new System.Drawing.Size(78, 17);
            this.wordWrapCheckBox.TabIndex = 0;
            this.wordWrapCheckBox.Text = "Word wrap";
            this.wordWrapCheckBox.UseVisualStyleBackColor = true;
            // 
            // formatGroupBox2
            // 
            this.formatGroupBox2.Controls.Add(this.keepBulletListOnReturnLabel2);
            this.formatGroupBox2.Controls.Add(this.keepBulletListOnReturnLabel);
            this.formatGroupBox2.Controls.Add(this.urlsCheckBox);
            this.formatGroupBox2.Controls.Add(this.keepBulletListOnReturnCheckBox);
            this.formatGroupBox2.Controls.Add(this.useSpacesInsteadTabsCheckBox);
            this.formatGroupBox2.Controls.Add(this.keepInitialSpacesOnReturnCheckBox);
            this.formatGroupBox2.Location = new System.Drawing.Point(3, 127);
            this.formatGroupBox2.Name = "formatGroupBox2";
            this.formatGroupBox2.Size = new System.Drawing.Size(346, 133);
            this.formatGroupBox2.TabIndex = 1;
            this.formatGroupBox2.TabStop = false;
            this.formatGroupBox2.Text = "Other";
            // 
            // keepBulletListOnReturnLabel2
            // 
            this.keepBulletListOnReturnLabel2.AutoSize = true;
            this.keepBulletListOnReturnLabel2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keepBulletListOnReturnLabel2.Location = new System.Drawing.Point(147, 111);
            this.keepBulletListOnReturnLabel2.Name = "keepBulletListOnReturnLabel2";
            this.keepBulletListOnReturnLabel2.Size = new System.Drawing.Size(182, 14);
            this.keepBulletListOnReturnLabel2.TabIndex = 5;
            this.keepBulletListOnReturnLabel2.Text = "\'1) \', \'1. \', \'1- \', \'- \'";
            // 
            // keepBulletListOnReturnLabel
            // 
            this.keepBulletListOnReturnLabel.AutoSize = true;
            this.keepBulletListOnReturnLabel.Location = new System.Drawing.Point(28, 111);
            this.keepBulletListOnReturnLabel.Name = "keepBulletListOnReturnLabel";
            this.keepBulletListOnReturnLabel.Size = new System.Drawing.Size(110, 13);
            this.keepBulletListOnReturnLabel.TabIndex = 4;
            this.keepBulletListOnReturnLabel.Text = "Allowed list templates:";
            // 
            // urlsCheckBox
            // 
            this.urlsCheckBox.AutoSize = true;
            this.urlsCheckBox.Location = new System.Drawing.Point(10, 20);
            this.urlsCheckBox.Name = "urlsCheckBox";
            this.urlsCheckBox.Size = new System.Drawing.Size(97, 17);
            this.urlsCheckBox.TabIndex = 0;
            this.urlsCheckBox.Text = "Highlight URLs";
            this.urlsCheckBox.UseVisualStyleBackColor = true;
            // 
            // keepBulletListOnReturnCheckBox
            // 
            this.keepBulletListOnReturnCheckBox.AutoSize = true;
            this.keepBulletListOnReturnCheckBox.Location = new System.Drawing.Point(10, 89);
            this.keepBulletListOnReturnCheckBox.Name = "keepBulletListOnReturnCheckBox";
            this.keepBulletListOnReturnCheckBox.Size = new System.Drawing.Size(144, 17);
            this.keepBulletListOnReturnCheckBox.TabIndex = 3;
            this.keepBulletListOnReturnCheckBox.Text = "Keep bullet lists on return";
            this.keepBulletListOnReturnCheckBox.UseVisualStyleBackColor = true;
            // 
            // useSpacesInsteadTabsCheckBox
            // 
            this.useSpacesInsteadTabsCheckBox.AutoSize = true;
            this.useSpacesInsteadTabsCheckBox.Location = new System.Drawing.Point(10, 43);
            this.useSpacesInsteadTabsCheckBox.Name = "useSpacesInsteadTabsCheckBox";
            this.useSpacesInsteadTabsCheckBox.Size = new System.Drawing.Size(154, 17);
            this.useSpacesInsteadTabsCheckBox.TabIndex = 1;
            this.useSpacesInsteadTabsCheckBox.Text = "Use spaces instead of tabs";
            this.useSpacesInsteadTabsCheckBox.UseVisualStyleBackColor = true;
            // 
            // keepInitialSpacesOnReturnCheckBox
            // 
            this.keepInitialSpacesOnReturnCheckBox.AutoSize = true;
            this.keepInitialSpacesOnReturnCheckBox.Location = new System.Drawing.Point(10, 66);
            this.keepInitialSpacesOnReturnCheckBox.Name = "keepInitialSpacesOnReturnCheckBox";
            this.keepInitialSpacesOnReturnCheckBox.Size = new System.Drawing.Size(221, 17);
            this.keepInitialSpacesOnReturnCheckBox.TabIndex = 2;
            this.keepInitialSpacesOnReturnCheckBox.Text = "Keep initial previous line spaces on return";
            this.keepInitialSpacesOnReturnCheckBox.UseVisualStyleBackColor = true;
            // 
            // languageGroupBox1
            // 
            this.languageGroupBox1.Controls.Add(this.languageComboBox);
            this.languageGroupBox1.Controls.Add(this.languageLabel);
            this.languageGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.languageGroupBox1.Name = "languageGroupBox1";
            this.languageGroupBox1.Size = new System.Drawing.Size(346, 47);
            this.languageGroupBox1.TabIndex = 0;
            this.languageGroupBox1.TabStop = false;
            this.languageGroupBox1.Text = "DtPad";
            // 
            // languageComboBox
            // 
            this.languageComboBox.EditValue = "English";
            this.languageComboBox.Location = new System.Drawing.Point(89, 17);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, global::DtPad.Languages.it.SearchPattern_historyComboBoxItems, 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, global::DtPad.Languages.it.SearchPattern_historyComboBoxItems, null, null, false)});
            this.languageComboBox.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("English", "English", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Italiano", "Italiano", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Français", "Français", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Español", "Español", 3)});
            this.languageComboBox.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.languageComboBox.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.languageComboBox.Properties.SmallImages = this.languageImageList;
            this.languageComboBox.Size = new System.Drawing.Size(194, 20);
            this.languageComboBox.TabIndex = 1;
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
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(10, 20);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(58, 13);
            this.languageLabel.TabIndex = 0;
            this.languageLabel.Text = "Language:";
            // 
            // viewPanel
            // 
            this.viewPanel.Controls.Add(this.viewGroupBox1);
            this.viewPanel.Controls.Add(this.viewGroupBox2);
            this.viewPanel.Controls.Add(this.viewGroupBox3);
            this.viewPanel.Location = new System.Drawing.Point(150, 13);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(349, 287);
            this.viewPanel.TabIndex = 10;
            this.viewPanel.Visible = false;
            // 
            // viewGroupBox1
            // 
            this.viewGroupBox1.Controls.Add(this.splashScreenCheckBox);
            this.viewGroupBox1.Controls.Add(this.minimizeOnTrayIconCheckBox);
            this.viewGroupBox1.Controls.Add(this.stayOnTopCheckBox);
            this.viewGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.viewGroupBox1.Name = "viewGroupBox1";
            this.viewGroupBox1.Size = new System.Drawing.Size(346, 90);
            this.viewGroupBox1.TabIndex = 0;
            this.viewGroupBox1.TabStop = false;
            this.viewGroupBox1.Text = "Window";
            // 
            // splashScreenCheckBox
            // 
            this.splashScreenCheckBox.AutoSize = true;
            this.splashScreenCheckBox.Location = new System.Drawing.Point(10, 66);
            this.splashScreenCheckBox.Name = "splashScreenCheckBox";
            this.splashScreenCheckBox.Size = new System.Drawing.Size(176, 17);
            this.splashScreenCheckBox.TabIndex = 2;
            this.splashScreenCheckBox.Text = "Splash screen on DtPad startup";
            this.splashScreenCheckBox.UseVisualStyleBackColor = true;
            // 
            // minimizeOnTrayIconCheckBox
            // 
            this.minimizeOnTrayIconCheckBox.AutoSize = true;
            this.minimizeOnTrayIconCheckBox.Location = new System.Drawing.Point(10, 43);
            this.minimizeOnTrayIconCheckBox.Name = "minimizeOnTrayIconCheckBox";
            this.minimizeOnTrayIconCheckBox.Size = new System.Drawing.Size(124, 17);
            this.minimizeOnTrayIconCheckBox.TabIndex = 1;
            this.minimizeOnTrayIconCheckBox.Text = "Minimize on tray icon";
            this.minimizeOnTrayIconCheckBox.UseVisualStyleBackColor = true;
            // 
            // stayOnTopCheckBox
            // 
            this.stayOnTopCheckBox.AutoSize = true;
            this.stayOnTopCheckBox.Location = new System.Drawing.Point(10, 20);
            this.stayOnTopCheckBox.Name = "stayOnTopCheckBox";
            this.stayOnTopCheckBox.Size = new System.Drawing.Size(80, 17);
            this.stayOnTopCheckBox.TabIndex = 0;
            this.stayOnTopCheckBox.Text = "Stay on top";
            this.stayOnTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewGroupBox2
            // 
            this.viewGroupBox2.Controls.Add(this.statusBarCheckBox);
            this.viewGroupBox2.Controls.Add(this.toolbarCheckBox);
            this.viewGroupBox2.Location = new System.Drawing.Point(3, 99);
            this.viewGroupBox2.Name = "viewGroupBox2";
            this.viewGroupBox2.Size = new System.Drawing.Size(346, 67);
            this.viewGroupBox2.TabIndex = 1;
            this.viewGroupBox2.TabStop = false;
            this.viewGroupBox2.Text = "Bars";
            // 
            // statusBarCheckBox
            // 
            this.statusBarCheckBox.AutoSize = true;
            this.statusBarCheckBox.Location = new System.Drawing.Point(10, 43);
            this.statusBarCheckBox.Name = "statusBarCheckBox";
            this.statusBarCheckBox.Size = new System.Drawing.Size(74, 17);
            this.statusBarCheckBox.TabIndex = 1;
            this.statusBarCheckBox.Text = "Status bar";
            this.statusBarCheckBox.UseVisualStyleBackColor = true;
            // 
            // toolbarCheckBox
            // 
            this.toolbarCheckBox.AutoSize = true;
            this.toolbarCheckBox.Location = new System.Drawing.Point(10, 20);
            this.toolbarCheckBox.Name = "toolbarCheckBox";
            this.toolbarCheckBox.Size = new System.Drawing.Size(62, 17);
            this.toolbarCheckBox.TabIndex = 0;
            this.toolbarCheckBox.Text = "Toolbar";
            this.toolbarCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewGroupBox3
            // 
            this.viewGroupBox3.Controls.Add(this.hideLinesNumericUpDown);
            this.viewGroupBox3.Controls.Add(this.helpHideLinesPictureBox);
            this.viewGroupBox3.Controls.Add(this.hideLinesCheckBox);
            this.viewGroupBox3.Controls.Add(this.lineNumbersCheckBox);
            this.viewGroupBox3.Controls.Add(this.internalExplorerCheckBox);
            this.viewGroupBox3.Location = new System.Drawing.Point(3, 172);
            this.viewGroupBox3.Name = "viewGroupBox3";
            this.viewGroupBox3.Size = new System.Drawing.Size(346, 72);
            this.viewGroupBox3.TabIndex = 2;
            this.viewGroupBox3.TabStop = false;
            this.viewGroupBox3.Text = "Other";
            // 
            // hideLinesNumericUpDown
            // 
            this.hideLinesNumericUpDown.CustomContextMenuStrip = this.numberContextMenuStrip;
            this.hideLinesNumericUpDown.Location = new System.Drawing.Point(284, 42);
            this.hideLinesNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.hideLinesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hideLinesNumericUpDown.Name = "hideLinesNumericUpDown";
            this.hideLinesNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.hideLinesNumericUpDown.TabIndex = 3;
            this.hideLinesNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // helpHideLinesPictureBox
            // 
            this.helpHideLinesPictureBox.Image = global::DtPad.ToolbarResource.info_blue;
            this.helpHideLinesPictureBox.Location = new System.Drawing.Point(262, 44);
            this.helpHideLinesPictureBox.Name = "helpHideLinesPictureBox";
            this.helpHideLinesPictureBox.Size = new System.Drawing.Size(16, 16);
            this.helpHideLinesPictureBox.TabIndex = 10;
            this.helpHideLinesPictureBox.TabStop = false;
            this.optionsToolTip.SetToolTip(this.helpHideLinesPictureBox, "It is strongly recommended to let property below\r\nenabled to avoid long opening o" +
        "f large files.");
            // 
            // hideLinesCheckBox
            // 
            this.hideLinesCheckBox.AutoSize = true;
            this.hideLinesCheckBox.Location = new System.Drawing.Point(10, 43);
            this.hideLinesCheckBox.Name = "hideLinesCheckBox";
            this.hideLinesCheckBox.Size = new System.Drawing.Size(194, 17);
            this.hideLinesCheckBox.TabIndex = 2;
            this.hideLinesCheckBox.Text = "Hide line numers if text exceed lines";
            this.hideLinesCheckBox.UseVisualStyleBackColor = true;
            this.hideLinesCheckBox.CheckedChanged += new System.EventHandler(this.hideLinesCheckBox_CheckedChanged);
            // 
            // lineNumbersCheckBox
            // 
            this.lineNumbersCheckBox.AutoSize = true;
            this.lineNumbersCheckBox.Location = new System.Drawing.Point(153, 20);
            this.lineNumbersCheckBox.Name = "lineNumbersCheckBox";
            this.lineNumbersCheckBox.Size = new System.Drawing.Size(91, 17);
            this.lineNumbersCheckBox.TabIndex = 1;
            this.lineNumbersCheckBox.Text = "Row numbers";
            this.lineNumbersCheckBox.UseVisualStyleBackColor = true;
            this.lineNumbersCheckBox.CheckedChanged += new System.EventHandler(this.lineNumbersCheckBox_CheckedChanged);
            // 
            // internalExplorerCheckBox
            // 
            this.internalExplorerCheckBox.AutoSize = true;
            this.internalExplorerCheckBox.Location = new System.Drawing.Point(10, 20);
            this.internalExplorerCheckBox.Name = "internalExplorerCheckBox";
            this.internalExplorerCheckBox.Size = new System.Drawing.Size(102, 17);
            this.internalExplorerCheckBox.TabIndex = 0;
            this.internalExplorerCheckBox.Text = "Internal Explorer";
            this.internalExplorerCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabCloseButtonOnComboBox
            // 
            this.tabCloseButtonOnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tabCloseButtonOnComboBox.FormattingEnabled = true;
            this.tabCloseButtonOnComboBox.Items.AddRange(new object[] {
            "Right tab panel margin",
            "Each tab",
            "Active tab",
            "Do not show"});
            this.tabCloseButtonOnComboBox.Location = new System.Drawing.Point(122, 17);
            this.tabCloseButtonOnComboBox.Name = "tabCloseButtonOnComboBox";
            this.tabCloseButtonOnComboBox.Size = new System.Drawing.Size(210, 21);
            this.tabCloseButtonOnComboBox.TabIndex = 1;
            // 
            // closeTabButtonOnLabel
            // 
            this.closeTabButtonOnLabel.AutoSize = true;
            this.closeTabButtonOnLabel.Location = new System.Drawing.Point(10, 20);
            this.closeTabButtonOnLabel.Name = "closeTabButtonOnLabel";
            this.closeTabButtonOnLabel.Size = new System.Drawing.Size(84, 13);
            this.closeTabButtonOnLabel.TabIndex = 0;
            this.closeTabButtonOnLabel.Text = "Close button on:";
            // 
            // internetPanel
            // 
            this.internetPanel.Controls.Add(this.internetGroupBox1);
            this.internetPanel.Controls.Add(this.internetGroupBox2);
            this.internetPanel.Location = new System.Drawing.Point(150, 13);
            this.internetPanel.Name = "internetPanel";
            this.internetPanel.Size = new System.Drawing.Size(349, 287);
            this.internetPanel.TabIndex = 12;
            this.internetPanel.Visible = false;
            // 
            // internetGroupBox1
            // 
            this.internetGroupBox1.Controls.Add(this.proxyPortNumericUpDown);
            this.internetGroupBox1.Controls.Add(this.proxyHostTextBox);
            this.internetGroupBox1.Controls.Add(this.proxyPortLabel);
            this.internetGroupBox1.Controls.Add(this.proxyHostLabel);
            this.internetGroupBox1.Controls.Add(this.checkConnectionButton);
            this.internetGroupBox1.Controls.Add(this.infoProxyPictureBox);
            this.internetGroupBox1.Controls.Add(this.statusPictureBox);
            this.internetGroupBox1.Controls.Add(this.domainTextBox);
            this.internetGroupBox1.Controls.Add(this.passwordTextBox);
            this.internetGroupBox1.Controls.Add(this.usernameTextBox);
            this.internetGroupBox1.Controls.Add(this.domainLabel);
            this.internetGroupBox1.Controls.Add(this.passwordLabel);
            this.internetGroupBox1.Controls.Add(this.usernameLabel);
            this.internetGroupBox1.Controls.Add(this.statusLabel);
            this.internetGroupBox1.Controls.Add(this.enableProxySettingsCheckBox);
            this.internetGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.internetGroupBox1.Name = "internetGroupBox1";
            this.internetGroupBox1.Size = new System.Drawing.Size(346, 199);
            this.internetGroupBox1.TabIndex = 0;
            this.internetGroupBox1.TabStop = false;
            this.internetGroupBox1.Text = "Proxy";
            // 
            // proxyPortNumericUpDown
            // 
            this.proxyPortNumericUpDown.CustomContextMenuStrip = this.numberContextMenuStrip;
            this.proxyPortNumericUpDown.Location = new System.Drawing.Point(74, 170);
            this.proxyPortNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.proxyPortNumericUpDown.Name = "proxyPortNumericUpDown";
            this.proxyPortNumericUpDown.Size = new System.Drawing.Size(77, 20);
            this.proxyPortNumericUpDown.TabIndex = 12;
            // 
            // proxyHostTextBox
            // 
            this.proxyHostTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.proxyHostTextBox.Location = new System.Drawing.Point(74, 146);
            this.proxyHostTextBox.Name = "proxyHostTextBox";
            this.proxyHostTextBox.Size = new System.Drawing.Size(258, 20);
            this.proxyHostTextBox.TabIndex = 10;
            // 
            // contentContextMenuStrip
            // 
            this.contentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator29,
            this.selectAllToolStripMenuItem});
            this.contentContextMenuStrip.Name = "searchContextMenuStrip";
            this.contentContextMenuStrip.Size = new System.Drawing.Size(123, 148);
            this.contentContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contentContextMenuStrip_Opening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::DtPad.ToolbarResource.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::DtPad.ToolbarResource.paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(119, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.selectAllToolStripMenuItem_Click);
            // 
            // proxyPortLabel
            // 
            this.proxyPortLabel.AutoSize = true;
            this.proxyPortLabel.Location = new System.Drawing.Point(10, 172);
            this.proxyPortLabel.Name = "proxyPortLabel";
            this.proxyPortLabel.Size = new System.Drawing.Size(29, 13);
            this.proxyPortLabel.TabIndex = 11;
            this.proxyPortLabel.Text = "Port:";
            // 
            // proxyHostLabel
            // 
            this.proxyHostLabel.AutoSize = true;
            this.proxyHostLabel.Location = new System.Drawing.Point(10, 149);
            this.proxyHostLabel.Name = "proxyHostLabel";
            this.proxyHostLabel.Size = new System.Drawing.Size(48, 13);
            this.proxyHostLabel.TabIndex = 9;
            this.proxyHostLabel.Text = "Address:";
            // 
            // checkConnectionButton
            // 
            this.checkConnectionButton.Location = new System.Drawing.Point(273, 112);
            this.checkConnectionButton.Name = "checkConnectionButton";
            this.checkConnectionButton.Size = new System.Drawing.Size(60, 23);
            this.checkConnectionButton.TabIndex = 8;
            this.checkConnectionButton.Text = "Verify";
            this.checkConnectionButton.UseVisualStyleBackColor = true;
            this.checkConnectionButton.Click += new System.EventHandler(this.checkConnectionButton_Click);
            // 
            // infoProxyPictureBox
            // 
            this.infoProxyPictureBox.Image = global::DtPad.ToolbarResource.info_blue;
            this.infoProxyPictureBox.Location = new System.Drawing.Point(248, 19);
            this.infoProxyPictureBox.Name = "infoProxyPictureBox";
            this.infoProxyPictureBox.Size = new System.Drawing.Size(16, 16);
            this.infoProxyPictureBox.TabIndex = 9;
            this.infoProxyPictureBox.TabStop = false;
            this.optionsToolTip.SetToolTip(this.infoProxyPictureBox, "DtPad uses Internet Explorer\'s settings to connect. Insert following\r\nfields just" +
        " in case it requires a manual authentication.");
            // 
            // statusPictureBox
            // 
            this.statusPictureBox.Location = new System.Drawing.Point(316, 19);
            this.statusPictureBox.Name = "statusPictureBox";
            this.statusPictureBox.Size = new System.Drawing.Size(16, 16);
            this.statusPictureBox.TabIndex = 8;
            this.statusPictureBox.TabStop = false;
            // 
            // domainTextBox
            // 
            this.domainTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.domainTextBox.Location = new System.Drawing.Point(74, 86);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.Size = new System.Drawing.Size(258, 20);
            this.domainTextBox.TabIndex = 7;
            this.domainTextBox.TextChanged += new System.EventHandler(this.domainTextBox_TextChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.passwordTextBox.Location = new System.Drawing.Point(74, 63);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(258, 20);
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.usernameTextBox.Location = new System.Drawing.Point(74, 40);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(258, 20);
            this.usernameTextBox.TabIndex = 3;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
            // 
            // domainLabel
            // 
            this.domainLabel.AutoSize = true;
            this.domainLabel.Location = new System.Drawing.Point(10, 89);
            this.domainLabel.Name = "domainLabel";
            this.domainLabel.Size = new System.Drawing.Size(46, 13);
            this.domainLabel.TabIndex = 6;
            this.domainLabel.Text = "Domain:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(10, 66);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(10, 43);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Username:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(270, 21);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Status:";
            // 
            // enableProxySettingsCheckBox
            // 
            this.enableProxySettingsCheckBox.AutoSize = true;
            this.enableProxySettingsCheckBox.Location = new System.Drawing.Point(10, 20);
            this.enableProxySettingsCheckBox.Name = "enableProxySettingsCheckBox";
            this.enableProxySettingsCheckBox.Size = new System.Drawing.Size(126, 17);
            this.enableProxySettingsCheckBox.TabIndex = 0;
            this.enableProxySettingsCheckBox.Text = "Enable proxy settings";
            this.enableProxySettingsCheckBox.UseVisualStyleBackColor = true;
            this.enableProxySettingsCheckBox.CheckedChanged += new System.EventHandler(this.enableProxySettingsCheckBox_CheckedChanged);
            // 
            // internetGroupBox2
            // 
            this.internetGroupBox2.Controls.Add(this.customBrowserButton);
            this.internetGroupBox2.Controls.Add(this.customBrowserTextBox);
            this.internetGroupBox2.Controls.Add(this.customBrowserRadioButton);
            this.internetGroupBox2.Controls.Add(this.defaultBrowserRadioButton);
            this.internetGroupBox2.Location = new System.Drawing.Point(3, 208);
            this.internetGroupBox2.Name = "internetGroupBox2";
            this.internetGroupBox2.Size = new System.Drawing.Size(346, 76);
            this.internetGroupBox2.TabIndex = 1;
            this.internetGroupBox2.TabStop = false;
            this.internetGroupBox2.Text = "Browser";
            // 
            // customBrowserButton
            // 
            this.customBrowserButton.Enabled = false;
            this.customBrowserButton.Location = new System.Drawing.Point(303, 42);
            this.customBrowserButton.Name = "customBrowserButton";
            this.customBrowserButton.Size = new System.Drawing.Size(30, 23);
            this.customBrowserButton.TabIndex = 3;
            this.customBrowserButton.Text = "...";
            this.customBrowserButton.UseVisualStyleBackColor = true;
            this.customBrowserButton.Click += new System.EventHandler(this.customBrowserButton_Click);
            // 
            // customBrowserTextBox
            // 
            this.customBrowserTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.customBrowserTextBox.Enabled = false;
            this.customBrowserTextBox.Location = new System.Drawing.Point(10, 44);
            this.customBrowserTextBox.Name = "customBrowserTextBox";
            this.customBrowserTextBox.Size = new System.Drawing.Size(287, 20);
            this.customBrowserTextBox.TabIndex = 2;
            // 
            // customBrowserRadioButton
            // 
            this.customBrowserRadioButton.AutoSize = true;
            this.customBrowserRadioButton.Location = new System.Drawing.Point(170, 20);
            this.customBrowserRadioButton.Name = "customBrowserRadioButton";
            this.customBrowserRadioButton.Size = new System.Drawing.Size(137, 17);
            this.customBrowserRadioButton.TabIndex = 1;
            this.customBrowserRadioButton.Text = "Use following command";
            this.customBrowserRadioButton.UseVisualStyleBackColor = true;
            // 
            // defaultBrowserRadioButton
            // 
            this.defaultBrowserRadioButton.AutoSize = true;
            this.defaultBrowserRadioButton.Checked = true;
            this.defaultBrowserRadioButton.Location = new System.Drawing.Point(10, 20);
            this.defaultBrowserRadioButton.Name = "defaultBrowserRadioButton";
            this.defaultBrowserRadioButton.Size = new System.Drawing.Size(119, 17);
            this.defaultBrowserRadioButton.TabIndex = 0;
            this.defaultBrowserRadioButton.TabStop = true;
            this.defaultBrowserRadioButton.Text = "Use default browser";
            this.defaultBrowserRadioButton.UseVisualStyleBackColor = true;
            this.defaultBrowserRadioButton.CheckedChanged += new System.EventHandler(this.defaultBrowserRadioButton_CheckedChanged);
            // 
            // lookAndFeelPanel
            // 
            this.lookAndFeelPanel.Controls.Add(this.lookAndFeelGroupBox1);
            this.lookAndFeelPanel.Location = new System.Drawing.Point(150, 13);
            this.lookAndFeelPanel.Name = "lookAndFeelPanel";
            this.lookAndFeelPanel.Size = new System.Drawing.Size(349, 287);
            this.lookAndFeelPanel.TabIndex = 11;
            this.lookAndFeelPanel.Visible = false;
            // 
            // lookAndFeelGroupBox1
            // 
            this.lookAndFeelGroupBox1.Controls.Add(this.renderPictureBox);
            this.lookAndFeelGroupBox1.Controls.Add(this.renderModeComboBox);
            this.lookAndFeelGroupBox1.Controls.Add(this.renderModeLabel);
            this.lookAndFeelGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.lookAndFeelGroupBox1.Name = "lookAndFeelGroupBox1";
            this.lookAndFeelGroupBox1.Size = new System.Drawing.Size(346, 284);
            this.lookAndFeelGroupBox1.TabIndex = 0;
            this.lookAndFeelGroupBox1.TabStop = false;
            this.lookAndFeelGroupBox1.Text = "Style";
            // 
            // renderPictureBox
            // 
            this.renderPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.renderPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renderPictureBox.Location = new System.Drawing.Point(13, 43);
            this.renderPictureBox.Name = "renderPictureBox";
            this.renderPictureBox.Size = new System.Drawing.Size(319, 226);
            this.renderPictureBox.TabIndex = 2;
            this.renderPictureBox.TabStop = false;
            // 
            // renderModeComboBox
            // 
            this.renderModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.renderModeComboBox.FormattingEnabled = true;
            this.renderModeComboBox.Items.AddRange(new object[] {
            "Office 2003",
            "Windows"});
            this.renderModeComboBox.Location = new System.Drawing.Point(100, 17);
            this.renderModeComboBox.Name = "renderModeComboBox";
            this.renderModeComboBox.Size = new System.Drawing.Size(232, 21);
            this.renderModeComboBox.TabIndex = 1;
            this.renderModeComboBox.SelectedIndexChanged += new System.EventHandler(this.renderModeComboBox_SelectedIndexChanged);
            // 
            // renderModeLabel
            // 
            this.renderModeLabel.AutoSize = true;
            this.renderModeLabel.Location = new System.Drawing.Point(10, 20);
            this.renderModeLabel.Name = "renderModeLabel";
            this.renderModeLabel.Size = new System.Drawing.Size(74, 13);
            this.renderModeLabel.TabIndex = 0;
            this.renderModeLabel.Text = "Render mode:";
            // 
            // filePanel
            // 
            this.filePanel.Controls.Add(this.fileGroupBox1);
            this.filePanel.Controls.Add(this.fileGroupBox2);
            this.filePanel.Location = new System.Drawing.Point(150, 13);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(349, 287);
            this.filePanel.TabIndex = 1;
            // 
            // fileGroupBox1
            // 
            this.fileGroupBox1.Controls.Add(this.folderOpenedFileCheckBox);
            this.fileGroupBox1.Controls.Add(this.specificFolderButton);
            this.fileGroupBox1.Controls.Add(this.specificFolderTextBox);
            this.fileGroupBox1.Controls.Add(this.specificFolderRadioButton);
            this.fileGroupBox1.Controls.Add(this.lastUsedFolderRadioButton);
            this.fileGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.fileGroupBox1.Name = "fileGroupBox1";
            this.fileGroupBox1.Size = new System.Drawing.Size(346, 96);
            this.fileGroupBox1.TabIndex = 0;
            this.fileGroupBox1.TabStop = false;
            this.fileGroupBox1.Text = "Initial folder";
            // 
            // folderOpenedFileCheckBox
            // 
            this.folderOpenedFileCheckBox.AutoSize = true;
            this.folderOpenedFileCheckBox.Location = new System.Drawing.Point(10, 71);
            this.folderOpenedFileCheckBox.Name = "folderOpenedFileCheckBox";
            this.folderOpenedFileCheckBox.Size = new System.Drawing.Size(206, 17);
            this.folderOpenedFileCheckBox.TabIndex = 4;
            this.folderOpenedFileCheckBox.Text = "Override setting with active file\'s folder";
            this.folderOpenedFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // specificFolderButton
            // 
            this.specificFolderButton.Enabled = false;
            this.specificFolderButton.Location = new System.Drawing.Point(303, 42);
            this.specificFolderButton.Name = "specificFolderButton";
            this.specificFolderButton.Size = new System.Drawing.Size(30, 23);
            this.specificFolderButton.TabIndex = 3;
            this.specificFolderButton.Text = "...";
            this.specificFolderButton.UseVisualStyleBackColor = true;
            this.specificFolderButton.Click += new System.EventHandler(this.specificFolderButton_Click);
            // 
            // specificFolderTextBox
            // 
            this.specificFolderTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.specificFolderTextBox.Enabled = false;
            this.specificFolderTextBox.Location = new System.Drawing.Point(10, 44);
            this.specificFolderTextBox.Name = "specificFolderTextBox";
            this.specificFolderTextBox.Size = new System.Drawing.Size(287, 20);
            this.specificFolderTextBox.TabIndex = 2;
            // 
            // specificFolderRadioButton
            // 
            this.specificFolderRadioButton.AutoSize = true;
            this.specificFolderRadioButton.Location = new System.Drawing.Point(153, 20);
            this.specificFolderRadioButton.Name = "specificFolderRadioButton";
            this.specificFolderRadioButton.Size = new System.Drawing.Size(92, 17);
            this.specificFolderRadioButton.TabIndex = 1;
            this.specificFolderRadioButton.Text = "Specific folder";
            this.specificFolderRadioButton.UseVisualStyleBackColor = true;
            // 
            // lastUsedFolderRadioButton
            // 
            this.lastUsedFolderRadioButton.AutoSize = true;
            this.lastUsedFolderRadioButton.Checked = true;
            this.lastUsedFolderRadioButton.Location = new System.Drawing.Point(10, 20);
            this.lastUsedFolderRadioButton.Name = "lastUsedFolderRadioButton";
            this.lastUsedFolderRadioButton.Size = new System.Drawing.Size(100, 17);
            this.lastUsedFolderRadioButton.TabIndex = 0;
            this.lastUsedFolderRadioButton.TabStop = true;
            this.lastUsedFolderRadioButton.Text = "Last used folder";
            this.lastUsedFolderRadioButton.UseVisualStyleBackColor = true;
            this.lastUsedFolderRadioButton.CheckedChanged += new System.EventHandler(this.lastUsedFolderRadioButton_CheckedChanged);
            // 
            // fileGroupBox2
            // 
            this.fileGroupBox2.Controls.Add(this.extensionsButton);
            this.fileGroupBox2.Controls.Add(this.extensionLabel);
            this.fileGroupBox2.Controls.Add(this.extensionListBox);
            this.fileGroupBox2.Controls.Add(this.clearRecentFilesButton);
            this.fileGroupBox2.Controls.Add(this.recentFilesNumberNumericUpDown);
            this.fileGroupBox2.Controls.Add(this.recentFilesNumberLabel);
            this.fileGroupBox2.Location = new System.Drawing.Point(3, 105);
            this.fileGroupBox2.Name = "fileGroupBox2";
            this.fileGroupBox2.Size = new System.Drawing.Size(346, 182);
            this.fileGroupBox2.TabIndex = 1;
            this.fileGroupBox2.TabStop = false;
            this.fileGroupBox2.Text = "Other";
            // 
            // extensionsButton
            // 
            this.extensionsButton.Image = global::DtPad.ToolbarResource.chart;
            this.extensionsButton.Location = new System.Drawing.Point(45, 145);
            this.extensionsButton.Name = "extensionsButton";
            this.extensionsButton.Size = new System.Drawing.Size(23, 23);
            this.extensionsButton.TabIndex = 5;
            this.optionsToolTip.SetToolTip(this.extensionsButton, "Manage file extensions");
            this.extensionsButton.UseVisualStyleBackColor = true;
            this.extensionsButton.Click += new System.EventHandler(this.extensionsButton_Click);
            // 
            // extensionLabel
            // 
            this.extensionLabel.AutoSize = true;
            this.extensionLabel.Location = new System.Drawing.Point(10, 48);
            this.extensionLabel.Name = "extensionLabel";
            this.extensionLabel.Size = new System.Drawing.Size(61, 13);
            this.extensionLabel.TabIndex = 3;
            this.extensionLabel.Text = "Extensions:";
            // 
            // extensionListBox
            // 
            this.extensionListBox.FormattingEnabled = true;
            this.extensionListBox.Location = new System.Drawing.Point(77, 47);
            this.extensionListBox.Name = "extensionListBox";
            this.extensionListBox.Size = new System.Drawing.Size(256, 121);
            this.extensionListBox.TabIndex = 4;
            // 
            // clearRecentFilesButton
            // 
            this.clearRecentFilesButton.Location = new System.Drawing.Point(273, 15);
            this.clearRecentFilesButton.Name = "clearRecentFilesButton";
            this.clearRecentFilesButton.Size = new System.Drawing.Size(60, 23);
            this.clearRecentFilesButton.TabIndex = 2;
            this.clearRecentFilesButton.Text = "Clear";
            this.clearRecentFilesButton.UseVisualStyleBackColor = true;
            this.clearRecentFilesButton.Click += new System.EventHandler(this.clearRecentFilesButton_Click);
            // 
            // recentFilesNumberNumericUpDown
            // 
            this.recentFilesNumberNumericUpDown.CustomContextMenuStrip = this.numberContextMenuStrip;
            this.recentFilesNumberNumericUpDown.Location = new System.Drawing.Point(120, 18);
            this.recentFilesNumberNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.recentFilesNumberNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentFilesNumberNumericUpDown.Name = "recentFilesNumberNumericUpDown";
            this.recentFilesNumberNumericUpDown.Size = new System.Drawing.Size(44, 20);
            this.recentFilesNumberNumericUpDown.TabIndex = 1;
            this.recentFilesNumberNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // recentFilesNumberLabel
            // 
            this.recentFilesNumberLabel.AutoSize = true;
            this.recentFilesNumberLabel.Location = new System.Drawing.Point(10, 20);
            this.recentFilesNumberLabel.Name = "recentFilesNumberLabel";
            this.recentFilesNumberLabel.Size = new System.Drawing.Size(104, 13);
            this.recentFilesNumberLabel.TabIndex = 0;
            this.recentFilesNumberLabel.Text = "Recent files number:";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select the default folder for saving and opening files:";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // okButton
            // 
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(262, 315);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "OK";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Image = global::DtPad.MessageBoxResource.ok;
            this.applyButton.Location = new System.Drawing.Point(424, 315);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 18;
            this.applyButton.Text = "Apply";
            this.applyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // encodingPanel
            // 
            this.encodingPanel.Controls.Add(this.encodingGroupBox1);
            this.encodingPanel.Location = new System.Drawing.Point(150, 13);
            this.encodingPanel.Name = "encodingPanel";
            this.encodingPanel.Size = new System.Drawing.Size(349, 287);
            this.encodingPanel.TabIndex = 2;
            this.encodingPanel.Visible = false;
            // 
            // encodingGroupBox1
            // 
            this.encodingGroupBox1.Controls.Add(this.noteLabel);
            this.encodingGroupBox1.Controls.Add(this.defaultComboBox);
            this.encodingGroupBox1.Controls.Add(this.defaultLabel);
            this.encodingGroupBox1.Controls.Add(this.useExistingCheckBox);
            this.encodingGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.encodingGroupBox1.Name = "encodingGroupBox1";
            this.encodingGroupBox1.Size = new System.Drawing.Size(346, 130);
            this.encodingGroupBox1.TabIndex = 0;
            this.encodingGroupBox1.TabStop = false;
            this.encodingGroupBox1.Text = "Encoding";
            // 
            // noteLabel
            // 
            this.noteLabel.Location = new System.Drawing.Point(10, 81);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(323, 46);
            this.noteLabel.TabIndex = 3;
            this.noteLabel.Text = "Note: UTF-8 is a standard encoding method used by a great number of applications," +
    " as much as for ASCII. In case of lack of specific needs, it\'s recommended to us" +
    "e one of this two algorithms.";
            // 
            // defaultComboBox
            // 
            this.defaultComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultComboBox.FormattingEnabled = true;
            this.defaultComboBox.Items.AddRange(new object[] {
            "ASCII",
            "UTF-8",
            "UTF-16 Big Endian",
            "UTF-32 Little Endian"});
            this.defaultComboBox.Location = new System.Drawing.Point(60, 40);
            this.defaultComboBox.Name = "defaultComboBox";
            this.defaultComboBox.Size = new System.Drawing.Size(273, 21);
            this.defaultComboBox.TabIndex = 2;
            // 
            // defaultLabel
            // 
            this.defaultLabel.AutoSize = true;
            this.defaultLabel.Location = new System.Drawing.Point(10, 43);
            this.defaultLabel.Name = "defaultLabel";
            this.defaultLabel.Size = new System.Drawing.Size(44, 13);
            this.defaultLabel.TabIndex = 1;
            this.defaultLabel.Text = "Default:";
            // 
            // useExistingCheckBox
            // 
            this.useExistingCheckBox.AutoSize = true;
            this.useExistingCheckBox.Location = new System.Drawing.Point(10, 20);
            this.useExistingCheckBox.Name = "useExistingCheckBox";
            this.useExistingCheckBox.Size = new System.Drawing.Size(158, 17);
            this.useExistingCheckBox.TabIndex = 0;
            this.useExistingCheckBox.Text = "Use existing for opened files";
            this.useExistingCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabGroupBox1);
            this.tabPanel.Location = new System.Drawing.Point(150, 13);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Size = new System.Drawing.Size(349, 287);
            this.tabPanel.TabIndex = 9;
            this.tabPanel.Visible = false;
            // 
            // tabGroupBox1
            // 
            this.tabGroupBox1.Controls.Add(this.tabMultilineCheckBox);
            this.tabGroupBox1.Controls.Add(this.tabOrientationComboBox);
            this.tabGroupBox1.Controls.Add(this.tabOrientationLabel);
            this.tabGroupBox1.Controls.Add(this.tabPositionComboBox);
            this.tabGroupBox1.Controls.Add(this.tabPositionLabel);
            this.tabGroupBox1.Controls.Add(this.closeTabButtonOnLabel);
            this.tabGroupBox1.Controls.Add(this.tabCloseButtonOnComboBox);
            this.tabGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.tabGroupBox1.Name = "tabGroupBox1";
            this.tabGroupBox1.Size = new System.Drawing.Size(346, 116);
            this.tabGroupBox1.TabIndex = 0;
            this.tabGroupBox1.TabStop = false;
            this.tabGroupBox1.Text = "Settings";
            // 
            // tabMultilineCheckBox
            // 
            this.tabMultilineCheckBox.AutoSize = true;
            this.tabMultilineCheckBox.Location = new System.Drawing.Point(10, 92);
            this.tabMultilineCheckBox.Name = "tabMultilineCheckBox";
            this.tabMultilineCheckBox.Size = new System.Drawing.Size(112, 17);
            this.tabMultilineCheckBox.TabIndex = 6;
            this.tabMultilineCheckBox.Text = "Multiline alignment";
            this.tabMultilineCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabOrientationComboBox
            // 
            this.tabOrientationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tabOrientationComboBox.FormattingEnabled = true;
            this.tabOrientationComboBox.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
            this.tabOrientationComboBox.Location = new System.Drawing.Point(122, 64);
            this.tabOrientationComboBox.Name = "tabOrientationComboBox";
            this.tabOrientationComboBox.Size = new System.Drawing.Size(210, 21);
            this.tabOrientationComboBox.TabIndex = 5;
            // 
            // tabOrientationLabel
            // 
            this.tabOrientationLabel.AutoSize = true;
            this.tabOrientationLabel.Location = new System.Drawing.Point(10, 66);
            this.tabOrientationLabel.Name = "tabOrientationLabel";
            this.tabOrientationLabel.Size = new System.Drawing.Size(81, 13);
            this.tabOrientationLabel.TabIndex = 4;
            this.tabOrientationLabel.Text = "Tab orientation:";
            // 
            // tabPositionComboBox
            // 
            this.tabPositionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tabPositionComboBox.FormattingEnabled = true;
            this.tabPositionComboBox.Items.AddRange(new object[] {
            "Top (default)",
            "Right",
            "Bottom",
            "Left"});
            this.tabPositionComboBox.Location = new System.Drawing.Point(122, 41);
            this.tabPositionComboBox.Name = "tabPositionComboBox";
            this.tabPositionComboBox.Size = new System.Drawing.Size(210, 21);
            this.tabPositionComboBox.TabIndex = 3;
            // 
            // tabPositionLabel
            // 
            this.tabPositionLabel.AutoSize = true;
            this.tabPositionLabel.Location = new System.Drawing.Point(10, 43);
            this.tabPositionLabel.Name = "tabPositionLabel";
            this.tabPositionLabel.Size = new System.Drawing.Size(68, 13);
            this.tabPositionLabel.TabIndex = 2;
            this.tabPositionLabel.Text = "Tab position:";
            // 
            // savingPanel
            // 
            this.savingPanel.Controls.Add(this.savingGroupBox1);
            this.savingPanel.Controls.Add(this.backupGroupBox2);
            this.savingPanel.Location = new System.Drawing.Point(150, 13);
            this.savingPanel.Name = "savingPanel";
            this.savingPanel.Size = new System.Drawing.Size(349, 287);
            this.savingPanel.TabIndex = 4;
            this.savingPanel.Visible = false;
            // 
            // savingGroupBox1
            // 
            this.savingGroupBox1.Controls.Add(this.backupIncrementalCheckBox);
            this.savingGroupBox1.Controls.Add(this.backupReplaceExtensionRadioButton);
            this.savingGroupBox1.Controls.Add(this.backupAddExtensionRadioButton);
            this.savingGroupBox1.Controls.Add(this.backupExtensionTextBox);
            this.savingGroupBox1.Controls.Add(this.backupExtensionLabel);
            this.savingGroupBox1.Controls.Add(this.createBackupCheckBox);
            this.savingGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.savingGroupBox1.Name = "savingGroupBox1";
            this.savingGroupBox1.Size = new System.Drawing.Size(346, 137);
            this.savingGroupBox1.TabIndex = 0;
            this.savingGroupBox1.TabStop = false;
            this.savingGroupBox1.Text = "Backup";
            // 
            // backupIncrementalCheckBox
            // 
            this.backupIncrementalCheckBox.AutoSize = true;
            this.backupIncrementalCheckBox.Location = new System.Drawing.Point(10, 112);
            this.backupIncrementalCheckBox.Name = "backupIncrementalCheckBox";
            this.backupIncrementalCheckBox.Size = new System.Drawing.Size(225, 17);
            this.backupIncrementalCheckBox.TabIndex = 5;
            this.backupIncrementalCheckBox.Text = "Incremental numbering (ie. bak0, bak1, ...)";
            this.backupIncrementalCheckBox.UseVisualStyleBackColor = true;
            // 
            // backupReplaceExtensionRadioButton
            // 
            this.backupReplaceExtensionRadioButton.AutoSize = true;
            this.backupReplaceExtensionRadioButton.Location = new System.Drawing.Point(10, 89);
            this.backupReplaceExtensionRadioButton.Name = "backupReplaceExtensionRadioButton";
            this.backupReplaceExtensionRadioButton.Size = new System.Drawing.Size(211, 17);
            this.backupReplaceExtensionRadioButton.TabIndex = 4;
            this.backupReplaceExtensionRadioButton.Text = "Replace file extension with backup one";
            this.backupReplaceExtensionRadioButton.UseVisualStyleBackColor = true;
            // 
            // backupAddExtensionRadioButton
            // 
            this.backupAddExtensionRadioButton.AutoSize = true;
            this.backupAddExtensionRadioButton.Checked = true;
            this.backupAddExtensionRadioButton.Location = new System.Drawing.Point(10, 66);
            this.backupAddExtensionRadioButton.Name = "backupAddExtensionRadioButton";
            this.backupAddExtensionRadioButton.Size = new System.Drawing.Size(146, 17);
            this.backupAddExtensionRadioButton.TabIndex = 3;
            this.backupAddExtensionRadioButton.TabStop = true;
            this.backupAddExtensionRadioButton.Text = "Add extension to filename";
            this.backupAddExtensionRadioButton.UseVisualStyleBackColor = true;
            // 
            // backupExtensionTextBox
            // 
            this.backupExtensionTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.backupExtensionTextBox.Location = new System.Drawing.Point(77, 40);
            this.backupExtensionTextBox.Name = "backupExtensionTextBox";
            this.backupExtensionTextBox.Size = new System.Drawing.Size(154, 20);
            this.backupExtensionTextBox.TabIndex = 2;
            // 
            // backupExtensionLabel
            // 
            this.backupExtensionLabel.AutoSize = true;
            this.backupExtensionLabel.Location = new System.Drawing.Point(10, 43);
            this.backupExtensionLabel.Name = "backupExtensionLabel";
            this.backupExtensionLabel.Size = new System.Drawing.Size(56, 13);
            this.backupExtensionLabel.TabIndex = 1;
            this.backupExtensionLabel.Text = "Extension:";
            // 
            // createBackupCheckBox
            // 
            this.createBackupCheckBox.AutoSize = true;
            this.createBackupCheckBox.Location = new System.Drawing.Point(10, 20);
            this.createBackupCheckBox.Name = "createBackupCheckBox";
            this.createBackupCheckBox.Size = new System.Drawing.Size(175, 17);
            this.createBackupCheckBox.TabIndex = 0;
            this.createBackupCheckBox.Text = "Create backup file when saving";
            this.createBackupCheckBox.UseVisualStyleBackColor = true;
            // 
            // backupGroupBox2
            // 
            this.backupGroupBox2.Controls.Add(this.backupCustomFolderTextBox);
            this.backupGroupBox2.Controls.Add(this.backupCustomFolderRadioButton);
            this.backupGroupBox2.Controls.Add(this.backupCustomFolderButton);
            this.backupGroupBox2.Controls.Add(this.backupEditedFileRadioButton);
            this.backupGroupBox2.Location = new System.Drawing.Point(3, 146);
            this.backupGroupBox2.Name = "backupGroupBox2";
            this.backupGroupBox2.Size = new System.Drawing.Size(346, 74);
            this.backupGroupBox2.TabIndex = 1;
            this.backupGroupBox2.TabStop = false;
            this.backupGroupBox2.Text = "Location";
            // 
            // backupCustomFolderTextBox
            // 
            this.backupCustomFolderTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.backupCustomFolderTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.backupCustomFolderTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.backupCustomFolderTextBox.Enabled = false;
            this.backupCustomFolderTextBox.Location = new System.Drawing.Point(10, 43);
            this.backupCustomFolderTextBox.Name = "backupCustomFolderTextBox";
            this.backupCustomFolderTextBox.Size = new System.Drawing.Size(287, 20);
            this.backupCustomFolderTextBox.TabIndex = 2;
            // 
            // backupCustomFolderRadioButton
            // 
            this.backupCustomFolderRadioButton.AutoSize = true;
            this.backupCustomFolderRadioButton.Location = new System.Drawing.Point(155, 20);
            this.backupCustomFolderRadioButton.Name = "backupCustomFolderRadioButton";
            this.backupCustomFolderRadioButton.Size = new System.Drawing.Size(89, 17);
            this.backupCustomFolderRadioButton.TabIndex = 1;
            this.backupCustomFolderRadioButton.Text = "Custom folder";
            this.backupCustomFolderRadioButton.UseVisualStyleBackColor = true;
            this.backupCustomFolderRadioButton.CheckedChanged += new System.EventHandler(this.backupCustomFolderRadioButton_CheckedChanged);
            // 
            // backupCustomFolderButton
            // 
            this.backupCustomFolderButton.Enabled = false;
            this.backupCustomFolderButton.Location = new System.Drawing.Point(306, 41);
            this.backupCustomFolderButton.Name = "backupCustomFolderButton";
            this.backupCustomFolderButton.Size = new System.Drawing.Size(30, 23);
            this.backupCustomFolderButton.TabIndex = 3;
            this.backupCustomFolderButton.Text = "...";
            this.backupCustomFolderButton.UseVisualStyleBackColor = true;
            this.backupCustomFolderButton.Click += new System.EventHandler(this.backupCustomFolderButton_Click);
            // 
            // backupEditedFileRadioButton
            // 
            this.backupEditedFileRadioButton.AutoSize = true;
            this.backupEditedFileRadioButton.Checked = true;
            this.backupEditedFileRadioButton.Location = new System.Drawing.Point(10, 20);
            this.backupEditedFileRadioButton.Name = "backupEditedFileRadioButton";
            this.backupEditedFileRadioButton.Size = new System.Drawing.Size(100, 17);
            this.backupEditedFileRadioButton.TabIndex = 0;
            this.backupEditedFileRadioButton.TabStop = true;
            this.backupEditedFileRadioButton.Text = "Edited file folder";
            this.backupEditedFileRadioButton.UseVisualStyleBackColor = true;
            // 
            // sessionPanel
            // 
            this.sessionPanel.Controls.Add(this.sessionGroupBox1);
            this.sessionPanel.Location = new System.Drawing.Point(150, 13);
            this.sessionPanel.Name = "sessionPanel";
            this.sessionPanel.Size = new System.Drawing.Size(349, 287);
            this.sessionPanel.TabIndex = 5;
            this.sessionPanel.Visible = false;
            // 
            // sessionGroupBox1
            // 
            this.sessionGroupBox1.Controls.Add(this.automaticSessionSaveCheckBox);
            this.sessionGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.sessionGroupBox1.Name = "sessionGroupBox1";
            this.sessionGroupBox1.Size = new System.Drawing.Size(346, 45);
            this.sessionGroupBox1.TabIndex = 0;
            this.sessionGroupBox1.TabStop = false;
            this.sessionGroupBox1.Text = "Settings";
            // 
            // automaticSessionSaveCheckBox
            // 
            this.automaticSessionSaveCheckBox.AutoSize = true;
            this.automaticSessionSaveCheckBox.Location = new System.Drawing.Point(10, 20);
            this.automaticSessionSaveCheckBox.Name = "automaticSessionSaveCheckBox";
            this.automaticSessionSaveCheckBox.Size = new System.Drawing.Size(242, 17);
            this.automaticSessionSaveCheckBox.TabIndex = 0;
            this.automaticSessionSaveCheckBox.Text = "Automatically save opened session on closing";
            this.automaticSessionSaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // languagePanel
            // 
            this.languagePanel.Controls.Add(this.languageGroupBox1);
            this.languagePanel.Controls.Add(this.languageGroupBox2);
            this.languagePanel.Location = new System.Drawing.Point(150, 13);
            this.languagePanel.Name = "languagePanel";
            this.languagePanel.Size = new System.Drawing.Size(349, 287);
            this.languagePanel.TabIndex = 8;
            this.languagePanel.Visible = false;
            // 
            // languageGroupBox2
            // 
            this.languageGroupBox2.Controls.Add(this.switchButton);
            this.languageGroupBox2.Controls.Add(this.noteLanguageLabel);
            this.languageGroupBox2.Controls.Add(this.useSelectedSettingsLanguageCheckBox);
            this.languageGroupBox2.Controls.Add(this.destinationImageComboBoxEdit);
            this.languageGroupBox2.Controls.Add(this.sourceImageComboBoxEdit);
            this.languageGroupBox2.Controls.Add(this.destinationLanguageLabel);
            this.languageGroupBox2.Controls.Add(this.sourceLanguageLabel);
            this.languageGroupBox2.Location = new System.Drawing.Point(3, 56);
            this.languageGroupBox2.Name = "languageGroupBox2";
            this.languageGroupBox2.Size = new System.Drawing.Size(346, 144);
            this.languageGroupBox2.TabIndex = 1;
            this.languageGroupBox2.TabStop = false;
            this.languageGroupBox2.Text = "Google translation";
            // 
            // switchButton
            // 
            this.switchButton.Image = global::DtPad.ToolbarResource._switch;
            this.switchButton.Location = new System.Drawing.Point(289, 26);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(23, 23);
            this.switchButton.TabIndex = 4;
            this.switchButton.UseVisualStyleBackColor = true;
            this.switchButton.Click += new System.EventHandler(this.switchButton_Click);
            // 
            // noteLanguageLabel
            // 
            this.noteLanguageLabel.Location = new System.Drawing.Point(10, 109);
            this.noteLanguageLabel.Name = "noteLanguageLabel";
            this.noteLanguageLabel.Size = new System.Drawing.Size(273, 30);
            this.noteLanguageLabel.TabIndex = 6;
            this.noteLanguageLabel.Text = "Note: translation uses Google online service. Internet connection is required.";
            // 
            // useSelectedSettingsLanguageCheckBox
            // 
            this.useSelectedSettingsLanguageCheckBox.AutoSize = true;
            this.useSelectedSettingsLanguageCheckBox.Location = new System.Drawing.Point(10, 68);
            this.useSelectedSettingsLanguageCheckBox.Name = "useSelectedSettingsLanguageCheckBox";
            this.useSelectedSettingsLanguageCheckBox.Size = new System.Drawing.Size(184, 17);
            this.useSelectedSettingsLanguageCheckBox.TabIndex = 5;
            this.useSelectedSettingsLanguageCheckBox.Text = "Use selected settings without ask";
            this.useSelectedSettingsLanguageCheckBox.UseVisualStyleBackColor = true;
            // 
            // destinationImageComboBoxEdit
            // 
            this.destinationImageComboBoxEdit.EditValue = "Italiano";
            this.destinationImageComboBoxEdit.Location = new System.Drawing.Point(89, 40);
            this.destinationImageComboBoxEdit.Name = "destinationImageComboBoxEdit";
            this.destinationImageComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, global::DtPad.Languages.it.SearchPattern_historyComboBoxItems, 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, global::DtPad.Languages.it.SearchPattern_historyComboBoxItems, null, null, false)});
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
            // sourceImageComboBoxEdit
            // 
            this.sourceImageComboBoxEdit.EditValue = "English";
            this.sourceImageComboBoxEdit.Location = new System.Drawing.Point(89, 17);
            this.sourceImageComboBoxEdit.Name = "sourceImageComboBoxEdit";
            this.sourceImageComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, global::DtPad.Languages.it.SearchPattern_historyComboBoxItems, 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, global::DtPad.Languages.it.SearchPattern_historyComboBoxItems, null, null, false)});
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
            this.destinationLanguageLabel.Location = new System.Drawing.Point(10, 43);
            this.destinationLanguageLabel.Name = "destinationLanguageLabel";
            this.destinationLanguageLabel.Size = new System.Drawing.Size(63, 13);
            this.destinationLanguageLabel.TabIndex = 2;
            this.destinationLanguageLabel.Text = "Destination:";
            // 
            // sourceLanguageLabel
            // 
            this.sourceLanguageLabel.AutoSize = true;
            this.sourceLanguageLabel.Location = new System.Drawing.Point(10, 20);
            this.sourceLanguageLabel.Name = "sourceLanguageLabel";
            this.sourceLanguageLabel.Size = new System.Drawing.Size(44, 13);
            this.sourceLanguageLabel.TabIndex = 0;
            this.sourceLanguageLabel.Text = "Source:";
            // 
            // shellPanel
            // 
            this.shellPanel.Controls.Add(this.shellGroupBox1);
            this.shellPanel.Location = new System.Drawing.Point(150, 13);
            this.shellPanel.Name = "shellPanel";
            this.shellPanel.Size = new System.Drawing.Size(349, 287);
            this.shellPanel.TabIndex = 15;
            this.shellPanel.Visible = false;
            // 
            // shellGroupBox1
            // 
            this.shellGroupBox1.Controls.Add(this.jumpListCheckBox);
            this.shellGroupBox1.Controls.Add(this.openWithCheckBox);
            this.shellGroupBox1.Controls.Add(this.sendToCheckBox);
            this.shellGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.shellGroupBox1.Name = "shellGroupBox1";
            this.shellGroupBox1.Size = new System.Drawing.Size(346, 90);
            this.shellGroupBox1.TabIndex = 0;
            this.shellGroupBox1.TabStop = false;
            this.shellGroupBox1.Text = "Windows";
            // 
            // jumpListCheckBox
            // 
            this.jumpListCheckBox.AutoSize = true;
            this.jumpListCheckBox.Location = new System.Drawing.Point(10, 66);
            this.jumpListCheckBox.Name = "jumpListCheckBox";
            this.jumpListCheckBox.Size = new System.Drawing.Size(211, 17);
            this.jumpListCheckBox.TabIndex = 2;
            this.jumpListCheckBox.Text = "Activate Jump List (only on Windows 7)";
            this.jumpListCheckBox.UseVisualStyleBackColor = true;
            // 
            // openWithCheckBox
            // 
            this.openWithCheckBox.AutoSize = true;
            this.openWithCheckBox.Location = new System.Drawing.Point(10, 43);
            this.openWithCheckBox.Name = "openWithCheckBox";
            this.openWithCheckBox.Size = new System.Drawing.Size(140, 17);
            this.openWithCheckBox.TabIndex = 1;
            this.openWithCheckBox.Text = "\"Open with\" association";
            this.openWithCheckBox.UseVisualStyleBackColor = true;
            // 
            // sendToCheckBox
            // 
            this.sendToCheckBox.AutoSize = true;
            this.sendToCheckBox.Location = new System.Drawing.Point(10, 20);
            this.sendToCheckBox.Name = "sendToCheckBox";
            this.sendToCheckBox.Size = new System.Drawing.Size(129, 17);
            this.sendToCheckBox.TabIndex = 0;
            this.sendToCheckBox.Text = "\"Send to\" association";
            this.sendToCheckBox.UseVisualStyleBackColor = true;
            // 
            // openingPanel
            // 
            this.openingPanel.Controls.Add(this.openingGroupBox1);
            this.openingPanel.Controls.Add(this.openingGroupBox2);
            this.openingPanel.Controls.Add(this.openingGroupBox3);
            this.openingPanel.Location = new System.Drawing.Point(150, 13);
            this.openingPanel.Name = "openingPanel";
            this.openingPanel.Size = new System.Drawing.Size(349, 287);
            this.openingPanel.TabIndex = 3;
            this.openingPanel.Visible = false;
            // 
            // openingGroupBox1
            // 
            this.openingGroupBox1.Controls.Add(this.xmlCheckBox);
            this.openingGroupBox1.Controls.Add(this.htmlCheckBox);
            this.openingGroupBox1.Controls.Add(this.autoFormatLabel);
            this.openingGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.openingGroupBox1.Name = "openingGroupBox1";
            this.openingGroupBox1.Size = new System.Drawing.Size(346, 66);
            this.openingGroupBox1.TabIndex = 0;
            this.openingGroupBox1.TabStop = false;
            this.openingGroupBox1.Text = "Code files";
            // 
            // xmlCheckBox
            // 
            this.xmlCheckBox.AutoSize = true;
            this.xmlCheckBox.Location = new System.Drawing.Point(150, 43);
            this.xmlCheckBox.Name = "xmlCheckBox";
            this.xmlCheckBox.Size = new System.Drawing.Size(48, 17);
            this.xmlCheckBox.TabIndex = 2;
            this.xmlCheckBox.Text = "XML";
            this.xmlCheckBox.UseVisualStyleBackColor = true;
            // 
            // htmlCheckBox
            // 
            this.htmlCheckBox.AutoSize = true;
            this.htmlCheckBox.Location = new System.Drawing.Point(10, 43);
            this.htmlCheckBox.Name = "htmlCheckBox";
            this.htmlCheckBox.Size = new System.Drawing.Size(56, 17);
            this.htmlCheckBox.TabIndex = 1;
            this.htmlCheckBox.Text = "HTML";
            this.htmlCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoFormatLabel
            // 
            this.autoFormatLabel.AutoSize = true;
            this.autoFormatLabel.Location = new System.Drawing.Point(10, 20);
            this.autoFormatLabel.Name = "autoFormatLabel";
            this.autoFormatLabel.Size = new System.Drawing.Size(212, 13);
            this.autoFormatLabel.TabIndex = 0;
            this.autoFormatLabel.Text = "Auto-format following code files on opening:";
            // 
            // openingGroupBox2
            // 
            this.openingGroupBox2.Controls.Add(this.hostsConfiguratorTabColorComboBox);
            this.openingGroupBox2.Controls.Add(this.hostsConfiguratorTabColorLabel);
            this.openingGroupBox2.Controls.Add(this.hostsConfiguratorCheckBox);
            this.openingGroupBox2.Location = new System.Drawing.Point(3, 75);
            this.openingGroupBox2.Name = "openingGroupBox2";
            this.openingGroupBox2.Size = new System.Drawing.Size(346, 71);
            this.openingGroupBox2.TabIndex = 1;
            this.openingGroupBox2.TabStop = false;
            this.openingGroupBox2.Text = "System files";
            // 
            // hostsConfiguratorTabColorComboBox
            // 
            this.hostsConfiguratorTabColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hostsConfiguratorTabColorComboBox.Enabled = false;
            this.hostsConfiguratorTabColorComboBox.FormattingEnabled = true;
            this.hostsConfiguratorTabColorComboBox.Items.AddRange(new object[] {
            "Orange",
            "Red",
            "Green",
            "Blue",
            "Black"});
            this.hostsConfiguratorTabColorComboBox.Location = new System.Drawing.Point(89, 40);
            this.hostsConfiguratorTabColorComboBox.Name = "hostsConfiguratorTabColorComboBox";
            this.hostsConfiguratorTabColorComboBox.Size = new System.Drawing.Size(175, 21);
            this.hostsConfiguratorTabColorComboBox.TabIndex = 2;
            // 
            // hostsConfiguratorTabColorLabel
            // 
            this.hostsConfiguratorTabColorLabel.AutoSize = true;
            this.hostsConfiguratorTabColorLabel.Location = new System.Drawing.Point(10, 43);
            this.hostsConfiguratorTabColorLabel.Name = "hostsConfiguratorTabColorLabel";
            this.hostsConfiguratorTabColorLabel.Size = new System.Drawing.Size(55, 13);
            this.hostsConfiguratorTabColorLabel.TabIndex = 1;
            this.hostsConfiguratorTabColorLabel.Text = "Tab color:";
            // 
            // hostsConfiguratorCheckBox
            // 
            this.hostsConfiguratorCheckBox.AutoSize = true;
            this.hostsConfiguratorCheckBox.Location = new System.Drawing.Point(10, 20);
            this.hostsConfiguratorCheckBox.Name = "hostsConfiguratorCheckBox";
            this.hostsConfiguratorCheckBox.Size = new System.Drawing.Size(261, 17);
            this.hostsConfiguratorCheckBox.TabIndex = 0;
            this.hostsConfiguratorCheckBox.Text = "Open Hosts File Configurator on hosts file opening";
            this.hostsConfiguratorCheckBox.UseVisualStyleBackColor = true;
            this.hostsConfiguratorCheckBox.CheckedChanged += new System.EventHandler(this.hostsConfiguratorCheckBox_CheckedChanged);
            // 
            // openingGroupBox3
            // 
            this.openingGroupBox3.Controls.Add(this.nullCharCheckBox);
            this.openingGroupBox3.Location = new System.Drawing.Point(3, 152);
            this.openingGroupBox3.Name = "openingGroupBox3";
            this.openingGroupBox3.Size = new System.Drawing.Size(346, 45);
            this.openingGroupBox3.TabIndex = 2;
            this.openingGroupBox3.TabStop = false;
            this.openingGroupBox3.Text = "Other";
            // 
            // nullCharCheckBox
            // 
            this.nullCharCheckBox.AutoSize = true;
            this.nullCharCheckBox.Location = new System.Drawing.Point(10, 20);
            this.nullCharCheckBox.Name = "nullCharCheckBox";
            this.nullCharCheckBox.Size = new System.Drawing.Size(261, 17);
            this.nullCharCheckBox.TabIndex = 0;
            this.nullCharCheckBox.Text = "Do not consider null character of end of string (\\0)";
            this.nullCharCheckBox.UseVisualStyleBackColor = true;
            // 
            // updatePanel
            // 
            this.updatePanel.Controls.Add(this.updateGroupBox1);
            this.updatePanel.Location = new System.Drawing.Point(150, 13);
            this.updatePanel.Name = "updatePanel";
            this.updatePanel.Size = new System.Drawing.Size(349, 287);
            this.updatePanel.TabIndex = 13;
            this.updatePanel.Visible = false;
            // 
            // updateGroupBox1
            // 
            this.updateGroupBox1.Controls.Add(this.lastCheckLabel);
            this.updateGroupBox1.Controls.Add(this.frequencyAutomaticUpdateLabel);
            this.updateGroupBox1.Controls.Add(this.frequencyAutomaticUpdateComboBox);
            this.updateGroupBox1.Controls.Add(this.enableAutomaticUpdateCheckBox);
            this.updateGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.updateGroupBox1.Name = "updateGroupBox1";
            this.updateGroupBox1.Size = new System.Drawing.Size(346, 102);
            this.updateGroupBox1.TabIndex = 0;
            this.updateGroupBox1.TabStop = false;
            this.updateGroupBox1.Text = "Automatic Check";
            // 
            // lastCheckLabel
            // 
            this.lastCheckLabel.AutoSize = true;
            this.lastCheckLabel.Location = new System.Drawing.Point(10, 81);
            this.lastCheckLabel.Name = "lastCheckLabel";
            this.lastCheckLabel.Size = new System.Drawing.Size(63, 13);
            this.lastCheckLabel.TabIndex = 3;
            this.lastCheckLabel.Text = "Last check:";
            // 
            // frequencyAutomaticUpdateLabel
            // 
            this.frequencyAutomaticUpdateLabel.AutoSize = true;
            this.frequencyAutomaticUpdateLabel.Location = new System.Drawing.Point(10, 43);
            this.frequencyAutomaticUpdateLabel.Name = "frequencyAutomaticUpdateLabel";
            this.frequencyAutomaticUpdateLabel.Size = new System.Drawing.Size(60, 13);
            this.frequencyAutomaticUpdateLabel.TabIndex = 1;
            this.frequencyAutomaticUpdateLabel.Text = "Frequency:";
            // 
            // frequencyAutomaticUpdateComboBox
            // 
            this.frequencyAutomaticUpdateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frequencyAutomaticUpdateComboBox.FormattingEnabled = true;
            this.frequencyAutomaticUpdateComboBox.Items.AddRange(new object[] {
            "Montly",
            "Weekly"});
            this.frequencyAutomaticUpdateComboBox.Location = new System.Drawing.Point(84, 40);
            this.frequencyAutomaticUpdateComboBox.Name = "frequencyAutomaticUpdateComboBox";
            this.frequencyAutomaticUpdateComboBox.Size = new System.Drawing.Size(234, 21);
            this.frequencyAutomaticUpdateComboBox.TabIndex = 2;
            // 
            // enableAutomaticUpdateCheckBox
            // 
            this.enableAutomaticUpdateCheckBox.AutoSize = true;
            this.enableAutomaticUpdateCheckBox.Location = new System.Drawing.Point(10, 20);
            this.enableAutomaticUpdateCheckBox.Name = "enableAutomaticUpdateCheckBox";
            this.enableAutomaticUpdateCheckBox.Size = new System.Drawing.Size(211, 17);
            this.enableAutomaticUpdateCheckBox.TabIndex = 0;
            this.enableAutomaticUpdateCheckBox.Text = "Enable automatic DtPad version check";
            this.enableAutomaticUpdateCheckBox.UseVisualStyleBackColor = true;
            this.enableAutomaticUpdateCheckBox.CheckedChanged += new System.EventHandler(this.enableAutomaticUpdateCheckBox_CheckedChanged);
            // 
            // dropboxPanel
            // 
            this.dropboxPanel.Controls.Add(this.dropboxGroupBox1);
            this.dropboxPanel.Location = new System.Drawing.Point(150, 13);
            this.dropboxPanel.Name = "dropboxPanel";
            this.dropboxPanel.Size = new System.Drawing.Size(349, 287);
            this.dropboxPanel.TabIndex = 14;
            this.dropboxPanel.Visible = false;
            // 
            // dropboxGroupBox1
            // 
            this.dropboxGroupBox1.Controls.Add(this.dropboxDeleteCheckBox);
            this.dropboxGroupBox1.Controls.Add(this.dropboxRememberCheckBox);
            this.dropboxGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.dropboxGroupBox1.Name = "dropboxGroupBox1";
            this.dropboxGroupBox1.Size = new System.Drawing.Size(346, 66);
            this.dropboxGroupBox1.TabIndex = 0;
            this.dropboxGroupBox1.TabStop = false;
            this.dropboxGroupBox1.Text = "Usage";
            // 
            // dropboxDeleteCheckBox
            // 
            this.dropboxDeleteCheckBox.AutoSize = true;
            this.dropboxDeleteCheckBox.Location = new System.Drawing.Point(10, 43);
            this.dropboxDeleteCheckBox.Name = "dropboxDeleteCheckBox";
            this.dropboxDeleteCheckBox.Size = new System.Drawing.Size(196, 17);
            this.dropboxDeleteCheckBox.TabIndex = 1;
            this.dropboxDeleteCheckBox.Text = "Allow delete file and folder operation";
            this.dropboxDeleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // dropboxRememberCheckBox
            // 
            this.dropboxRememberCheckBox.AutoSize = true;
            this.dropboxRememberCheckBox.Location = new System.Drawing.Point(10, 20);
            this.dropboxRememberCheckBox.Name = "dropboxRememberCheckBox";
            this.dropboxRememberCheckBox.Size = new System.Drawing.Size(173, 17);
            this.dropboxRememberCheckBox.TabIndex = 0;
            this.dropboxRememberCheckBox.Text = "Remember user login when exit";
            this.dropboxRememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(511, 350);
            this.Controls.Add(this.optionsTreeView);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.filePanel);
            this.Controls.Add(this.updatePanel);
            this.Controls.Add(this.dropboxPanel);
            this.Controls.Add(this.shellPanel);
            this.Controls.Add(this.openingPanel);
            this.Controls.Add(this.lookAndFeelPanel);
            this.Controls.Add(this.internetPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.formatPanel);
            this.Controls.Add(this.encodingPanel);
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.languagePanel);
            this.Controls.Add(this.sessionPanel);
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.savingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Options_HelpButtonClicked);
            this.searchPanel.ResumeLayout(false);
            this.searchGroupBox1.ResumeLayout(false);
            this.searchGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchHistoryNumericUpDown)).EndInit();
            this.numberContextMenuStrip.ResumeLayout(false);
            this.formatPanel.ResumeLayout(false);
            this.formatGroupBox1.ResumeLayout(false);
            this.formatGroupBox1.PerformLayout();
            this.formatGroupBox2.ResumeLayout(false);
            this.formatGroupBox2.PerformLayout();
            this.languageGroupBox1.ResumeLayout(false);
            this.languageGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languageComboBox.Properties)).EndInit();
            this.viewPanel.ResumeLayout(false);
            this.viewGroupBox1.ResumeLayout(false);
            this.viewGroupBox1.PerformLayout();
            this.viewGroupBox2.ResumeLayout(false);
            this.viewGroupBox2.PerformLayout();
            this.viewGroupBox3.ResumeLayout(false);
            this.viewGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hideLinesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpHideLinesPictureBox)).EndInit();
            this.internetPanel.ResumeLayout(false);
            this.internetGroupBox1.ResumeLayout(false);
            this.internetGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proxyPortNumericUpDown)).EndInit();
            this.contentContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoProxyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPictureBox)).EndInit();
            this.internetGroupBox2.ResumeLayout(false);
            this.internetGroupBox2.PerformLayout();
            this.lookAndFeelPanel.ResumeLayout(false);
            this.lookAndFeelGroupBox1.ResumeLayout(false);
            this.lookAndFeelGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renderPictureBox)).EndInit();
            this.filePanel.ResumeLayout(false);
            this.fileGroupBox1.ResumeLayout(false);
            this.fileGroupBox1.PerformLayout();
            this.fileGroupBox2.ResumeLayout(false);
            this.fileGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentFilesNumberNumericUpDown)).EndInit();
            this.encodingPanel.ResumeLayout(false);
            this.encodingGroupBox1.ResumeLayout(false);
            this.encodingGroupBox1.PerformLayout();
            this.tabPanel.ResumeLayout(false);
            this.tabGroupBox1.ResumeLayout(false);
            this.tabGroupBox1.PerformLayout();
            this.savingPanel.ResumeLayout(false);
            this.savingGroupBox1.ResumeLayout(false);
            this.savingGroupBox1.PerformLayout();
            this.backupGroupBox2.ResumeLayout(false);
            this.backupGroupBox2.PerformLayout();
            this.sessionPanel.ResumeLayout(false);
            this.sessionGroupBox1.ResumeLayout(false);
            this.sessionGroupBox1.PerformLayout();
            this.languagePanel.ResumeLayout(false);
            this.languageGroupBox2.ResumeLayout(false);
            this.languageGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destinationImageComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageComboBoxEdit.Properties)).EndInit();
            this.shellPanel.ResumeLayout(false);
            this.shellGroupBox1.ResumeLayout(false);
            this.shellGroupBox1.PerformLayout();
            this.openingPanel.ResumeLayout(false);
            this.openingGroupBox1.ResumeLayout(false);
            this.openingGroupBox1.PerformLayout();
            this.openingGroupBox2.ResumeLayout(false);
            this.openingGroupBox2.PerformLayout();
            this.openingGroupBox3.ResumeLayout(false);
            this.openingGroupBox3.PerformLayout();
            this.updatePanel.ResumeLayout(false);
            this.updateGroupBox1.ResumeLayout(false);
            this.updateGroupBox1.PerformLayout();
            this.dropboxPanel.ResumeLayout(false);
            this.dropboxGroupBox1.ResumeLayout(false);
            this.dropboxGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView optionsTreeView;
        private System.Windows.Forms.FlowLayoutPanel searchPanel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox searchGroupBox1;
        internal System.Windows.Forms.CheckBox caseSensitiveCheckBox;
        internal System.Windows.Forms.CheckBox showSearchPanelCheckBox;
        private System.Windows.Forms.FlowLayoutPanel formatPanel;
        private System.Windows.Forms.GroupBox formatGroupBox1;
        private System.Windows.Forms.Button fontButton;
        internal System.Windows.Forms.CheckBox wordWrapCheckBox;
        private System.Windows.Forms.GroupBox languageGroupBox1;
        private System.Windows.Forms.FlowLayoutPanel viewPanel;
        private System.Windows.Forms.GroupBox viewGroupBox1;
        private System.Windows.Forms.GroupBox viewGroupBox2;
        internal System.Windows.Forms.CheckBox minimizeOnTrayIconCheckBox;
        internal System.Windows.Forms.CheckBox stayOnTopCheckBox;
        internal System.Windows.Forms.CheckBox statusBarCheckBox;
        internal System.Windows.Forms.CheckBox toolbarCheckBox;
        private System.Windows.Forms.FlowLayoutPanel internetPanel;
        private System.Windows.Forms.GroupBox internetGroupBox1;
        internal System.Windows.Forms.CheckBox enableProxySettingsCheckBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label domainLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        internal System.Windows.Forms.TextBox domainTextBox;
        internal System.Windows.Forms.TextBox passwordTextBox;
        internal System.Windows.Forms.TextBox usernameTextBox;
        internal System.Windows.Forms.PictureBox statusPictureBox;
        private System.Windows.Forms.Label fontLabel1;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.GroupBox internetGroupBox2;
        private System.Windows.Forms.TextBox customBrowserTextBox;
        private System.Windows.Forms.RadioButton customBrowserRadioButton;
        private System.Windows.Forms.RadioButton defaultBrowserRadioButton;
        private System.Windows.Forms.Button customBrowserButton;
        internal System.Windows.Forms.CheckBox loopAtEOFCheckBox;
        private System.Windows.Forms.FlowLayoutPanel lookAndFeelPanel;
        private System.Windows.Forms.GroupBox lookAndFeelGroupBox1;
        internal System.Windows.Forms.ComboBox renderModeComboBox;
        private System.Windows.Forms.Label renderModeLabel;
        private System.Windows.Forms.Label fontColorLabel;
        private System.Windows.Forms.Label backgroundColorLabel;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.TextBox fontColorTextBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.PictureBox renderPictureBox;
        internal System.Windows.Forms.CheckBox urlsCheckBox;
        private Customs.CustomNumericUpDown searchHistoryNumericUpDown;
        private System.Windows.Forms.Label searchHistoryLabel;
        private System.Windows.Forms.FlowLayoutPanel filePanel;
        private System.Windows.Forms.GroupBox fileGroupBox1;
        private System.Windows.Forms.Button specificFolderButton;
        private System.Windows.Forms.RadioButton specificFolderRadioButton;
        private System.Windows.Forms.RadioButton lastUsedFolderRadioButton;
        internal System.Windows.Forms.TextBox specificFolderTextBox;
        internal System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox fileGroupBox2;
        private System.Windows.Forms.Button clearRecentFilesButton;
        private Customs.CustomNumericUpDown recentFilesNumberNumericUpDown;
        private System.Windows.Forms.Label recentFilesNumberLabel;
        private System.Windows.Forms.Label extensionLabel;
        internal System.Windows.Forms.ListBox extensionListBox;
        private System.Windows.Forms.ToolTip optionsToolTip;
        private System.Windows.Forms.Button extensionsButton;
        internal DevExpress.XtraEditors.ImageComboBoxEdit languageComboBox;
        private System.Windows.Forms.PictureBox infoProxyPictureBox;
        private System.Windows.Forms.ImageList languageImageList;
        private System.Windows.Forms.GroupBox viewGroupBox3;
        internal System.Windows.Forms.CheckBox internalExplorerCheckBox;
        private System.Windows.Forms.Label closeTabButtonOnLabel;
        internal System.Windows.Forms.ComboBox tabCloseButtonOnComboBox;
        private System.Windows.Forms.FlowLayoutPanel encodingPanel;
        private System.Windows.Forms.GroupBox encodingGroupBox1;
        private System.Windows.Forms.Label defaultLabel;
        internal System.Windows.Forms.CheckBox useExistingCheckBox;
        internal System.Windows.Forms.ComboBox defaultComboBox;
        internal System.Windows.Forms.CheckBox lineNumbersCheckBox;
        private System.Windows.Forms.TextBox backgroundColorTextBox;
        private System.Windows.Forms.FlowLayoutPanel tabPanel;
        private System.Windows.Forms.GroupBox tabGroupBox1;
        internal System.Windows.Forms.ComboBox tabPositionComboBox;
        private System.Windows.Forms.Label tabPositionLabel;
        internal System.Windows.Forms.ComboBox tabOrientationComboBox;
        private System.Windows.Forms.Label tabOrientationLabel;
        internal System.Windows.Forms.CheckBox tabMultilineCheckBox;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.FlowLayoutPanel savingPanel;
        private System.Windows.Forms.GroupBox savingGroupBox1;
        private System.Windows.Forms.RadioButton backupReplaceExtensionRadioButton;
        private System.Windows.Forms.RadioButton backupAddExtensionRadioButton;
        private System.Windows.Forms.TextBox backupExtensionTextBox;
        private System.Windows.Forms.Label backupExtensionLabel;
        private System.Windows.Forms.CheckBox createBackupCheckBox;
        private System.Windows.Forms.GroupBox backupGroupBox2;
        private System.Windows.Forms.RadioButton backupCustomFolderRadioButton;
        private System.Windows.Forms.RadioButton backupEditedFileRadioButton;
        private System.Windows.Forms.Button backupCustomFolderButton;
        internal System.Windows.Forms.TextBox backupCustomFolderTextBox;
        private System.Windows.Forms.CheckBox backupIncrementalCheckBox;
        private System.Windows.Forms.CheckBox useSpacesInsteadTabsCheckBox;
        internal System.Windows.Forms.CheckBox keepInitialSpacesOnReturnCheckBox;
        private System.Windows.Forms.CheckBox splashScreenCheckBox;
        private System.Windows.Forms.Panel sessionPanel;
        private System.Windows.Forms.GroupBox sessionGroupBox1;
        private System.Windows.Forms.CheckBox automaticSessionSaveCheckBox;
        private System.Windows.Forms.FlowLayoutPanel languagePanel;
        private System.Windows.Forms.GroupBox languageGroupBox2;
        private System.Windows.Forms.Label sourceLanguageLabel;
        private System.Windows.Forms.Label noteLanguageLabel;
        private System.Windows.Forms.CheckBox useSelectedSettingsLanguageCheckBox;
        private DevExpress.XtraEditors.ImageComboBoxEdit destinationImageComboBoxEdit;
        private DevExpress.XtraEditors.ImageComboBoxEdit sourceImageComboBoxEdit;
        private System.Windows.Forms.Label destinationLanguageLabel;
        private System.Windows.Forms.CheckBox hideLinesCheckBox;
        private System.Windows.Forms.PictureBox helpHideLinesPictureBox;
        private Customs.CustomNumericUpDown hideLinesNumericUpDown;
        internal System.Windows.Forms.Button checkConnectionButton;
        private System.Windows.Forms.FlowLayoutPanel shellPanel;
        private System.Windows.Forms.GroupBox shellGroupBox1;
        private System.Windows.Forms.CheckBox sendToCheckBox;
        private System.Windows.Forms.CheckBox openWithCheckBox;
        private System.Windows.Forms.FlowLayoutPanel openingPanel;
        private System.Windows.Forms.GroupBox openingGroupBox1;
        private System.Windows.Forms.Label autoFormatLabel;
        private System.Windows.Forms.CheckBox xmlCheckBox;
        private System.Windows.Forms.CheckBox htmlCheckBox;
        internal System.Windows.Forms.ContextMenuStrip contentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.GroupBox openingGroupBox2;
        private System.Windows.Forms.CheckBox hostsConfiguratorCheckBox;
        internal System.Windows.Forms.CheckBox folderOpenedFileCheckBox;
        private System.Windows.Forms.FlowLayoutPanel updatePanel;
        private System.Windows.Forms.GroupBox updateGroupBox1;
        private System.Windows.Forms.Label lastCheckLabel;
        private System.Windows.Forms.Label frequencyAutomaticUpdateLabel;
        private System.Windows.Forms.ComboBox frequencyAutomaticUpdateComboBox;
        private System.Windows.Forms.CheckBox enableAutomaticUpdateCheckBox;
        private System.Windows.Forms.Label keepBulletListOnReturnLabel;
        internal System.Windows.Forms.CheckBox keepBulletListOnReturnCheckBox;
        private System.Windows.Forms.GroupBox formatGroupBox2;
        private System.Windows.Forms.Button switchButton;
        private System.Windows.Forms.Label keepBulletListOnReturnLabel2;
        private System.Windows.Forms.ComboBox hostsConfiguratorTabColorComboBox;
        private System.Windows.Forms.Label hostsConfiguratorTabColorLabel;
        internal System.Windows.Forms.ContextMenuStrip numberContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem1;
        private System.Windows.Forms.CheckBox highlightsResultsCheckBox;
        internal System.Windows.Forms.CheckBox jumpListCheckBox;
        internal System.Windows.Forms.TextBox proxyHostTextBox;
        private System.Windows.Forms.Label proxyPortLabel;
        private System.Windows.Forms.Label proxyHostLabel;
        internal Customs.CustomNumericUpDown proxyPortNumericUpDown;
        private System.Windows.Forms.FlowLayoutPanel dropboxPanel;
        private System.Windows.Forms.GroupBox dropboxGroupBox1;
        private System.Windows.Forms.CheckBox dropboxDeleteCheckBox;
        private System.Windows.Forms.CheckBox dropboxRememberCheckBox;
        private System.Windows.Forms.GroupBox openingGroupBox3;
        private System.Windows.Forms.CheckBox nullCharCheckBox;
    }
}
