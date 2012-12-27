using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using DtPad.Exceptions;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// DtPad start class.
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
            try
            {
                String controlTempPath = Path.Combine(ConstantUtil.ApplicationExecutionPath(), "UpdateControl");
                if (Directory.Exists(controlTempPath))
                {
                    Directory.Delete(controlTempPath, true);
                }
            }
            catch (Exception)
            {
                //String error = "Error during \"UpdateControl\" directory deletion." + Environment.NewLine + "Maybe it's in use.";
                //ProgramException exception = new ProgramException(error);
                //WindowManager.ShowErrorProgramBox(null, error, exception);
            }

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
                #if Debug
                    Application.Run(new Form1());
                    return;
                #endif

                String[] args = Environment.GetCommandLineArgs();
                SingleInstanceController controller = new SingleInstanceController();
                controller.Run(args);
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
            String user = String.Format(@"{0}\{1}", Environment.UserDomainName, Environment.UserName);
            AuthorizationRuleCollection collection = Directory.GetAccessControl(Path.Combine(ConstantUtil.ApplicationExecutionPath(), "DtPad.exe")).GetAccessRules(true, true, typeof(NTAccount));

            if (collection.Cast<FileSystemAccessRule>().Any(rule => rule.IdentityReference.Value.ToLower() == user.ToLower() && rule.AccessControlType == AccessControlType.Allow && rule.FileSystemRights == FileSystemRights.FullControl))
            {
                return true;
            }
            //foreach (FileSystemAccessRule rule in collection)
            //{
            //    if (rule.IdentityReference.Value.ToLower() == user.ToLower() && rule.AccessControlType == AccessControlType.Allow && rule.FileSystemRights == FileSystemRights.FullControl)
            //    {
            //        return true;
            //    }
            //}

            if (!SystemUtil.IsUserAdministrator())
            {
                WindowManager.ShowAlertBox(null, "DtPad need to be executed (only once!) as Administrator to set permissions." + Environment.NewLine + Environment.NewLine + "Program will now close. Please, restart it as Administrator.");
                return false;
            }

            DirectoryUtil.SetDirPermissions(ConstantUtil.ApplicationExecutionPath());
            foreach (String directory in DirectoryUtil.GetDirectories(ConstantUtil.ApplicationExecutionPath(), "*", SearchOption.AllDirectories))
            {
                DirectoryUtil.SetDirPermissions(directory);
            }

            foreach (String file in FileUtil.GetFiles(ConstantUtil.ApplicationExecutionPath(), "*.*", SearchOption.AllDirectories))
            {
                FileUtil.SetFilePermissions(file);
            }

            return true;
        }

        #endregion Private Methods
    }

    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        public SingleInstanceController()
        {
            IsSingleInstance = true;
            StartupNextInstance += This_StartupNextInstance;
        }

        private void This_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            String[] args = new String[e.CommandLine.Count];
            for (int i = 0; i < e.CommandLine.Count; i++)
            {
                args[i] = e.CommandLine[i];
            }

            Form1 form = MainForm as Form1;
            if (form == null)
            {
                String error = "Error during DtPad instance read." + Environment.NewLine + "Unable to execute the selected operation.";
                ProgramException exception = new ProgramException(error);
                WindowManager.ShowErrorProgramBox(null, error, exception);
                return;
            }

            form.OpenFiles(args);
        }

        protected override void OnCreateMainForm()
        {
            MainForm = new Form1();
            ((Form1)MainForm).OpenFiles(Environment.GetCommandLineArgs());
        }
    }
}
