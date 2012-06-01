﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using DtPadUninstaller.Managers;
using DtPadUninstaller.Utils;

namespace DtPadUninstaller
{
    /// <summary>
    /// DtPadUninstaller start class.
    /// </summary>
    /// <author>Marco Macciò</author>
    public static class Program
    {
        /// <summary>
        /// The main entry point.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            String culture = ConfigUtil.GetStringParameter("Language", "English", Application.StartupPath);
            String shortCulture = LanguageUtil.GetReallyShortCulture(culture);

            if (!CheckPermissions(shortCulture))
            {
                Application.DoEvents();
                Application.Exit();
                return;
            }

            if (Process.GetProcessesByName("DtPad").Length > 0)
            {
                String error = LanguageUtil.GetCurrentLanguageString("InstanceDtPad", "Program", shortCulture);
                WindowManager.ShowAlertProgramBox(null, error, shortCulture);
                Application.Exit();
                return;
            }
            if (Process.GetProcessesByName("DtHelp").Length > 0)
            {
                String error = LanguageUtil.GetCurrentLanguageString("InstanceDtHelp", "Program", shortCulture);
                WindowManager.ShowAlertProgramBox(null, error, shortCulture);
                Application.Exit();
                return;
            }
            if (Process.GetProcessesByName("DtPadUpdater").Length > 0)
            {
                String error = LanguageUtil.GetCurrentLanguageString("InstanceDtPadUpdater", "Program", shortCulture);
                WindowManager.ShowAlertProgramBox(null, error, shortCulture);
                Application.Exit();
                return;
            }
            if (Process.GetProcessesByName("DtPadUninstaller").Length > 1)
            {
                String error = LanguageUtil.GetCurrentLanguageString("InstanceDtPadUninstaller", "Program", shortCulture);
                WindowManager.ShowAlertProgramBox(null, error, shortCulture);
                Application.Exit();
                return;
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Main_ThreadExceptionEventHandler;
            Application.Run(new Form1(ConstantUtil.ApplicationExecutionPath()));
        }

        #region Private Methods

        /// <summary>
        /// The main exception handling point.
        /// </summary>
        private static void Main_ThreadExceptionEventHandler(object sender, ThreadExceptionEventArgs e)
        {
            WindowManager.ShowErrorProgramBox(null, e.Exception.Message, e.Exception);
        }

        private static bool CheckPermissions(String shortCulture)
        {
            if (!SystemUtil.IsUserAdministrator())
            {
                WindowManager.ShowAlertProgramBox(null, "DtPad need to be executed (only once!) as Administrator to set permissions." + Environment.NewLine + Environment.NewLine + "Program will now close. Please, restart it as Administrator.", shortCulture);
                return false;
            }

            return true;
        }

        #endregion Private Methods
    }
}
