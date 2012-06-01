using System;
using System.Windows.Forms;

namespace DtHelp.Utils.Language
{
    /// <summary>
    /// TreeNodeControl multilanguage class.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class TreeNodeControl
    {
        #region Internal Methods

        internal static void ManageControl(TreeNode item, String formName, String culture)
        {
            String localized = LanguageUtil.GetCurrentLanguageString(item.Name, formName, culture);

            if (!String.IsNullOrEmpty(localized))
            {
                item.Text = LanguageUtil.GetCurrentLanguageString(item.Name, formName, culture);
            }

            if (item.ContextMenuStrip != null)
            {
                LanguageUtil.CicleControls(formName, item.ContextMenuStrip.Items, culture);
            }

            if (item.Nodes.Count > 0)
            {
                LanguageUtil.CicleControls(formName, item.Nodes, culture);
            }
        }

        #endregion Internal Methods
    }
}
