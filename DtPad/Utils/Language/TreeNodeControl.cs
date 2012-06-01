using System;
using System.Windows.Forms;

namespace DtPad.Utils.Language
{
    /// <summary>
    /// TreeNodeControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TreeNodeControl
    {
        #region Internal Methods

        internal static void ManageControl(TreeNode item, String formName)
        {
            String localized = LanguageUtil.GetCurrentLanguageString(item.Name, formName);

            if (!String.IsNullOrEmpty(localized))
            {
                item.Text = LanguageUtil.GetCurrentLanguageString(item.Name, formName);
            }

            if (item.ContextMenuStrip != null)
            {
                LanguageUtil.CicleControls(formName, item.ContextMenuStrip.Items);
            }

            if (item.Nodes.Count > 0)
            {
                LanguageUtil.CicleControls(formName, item.Nodes);
            }
        }

        #endregion Internal Methods
    }
}
