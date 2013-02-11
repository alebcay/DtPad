using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom Panel (to use hosts configurator panel inside tab page).
    /// </summary>
    /// <author>Marco Macciò</author>
    public class CustomPanel : Panel
    {
        public CustomPanel()
        {
            HorizontalLine = false;
            HorizontalLineOnTop = false;
            NotShowLine = false;
            MarginLeftHorizontalLine = 0;
            MarginBottomHorizontalLine = 1;
            MarginTopHorizontalLine = 1;
        }

        #region Public Instance Fields

        [Category("Behavior"), Browsable(true), DisplayName("HorizontalLine")]
        public bool HorizontalLine { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("HorizontalLineOnTop")]
        public bool HorizontalLineOnTop { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("NotShowLine")]
        public bool NotShowLine { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("MarginLeftHorizontalLine")]
        public int MarginLeftHorizontalLine { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("MarginBottomHorizontalLine")]
        public int MarginBottomHorizontalLine { get; set; }

        [Category("Behavior"), Browsable(true), DisplayName("MarginTopHorizontalLine")]
        public int MarginTopHorizontalLine { get; set; }

        #endregion Public Instance Fields

        #region Protected Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            if (NotShowLine)
            {
                base.OnPaint(e);
                return;
            }

            Pen pen = null;
            try
            {
                if (HorizontalLine)
                {
                    pen = new Pen(Color.DeepSkyBlue, 1);
                    pen.DashStyle = DashStyle.Dash;

                    if (!HorizontalLineOnTop)
                    {
                        e.Graphics.DrawLine(pen, MarginLeftHorizontalLine, Height - MarginBottomHorizontalLine, Width, Height - MarginBottomHorizontalLine);
                    }
                    else
                    {
                        e.Graphics.DrawLine(pen, MarginLeftHorizontalLine, 0 + MarginTopHorizontalLine, Width, 0 + MarginTopHorizontalLine);
                    }
                }
                else
                {
                    pen = new Pen(Color.DeepSkyBlue, 1);
                    pen.DashStyle = DashStyle.Dash;
                    e.Graphics.DrawLine(pen, 3, 0, 3, Height - 3);
                }
            }
            finally
            {
                if (pen != null)
                {
                    pen.Dispose();
                }
            }

            base.OnPaint(e);
        }

        #endregion Protected Methods
    }
}
