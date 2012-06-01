using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DtPad.Objects;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Help manager (linked to DtHelp).
    /// </summary>
    /// <remarks>Rem lines because of in-line help disabled.</remarks>
    /// <author>Marco Macciò</author>
    internal static class HelpManager
    {
        #region Internal Methods

        internal static void ManageHelpPanel(Form form, CancelEventArgs e)
        {
            e.Cancel = true;

            if (!IsPanelVisible(form))
            {
                IEnumerable<ControlObject> modifiedControls = RemoveControlsBottomAncorage(form);
                int initialFormHeight = form.Height;

                if (!form.MaximumSize.IsEmpty)
                {
                    form.MaximumSize = new Size(form.MaximumSize.Width, form.MaximumSize.Height + ConstantUtil.standardHelpPanelHeight);
                }
                if (!form.MinimumSize.IsEmpty)
                {
                    form.MinimumSize = new Size(form.MinimumSize.Width, form.MinimumSize.Height + ConstantUtil.standardHelpPanelHeight);
                }

                if (initialFormHeight >= form.Height)
                {
                    form.Height += ConstantUtil.standardHelpPanelHeight;
                }

                PictureBox helpPictureBox = new PictureBox
                                                {
                                                    Image = ToolbarResource.question_blue,
                                                    Location = new Point(13, 7),
                                                    Name = "helpPictureBox",
                                                    Size = new Size(16, 16),
                                                    TabStop = false
                                                };
                Label helpLabel = new Label
                                      {
                                          Text = LanguageUtil.GetCurrentLanguageString("helpLabel", form.Name),
                                          Size = new Size(form.Width - 42, 13),
                                          Location = new Point(29, 8)
                                      };
                Panel helpPanel = new Panel
                                      {
                                          BackColor = SystemColors.Info,
                                          Dock = DockStyle.Bottom,
                                          Location = new Point(0, ConstantUtil.standardHelpPanelHeight),
                                          Name = "helpPanel",
                                          Size = new Size(form.Width, ConstantUtil.standardHelpPanelHeight)
                                      };
                helpPanel.Controls.Add(helpPictureBox);
                helpPanel.Controls.Add(helpLabel);

                form.Controls.Add(helpPanel);
                RecreateControlsBottomAncorage(modifiedControls);
            }
            else
            {
                IEnumerable<ControlObject> modifiedControls = RemoveControlsBottomAncorage(form);
                //form.Height -= ConstantUtil.standardHelpPanelHeight;

                if (!form.MinimumSize.IsEmpty)
                {
                    form.MinimumSize = new Size(form.MinimumSize.Width, form.MinimumSize.Height - ConstantUtil.standardHelpPanelHeight);
                }
                if (!form.MaximumSize.IsEmpty)
                {
                    form.MaximumSize = new Size(form.MaximumSize.Width, form.MaximumSize.Height - ConstantUtil.standardHelpPanelHeight);
                }

                form.Height -= ConstantUtil.standardHelpPanelHeight;

                form.Controls.RemoveByKey("helpPanel");
                RecreateControlsBottomAncorage(modifiedControls);
            }
        }

        internal static void OpenDtHelp()
        {
            String language = LanguageUtil.GetReallyShortCulture();

            String guideFileName = String.Format("{0}{1}{2}", ConstantUtil.defaultDtPadGuideName, language, ConstantUtil.defaultDtPadGuideExtension);
            guideFileName = String.Format("\"{0}\"", Path.Combine(ConstantUtil.ApplicationExecutionPath(), guideFileName));

            ProcessStartInfo processStartInfo = new ProcessStartInfo(Path.Combine(ConstantUtil.ApplicationExecutionPath(), ConstantUtil.dtHelpExecutable), guideFileName)
                                                    {
                                                        WorkingDirectory = ConstantUtil.ApplicationExecutionPath(),
                                                        UseShellExecute = false
                                                    };
            OtherManager.StartProcessInfo(null, processStartInfo);
        }

        #endregion Internal Methods

        #region Event Methods

        //private static void helpPictureBox_Click(object sender, EventArgs e)
        //{
        //    OpenDtHelp();
        //}

        //private static void helpLabel_Click(object sender, EventArgs e)
        //{
        //    OpenDtHelp();
        //}

        //private static void helpLabel_MouseHover(object sender, EventArgs e)
        //{
        //    Label helpLabel = (Label)sender;
        //    helpLabel.Font = new Font(helpLabel.Font, FontStyle.Underline);
        //}

        //private static void helpLabel_MouseLeave(object sender, EventArgs e)
        //{
        //    Label helpLabel = (Label)sender;
        //    helpLabel.Font = new Font(helpLabel.Font, FontStyle.Regular);
        //}

        #endregion Event Methods

        #region Private Methods

        private static bool IsPanelVisible(Control form)
        {
            return form.Controls.ContainsKey("helpPanel");
        }

        private static IEnumerable<ControlObject> RemoveControlsBottomAncorage(Control form)
        {
            Control.ControlCollection controls = form.Controls;
            List<ControlObject> modifiedControls = new List<ControlObject>();

            foreach (Control control in controls)
            {
                if (!control.Anchor.ToString().Contains("Bottom"))
                {
                    continue;
                }
                modifiedControls.Add(new ControlObject(control, control.Anchor));
                control.Anchor = AnchorStyles.Top;

                //switch (control.Anchor)
                //{
                //    case AnchorStyles.Bottom | AnchorStyles.Right:
                //        control.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //        modifiedControls.Add(new ControlObject(control, AnchorStyles.Bottom | AnchorStyles.Right));
                //        break;
                //    case AnchorStyles.Bottom | AnchorStyles.Left:
                //        control.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                //        modifiedControls.Add(new ControlObject(control, AnchorStyles.Bottom | AnchorStyles.Left));
                //        break;
                //    case AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left: //OCCHIOOOOO!!!!!!!!
                //        control.Anchor = AnchorStyles.Top | AnchorStyles.Right  | AnchorStyles.Left;
                //        modifiedControls.Add(new ControlObject(control, AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left));
                //        break;
                //    case AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left:
                //        control.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
                //        modifiedControls.Add(new ControlObject(control, AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left));
                //        break;
                //}
            }

            return modifiedControls;
        }

        private static void RecreateControlsBottomAncorage(IEnumerable<ControlObject> modifiedControls)
        {
            foreach (ControlObject controlObject in modifiedControls)
            {
                controlObject.control.Anchor = controlObject.previousAnchor;
            }
        }

        #endregion Private Methods
    }
}
