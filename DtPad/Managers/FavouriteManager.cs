using System;
using System.IO;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Favourite files manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class FavouriteManager
    {
        #region Internal Methods

        internal static void AddNewFavourite(Favourites form, Form1 form1)
        {
            ListBox favouritesListBox = form.favouritesListBox;
            
            int defaultExtension;
            String defaultExtensionShortString;
            String filter = ExtensionManager.GetFileDialogFilter(out defaultExtension, out defaultExtensionShortString);
            String fileName = FileUtil.GetFileNameAndPath(form1, filter, defaultExtension, defaultExtensionShortString);

            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }

            FileListManager.SetNewFavouriteFile(form1, fileName);

            favouritesListBox.Items.Clear();
            form.InitializeForm(true);
            favouritesListBox.SelectedIndex = favouritesListBox.Items.Count - 1;
        }

        internal static void DeleteFavourite(Favourites form, Form1 form1)
        {
            ListBox favouritesListBox = form.favouritesListBox;

            int selectedIndex = favouritesListBox.SelectedIndex;
            FileListManager.DeleteExistingFavouriteFile(form1, selectedIndex);

            favouritesListBox.Items.Clear();
            form.InitializeForm(true);

            if (favouritesListBox.Items.Count <= 0)
            {
                return;
            }

            if (selectedIndex < favouritesListBox.Items.Count)
            {
                favouritesListBox.SelectedIndex = selectedIndex;
            }
            else
            {
                favouritesListBox.SelectedIndex = selectedIndex - 1;
            }
        }

        internal static void MoveFavourite(Favourites form, Form1 form1, ObjectListUtil.Movement move)
        {
            ListBox favouritesListBox = form.favouritesListBox;
            Object selectedItem = favouritesListBox.SelectedItem;
            int selectedItemIndex = favouritesListBox.SelectedIndex;

            favouritesListBox.Items.RemoveAt(selectedItemIndex);

            switch (move)
            {
                case ObjectListUtil.Movement.Up:
                    favouritesListBox.Items.Insert(selectedItemIndex - 1, selectedItem);
                    break;
                case ObjectListUtil.Movement.Down:
                    favouritesListBox.Items.Insert(selectedItemIndex + 1, selectedItem);
                    break;
            }

            favouritesListBox.SelectedItem = selectedItem;
            FileListManager.CreateFileFromListBox(form);
            FileListManager.LoadFavouriteFiles(form1, true);
        }

        internal static bool IsFileFavourite(String filePathAndName)
        {
            String fileContent;
            return IsFileFavourite(filePathAndName, out fileContent);
        }
        internal static bool IsFileFavourite(String filePathAndName, out String fileContent)
        {
            fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.fvFile));

            return fileContent.IndexOf(filePathAndName + Environment.NewLine) >= 0;
        }

        #endregion Internal Methods
    }
}
