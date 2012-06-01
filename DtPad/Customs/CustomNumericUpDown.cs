using System.ComponentModel;
using System.Windows.Forms;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom NumericUpDown (to use clipboard).
    /// </summary>
    /// <author>Marco Macciò</author>
    public sealed class CustomNumericUpDown : NumericUpDown
    {
        public CustomNumericUpDown()
        {
            ContextMenuStrip = new ContextMenuStrip();
        }

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
                CustomContextMenuStrip.Show(this, e.Location, ToolStripDropDownDirection.BelowRight);
            }
            else
            {
                base.OnMouseUp(e);
            }
        }

        #endregion Protected Methods
    }
}
