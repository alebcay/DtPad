using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DtHelp.Utils;

namespace DtHelp.Managers
{
    /// <summary>
    /// Guide reading operations manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class GuideManager
    {
        private const String className = "GuideManager";

        #region Internal Methods

        internal static void ReadHelpGuide(Form1 form, String pathAndFileName)
        {            
            TreeView indexTreeView = form.indexTreeView;

            String culture = OptionManager.GetLanguage(form);
            CloseGuide(form, true); //indexTreeView.Nodes.Clear();

            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;

            String guidePath = Path.GetDirectoryName(pathAndFileName);
            
            try
            {
                form.GuidePath = guidePath;
                
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(pathAndFileName);

                form.Text = String.Format("{0} - {1}", LanguageUtil.GetCurrentLanguageString("Title", "Form1", culture), xmldoc.GetElementsByTagName("guide").Item(0).Attributes["format"].Value);

                XmlNodeList indexList = xmldoc.GetElementsByTagName("index");
                XmlNode indexNode = indexList[0];
                TreeNode newIndex = new TreeNode(indexNode.Attributes["title"].Value);
                newIndex.ImageIndex = 0;
                newIndex.SelectedImageIndex = 0;
                newIndex.Name = indexNode.Attributes["file"].Value;
                indexTreeView.Nodes.Add(newIndex);

                String homeFile = Path.Combine(guidePath, indexNode.Attributes["file"].Value);
                helpWebBrowser.Url = new Uri(homeFile);
                form.Home = homeFile;
                indexTreeView.SelectedNode = newIndex;

                XmlNodeList chapterList = xmldoc.GetElementsByTagName("chapter");
                foreach (XmlNode nodeChapter in chapterList)
                {
                    TreeNode newChapter = new TreeNode(nodeChapter.Attributes["title"].Value);
                    newChapter.ImageIndex = 1;
                    newChapter.SelectedImageIndex = 1;
                    newChapter.Name = nodeChapter.Attributes["file"].Value;
                    indexTreeView.Nodes.Add(newChapter);
                    
                    XmlNodeList pageList = nodeChapter.ChildNodes;
                    foreach (XmlNode nodePage in pageList)
                    {
                        TreeNode newPage = new TreeNode(nodePage.Attributes["title"].Value);
                        newPage.ImageIndex = 2;
                        newPage.SelectedImageIndex = 2;
                        newPage.Name = nodePage.Attributes["file"].Value;
                        newChapter.Nodes.Add(newPage);
                    }
                }
            }
            catch (XmlException exception)
            {
                form.GuidePath = String.Empty;
                form.Home = String.Empty;
                WindowManager.DisableInterface(form);
                WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorReading", className, culture), exception, OptionManager.GetLanguage(form));
            }
        }

        internal static void ReadSelectedNodePage(Form1 form, String guidePath)
        {
            TreeView indexTreeView = form.indexTreeView;
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;

            TreeNode selectedNode = indexTreeView.SelectedNode;
            String uriPath = Path.Combine(guidePath, selectedNode.Name);
            helpWebBrowser.Url = new Uri(uriPath);
        }

        internal static void SelectNodePageFromNavigatedUrl(Form1 form, Uri url, String guidePath)
        {
            TreeView indexTreeView = form.indexTreeView;

            String culture = OptionManager.GetLanguage(form);
            
            try
            {
                String nodeNameUrl = url.ToString().Remove(0, guidePath.Length + 9).Replace("/", "\\");
                if (indexTreeView.Nodes.ContainsKey(nodeNameUrl))
                {
                    indexTreeView.SelectedNode = indexTreeView.Nodes[indexTreeView.Nodes.IndexOfKey(nodeNameUrl)];
                    return;
                }

                foreach (TreeNode node in indexTreeView.Nodes)
                {
                    if (node.Nodes.Count == 0 || !node.Nodes.ContainsKey(nodeNameUrl))
                    {
                        continue;
                    }

                    indexTreeView.SelectedNode = node.Nodes[node.Nodes.IndexOfKey(nodeNameUrl)];
                    return;
                }
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorGetting", className, culture), exception, OptionManager.GetLanguage(form));
            }
        }

        internal static void Expand(Form1 form, bool all)
        {
            TreeView indexTreeView = form.indexTreeView;

            if (all)
            {
                indexTreeView.ExpandAll();
            }
            else
            {
                indexTreeView.SelectedNode.Expand();
            }            
        }

        internal static void Collapse(Form1 form, bool all)
        {
            TreeView indexTreeView = form.indexTreeView;

            if (all)
            {
                indexTreeView.CollapseAll();
            }
            else
            {
                indexTreeView.SelectedNode.Collapse();
            }
        }

        internal static void CloseGuide(Form1 form, bool newOpening)
        {
            TreeView indexTreeView = form.indexTreeView;
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            ToolStripTextBox urlToolStripTextBox = form.urlToolStripTextBox;
            
            if (helpWebBrowser.Document == null)
            {
                return;
            }

            form.Text = LanguageUtil.GetCurrentLanguageString("Title", form.Name, OptionManager.GetLanguage(form));
            indexTreeView.Nodes.Clear();
            urlToolStripTextBox.Text = String.Empty;
            ReplaceHelpWebBrowser(form);

            if (!newOpening)
            {
                WindowManager.DisableInterface(form);
            }
        }

        internal static void ReplaceHelpWebBrowser(Form1 form)
        {
            WebBrowser helpWebBrowser = (WebBrowser)form.splitContainer1.Panel2.Controls["helpWebBrowser"]; //form.helpWebBrowser;
            ToolStripButton goBackToolStripButton = form.goBackToolStripButton;
            ToolStripMenuItem goBackToolStripMenuItem = form.goBackToolStripMenuItem;
            ToolStripMenuItem goBackToolStripMenuItem1 = form.goBackToolStripMenuItem1;
            ToolStripButton goForwardToolStripButton = form.goForwardToolStripButton;
            ToolStripMenuItem goForwardToolStripMenuItem = form.goForwardToolStripMenuItem;
            ToolStripMenuItem goForwardToolStripMenuItem1 = form.goForwardToolStripMenuItem1;
            
            WebBrowser newBrowser = new WebBrowser
                                        {
                                            AllowWebBrowserDrop = false,
                                            ContextMenuStrip = form.browserContextMenuStrip,
                                            Dock = DockStyle.Fill,
                                            IsWebBrowserContextMenuEnabled = false,
                                            Location = new Point(0, 23),
                                            MinimumSize = new Size(20, 20),
                                            Name = "helpWebBrowser",
                                            ScriptErrorsSuppressed = true,
                                            Size = new Size(554, 316),
                                            TabIndex = 0
                                        };
            newBrowser.Navigated += form.helpWebBrowser_Navigated;
            newBrowser.ProgressChanged += form.helpWebBrowser_ProgressChanged;
            newBrowser.DocumentCompleted += form.helpWebBrowser_DocumentCompleted;
            newBrowser.StatusTextChanged += form.helpWebBrowser_StatusTextChanged;

            form.splitContainer1.Panel2.Controls.Remove(helpWebBrowser);
            helpWebBrowser.Dispose();
            form.splitContainer1.Panel2.Controls.Add(newBrowser);

            goBackToolStripButton.Enabled = false;
            goBackToolStripMenuItem.Enabled = false;
            goBackToolStripMenuItem1.Enabled = false;
            goForwardToolStripButton.Enabled = false;
            goForwardToolStripMenuItem.Enabled = false;
            goForwardToolStripMenuItem1.Enabled = false;
        }

        #endregion Internal Methods
    }
}
