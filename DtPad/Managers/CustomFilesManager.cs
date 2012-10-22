using System;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Custom files manager (ie. HostsConfig).
    /// </summary>
    /// <author>External source, Marco Macciò</author>
    internal static class CustomFilesManager
    {
        private const String className = "CustomFilesManager";
        private const int annotationPanelWidth = 300;

        #region Hosts Panel Methods

        internal static bool IsHostsSectionPanelOpen(Form1 form)
        {
            return ProgramUtil.GetSectionsPanel(form.pagesTabControl.SelectedTabPage) != null;
        }

        internal static void ToggleHostsSectionPanel(Form1 form)
        {
            if (IsHostsSectionPanelOpen(form))
            {
                CloseHostsSectionPanel(form);
            }
            else
            {
                OpenHostsSectionPanel(form);
            }
        }

        internal static void OpenHostsSectionPanel(Form1 form)
        {
            ToolStripMenuItem hostsFileConfiguratorToolStripMenuItem = form.hostsFileConfiguratorToolStripMenuItem;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            XtraTabPage selectedTabPage = pagesTabControl.SelectedTabPage;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            if (ProgramUtil.GetSectionsPanel(selectedTabPage) != null)
            {
                selectedTabPage.Controls.Remove(ProgramUtil.GetSectionsPanel(pagesTabControl.SelectedTabPage));
            }

            //ContextMenuStrip
            ToolStripMenuItem closeToolStripMenuItem = new ToolStripMenuItem
                                                           {
                                                               Image = ToolbarResource.minus,
                                                               Name = "closeToolStripMenuItem",
                                                               ShowShortcutKeys = false,
                                                               Text = LanguageUtil.GetCurrentLanguageString("ClosePanel", className)
                                                           };
            ToolStripMenuItem helpToolStripMenuItem = new ToolStripMenuItem
                                                          {
                                                              Image = ToolbarResource.question_blue,
                                                              Name = "helpToolStripMenuItem",
                                                              ShowShortcutKeys = false,
                                                              Text = LanguageUtil.GetCurrentLanguageString("HelpPanel", className)
                                                          };
            closeToolStripMenuItem.Click += form.hostsFileConfiguratorToolStripMenuItem_Click;
            helpToolStripMenuItem.Click += form.helpHostsFileConfiguratorToolStripMenuItem_Click;

            ToolStripRenderMode rendererMode = ConfigUtil.GetIntParameter("LookAndFeel") == 0 ? ToolStripRenderMode.ManagerRenderMode : ToolStripRenderMode.System;
            ContextMenuStrip sectionsContextMenuStrip = new ContextMenuStrip
                                                            {
                                                                RenderMode = rendererMode
                                                            };
            sectionsContextMenuStrip.Items.AddRange(new ToolStripItem[] { closeToolStripMenuItem, helpToolStripMenuItem });

            //Panel
            CustomPanel sectionsPanel = new CustomPanel
                                            {
                                                Dock = DockStyle.Right,
                                                Height = selectedTabPage.Height,
                                                Name = "sectionsPanel",
                                                Width = 180
                                            };
            CheckedListBox sectionsCheckedListBox = new CheckedListBox
                                                        {
                                                            BackColor = pageTextBox.BackColor,
                                                            BorderStyle = BorderStyle.None,
                                                            CheckOnClick = true,
                                                            ContextMenuStrip = sectionsContextMenuStrip,
                                                            Dock = DockStyle.Right,
                                                            ForeColor = pageTextBox.ForeColor,
                                                            Height = selectedTabPage.Height,
                                                            HorizontalScrollbar = true,
                                                            Name = "sectionsCheckedListBox",
                                                            Tag = pageTextBox.Text.GetHashCode().ToString(),
                                                            Width = 174
                                                        };
            sectionsPanel.Controls.Add(sectionsCheckedListBox);
            selectedTabPage.Controls.Add(sectionsPanel);

            hostsFileConfiguratorToolStripMenuItem.Checked = true;

            GetSections(form, true);

            sectionsCheckedListBox.ItemCheck += CustomEvents.sectionsCheckedListBox_ItemCheck;
            sectionsCheckedListBox.Enter += CustomEvents.sectionsCheckedListBox_Refresh;
        }

        internal static void GetSections(Form1 form, bool forceRefresh)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            CustomPanel sectionsPanel = ProgramUtil.GetSectionsPanel(pagesTabControl.SelectedTabPage);

            if (sectionsPanel == null)
            {
                return; //User changes tab page
            }

            CheckedListBox sectionsCheckedListBox = (CheckedListBox)sectionsPanel.Controls["sectionsCheckedListBox"];
            String content = pageTextBox.Text;

            if (!forceRefresh && pageTextBox.Text.GetHashCode().ToString() == sectionsCheckedListBox.Tag.ToString())
            {
                return;
            }

            sectionsCheckedListBox.Items.Clear();
            int index = -1;
            int num = 0;
            int num2 = 0;

            foreach (String str in content.Split(new[] { Convert.ToChar(ConstantUtil.newLine) }))
            {
                if (str.StartsWith("#SECTION ", StringComparison.OrdinalIgnoreCase))
                {
                    if (index >= 0)
                    {
                        if ((num > 0) & (num2 > 0))
                        {
                            sectionsCheckedListBox.SetItemCheckState(index, CheckState.Indeterminate);
                        }
                        if ((num == 0) & (num2 > 0))
                        {
                            sectionsCheckedListBox.SetItemCheckState(index, CheckState.Unchecked);
                        }
                        if ((num > 0) & (num2 == 0))
                        {
                            sectionsCheckedListBox.SetItemCheckState(index, CheckState.Checked);
                        }
                    }

                    String item = str.Substring("#SECTION ".Length);
                    index = sectionsCheckedListBox.Items.Add(item, CheckState.Indeterminate);
                    num = 0;
                    num2 = 0;
                }
                else if (!String.IsNullOrEmpty(str))
                {
                    if (str.StartsWith(ConstantUtil.hostsComments))
                    {
                        num2++;
                    }
                    else
                    {
                        num++;
                    }
                }
            }

            if (index < 0)
            {
                return;
            }

            if ((num > 0) & (num2 > 0))
            {
                sectionsCheckedListBox.SetItemCheckState(index, CheckState.Indeterminate);
            }
            if ((num == 0) & (num2 > 0))
            {
                sectionsCheckedListBox.SetItemCheckState(index, CheckState.Unchecked);
            }
            if ((num > 0) & (num2 == 0))
            {
                sectionsCheckedListBox.SetItemCheckState(index, CheckState.Checked);
            }

            sectionsCheckedListBox.Tag = pageTextBox.Text.GetHashCode().ToString();
        }

        internal static void ChangeSection(Form1 form, int index, bool active)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            CustomPanel sectionsPanel = ProgramUtil.GetSectionsPanel(pagesTabControl.SelectedTabPage);
            CheckedListBox sectionsCheckedListBox = (CheckedListBox)sectionsPanel.Controls["sectionsCheckedListBox"];
            String content = pageTextBox.Text;
            String section = sectionsCheckedListBox.Items[index].ToString();
            
            bool flag = false;
            StringBuilder builder = new StringBuilder();

            foreach (String str in content.Split(new[] { Convert.ToChar(ConstantUtil.newLine) }))
            {
                if (builder.Length > 0)
                {
                    builder.Append(ConstantUtil.newLine); //builder.AppendLine();
                }
                if (String.IsNullOrEmpty(str))
                {
                    continue;
                }

                if (str.StartsWith("#SECTION ", StringComparison.OrdinalIgnoreCase))
                {
                    //flag = str.EndsWith(" " + section, StringComparison.OrdinalIgnoreCase);
                    flag = (str == ("#SECTION " + section));
                    builder.Append(str);
                }
                else if (flag)
                {
                    if (active)
                    {
                        builder.Append(str.StartsWith(ConstantUtil.hostsComments) ? str.Substring(ConstantUtil.hostsComments.Length) : str);
                    }
                    else if (!str.StartsWith(ConstantUtil.hostsComments))
                    {
                        builder.Append(ConstantUtil.hostsComments).Append(str);
                    }
                    else
                    {
                        builder.Append(str);
                    }
                }
                else
                {
                    builder.Append(str);
                }
            }

            pageTextBox.SelectAll();
            pageTextBox.SelectedText = builder.ToString();
            TextManager.RefreshUndoRedoExternal(form);
            pageTextBox.ScrollToCaret();
        }

        internal static void ShowHostsHelp(Form1 form)
        {
            WindowManager.ShowContent(form, LanguageUtil.GetCurrentLanguageString("HostsHelp", className), true);
        }

        private static void CloseHostsSectionPanel(Form1 form)
        {
            ToolStripMenuItem hostsFileConfiguratorToolStripMenuItem = form.hostsFileConfiguratorToolStripMenuItem;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomPanel sectionsPanel = ProgramUtil.GetSectionsPanel(pagesTabControl.SelectedTabPage);

            if (sectionsPanel != null)
            {
                pagesTabControl.SelectedTabPage.Controls.Remove(sectionsPanel);
            }

            hostsFileConfiguratorToolStripMenuItem.Checked = false;

            WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("HostsClose", className));
        }

        #endregion Hosts Panel Methods

        #region Annotation Panel Methods

        internal static bool IsAnnotationPanelOpen(Form1 form)
        {
            return ProgramUtil.GetAnnotationPanel(form.pagesTabControl.SelectedTabPage) != null;
        }

        internal static void ToggleAnnotationPanel(Form1 form)
        {
            if (IsAnnotationPanelOpen(form))
            {
                CloseAnnotationPanel(form);
            }
            else
            {
                OpenAnnotationPanel(form);
            }
        }

        private static void OpenAnnotationPanel(Form1 form)
        {
            ToolStripMenuItem annotationPanelToolStripMenuItem = form.annotationPanelToolStripMenuItem;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            XtraTabPage selectedTabPage = pagesTabControl.SelectedTabPage;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
            CustomPanel annotationPanelStart = ProgramUtil.GetAnnotationPanel(selectedTabPage);

            if (annotationPanelStart != null)
            {
                selectedTabPage.Controls.Remove(annotationPanelStart);
            }

            //ContextMenuStrip
            ToolStripMenuItem undoToolStripMenuItem = new ToolStripMenuItem
                                                          {
                                                              Enabled = false,
                                                              Name = "undoToolStripMenuItem",
                                                              ShowShortcutKeys = false,
                                                              Text = LanguageUtil.GetCurrentLanguageString("UndoPanel", className)
                                                          };
            ToolStripSeparator toolStripSeparator0 = new ToolStripSeparator
                                                         {
                                                             Name = "toolStripSeparator0"
                                                         };
            ToolStripMenuItem cutToolStripMenuItem = new ToolStripMenuItem
                                                         {
                                                             Image = ToolbarResource.cut,
                                                             Name = "cutToolStripMenuItem",
                                                             ShowShortcutKeys = false,
                                                             Text = LanguageUtil.GetCurrentLanguageString("CutPanel", className)
                                                         };
            ToolStripMenuItem copyToolStripMenuItem = new ToolStripMenuItem
                                                          {
                                                              Image = ToolbarResource.copy,
                                                              Name = "copyToolStripMenuItem",
                                                              ShowShortcutKeys = false,
                                                              Text = LanguageUtil.GetCurrentLanguageString("CopyPanel", className)
                                                          };
            ToolStripMenuItem pasteToolStripMenuItem = new ToolStripMenuItem
                                                           {
                                                               Image = ToolbarResource.paste,
                                                               Name = "pasteToolStripMenuItem",
                                                               ShowShortcutKeys = false,
                                                               Text = LanguageUtil.GetCurrentLanguageString("PastePanel", className)
                                                           };
            ToolStripMenuItem deleteToolStripMenuItem = new ToolStripMenuItem
                                                            {
                                                                Name = "deleteToolStripMenuItem",
                                                                ShowShortcutKeys = false,
                                                                Text = LanguageUtil.GetCurrentLanguageString("DeletePanel", className)
                                                            };
            ToolStripSeparator toolStripSeparator1 = new ToolStripSeparator
                                                         {
                                                             Name = "toolStripSeparator1"
                                                         };
            ToolStripMenuItem selectAllToolStripMenuItem = new ToolStripMenuItem
                                                               {
                                                                   Name = "selectAllToolStripMenuItem",
                                                                   ShowShortcutKeys = false,
                                                                   Text = LanguageUtil.GetCurrentLanguageString("SelectAllPanel", className)
                                                               };
            ToolStripMenuItem wordWrapToolStripMenuItem = new ToolStripMenuItem
                                                              {
                                                                  Checked = true,
                                                                  Name = "wordWrapToolStripMenuItem",
                                                                  ShowShortcutKeys = false,
                                                                  Text = LanguageUtil.GetCurrentLanguageString("WordWrapPanel", className)
                                                              };
            ToolStripSeparator toolStripSeparator2 = new ToolStripSeparator
                                                         {
                                                             Name = "toolStripSeparator2"
                                                         };
            ToolStripMenuItem closeToolStripMenuItem = new ToolStripMenuItem
                                                           {
                                                               Image = ToolbarResource.minus,
                                                               Name = "closeToolStripMenuItem",
                                                               ShowShortcutKeys = false,
                                                               Text = LanguageUtil.GetCurrentLanguageString("ClosePanel", className)
                                                           };
            ToolStripMenuItem helpToolStripMenuItem = new ToolStripMenuItem
                                                          {
                                                              Image = ToolbarResource.question_blue,
                                                              Name = "helpToolStripMenuItem",
                                                              ShowShortcutKeys = false,
                                                              Text = LanguageUtil.GetCurrentLanguageString("HelpPanel", className)
                                                          };
            undoToolStripMenuItem.Click += CustomEvents.undoToolStripMenuItem_Click;
            cutToolStripMenuItem.Click += CustomEvents.cutToolStripMenuItem_Click;
            copyToolStripMenuItem.Click += CustomEvents.copyToolStripMenuItem_Click;
            pasteToolStripMenuItem.Click += CustomEvents.pasteToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += CustomEvents.deleteToolStripMenuItem_Click;
            selectAllToolStripMenuItem.Click += CustomEvents.selectAllToolStripMenuItem_Click;
            wordWrapToolStripMenuItem.Click += form.wordWrapAnnotationToolStripMenuItem_Click;
            closeToolStripMenuItem.Click += form.annotationPanelToolStripMenuItem_Click;
            helpToolStripMenuItem.Click += form.helpAnnotationPanelToolStripMenuItem_Click;

            ToolStripRenderMode rendererMode = ConfigUtil.GetIntParameter("LookAndFeel") == 0 ? ToolStripRenderMode.ManagerRenderMode : ToolStripRenderMode.System;
            ContextMenuStrip annotationContextMenuStrip = new ContextMenuStrip
                                                              {
                                                                  RenderMode = rendererMode
                                                              };
            annotationContextMenuStrip.Items.AddRange(new ToolStripItem[] { undoToolStripMenuItem, toolStripSeparator0, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem,
                toolStripSeparator1, selectAllToolStripMenuItem, wordWrapToolStripMenuItem, toolStripSeparator2, closeToolStripMenuItem, helpToolStripMenuItem });
            annotationContextMenuStrip.Opening += CustomEvents.annotationContextMenuStrip_Opening;

            //Panel
            CustomPanel annotationPanel = new CustomPanel
                                              {
                                                  Dock = DockStyle.Right,
                                                  Height = selectedTabPage.Height,
                                                  Name = "annotationPanel",
                                                  Width = annotationPanelWidth
                                              };
            CustomRichTextBoxBase annotationTextBox = new CustomRichTextBoxBase
                                                          {
                                                              AutoWordSelection = false,
                                                              BackColor = pageTextBox.BackColor,
                                                              BorderStyle = BorderStyle.None,
                                                              ContextMenuStrip = annotationContextMenuStrip,
                                                              DetectUrls = false,
                                                              Dock = DockStyle.Right,
                                                              Font = pageTextBox.Font,
                                                              ForeColor = pageTextBox.ForeColor,
                                                              Height = selectedTabPage.Height,
                                                              Multiline = true,
                                                              Name = "annotationTextBox",
                                                              WordWrap = true,
                                                              Width = annotationPanelWidth - 6
                                                          };
            annotationTextBox.KeyDown += CustomEvents.annotationTextBox_KeyDown;
            annotationPanel.Controls.Add(annotationTextBox);
            selectedTabPage.Controls.Add(annotationPanel);

            annotationPanelToolStripMenuItem.Checked = true;
            annotationTextBox.Focus();
        }

        internal static void CheckAnnotationWordWrap(Form1 form, ToolStripMenuItem wordWrapToolStripMenuItem)
        {
            CustomPanel annotationPanel = ProgramUtil.GetAnnotationPanel(form.pagesTabControl.SelectedTabPage);

            if (annotationPanel == null)
            {
                return;
            }

            CustomRichTextBoxBase annotationTextBox = (CustomRichTextBoxBase)annotationPanel.Controls["annotationTextBox"];

            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
            annotationTextBox.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        internal static void ShowAnnotationHelp(Form1 form)
        {
            WindowManager.ShowContent(form, LanguageUtil.GetCurrentLanguageString("HelpAnnotation", className), true);
        }

        private static void CloseAnnotationPanel(Form1 form)
        {
            ToolStripMenuItem annotationPanelToolStripMenuItem = form.annotationPanelToolStripMenuItem;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomPanel annotationPanel = ProgramUtil.GetAnnotationPanel(form.pagesTabControl.SelectedTabPage);

            if (annotationPanel != null)
            {
                CustomRichTextBoxBase annotationTextBox = (CustomRichTextBoxBase)annotationPanel.Controls["annotationTextBox"];

                if (!String.IsNullOrEmpty(annotationTextBox.Text))
                {
                    if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("WarningAnnotationPanelClose", className)) == DialogResult.No)
                    {
                        return;
                    }
                }

                pagesTabControl.SelectedTabPage.Controls.Remove(annotationPanel);
            }

            ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Focus();
            annotationPanelToolStripMenuItem.Checked = false;
        }

        internal static void HideAnnotationPanel(Form1 form)
        {
            ProgramUtil.GetAnnotationPanel(form.pagesTabControl.SelectedTabPage).Width = 0;
        }

        internal static void ResumeAnnotationPanel(Form1 form)
        {
            ProgramUtil.GetAnnotationPanel(form.pagesTabControl.SelectedTabPage).Width = annotationPanelWidth;
        }

        #endregion Annotation Panel Methods
    }
}
