using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DtHelp.Utils;

namespace DtHelp.Managers
{
    /// <summary>
    /// Help manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class HelpManager
    {
        #region Internal Methods

        internal static void ManageHelpPanel(Form form, CancelEventArgs e, String culture)
        {
            e.Cancel = true;

            if (!IsPanelVisible(form))
            {
                form.Height = form.Height + ConstantUtil.standardHelpPanelHeight;

                PictureBox helpPictureBox = new PictureBox
                                                {
                                                    Image = ToolbarResource.info_blue,
                                                    Location = new Point(13, 7),
                                                    Name = "helpPictureBox",
                                                    Size = new Size(16, 16),
                                                    TabStop = false
                                                };
                Label helpLabel = new Label
                                      {
                                          Text = LanguageUtil.GetCurrentLanguageString("helpLabel", form.Name, culture),
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
            }
            else
            {
                form.Height = form.Height - ConstantUtil.standardHelpPanelHeight;

                form.Controls.RemoveByKey("helpPanel");
            }
        }

        #endregion Internal Methods

        #region Private Methods

        private static bool IsPanelVisible(Control form)
        {
            return form.Controls.ContainsKey("helpPanel");
        }

        #endregion Private Methods
    }
}
