using System.ComponentModel;
using System.Windows.Forms;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom ComboBox (to use clipboard).
    /// </summary>
    /// <author>Marco Macciò</author>
    public sealed class CustomComboBox : ComboBox
    {
        public CustomComboBox()
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
            int startIndex = SelectionStart;
            int length = SelectionLength;

            if (e.Button == MouseButtons.Right)
            {
                CustomContextMenuStrip.Show(this, e.Location, ToolStripDropDownDirection.BelowRight);
            }
            else
            {
                base.OnMouseUp(e);
            }

            Select(startIndex, length);
        }

        #endregion Protected Methods
    }
}
