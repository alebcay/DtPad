using System;

namespace DtPadSetup.Utils
{
    /// <summary>
    /// String management util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class StringUtil
    {
        #region Internal Methods

        internal static String Rot13Transform(String inputString)
        {
            char[] array = inputString.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }

                array[i] = (char)number;
            }

            return new String(array);
        }
		
		#endregion Internal Methods
    }
}
