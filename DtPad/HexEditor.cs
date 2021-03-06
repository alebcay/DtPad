﻿using System;
using System.Text;
using System.Windows.Forms;
using Be.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Exadecimal view DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class HexEditor : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            SetLanguage();

            Form1 form = (Form1)Owner;

            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            //Encoding encoding = String.IsNullOrEmpty(pageTextBox.CustomEncoding) ? EncodingUtil.GetDefaultEncoding() : TabUtil.GetTabTextEncoding(pagesTabControl.SelectedTabPage);
            Encoding encoding = TabUtil.GetTabTextEncoding(pagesTabControl.SelectedTabPage);

            byte[] byteArray = encoding.GetBytes(pageTextBox.Text);
            byteArray = Encoding.Convert(encoding, Encoding.Default, byteArray);

            hexBox.ByteProvider = new DynamicByteProvider(byteArray);
            hexBox.Font = pageTextBox.Font;
            hexBox.ForeColor = pageTextBox.ForeColor;
            hexBox.BackColor = pageTextBox.BackColor;

            Width--;
        }

        #endregion Window Methods

        #region Button Methods

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region Context Menu Methods

        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            hexBox.Copy();
        }

        private void copyHexadecimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hexBox.CopyHex();
        }

        private void selectAllToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            hexBox.SelectAll();
        }

        #endregion Context Menu Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, textMenuStrip.Items);
        }

        #endregion Private Methods
    }
}
