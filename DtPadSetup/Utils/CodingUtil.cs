using System;
using System.Text;

namespace DtPadSetup.Utils
{
    /// <summary>
    /// Crypting and decrypting util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class CodingUtil
    {
        #region Internal Methods

        internal static String EncodeString(String inputString)
        {
            Encoding encoding = Encoding.UTF8;
            Encoder encoder = encoding.GetEncoder();

            inputString = StringUtil.Rot13Transform(inputString);

            char[] charArray = inputString.ToCharArray();
            byte[] byteArray = new byte[encoder.GetByteCount(charArray, 0, charArray.Length, true)];
            String outputString = String.Empty;
            encoder.GetBytes(charArray, 0, charArray.Length, byteArray, 0, true);

            for (int i = 0; i < byteArray.Length; i++)
            {
                outputString = outputString + byteArray[i];

                if (i != byteArray.Length - 1)
                {
                    outputString = outputString + "-";
                }
            }

            return outputString;
        }

        #endregion Internal Methods
    }
}
