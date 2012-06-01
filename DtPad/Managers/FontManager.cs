using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Font operations manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class FontManager
    {
        private const String className = "FontManager";

        #region Internal Methods

        internal static Font GetFontFromSelection(FontSelect form)
        {
            FontEdit fontEdit = form.fontEdit;
            ColorEdit colorEdit = form.colorEdit;
            NumericUpDown sizeNumericUpDown = form.sizeNumericUpDown;
            CheckBox boldCheckBox = form.boldCheckBox;
            CheckBox italicCheckBox = form.italicCheckBox;
            CheckBox underlinedCheckBox = form.underlinedCheckBox;
            RichTextBox previewTextBox = form.previewTextBox;

            Font font = SetFontWithStyle(fontEdit.EditValue.ToString(), (float)sizeNumericUpDown.Value, boldCheckBox.Checked, italicCheckBox.Checked, underlinedCheckBox.Checked);
            previewTextBox.Font = font;
            previewTextBox.ForeColor = (Color)colorEdit.EditValue;

            return font;
        }

        internal static void ResetFont(FontSelect form)
        {
            FontEdit fontEdit = form.fontEdit;
            ColorEdit colorEdit = form.colorEdit;
            NumericUpDown sizeNumericUpDown = form.sizeNumericUpDown;
            CheckBox boldCheckBox = form.boldCheckBox;
            CheckBox italicCheckBox = form.italicCheckBox;
            CheckBox underlinedCheckBox = form.underlinedCheckBox;
            RichTextBox previewTextBox = form.previewTextBox;
            
            if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("ResetQuestion", className)) == DialogResult.No)
            {
                return;
            }

            fontEdit.SelectedItem = "Courier New";
            colorEdit.EditValue = Color.FromArgb(255, 0, 0, 0);
            sizeNumericUpDown.Value = 10;
            boldCheckBox.Checked = false;
            italicCheckBox.Checked = false;
            underlinedCheckBox.Checked = false;

            previewTextBox.Font = new Font("Courier New", 10);
            previewTextBox.ForeColor = (Color)colorEdit.EditValue;
        }

        internal static String SetARGBString(Color color)
        {   
            return "255;" + color.R + ";" + color.G + ";" + color.B;
        }

        internal static Font SetFontWithStyle(String name, float size, bool bold, bool italic, bool underline)
        {
            FontStyle style = FontStyle.Regular;

            if (bold)
            {
                style = style | FontStyle.Bold;
            }
            if (italic)
            {
                style = style | FontStyle.Italic;
            }
            if (underline)
            {
                style = style | FontStyle.Underline;
            }

            return new Font(name, size, style);
        }

        #endregion Internal Methods
    }
}
