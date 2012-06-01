using System;
using System.Diagnostics;
using System.Windows.Forms;
using DtPadUpdater.Utils;

namespace DtPadUpdater.Managers
{
    /// <summary>
    /// Other functions manager (ie. start external processes).
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class OtherManager
    {
        #region Internal Methods

        internal static void StartProcess(Form form, String process, String culture)
        {
            try
            {
                Process.Start(process);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception, culture);
            }
        }

        internal static void StartProcessBrowser(Form form, String process, String executablePath, String culture)
        {
            try
            {
                if (ConfigUtil.GetBoolParameter("UseDefaultBrowser", "true", executablePath))
                {
                    Process.Start(process);
                }
                else
                {
                    ProcessStartInfo browser = new ProcessStartInfo(ConfigUtil.GetStringParameter("CustomBrowserCommand", String.Empty, executablePath), process)
                                                   {UseShellExecute = true};
                    Process.Start(browser);
                }
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(form, exception.Message, exception, culture);
            }
        }

        #endregion Internal Methods
    }
}
