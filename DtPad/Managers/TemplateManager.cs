using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Exceptions;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Templates manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TemplateManager
    {
        private const String className = "TemplateManager";

        #region Internal Methods

        internal static TemplateObjectList LoadTemplatesList(Templates form)
        {
            TreeView templateTreeView = form.templateTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;
            TextBox textTextBox = form.textTextBox;
            Button removeButton = form.removeButton;

            TemplateObjectList templateObjectList = new TemplateObjectList();

            String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.tmFile));

            String[] separator = { Environment.NewLine };
            String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (splittedFileContent.Length > 0)
            {
                templateTreeView.BeginUpdate();
            }

            foreach (String templateString in splittedFileContent) //HTML@|-<html></html>
            {
                separator[0] = "@|-";
                String[] splittedExtensionContent = templateString.Split(separator, StringSplitOptions.None);

                if (splittedExtensionContent.Length != 2)
                {
                    WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ErrorReading", className));
                    FileListManager.SaveFileList(ConstantUtil.tmFile, String.Empty);
                    return LoadTemplatesList(form);
                }

                templateTreeView.Nodes.Add(splittedExtensionContent[0]); //HTML

                TemplateObject templateObject = new TemplateObject(splittedExtensionContent[0], splittedExtensionContent[1]);
                templateObjectList.Add(templateObject);
            }

            if (splittedFileContent.Length > 0)
            {
                templateTreeView.EndUpdate();
            }

            templateTreeView.Focus();

            if (templateTreeView.Nodes.Count > 0)
            {
                templateTreeView.SelectedNode = templateTreeView.Nodes[0];
            }
            else
            {
                descriptionTextBox.Enabled = false;
                textTextBox.Enabled = false;
                removeButton.Enabled = false;
            }

            return templateObjectList;
        }

        internal static void LoadTemplate(Templates form, TemplateObjectList templateObjectList)
        {
            TreeView templateTreeView = form.templateTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;
            TextBox textTextBox = form.textTextBox;

            foreach (TemplateObject templateObject in templateObjectList)
            {
                if (templateObject.Description != templateTreeView.SelectedNode.Text)
                {
                    continue;
                }

                descriptionTextBox.Text = templateObject.Description; //HTML
                textTextBox.Text = ElaborateTextToTextBox(templateObject.Text); //<html></html>
                break;
            }
        }

        internal static bool SaveDescription(Templates form, TemplateObjectList templateObjectList)
        {
            TreeView templateTreeView = form.templateTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;

            if (String.IsNullOrEmpty(descriptionTextBox.Text))
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("NameNotEmpty", className));
                descriptionTextBox.Focus();
                return true;
            }

            TemplateObject selectedTemplateObject = null;

            foreach (TemplateObject templateObject in templateObjectList)
            {
                if (templateObject.Description != templateTreeView.SelectedNode.Text && templateObject.Description == descriptionTextBox.Text)
                {
                    WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("AlreadyExists", className));
                    descriptionTextBox.Focus();
                    return true;
                }

                if (templateObject.Description == templateTreeView.SelectedNode.Text)
                {
                    selectedTemplateObject = templateObject;
                }
            }

            if (selectedTemplateObject == null)
            {
                String error = LanguageUtil.GetCurrentLanguageString("ErrorSaving", className);
                TemplateException exception = new TemplateException(error);
                WindowManager.ShowErrorBox(form, error, exception);
                return false;
            }

            selectedTemplateObject.Description = descriptionTextBox.Text;
            templateTreeView.SelectedNode.Text = selectedTemplateObject.Description;

            return true;
        }

        internal static void SaveText(Templates form, TemplateObjectList templateObjectList)
        {
            TreeView templateTreeView = form.templateTreeView;
            TextBox textTextBox = form.textTextBox;

            foreach (TemplateObject templateObject in templateObjectList)
            {
                if (templateObject.Description != templateTreeView.SelectedNode.Text)
                {
                    continue;
                }
                templateObject.Text = ElaborateTextToExternal(textTextBox.Text);
                return;
            }
        }

        internal static int AddTemplate(Templates form, TemplateObjectList templateObjectList, int newTemplateIdentity)
        {
            TreeView templateTreeView = form.templateTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;
            TextBox textTextBox = form.textTextBox;
            Button removeButton = form.removeButton;

            String newTemplate = LanguageUtil.GetCurrentLanguageString("New", className);

            newTemplateIdentity++;
            String description = String.Format("{0} ({1})", newTemplate, newTemplateIdentity);

            while (CheckIdentityExists(form, templateObjectList, description))
            {
                newTemplateIdentity++;
                description = String.Format("{0} ({1})", newTemplate, newTemplateIdentity);
            }

            TemplateObject extensionObject = new TemplateObject(description, String.Empty);
            templateObjectList.Add(extensionObject);

            templateTreeView.Focus();
            templateTreeView.Nodes.Add(description);
            templateTreeView.SelectedNode = templateTreeView.Nodes[templateTreeView.Nodes.Count - 1];

            descriptionTextBox.Enabled = true;
            textTextBox.Enabled = true;
            removeButton.Enabled = true;

            return newTemplateIdentity;
        }

        internal static bool RemoveTemplate(Templates form, TemplateObjectList templateObjectList)
        {
            TreeView templateTreeView = form.templateTreeView;
            TextBox descriptionTextBox = form.descriptionTextBox;
            TextBox textTextBox = form.textTextBox;
            Button removeButton = form.removeButton;

            int indexNodeToRemove = templateTreeView.SelectedNode.Index;
            int templatePositionInList = GetTemplatePositionInList(templateObjectList, descriptionTextBox.Text);
            if (templatePositionInList == -1)
            {
                String error = LanguageUtil.GetCurrentLanguageString("ErrorRemoving", className);
                TemplateException exception = new TemplateException(error);
                WindowManager.ShowErrorBox(form, error, exception);
                return false;
            }
            templateObjectList.RemoveAt(templatePositionInList);

            templateTreeView.Focus();
            templateTreeView.Nodes.Remove(templateTreeView.SelectedNode);

            if (templateTreeView.Nodes.Count == 0)
            {
                descriptionTextBox.Text = String.Empty;
                textTextBox.Text = String.Empty;

                descriptionTextBox.Enabled = false;
                textTextBox.Enabled = false;
                removeButton.Enabled = false;
            }
            else if (templateTreeView.Nodes.Count > indexNodeToRemove)
            {
                templateTreeView.SelectedNode = templateTreeView.Nodes[indexNodeToRemove];

                descriptionTextBox.Enabled = true;
                textTextBox.Enabled = true;
                removeButton.Enabled = true;
            }
            else
            {
                templateTreeView.SelectedNode = templateTreeView.Nodes[indexNodeToRemove - 1];

                descriptionTextBox.Enabled = true;
                textTextBox.Enabled = true;
                removeButton.Enabled = true;
            }

            return true;
        }

        internal static bool SaveTemplatesIntoFile(Form form, TemplateObjectList templateObjectList)
        {
            String fileContent = String.Empty;

            foreach (TemplateObject templateObject in templateObjectList)
            {
                if (String.IsNullOrEmpty(templateObject.Text))
                {
                    WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("Unvalorized", className));
                    return false;
                }

                fileContent += String.Format("{0}@|-{1}{2}", templateObject.Description, templateObject.Text, Environment.NewLine);
            }

            FileListManager.SaveFileList(ConstantUtil.tmFile, fileContent);

            return true;
        }

        internal static TemplateObjectList GetTemplateObjectListFromTmFile(Form form)
        {
            try
            {
                TemplateObjectList templateObjectList = new TemplateObjectList();

                String fileContent = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.tmFile));

                String[] separator = { Environment.NewLine };
                String[] splittedFileContent = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                foreach (String extensionString in splittedFileContent)
                {
                    separator[0] = "@|-";
                    String[] splittedExtensionContent = extensionString.Split(separator, StringSplitOptions.None);

                    TemplateObject templateObject = new TemplateObject(splittedExtensionContent[0], splittedExtensionContent[1]);
                    templateObjectList.Add(templateObject);
                }

                return templateObjectList;
            }
            catch (Exception)
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("ErrorReading", className));
                FileListManager.SaveFileList(ConstantUtil.tmFile, String.Empty);

                return GetTemplateObjectListFromTmFile(form);
            }
        }

        internal static void GetTemplate(Form1 form, String template)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            template = ElaborateTextToRichTextBox(template);

            if (!TabManager.IsCurrentTabInUse(form))
            {
                pageTextBox.SelectedText = template;
                TextManager.RefreshUndoRedoExternal(form);
                return;
            }

            form.TabIdentity = TabManager.AddNewPage(form, form.TabIdentity);
            pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            pageTextBox.SelectedText = template;
            TextManager.RefreshUndoRedoExternal(form);
        }

        internal static void ClearTemplatesMenu(Form1 form)
        {
            ToolStripMenuItem templatesToolStripMenuItem = form.templatesToolStripMenuItem;

            templatesToolStripMenuItem.DropDownItems.Clear();

            ToolStripMenuItem emptyTemplateToolStripMenuItem = new ToolStripMenuItem
                                                                   {
                                                                       Enabled = false,
                                                                       Name = "emptyTemplateToolStripMenuItem",
                                                                       Size = new Size(152, 22),
                                                                       Text = LanguageUtil.GetCurrentLanguageString("emptyTemplateToolStripMenuItem", "Form1")
                                                                   };
            templatesToolStripMenuItem.DropDownItems.Add(emptyTemplateToolStripMenuItem);
        }

        internal static TemplateObjectList MoveTemplate(Templates form, ObjectListUtil.Movement move, TemplateObjectList templateObjectList)
        {
            TreeView templateTreeView = form.templateTreeView;

            TreeNode selectedNode = templateTreeView.SelectedNode;
            int selectedNodeIndex = templateTreeView.SelectedNode.Index;
            TemplateObject templateObject = (TemplateObject)templateObjectList[selectedNodeIndex];

            return (TemplateObjectList)ObjectListUtil.MoveObject(move, templateObjectList, templateObject, templateTreeView, selectedNode, selectedNodeIndex);
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool CheckIdentityExists(Templates form, TemplateObjectList templateObjectList, String descriptionToSearch)
        {
            TreeView templateTreeView = form.templateTreeView;

            //foreach (TemplateObject templateObject in templateObjectList)
            //{
            //    if (templateObject.Description != templateTreeView.SelectedNode.Text && templateObject.Description == descriptionToSearch)
            //    {
            //        return true;
            //    }
            //}
            return templateObjectList.Cast<TemplateObject>().Any(templateObject => templateObject.Description != templateTreeView.SelectedNode.Text && templateObject.Description == descriptionToSearch);
        }

        private static int GetTemplatePositionInList(IList templateObjectList, String templateDescription)
        {
            for (int i = 0; i < templateObjectList.Count; i++)
            {
                TemplateObject templateObject = (TemplateObject)templateObjectList[i];

                if (templateObject.Description == templateDescription)
                {
                    return i;
                }
            }

            return -1;
        }

        private static String ElaborateTextToExternal(String text)
        {
            text = text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            text = text.Replace("\n", "\\n");
            text = text.Replace("\t", "\\t");

            return text;
        }

        private static String ElaborateTextToTextBox(String text)
        {
            text = text.Replace("\\n", "\n");
            text = text.Replace("\\t", "\t");
            text = text.Replace(ConstantUtil.newLine, ConstantUtil.newLineNotCompatible);

            return text;
        }

        private static String ElaborateTextToRichTextBox(String text)
        {
            text = text.Replace("\\n", "\n");
            text = text.Replace("\\t", "\t");
            text = text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);

            return text;
        }

        #endregion Private Methods
    }
}
