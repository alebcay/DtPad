namespace DtPad.UserControls
{
    partial class SearchPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchTextBox = new Customs.CustomTextBox();
            this.replaceTextBox = new Customs.CustomTextBox();
            this.searchReplaceToolStrip = new System.Windows.Forms.ToolStrip();
            this.findFirstToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.findNextToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.findPreviousToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.findLastToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.searchCountToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.replaceToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.replacePreviousToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.replaceAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
            this.highlightsResultsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.historyToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.patternToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.closeToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.searchReplaceCentralPanel = new System.Windows.Forms.Panel();
            this.rightSearchReplacePanel = new System.Windows.Forms.Panel();
            this.searchAllTabsCheckBox = new Customs.CustomCheckBox();
            this.loopCheckBox = new Customs.CustomCheckBox();
            this.caseCheckBox = new Customs.CustomCheckBox();
            this.searchReplaceLeftPanel = new System.Windows.Forms.Panel();
            this.replaceLabel = new System.Windows.Forms.Label();
            this.searchLabel = new System.Windows.Forms.Label();
            this.regularExpressionsCheckBox = new Customs.CustomCheckBox();
            this.searchReplaceToolStrip.SuspendLayout();
            this.searchReplaceCentralPanel.SuspendLayout();
            this.rightSearchReplacePanel.SuspendLayout();
            this.searchReplaceLeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchTextBox.Location = new System.Drawing.Point(0, 0);
            this.searchTextBox.Multiline = true;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.searchTextBox.Size = new System.Drawing.Size(564, 57);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Tag = "DontTranslate";
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.replaceTextBox.Location = new System.Drawing.Point(0, 57);
            this.replaceTextBox.Multiline = true;
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.replaceTextBox.Size = new System.Drawing.Size(564, 37);
            this.replaceTextBox.TabIndex = 1;
            this.replaceTextBox.Tag = "DontTranslate";
            // 
            // searchReplaceToolStrip
            // 
            this.searchReplaceToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findFirstToolStripButton,
            this.findNextToolStripButton,
            this.findPreviousToolStripButton,
            this.findLastToolStripButton,
            this.searchCountToolStripButton,
            this.toolStripSeparator17,
            this.replaceToolStripButton2,
            this.replacePreviousToolStripButton,
            this.replaceAllToolStripButton,
            this.toolStripSeparator33,
            this.highlightsResultsToolStripButton,
            this.historyToolStripDropDownButton,
            this.toolStripSeparator1,
            this.patternToolStripButton,
            this.closeToolStripButton2});
            this.searchReplaceToolStrip.Location = new System.Drawing.Point(0, 0);
            this.searchReplaceToolStrip.Name = "searchReplaceToolStrip";
            this.searchReplaceToolStrip.Size = new System.Drawing.Size(817, 25);
            this.searchReplaceToolStrip.TabIndex = 0;
            this.searchReplaceToolStrip.Text = "toolStrip1";
            // 
            // findFirstToolStripButton
            // 
            this.findFirstToolStripButton.Image = global::DtPad.ToolbarResource.search;
            this.findFirstToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findFirstToolStripButton.Name = "findFirstToolStripButton";
            this.findFirstToolStripButton.Size = new System.Drawing.Size(75, 22);
            this.findFirstToolStripButton.Text = "Find First";
            this.findFirstToolStripButton.Click += new System.EventHandler(this.findFirstToolStripButton_Click);
            // 
            // findNextToolStripButton
            // 
            this.findNextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.findNextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findNextToolStripButton.Name = "findNextToolStripButton";
            this.findNextToolStripButton.Size = new System.Drawing.Size(61, 22);
            this.findNextToolStripButton.Text = "Find Next";
            this.findNextToolStripButton.Click += new System.EventHandler(this.findNextToolStripButton_Click);
            // 
            // findPreviousToolStripButton
            // 
            this.findPreviousToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.findPreviousToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findPreviousToolStripButton.Name = "findPreviousToolStripButton";
            this.findPreviousToolStripButton.Size = new System.Drawing.Size(82, 22);
            this.findPreviousToolStripButton.Text = "Find Previous";
            this.findPreviousToolStripButton.Click += new System.EventHandler(this.findPreviousToolStripButton_Click);
            // 
            // findLastToolStripButton
            // 
            this.findLastToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.findLastToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findLastToolStripButton.Name = "findLastToolStripButton";
            this.findLastToolStripButton.Size = new System.Drawing.Size(58, 22);
            this.findLastToolStripButton.Text = "Find Last";
            this.findLastToolStripButton.Click += new System.EventHandler(this.findLastToolStripButton_Click);
            // 
            // searchCountToolStripButton
            // 
            this.searchCountToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchCountToolStripButton.Image = global::DtPad.ToolbarResource.search_count;
            this.searchCountToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchCountToolStripButton.Name = "searchCountToolStripButton";
            this.searchCountToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.searchCountToolStripButton.Text = "Count Occurences";
            this.searchCountToolStripButton.Click += new System.EventHandler(this.searchCountToolStripButton_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // replaceToolStripButton2
            // 
            this.replaceToolStripButton2.Image = global::DtPad.ToolbarResource.replace;
            this.replaceToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.replaceToolStripButton2.Name = "replaceToolStripButton2";
            this.replaceToolStripButton2.Size = new System.Drawing.Size(68, 22);
            this.replaceToolStripButton2.Text = "Replace";
            this.replaceToolStripButton2.Click += new System.EventHandler(this.replaceToolStripButton2_Click);
            // 
            // replacePreviousToolStripButton
            // 
            this.replacePreviousToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.replacePreviousToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.replacePreviousToolStripButton.Name = "replacePreviousToolStripButton";
            this.replacePreviousToolStripButton.Size = new System.Drawing.Size(100, 22);
            this.replacePreviousToolStripButton.Text = "Replace Previous";
            this.replacePreviousToolStripButton.Click += new System.EventHandler(this.replacePreviousToolStripButton_Click);
            // 
            // replaceAllToolStripButton
            // 
            this.replaceAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.replaceAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.replaceAllToolStripButton.Name = "replaceAllToolStripButton";
            this.replaceAllToolStripButton.Size = new System.Drawing.Size(69, 22);
            this.replaceAllToolStripButton.Text = "Replace All";
            this.replaceAllToolStripButton.Click += new System.EventHandler(this.replaceAllToolStripButton_Click);
            // 
            // toolStripSeparator33
            // 
            this.toolStripSeparator33.Name = "toolStripSeparator33";
            this.toolStripSeparator33.Size = new System.Drawing.Size(6, 25);
            // 
            // highlightsResultsToolStripButton
            // 
            this.highlightsResultsToolStripButton.CheckOnClick = true;
            this.highlightsResultsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.highlightsResultsToolStripButton.Image = global::DtPad.ToolbarResource.highlighter;
            this.highlightsResultsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.highlightsResultsToolStripButton.Name = "highlightsResultsToolStripButton";
            this.highlightsResultsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.highlightsResultsToolStripButton.Text = "Highlights Results";
            this.highlightsResultsToolStripButton.CheckedChanged += new System.EventHandler(this.highlightsResultsToolStripButton_CheckedChanged);
            // 
            // historyToolStripDropDownButton
            // 
            this.historyToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.historyToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearHistoryToolStripMenuItem,
            this.toolStripSeparator34});
            this.historyToolStripDropDownButton.Image = global::DtPad.ToolbarResource.time;
            this.historyToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.historyToolStripDropDownButton.Name = "historyToolStripDropDownButton";
            this.historyToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.historyToolStripDropDownButton.Text = "History";
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.clearHistoryToolStripMenuItem.Text = "Clear History";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearHistoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator34
            // 
            this.toolStripSeparator34.Name = "toolStripSeparator34";
            this.toolStripSeparator34.Size = new System.Drawing.Size(139, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // patternToolStripButton
            // 
            this.patternToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.patternToolStripButton.Image = global::DtPad.ToolbarResource.pattern;
            this.patternToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.patternToolStripButton.Name = "patternToolStripButton";
            this.patternToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.patternToolStripButton.Text = "Patterns...";
            this.patternToolStripButton.Click += new System.EventHandler(this.patternToolStripButton_Click);
            // 
            // closeToolStripButton2
            // 
            this.closeToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeToolStripButton2.Image = global::DtPad.ToolbarResource.minus;
            this.closeToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeToolStripButton2.Name = "closeToolStripButton2";
            this.closeToolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.closeToolStripButton2.Text = "Close Search Panel";
            this.closeToolStripButton2.Click += new System.EventHandler(this.closeToolStripButton2_Click);
            // 
            // searchReplaceCentralPanel
            // 
            this.searchReplaceCentralPanel.Controls.Add(this.searchTextBox);
            this.searchReplaceCentralPanel.Controls.Add(this.replaceTextBox);
            this.searchReplaceCentralPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchReplaceCentralPanel.Location = new System.Drawing.Point(94, 25);
            this.searchReplaceCentralPanel.Name = "searchReplaceCentralPanel";
            this.searchReplaceCentralPanel.Size = new System.Drawing.Size(564, 94);
            this.searchReplaceCentralPanel.TabIndex = 6;
            // 
            // rightSearchReplacePanel
            // 
            this.rightSearchReplacePanel.Controls.Add(this.regularExpressionsCheckBox);
            this.rightSearchReplacePanel.Controls.Add(this.searchAllTabsCheckBox);
            this.rightSearchReplacePanel.Controls.Add(this.loopCheckBox);
            this.rightSearchReplacePanel.Controls.Add(this.caseCheckBox);
            this.rightSearchReplacePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightSearchReplacePanel.Location = new System.Drawing.Point(658, 25);
            this.rightSearchReplacePanel.Name = "rightSearchReplacePanel";
            this.rightSearchReplacePanel.Size = new System.Drawing.Size(159, 94);
            this.rightSearchReplacePanel.TabIndex = 2;
            // 
            // searchAllTabsCheckBox
            // 
            this.searchAllTabsCheckBox.AutoSize = true;
            this.searchAllTabsCheckBox.Location = new System.Drawing.Point(7, 50);
            this.searchAllTabsCheckBox.Name = "searchAllTabsCheckBox";
            this.searchAllTabsCheckBox.Size = new System.Drawing.Size(122, 17);
            this.searchAllTabsCheckBox.TabIndex = 2;
            this.searchAllTabsCheckBox.Text = "Search Into All Tabs";
            this.searchAllTabsCheckBox.UseVisualStyleBackColor = true;
            // 
            // loopCheckBox
            // 
            this.loopCheckBox.AutoSize = true;
            this.loopCheckBox.Location = new System.Drawing.Point(7, 27);
            this.loopCheckBox.Name = "loopCheckBox";
            this.loopCheckBox.Size = new System.Drawing.Size(118, 17);
            this.loopCheckBox.TabIndex = 1;
            this.loopCheckBox.Text = "Loop At End-Of-File";
            this.loopCheckBox.UseVisualStyleBackColor = true;
            this.loopCheckBox.CheckedChanged += new System.EventHandler(this.loopCheckBox_CheckedChanged);
            // 
            // caseCheckBox
            // 
            this.caseCheckBox.AutoSize = true;
            this.caseCheckBox.Location = new System.Drawing.Point(7, 4);
            this.caseCheckBox.Name = "caseCheckBox";
            this.caseCheckBox.Size = new System.Drawing.Size(96, 17);
            this.caseCheckBox.TabIndex = 0;
            this.caseCheckBox.Text = "Case Sensitive";
            this.caseCheckBox.UseVisualStyleBackColor = true;
            this.caseCheckBox.CheckedChanged += new System.EventHandler(this.caseCheckBox_CheckedChanged);
            // 
            // searchReplaceLeftPanel
            // 
            this.searchReplaceLeftPanel.Controls.Add(this.replaceLabel);
            this.searchReplaceLeftPanel.Controls.Add(this.searchLabel);
            this.searchReplaceLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchReplaceLeftPanel.Location = new System.Drawing.Point(0, 25);
            this.searchReplaceLeftPanel.Name = "searchReplaceLeftPanel";
            this.searchReplaceLeftPanel.Size = new System.Drawing.Size(94, 94);
            this.searchReplaceLeftPanel.TabIndex = 1;
            // 
            // replaceLabel
            // 
            this.replaceLabel.AutoSize = true;
            this.replaceLabel.Location = new System.Drawing.Point(4, 60);
            this.replaceLabel.Name = "replaceLabel";
            this.replaceLabel.Size = new System.Drawing.Size(75, 13);
            this.replaceLabel.TabIndex = 1;
            this.replaceLabel.Text = "Replace With:";
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(4, 4);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(44, 13);
            this.searchLabel.TabIndex = 0;
            this.searchLabel.Text = "Search:";
            // 
            // regularExpressionsCheckBox
            // 
            this.regularExpressionsCheckBox.AutoSize = true;
            this.regularExpressionsCheckBox.Location = new System.Drawing.Point(7, 73);
            this.regularExpressionsCheckBox.Name = "regularExpressionsCheckBox";
            this.regularExpressionsCheckBox.Size = new System.Drawing.Size(144, 17);
            this.regularExpressionsCheckBox.TabIndex = 3;
            this.regularExpressionsCheckBox.Text = "Use Regular Expressions";
            this.regularExpressionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchReplaceCentralPanel);
            this.Controls.Add(this.searchReplaceLeftPanel);
            this.Controls.Add(this.rightSearchReplacePanel);
            this.Controls.Add(this.searchReplaceToolStrip);
            this.Name = "SearchPanel";
            this.Size = new System.Drawing.Size(817, 119);
            this.Load += new System.EventHandler(this.SearchPanel_Load);
            this.searchReplaceToolStrip.ResumeLayout(false);
            this.searchReplaceToolStrip.PerformLayout();
            this.searchReplaceCentralPanel.ResumeLayout(false);
            this.searchReplaceCentralPanel.PerformLayout();
            this.rightSearchReplacePanel.ResumeLayout(false);
            this.rightSearchReplacePanel.PerformLayout();
            this.searchReplaceLeftPanel.ResumeLayout(false);
            this.searchReplaceLeftPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip searchReplaceToolStrip;
        private System.Windows.Forms.ToolStripButton findFirstToolStripButton;
        private System.Windows.Forms.ToolStripButton findNextToolStripButton;
        private System.Windows.Forms.ToolStripButton findPreviousToolStripButton;
        private System.Windows.Forms.ToolStripButton findLastToolStripButton;
        private System.Windows.Forms.ToolStripButton searchCountToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton replaceToolStripButton2;
        private System.Windows.Forms.ToolStripButton replacePreviousToolStripButton;
        private System.Windows.Forms.ToolStripButton replaceAllToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator33;
        internal System.Windows.Forms.ToolStripDropDownButton historyToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator34;
        private System.Windows.Forms.ToolStripButton closeToolStripButton2;
        private System.Windows.Forms.Panel searchReplaceCentralPanel;
        internal Customs.CustomTextBox searchTextBox;
        internal Customs.CustomTextBox replaceTextBox;
        private System.Windows.Forms.Panel rightSearchReplacePanel;
        internal Customs.CustomCheckBox searchAllTabsCheckBox;
        internal Customs.CustomCheckBox loopCheckBox;
        internal Customs.CustomCheckBox caseCheckBox;
        private System.Windows.Forms.Panel searchReplaceLeftPanel;
        private System.Windows.Forms.Label replaceLabel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton patternToolStripButton;
        internal System.Windows.Forms.ToolStripButton highlightsResultsToolStripButton;
        internal Customs.CustomCheckBox regularExpressionsCheckBox;
    }
}
