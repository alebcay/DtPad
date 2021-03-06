﻿namespace DtPad.UserControls
{
    partial class CalculatorPanel
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
            this.calcTextBox = new Customs.CustomTextBox();
            this.calculationTextBox = new Customs.CustomTextBox();
            this.calculatorToolStrip = new System.Windows.Forms.ToolStrip();
            this.clearCalculatorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.thousandSepToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel = new DtPad.Customs.CustomTableLayoutPanel();
            this.plusButton = new System.Windows.Forms.Button();
            this.commaButton = new System.Windows.Forms.Button();
            this.signButton = new System.Windows.Forms.Button();
            this.zeroButton = new System.Windows.Forms.Button();
            this.equalButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.starButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.barButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.eightButton = new System.Windows.Forms.Button();
            this.sevenButton = new System.Windows.Forms.Button();
            this.backspaceButton = new System.Windows.Forms.Button();
            this.calculatorToolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculatorToolStrip
            // 
            this.calculatorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearCalculatorToolStripButton,
            this.toolStripSeparator1,
            this.thousandSepToolStripButton});
            this.calculatorToolStrip.Location = new System.Drawing.Point(0, 0);
            this.calculatorToolStrip.Name = "calculatorToolStrip";
            this.calculatorToolStrip.Size = new System.Drawing.Size(206, 25);
            this.calculatorToolStrip.TabIndex = 2;
            this.calculatorToolStrip.Text = "toolStrip1";
            // 
            // clearCalculatorToolStripButton
            // 
            this.clearCalculatorToolStripButton.Image = global::DtPad.ToolbarResource.bin;
            this.clearCalculatorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearCalculatorToolStripButton.Name = "clearCalculatorToolStripButton";
            this.clearCalculatorToolStripButton.Size = new System.Drawing.Size(111, 22);
            this.clearCalculatorToolStripButton.Text = "Clear Calculator";
            this.clearCalculatorToolStripButton.Click += new System.EventHandler(this.clearCalculatorToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // thousandSepToolStripButton
            // 
            this.thousandSepToolStripButton.Checked = true;
            this.thousandSepToolStripButton.CheckOnClick = true;
            this.thousandSepToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.thousandSepToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.thousandSepToolStripButton.Image = global::DtPad.ToolbarResource.thousands;
            this.thousandSepToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.thousandSepToolStripButton.Name = "thousandSepToolStripButton";
            this.thousandSepToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.thousandSepToolStripButton.Text = "Use Thousands Separator";
            this.thousandSepToolStripButton.CheckedChanged += new System.EventHandler(this.thousandSepToolStripButton_CheckedChanged);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Controls.Add(this.plusButton, 4, 4);
            this.tableLayoutPanel.Controls.Add(this.commaButton, 3, 4);
            this.tableLayoutPanel.Controls.Add(this.signButton, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.zeroButton, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.equalButton, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.minusButton, 4, 3);
            this.tableLayoutPanel.Controls.Add(this.threeButton, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.twoButton, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.oneButton, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.starButton, 4, 2);
            this.tableLayoutPanel.Controls.Add(this.sixButton, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.fiveButton, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.fourButton, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.cancelButton, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.barButton, 4, 1);
            this.tableLayoutPanel.Controls.Add(this.nineButton, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.eightButton, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.sevenButton, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.backspaceButton, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.calcTextBox, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel.HorizontalLine = true;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 209);
            this.tableLayoutPanel.MarginLeftHorizontalLine = 0;
            this.tableLayoutPanel.MarginTopHorizontalLine = 0;
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(206, 176);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // plusButton
            // 
            this.plusButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plusButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.plusButton.Location = new System.Drawing.Point(167, 143);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(36, 30);
            this.plusButton.TabIndex = 19;
            this.plusButton.Tag = "DontTranslate";
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.plusButton_KeyDown);
            this.plusButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.operationButton_MouseClick);
            // 
            // commaButton
            // 
            this.commaButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commaButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.commaButton.Location = new System.Drawing.Point(126, 143);
            this.commaButton.Name = "commaButton";
            this.commaButton.Size = new System.Drawing.Size(35, 30);
            this.commaButton.TabIndex = 18;
            this.commaButton.Tag = "DontTranslate";
            this.commaButton.Text = ",";
            this.commaButton.UseVisualStyleBackColor = true;
            this.commaButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commaButton_KeyDown);
            this.commaButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.commaButton_MouseClick);
            // 
            // signButton
            // 
            this.signButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.signButton.Location = new System.Drawing.Point(85, 143);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(35, 30);
            this.signButton.TabIndex = 17;
            this.signButton.Tag = "DontTranslate";
            this.signButton.Text = "+/-";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.signButton_KeyDown);
            this.signButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.signButton_MouseClick);
            // 
            // zeroButton
            // 
            this.zeroButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zeroButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.zeroButton.Location = new System.Drawing.Point(44, 143);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(35, 30);
            this.zeroButton.TabIndex = 16;
            this.zeroButton.Tag = "DontTranslate";
            this.zeroButton.Text = "0";
            this.zeroButton.UseVisualStyleBackColor = true;
            this.zeroButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zeroButton_KeyDown);
            this.zeroButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberButton_MouseClick);
            // 
            // equalButton
            // 
            this.equalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.equalButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.equalButton.Location = new System.Drawing.Point(3, 108);
            this.equalButton.Name = "equalButton";
            this.tableLayoutPanel.SetRowSpan(this.equalButton, 2);
            this.equalButton.Size = new System.Drawing.Size(35, 65);
            this.equalButton.TabIndex = 11;
            this.equalButton.Tag = "DontTranslate";
            this.equalButton.Text = "=";
            this.equalButton.UseVisualStyleBackColor = true;
            this.equalButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.equalButton_KeyDown);
            this.equalButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.equalButton_MouseClick);
            // 
            // minusButton
            // 
            this.minusButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minusButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.minusButton.Location = new System.Drawing.Point(167, 108);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(36, 29);
            this.minusButton.TabIndex = 15;
            this.minusButton.Tag = "DontTranslate";
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.minusButton_KeyDown);
            this.minusButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.operationButton_MouseClick);
            // 
            // threeButton
            // 
            this.threeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.threeButton.Location = new System.Drawing.Point(126, 108);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(35, 29);
            this.threeButton.TabIndex = 14;
            this.threeButton.Tag = "DontTranslate";
            this.threeButton.Text = "3";
            this.threeButton.UseVisualStyleBackColor = true;
            this.threeButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.threeButton_KeyDown);
            this.threeButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberButton_MouseClick);
            // 
            // twoButton
            // 
            this.twoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twoButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.twoButton.Location = new System.Drawing.Point(85, 108);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(35, 29);
            this.twoButton.TabIndex = 13;
            this.twoButton.Tag = "DontTranslate";
            this.twoButton.Text = "2";
            this.twoButton.UseVisualStyleBackColor = true;
            this.twoButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.twoButton_KeyDown);
            this.twoButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberButton_MouseClick);
            // 
            // oneButton
            // 
            this.oneButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oneButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.oneButton.Location = new System.Drawing.Point(44, 108);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(35, 29);
            this.oneButton.TabIndex = 12;
            this.oneButton.Tag = "DontTranslate";
            this.oneButton.Text = "1";
            this.oneButton.UseVisualStyleBackColor = true;
            this.oneButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.oneButton_KeyDown);
            this.oneButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberButton_MouseClick);
            // 
            // starButton
            // 
            this.starButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.starButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.starButton.Location = new System.Drawing.Point(167, 73);
            this.starButton.Name = "starButton";
            this.starButton.Size = new System.Drawing.Size(36, 29);
            this.starButton.TabIndex = 10;
            this.starButton.Tag = "DontTranslate";
            this.starButton.Text = "*";
            this.starButton.UseVisualStyleBackColor = true;
            this.starButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.starButton_KeyDown);
            this.starButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.operationButton_MouseClick);
            // 
            // sixButton
            // 
            this.sixButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sixButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sixButton.Location = new System.Drawing.Point(126, 73);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(35, 29);
            this.sixButton.TabIndex = 9;
            this.sixButton.Tag = "DontTranslate";
            this.sixButton.Text = "6";
            this.sixButton.UseVisualStyleBackColor = true;
            this.sixButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sixButton_KeyDown);
            this.sixButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberButton_MouseClick);
            // 
            // fiveButton
            // 
            this.fiveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fiveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.fiveButton.Location = new System.Drawing.Point(85, 73);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(35, 29);
            this.fiveButton.TabIndex = 8;
            this.fiveButton.Tag = "DontTranslate";
            this.fiveButton.Text = "5";
            this.fiveButton.UseVisualStyleBackColor = true;
            this.fiveButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fiveButton_KeyDown);
            this.fiveButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberButton_MouseClick);
            // 
            // fourButton
            // 
            this.fourButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fourButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.fourButton.Location = new System.Drawing.Point(44, 73);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(35, 29);
            this.fourButton.TabIndex = 7;
            this.fourButton.Tag = "DontTranslate";
            this.fourButton.Text = "4";
            this.fourButton.UseVisualStyleBackColor = true;
            this.fourButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fourButton_KeyDown);
            this.fourButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberButton_MouseClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(3, 73);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(35, 29);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Tag = "DontTranslate";
            this.cancelButton.Text = "C";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cancelButton_KeyDown);
            this.cancelButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cancelButton_MouseClick);
            // 
            // barButton
            // 
            this.barButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.barButton.Location = new System.Drawing.Point(167, 38);
            this.barButton.Name = "barButton";
            this.barButton.Size = new System.Drawing.Size(36, 29);
            this.barButton.TabIndex = 5;
            this.barButton.Tag = "DontTranslate";
            this.barButton.Text = "/";
            this.barButton.UseVisualStyleBackColor = true;
            this.barButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.barButton_KeyDown);
            this.barButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.operationButton_MouseClick);
            // 
            // nineButton
            // 
            this.nineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nineButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.nineButton.Location = new System.Drawing.Point(126, 38);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(35, 29);
            this.nineButton.TabIndex = 4;
            this.nineButton.Tag = "DontTranslate";
            this.nineButton.Text = "9";
            this.nineButton.UseVisualStyleBackColor = true;
            this.nineButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nineButton_KeyDown);
            this.nineButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberButton_MouseClick);
            // 
            // eightButton
            // 
            this.eightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eightButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.eightButton.Location = new System.Drawing.Point(85, 38);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(35, 29);
            this.eightButton.TabIndex = 3;
            this.eightButton.Tag = "DontTranslate";
            this.eightButton.Text = "8";
            this.eightButton.UseVisualStyleBackColor = true;
            this.eightButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eightButton_KeyDown);
            this.eightButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberButton_MouseClick);
            // 
            // sevenButton
            // 
            this.sevenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sevenButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sevenButton.Location = new System.Drawing.Point(44, 38);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(35, 29);
            this.sevenButton.TabIndex = 2;
            this.sevenButton.Tag = "DontTranslate";
            this.sevenButton.Text = "7";
            this.sevenButton.UseVisualStyleBackColor = true;
            this.sevenButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sevenButton_KeyDown);
            this.sevenButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberButton_MouseClick);
            // 
            // backspaceButton
            // 
            this.backspaceButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backspaceButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backspaceButton.Location = new System.Drawing.Point(3, 38);
            this.backspaceButton.Name = "backspaceButton";
            this.backspaceButton.Size = new System.Drawing.Size(35, 29);
            this.backspaceButton.TabIndex = 1;
            this.backspaceButton.Tag = "DontTranslate";
            this.backspaceButton.Text = "<";
            this.backspaceButton.UseVisualStyleBackColor = true;
            this.backspaceButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.backspaceButton_KeyDown);
            this.backspaceButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.backspaceButton_MouseClick);
            // 
            // calcTextBox
            // 
            this.calcTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.calcTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel.SetColumnSpan(this.calcTextBox, 5);
            this.calcTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.calcTextBox.Location = new System.Drawing.Point(3, 19);
            this.calcTextBox.Name = "calcTextBox";
            this.calcTextBox.ReadOnly = true;
            this.calcTextBox.Size = new System.Drawing.Size(200, 13);
            this.calcTextBox.TabIndex = 0;
            this.calcTextBox.Tag = "DontTranslate";
            this.calcTextBox.Text = "0,";
            this.calcTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.calcTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calcTextBox_KeyDown);
            // 
            // calculationTextBox
            // 
            this.calculationTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.calculationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.calculationTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calculationTextBox.Location = new System.Drawing.Point(0, 25);
            this.calculationTextBox.Multiline = true;
            this.calculationTextBox.Name = "calculationTextBox";
            this.calculationTextBox.ReadOnly = true;
            this.calculationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.calculationTextBox.Size = new System.Drawing.Size(206, 184);
            this.calculationTextBox.TabIndex = 0;
            this.calculationTextBox.Tag = "DontTranslate";
            this.calculationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calculationTextBox_KeyDown);
            // 
            // CalculatorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calculationTextBox);
            this.Controls.Add(this.calculatorToolStrip);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "CalculatorPanel";
            this.Size = new System.Drawing.Size(206, 385);
            this.Load += new System.EventHandler(this.CalculatorPanel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CalculatorPanel_KeyDown);
            this.calculatorToolStrip.ResumeLayout(false);
            this.calculatorToolStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Customs.CustomTextBox calculationTextBox;
        private Customs.CustomTableLayoutPanel tableLayoutPanel;
        internal System.Windows.Forms.Button plusButton;
        internal System.Windows.Forms.Button commaButton;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Button zeroButton;
        internal System.Windows.Forms.Button equalButton;
        internal System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button twoButton;
        private System.Windows.Forms.Button oneButton;
        internal System.Windows.Forms.Button starButton;
        private System.Windows.Forms.Button sixButton;
        private System.Windows.Forms.Button fiveButton;
        private System.Windows.Forms.Button fourButton;
        private System.Windows.Forms.Button cancelButton;
        internal System.Windows.Forms.Button barButton;
        private System.Windows.Forms.Button nineButton;
        private System.Windows.Forms.Button eightButton;
        private System.Windows.Forms.Button sevenButton;
        private System.Windows.Forms.Button backspaceButton;
        internal Customs.CustomTextBox calcTextBox;
        internal System.Windows.Forms.ToolStrip calculatorToolStrip;
        private System.Windows.Forms.ToolStripButton clearCalculatorToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton thousandSepToolStripButton;
    }
}
