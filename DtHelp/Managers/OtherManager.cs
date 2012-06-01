using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DtHelp.Managers
{
    /// <summary>
    /// Other functions manager (ie.start external processes).
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

        #endregion Internal Methods
    }
}
