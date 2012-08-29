using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// File properties view DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class FileProperties : Form
    {
        private const int maxCharsNumber = 54;
        private String fileName;

        #region Window Methods

        internal void InitializeForm(String inFileName, bool sessionFile = false)
        {
            fileName = inFileName;

            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            if (sessionFile)
            {
                iconPictureBox.Visible = false;
                Text = LanguageUtil.GetCurrentLanguageString("TitleSession", Name);
            }
            
            if (Owner == null)
            {
                return;
            }
            
            try
            {
                String dateTimeFormat = LanguageUtil.GetDateTimeFormat();
                FileInfo fileInfo = new FileInfo(fileName);

                String name = StringUtil.CheckStringLength(fileInfo.Name, maxCharsNumber);
                //String directoryName = StringUtil.CheckStringLength(fileInfo.DirectoryName, maxCharsNumber);
                decimal size = fileInfo.Length;
                decimal highSize = size / 1049129;
                String highSizeStr;
                if (Math.Round(highSize, 1) <= 0)
                {
                    highSize = size / new decimal(1024.27);
                    highSizeStr = String.Format(LanguageUtil.GetInfoCulture(), "{0:0.00}", highSize) + " KB";
                }
                else
                {
                    highSizeStr = String.Format(LanguageUtil.GetInfoCulture(), "{0:0.0}", highSize) + " MB";
                }

                nameLabel.Text = name;
                nameToolTip.SetToolTip(nameLabel, fileInfo.Name);
                directoryLabel.Text = fileInfo.DirectoryName; //directoryName;
                directoryLabel.Select(directoryLabel.Text.Length - 1, 0);
                directoryToolTip.SetToolTip(directoryLabel, fileInfo.DirectoryName);
                creationDateLabel.Text = fileInfo.CreationTime.ToString(dateTimeFormat);
                lastUpdateLabel.Text = fileInfo.LastWriteTime.ToString(dateTimeFormat);
                lastAccessLabel.Text = fileInfo.LastAccessTime.ToString(dateTimeFormat);
                readonlyLabel.Text = fileInfo.IsReadOnly ? LanguageUtil.GetCurrentLanguageString("readonlyLabel1Yes", Name) : LanguageUtil.GetCurrentLanguageString("readonlyLabel1No", Name);
                sizeLabel.Text = highSizeStr + " (" + String.Format(LanguageUtil.GetInfoCulture(), "{0:0,0}", size) + " " + LanguageUtil.GetCurrentLanguageString("Bytes", Name) + ")";

                bool withBOM;
                Encoding fileEncoding = EncodingUtil.GetFileEncoding(fileInfo.FullName, out withBOM);
                encodingLabel.Text = fileEncoding.EncodingName;
                if (!withBOM)
                {
                    encodingLabel.Text += " " + LanguageUtil.GetCurrentLanguageString("EncodingWithoutBOM", Name);
                }

                Icon icon = Icon.ExtractAssociatedIcon(fileName);
                if (icon == null)
                {
                    iconPictureBox.Width = 32;
                    iconPictureBox.Height = 32;
                    iconPictureBox.Image = ToolbarResource.paper;
                }
                else
                {
                    iconPictureBox.Width = icon.Width;
                    iconPictureBox.Height = icon.Height;
                    iconPictureBox.Image = icon.ToBitmap();
                }

                Select();
            }
            catch (Exception exception)
            {
                WindowManager.HiddenForm(this);
                WindowManager.ShowErrorBox(this, exception.Message, exception);
            }
        }

        private void directoryLabel_MouseLeave(object sender, EventArgs e)
        {
            directoryToolTip.Active = false;
            directoryToolTip.Active = true;
        }

        private void nameLabel_MouseLeave(object sender, EventArgs e)
        {
            nameToolTip.Active = false;
            nameToolTip.Active = true;
        }

        #endregion Window Methods

        #region Buttons Methods

        private void copyButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            Clipboard.SetDataObject(fileName, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
            ClipboardManager.AddContent(form);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Buttons Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            filePropertiesToolTip.SetToolTip(copyButton, LanguageUtil.GetCurrentLanguageString("copyButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
