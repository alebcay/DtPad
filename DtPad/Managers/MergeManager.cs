using System;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Merge tabs manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class MergeManager
    {
        #region Internal Methods

        internal static void MergeTabs(MergeTabs form, String[] itemValues)
        {
            Form1 form1 = (Form1)form.Owner;
            ListBox tabPagesListBox = form.tabPagesListBox;
            CheckBox markSeparationCheckBox = form.markSeparationCheckBox;
            TextBox markSeparationTextBox = form.markSeparationTextBox;
            
            String[] selectedTabNames = new String[tabPagesListBox.SelectedIndices.Count];

            for (int i = 0; i < tabPagesListBox.SelectedIndices.Count; i++)
            {
                selectedTabNames[i] = itemValues[tabPagesListBox.SelectedIndices[i]];
            }

            TabManager.MergeTab(form1, selectedTabNames, markSeparationCheckBox.Checked, markSeparationTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine));
        }

        internal static String[] MoveItemsUp(MergeTabs form, String[] itemValues)
        {
            ListBox tabPagesListBox = form.tabPagesListBox;
            
            bool checkFirstItem = false;

            if (itemValues == null)
            {
                return null;
            }

            int selectedIndicesCount = tabPagesListBox.SelectedIndices.Count;
            int[] selectedIndices = new int[selectedIndicesCount];
            tabPagesListBox.SelectedIndices.CopyTo(selectedIndices, 0);
            tabPagesListBox.ClearSelected();

            for (int i = 0; i < selectedIndicesCount; i++)
            {
                if (selectedIndices[i] == 0)
                {
                    checkFirstItem = true;
                    continue;
                }

                int initialPositionItemToMoveUp = selectedIndices[i];

                if (checkFirstItem && initialPositionItemToMoveUp - 1 == selectedIndices[i - 1])
                {
                    continue;
                }
                    
                checkFirstItem = false;

                Object itemToMoveDown = tabPagesListBox.Items[initialPositionItemToMoveUp - 1];
                tabPagesListBox.Items[initialPositionItemToMoveUp - 1] = tabPagesListBox.Items[initialPositionItemToMoveUp];
                tabPagesListBox.Items[initialPositionItemToMoveUp] = itemToMoveDown;

                String stringToMoveDown = itemValues[initialPositionItemToMoveUp - 1];
                itemValues[initialPositionItemToMoveUp - 1] = itemValues[initialPositionItemToMoveUp];
                itemValues[initialPositionItemToMoveUp] = stringToMoveDown;

                tabPagesListBox.SetSelected(initialPositionItemToMoveUp - 1, true);
            }

            return itemValues;
        }

        internal static String[] MoveItemsDown(MergeTabs form, String[] itemValues)
        {
            ListBox tabPagesListBox = form.tabPagesListBox;
            
            bool checkLastItem = false;

            if (itemValues == null)
            {
                return null;
            }

            int selectedIndicesCount = tabPagesListBox.SelectedIndices.Count;
            int[] selectedIndices = new int[selectedIndicesCount];
            tabPagesListBox.SelectedIndices.CopyTo(selectedIndices, 0);
            tabPagesListBox.ClearSelected();

            for (int i = selectedIndicesCount - 1; i >= 0; i--)
            {
                if (selectedIndices[i] == tabPagesListBox.Items.Count - 1)
                {
                    checkLastItem = true;
                    continue;
                }

                int initialPositionItemToMoveDown = selectedIndices[i];

                if (checkLastItem && initialPositionItemToMoveDown + 1 == selectedIndices[i + 1])
                {
                    continue;
                }

                checkLastItem = false;

                Object itemToMoveUp = tabPagesListBox.Items[initialPositionItemToMoveDown + 1];
                tabPagesListBox.Items[initialPositionItemToMoveDown + 1] = tabPagesListBox.Items[initialPositionItemToMoveDown];
                tabPagesListBox.Items[initialPositionItemToMoveDown] = itemToMoveUp;

                String stringToMoveUp = itemValues[initialPositionItemToMoveDown + 1];
                itemValues[initialPositionItemToMoveDown + 1] = itemValues[initialPositionItemToMoveDown];
                itemValues[initialPositionItemToMoveDown] = stringToMoveUp;

                tabPagesListBox.SetSelected(initialPositionItemToMoveDown + 1, true);
            }

            return itemValues;
        }

        #endregion Internal Methods
    }
}
