using System;
using System.Drawing;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad.MessageBoxes
{
    /// <summary>
    /// Alert message box form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class AlertO : Form
    {
        internal AlertO(Form parent, String message)
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);

            if (parent == null)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }

            alertLabel.Text = message;
            if (alertLabel.Width <= ConstantUtil.standardMessageWidth)
            {
                return;
            }

            Width = Width + alertLabel.Width - ConstantUtil.standardMessageWidth;
            okButton.Location = new Point(Width - ConstantUtil.standardButtonPositionFromRight, okButton.Location.Y);
        }

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion Button Methods
    }
}
