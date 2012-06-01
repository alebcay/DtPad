using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Translate text DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class TranslateText : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            SetLanguage();

            sourceImageComboBoxEdit.EditValue = LanguageUtil.GetLongCultureForGoogleTranslator(ConfigUtil.GetStringParameter("Translation").Substring(0, 2));
            destinationImageComboBoxEdit.EditValue = LanguageUtil.GetLongCultureForGoogleTranslator(ConfigUtil.GetStringParameter("Translation").Substring(3, 2));
        }

        private void TranslateText_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void translateButton_Click(object sender, EventArgs e)
        {
            if (sourceImageComboBoxEdit.SelectedItem.ToString() == destinationImageComboBoxEdit.SelectedItem.ToString())
            {
                WindowManager.ShowInfoBox(this, LanguageUtil.GetCurrentLanguageString("SourceEqualToDestionation", Name));
                return;
            }

            String translation = LanguageUtil.GetReallyShortCultureForGoogleTranslator(sourceImageComboBoxEdit.SelectedItem.ToString()) + "|" + LanguageUtil.GetReallyShortCultureForGoogleTranslator(destinationImageComboBoxEdit.SelectedItem.ToString());
            ConfigUtil.UpdateParameter("Translation", translation);
            
            DialogResult = DialogResult.OK;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            object sourceLanguage = sourceImageComboBoxEdit.EditValue;
            sourceImageComboBoxEdit.EditValue = destinationImageComboBoxEdit.EditValue;
            destinationImageComboBoxEdit.EditValue = sourceLanguage;
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            translateTextToolTip.SetToolTip(switchButton, LanguageUtil.GetCurrentLanguageString("switchButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
