using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Insert tag into text DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class TagEntry : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            LanguageUtil.SetCurrentLanguage(this);
        }

        private void customRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            customTextBox1.Enabled = customRadioButton.Checked;
            customTextBox2.Enabled = customRadioButton.Checked;
        }

        private void tagTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !String.IsNullOrEmpty(tagTextBox.Text);
        }

        private void contentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = ControlUtil.FocusedTextBoxCanUndo(sender);
        }

        private void TagEntry_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            if (customRadioButton.Checked && (String.IsNullOrEmpty(customTextBox1.Text) || String.IsNullOrEmpty(customTextBox2.Text)))
            {
                WindowManager.ShowAlertBox(this, LanguageUtil.GetCurrentLanguageString("CustomTagTypeEmpty", Name));
                return;
            }

            FormatManager.TagType type = FormatManager.TagType.XHTML; //Default
            FormatManager.TagExtension extension = FormatManager.TagExtension.Complete; //Default

            if (forumRadioButton.Checked)
            {
                type = FormatManager.TagType.Forum;
            }
            else if (customRadioButton.Checked)
            {
                type = FormatManager.TagType.Custom;
            }

            if (shortRadioButton.Checked)
            {
                extension = FormatManager.TagExtension.Short;
            }

            if (customRadioButton.Checked)
            {
                FormatManager.InsertTag(form, tagTextBox.Text, type, extension, customTextBox1.Text, customTextBox2.Text);
            }
            else
            {
                FormatManager.InsertTag(form, tagTextBox.Text, type, extension);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Button Methods
    }
}
