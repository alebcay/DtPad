using System;
using System.Windows.Forms;

namespace DtPadSetup.Utils.Language
{
    /// <summary>
    /// TreeViewControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TreeViewControl
    {
        #region Internal Methods

        internal static void ManageControl(Control control, String formName, String culture)
        {
            TreeView controlTree = (TreeView)control;

            if (controlTree.Nodes.Count > 0)
            {
                LanguageUtil.CicleControls(formName, controlTree.Nodes, culture);
            }
        }

        #endregion Internal Methods
    }
}
