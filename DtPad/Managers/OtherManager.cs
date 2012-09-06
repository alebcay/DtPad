using System;
using System.Diagnostics;
using System.Windows.Forms;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Other functions manager (ie. start external processes).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class OtherManager
    {
        #region Process Methods

        internal static void StartProcess(Form form, String process)
        {
            try
            {
                Process.Start(process);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
        }

        internal static void StartProcessInfo(Form form, ProcessStartInfo processStart)
        {
            try
            {
                Process.Start(processStart);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
        }

        internal static void StartProcessInfoWithInit(Form form, String process, String workingFolder, ProcessWindowStyle run)
        {
            try
            {
                ProcessStartInfo processStart = new ProcessStartInfo
                                                    {
                                                        FileName = process,
                                                        WorkingDirectory = workingFolder,
                                                        WindowStyle = run
                                                    };

                Process.Start(processStart);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
        }

        //internal static bool StartProcessInfoWaitExit(Form form, ProcessStartInfo processStart)
        //{
        //    try
        //    {
        //        Process process = new Process();
        //        process.StartInfo = processStart;
        //        process.Start();
        //        process.WaitForExit();
                
        //        return true;
        //    }
        //    catch (Exception exception)
        //    {
        //        WindowManager.ShowErrorBox(form, exception.Message, exception);
        //        return false;
        //    }
        //}

        internal static void StartProcessBrowser(Form form, String process)
        {
            try
            {
                if (ConfigUtil.GetBoolParameter("UseDefaultBrowser"))
                {
                    Process.Start(process);
                }
                else
                {
                    ProcessStartInfo browser = new ProcessStartInfo(ConfigUtil.GetStringParameter("CustomBrowserCommand"), process) { UseShellExecute = true };
                    Process.Start(browser);
                }
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception);
            }
        }

        #endregion Process Methods

        #region Internal Methods

        internal static void FocusOnEditor(Form1 form)
        {
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            
            pageTextBox.Focus();
        }

        #endregion Internal Methods
    }
}
