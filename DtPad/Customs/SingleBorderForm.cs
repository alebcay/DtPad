using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom form with single border (ie. used for fast tabs switching window).
    /// </summary>
    /// <author>Marco Macciò</author>
    public class SingleBorderForm : Form
    {
        protected SingleBorderForm()
        {
            FormBorderStyle = FormBorderStyle.None;
        }

        #region Protected Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = null;
            try
            {
                pen = new Pen(Color.Gray, 1); //DeepSkyBlue
                pen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, 1, 1, Width - 2, Height - 2);
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
