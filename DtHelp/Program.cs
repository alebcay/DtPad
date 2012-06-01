using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using DtHelp.Exceptions;
using DtHelp.Managers;
using DtHelp.Utils;

namespace DtHelp
{
    /// <summary>
    /// DtHelp start class.
    /// </summary>
    /// <author>Marco Macciò</author>
    public static class Program
    {
        /// <summary>
        /// The main entry point.
        /// </summary>
        [STAThread]
        public static void Main(String[] args)
        {
            if (args.Length > 1)
            {
                String error = LanguageUtil.GetCurrentLanguageString("InputError", "Program", LanguageUtil.GetReallyShortCulture(CultureInfo.CurrentCulture.Name));
                ProgramException exception = new ProgramException(error);

                throw exception;
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Main_ThreadExceptionEventHandler;
            Application.Run(new Form1(args));
        }

        #region Private Methods

        /// <summary>
        /// The main exception handling point.
        /// </summary>
        private static void Main_ThreadExceptionEventHandler(object sender, ThreadExceptionEventArgs e)
        {
            WindowManager.ShowErrorProgramBox(null, e.Exception.Message, e.Exception);
        }

        #endregion Private Methods
    }
}
