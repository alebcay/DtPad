using System;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Splash DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Splash : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);
        }

        private void doNotShowCheckBox_Click(object sender, EventArgs e)
        {
            ConfigUtil.UpdateParameter("ShowSplashScreen", "false");
        }

        #endregion Window Methods
    }
}
