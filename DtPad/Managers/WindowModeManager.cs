using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using DevExpress.XtraTab.Buttons;
using DtControls;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Window modes manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class WindowModeManager
    {
        private const String className = "WindowModeManager";
        private const String RelaxModeMarginName = "RelaxModeMargin";

        #region Generic Methods

        internal static void ToggleNonStandardMode(Form1 form)
        {
            switch (form.WindowMode)
            {
                case CustomForm.WindowModeEnum.Note:
                    NoteModeOff(form);
                    break;
                case CustomForm.WindowModeEnum.Fullscreen:
                    FullscreenModeOff(form);
                    break;
                case CustomForm.WindowModeEnum.Relax:
                    RelaxModeOff(form);
                    break;
            }

            form.WindowMode = CustomForm.WindowModeEnum.Normal;
        }

        #endregion Generic Methods

        #region Note Mode Methods

        internal static void ToggleNoteMode(Form1 form)
        {
            switch (form.WindowMode)
            {
                case CustomForm.WindowModeEnum.Note:
                    NoteModeOff(form);
                    form.WindowMode = CustomForm.WindowModeEnum.Normal;
                    break;
                case CustomForm.WindowModeEnum.Normal:
                    form.WindowMode = CustomForm.WindowModeEnum.Note;
                    NoteModeOn(form);
                    break;
            }
        }

        private static void NoteModeOn(Form1 form)
        {
            MenuStrip menuStrip = form.menuStrip;
            ToolStrip toolStrip = form.toolStrip;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            ToolStrip sessionToolStrip = form.sessionToolStrip;
            Panel searchReplacePanel = form.searchReplacePanel;
            StatusStrip statusStrip = form.statusStrip;
            PictureBox zoomPictureBox = form.zoomPictureBox;
            ZoomTrackBarControl zoomTrackBarControl = form.zoomTrackBarControl;

            if (ConfigUtil.GetBoolParameter("NoteModeTabs"))
            {
                ContextMenuStrip smallPageContextMenuStrip = new ContextMenuStrip();
                for (int i = 0; i < 2; i++)
                {
                    smallPageContextMenuStrip.Items.Add(((CustomToolStripMenuItem)form.pageContextMenuStrip.Items[i]).Clone());
                }
                pagesTabControl.ContextMenuStrip = smallPageContextMenuStrip;
                pagesTabControl.CustomHeaderButtons.Clear();
            }
            else
            {
                pagesTabControl.ContextMenuStrip = null;
                pagesTabControl.ShowTabHeader = DefaultBoolean.False;
            }

            menuStrip.Visible = false;
            toolStrip.Visible = false;
            verticalSplitContainer.Panel1.Padding = new Padding(0, 0, 0, 0);
            verticalSplitContainer.Panel2Collapsed = true;
            sessionToolStrip.Visible = false;
            searchReplacePanel.Visible = false;
            statusStrip.Visible = false;
            zoomPictureBox.Visible = false;
            zoomTrackBarControl.Visible = false;
            form.TopMost = true;
            form.FormBorderStyle = FormBorderStyle.SizableToolWindow;

            for (int i = 0; i < pagesTabControl.TabPages.Count; i++)
            {
                CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.TabPages[i]);
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.TabPages[i]);

                if (ColumnRulerManager.IsPanelOpen(pagesTabControl.TabPages[i]))
                {
                    ColumnRulerManager.ClosePanel(pagesTabControl.TabPages[i]);
                }

                customLineNumbers.Visible = false;
                pageTextBox.WordWrap = true;
            }

            form.WindowState = FormWindowState.Normal;
            form.Size = new Size(ConfigUtil.GetIntParameter("NoteModeSizeX"), ConfigUtil.GetIntParameter("NoteModeSizeY")); //new Size(400, 300);
            if (CustomFilesManager.IsHostsSectionPanelOpen(form))
            {
                form.Width += 180; //ProgramUtil.GetSectionsPanel(pagesTabControl.SelectedTabPage).Width;
            }
            if (CustomFilesManager.IsAnnotationPanelOpen(form))
            {
                CustomFilesManager.HideAnnotationPanel(form);
            }

            form.SetDesktopLocation(Screen.PrimaryScreen.Bounds.Width - form.Width - 50, 50);
        }

        private static void NoteModeOff(Form1 form)
        {
            MenuStrip menuStrip = form.menuStrip;
            ToolStrip toolStrip = form.toolStrip;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            ToolStrip sessionToolStrip = form.sessionToolStrip;
            Panel searchReplacePanel = form.searchReplacePanel;
            StatusStrip statusStrip = form.statusStrip;
            PictureBox zoomPictureBox = form.zoomPictureBox;
            ZoomTrackBarControl zoomTrackBarControl = form.zoomTrackBarControl;
            ToolStripMenuItem closeToolStripMenuItem3 = form.closeToolStripMenuItem3;

            if (ConfigUtil.GetBoolParameter("NoteModeTabs"))
            {
                pagesTabControl.CustomHeaderButtons.AddRange(new[] { new CustomHeaderButton(ButtonPredefines.Ellipsis) });
            }

            form.Size = new Size(ConfigUtil.GetIntParameter("WindowSizeX"), ConfigUtil.GetIntParameter("WindowSizeY"));
            menuStrip.Visible = true;
            toolStrip.Visible = !ConfigUtil.GetBoolParameter("ToolbarInvisible");
            pagesTabControl.ShowTabHeader = DefaultBoolean.True;
            pagesTabControl.ContextMenuStrip = form.pageContextMenuStrip;
            verticalSplitContainer.Panel1.Padding = new Padding(3, 0, 3, 0);
            sessionToolStrip.Visible = closeToolStripMenuItem3.Enabled;
            searchReplacePanel.Visible = !ConfigUtil.GetBoolParameter("SearchReplacePanelDisabled");
            statusStrip.Visible = !ConfigUtil.GetBoolParameter("StatusBarInvisible");
            zoomPictureBox.Visible = true;
            zoomTrackBarControl.Visible = true;
            form.TopMost = !ConfigUtil.GetBoolParameter("StayOnTopDisabled");
            form.FormBorderStyle = FormBorderStyle.Sizable;

            for (int i = 0; i < pagesTabControl.TabPages.Count; i++)
            {
                CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.TabPages[i]);
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.TabPages[i]);

                customLineNumbers.Visible = ConfigUtil.GetBoolParameter("LineNumbersVisible");
                pageTextBox.WordWrap = !ConfigUtil.GetBoolParameter("WordWrapDisabled");
            }

            if (CustomFilesManager.IsAnnotationPanelOpen(form))
            {
                CustomFilesManager.ResumeAnnotationPanel(form);
            }

            form.SetDesktopLocation(50, 50);
            form.WindowState = ConfigUtil.GetStringParameter("WindowState") == "Maximized" ? FormWindowState.Maximized : FormWindowState.Normal;
            verticalSplitContainer.Panel2Collapsed = ConfigUtil.GetBoolParameter("InternalExplorerInvisible");
        }

        #endregion Note Mode Methods

        #region Fullscreen Mode Methods
        
        internal static void ToggleFullscreenMode(Form1 form)
        {
            switch (form.WindowMode)
            {
                case CustomForm.WindowModeEnum.Fullscreen:
                    FullscreenModeOff(form);
                    form.WindowMode = CustomForm.WindowModeEnum.Normal;
                    break;
                case CustomForm.WindowModeEnum.Normal:
                    form.WindowMode = CustomForm.WindowModeEnum.Fullscreen;
                    FullscreenModeOn(form);
                    break;
            }
        }

        private static void FullscreenModeOn(Form1 form)
        {
            ToolStripMenuItem fullscreenToolStripMenuItem = form.fullscreenToolStripMenuItem;
            ToolStripMenuItem showTabAsNoteOnTopToolStripMenuItem1 = form.showTabAsNoteOnTopToolStripMenuItem1;
            ToolStripMenuItem showTabAsNoteOnTopToolStripMenuItem = form.showTabAsNoteOnTopToolStripMenuItem;
            ToolStripButton stayOnTopToolStripButton = form.stayOnTopToolStripButton;
            ToolStripMenuItem stayOnTopToolStripMenuItem = form.stayOnTopToolStripMenuItem;
            StatusStrip statusStrip = form.statusStrip;

            //if (form.WindowState != FormWindowState.Maximized)
            //{
            //    ConfigUtil.UpdateParameters(new[] { "WindowState", "WindowSizeX", "WindowSizeY" }, new[] { form.WindowState.ToString(), form.Width.ToString(), form.Height.ToString() });
            //}
            //else
            //{
            //    ConfigUtil.UpdateParameter("WindowState", form.WindowState.ToString());
            //}

            form.WindowState = FormWindowState.Normal;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopMost = true;

            form.Size = new Size(Screen.FromControl(form).Bounds.Width, Screen.FromControl(form).Bounds.Height);
            form.SetDesktopLocation(0, 0);

            fullscreenToolStripMenuItem.Text = LanguageUtil.GetCurrentLanguageString("fullscreenToolStripMenuItem", form.Name);
            fullscreenToolStripMenuItem.Visible = true;
            showTabAsNoteOnTopToolStripMenuItem1.Enabled = false;
            showTabAsNoteOnTopToolStripMenuItem.Enabled = false;
            stayOnTopToolStripButton.Enabled = false;
            stayOnTopToolStripMenuItem.Enabled = false;
            statusStrip.SizingGrip = false;
        }

        private static void FullscreenModeOff(Form1 form)
        {
            ToolStripMenuItem fullscreenToolStripMenuItem = form.fullscreenToolStripMenuItem;
            ToolStripMenuItem showTabAsNoteOnTopToolStripMenuItem1 = form.showTabAsNoteOnTopToolStripMenuItem1;
            ToolStripMenuItem showTabAsNoteOnTopToolStripMenuItem = form.showTabAsNoteOnTopToolStripMenuItem;
            ToolStripButton stayOnTopToolStripButton = form.stayOnTopToolStripButton;
            ToolStripMenuItem stayOnTopToolStripMenuItem = form.stayOnTopToolStripMenuItem;
            StatusStrip statusStrip = form.statusStrip;

            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.TopMost = !ConfigUtil.GetBoolParameter("StayOnTopDisabled");

            form.Size = new Size(ConfigUtil.GetIntParameter("WindowSizeX"), ConfigUtil.GetIntParameter("WindowSizeY"));
            form.SetDesktopLocation(50, 50);
            form.WindowState = ConfigUtil.GetStringParameter("WindowState") == "Maximized" ? FormWindowState.Maximized : FormWindowState.Normal;

            fullscreenToolStripMenuItem.Visible = false;
            showTabAsNoteOnTopToolStripMenuItem1.Enabled = true;
            showTabAsNoteOnTopToolStripMenuItem.Enabled = true;
            stayOnTopToolStripButton.Enabled = true;
            stayOnTopToolStripMenuItem.Enabled = true;
            statusStrip.SizingGrip = true;
        }

        #endregion Fullscreen Mode Methods

        #region Relax Mode Methods

        internal static void ToggleRelaxMode(Form1 form)
        {
            switch (form.WindowMode)
            {
                case CustomForm.WindowModeEnum.Relax:
                    RelaxModeOff(form);
                    form.WindowMode = CustomForm.WindowModeEnum.Normal;
                    break;
                case CustomForm.WindowModeEnum.Normal:
                    form.WindowMode = CustomForm.WindowModeEnum.Relax;
                    RelaxModeOn(form);
                    break;
            }
        }

        private static void RelaxModeOn(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStrip sessionToolStrip = form.sessionToolStrip;
            ToolStripMenuItem fullscreenToolStripMenuItem = form.fullscreenToolStripMenuItem;

            form.SuspendPainting(pagesTabControl);

            pagesTabControl.ContextMenuStrip = null;
            pagesTabControl.ShowTabHeader = DefaultBoolean.False;
            fullscreenToolStripMenuItem.Text = LanguageUtil.GetCurrentLanguageString("ExitRelaxMode", className);
            fullscreenToolStripMenuItem.Visible = true;

            WindowManager.CheckToolbar(form, true, false, false);
            WindowManager.CheckStatusBar(form, true, false, false);
            WindowManager.CheckLineNumbers(form, false, false);
            WindowManager.CheckWordWrap(form, false, false);
            WindowManager.CheckInternalExplorer(form, false, false);
            WindowManager.CheckSearchReplacePanel(form, false, false);

            sessionToolStrip.Visible = false;

            form.WindowState = FormWindowState.Normal;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopMost = true;
            form.Size = new Size(Screen.FromControl(form).Bounds.Width, Screen.FromControl(form).Bounds.Height);
            form.SetDesktopLocation(0, 0);
    
            #if Debug
                form.TopMost = false;
            #endif

            AddRelaxModeMargins(form);

            if (ColumnRulerManager.IsPanelOpen(pagesTabControl.SelectedTabPage))
            {
                ColumnRulerManager.ClosePanel(pagesTabControl.SelectedTabPage);
            }
            if (CustomFilesManager.IsHostsSectionPanelOpen(form))
            {
                CustomFilesManager.ToggleHostsSectionPanel(form);
            }
            if (CustomFilesManager.IsAnnotationPanelOpen(form))
            {
                CustomFilesManager.HideAnnotationPanel(form);
            }

            form.ResumePainting(pagesTabControl);
        }

        private static void RelaxModeOff(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStrip sessionToolStrip = form.sessionToolStrip;
            ToolStripMenuItem fullscreenToolStripMenuItem = form.fullscreenToolStripMenuItem;

            form.SuspendPainting(pagesTabControl);

            pagesTabControl.ContextMenuStrip = form.pageContextMenuStrip;
            pagesTabControl.ShowTabHeader = DefaultBoolean.True;
            fullscreenToolStripMenuItem.Visible = false;

            WindowManager.CheckToolbar(form, ConfigUtil.GetBoolParameter("ToolbarInvisible"), false, false);
            WindowManager.CheckStatusBar(form, ConfigUtil.GetBoolParameter("StatusBarInvisible"), false, false);
            WindowManager.CheckLineNumbers(form, ConfigUtil.GetBoolParameter("LineNumbersVisible"), false);
            WindowManager.CheckWordWrap(form, ConfigUtil.GetBoolParameter("WordWrapDisabled"), false);
            WindowManager.CheckInternalExplorer(form, !ConfigUtil.GetBoolParameter("InternalExplorerInvisible"), false);
            WindowManager.CheckSearchReplacePanel(form, !ConfigUtil.GetBoolParameter("SearchReplacePanelDisabled"), false);

            sessionToolStrip.Visible = SessionManager.IsASessionOpened(form);

            form.WindowState = ConfigUtil.GetStringParameter("WindowState") == "Maximized" ? FormWindowState.Maximized : FormWindowState.Normal;
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.TopMost = !ConfigUtil.GetBoolParameter("StayOnTopDisabled");
            form.Size = new Size(ConfigUtil.GetIntParameter("WindowSizeX"), ConfigUtil.GetIntParameter("WindowSizeY"));
            form.SetDesktopLocation(50, 50);

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                String marginLeft = String.Format("{0}Left_{1}", RelaxModeMarginName, tabPage.Name);
                String marginRight = String.Format("{0}Right_{1}", RelaxModeMarginName, tabPage.Name);

                if (!tabPage.Controls.ContainsKey(marginLeft) && !tabPage.Controls.ContainsKey(marginRight))
                {
                    continue;
                }

                tabPage.Controls.RemoveByKey(marginLeft);
                tabPage.Controls.RemoveByKey(String.Format("{0}_Very", marginLeft));

                tabPage.Controls.RemoveByKey(marginRight);
                tabPage.Controls.RemoveByKey(String.Format("{0}_Very", marginRight));
            }

            form.ResumePainting(pagesTabControl);
        }

        internal static void AddRelaxModeMargins(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;

            if (form.WindowMode != CustomForm.WindowModeEnum.Relax)
            {
                return;
            }

            foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
            {
                String marginLeft = String.Format("{0}Left_{1}", RelaxModeMarginName, tabPage.Name);
                String marginRight = String.Format("{0}Right_{1}", RelaxModeMarginName, tabPage.Name);

                if (tabPage.Controls.ContainsKey(marginLeft) || tabPage.Controls.ContainsKey(marginRight))
                {
                    continue;
                }

                Panel panelVeryLeft = new Panel
                                          {
                                              Dock = DockStyle.Left,
                                              Name = String.Format("{0}_Very", marginLeft),
                                              Width = ((Screen.FromControl(form).Bounds.Width - 800) / 2) - WindowResource.relax_margin_left.Width
                                          };
                Panel panelLeft = new Panel
                                      {
                                          Dock = DockStyle.Left,
                                          Name = marginLeft,
                                          Width = WindowResource.relax_margin_left.Width,
                                          BackgroundImage = WindowResource.relax_margin_left,
                                          BackgroundImageLayout = ImageLayout.Stretch
                                      };

                Panel panelVeryRight = new Panel
                                           {
                                               Dock = DockStyle.Right,
                                               Name = String.Format("{0}_Very", marginRight),
                                               Width = ((Screen.FromControl(form).Bounds.Width - 800) / 2) - WindowResource.relax_margin_right.Width
                                           };
                Panel panelRight = new Panel
                                       {
                                           Dock = DockStyle.Right,
                                           Name = marginRight,
                                           Width = WindowResource.relax_margin_right.Width,
                                           BackgroundImage = WindowResource.relax_margin_right,
                                           BackgroundImageLayout = ImageLayout.Stretch
                                       };

                tabPage.Controls.Add(panelLeft);
                tabPage.Controls.Add(panelVeryLeft);

                tabPage.Controls.Add(panelRight);
                tabPage.Controls.Add(panelVeryRight);
            }
        }

        #endregion Relax Mode Methods
    }
}
