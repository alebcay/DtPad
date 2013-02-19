using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtControls;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Column ruler manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ColumnRulerManager
    {
        private const String className = "ColumnRulerManager";

        #region Internal Methods

        internal static void TogglePanel(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            XtraTabPage selectedTabPage = pagesTabControl.SelectedTabPage;

            if (IsPanelOpen(selectedTabPage))
            {
                ClosePanel(selectedTabPage);
            }
            else if (form.WindowMode == CustomForm.WindowModeEnum.Relax)
            {
                WindowManager.ShowAlertBox(form, LanguageUtil.GetCurrentLanguageString("NoColumnsWithRelax", className));
            }
            else
            {
                OpenPanel(form, selectedTabPage);
            }
        }

        internal static void UpdatePanelAppearance(XtraTabPage tabPage, bool customLineNumbersVisible)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(tabPage);
            CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(tabPage);
            CustomPanel columnRulerPanel = (CustomPanel)tabPage.Controls["columnRulerPanel"];

            if (columnRulerPanel == null)
            {
                return;
            }

            pageTextBox.Size = new Size(pageTextBox.Size.Width + 1, pageTextBox.Size.Height);
            pageTextBox.Size = new Size(pageTextBox.Size.Width - 1, pageTextBox.Size.Height);
            RichTextBox columnRulerTextBox = (RichTextBox)columnRulerPanel.Controls["columnRulerTextBox"];

            columnRulerTextBox.Width = pageTextBox.Width + 1;
            columnRulerTextBox.Left = customLineNumbersVisible ? customLineNumbers.Width : 0;
            //columnRulerPanel.MarginLeftHorizontalLine = tabPage.Width - columnRulerTextBox.Width - 5;
            columnRulerPanel.MarginLeftHorizontalLine = columnRulerTextBox.Left;
            columnRulerPanel.Refresh();
        }

        internal static void UpdatePanelFont(Form1 form)
        {
            if (form == null) //Before initialization
            {
                return;
            }

            XtraTabControl pagesTabControl = form.pagesTabControl;
            XtraTabPage selectedTabPage = pagesTabControl.SelectedTabPage;
            CustomPanel columnRulerPanel = (CustomPanel)selectedTabPage.Controls["columnRulerPanel"];

            if (columnRulerPanel == null)
            {
                return;
            }

            TogglePanel(form);
            TogglePanel(form);
        }

        internal static bool IsPanelOpen(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            XtraTabPage selectedTabPage = pagesTabControl.SelectedTabPage;

            return IsPanelOpen(selectedTabPage);
        }
        internal static bool IsPanelOpen(XtraTabPage tabPage)
        {
            return tabPage.Controls["columnRulerPanel"] != null;
        }

        internal static void ClosePanel(XtraTabPage tabPage)
        {
            if (tabPage.Controls["columnRulerPanel"] != null)
            {
                tabPage.Controls.Remove(tabPage.Controls["columnRulerPanel"]);
            }
        }

        internal static void SetZoom(XtraTabPage tabPage, int zoomFactor)
        {
            CustomPanel columnRulerPanel = (CustomPanel)tabPage.Controls["columnRulerPanel"];

            if (columnRulerPanel == null)
            {
                return;
            }

            RichTextBox columnRulerTextBox = (RichTextBox)columnRulerPanel.Controls["columnRulerTextBox"];
            columnRulerTextBox.ZoomFactor = (float)zoomFactor / 100;

            int newHeight = Convert.ToInt32(Convert.ToInt32(columnRulerTextBox.Font.GetHeight()* 2 + 5) * columnRulerTextBox.ZoomFactor);
            columnRulerPanel.Height = newHeight + 1;
            columnRulerTextBox.Height = newHeight;
        }

        #endregion Internal Methods

        #region Private Methods

        private static void OpenPanel(Form1 form, XtraTabPage tabPage)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(tabPage);
            CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(tabPage);

            bool wasHostsSectionOpen = false;
            if (CustomFilesManager.IsHostsSectionPanelOpen(form))
            {
                wasHostsSectionOpen = true;
                CustomFilesManager.ToggleHostsSectionPanel(form, true);
            }
            String annotationText = String.Empty;
            if (CustomFilesManager.IsAnnotationPanelOpen(form))
            {
                annotationText = CustomFilesManager.GetAnnotationPanelText(form);
                CustomFilesManager.ToggleAnnotationPanel(form, true);
            }

            int left = 0;
            if (ConfigUtil.GetBoolParameter("LineNumbersVisible"))
            {
                left = customLineNumbers.Width;
            }

            //Panel
            RichTextBox columnRulerTextBox = new RichTextBox
                                                 {
                                                     Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left,
                                                     BackColor = pageTextBox.BackColor,
                                                     BorderStyle = BorderStyle.None,
                                                     Font = pageTextBox.Font,
                                                     //ForeColor = pageTextBox.ForeColor,
                                                     ForeColor = SystemColors.AppWorkspace,
                                                     Height = Convert.ToInt32(pageTextBox.Font.GetHeight() * 2 + 5), //35
                                                     Left = left,
                                                     Multiline = true,
                                                     Name = "columnRulerTextBox",
                                                     ReadOnly = true,
                                                     ScrollBars = RichTextBoxScrollBars.None,
                                                     ShortcutsEnabled = false,
                                                     Text = ConstantUtil.columnsHeader,
                                                     Width = pageTextBox.Width + 1,
                                                     WordWrap = false
                                                 };
            CustomPanel columnRulerPanel = new CustomPanel
                                               {
                                                   Dock = DockStyle.Top,
                                                   Height = columnRulerTextBox.Height + 1,
                                                   Name = "columnRulerPanel",
                                                   Width = tabPage.Width,
                                                   HorizontalLine = true,
                                                   MarginLeftHorizontalLine = tabPage.Width - columnRulerTextBox.Width - 5
                                               };
            columnRulerPanel.Controls.Add(columnRulerTextBox);
            tabPage.Controls.Add(columnRulerPanel);

            if (wasHostsSectionOpen)
            {
                CustomFilesManager.ToggleHostsSectionPanel(form, true);
            }
            if (!String.IsNullOrEmpty(annotationText))
            {
                CustomFilesManager.ToggleAnnotationPanel(form);
                CustomFilesManager.SetAnnotationPanelText(form, annotationText);
            }

            pageTextBox.Focus();
        }

        #endregion Private Methods
    }
}
