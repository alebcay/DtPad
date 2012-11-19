using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraTab;
using DtPad.UserControls;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Clipboard history manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ClipboardManager
    {
        private const String className = "ClipboardManager";
        private const int maxCharCount = 50;
        
        #region Internal Methods

        internal static void GetClipboardList(Form1 form, bool forceLoad)
        {
            ListBox clipboardListBox = form.clipboardPanel.clipboardListBox;
            XtraTabControl verticalTabControl = form.verticalTabControl;
            XtraTabPage clipboardTabPage = form.clipboardTabPage;

            if ((verticalTabControl.SelectedTabPage != clipboardTabPage) || (!forceLoad && clipboardListBox.Items.Count > 0))
            {
                return;
            }

            ClearClipboardList(form);

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.clFile));

                XmlNodeList clipList = xmldoc.GetElementsByTagName("clip");

                foreach (XmlNode clip in clipList)
                {
                    clipboardListBox.Items.Add(clip.ChildNodes[1].InnerText); //short
                }
            }
            catch (XmlException exception)
            {
                WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorReading", className), exception);
                FileListManager.SaveFileList(ConstantUtil.clFile, ConstantUtil.defaultClipboardFileContent);
            }
        }

        internal static void ClearClipboardList(Form1 form)
        {
            ListBox clipboardListBox = form.clipboardPanel.clipboardListBox;

            clipboardListBox.Items.Clear();
        }

        internal static void ClearClipboardFile(Form1 form)
        {
            ClearClipboardList(form);
            FileListManager.SaveFileList(ConstantUtil.clFile, ConstantUtil.defaultClipboardFileContent);
        }

        internal static void AddContent(Form1 form)
        {
            ListBox clipboardListBox = form.clipboardPanel.clipboardListBox;
            String content;

            try
            {
                if (!Clipboard.ContainsText())
                {
                    return;
                }

                content = Clipboard.GetText();
            }
            catch (ExternalException exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
                return;
            }

            String shortContent = content.Replace(ConstantUtil.newLine, " ");
            shortContent = shortContent.Replace(Environment.NewLine, " ");
            shortContent = StringUtil.CheckStringLengthEnd(shortContent, maxCharCount);
            //shortContent.Replace("<", "&lt;");
            //shortContent.Replace(">", "&gt;");

            if (IsContentAlreadyClipboarded(form, content))
            {
                return;
            }

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.clFile));

                XmlElement newClip = xmldoc.CreateElement("clip");

                XmlElement numberNode = xmldoc.CreateElement("number");
                numberNode.InnerText = clipboardListBox.Items.Count.ToString();
                newClip.AppendChild(numberNode);

                XmlElement shortNode = xmldoc.CreateElement("short");
                XmlCDataSection shortNodeCData = xmldoc.CreateCDataSection(shortContent);
                shortNode.InnerText = String.Empty;
                shortNode.AppendChild(shortNodeCData);

                XmlElement contentNode = xmldoc.CreateElement("content");
                XmlText contentNodeCData = xmldoc.CreateTextNode(content); //XmlCDataSection contentNodeCData = xmldoc.CreateCDataSection(content);
                contentNode.InnerText = String.Empty;
                contentNode.AppendChild(contentNodeCData);

                newClip.AppendChild(shortNode);
                newClip.AppendChild(contentNode);

                if (xmldoc.DocumentElement != null)
                {
                    xmldoc.DocumentElement.InsertAfter(newClip, xmldoc.DocumentElement.LastChild);
                    xmldoc.Save(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.clFile));

                    clipboardListBox.Items.Add(shortContent);
                }
                else
                {
                    throw new XmlException();
                }
            }
            catch (XmlException exception)
            {
                WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorCreation", className), exception);
                FileListManager.SaveFileList(ConstantUtil.clFile, ConstantUtil.defaultClipboardFileContent);
            }
        }

        internal static void CopyContent(ClipboardPanel form)
        {
            ListBox clipboardListBox = form.clipboardListBox;

            try
            {
                //Clipboard.SetText(GetContent(clipboardListBox.SelectedIndex));
                Clipboard.SetDataObject(GetContent(clipboardListBox.SelectedIndex), true, 4, 250);
            }
            catch (ExternalException exception)
            {
                WindowManager.ShowErrorBox(form.ParentForm, exception.Message, exception);
            }
        }

        internal static void ShowSelectedContent(Form1 form)
        {
            ListBox clipboardListBox = form.clipboardPanel.clipboardListBox;
            
            WindowManager.ShowContent(form, GetContent(clipboardListBox.SelectedIndex));
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool IsContentAlreadyClipboarded(Form form, String newContent)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.clFile));

                XmlNodeList contentList = xmldoc.GetElementsByTagName("content");

                //foreach (XmlNode content in contentList)
                //{
                //    if (content.InnerText == newContent)
                //    {
                //        return true;
                //    }
                //}
                if (contentList.Cast<XmlNode>().Any(content => content.InnerText == newContent))
                {
                    return true;
                }
            }
            catch (XmlException exception)
            {
                WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString("ErrorReading", className), exception);
                FileListManager.SaveFileList(ConstantUtil.clFile, ConstantUtil.defaultClipboardFileContent);
            }

            return false;
        }

        private static String GetContent(int number)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.clFile));

                XmlNodeList clipList = xmldoc.GetElementsByTagName("clip");

                foreach (XmlNode clip in clipList)
                {
                    if (clip.ChildNodes[0].InnerText == number.ToString())
                    {
                        return clip.ChildNodes[2].InnerText;
                    }
                }
            }
            catch (XmlException exception)
            {
                WindowManager.ShowErrorBox(null, LanguageUtil.GetCurrentLanguageString("ErrorReading", className), exception);
                FileListManager.SaveFileList(ConstantUtil.clFile, ConstantUtil.defaultClipboardFileContent);
            }

            return String.Empty;
        }

        #endregion Private Methods
    }
}
