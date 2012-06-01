using System;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.UserControls
{
    /// <summary>
    /// Tab explorer user control.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class TabPanel : UserControl
    {
        internal TabPanel()
        {
            InitializeComponent();
        }

        #region Window Methods

        private void tabExplorerTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            ExplorerManager.SelectTabPageFromTabExplorer(form, e);
        }

        private void tabExplorerTreeView_LostFocus(object sender, EventArgs e)
        {
            moveTabFirstToolStripButton.Enabled = false;
            moveTabUpToolStripButton.Enabled = false;
            moveTabDownToolStripButton.Enabled = false;
            moveTabLastToolStripButton.Enabled = false;

            tabExplorerTreeView.SelectedNode = null;
        }

        #endregion Window Methods

        #region Button Methods

        private void moveTabFirstToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            TabManager.MoveTabFirstOrUp(form, true);
        }

        private void moveTabUpToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            TabManager.MoveTabFirstOrUp(form);
        }

        private void moveTabDownToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            TabManager.MoveTabDownOrLast(form);
        }

        private void moveTabLastToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            TabManager.MoveTabDownOrLast(form, true);
        }

        private void closeAllToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            TabManager.CloseAllPages(form);
        }

        private void sortTabsAlphabeticallyToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            TabManager.SortTabsAlphabetically(form);
        }

        #endregion Button Methods

        #region Multilanguage Methods

        internal void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
        }

        #endregion Multilanguage Methods
    }
}
