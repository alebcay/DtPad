using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Tabs switch view DtPad form.
    /// </summary>
    /// <author>Marco Macciò, Derek Morin</author>
    internal partial class TabsSwitch : SingleBorderForm
    {
        private int totalPages;
        private int totalNumberOfDocuments;
        private int currentlySelectedThumbnail;
        private TabsSwitchUtil.InterfaceType interfaceType;
        private const int thumbnailsPerPage = 8; //NOTE: changing this wouldn't have any effect unless you changed the number of controls in the designer

        internal bool Forward;

        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            SetLanguage();

            Form1 form = (Form1)Owner;
            totalNumberOfDocuments = form.pagesTabControl.TabPages.Count;
            totalPages = (int)Math.Ceiling(totalNumberOfDocuments / (decimal)thumbnailsPerPage);

            if (totalPages > 1)
            {
                pagingLabel.Visible = true;
                nextButton.Visible = true;
                backButton.Visible = true;
            }

            currentlySelectedThumbnail = form.pagesTabControl.TabPages.TabControl.SelectedTabPageIndex;
            currentlySelectedThumbnail = (Forward) ? GetNextDocumentIndex() : GetPreviousDocumentIndex();

            SetKeyboardOrMouseInterface();
            ReadOwnerFormTabs();
        }

        private void TabsSwitch_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                SelectTab();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Control))
            {
                currentlySelectedThumbnail = GetNextDocumentIndex();
                ReadOwnerFormTabs();
                return true;
            }
            if (keyData == (Keys.Tab | Keys.Control | Keys.Shift))
            {
                currentlySelectedThumbnail = GetPreviousDocumentIndex();
                ReadOwnerFormTabs();
                return true;
            }
            if (keyData == Keys.Enter || keyData == Keys.Return)
            {
                SelectTab();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion Window Methods

        #region Tabs Methods

        private void tabTextBox_Click(object sender, EventArgs e)
        {
            switch (interfaceType)
            {
                case TabsSwitchUtil.InterfaceType.Mouse:
                    currentlySelectedThumbnail = (int)((TextBox)sender).Tag;
                    SelectTab();
                    break;
            }
        }

        private void tabTextBox_MouseEnter(object sender, EventArgs e)
        {
            switch (interfaceType)
            {
                case TabsSwitchUtil.InterfaceType.Mouse:
                    foreach (TextBox textBox in tableLayoutPanel.Controls.OfType<TextBox>())
                    {
                        textBox.BackColor = (textBox.BorderStyle == BorderStyle.FixedSingle) ? Color.White : BackColor;
                    }
                    ((TextBox)sender).BackColor = Color.LightSkyBlue;
                    break;
            }
        }

        private void tabTextBox_MouseLeave(object sender, EventArgs e)
        {
            switch (interfaceType)
            {
                case TabsSwitchUtil.InterfaceType.Mouse:
                    ((TextBox)sender).BackColor = (((TextBox)sender).BorderStyle == BorderStyle.FixedSingle) ? Color.White : BackColor;
                    break;
            }
        }

        #endregion Tabs Methods

        #region Button Methods

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            Next();
        }

        #endregion Button Methods

        #region Private Methods

        private TextBox GetTextBox(int tabIndex)
        {
            int index = (tabIndex % thumbnailsPerPage) + 1;
            return (TextBox)(Controls["tableLayoutPanel"].Controls[String.Format("tabTextBox{0}", index)]);
        }

        private Label GetLabel(int tabIndex)
        {
            int index = (tabIndex % thumbnailsPerPage) + 1;
            return (Label)(Controls["tableLayoutPanel"].Controls[String.Format("tabTitleLabel{0}", index)]);
        }

        private void ReadOwnerFormTabs()
        {
            Form1 form = (Form1)Owner;
            int rangeStart = (int)Math.Floor(currentlySelectedThumbnail / (decimal)thumbnailsPerPage) * 8;
            int currentPage = (int)Math.Ceiling((currentlySelectedThumbnail + 1) / (decimal)thumbnailsPerPage);

            for (int i = rangeStart; i < rangeStart + thumbnailsPerPage; i++)
            {
                TextBox nextTabTextBox = GetTextBox(i);
                Label tabTitleLabel = GetLabel(i);
                nextTabTextBox.BackColor = Color.White;

                if (i < form.pagesTabControl.TabPages.Count)
                {
                    XtraTabPage tabPage = form.pagesTabControl.TabPages[i];

                    tabTitleLabel.Text = tabPage.Text;
                    String textToShow = ProgramUtil.GetPageTextBox(tabPage).Text;
                    
                    nextTabTextBox.Text = textToShow.Substring(0, Math.Min(2000, textToShow.Length));
                    nextTabTextBox.Select(0, 0);
                    tabsSwitchToolTip.SetToolTip(nextTabTextBox, tabPage.Text);
                    nextTabTextBox.Tag = i;
                    nextTabTextBox.BorderStyle = BorderStyle.FixedSingle; //Have to put the border back in case it was removed (see below)
                    nextTabTextBox.Visible = true;
                    tabTitleLabel.Visible = true;
                }
                else
                {
                    nextTabTextBox.BorderStyle = BorderStyle.None;
                    nextTabTextBox.BackColor = BackColor;
                    nextTabTextBox.Text = "";
                    tabTitleLabel.Visible = false;

                    switch (interfaceType)
                    {
                        case TabsSwitchUtil.InterfaceType.Mouse:
                            nextTabTextBox.Visible = false;
                            break;
                    }
                }
            }

            GetTextBox(currentlySelectedThumbnail).BackColor = Color.LightSkyBlue;

            pagingLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("pagingLabel", Name), currentPage, totalPages);
            nextButton.Enabled = (currentPage < totalPages);
            backButton.Enabled = (currentPage > 1);
            Select();
        }

        private void SelectTab()
        {
            Form1 form = (Form1)Owner;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[currentlySelectedThumbnail];
            WindowManager.CloseForm(this);
        }

        private void Back()
        {
            currentlySelectedThumbnail = currentlySelectedThumbnail - thumbnailsPerPage;
            currentlySelectedThumbnail = currentlySelectedThumbnail - (currentlySelectedThumbnail % 8);
            ReadOwnerFormTabs();
        }

        private void Next()
        {
            currentlySelectedThumbnail = currentlySelectedThumbnail + thumbnailsPerPage;
            currentlySelectedThumbnail = currentlySelectedThumbnail - (currentlySelectedThumbnail % thumbnailsPerPage);
            ReadOwnerFormTabs();
        }

        private int GetNextDocumentIndex()
        {
            return (currentlySelectedThumbnail == (totalNumberOfDocuments - 1)) ? 0 : currentlySelectedThumbnail + 1;
        }

        private int GetPreviousDocumentIndex()
        {
            return (currentlySelectedThumbnail == 0) ? totalNumberOfDocuments - 1 : currentlySelectedThumbnail - 1;
        }

        private void SetKeyboardOrMouseInterface()
        {
            switch (ConfigUtil.GetIntParameter("TabsSwitchType"))
            {
                case 0:
                    interfaceType = TabsSwitchUtil.InterfaceType.Keyboard;

                    backButton.Visible = false;
                    nextButton.Visible = false;

                    foreach (TextBox textBox in tableLayoutPanel.Controls.OfType<TextBox>())
                    {
                        textBox.Enabled = false;
                    }

                    KeyUp += TabsSwitch_KeyUp;
                    break;
                case 1:
                    interfaceType = TabsSwitchUtil.InterfaceType.Mouse;
                    break;

                default:
                    interfaceType = TabsSwitchUtil.InterfaceType.Keyboard;
                    break;
            }
        }

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            tabsSwitchToolTip.SetToolTip(backButton, LanguageUtil.GetCurrentLanguageString("backButtonToolTip", Name));
            tabsSwitchToolTip.SetToolTip(nextButton, LanguageUtil.GetCurrentLanguageString("nextButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
