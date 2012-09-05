using System;
using System.Drawing;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad.MessageBoxes
{
    /// <summary>
    /// Information message box form.
    /// </summary>
    /// <author>Marco Macci�</author>
    internal partial class InfoO : Form
    {
        internal InfoO(Form parent, String message)
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);

            if (parent == null)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }

            infoLabel.Text = message;
            if (infoLabel.Width <= ConstantUtil.standardMessageWidth)
            {
                return;
            }

            Width = Width + infoLabel.Width - ConstantUtil.standardMessageWidth;
        }

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion Button Methods
    }
}
