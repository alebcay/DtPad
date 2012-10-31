using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Favourites management DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class Favourites : Form
    {
        #region Window Methods

        internal void InitializeForm(bool reload)
        {
            if (!reload)
            {
                InitializeComponent();
                SetLanguage();
            }
            
            FileListManager.LoadFavouriteWindowFiles(this);
        }

        private void favouritesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteFavouriteButton.Enabled = favouritesListBox.SelectedItems.Count > 0;
            CheckObjectCount();
        }

        private void Favourites_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void addFavouriteButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            FavouriteManager.AddNewFavourite(this, form);
            CheckObjectCount();
        }

        private void addFavouriteSessionButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            FavouriteManager.AddNewFavouriteSession(this, form);
            CheckObjectCount();
        }

        private void addFavouriteUrlButton_Click(object sender, EventArgs e)
        {
            FavouriteManager.AddNewFavouriteUrl(this);
            CheckObjectCount();
        }

        private void deleteFavouriteButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            FavouriteManager.DeleteFavourite(this, form);
            CheckObjectCount();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            FavouriteManager.MoveFavourite(this, form, ObjectListUtil.Movement.Up);
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            FavouriteManager.MoveFavourite(this, form, ObjectListUtil.Movement.Down);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            favouriteToolTip.SetToolTip(addFavouriteButton, LanguageUtil.GetCurrentLanguageString("addFavouriteButtonToolTip", Name));
            favouriteToolTip.SetToolTip(addFavouriteSessionButton, LanguageUtil.GetCurrentLanguageString("addFavouriteSessionButtonToolTip", Name));
            favouriteToolTip.SetToolTip(addFavouriteUrlButton, LanguageUtil.GetCurrentLanguageString("addFavouriteUrlButtonToolTip", Name));
            favouriteToolTip.SetToolTip(deleteFavouriteButton, LanguageUtil.GetCurrentLanguageString("deleteFavouriteButtonToolTip", Name));
            favouriteToolTip.SetToolTip(moveUpButton, LanguageUtil.GetCurrentLanguageString("moveUpButtonToolTip", Name));
            favouriteToolTip.SetToolTip(moveDownButton, LanguageUtil.GetCurrentLanguageString("moveDownButtonToolTip", Name));
        }

        private void CheckObjectCount()
        {
            if (favouritesListBox.Items.Count <= 1 || favouritesListBox.SelectedIndex < 0)
            {
                moveUpButton.Enabled = false;
                moveDownButton.Enabled = false;
                return;
            }

            moveUpButton.Enabled = favouritesListBox.SelectedIndex > 0;
            moveDownButton.Enabled = favouritesListBox.SelectedIndex < favouritesListBox.Items.Count - 1;
        }

        #endregion Private Methods
    }
}
