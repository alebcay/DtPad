using System.Drawing;

namespace DtPad.Utils
{
    /// <summary>
    /// Color configurations util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ColorUtil
    {
        #region Internal Methods

        internal static int GetIndexFromTabColor(Color selectedColor)
        {
            if (selectedColor == Color.Orange)
            {
                return 0;
            }
            if (selectedColor == Color.Red)
            {
                return 1;
            }
            if (selectedColor == Color.Green)
            {
                return 2;
            }
            if (selectedColor == Color.Blue)
            {
                return 3;
            }
            if (selectedColor == Color.Black)
            {
                return 4;
            }

            return 4;
        }

        internal static Color GetColorFromTabInt(int selectedIndex)
        {
            switch(selectedIndex)
            {
                case 0:
                    return Color.Orange;
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Green;
                case 3:
                    return Color.Blue;
                case 4:
                    return Color.Black;

                default:
                    return Color.Black;
            }
        }

        #endregion Internal Methods
    }
}
