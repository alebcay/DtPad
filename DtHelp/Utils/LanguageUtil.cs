using System;
using System.Windows.Forms;
using DtHelp.Exceptions;
using DtHelp.Languages;
using DtHelp.Managers;
using DtHelp.Utils.Language;

namespace DtHelp.Utils
{
    /// <summary>
    /// Multilanguage support util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class LanguageUtil
    {
        #region Set/Get Culture Methods

        internal static void SetCurrentLanguage(Form form, String culture)
        {
            try
            {
                form.Text = GetCurrentLanguageString("Title", form.Name, culture);
                CicleControls(form.Name, form.Controls, culture);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(null, String.Format("Error during language resource reading: {0}", exception.Message), exception, culture);
            }
        }

        internal static void SetCurrentLanguage(Form form, String culture, bool isFormReloading)
        {
            try
            {
                if (!isFormReloading)
                {
                    form.Text = GetCurrentLanguageString("Title", form.Name, culture);
                }

                CicleControls(form.Name, form.Controls, culture);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(null, String.Format("Error during language resource reading: {0}", exception.Message), exception, culture);
            }
        }

        internal static String GetCurrentLanguageString(String name, String resource, String culture)
        {
            String result;

            switch (culture)
            {
                case "en":
                    result = en.ResourceManager.GetString(String.Format("{0}_{1}", resource, name));
                    break;
                case "it":
                    result = it.ResourceManager.GetString(String.Format("{0}_{1}", resource, name));
                    break;

                default:
                    result = en.ResourceManager.GetString(String.Format("{0}_{1}", resource, name));
                    break;
            }

            return result;
        }

        #endregion Set/Get Culture Methods

        #region Culture Description Methods

        internal static String GetReallyShortCulture(String cultureName)
        {
            String language;

            switch (cultureName)
            {
                case "en-GB":
                    language = "en";
                    break;
                case "en-US":
                    language = "en";
                    break;
                case "it-IT":
                    language = "it";
                    break;

                default:
                    language = "en";
                    break;
            }

            return language;
        }

        #endregion Culture Description Methods

        #region Cicle Controls Methods

        internal static void CicleControls(String formName, Control.ControlCollection controls, String culture)
        {
            foreach (Control control in controls)
            {
                try
                {
                    Type controlType = control.GetType();

                    if (controlType == typeof(TextBox) || controlType == typeof(Label) || controlType == typeof(LinkLabel) || controlType == typeof(Button)
                        || controlType == typeof(CheckBox) || controlType == typeof(RadioButton) || controlType == typeof(RichTextBox) || controlType == typeof(TabControl))
                    {
                        GeneralControl.ManageControl(control, formName, culture);
                    }
                    else if (controlType == typeof(TabPage))
                    {
                        TabPageControl.ManageControl(control, formName, culture);
                    }
                    else if (controlType == typeof(FlowLayoutPanel) || controlType == typeof(Panel) || controlType == typeof(SplitContainer)
                        || controlType == typeof(SplitterPanel) || controlType == typeof(ContextMenuStrip))
                    {
                        PanelMenuControl.ManageControl(control, formName, culture);
                    }
                    else if (controlType == typeof(GroupBox))
                    {
                        GroupBoxControl.ManageControl(control, formName, culture);
                    }
                    else if (controlType == typeof(MenuStrip))
                    {
                        MenuStripControl.ManageControl(control, formName, culture);
                    }
                    else if (controlType == typeof(ToolStrip))
                    {
                        ToolStripControl.ManageControl(control, formName, culture);
                    }
                    else if (controlType == typeof(StatusStrip))
                    {
                        StatusStripControl.ManageControl(control, formName, culture);
                    }
                    else if (controlType == typeof(ComboBox))
                    {
                        ComboBoxControl.ManageControl(control, formName, culture);
                    }
                    else if (controlType == typeof(TreeView))
                    {
                        TreeViewControl.ManageControl(control, formName, culture);
                    }
                }
                catch (Exception exception)
                {
                    throw new LanguageException(String.Format("{0} - {1}", control.Name, exception.Message));
                }
            }
        }

        internal static void CicleControls(String formName, ToolStripItemCollection items, String culture)
        {
            foreach (ToolStripItem item in items)
            {
                Type itemType = item.GetType();

                if (itemType == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItemControl.ManageControl(item, formName, culture);
                }
                else if (itemType == typeof(ToolStripTextBox) || itemType == typeof(ToolStripStatusLabel) || itemType == typeof(ToolStripLabel))
                {
                    ToolStripTextBoxStatusControl.ManageControl(item, formName, culture);
                }
                else if (itemType == typeof(ToolStripButton) || itemType == typeof(ToolStripSplitButton)
                    || itemType == typeof(ToolStripComboBox))
                {
                    ToolStripButtonComboControl.ManageControl(item, formName, culture);
                }
                else if (itemType == typeof(ToolStripDropDownButton))
                {
                    ToolStripDropDownButtonControl.ManageControl(item, formName, culture);
                }
            }
        }

        internal static void CicleControls(String formName, TreeNodeCollection items, String culture)
        {
            foreach (TreeNode item in items)
            {
                TreeNodeControl.ManageControl(item, formName, culture);
            }
        }

        #endregion Cicle Controls Methods
    }
}
