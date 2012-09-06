using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Sort text function DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class SortText : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);
        }

        private void ascCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            descCheckBox.Checked = !ascCheckBox.Checked;
        }

        private void descCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            ascCheckBox.Checked = !descCheckBox.Checked;
        }

        private void SortText_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, System.EventArgs e)
        {
            Form1 form = (Form1)Owner;

            TextManager.RowSort(form, allTextRadioButton.Checked, descCheckBox.Checked);
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods
    }
}
