using System.Windows.Forms;
using DevExpress.XtraTab;
using DtControls;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Window tray manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TrayManager
    {
        #region Internal Methods

        internal static void RestoreFormFromTray(Form1 form, FormWindowState previousWindowState)
        {
            NotifyIcon notifyIcon = form.notifyIcon;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.SelectedTabPage);

            if (form.Visible)
            {
                return;
            }
            
            form.Visible = true;
            notifyIcon.Visible = false;
            form.WindowState = previousWindowState;

            customLineNumbers.Refresh();

            form.BringToFront();
        }

        internal static void RestoreFormIfIsInTray(Form1 form)
        {
            NotifyIcon notifyIcon = form.notifyIcon;

            if (notifyIcon != null && notifyIcon.Visible)
            {
                RestoreFormFromTray(form, form.PreviousWindowState);
            }
        }

        #endregion Internal Methods
    }
}
