using System.Drawing;
using System.Windows.Forms;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom MonthCalendar.
    /// </summary>
    /// <author>Marco Macciò</author>
    public class CustomMonthCalendar : Pabo.Calendar.MonthCalendar
    {
        #region Protected Methods

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) //Maintain namespace
            {
                return;
            }

            int x = Left;
            int y = Top;
            Control control = this;

            while (control.Parent != null)
            {
                x += control.Parent.Left + control.Padding.Left;
                y += control.Parent.Top - control.Padding.Top;

                control = control.Parent;
            }

            ContextMenuStrip.Show(new Point(x + e.X, y + e.Y + ContextMenuStrip.Height));
        }

        #endregion Protected Methods
    }
}
