using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AppLimit.CloudComputing.SharpBox;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom form.
    /// </summary>
    /// <author>Marco Macciò</author>
    public class CustomForm : Form
    {
        #region Public Instance Fields

        [Category("Behavior"), Browsable(true), DisplayName("TextFont")]
        public Font TextFont { get; private set; }

        [Category("Behavior"), Browsable(true), DisplayName("TextFontColor")]
        public Color TextFontColor { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("TextBackgroundColor")]
        public Color TextBackgroundColor { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("TabIdentity")]
        public int TabIdentity { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("DropboxCloudStorage")]
        public CloudStorage DropboxCloudStorage { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("KeepInitialSpacesOnReturn")]
        public bool KeepInitialSpacesOnReturn { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("KeepBulletListOnReturn")]
        public bool KeepBulletListOnReturn { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("PreviousWindowState")]
        public FormWindowState PreviousWindowState { get; set; }

        public bool IsOpening { get; set; }

        #endregion Public Instance Fields

        #region Internal Instance Fields

        internal bool ToolsFirstLoadExecuted { get; set; }
        internal CustomPrintDocument PrintDocument { get; set; }
        internal Splash SplashWindow { get; set; }
        internal String LastDropboxFolder { get; set; }

        #endregion Internal Instance Fields

        #region Internal Event Methods

        internal delegate void MainFontChanged(object sender, MainFontChangeArgs e);
        internal event MainFontChanged MainFontChange;

        internal void SetMainFont(Font newFont)
        {
            TextFont = newFont;

            MainFontChangeArgs fontChange = new MainFontChangeArgs(newFont);
            MainFontChange(this, fontChange);
        }

        #endregion Internal Event Methods

        #region Protected Methods

        protected override void OnShown(EventArgs e)
        {
            WindowManager.ShowWelcome(this);
            base.OnShown(e);
        }

        protected void PreInitializeForm()
        {
            TabIdentity = 1;

            PrintDocument = new CustomPrintDocument();

            Size = new Size(ConfigUtil.GetIntParameter("WindowSizeX"), ConfigUtil.GetIntParameter("WindowSizeY"));
            WindowState = (ConfigUtil.GetStringParameter("WindowState") == "Maximized" ? FormWindowState.Maximized : FormWindowState.Normal);
            PreviousWindowState = WindowState;
            KeepInitialSpacesOnReturn = ConfigUtil.GetBoolParameter("KeepInitialSpacesOnReturn");
            KeepBulletListOnReturn = ConfigUtil.GetBoolParameter("KeepBulletListOnReturn");
            //PreviousWindowState = (WindowState == FormWindowState.Minimized ? FormWindowState.Normal : WindowState);

            TextFont = ConfigUtil.GetFontParameter("FontInUse");
            String[] argbFontColor = ConfigUtil.GetStringParameter("FontInUseColorARGB").Split(new[] { ';' });
            TextFontColor = Color.FromArgb(Convert.ToInt32(argbFontColor[0]), Convert.ToInt32(argbFontColor[1]), Convert.ToInt32(argbFontColor[2]), Convert.ToInt32(argbFontColor[3]));
            String[] argbBackgroundColor = ConfigUtil.GetStringParameter("BackgroundColorARGB").Split(new[] { ';' });
            TextBackgroundColor = Color.FromArgb(Convert.ToInt32(argbBackgroundColor[0]), Convert.ToInt32(argbBackgroundColor[1]), Convert.ToInt32(argbBackgroundColor[2]), Convert.ToInt32(argbBackgroundColor[3]));
        }

        #endregion Protected Methods
    }
}
