using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Managers;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom DevExpress XtraTabControl (to distinguish main textarea from others).
    /// </summary>
    /// <author>Marco Macciò</author>
    /// <seealso cref="http://community.devexpress.com/forums/p/14918/196089.aspx"/>
    public class CustomXtraTabControl : XtraTabControl
    {
        #region Protected Methods

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnMouseUp(e);
                return;
            }

            TabManager.MouseUpOnTab(form, e);
            base.OnMouseUp(e);
        }

        #endregion Protected Methods
    }
}
