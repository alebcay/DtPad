using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// File explorer manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class FileExplorerManager
    {
        private const String className = "FileExplorerManager";

        #region Internal Methods

        internal static void LoadFileTree(Form1 form, bool forceLoad)
        {
            TreeView fileExplorerTreeView = form.filePanel.fileExplorerTreeView;
            ContextMenuStrip directoryContextMenuStrip = form.filePanel.directoryContextMenuStrip;
            XtraTabControl verticalTabControl = form.verticalTabControl;
            XtraTabPage fileExplorerTabPage = form.fileExplorerTabPage;

            if ((verticalTabControl.SelectedTabPage != fileExplorerTabPage) || (!forceLoad && fileExplorerTreeView.Nodes.Count > 0))
            {
                return;
            }
            
            try
            {
                fileExplorerTreeView.BeginUpdate();
                fileExplorerTreeView.Nodes.Clear();
                
                TreeNode desktop = new TreeNode
                                       {
                                           Text = "Desktop",
                                           Tag = "Desktop",
                                           ToolTipText = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                           ImageIndex = 0,
                                           SelectedImageIndex = 0,
                                           ContextMenuStrip = directoryContextMenuStrip
                                       };
                desktop.Nodes.Add(String.Empty);
                fileExplorerTreeView.Nodes.Add(desktop);

                foreach (DriveInfo drv in DriveInfo.GetDrives())
                {
                    TreeNode fChild = new TreeNode();

                    switch (drv.DriveType)
                    {
                        case DriveType.Fixed:
                            fChild.ImageIndex = 1;
                            fChild.SelectedImageIndex = 1;
                            fChild.Tag = "Fixed";
                            break;
                        case DriveType.CDRom:
                            fChild.ImageIndex = 2;
                            fChild.SelectedImageIndex = 2;
                            fChild.Tag = "CDRom";
                            break;
                        case DriveType.Network:
                            fChild.ImageIndex = 3;
                            fChild.SelectedImageIndex = 3;
                            fChild.Tag = "Network";
                            break;
                        case DriveType.Ram:
                        case DriveType.Removable:
                            fChild.ImageIndex = 4;
                            fChild.SelectedImageIndex = 4;
                            fChild.Tag = "Removable";
                            break;
                    }

                    fChild.Text = drv.Name;
                    fChild.ToolTipText = drv.Name;
                    fChild.ContextMenuStrip = directoryContextMenuStrip;
                    fChild.Nodes.Add(String.Empty);
                    fileExplorerTreeView.Nodes.Add(fChild);
                }

                fileExplorerTreeView.EndUpdate();
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorLoadingTree", className), exception);
            }
        }

        internal static void LoadDirectory(Form1 form, TreeNode parentNode, bool refresh)
        {
            ContextMenuStrip fileContextMenuStrip = form.filePanel.fileContextMenuStrip;
            ContextMenuStrip directoryContextMenuStrip = form.filePanel.directoryContextMenuStrip;
            ToolStripButton hiddenToolStripButton = form.filePanel.hiddenToolStripButton;
            
            try
            {
                if (!refresh && !String.IsNullOrEmpty(parentNode.Nodes[0].Text) && (parentNode.Tag == null || parentNode.Tag.ToString() != "CDRom"))
                {
                    return;
                }

                DirectoryInfo rootDir;
                Char[] arr = {'\\'};
                String[] nameList = parentNode.FullPath.Split(arr);

                if (nameList.GetValue(0).ToString() == "Desktop")
                {
                    String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";

                    for (int i = 1; i < nameList.Length; i++)
                    {
                        path = path + nameList[i] + "\\";
                    }

                    rootDir = new DirectoryInfo(path);
                }
                else
                {
                    rootDir = new DirectoryInfo(parentNode.FullPath + "\\");
                }

                //if (rootDir.Name == rootDir.Root.Name)
                //{
                //    LoadFileTree(form, refresh);
                //}

                parentNode.Nodes.Clear();

                DirectoryInfo[] directories = rootDir.GetDirectories();
                Array.Sort(directories, new Comparison<DirectoryInfo>((d1, d2) => String.Compare(d1.Name, d2.Name))); //return string.Compare(d1.Name, d2.Name);
                foreach (DirectoryInfo directory in directories)
                {
                    if (!hiddenToolStripButton.Checked && directory.Attributes.ToString().Contains("Hidden"))
                    {
                        continue;
                    }
                    
                    int dirImageIndex = 5;
                    if (directory.Attributes.ToString().Contains("Hidden"))
                    {
                        dirImageIndex = 8;
                    }

                    TreeNode node = new TreeNode
                                        {
                                            Text = directory.Name,
                                            ToolTipText = directory.FullName,
                                            ImageIndex = dirImageIndex,
                                            SelectedImageIndex = dirImageIndex,
                                            ContextMenuStrip = directoryContextMenuStrip
                                        };
                    node.Nodes.Add(String.Empty);
                    parentNode.Nodes.Add(node);
                }

                FileInfo[] files = rootDir.GetFiles();
                Array.Sort(files, new Comparison<FileInfo>((f1, f2) => String.Compare(f1.Name, f2.Name)));
                foreach (FileInfo file in files)
                {
                    if (!hiddenToolStripButton.Checked && file.Attributes.ToString().Contains("Hidden") || IsFileBlackListed(file.Name))
                    {
                        continue;
                    }

                    int fileImageIndex = 6;
                    if (file.Attributes.ToString().Contains("Hidden"))
                    {
                        fileImageIndex = 9;
                    }
                    else if (file.Extension == ".gif" || file.Extension == ".jpg" || file.Extension == ".bmp" || file.Extension == ".png")
                    {
                        fileImageIndex = 10;
                    }
                    else if (file.Extension == ".pdf")
                    {
                        fileImageIndex = 11;
                    }
                    else if (file.Extension == ".doc" || file.Extension == ".docx")
                    {
                        fileImageIndex = 12;
                    }
                    else if (file.Extension == ".xls" || file.Extension == ".xlsx")
                    {
                        fileImageIndex = 13;
                    }
                    else if (file.Extension == ".ppt" || file.Extension == ".pptx")
                    {
                        fileImageIndex = 14;
                    }
                    else if (file.Extension == ".mdb")
                    {
                        fileImageIndex = 15;
                    }
                    else if (file.Extension == ".mov" || file.Extension == ".avi" || file.Extension == ".vmw" || file.Extension == ".mpg")
                    {
                        fileImageIndex = 16;
                    }
                    else if (file.Extension == ".txt")
                    {
                        fileImageIndex = 17;
                    }

                    TreeNode node = new TreeNode
                                        {
                                            Text = file.Name,
                                            ToolTipText = file.FullName,
                                            ImageIndex = fileImageIndex,
                                            SelectedImageIndex = fileImageIndex,
                                            ContextMenuStrip = fileContextMenuStrip
                                        };
                    parentNode.Nodes.Add(node);
                }
            }
            catch (Exception exception)
            {
                if (parentNode == null)
                {
                    WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorLoadingDirFiles", className), exception);
                    return;
                }
                
                if (parentNode.Tag != null && (parentNode.Tag.ToString() == "CDRom" || parentNode.Tag.ToString() == "Removable"))
                {
                    if (parentNode.Nodes.Count == 0)
                    {
                        parentNode.Nodes.Add(null, LanguageUtil.GetCurrentLanguageString("NoDisk", className), 7, 7);
                    }

                    WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("DeviceNotReady", className));
                }
                else
                {
                    WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorLoadingDirFiles", className), exception);
                }
            }
        }

        internal static void ClearFileTree(Form1 form)
        {
            TreeView fileExplorerTreeView = form.filePanel.fileExplorerTreeView;

            fileExplorerTreeView.Nodes.Clear();
        }

        internal static void SelectNode(Form1 form)
        {
            TreeView fileExplorerTreeView = form.filePanel.fileExplorerTreeView;
            ToolStripButton openSelectedFileToolStripButton = form.filePanel.openSelectedFileToolStripButton;
            ToolStripButton refreshToolStripButton = form.filePanel.refreshToolStripButton;
            TextBox pathTextBox = form.filePanel.pathTextBox;

            if (fileExplorerTreeView.SelectedNode.ImageIndex == 6 || fileExplorerTreeView.SelectedNode.ImageIndex >= 9)
            {
                openSelectedFileToolStripButton.Enabled = true;
                refreshToolStripButton.Enabled = false;
                pathTextBox.Text = Path.GetDirectoryName(fileExplorerTreeView.SelectedNode.ToolTipText);
            }
            else
            {
                openSelectedFileToolStripButton.Enabled = false;
                refreshToolStripButton.Enabled = true;
                pathTextBox.Text = fileExplorerTreeView.SelectedNode.ToolTipText;
            }

            if (!String.IsNullOrEmpty(pathTextBox.Text))
            {
                pathTextBox.Select(pathTextBox.Text.Length, 0);
            }
        }

        internal static void OpenSelectedNode(Form1 form)
        {
            TreeView fileExplorerTreeView = form.filePanel.fileExplorerTreeView;

            if (fileExplorerTreeView.SelectedNode != null && (fileExplorerTreeView.SelectedNode.ImageIndex == 6 || fileExplorerTreeView.SelectedNode.ImageIndex >= 9))
            {
                FileManager.OpenFile(form, form.TabIdentity, new[] { fileExplorerTreeView.SelectedNode.ToolTipText });
            }
        }

        internal static void ShowPropertiesSelectedNode(Form1 form)
        {
            TreeView fileExplorerTreeView = form.filePanel.fileExplorerTreeView;

            if (fileExplorerTreeView.SelectedNode != null && (fileExplorerTreeView.SelectedNode.ImageIndex == 6 || fileExplorerTreeView.SelectedNode.ImageIndex >= 9))
            {
                WindowManager.ShowFileProperties(form, fileExplorerTreeView.SelectedNode.ToolTipText);
            }
        }

        internal static void OpenIntoWindowsExplorer(Form1 form, TreeNode parentNode)
        {
            if (parentNode.Tag != null && parentNode.Tag.ToString() == "Desktop")
            {
                OtherManager.StartProcess(form, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            }
            else
            {
                OtherManager.StartProcess(form, parentNode.ToolTipText);
            }
        }

        internal static void ListFolderContentIntoFile(Form1 form, TreeNode parentNode, bool withSizes, String filePattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            ToolStripButton hiddenToolStripButton = form.filePanel.hiddenToolStripButton;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            long totalSize = 0;

            try
            {
                //Root directory
                DirectoryInfo rootDir;
                Char[] arr = { '\\' };
                String[] nameList = parentNode.FullPath.Split(arr);

                if (nameList.GetValue(0).ToString() == "Desktop")
                {
                    String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";

                    for (int i = 1; i < nameList.Length; i++)
                    {
                        path = path + nameList[i] + "\\";
                    }

                    rootDir = new DirectoryInfo(path);
                }
                else
                {
                    rootDir = new DirectoryInfo(parentNode.FullPath + "\\");
                }

                String fileList = LanguageUtil.GetCurrentLanguageString("ListDirectoryHeader", className) + " " + rootDir.FullName + ConstantUtil.newLine + ConstantUtil.newLine;

                //Child directories
                DirectoryInfo[] directories = rootDir.GetDirectories(filePattern, searchOption);
                Array.Sort(directories, new Comparison<DirectoryInfo>((d1, d2) => String.Compare(d1.Name, d2.Name))); //return string.Compare(d1.Name, d2.Name);
                foreach (DirectoryInfo directory in directories)
                {
                    if (!hiddenToolStripButton.Checked && directory.Attributes.ToString().Contains("Hidden"))
                    {
                        continue;
                    }

                    String size = String.Empty;
                    if (withSizes)
                    {
                        int filesCount = 0;
                        int dirsCount = 0;
                        long sizeLong = DirectoryUtil.GetSize(directory, filesCount, dirsCount, out filesCount, out dirsCount);
                        totalSize += sizeLong;
                        double sizeDouble = (sizeLong / 1024f) / 1024f;

                        size = "     - " + Math.Round(sizeDouble, 2).ToString(LanguageUtil.GetInfoCulture())
                            + " MB, " + filesCount + " " + LanguageUtil.GetCurrentLanguageString("Files", className) + ", " + dirsCount + " " + LanguageUtil.GetCurrentLanguageString("Directories", className);
                    }

                    fileList += "[dir] " + directory.Name + "\\" + size + ConstantUtil.newLine; //directory.FullName
                }

                fileList += ConstantUtil.newLine;

                //Child files
                FileInfo[] files = rootDir.GetFiles(filePattern, searchOption);
                Array.Sort(files, new Comparison<FileInfo>((f1, f2) => String.Compare(f1.Name, f2.Name)));
                foreach (FileInfo file in files)
                {
                    if (!hiddenToolStripButton.Checked && file.Attributes.ToString().Contains("Hidden") || IsFileBlackListed(file.Name))
                    {
                        continue;
                    }

                    String size = String.Empty;
                    if (withSizes)
                    {
                        totalSize += file.Length;
                        double sizeDouble = (file.Length / 1024f) / 1024f;
                        size = "     - " + Math.Round(sizeDouble, 2).ToString(LanguageUtil.GetInfoCulture()) + " MB";
                    }

                    switch (searchOption)
                    {
                        case SearchOption.TopDirectoryOnly:
                            fileList = fileList + file.Name + size + ConstantUtil.newLine;
                            break;
                        default:
                            fileList = fileList + file.FullName.Substring(rootDir.FullName.Length) + size + ConstantUtil.newLine;
                            break;
                    }
                }

                if (withSizes)
                {
                    double totalSizeDouble = (totalSize / 1024f) / 1024f;
                    fileList = fileList + ConstantUtil.newLine + LanguageUtil.GetCurrentLanguageString("TotalSize", className) + " " +
                        Math.Round(totalSizeDouble, 2).ToString(LanguageUtil.GetInfoCulture()) + " MB" + ConstantUtil.newLine;
                }

                if (!TabManager.IsCurrentTabInUse(form))
                {
                    pageTextBox.SelectedText = fileList;
                    TextManager.RefreshUndoRedoExternal(form);
                    return;
                }

                form.TabIdentity = TabManager.AddNewPage(form, form.TabIdentity);
                pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                pageTextBox.SelectedText = fileList;
                TextManager.RefreshUndoRedoExternal(form);
            }
            catch (Exception exception)
            {
                if (parentNode == null)
                {
                    WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorLoadingDirFiles", className), exception);
                    return;
                }

                if (parentNode.Tag != null && (parentNode.Tag.ToString() == "CDRom" || parentNode.Tag.ToString() == "Removable"))
                {
                    if (parentNode.Nodes.Count == 0)
                    {
                        parentNode.Nodes.Add(null, LanguageUtil.GetCurrentLanguageString("NoDisk", className), 7, 7);
                    }

                    WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("DeviceNotReady", className));
                }
                else
                {
                    WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorLoadingDirFiles", className), exception);
                }
            }
        }

        internal static void GoToSelectedFolder(Form1 form)
        {
            TreeView fileExplorerTreeView = form.filePanel.fileExplorerTreeView;
            TextBox pathTextBox = form.filePanel.pathTextBox;

            if (String.IsNullOrEmpty(pathTextBox.Text))
            {
                return;
            }
            if (!Directory.Exists(pathTextBox.Text))
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("UnexistingPath", className));
                return;
            }

            String[] splittedPath = pathTextBox.Text.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            TreeNode firstNode = fileExplorerTreeView.Nodes.Cast<TreeNode>().FirstOrDefault(node => node.Text.ToLower() == splittedPath[0].ToLower() + "\\");
            //foreach (TreeNode node in fileExplorerTreeView.Nodes)
            //{
            //    if (node.Text.ToLower() == splittedPath[0].ToLower() + "\\")
            //    {
            //        firstNode = node;
            //        break;
            //    }
            //}

            if (firstNode == null)
            {
                return;
            }

            fileExplorerTreeView.SelectedNode = firstNode;
            firstNode.Expand();

            if (splittedPath.Length > 1)
            {
                CicleNodes(fileExplorerTreeView, firstNode.Nodes, splittedPath, 1);
            }
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool IsFileBlackListed(String fileName)
        {
            String[] blackListFiles = { "AUTOEXEC.BAT", "boot.ini", "BOOTSECT.DOS", "CONFIG.SYS", "dynamic.ini", "hiberfil.sys", "IO.SYS", "MSDOS.SYS", "NTDETECT.COM", "ntldr", "pagefile.sys", "pidpropsca.dll" };

            //foreach(String blackListedFile in blackListFiles)
            //{
            //    if (blackListedFile == fileName)
            //    {
            //        return true;
            //    }
            //}
            return blackListFiles.Any(blackListedFile => blackListedFile == fileName);
        }

        private static void CicleNodes(TreeView fileExplorerTreeView, TreeNodeCollection collection, IList<String> splittedPath, int counter)
        {
            foreach (TreeNode node in collection)
            {
                if (node.Text.ToLower() != splittedPath[counter].ToLower())
                {
                    continue;
                }

                fileExplorerTreeView.SelectedNode = node;
                node.Expand();

                if (counter < splittedPath.Count - 1)
                {
                    counter = counter + 1;
                    CicleNodes(fileExplorerTreeView, node.Nodes, splittedPath, counter);
                }
            }
        }

        #endregion Private Methods
    }
}
