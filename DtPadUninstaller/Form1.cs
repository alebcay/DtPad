using System;
using System.Windows.Forms;
using DtPadUninstaller.Managers;
using DtPadUninstaller.Utils;

namespace DtPadUninstaller
{
    /// <summary>
    /// Main DtPadUninstaller form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Form1 : Form
    {
        private readonly String executablePath = String.Empty;
        private String internalCulture;

        internal Form1(String path)
        {
            InitializeComponent();
            executablePath = path;
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip, executablePath);
            SetLanguage();
        }

        #region Button Methods

        private void linkLabel_MouseClick(object sender, MouseEventArgs e)
        {
            OtherManager.StartProcess(this, "mailto:" + ConstantUtil.myEmail, internalCulture);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void uninstallButton_Click(object sender, EventArgs e)
        {
            String message = LanguageUtil.GetCurrentLanguageString("SureUninstall", Name, internalCulture);
            if (WindowManager.ShowQuestionBox(this, message, internalCulture) == DialogResult.No)
            {
                return;
            }

            introPanel.Visible = false;
            updatePanel.Visible = true;
            uninstallButton.Visible = false;
            cancelButton.Enabled = false;
            cancelButton.Text = LanguageUtil.GetCurrentLanguageString("CloseButton", Name, internalCulture);

            UninstallManager.UninstallProcedure(this, internalCulture);

            cancelButton.Enabled = true;
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(updateTextBox);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(updateTextBox);
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private void SetLanguage()
        {
            internalCulture = LanguageUtil.GetReallyShortCulture(ConfigUtil.GetStringParameter("Language", "English", executablePath));
            LanguageUtil.SetCurrentLanguage(this, internalCulture);
        }

        #endregion Private Methods 
    }
}
