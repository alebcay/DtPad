namespace DtPad
{
    partial class CsvEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CsvEditor));
            this.csvGridView = new System.Windows.Forms.DataGridView();
            this.gridViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectCurrentColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectCurrentRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectedColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeButton = new System.Windows.Forms.Button();
            this.delimiterLabel = new System.Windows.Forms.Label();
            this.headerCheckBox = new System.Windows.Forms.CheckBox();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.quoteComboBox = new DtPad.Customs.CustomComboBox();
            this.quoteLabel = new System.Windows.Forms.Label();
            this.delimiterComboBox = new DtPad.Customs.CustomComboBox();
            this.csvEditorToolStrip = new System.Windows.Forms.ToolStrip();
            this.undoToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.undoAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewColumnToolStripTextBox = new DtPad.Customs.CustomToolStripTextBox();
            this.customContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoCustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.cutCustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllCustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewColumnToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.selectToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.currentColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editHeaderToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteSelectedColumnsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteSelectedRowsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cellWrapToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.screenshotToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.applyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.csvGridView)).BeginInit();
            this.gridViewContextMenuStrip.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.csvEditorToolStrip.SuspendLayout();
            this.customContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // csvGridView
            // 
            this.csvGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.csvGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.csvGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.csvGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.csvGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.csvGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.csvGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csvGridView.ContextMenuStrip = this.gridViewContextMenuStrip;
            this.csvGridView.Location = new System.Drawing.Point(12, 28);
            this.csvGridView.Name = "csvGridView";
            this.csvGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.csvGridView.Size = new System.Drawing.Size(673, 376);
            this.csvGridView.TabIndex = 0;
            this.csvGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.csvGridView_CellValueChanged);
            this.csvGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.csvGridView_ColumnDisplayIndexChanged);
            this.csvGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.csvGridView_RowPostPaint);
            this.csvGridView.SelectionChanged += new System.EventHandler(this.csvGridView_SelectionChanged);
            this.csvGridView.Sorted += new System.EventHandler(this.csvGridView_Sorted);
            // 
            // gridViewContextMenuStrip
            // 
            this.gridViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator1,
            this.selectCurrentColumnsToolStripMenuItem,
            this.selectCurrentRowsToolStripMenuItem,
            this.toolStripSeparator4,
            this.deleteSelectedColumnsToolStripMenuItem,
            this.deleteSelectedRowsToolStripMenuItem});
            this.gridViewContextMenuStrip.Name = "gridViewContextMenuStrip";
            this.gridViewContextMenuStrip.Size = new System.Drawing.Size(206, 126);
            this.gridViewContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.gridViewContextMenuStrip_Opening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Image = global::DtPad.ToolbarResource.arrow_left;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.undoToolStripMenuItem.Text = "Undo Last Action";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // selectCurrentColumnsToolStripMenuItem
            // 
            this.selectCurrentColumnsToolStripMenuItem.Name = "selectCurrentColumnsToolStripMenuItem";
            this.selectCurrentColumnsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.selectCurrentColumnsToolStripMenuItem.Text = "Select Current Columns";
            this.selectCurrentColumnsToolStripMenuItem.Click += new System.EventHandler(this.selectCurrentColumnsToolStripMenuItem_Click);
            // 
            // selectCurrentRowsToolStripMenuItem
            // 
            this.selectCurrentRowsToolStripMenuItem.Name = "selectCurrentRowsToolStripMenuItem";
            this.selectCurrentRowsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.selectCurrentRowsToolStripMenuItem.Text = "Select Current Rows";
            this.selectCurrentRowsToolStripMenuItem.Click += new System.EventHandler(this.selectCurrentRowsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(202, 6);
            // 
            // deleteSelectedColumnsToolStripMenuItem
            // 
            this.deleteSelectedColumnsToolStripMenuItem.Image = global::DtPad.ToolbarResource.delete_column;
            this.deleteSelectedColumnsToolStripMenuItem.Name = "deleteSelectedColumnsToolStripMenuItem";
            this.deleteSelectedColumnsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.deleteSelectedColumnsToolStripMenuItem.Text = "Delete Selected Columns";
            this.deleteSelectedColumnsToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedColumnsToolStripMenuItem_Click);
            // 
            // deleteSelectedRowsToolStripMenuItem
            // 
            this.deleteSelectedRowsToolStripMenuItem.Image = global::DtPad.ToolbarResource.delete_row;
            this.deleteSelectedRowsToolStripMenuItem.Name = "deleteSelectedRowsToolStripMenuItem";
            this.deleteSelectedRowsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.deleteSelectedRowsToolStripMenuItem.Text = "Delete Selected Rows";
            this.deleteSelectedRowsToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedRowsToolStripMenuItem_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(543, 463);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(142, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // delimiterLabel
            // 
            this.delimiterLabel.AutoSize = true;
            this.delimiterLabel.Location = new System.Drawing.Point(6, 23);
            this.delimiterLabel.Name = "delimiterLabel";
            this.delimiterLabel.Size = new System.Drawing.Size(50, 13);
            this.delimiterLabel.TabIndex = 0;
            this.delimiterLabel.Text = "Delimiter:";
            // 
            // headerCheckBox
            // 
            this.headerCheckBox.AutoSize = true;
            this.headerCheckBox.Location = new System.Drawing.Point(331, 23);
            this.headerCheckBox.Name = "headerCheckBox";
            this.headerCheckBox.Size = new System.Drawing.Size(99, 17);
            this.headerCheckBox.TabIndex = 2;
            this.headerCheckBox.Text = "Header present";
            this.headerCheckBox.UseVisualStyleBackColor = true;
            this.headerCheckBox.CheckedChanged += new System.EventHandler(this.headerCheckBox_CheckedChanged);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsGroupBox.Controls.Add(this.quoteComboBox);
            this.settingsGroupBox.Controls.Add(this.quoteLabel);
            this.settingsGroupBox.Controls.Add(this.delimiterComboBox);
            this.settingsGroupBox.Controls.Add(this.delimiterLabel);
            this.settingsGroupBox.Controls.Add(this.headerCheckBox);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 410);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(525, 77);
            this.settingsGroupBox.TabIndex = 1;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "File configuration";
            // 
            // quoteComboBox
            // 
            this.quoteComboBox.CustomContextMenuStrip = null;
            this.quoteComboBox.FormattingEnabled = true;
            this.quoteComboBox.Items.AddRange(new object[] {
            global::DtPad.Languages.it.SearchInFiles_searchFolderComboBoxItems,
            "[Empty quote]",
            "\" (quotes)",
            "\' (single quote)"});
            this.quoteComboBox.Location = new System.Drawing.Point(103, 47);
            this.quoteComboBox.MaxLength = 1;
            this.quoteComboBox.Name = "quoteComboBox";
            this.quoteComboBox.Size = new System.Drawing.Size(171, 21);
            this.quoteComboBox.TabIndex = 4;
            this.quoteComboBox.TextChanged += new System.EventHandler(this.quoteComboBox_TextChanged);
            // 
            // quoteLabel
            // 
            this.quoteLabel.AutoSize = true;
            this.quoteLabel.Location = new System.Drawing.Point(6, 50);
            this.quoteLabel.Name = "quoteLabel";
            this.quoteLabel.Size = new System.Drawing.Size(61, 13);
            this.quoteLabel.TabIndex = 3;
            this.quoteLabel.Text = "Text quote:";
            // 
            // delimiterComboBox
            // 
            this.delimiterComboBox.CustomContextMenuStrip = null;
            this.delimiterComboBox.FormattingEnabled = true;
            this.delimiterComboBox.Items.AddRange(new object[] {
            global::DtPad.Languages.it.SearchInFiles_searchFolderComboBoxItems,
            ", (comma)",
            ". (dot)",
            "; (semicolon)",
            "- (dash)"});
            this.delimiterComboBox.Location = new System.Drawing.Point(103, 20);
            this.delimiterComboBox.MaxLength = 1;
            this.delimiterComboBox.Name = "delimiterComboBox";
            this.delimiterComboBox.Size = new System.Drawing.Size(171, 21);
            this.delimiterComboBox.TabIndex = 1;
            this.delimiterComboBox.TextChanged += new System.EventHandler(this.delimiterComboBox_TextChanged);
            // 
            // csvEditorToolStrip
            // 
            this.csvEditorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripSplitButton,
            this.toolStripSeparator2,
            this.addNewColumnToolStripTextBox,
            this.addNewColumnToolStripButton,
            this.toolStripSeparator5,
            this.selectToolStripDropDownButton,
            this.editHeaderToolStripButton,
            this.deleteSelectedColumnsToolStripButton,
            this.deleteSelectedRowsToolStripButton,
            this.toolStripSeparator3,
            this.cellWrapToolStripButton,
            this.screenshotToolStripButton});
            this.csvEditorToolStrip.Location = new System.Drawing.Point(0, 0);
            this.csvEditorToolStrip.Name = "csvEditorToolStrip";
            this.csvEditorToolStrip.Size = new System.Drawing.Size(697, 25);
            this.csvEditorToolStrip.TabIndex = 4;
            this.csvEditorToolStrip.Text = "csvEditorToolStrip";
            // 
            // undoToolStripSplitButton
            // 
            this.undoToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoAllToolStripMenuItem});
            this.undoToolStripSplitButton.Enabled = false;
            this.undoToolStripSplitButton.Image = global::DtPad.ToolbarResource.arrow_left;
            this.undoToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolStripSplitButton.Name = "undoToolStripSplitButton";
            this.undoToolStripSplitButton.Size = new System.Drawing.Size(32, 22);
            this.undoToolStripSplitButton.Text = "Undo Last Action";
            this.undoToolStripSplitButton.ButtonClick += new System.EventHandler(this.undoToolStripSplitButton_ButtonClick);
            // 
            // undoAllToolStripMenuItem
            // 
            this.undoAllToolStripMenuItem.Name = "undoAllToolStripMenuItem";
            this.undoAllToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.undoAllToolStripMenuItem.Text = "Undo All";
            this.undoAllToolStripMenuItem.Click += new System.EventHandler(this.undoAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // addNewColumnToolStripTextBox
            // 
            this.addNewColumnToolStripTextBox.CustomContextMenuStrip = this.customContextMenuStrip;
            this.addNewColumnToolStripTextBox.Enabled = false;
            this.addNewColumnToolStripTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewColumnToolStripTextBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.addNewColumnToolStripTextBox.Name = "addNewColumnToolStripTextBox";
            this.addNewColumnToolStripTextBox.ShortcutsEnabled = false;
            this.addNewColumnToolStripTextBox.Size = new System.Drawing.Size(200, 25);
            this.addNewColumnToolStripTextBox.Text = "Insert column name";
            this.addNewColumnToolStripTextBox.Enter += new System.EventHandler(this.addNewColumnToolStripTextBox_Enter);
            this.addNewColumnToolStripTextBox.Leave += new System.EventHandler(this.addNewColumnToolStripTextBox_Leave);
            this.addNewColumnToolStripTextBox.TextChanged += new System.EventHandler(this.addNewColumnToolStripTextBox_TextChanged);
            // 
            // customContextMenuStrip
            // 
            this.customContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoCustomToolStripMenuItem,
            this.toolStripSeparator7,
            this.cutCustomToolStripMenuItem,
            this.copyCustomToolStripMenuItem,
            this.pasteCustomToolStripMenuItem,
            this.deleteCustomToolStripMenuItem,
            this.toolStripSeparator8,
            this.selectAllCustomToolStripMenuItem});
            this.customContextMenuStrip.Name = "customContextMenuStrip";
            this.customContextMenuStrip.Size = new System.Drawing.Size(123, 148);
            this.customContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.customContextMenuStrip_Opening);
            // 
            // undoCustomToolStripMenuItem
            // 
            this.undoCustomToolStripMenuItem.Enabled = false;
            this.undoCustomToolStripMenuItem.Name = "undoCustomToolStripMenuItem";
            this.undoCustomToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.undoCustomToolStripMenuItem.Text = "Undo";
            this.undoCustomToolStripMenuItem.Click += new System.EventHandler(this.undoCustomToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(119, 6);
            // 
            // cutCustomToolStripMenuItem
            // 
            this.cutCustomToolStripMenuItem.Image = global::DtPad.ToolbarResource.cut;
            this.cutCustomToolStripMenuItem.Name = "cutCustomToolStripMenuItem";
            this.cutCustomToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutCustomToolStripMenuItem.Text = "Cut";
            this.cutCustomToolStripMenuItem.Click += new System.EventHandler(this.cutCustomToolStripMenuItem_Click);
            // 
            // copyCustomToolStripMenuItem
            // 
            this.copyCustomToolStripMenuItem.Image = global::DtPad.ToolbarResource.copy;
            this.copyCustomToolStripMenuItem.Name = "copyCustomToolStripMenuItem";
            this.copyCustomToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyCustomToolStripMenuItem.Text = "Copy";
            this.copyCustomToolStripMenuItem.Click += new System.EventHandler(this.copyCustomToolStripMenuItem_Click);
            // 
            // pasteCustomToolStripMenuItem
            // 
            this.pasteCustomToolStripMenuItem.Image = global::DtPad.ToolbarResource.paste;
            this.pasteCustomToolStripMenuItem.Name = "pasteCustomToolStripMenuItem";
            this.pasteCustomToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteCustomToolStripMenuItem.Text = "Paste";
            this.pasteCustomToolStripMenuItem.Click += new System.EventHandler(this.pasteCustomToolStripMenuItem_Click);
            // 
            // deleteCustomToolStripMenuItem
            // 
            this.deleteCustomToolStripMenuItem.Name = "deleteCustomToolStripMenuItem";
            this.deleteCustomToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteCustomToolStripMenuItem.Text = "Delete";
            this.deleteCustomToolStripMenuItem.Click += new System.EventHandler(this.deleteCustomToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(119, 6);
            // 
            // selectAllCustomToolStripMenuItem
            // 
            this.selectAllCustomToolStripMenuItem.Name = "selectAllCustomToolStripMenuItem";
            this.selectAllCustomToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllCustomToolStripMenuItem.Text = "Select All";
            this.selectAllCustomToolStripMenuItem.Click += new System.EventHandler(this.selectAllCustomToolStripMenuItem_Click);
            // 
            // addNewColumnToolStripButton
            // 
            this.addNewColumnToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addNewColumnToolStripButton.Image = global::DtPad.ToolbarResource.add_column;
            this.addNewColumnToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNewColumnToolStripButton.Name = "addNewColumnToolStripButton";
            this.addNewColumnToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addNewColumnToolStripButton.Text = "Add New Column";
            this.addNewColumnToolStripButton.Click += new System.EventHandler(this.addNewColumnToolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // selectToolStripDropDownButton
            // 
            this.selectToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentColumnsToolStripMenuItem,
            this.currentRowsToolStripMenuItem,
            this.toolStripSeparator6,
            this.allToolStripMenuItem});
            this.selectToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("selectToolStripDropDownButton.Image")));
            this.selectToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectToolStripDropDownButton.Name = "selectToolStripDropDownButton";
            this.selectToolStripDropDownButton.Size = new System.Drawing.Size(60, 22);
            this.selectToolStripDropDownButton.Text = "Select...";
            // 
            // currentColumnsToolStripMenuItem
            // 
            this.currentColumnsToolStripMenuItem.Name = "currentColumnsToolStripMenuItem";
            this.currentColumnsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.currentColumnsToolStripMenuItem.Text = "Current Columns";
            this.currentColumnsToolStripMenuItem.Click += new System.EventHandler(this.currentColumnsToolStripMenuItem_Click);
            // 
            // currentRowsToolStripMenuItem
            // 
            this.currentRowsToolStripMenuItem.Name = "currentRowsToolStripMenuItem";
            this.currentRowsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.currentRowsToolStripMenuItem.Text = "Current Rows";
            this.currentRowsToolStripMenuItem.Click += new System.EventHandler(this.currentRowsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(162, 6);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // editHeaderToolStripButton
            // 
            this.editHeaderToolStripButton.Image = global::DtPad.ToolbarResource.header;
            this.editHeaderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editHeaderToolStripButton.Name = "editHeaderToolStripButton";
            this.editHeaderToolStripButton.Size = new System.Drawing.Size(88, 22);
            this.editHeaderToolStripButton.Text = "Edit Header";
            this.editHeaderToolStripButton.Click += new System.EventHandler(this.editHeaderToolStripButton_Click);
            // 
            // deleteSelectedColumnsToolStripButton
            // 
            this.deleteSelectedColumnsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteSelectedColumnsToolStripButton.Image = global::DtPad.ToolbarResource.delete_column;
            this.deleteSelectedColumnsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteSelectedColumnsToolStripButton.Name = "deleteSelectedColumnsToolStripButton";
            this.deleteSelectedColumnsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteSelectedColumnsToolStripButton.Text = "Delete Selected Columns";
            this.deleteSelectedColumnsToolStripButton.Click += new System.EventHandler(this.deleteSelectedColumnsToolStripButton_Click);
            // 
            // deleteSelectedRowsToolStripButton
            // 
            this.deleteSelectedRowsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteSelectedRowsToolStripButton.Image = global::DtPad.ToolbarResource.delete_row;
            this.deleteSelectedRowsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteSelectedRowsToolStripButton.Name = "deleteSelectedRowsToolStripButton";
            this.deleteSelectedRowsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteSelectedRowsToolStripButton.Text = "Delete Selected Rows";
            this.deleteSelectedRowsToolStripButton.Click += new System.EventHandler(this.deleteSelectedRowsToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cellWrapToolStripButton
            // 
            this.cellWrapToolStripButton.CheckOnClick = true;
            this.cellWrapToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cellWrapToolStripButton.Image = global::DtPad.ToolbarResource.word_wrap;
            this.cellWrapToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cellWrapToolStripButton.Name = "cellWrapToolStripButton";
            this.cellWrapToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cellWrapToolStripButton.Text = "Word Wrap";
            this.cellWrapToolStripButton.CheckedChanged += new System.EventHandler(this.cellWrapToolStripButton_CheckedChanged);
            // 
            // screenshotToolStripButton
            // 
            this.screenshotToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.screenshotToolStripButton.Image = global::DtPad.ToolbarResource.screenshot;
            this.screenshotToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.screenshotToolStripButton.Name = "screenshotToolStripButton";
            this.screenshotToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.screenshotToolStripButton.Text = "toolStripButton1";
            this.screenshotToolStripButton.Click += new System.EventHandler(this.screenshotToolStripButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Enabled = false;
            this.applyButton.Image = global::DtPad.MessageBoxResource.ok;
            this.applyButton.Location = new System.Drawing.Point(543, 433);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(142, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply changes";
            this.applyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.applyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // CsvEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 498);
            this.Controls.Add(this.csvEditorToolStrip);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.csvGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(713, 536);
            this.Name = "CsvEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CsvEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.csvGridView)).EndInit();
            this.gridViewContextMenuStrip.ResumeLayout(false);
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.csvEditorToolStrip.ResumeLayout(false);
            this.csvEditorToolStrip.PerformLayout();
            this.customContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label delimiterLabel;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Label quoteLabel;
        internal System.Windows.Forms.DataGridView csvGridView;
        internal System.Windows.Forms.CheckBox headerCheckBox;
        private System.Windows.Forms.ContextMenuStrip gridViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip csvEditorToolStrip;
        private System.Windows.Forms.ToolStripMenuItem undoAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton addNewColumnToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal Customs.CustomToolStripTextBox addNewColumnToolStripTextBox;
        internal Customs.CustomComboBox delimiterComboBox;
        internal Customs.CustomComboBox quoteComboBox;
        internal System.Windows.Forms.Button applyButton;
        internal System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSplitButton undoToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem selectCurrentColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectCurrentRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripDropDownButton selectToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem currentColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        internal System.Windows.Forms.ToolStripButton deleteSelectedColumnsToolStripButton;
        internal System.Windows.Forms.ToolStripButton deleteSelectedRowsToolStripButton;
        internal System.Windows.Forms.ContextMenuStrip customContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem undoCustomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem cutCustomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCustomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteCustomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCustomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem selectAllCustomToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton editHeaderToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton screenshotToolStripButton;
        private System.Windows.Forms.ToolStripButton cellWrapToolStripButton;
    }
}
