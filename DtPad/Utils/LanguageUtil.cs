using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Exceptions;
using DtPad.Managers;
using DtPad.Utils.Language;
using WmHelp.XmlGrid;
using ComboBox = System.Windows.Forms.ComboBox;

namespace DtPad.Utils
{
    /// <summary>
    /// Multilanguage support util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class LanguageUtil
    {
        #region Set/Get Culture Methods

        internal static void SetCurrentLanguage(Form form)
        {
            try
            {
                form.Text = GetCurrentLanguageString("Title", form.Name);
                CicleControls(form.Name, form.Controls, false);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(null, String.Format("Error during language resource reading: {0}", exception.Message), exception);
            }
        }

        internal static void SetCurrentLanguage(UserControl form)
        {
            try
            {
                CicleControls(form.Name, form.Controls, false);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(null, String.Format("Error during language resource reading: {0}", exception.Message), exception);
            }
        }

        internal static void SetCurrentLanguage(Form form, bool isFormReloading)
        {
            try
            {
                if (!isFormReloading)
                {
                    form.Text = GetCurrentLanguageString("Title", form.Name);
                }
                CicleControls(form.Name, form.Controls, isFormReloading);
            }
            catch (Exception exception)
            {
                WindowManager.ShowErrorBox(null, String.Format("Error during language resource reading: {0}", exception.Message), exception);
            }
        }

        internal static String GetCurrentLanguageString(String name, String resource)
        {
            try
            {
                ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager(GetReallyShortCulture(), Path.Combine(ConstantUtil.ApplicationExecutionPath(), "Languages"), null);
                return resourceManager.GetString(String.Format("{0}_{1}", resource, name));
            }
            catch (Exception exception)
            {
                LanguageException languageException = new LanguageException(String.Format("Error during language resource reading: {0}", exception.Message));
                throw languageException;
            }
        }
        internal static String GetCurrentLanguageString(String name, String resource, int counter)
        {
            try
            {
                ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager(GetReallyShortCulture(), Path.Combine(ConstantUtil.ApplicationExecutionPath(), "Languages"), null);
                return resourceManager.GetString(counter == 1 ? String.Format("{0}_{1}One", resource, name) : String.Format("{0}_{1}More", resource, name));
            }
            catch (Exception exception)
            {
                LanguageException languageException = new LanguageException(String.Format("Error during language resource reading: {0}", exception.Message));
                throw languageException;
            }
        }

        #endregion Set/Get Culture Methods

        #region Culture Description Methods

        internal static CultureInfo GetInfoCulture()
        {
            switch (ConfigUtil.GetStringParameter("Language"))
            {
                case "English":
                    return new CultureInfo("en-GB");
                case "Italiano":
                    return new CultureInfo("it-IT");
                case "Français":
                    return new CultureInfo("fr-FR");
                case "Español":
                    return new CultureInfo("es-ES");

                default:
                    return new CultureInfo("en-GB");
            }
        }

        internal static String GetReallyShortCulture()
        {
            switch (ConfigUtil.GetStringParameter("Language"))
            {
                case "English":
                    return "en";
                case "Italiano":
                    return "it";
                case "Français":
                    return "fr";
                case "Español":
                    return "es";

                default:
                    return "en";
            }
        }

        internal static String GetLongCultureForGoogleTranslator(String culture)
        {
            switch (culture)
            {
                case "en":
                    return "English";
                case "it":
                    return "Italiano";
                case "fr":
                    return "Français";
                case "es":
                    return "Español";
                case "de":
                    return "Deutsch";

                default:
                    return "English";
            }
        }

        internal static String GetReallyShortCultureForGoogleTranslator(String culture)
        {
            switch (culture)
            {
                case "English":
                    return "en";
                case "Italiano":
                    return "it";
                case "Français":
                    return "fr";
                case "Español":
                    return "es";
                case "Deutsch":
                    return "de";

                default:
                    return "en";
            }
        }

        internal static bool InitialCapsUp()
        {
            switch (ConfigUtil.GetStringParameter("Language"))
            {
                case "English":
                    return true;
                case "Italiano":
                    return false;
                case "Français":
                    return false;
                case "Español":
                    return false;

                default:
                    return true;
            }
        }

        #endregion Culture Description Methods

        #region DateTime Methods

        internal static String GetDateTimeFormat()
        {
            switch (ConfigUtil.GetStringParameter("Language"))
            {
                case "English":
                    return "MM/dd/yyyy hh:mm:ss tt";
                case "Italiano":
                    return "dd/MM/yyyy HH:mm:ss";
                case "Français":
                    return "dd/MM/yyyy HH:mm:ss";
                case "Español":
                    return "dd/MM/yyyy HH:mm:ss";

                default:
                    return "MM/dd/yyyy hh:mm:ss tt";
            }
        }

        internal static String GetShortDateTimeFormat()
        {
            switch (ConfigUtil.GetStringParameter("Language"))
            {
                case "English":
                    return "MM/dd/yyyy";
                case "Italiano":
                    return "dd/MM/yyyy";
                case "Français":
                    return "dd/MM/yyyy";
                case "Español":
                    return "dd/MM/yyyy";

                default:
                    return "MM/dd/yyyy";
            }
        }

        #endregion DateTime Methods

        #region Domain Extension Methods

        internal static String GetDomainExtension()
        {
            switch (ConfigUtil.GetStringParameter("Language"))
            {
                case "English":
                    return "com";
                case "Italiano":
                    return "it";
                case "Français":
                    return "fr";
                case "Español":
                    return "es";

                default:
                    return "com";
            }
        }

        #endregion Domain Extension Methods

        #region Cicle Controls Methods

        internal static void CicleControls(String formName, Control.ControlCollection controls, bool isFormReloading)
        {
            foreach (Control control in controls)
            {
                try
                {
                    Type controlType = control.GetType();

                    if (controlType == typeof(TextBox) || controlType == typeof(Label) || controlType == typeof(LinkLabel) || controlType == typeof(Button) || controlType == typeof(CheckBox)
                        || controlType == typeof(RadioButton) || controlType == typeof(RichTextBox) || (controlType == typeof(CustomXtraTabControl) && !isFormReloading) || controlType == typeof(TabControl)
                        || controlType == typeof(XtraTabControl) || controlType == typeof(XmlGridView))
                    {
                        GeneralControl.ManageControl(control, formName, isFormReloading);
                    }
                    else if (controlType == typeof(TabPage))
                    {
                        TabPageControl.ManageControl(control, formName, isFormReloading);
                    }
                    else if (controlType == typeof(XtraTabPage))
                    {
                        XtraTabPageControl.ManageControl(control, formName, isFormReloading);
                    }
                    else if (controlType == typeof(FlowLayoutPanel) || controlType == typeof(Panel) || controlType == typeof(SplitContainer)
                        || controlType == typeof(SplitterPanel) || controlType == typeof(ContextMenuStrip))
                    {
                        PanelMenuControl.ManageControl(control, formName, isFormReloading);
                    }
                    else if (controlType == typeof(GroupBox))
                    {
                        GroupBoxControl.ManageControl(control, formName, isFormReloading);
                    }
                    else if (controlType == typeof(MenuStrip))
                    {
                        MenuStripControl.ManageControl(control, formName);
                    }
                    else if (controlType == typeof(ToolStrip))
                    {
                        ToolStripControl.ManageControl(control, formName);
                    }
                    else if (controlType == typeof(StatusStrip))
                    {
                        StatusStripControl.ManageControl(control, formName);
                    }
                    else if (controlType == typeof(ComboBox) || (controlType == typeof(ComboBoxEdit)))
                    {
                        ComboBoxControl.ManageControl(control, formName);
                    }
                    else if (controlType == typeof(TreeView))
                    {
                        TreeViewControl.ManageControl(control, formName);
                    }
                    else if (controlType == typeof(ListView))
                    {
                        ListViewControl.ManageControl(control, formName);
                    }
                }
                catch (Exception exception)
                {
                    throw new LanguageException(String.Format("{0} - {1}", control.Name, exception.Message), exception);
                }
            }
        }

        internal static void CicleControls(String formName, TreeNodeCollection items)
        {
            foreach (TreeNode item in items)
            {
                TreeNodeControl.ManageControl(item, formName);
            }
        }

        internal static void CicleControls(String formName, ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                Type itemType = item.GetType();

                if (itemType == typeof(ToolStripMenuItem) || itemType == typeof(CustomToolStripMenuItem))
                {
                    ToolStripMenuItemControl.ManageControl(item, formName);
                }
                else if (itemType == typeof(ToolStripTextBox) || itemType == typeof(ToolStripStatusLabel))
                {
                    ToolStripTextBoxStatusControl.ManageControl(item, formName);
                }
                else if (itemType == typeof(ToolStripButton) || itemType == typeof(ToolStripComboBox))
                {
                    ToolStripButtonComboControl.ManageControl(item, formName);
                }
                else if (itemType == typeof(ToolStripDropDownButton))
                {
                    ToolStripDropDownButtonControl.ManageControl(item, formName);
                }
                else if (itemType == typeof(ToolStripSplitButton))
                {
                    ToolStripSplitButtonControl.ManageControl(item, formName);
                }
            }
        }

        #endregion Cicle Controls Methods
    }
}
