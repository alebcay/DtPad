using System;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Tabs switch view DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class TabsSwitch : Form
    {
        private int currentPage = 1;
        private int totalPages;

        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            SetLanguage();

            Form1 form = (Form1)Owner;

            if (form.pagesTabControl.TabPages.Count <= 8)
            {
                backButton.Enabled = false;
                nextButton.Enabled = false;
            }
            else
            {
                nextButton.Enabled = true;
                pagingLabel.Visible = true;
                totalPages = Convert.ToInt32(Math.Ceiling(form.pagesTabControl.TabPages.Count/(decimal) 8));

                pagingLabel.Text = String.Format(pagingLabel.Text, currentPage, totalPages);
            }

            ReadOwnerFormTabs();
            //for (int i = 0; i < 8; i++)
            //{
            //    TextBox nextTabTextBox = (TextBox)(Controls["tableLayoutPanel"].Controls[String.Format("tabTextBox{0}", (i + 1))]);

            //    if (i < form.pagesTabControl.TabPages.Count)
            //    {
            //        XtraTabPage tabPage = form.pagesTabControl.TabPages[i];
            //        nextTabTextBox.Text = ProgramUtil.GetPageTextBox(tabPage).Text;
            //        nextTabTextBox.Tag = i;
            //    }
            //    else
            //    {
            //        nextTabTextBox.Visible = false;
            //    }
            //}
        }

        #endregion Window Methods

        #region Tabs Methods

        private void tabTextBox1_Click(object sender, EventArgs e)
        {
            SelectTab(tabTextBox1);
        }

        private void tabTextBox2_Click(object sender, EventArgs e)
        {
            SelectTab(tabTextBox2);
        }

        private void tabTextBox3_Click(object sender, EventArgs e)
        {
            SelectTab(tabTextBox3);
        }

        private void tabTextBox4_Click(object sender, EventArgs e)
        {
            SelectTab(tabTextBox4);
        }

        private void tabTextBox5_Click(object sender, EventArgs e)
        {
            SelectTab(tabTextBox5);
        }

        private void tabTextBox6_Click(object sender, EventArgs e)
        {
            SelectTab(tabTextBox6);
        }

        private void tabTextBox7_Click(object sender, EventArgs e)
        {
            SelectTab(tabTextBox7);
        }

        private void tabTextBox8_Click(object sender, EventArgs e)
        {
            SelectTab(tabTextBox8);
        }

        #endregion Tabs Methods

        #region Button Methods

        private void backButton_Click(object sender, EventArgs e)
        {
            currentPage--;
            pagingLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("pagingLabel", Name), currentPage, totalPages);
            nextButton.Enabled = true;
            if (currentPage <= 1)
            {
                backButton.Enabled = false;
            }

            ReadOwnerFormTabs();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            currentPage++;
            pagingLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("pagingLabel", Name), currentPage, totalPages);
            backButton.Enabled = true;
            if (currentPage >= totalPages)
            {
                nextButton.Enabled = false;
            }

            ReadOwnerFormTabs();
        }

        #endregion Button Methods

        #region Private Methods

        private void ReadOwnerFormTabs()
        {
            Form1 form = (Form1)Owner;
            int rangeStart = (currentPage - 1) * 8;

            for (int i = rangeStart; i < rangeStart + 8; i++)
            {
                TextBox nextTabTextBox = (TextBox)(Controls["tableLayoutPanel"].Controls[String.Format("tabTextBox{0}", (i - (8 * (currentPage - 1)) + 1))]);

                if (i < form.pagesTabControl.TabPages.Count)
                {
                    XtraTabPage tabPage = form.pagesTabControl.TabPages[i];
                    nextTabTextBox.Text = ProgramUtil.GetPageTextBox(tabPage).Text;
                    tabsSwitchToolTip.SetToolTip(nextTabTextBox, tabPage.Text);
                    nextTabTextBox.Tag = i;
                    nextTabTextBox.Visible = true;
                }
                else
                {
                    nextTabTextBox.Visible = false;
                }
            }
        }

        private void SelectTab(TextBox tabTextBox)
        {
            Form1 form = (Form1)Owner;
            XtraTabControl pagesTabControl = form.pagesTabControl;

            pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[Convert.ToInt32(tabTextBox.Tag)];
            WindowManager.CloseForm(this);
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
