using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraTab;
using DtControls;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Notes manager (internal explorer).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class NoteManager
    {
        private const String className = "NoteManager";

        internal enum ExportTypeEnum
        {
            [Description("Export in a XML file")]
            Xml,
            [Description("Export in a TXT file")]
            Txt
        }

        internal enum TagEnum
        {
            Black,
            Orange,
            Red,
            Green,
            Blue
        }

        #region Internal Methods

        internal static void GetNotesList(Form1 form)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;
            ContextMenuStrip noteContextMenuStrip = form.notePanel.noteContextMenuStrip;

            notesTreeView.BeginUpdate();
            notesTreeView.Nodes.Clear();
            
            try
            {
                XmlNodeList noteNodeList;
                using (StreamReader reader = new StreamReader(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile)))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(reader);

                    noteNodeList = xmldoc.GetElementsByTagName("note");
                }

                foreach (XmlNode noteNode in noteNodeList)
                {
                    TagEnum color;

                    try
                    {
                        color = (TagEnum)Enum.Parse(typeof(TagEnum), noteNode.Attributes["tag"].Value, true);
                    }
                    catch (Exception)
                    {
                        color = TagEnum.Black;
                    }

                    TreeNode node = new TreeNode(noteNode.ChildNodes[0].InnerText)
                                        {
                                            ContextMenuStrip = noteContextMenuStrip,
                                            ImageIndex = Convert.ToInt32(color),
                                            SelectedImageIndex = Convert.ToInt32(color),
                                            ForeColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), color.ToString(), true))
                                        };
                    notesTreeView.Nodes.Add(node);
                }

                if (notesTreeView.Nodes.Count > 0)
                {
                    notesTreeView.SelectedNode = notesTreeView.Nodes[0];
                }

                ExplorerManager.ToggleNoteInput(form);
                notesTreeView.EndUpdate();
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
            }
            catch (DirectoryNotFoundException exception)
            {
                ManageError(form, exception);
            }
        }

        internal static void ClearNotes(Form1 form)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;

            notesTreeView.Nodes.Clear();
        }

        internal static String GetNoteText(Form1 form, String title)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                XmlNodeList noteNodeList = xmldoc.GetElementsByTagName("note");

                foreach (XmlNode noteNode in noteNodeList)
                {
                    if (noteNode.ChildNodes[0].InnerText == title)
                    {
                        return noteNode.ChildNodes[1].InnerText;
                    }
                }
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
            }

            return String.Empty;
        }

        internal static void AddNote(Form1 form, String title)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                if (CheckNoteTitleExists(form, title))
                {
                    WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("AlreadyExists", className));
                    GetNotesList(form);
                    return;
                }

                XmlElement newNote = xmldoc.CreateElement("note");

                XmlElement noteTitleNode = xmldoc.CreateElement("title");
                noteTitleNode.InnerText = title;
                newNote.AppendChild(noteTitleNode);
                XmlElement noteTextNode = xmldoc.CreateElement("text");
                noteTextNode.InnerText = String.Empty;
                newNote.AppendChild(noteTextNode);

                xmldoc.DocumentElement.InsertAfter(newNote, xmldoc.DocumentElement.LastChild);
                SaveXml(xmldoc, Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
            }
        }

        internal static void RemoveNote(Form1 form, String title)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                XmlNodeList noteNodeList = xmldoc.GetElementsByTagName("note");

                foreach (XmlNode noteNode in noteNodeList)
                {
                    if (noteNode.ChildNodes[0].InnerText != title)
                    {
                        continue;
                    }

                    noteNode.ParentNode.RemoveChild(noteNode);
                    break;
                }

                SaveXml(xmldoc, Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
            }
        }

        internal static bool SaveTitleNode(Form1 form, String oldTitle, String newTitle)
        {
            TextBox nodeTitleTextBox = form.notePanel.noteTitleTextBox;
            //TextBox nodeTextTextBox = form.notePanel.nodeTextTextBox;

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                if (CheckNoteTitleExists(form, newTitle))
                {
                    WindowManager.ShowAlertBox(form,
                                                LanguageUtil.GetCurrentLanguageString("AlreadyExists", className));
                    nodeTitleTextBox.Text = oldTitle;
                    //GetNotesList(form);
                    //nodeTitleTextBox.Text = oldTitle;
                    //nodeTextTextBox.Text = GetNoteText(form, oldTitle);
                    return false;
                }

                XmlNodeList noteNodeList = xmldoc.GetElementsByTagName("note");

                foreach (XmlNode noteNode in noteNodeList)
                {
                    if (noteNode.ChildNodes[0].InnerText != oldTitle)
                    {
                        continue;
                    }

                    noteNode.ChildNodes[0].InnerText = newTitle;
                    break;
                }

                SaveXml(xmldoc, Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
                return false;
            }

            return true;
        }

        internal static void SaveTextNode(Form1 form, String title, String text)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                XmlNodeList noteNodeList = xmldoc.GetElementsByTagName("note");

                foreach (XmlNode noteNode in noteNodeList)
                {
                    if (noteNode.ChildNodes[0].InnerText != title)
                    {
                        continue;
                    }

                    noteNode.ChildNodes[1].InnerText = text;
                    break;
                }

                SaveXml(xmldoc, Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
            }
        }

        internal static void ExportNotes(Form1 form, ExportTypeEnum exportType)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            CustomLineNumbers customLineNumbers;
            String content;
            bool linesDisabled = false;

            switch (exportType)
            {
                case ExportTypeEnum.Xml:
                    if (TabManager.IsCurrentTabInUse(form))
                    {
                        form.TabIdentity = TabManager.AddNewPage(form, form.TabIdentity);
                        pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                    }

                    customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.SelectedTabPage);
                    content = FileUtil.ReadToEndWithStandardEncoding(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                    if (StringUtil.AreLinesTooMuchForPasteWithRowLines(content) && customLineNumbers.Visible)
                    {
                        WindowManager.CheckLineNumbers(form, false, true);
                        linesDisabled = true;
                    }

                    pageTextBox.SelectedText = content;

                    if (linesDisabled)
                    {
                        WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("LineNumbersDisabled", className));
                    }

                    TextManager.RefreshUndoRedoExternal(form);
                    break;
                case ExportTypeEnum.Txt:
                    try
                    {
                        XmlDocument xmldoc = new XmlDocument();
                        xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                        XmlNodeList noteNodeList = xmldoc.GetElementsByTagName("note");

                        foreach (XmlNode noteNode in noteNodeList)
                        {
                            if (TabManager.IsCurrentTabInUse(form))
                            {
                                form.TabIdentity = TabManager.AddNewPage(form, form.TabIdentity);
                                pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                            }

                            customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.SelectedTabPage);
                            content = noteNode.ChildNodes[0].InnerText + ConstantUtil.newLine + ConstantUtil.newLine + noteNode.ChildNodes[1].InnerText;
                            linesDisabled = false;

                            if (StringUtil.AreLinesTooMuchForPasteWithRowLines(content) && customLineNumbers.Visible)
                            {
                                WindowManager.CheckLineNumbers(form, false, true);
                                linesDisabled = true;
                            }

                            pageTextBox.SelectedText = content;

                            if (linesDisabled)
                            {
                                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("LineNumbersDisabled", className));
                            }

                            TextManager.RefreshUndoRedoExternal(form);
                        }
                    }
                    catch (XmlException exception)
                    {
                        ManageError(form, exception);
                    }
                    break;
            }
        }

        internal static void MoveNoteFirstOrUp(Form1 form, bool first = false)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;

            TreeNode selectedNode = notesTreeView.SelectedNode;
            int selectedNodeIndex = notesTreeView.SelectedNode.Index;

            if (selectedNodeIndex == 0)
            {
                return;
            }

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                notesTreeView.Nodes.Remove(selectedNode);
                notesTreeView.Nodes.Insert(first ? 0 : selectedNodeIndex - 1, selectedNode);
                notesTreeView.SelectedNode = selectedNode;

                //Save XML
                XmlNodeList notesNodeList = xmldoc.GetElementsByTagName("notes");
                XmlNodeList nodeNodeList = xmldoc.GetElementsByTagName("note");
                XmlNode selectedNodeXml = nodeNodeList[selectedNodeIndex];

                notesNodeList[0].RemoveChild(nodeNodeList[selectedNodeIndex]);
                notesNodeList[0].InsertBefore(selectedNodeXml, first ? nodeNodeList[0] : nodeNodeList[selectedNodeIndex - 1]);

                SaveXml(xmldoc, Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
            }
        }

        internal static void MoveNoteDownOrLast(Form1 form, bool last = false)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;

            TreeNode selectedNode = notesTreeView.SelectedNode;
            int selectedNodeIndex = notesTreeView.SelectedNode.Index;

            if (selectedNodeIndex >= notesTreeView.Nodes.Count - 1)
            {
                return;
            }

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                notesTreeView.Nodes.Remove(selectedNode);
                notesTreeView.Nodes.Insert(last ? notesTreeView.Nodes.Count : selectedNodeIndex + 1, selectedNode);

                notesTreeView.SelectedNode = selectedNode;

                //Save XML
                XmlNodeList notesNodeList = xmldoc.GetElementsByTagName("notes");
                XmlNodeList nodeNodeList = xmldoc.GetElementsByTagName("note");
                XmlNode selectedNodeXml = nodeNodeList[selectedNodeIndex];

                notesNodeList[0].RemoveChild(nodeNodeList[selectedNodeIndex]);
                notesNodeList[0].InsertAfter(selectedNodeXml, last ? nodeNodeList[notesTreeView.Nodes.Count - 2] : nodeNodeList[selectedNodeIndex]);

                SaveXml(xmldoc, Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
            }
        }

        internal static void OpenNoteOnEditor(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            TreeView notesTreeView = form.notePanel.notesTreeView;

            TreeNode selectedNode = notesTreeView.SelectedNode;
            String content;
            bool linesDisabled = false;

            try
            {
                content = GetNoteText(form, selectedNode.Text);
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
                return;
            }

            if (TabManager.IsCurrentTabInUse(form))
            {
                form.TabIdentity = TabManager.AddNewPage(form, form.TabIdentity);
            }

            CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.SelectedTabPage);

            if (StringUtil.AreLinesTooMuchForPasteWithRowLines(content) && customLineNumbers.Visible)
            {
                WindowManager.CheckLineNumbers(form, false, true);
                linesDisabled = true;
            }

            ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Text = content;

            if (linesDisabled)
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("LineNumbersDisabled", className));
            }
        }

        internal static void ChangeNoteColor(Form1 form, TagEnum color)
        {
            TreeView notesTreeView = form.notePanel.notesTreeView;

            TreeNode selectedNode = notesTreeView.SelectedNode;
            int selectedNodeIndex = notesTreeView.SelectedNode.Index;

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                //Save XML
                XmlNodeList nodeNodeList = xmldoc.GetElementsByTagName("note");
                XmlElement selectedNodeXml = (XmlElement) nodeNodeList[selectedNodeIndex];
                selectedNodeXml.SetAttribute("tag", color.ToString());

                SaveXml(xmldoc, Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));

                selectedNode.ImageIndex = Convert.ToInt32(color);
                selectedNode.SelectedImageIndex = Convert.ToInt32(color);
                selectedNode.ForeColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), color.ToString(), true));
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
            }
        }

        internal static void CopyTextIntoNewNote(Form1 form)
        {
            XtraTabControl verticalTabControl = form.verticalTabControl;
            ToolStripButton verticalContainerToolStripButton = form.verticalContainerToolStripButton;
            XtraTabPage notesTabPage = form.notesTabPage;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (!verticalContainerToolStripButton.Checked)
            {
                WindowManager.CheckInternalExplorer(form, !verticalContainerToolStripButton.Checked, true);
            }

            verticalTabControl.SelectedTabPage = notesTabPage;

            ExplorerManager.AddNote(form, form.notePanel.noteIdentity);
            form.notePanel.nodeTextTextBox.Text = pageTextBox.SelectedText;
            form.notePanel.Select();
            form.notePanel.nodeTextTextBox.Select();
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool CheckNoteTitleExists(Form1 form, String title)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.noFile));
                XmlNodeList noteNodeList = xmldoc.GetElementsByTagName("note");

                //foreach (XmlNode noteNode in noteNodeList)
                //{
                //    if (noteNode.ChildNodes[0].InnerText == title)
                //    {
                //        return true;
                //    }
                //}
                if (noteNodeList.Cast<XmlNode>().Any(noteNode => noteNode.ChildNodes[0].InnerText == title))
                {
                    return true;
                }
            }
            catch (XmlException exception)
            {
                ManageError(form, exception);
            }

            return false;
        }

        private static void ManageError(Form1 form, Exception exception)
        {
            WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorCreating", className), exception);

            form.TabIdentity = FileManager.OpenFile(form, form.TabIdentity, new[] { ConstantUtil.noFile });
            FileListManager.SaveFileList(ConstantUtil.noFile, ConstantUtil.defaultNoteFileContent);
        }

        private static void SaveXml(XmlDocument xmldoc, String fileNameAndPath)
        {
            xmldoc.Save(fileNameAndPath);

            //Thread newThread = new Thread(SaveFileOnDropbox);
            //newThread.Start(new DropboxObject(form, form.DropboxCloudStorage, ConstantUtil.noFileName, xmldoc.InnerXml));
        }

        //private static void SaveFileOnDropbox(object dropboxObject)
        //{
        //    DropboxObject dropboxObjectCasted = (DropboxObject)dropboxObject;
        //    DropboxManager.SaveFileOnDropbox(dropboxObjectCasted.form, DropboxManager.GetDefaultDtPadDirectory(dropboxObjectCasted.cloudStorage), dropboxObjectCasted.fileName, dropboxObjectCasted.content);
        //}

        #endregion Private Methods
    }
}
