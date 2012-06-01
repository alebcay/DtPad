using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Environment statistics DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Statistics : Form
    {
        private const int maxCharsNumber = 54;

        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            LoadData();
        }

        private void Statistics_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;
            
            ClipboardData(form);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            statisticsToolTip.SetToolTip(refreshButton, LanguageUtil.GetCurrentLanguageString("refreshButtonToolTip", Name));
            statisticsToolTip.SetToolTip(copyButton, LanguageUtil.GetCurrentLanguageString("copyButtonToolTip", Name));
        }

        private void LoadData()
        {
            String directoryName = StringUtil.CheckStringLength(ConstantUtil.ApplicationExecutionPath(), maxCharsNumber);
            int memoryWorkingSet = Convert.ToInt32(Environment.WorkingSet / 1000);
            String bits = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";

            usernameLabel.Text = Environment.UserName;
            domainLabel.Text = Environment.UserDomainName;
            workingDirectoryLabel.Text = directoryName;
            machineNameLabel.Text = Environment.MachineName;
            osLabel.Text = SystemUtil.GetOSDescription(SystemUtil.GetOSInfo()) + " " + Environment.OSVersion.ServicePack + " " + bits;
            processorsLabel.Text = Environment.ProcessorCount.ToString();
            frameworkVersionLabel.Text = Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build + "." + Environment.Version.Revision;
            memoryLabel.Text = memoryWorkingSet.ToString("#,###", LanguageUtil.GetInfoCulture()) + " KB";

            directoryToolTip.SetToolTip(workingDirectoryLabel, Environment.CurrentDirectory);
        }

        private void ClipboardData(Form1 form)
        {
            String textToClipboard = String.Empty;

            textToClipboard += usernameLabel1.Text + " " + usernameLabel.Text + Environment.NewLine;
            textToClipboard += domainLabel1.Text + " " + domainLabel.Text + Environment.NewLine;
            textToClipboard += workingDirectoryLabel1.Text + " " + ConstantUtil.ApplicationExecutionPath() + Environment.NewLine;
            textToClipboard += machineNameLabel1.Text + " " + machineNameLabel.Text + Environment.NewLine;
            textToClipboard += osLabel1.Text + " " + osLabel.Text + Environment.NewLine;
            textToClipboard += processorsLabel1.Text + " " + processorsLabel.Text + Environment.NewLine;
            textToClipboard += frameworkVersionLabel1.Text + " " + frameworkVersionLabel.Text + Environment.NewLine;
            textToClipboard += memoryLabel1.Text + " " + memoryLabel.Text + Environment.NewLine;

            Clipboard.SetDataObject(textToClipboard, true, ConstantUtil.clipboardRetryTimes, ConstantUtil.clipboardRetryDelay);
            ClipboardManager.AddContent(form);
        }

        #endregion Private Methods
    }
}
