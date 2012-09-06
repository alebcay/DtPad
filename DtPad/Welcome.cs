using System;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Welcome DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Welcome : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);
            ConfigUtil.UpdateParameter("WelcomeShown", true.ToString());

            SetFamilyEdition();
        }

        #endregion Window Methods

        #region Button Methods

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetFamilyEdition()
        {
            #if ReleaseFE
            signLabel.Text = LanguageUtil.GetCurrentLanguageString("signLabel_FE", Name);
            #endif
        }

        #endregion Private Methods
    }
}
