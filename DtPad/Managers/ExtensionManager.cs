using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DtPad.Exceptions;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Extension manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ExtensionManager
    {
        private const String className = "ExtensionManager";
        
        #region Internal Methods

        internal static ExtensionObjectList LoadExtensionsList(Extensions form)
        {
            return LoadExtensionsListPrivate(form, false);
        }

        internal static void LoadExtension(Extensions form, ExtensionObjectList extensionObjectList)
        {
            TreeView extensionTreeView = form.extensionTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;
            TextBox extensionTextBox = form.extensionTextBox;
            CheckBox defaultCheckBox = form.defaultCheckBox;
            Button removeButton = form.removeButton;

            foreach (ExtensionObject extensionObject in extensionObjectList)
            {
                if (extensionObject.Description != extensionTreeView.SelectedNode.Text)
                {
                    continue;
                }

                descriptionTextBox.Text = extensionObject.Description; //Text document
                extensionTextBox.Text = extensionObject.Extension; //txt
                defaultCheckBox.Checked = Convert.ToBoolean(extensionObject.DefaultExtension); //True

                break;
            }

            if (extensionTreeView.SelectedNode.Index == 0)
            {
                descriptionTextBox.Enabled = true;
                extensionTextBox.Enabled = false;
                removeButton.Enabled = false;
            }
            else
            {
                descriptionTextBox.Enabled = true;
                extensionTextBox.Enabled = true;
                removeButton.Enabled = true;
            }
        }

        internal static bool SaveExtensionsIntoFile(Form form, ExtensionObjectList extensionObjectList)
        {
            return SaveExtensionsIntoFilePrivate(form, extensionObjectList, false);
        }

        internal static int AddExtension(Extensions form, ExtensionObjectList extensionObjectList, int newExtensionIdentity)
        {
            TreeView extensionTreeView = form.extensionTreeView;
            if (newExtensionIdentity < extensionTreeView.Nodes.Count)
            {
                newExtensionIdentity = extensionTreeView.Nodes.Count;
            }

            newExtensionIdentity++;
            String description = String.Format("{0} ({1})", LanguageUtil.GetCurrentLanguageString("New", className), newExtensionIdentity);

            while (CheckIdentityExists(form, extensionObjectList, description))
            {
                newExtensionIdentity++;
                description = String.Format("{0} ({1})", LanguageUtil.GetCurrentLanguageString("New", className), newExtensionIdentity);
            }

            ExtensionObject extensionObject = new ExtensionObject(description, String.Empty, false);
            extensionObjectList.Add(extensionObject);

            extensionTreeView.Focus();
            extensionTreeView.Nodes.Add(description);
            extensionTreeView.SelectedNode = extensionTreeView.Nodes[extensionTreeView.Nodes.Count - 1];

            return newExtensionIdentity;
        }

        internal static bool RemoveExtension(Extensions form, ExtensionObjectList extensionObjectList)
        {
            TreeView extensionTreeView = form.extensionTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;

            int indexNodeToRemove = extensionTreeView.SelectedNode.Index;
            int extensionPositionInList = GetExtensionPositionInList(extensionObjectList, descriptionTextBox.Text);
            if (extensionPositionInList == -1)
            {
                String error = LanguageUtil.GetCurrentLanguageString("Removing", className);
                ExtensionException exception = new ExtensionException(error);
                WindowManager.ShowErrorBox(form, error, exception);
                return false;
            }
            extensionObjectList.RemoveAt(extensionPositionInList);

            extensionTreeView.Focus();
            extensionTreeView.Nodes.Remove(extensionTreeView.SelectedNode);
            extensionTreeView.SelectedNode = extensionTreeView.Nodes.Count > indexNodeToRemove ? extensionTreeView.Nodes[indexNodeToRemove] : extensionTreeView.Nodes[indexNodeToRemove - 1];

            return true;
        }

        internal static bool SaveDescription(Extensions form, ExtensionObjectList extensionObjectList)
        {
            TreeView extensionTreeView = form.extensionTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;

            if (String.IsNullOrEmpty(descriptionTextBox.Text))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ExtensionNameNotEmpty", className));
                descriptionTextBox.Focus();
                return true;
            }

            ExtensionObject selectedExtensionObject = null;

            foreach (ExtensionObject extensionObject in extensionObjectList)
            {
                if (extensionObject.Description != extensionTreeView.SelectedNode.Text && extensionObject.Description == descriptionTextBox.Text)
                {
                    WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("AlreadyExists", className));
                    descriptionTextBox.Focus();
                    return true;
                }
                
                if (extensionObject.Description == extensionTreeView.SelectedNode.Text)
                {
                    selectedExtensionObject = extensionObject;
                }
            }

            if (selectedExtensionObject == null)
            {
                String error = LanguageUtil.GetCurrentLanguageString("Saving", className);
                ExtensionException exception = new ExtensionException(error);
                WindowManager.ShowErrorBox(form, error, exception);
                return false;
            }

            selectedExtensionObject.Description = descriptionTextBox.Text;
            extensionTreeView.SelectedNode.Text = selectedExtensionObject.Description;

            return true;
        }

        internal static void SaveExtension(Extensions form, ExtensionObjectList extensionObjectList)
        {
            TreeView extensionTreeView = form.extensionTreeView;
            TextBox extensionTextBox = form.extensionTextBox;

            foreach (ExtensionObject extensionObject in extensionObjectList)
            {
                if (extensionObject.Description != extensionTreeView.SelectedNode.Text)
                {
                    continue;
                }

                extensionObject.Extension = CheckExtension(extensionTextBox.Text);
                return;
            }
        }

        internal static void SaveDefault(Extensions form, ExtensionObjectList extensionObjectList)
        {
            TreeView extensionTreeView = form.extensionTreeView;
            CheckBox defaultCheckBox = form.defaultCheckBox;
            
            if (!defaultCheckBox.Checked)
            {
                return;
            }

            foreach (ExtensionObject extensionObject in extensionObjectList)
            {
                if (extensionObject.Description != extensionTreeView.SelectedNode.Text && extensionObject.DefaultExtension)
                {
                    extensionObject.DefaultExtension = false;
                }
                else if (extensionObject.Description == extensionTreeView.SelectedNode.Text)
                {
                    extensionObject.DefaultExtension = true;
                }
            }
        }

        internal static String GetFileDialogFilter(out int defaultExtension, out String defaultExtensionShortString)
        {
            String filter = String.Empty;
            defaultExtension = -1;
            defaultExtensionShortString = "*.*";

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.exFile));

            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splittedFileContent.Length; i++) //Text document|txt|True
            {
                String extensionString = splittedFileContent[i];

                separator[0] = "|";
                String[] splittedExtensionContent = extensionString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                if (i != 0)
                {
                    filter += "|";
                }
                filter += String.Format("{0} (*.{1})|*.{1}", splittedExtensionContent[0], splittedExtensionContent[1]);

                if (!Convert.ToBoolean(splittedExtensionContent[2]))
                {
                    continue;
                }

                defaultExtensionShortString = String.Format("*.{0}", splittedExtensionContent[1]);
                defaultExtension = i;
            }

            return filter;
        }

        internal static ExtensionObjectList GetExtensionObjectListFromExFile()
        {
            ExtensionObjectList extensionObjectList = new ExtensionObjectList();

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.exFile));

            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (String extensionString in splittedFileContent)
            {
                separator[0] = "|";
                String[] splittedExtensionContent = extensionString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                ExtensionObject extensionObject = new ExtensionObject(splittedExtensionContent[0], splittedExtensionContent[1], Convert.ToBoolean(splittedExtensionContent[2]));
                extensionObjectList.Add(extensionObject);
            }

            return extensionObjectList;
        }

        internal static ExtensionObjectList MoveExtension(Extensions form, ObjectListUtil.Movement move, ExtensionObjectList extensionObjectList)
        {
            TreeView extensionTreeView = form.extensionTreeView;

            TreeNode selectedNode = extensionTreeView.SelectedNode;
            int selectedNodeIndex = extensionTreeView.SelectedNode.Index;
            ExtensionObject extensionObject = (ExtensionObject)extensionObjectList[selectedNodeIndex];

            return (ExtensionObjectList)ObjectListUtil.MoveObject(move, extensionObjectList, extensionObject, extensionTreeView, selectedNode, selectedNodeIndex);
        }

        #endregion Internal Methods

        #region Private Methods

        private static ExtensionObjectList LoadExtensionsListPrivate(Extensions form, bool suppressMessageBox)
        {
            TreeView extensionTreeView = form.extensionTreeView;

            ExtensionObjectList extensionObjectList = new ExtensionObjectList();

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.exFile));

            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (splittedFileContent.Length > 0)
            {
                extensionTreeView.BeginUpdate();
            }

            foreach (String extensionString in splittedFileContent)
            {
                separator[0] = "|";
                String[] splittedExtensionContent = extensionString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                if (splittedExtensionContent.Length != 3)
                {
                    if (!suppressMessageBox)
                    {
                        WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("Reading", className));
                    }
                    FileListManager.SaveFileList(ConstantUtil.exFile, ConstantUtil.defaultExtensionFileContent);
                    return LoadExtensionsList(form);
                }

                extensionTreeView.Nodes.Add(splittedExtensionContent[0]); //Text document

                ExtensionObject extensionObject = new ExtensionObject(splittedExtensionContent[0], splittedExtensionContent[1], Convert.ToBoolean(splittedExtensionContent[2]));
                extensionObjectList.Add(extensionObject);
            }

            if (splittedFileContent.Length > 0)
            {
                extensionTreeView.EndUpdate();
            }

            extensionTreeView.Focus();
            extensionTreeView.SelectedNode = extensionTreeView.Nodes[0];

            return extensionObjectList;
        }

        private static bool SaveExtensionsIntoFilePrivate(Form form, ExtensionObjectList extensionObjectList, bool suppressMessageBox)
        {
            String fileContent = String.Empty;

            foreach (ExtensionObject extensionObject in extensionObjectList)
            {
                if (String.IsNullOrEmpty(extensionObject.Extension) || String.IsNullOrEmpty(extensionObject.Description))
                {
                    if (!suppressMessageBox)
                    {
                        WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("Unvalorized", className));
                    }
                    return false;
                }

                fileContent += String.Format("{0}|{1}|{2}{3}", extensionObject.Description, extensionObject.Extension, extensionObject.DefaultExtension, Environment.NewLine);
            }

            FileListManager.SaveFileList(ConstantUtil.exFile, fileContent);

            return true;
        }

        private static int GetExtensionPositionInList(IList extensionObjectList, String extensionDescription)
        {
            for (int i = 0; i < extensionObjectList.Count; i++)
            {
                ExtensionObject extensionObject = (ExtensionObject)extensionObjectList[i];

                if (extensionObject.Description == extensionDescription)
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool CheckIdentityExists(Extensions form, ExtensionObjectList extensionObjectList, String descriptionToSearch)
        {
            TreeView extensionTreeView = form.extensionTreeView;

            //foreach (ExtensionObject extensionObject in extensionObjectList)
            //{
            //    if (extensionObject.Description != extensionTreeView.SelectedNode.Text && extensionObject.Description == descriptionToSearch)
            //    {
            //        return true;
            //    }
            //}
            return extensionObjectList.Cast<ExtensionObject>().Any(extensionObject => extensionObject.Description != extensionTreeView.SelectedNode.Text && extensionObject.Description == descriptionToSearch);
        }

        private static String CheckExtension(String extension)
        {
            return extension.StartsWith(".") ? extension.Substring(1) : extension;
        }

        #endregion Private Methods
    }
}
