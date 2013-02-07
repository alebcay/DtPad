using System.Windows.Forms;

namespace DtPad.Customs
{
    /// <summary>
    /// CustomCheckbox (when focused it supports the + key to check the CheckBox and the - key to uncheck the CheckBox)
    /// </summary>
    /// <author>Derek Morin, Marco Macciò</author>
    public class CustomCheckBox : CheckBox
    {
        #region Protected Methods

        /// <summary>
        /// Supports the + key to check the CheckBox and the - key to uncheck the CheckBox
        /// </summary>
        /// <author>Derek Morin</author>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Oemplus:
                case Keys.Add:
                    Checked = true;
                    break;
                case Keys.OemMinus:
                case Keys.Subtract:
                    Checked = false;
                    break;
            }

            base.OnKeyDown(e);
        }

        #endregion Protected Methods
    }
}
