using System;
using System.Drawing;

namespace DtPad.Customs
{
    /// <summary>
    /// Arguments of main text font change event.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class MainFontChangeArgs : EventArgs
    {
        private Font mainFont;

        #region Internal Methods

        internal MainFontChangeArgs(Font newFont)
        {
            mainFont = newFont;
        }

        internal Font MainFont()
        {
            return mainFont;
        }

        #endregion Internal Methods
    }
}
