using WmHelp.XmlGrid;

namespace DtPad
{
    partial class XmlEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlEditor));
            this.xmlGridView = new WmHelp.XmlGrid.XmlGridView();
            this.closeButton = new System.Windows.Forms.Button();
            this.collapseButton = new System.Windows.Forms.Button();
            this.expandButton = new System.Windows.Forms.Button();
            this.xmlEditorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // xmlGridView
            // 
            this.xmlGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlGridView.AutoHeightCells = true;
            this.xmlGridView.BackColor = System.Drawing.SystemColors.Window;
            this.xmlGridView.Cell = null;
            this.xmlGridView.DefaultColumnWidth = 150;
            this.xmlGridView.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlGridView.Footer = null;
            this.xmlGridView.Location = new System.Drawing.Point(12, 12);
            this.xmlGridView.Name = "xmlGridView";
            this.xmlGridView.ShowColumnHeader = false;
            this.xmlGridView.Size = new System.Drawing.Size(498, 220);
            this.xmlGridView.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(435, 238);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // collapseButton
            // 
            this.collapseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.collapseButton.Image = global::DtPad.ToolbarResource.move_up;
            this.collapseButton.Location = new System.Drawing.Point(12, 238);
            this.collapseButton.Name = "collapseButton";
            this.collapseButton.Size = new System.Drawing.Size(23, 23);
            this.collapseButton.TabIndex = 1;
            this.xmlEditorToolTip.SetToolTip(this.collapseButton, "Collapse all nodes");
            this.collapseButton.UseVisualStyleBackColor = true;
            this.collapseButton.Click += new System.EventHandler(this.collapseButton_Click);
            // 
            // expandButton
            // 
            this.expandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.expandButton.Image = global::DtPad.ToolbarResource.move_down;
            this.expandButton.Location = new System.Drawing.Point(41, 238);
            this.expandButton.Name = "expandButton";
            this.expandButton.Size = new System.Drawing.Size(23, 23);
            this.expandButton.TabIndex = 2;
            this.xmlEditorToolTip.SetToolTip(this.expandButton, "Expands all nodes");
            this.expandButton.UseVisualStyleBackColor = true;
            this.expandButton.Click += new System.EventHandler(this.expandButton_Click);
            // 
            // XmlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 273);
            this.Controls.Add(this.expandButton);
            this.Controls.Add(this.collapseButton);
            this.Controls.Add(this.xmlGridView);
            this.Controls.Add(this.closeButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XmlEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Tree View";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private XmlGridView xmlGridView;
        private System.Windows.Forms.Button collapseButton;
        private System.Windows.Forms.Button expandButton;
        private System.Windows.Forms.ToolTip xmlEditorToolTip;
    }
}
