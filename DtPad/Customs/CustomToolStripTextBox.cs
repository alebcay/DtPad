using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom ToolStripTextBox (to use clipboard).
    /// </summary>
    /// <author>Marco Macciò</author>
    public sealed class CustomToolStripTextBox : ToolStripTextBox
    {
        #region Public Instance Fields

        [Category("Behavior"), Browsable(true), DisplayName("CustomContextMenuStrip")]
        public ContextMenuStrip CustomContextMenuStrip { get; set; }

        #endregion Public Instance Fields

        #region Protected Methods

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Focus();
                CustomContextMenuStrip.Show(Owner, new Point(e.X + 50, e.Y + 5), ToolStripDropDownDirection.BelowRight);
            }
            else
            {
                base.OnMouseUp(e);
            }
        }

        #endregion Protected Methods
    }
}
