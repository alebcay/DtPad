using System;
using System.Threading;
using System.Windows.Forms;
using DtPadSetup.Managers;
using DtPadSetup.Utils;

namespace DtPadSetup
{
    /// <summary>
    /// DtPadSetup start class.
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Main_ThreadExceptionEventHandler;

            if (!CheckPermissions())
            {
                Application.DoEvents();
                Application.Exit();
            }
            else
            {
                Application.Run(new Form1());
            }
        }

        #region Private Methods

        /// <summary>
        /// The main exception handling point.
        /// </summary>
        private static void Main_ThreadExceptionEventHandler(object sender, ThreadExceptionEventArgs e)
        {
            WindowManager.ShowErrorProgramBox(null, e.Exception.Message, e.Exception);
        }

        private static bool CheckPermissions()
        {
            if (!SystemUtil.IsUserAdministrator())
            {
                WindowManager.ShowAlertProgramBox(null, "DtPad need to be executed (only once!) as Administrator to set permissions." + Environment.NewLine + Environment.NewLine + "Program will now close. Please, restart it as Administrator.");
                return false;
            }

            return true;
        }

        #endregion Private Methods
    }
}
