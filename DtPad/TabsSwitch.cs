using System;
using System.Drawing;
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
        private int currentTab = 1;
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
                totalPages = Convert.ToInt32(Math.Ceiling(form.pagesTabControl.TabPages.Count / (decimal)8));

                pagingLabel.Text = String.Format(pagingLabel.Text, currentPage, totalPages);
            }

            ReadOwnerFormTabs();
            tabTextBox1.BackColor = Color.LightSkyBlue;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            String currentControl = String.Format("tabTextBox{0}", (currentTab));

            if (backButton.Enabled && keyData == Keys.Left)
            {
                Back();
                return true;
            }
            if (nextButton.Enabled && keyData == Keys.Right)
            {
                Next();
                return true;
            }
            if (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Control))
            {
                String nextControl = String.Format("tabTextBox{0}", (currentTab + 1));
                tableLayoutPanel.Controls[currentControl].BackColor = Color.White;

                if (tableLayoutPanel.Controls[nextControl] != null && tableLayoutPanel.Controls[nextControl].Visible)
                {
                    tableLayoutPanel.Controls[nextControl].BackColor = Color.LightSkyBlue;

                    currentTab++;
                }
                else if (currentPage < totalPages)
                {
                    Next();
                    tabTextBox1.BackColor = Color.LightSkyBlue;

                    currentTab = 1;
                }
                else if (currentPage == totalPages && totalPages > 1)
                {
                    First();
                    tabTextBox1.BackColor = Color.LightSkyBlue;

                    currentTab = 1;
                }
                else
                {
                    tabTextBox1.BackColor = Color.LightSkyBlue;

                    currentTab = 1;
                }
                return true;
            }
            if (keyData == Keys.Enter || keyData == Keys.Return)
            {
                SelectTab(tableLayoutPanel.Controls[currentControl]);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion Window Methods

        #region Tabs Methods

        private void tabTextBox_Click(object sender, EventArgs e)
        {
            SelectTab((TextBox)sender);
        }

        private void tabTextBox_MouseEnter(object sender, EventArgs e)
        {
            tableLayoutPanel.Controls["tabTextBox1"].BackColor = Color.White;
            tableLayoutPanel.Controls["tabTextBox2"].BackColor = Color.White;
            tableLayoutPanel.Controls["tabTextBox3"].BackColor = Color.White;
            tableLayoutPanel.Controls["tabTextBox4"].BackColor = Color.White;
            tableLayoutPanel.Controls["tabTextBox5"].BackColor = Color.White;
            tableLayoutPanel.Controls["tabTextBox6"].BackColor = Color.White;
            tableLayoutPanel.Controls["tabTextBox7"].BackColor = Color.White;
            tableLayoutPanel.Controls["tabTextBox8"].BackColor = Color.White;

            ((TextBox)sender).BackColor = Color.LightSkyBlue;
        }

        private void tabTextBox_MouseLeave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;

            tableLayoutPanel.Controls[String.Format("tabTextBox{0}", (currentTab))].BackColor = Color.LightSkyBlue;
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

        private void ReadOwnerFormTabs()
        {
            Form1 form = (Form1)Owner;
            int rangeStart = (currentPage - 1) * 8;

            for (int i = rangeStart; i < rangeStart + 8; i++)
            {
                TextBox nextTabTextBox = (TextBox)(Controls["tableLayoutPanel"].Controls[String.Format("tabTextBox{0}", (i - (8 * (currentPage - 1)) + 1))]);
                Label tabTitleLabel = (Label)(Controls["tableLayoutPanel"].Controls[String.Format("tabTitleLabel{0}", (i - (8 * (currentPage - 1)) + 1))]);

                if (i < form.pagesTabControl.TabPages.Count)
                {
                    XtraTabPage tabPage = form.pagesTabControl.TabPages[i];

                    tabTitleLabel.Text = tabPage.Text;
                    nextTabTextBox.Text = ProgramUtil.GetPageTextBox(tabPage).Text;
                    nextTabTextBox.Select(0, 0);
                    tabsSwitchToolTip.SetToolTip(nextTabTextBox, tabPage.Text);
                    nextTabTextBox.Tag = i;

                    nextTabTextBox.Visible = true;
                    tabTitleLabel.Visible = true;
                }
                else
                {
                    nextTabTextBox.Visible = false;
                    tabTitleLabel.Visible = false;
                }
            }

            Select();
        }

        private void SelectTab(Control tabTextBox)
        {
            Form1 form = (Form1)Owner;
            XtraTabControl pagesTabControl = form.pagesTabControl;

            pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[Convert.ToInt32(tabTextBox.Tag)];

            WindowManager.CloseForm(this);
        }

        private void First()
        {
            currentPage = 1;
            pagingLabel.Text = String.Format(LanguageUtil.GetCurrentLanguageString("pagingLabel", Name), currentPage, totalPages);
            nextButton.Enabled = true;
            backButton.Enabled = false;

            ReadOwnerFormTabs();
        }

        private void Back()
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

        private void Next()
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

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            tabsSwitchToolTip.SetToolTip(backButton, LanguageUtil.GetCurrentLanguageString("backButtonToolTip", Name));
            tabsSwitchToolTip.SetToolTip(nextButton, LanguageUtil.GetCurrentLanguageString("nextButtonToolTip", Name));
        }

        #endregion Private Methods
    }
}
