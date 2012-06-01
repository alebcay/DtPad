using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Color selection DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class ColorSelect : Form
    {
        #region Window Methods

        internal void InitializeForm(Color color)
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);

            colorEdit.Color = color;

            previewTextBox.Font = ConfigUtil.GetFontParameter("FontInUse");
            String[] argbFontColor = ConfigUtil.GetStringParameter("FontInUseColorARGB").Split(new[] { ';' });
            previewTextBox.ForeColor = Color.FromArgb(Convert.ToInt32(argbFontColor[0]), Convert.ToInt32(argbFontColor[1]), Convert.ToInt32(argbFontColor[2]), Convert.ToInt32(argbFontColor[3]));
            previewTextBox.BackColor = color;
        }

        private void ColorSelect_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        private void colorEdit_ColorChanged(object sender, EventArgs e)
        {
            previewTextBox.BackColor = (Color)colorEdit.EditValue;
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Owner.GetType() == typeof(Options))
            {
                Options form = (Options)Owner;

                form.TextBackgroundColor = (Color)colorEdit.EditValue;
            }

            WindowManager.HiddenForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Button Methods
    }
}
