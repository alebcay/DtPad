using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DtPad.Exceptions;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Tools manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ToolManager
    {
        private const String className = "ToolManager";

        #region Internal Methods

        internal static ToolObjectList LoadToolsList(Tools form)
        {
            TreeView toolTreeView = form.toolTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;
            TextBox commandLineTextBox = form.commandLineTextBox;
            TextBox workingFolderTextBox = form.workingFolderTextBox;
            ComboBox runComboBox = form.runComboBox;
            Button removeButton = form.removeButton;

            ToolObjectList toolObjectList = new ToolObjectList();

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.toFile));

            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (splittedFileContent.Length > 0)
            {
                toolTreeView.BeginUpdate();
            }

            foreach (String toolString in splittedFileContent)
            {
                separator[0] = "|";
                String[] splittedExtensionContent = toolString.Split(separator, StringSplitOptions.None);

                if (splittedExtensionContent.Length != 4)
                {
                    WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ErrorReading", className));
                    FileListManager.SaveFileList(ConstantUtil.toFile, String.Empty);
                    return LoadToolsList(form);
                }

                toolTreeView.Nodes.Add(splittedExtensionContent[0]); //DtPad

                ToolObject toolObject = new ToolObject(splittedExtensionContent[0], splittedExtensionContent[1], splittedExtensionContent[2], Convert.ToInt32(splittedExtensionContent[3]));
                toolObjectList.Add(toolObject);
            }

            if (splittedFileContent.Length > 0)
            {
                toolTreeView.EndUpdate();
            }

            toolTreeView.Focus();

            if (toolTreeView.Nodes.Count > 0)
            {
                toolTreeView.SelectedNode = toolTreeView.Nodes[0];
            }
            else
            {
                descriptionTextBox.Enabled = false;
                commandLineTextBox.Enabled = false;
                workingFolderTextBox.Enabled = false;
                runComboBox.Enabled = false;
                runComboBox.SelectedIndex = 0;
                removeButton.Enabled = false;
            }

            return toolObjectList;
        }

        internal static void LoadTool(Tools form, ToolObjectList toolObjectList)
        {
            TreeView toolTreeView = form.toolTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;
            TextBox commandLineTextBox = form.commandLineTextBox;
            TextBox workingFolderTextBox = form.workingFolderTextBox;
            ComboBox runComboBox = form.runComboBox;

            foreach (ToolObject toolObject in toolObjectList)
            {
                if (toolObject.Description != toolTreeView.SelectedNode.Text)
                {
                    continue;
                }

                descriptionTextBox.Text = toolObject.Description; //DtPad
                commandLineTextBox.Text = toolObject.CommandLine; //C:\Program Files\DtPad\DtPad.exe
                workingFolderTextBox.Text = toolObject.WorkingFolder; //C:\Program Files\DtPad
                runComboBox.SelectedIndex = toolObject.Run; //0
                break;
            }
        }

        internal static bool SaveDescription(Tools form, ToolObjectList toolObjectList)
        {
            TreeView toolTreeView = form.toolTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;

            if (String.IsNullOrEmpty(descriptionTextBox.Text))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("NameNotEmpty", className));
                descriptionTextBox.Focus();
                return true;
            }

            ToolObject selectedToolObject = null;

            foreach (ToolObject toolObject in toolObjectList)
            {
                if (toolObject.Description != toolTreeView.SelectedNode.Text && toolObject.Description == descriptionTextBox.Text)
                {
                    WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("AlreadyExists", className));
                    descriptionTextBox.Focus();
                    return true;
                }

                if (toolObject.Description == toolTreeView.SelectedNode.Text)
                {
                    selectedToolObject = toolObject;
                }
            }

            if (selectedToolObject == null)
            {
                String error = LanguageUtil.GetCurrentLanguageString("ErrorSaving", className);
                ToolException exception = new ToolException(error);
                WindowManager.ShowErrorBox(form, error, exception);
                return false;
            }

            selectedToolObject.Description = descriptionTextBox.Text;
            toolTreeView.SelectedNode.Text = selectedToolObject.Description;

            return true;
        }

        internal static void SaveCommandLine(Tools form, ToolObjectList toolObjectList)
        {
            TreeView toolTreeView = form.toolTreeView;
            TextBox commandLineTextBox = form.commandLineTextBox;

            foreach (ToolObject toolObject in toolObjectList)
            {
                if (toolObject.Description != toolTreeView.SelectedNode.Text)
                {
                    continue;
                }

                toolObject.CommandLine = commandLineTextBox.Text;
                return;
            }
        }

        internal static void SaveWorkingFolder(Tools form, ToolObjectList toolObjectList)
        {
            TreeView toolTreeView = form.toolTreeView;
            TextBox workingFolderTextBox = form.workingFolderTextBox;

            foreach (ToolObject toolObject in toolObjectList)
            {
                if (toolObject.Description != toolTreeView.SelectedNode.Text)
                {
                    continue;
                }

                toolObject.WorkingFolder = workingFolderTextBox.Text;
                return;
            }
        }

        internal static void SaveRun(Tools form, ToolObjectList toolObjectList)
        {
            TreeView toolTreeView = form.toolTreeView;
            ComboBox runComboBox = form.runComboBox;

            foreach (ToolObject toolObject in toolObjectList)
            {
                if (toolObject.Description != toolTreeView.SelectedNode.Text)
                {
                    continue;
                }

                toolObject.Run = runComboBox.SelectedIndex;
                return;
            }
        }

        internal static int AddTool(Tools form, ToolObjectList toolObjectList, int newToolIdentity)
        {
            TreeView toolTreeView = form.toolTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;
            TextBox commandLineTextBox = form.commandLineTextBox;
            TextBox workingFolderTextBox = form.workingFolderTextBox;
            ComboBox runComboBox = form.runComboBox;
            Button removeButton = form.removeButton;

            String newTool = LanguageUtil.GetCurrentLanguageString("New", className);

            newToolIdentity++;
            String description = String.Format("{0} ({1})", newTool, newToolIdentity);

            while (CheckIdentityExists(form, toolObjectList, description))
            {
                newToolIdentity++;
                description = String.Format("{0} ({1})", newTool, newToolIdentity);
            }

            ToolObject toolObject = new ToolObject(description, String.Empty, String.Empty, 0);
            toolObjectList.Add(toolObject);

            toolTreeView.Focus();
            toolTreeView.Nodes.Add(description);
            toolTreeView.SelectedNode = toolTreeView.Nodes[toolTreeView.Nodes.Count - 1];

            descriptionTextBox.Enabled = true;
            commandLineTextBox.Enabled = true;
            workingFolderTextBox.Enabled = true;
            runComboBox.Enabled = true;
            removeButton.Enabled = true;

            return newToolIdentity;
        }

        internal static bool RemoveTool(Tools form, ToolObjectList toolObjectList)
        {
            TreeView toolTreeView = form.toolTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;
            TextBox commandLineTextBox = form.commandLineTextBox;
            TextBox workingFolderTextBox = form.workingFolderTextBox;
            ComboBox runComboBox = form.runComboBox;
            Button removeButton = form.removeButton;

            int indexNodeToRemove = toolTreeView.SelectedNode.Index;
            int toolPositionInList = GetToolPositionInList(toolObjectList, descriptionTextBox.Text);
            if (toolPositionInList == -1)
            {
                String error = LanguageUtil.GetCurrentLanguageString("ErrorRemoving", className);
                ToolException exception = new ToolException(error);
                WindowManager.ShowErrorBox(form, error, exception);
                return false;
            }
            toolObjectList.RemoveAt(toolPositionInList);

            toolTreeView.Focus();
            toolTreeView.Nodes.Remove(toolTreeView.SelectedNode);

            if (toolTreeView.Nodes.Count == 0)
            {
                descriptionTextBox.Text = String.Empty;
                commandLineTextBox.Text = String.Empty;
                workingFolderTextBox.Text = String.Empty;
                runComboBox.SelectedIndex = 0;

                descriptionTextBox.Enabled = false;
                commandLineTextBox.Enabled = false;
                workingFolderTextBox.Enabled = false;
                runComboBox.Enabled = false;
                removeButton.Enabled = false;
            }
            else if (toolTreeView.Nodes.Count > indexNodeToRemove)
            {
                toolTreeView.SelectedNode = toolTreeView.Nodes[indexNodeToRemove];

                descriptionTextBox.Enabled = true;
                commandLineTextBox.Enabled = true;
                workingFolderTextBox.Enabled = true;
                runComboBox.Enabled = true;
                removeButton.Enabled = true;
            }
            else
            {
                toolTreeView.SelectedNode = toolTreeView.Nodes[indexNodeToRemove - 1];

                descriptionTextBox.Enabled = true;
                commandLineTextBox.Enabled = true;
                workingFolderTextBox.Enabled = true;
                runComboBox.Enabled = true;
                removeButton.Enabled = true;
            }

            return true;
        }

        internal static bool SaveToolsIntoFile(Form form, ToolObjectList toolObjectList)
        {
            String fileContent = String.Empty;

            foreach (ToolObject toolObject in toolObjectList)
            {
                if (String.IsNullOrEmpty(toolObject.CommandLine))
                {
                    WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("Unvalorized", className));
                    return false;
                }

                fileContent += String.Format("{0}|{1}|{2}|{3}{4}", toolObject.Description, toolObject.CommandLine, toolObject.WorkingFolder, toolObject.Run, Environment.NewLine);
            }

            FileListManager.SaveFileList(ConstantUtil.toFile, fileContent);

            return true;
        }

        internal static ToolObjectList GetToolObjectListFromToFile(Form form)
        {
            try
            {
                ToolObjectList toolObjectList = new ToolObjectList();

                String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.toFile));

                String[] separator = {Environment.NewLine};
                String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                foreach (String extensionString in splittedFileContent)
                {
                    separator[0] = "|";
                    String[] splittedExtensionContent = extensionString.Split(separator, StringSplitOptions.None);

                    ToolObject toolObject = new ToolObject(splittedExtensionContent[0], splittedExtensionContent[1], splittedExtensionContent[2], Convert.ToInt32(splittedExtensionContent[3]));
                    toolObjectList.Add(toolObject);
                }

                return toolObjectList;
            }
            catch (Exception)
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ErrorReading", className));
                FileListManager.SaveFileList(ConstantUtil.toFile, String.Empty);

                return GetToolObjectListFromToFile(form);
            }
        }

        internal static ProcessWindowStyle GetProcessWindowStyleFromRun(String run)
        {
            ProcessWindowStyle processWindowStyle;
            
            switch (run)
            {
                case "0":
                    processWindowStyle = ProcessWindowStyle.Normal;
                    break;
                case "1":
                    processWindowStyle = ProcessWindowStyle.Minimized;
                    break;
                case "2":
                    processWindowStyle = ProcessWindowStyle.Maximized;
                    break;

                default:
                    processWindowStyle = ProcessWindowStyle.Normal;
                    break;
            }

            return processWindowStyle;
        }

        internal static ToolObjectList MoveTool(Tools form, ObjectListUtil.Movement move, ToolObjectList toolObjectList)
        {
            TreeView toolTreeView = form.toolTreeView;

            TreeNode selectedNode = toolTreeView.SelectedNode;
            int selectedNodeIndex = toolTreeView.SelectedNode.Index;
            ToolObject toolObject = (ToolObject)toolObjectList[selectedNodeIndex];

            return (ToolObjectList)ObjectListUtil.MoveObject(move, toolObjectList, toolObject, toolTreeView, selectedNode, selectedNodeIndex);
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool CheckIdentityExists(Tools form, ToolObjectList toolObjectList, String descriptionToSearch)
        {
            TreeView toolTreeView = form.toolTreeView;

            //foreach (ToolObject toolObject in toolObjectList)
            //{
            //    if (toolObject.Description != toolTreeView.SelectedNode.Text && toolObject.Description == descriptionToSearch)
            //    {
            //        return true;
            //    }
            //}
            return toolObjectList.Cast<ToolObject>().Any(toolObject => toolObject.Description != toolTreeView.SelectedNode.Text && toolObject.Description == descriptionToSearch);
        }

        private static int GetToolPositionInList(IList toolObjectList, String toolDescription)
        {
            for (int i = 0; i < toolObjectList.Count; i++)
            {
                ToolObject toolObject = (ToolObject)toolObjectList[i];

                if (toolObject.Description == toolDescription)
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion Private Methods
    }
}
