using System;
using System.Linq;
using System.Text;

namespace DtPad.Utils
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
