using System;
using System.Windows.Forms;

namespace DtHelp.Managers
{
    /// <summary>
    /// File open manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class FileManager
    {
        #region Internal Methods

        internal static void OpenGuide(Form1 form)
        {
            OpenFileDialog openFileDialog = form.openFileDialog;

            try
            {
                WindowManager.EnableInterface(form);
                
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    WindowManager.DisableInterface(form);
                    return;
                }

                String fileName = openFileDialog.FileName;
                GuideManager.ReadHelpGuide(form, fileName);
            }
            catch (Exception exception)
            {
                WindowManager.DisableInterface(form);
                WindowManager.ShowErrorBox(form, exception.Message, exception, OptionManager.GetLanguage(form));
            }
        }

        #endregion Internal Methods
    }
}
