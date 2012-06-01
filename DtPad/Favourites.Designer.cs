namespace DtPad
{
    partial class Favourites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Favourites));
            this.favouritesListBox = new System.Windows.Forms.ListBox();
            this.deleteFavouriteButton = new System.Windows.Forms.Button();
            this.addFavouriteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.favouriteToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // favouritesListBox
            // 
            this.favouritesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.favouritesListBox.FormattingEnabled = true;
            this.favouritesListBox.Location = new System.Drawing.Point(12, 12);
            this.favouritesListBox.Name = "favouritesListBox";
            this.favouritesListBox.Size = new System.Drawing.Size(431, 160);
            this.favouritesListBox.TabIndex = 0;
            this.favouritesListBox.SelectedIndexChanged += new System.EventHandler(this.favouritesListBox_SelectedIndexChanged);
            // 
            // deleteFavouriteButton
            // 
            this.deleteFavouriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteFavouriteButton.Enabled = false;
            this.deleteFavouriteButton.Image = global::DtPad.ToolbarResource.minus;
            this.deleteFavouriteButton.Location = new System.Drawing.Point(449, 41);
            this.deleteFavouriteButton.Name = "deleteFavouriteButton";
            this.deleteFavouriteButton.Size = new System.Drawing.Size(23, 23);
            this.deleteFavouriteButton.TabIndex = 2;
            this.favouriteToolTip.SetToolTip(this.deleteFavouriteButton, "Remove selected favourite");
            this.deleteFavouriteButton.UseVisualStyleBackColor = true;
            this.deleteFavouriteButton.Click += new System.EventHandler(this.deleteFavouriteButton_Click);
            // 
            // addFavouriteButton
            // 
            this.addFavouriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addFavouriteButton.Image = global::DtPad.ToolbarResource.plus;
            this.addFavouriteButton.Location = new System.Drawing.Point(449, 12);
            this.addFavouriteButton.Name = "addFavouriteButton";
            this.addFavouriteButton.Size = new System.Drawing.Size(23, 23);
            this.addFavouriteButton.TabIndex = 1;
            this.favouriteToolTip.SetToolTip(this.addFavouriteButton, "Add new favourite");
            this.addFavouriteButton.UseVisualStyleBackColor = true;
            this.addFavouriteButton.Click += new System.EventHandler(this.addFavouriteButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(396, 186);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Image = global::DtPad.ToolbarResource.move_down;
            this.moveDownButton.Location = new System.Drawing.Point(449, 149);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(23, 23);
            this.moveDownButton.TabIndex = 4;
            this.favouriteToolTip.SetToolTip(this.moveDownButton, "Move selected favourite down");
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Image = global::DtPad.ToolbarResource.move_up;
            this.moveUpButton.Location = new System.Drawing.Point(449, 120);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(23, 23);
            this.moveUpButton.TabIndex = 3;
            this.favouriteToolTip.SetToolTip(this.moveUpButton, "Move selected favourite up");
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // Favourites
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 221);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.addFavouriteButton);
            this.Controls.Add(this.deleteFavouriteButton);
            this.Controls.Add(this.favouritesListBox);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Favourites";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Favourites";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Favourites_HelpButtonClicked);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox favouritesListBox;
        private System.Windows.Forms.Button deleteFavouriteButton;
        private System.Windows.Forms.Button addFavouriteButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ToolTip favouriteToolTip;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
    }
}
