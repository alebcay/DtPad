using System.Windows.Forms;

namespace DtPad.Objects
{
    /// <summary>
    /// Control object.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class ControlObject
    {
        internal ControlObject(Control control, AnchorStyles previousAnchor)
        {
            this.control = control;
            this.previousAnchor = previousAnchor;
        }

        #region Internal Instance Properties

        internal Control control { private set; get; }
        internal AnchorStyles previousAnchor { private set; get; } 

        #endregion Internal Instance Properties
    }
}
