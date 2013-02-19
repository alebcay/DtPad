using System;
using System.Collections.Generic;
using DevExpress.XtraTab;
using DtControls;
using DtPad.Customs;
using DtPad.Managers;

namespace DtPad.Utils
{
    /// <summary>
    /// Program util (with main form tab's sections and labels).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ProgramUtil
    {
        #region Internal Instance Fields

        internal static CustomRichTextBox GetPageTextBox(XtraTabPage tabPage)
        {
            return (CustomRichTextBox)tabPage.Controls["pageTextBox"];
        }

        internal static CustomPanel GetSectionsPanel(XtraTabPage tabPage)
        {
            return (CustomPanel)tabPage.Controls["sectionsPanel"];
        }

        internal static CustomPanel GetAnnotationPanel(XtraTabPage tabPage)
        {
            return (CustomPanel)tabPage.Controls["annotationPanel"];
        }

        internal static CustomLineNumbers GetCustomLineNumbers(XtraTabPage tabPage)
        {
            return (CustomLineNumbers)tabPage.Controls["customLineNumbers"];
        }

        //internal static CustomLineNumbers GetCustomLineNumbers(CustomRichTextBox pageTextBox)
        //{
        //    return (CustomLineNumbers)pageTextBox.Parent.Controls["customLineNumbers"];
        //}

        internal static String GetFilenameTabPage(XtraTabPage tabPage)
        {
            return tabPage.Controls["filenameTabPage"].Text;
        }

        internal static void SetFilenameTabPage(XtraTabPage tabPage, String value)
        {
            tabPage.Controls["filenameTabPage"].Text = value;
        }

        #endregion Internal Instance Fields

        #region Internal Methods

        internal static void DtPadStart(Form1 form, String[] commandLine)
        {
            List<String> args = new List<String>();
            bool noteModeOn = false;

            if (commandLine.Length == 2 && commandLine[1] == ConstantUtil.cmdLineJLNew)
            {
                OpenNewTab(form);
            }
            else if (commandLine.Length == 2 && commandLine[1] == ConstantUtil.cmdLineJLNewAndPaste)
            {
                OpenNewTabAndPaste(form);
            }
            else if (commandLine.Length == 2 && commandLine[1] == ConstantUtil.cmdLineJLOpenFile)
            {
                OpenFile(form);
            }
            else if (commandLine.Length == 2 && commandLine[1] == ConstantUtil.cmdLineJLOpenSession)
            {
                OpenSession(form);
            }
            else if (commandLine.Length == 2 && commandLine[1] == ConstantUtil.cmdLineJLSearchInFiles)
            {
                SearchInFiles(form);
            }
            else if (commandLine.Length == 2 && commandLine[1] == ConstantUtil.cmdLineJLCheckNewVersion)
            {
                CheckNewVersion(form);
            }
            else
            {
                for (int i = 1; i < commandLine.Length; i++)
                {
                    if (commandLine[i] == ConstantUtil.cmdLineNoteModeOn)
                    {
                        noteModeOn = true;
                        continue;
                    }
                    args.Add(commandLine[i]);
                }

                if (args.Count > 0)
                {
                    form.WindowState = form.PreviousWindowState;
                    form.TabIdentity = FileManager.OpenFile(form, form.TabIdentity, args.ToArray());
                }
            }
            if (!form.Visible)
            {
                TrayManager.RestoreFormFromTray(form, form.PreviousWindowState);
            }

            if (noteModeOn && form.WindowMode == CustomForm.WindowModeEnum.Normal)
            {
                WindowModeManager.ToggleNoteMode(form);
            }
        }

        internal static void OpenNewTab(Form1 form)
        {
            TrayManager.RestoreFormFromTray(form, form.PreviousWindowState);

            if (TabManager.IsCurrentTabInUse(form))
            {
                form.TabIdentity = TabManager.AddNewPage(form, form.TabIdentity);
            }   
        }

        internal static void OpenNewTabAndPaste(Form1 form)
        {
            TrayManager.RestoreFormFromTray(form, form.PreviousWindowState);

            if (TabManager.IsCurrentTabInUse(form))
            {
                form.TabIdentity = TabManager.AddNewPage(form, form.TabIdentity);
            }

            TextManager.Paste(form, true);
        }

        internal static void OpenFile(Form1 form)
        {
            TrayManager.RestoreFormFromTray(form, form.PreviousWindowState);
            form.TabIdentity = FileManager.OpenFile(form, form.TabIdentity);
        }

        #endregion Internal Methods

        #region Private Methods

        private static void OpenSession(Form1 form)
        {
            SessionManager.OpenSession(form);
        }

        private static void SearchInFiles(Form1 form)
        {
            WindowManager.ShowSearchInFiles(form);
        }

        private static void CheckNewVersion(Form1 form)
        {
            WindowManager.ShowVersionCheck(form);
        }

        #endregion Private Methods
    }
}
