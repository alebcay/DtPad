using System;
using System.Linq;
using System.Text;

namespace DtPadUpdater.Utils
{
    /// <summary>
    /// Crypting and decrypting util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class CodingUtil
    {
        #region Internal Methods

        internal static String DecodeByte(String inputString)
        {
            Encoding encoding = Encoding.UTF8;
            Decoder decoder = encoding.GetDecoder();

            String[] separator = { "-" };
            String[] splittedInputString = inputString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            byte[] byteArray = new byte[splittedInputString.Length];
            for (int i = 0; i < splittedInputString.Length; i++)
            {
                byteArray[i] = Convert.ToByte(splittedInputString[i]);
            }

            char[] charArray = new char[decoder.GetCharCount(byteArray, 0, byteArray.Length, true)];
            String outputString = String.Empty;
            decoder.GetChars(byteArray, 0, byteArray.Length, charArray, 0, true);

            //for (int i = 0; i < charArray.Length; i++)
            //{
            //    outputString = outputString + charArray[i];
            //}
            outputString = charArray.Aggregate(outputString, (current, t) => current + t);

            return StringUtil.Rot13Transform(outputString);
        }

        #endregion Internal Methods
    }
}
