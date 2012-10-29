using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Font selection DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class FontSelect : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            if (Owner.GetType() == typeof(Form1))
            {
                Form1 form = (Form1)Owner;
                Font font = form.TextFont;
                Color color = form.TextFontColor;

                fontEdit.SelectedItem = font.Name;
                colorEdit.Color = color;
                sizeNumericUpDown.Value = Convert.ToDecimal(font.Size);
                sizeListBox.SelectedItem = Convert.ToDecimal(font.Size);
                boldCheckBox.Checked = font.Bold;
                italicCheckBox.Checked = font.Italic;
                underlinedCheckBox.Checked = font.Underline;

                previewTextBox.Font = FontManager.SetFontWithStyle(font.Name, font.Size, font.Bold, font.Italic, font.Underline);
                previewTextBox.ForeColor = color;
            }
            else if (Owner.GetType() == typeof(Options))
            {
                Options form = (Options)Owner;
                Font font = form.TextFont;
                Color color = form.TextFontColor;

                fontEdit.SelectedItem = font.Name;
                colorEdit.Color = color;
                sizeNumericUpDown.Value = Convert.ToDecimal(font.Size);
                sizeListBox.SelectedItem = Convert.ToDecimal(font.Size);
                boldCheckBox.Checked = font.Bold;
                italicCheckBox.Checked = font.Italic;
                underlinedCheckBox.Checked = font.Underline;

                previewTextBox.Font = FontManager.SetFontWithStyle(font.Name, font.Size, font.Bold, font.Italic, font.Underline);
                previewTextBox.ForeColor = color;
            }

            fontEdit.Visible = true;
        }

        private void FontSelect_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void fontEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontManager.GetFontFromSelection(this);
        }

        private void boldCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FontManager.GetFontFromSelection(this);
        }

        private void italicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FontManager.GetFontFromSelection(this);
        }

        private void underlinedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FontManager.GetFontFromSelection(this);
        }

        private void colorEdit_EditValueChanged(object sender, EventArgs e)
        {
            FontManager.GetFontFromSelection(this);
        }

        private void sizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FontManager.GetFontFromSelection(this);

            sizeListBox.SelectedItem = IsDecimalContainedInListBox(sizeListBox, sizeNumericUpDown.Value) ? sizeNumericUpDown.Value.ToString() : null;
        }

        private void sizeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sizeListBox.SelectedItem != null)
            {
                sizeNumericUpDown.Value = Convert.ToDecimal(sizeListBox.SelectedItem);
            }
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Owner.GetType() == typeof(Form1))
            {
                Form1 form = (Form1)Owner;

                form.SetMainFont(FontManager.GetFontFromSelection(this)); //form.TextFont = FontManager.GetFontFromSelection(this);
                form.TextFontColor = (Color)colorEdit.EditValue;
            }
            else if (Owner.GetType() == typeof(Options))
            {
                Options form = (Options)Owner;

                form.TextFont = FontManager.GetFontFromSelection(this);
                form.TextFontColor = (Color)colorEdit.EditValue;
            }

            WindowManager.CloseForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            FontManager.ResetFont(this);
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(sizeNumericUpDown);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.PasteControl(sizeNumericUpDown);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(sizeNumericUpDown);
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private static bool IsDecimalContainedInListBox(ListBox listBox, decimal valueToSearch)
        {
            //for (int i = 0; i < listBox.Items.Count; i++)
            //{
            //    decimal item = Convert.ToDecimal(listBox.Items[i]);

            //    if (item == valueToSearch)
            //    {
            //        return true;
            //    }
            //}

            return (from object t in listBox.Items select Convert.ToDecimal(t)).Any(item => item == valueToSearch);
        }

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, contentContextMenuStrip.Items);
        }

        #endregion Private Methods
    }
}
