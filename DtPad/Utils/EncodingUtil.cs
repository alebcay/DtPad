using System;
using System.IO;
using System.Linq;
using System.Text;

namespace DtPad.Utils
{
    /// <summary>
    /// Encoding util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class EncodingUtil
    {
        #region Internal Methods

        internal static bool IsEncodingDefaultEnabled()
        {
            return ConfigUtil.GetBoolParameter("DefaultEncoding");
        }

        internal static Encoding GetDefaultEncoding()
        {
            switch (ConfigUtil.GetIntParameter("Encoding"))
            {
                case 0:
                    return Encoding.Default;
                case 1:
                    return new UTF8Encoding(true);
                case 2:
                    return new UTF8Encoding(false);
                case 3:
                    return Encoding.Unicode;
                case 4:
                    return Encoding.BigEndianUnicode;
                case 5:
                    return Encoding.UTF32;

                default:
                    return new UTF8Encoding(true);
            }
        }

        internal static int GetEncodingIndexFromType(Encoding encoding)
        {
            if (encoding == Encoding.Default)
            {
                return 0;
            }
            if (encoding == new UTF8Encoding(true))
            {
                return 1;
            }
            if (encoding == new UTF8Encoding(false))
            {
                return 2;
            }
            if (encoding == Encoding.Unicode)
            {
                return 3;
            }
            if (encoding == Encoding.BigEndianUnicode)
            {
                return 4;
            }
            if (encoding == Encoding.UTF32)
            {
                return 5;
            }

            return 1;
        }

        internal static String GetEncodingCodePageFromIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return Encoding.Default.CodePage.ToString();
                case 1:
                    return new UTF8Encoding(true).CodePage.ToString();
                case 2:
                    return new UTF8Encoding(false).CodePage.ToString();
                case 3:
                    return Encoding.Unicode.CodePage.ToString();
                case 4:
                    return Encoding.BigEndianUnicode.CodePage.ToString();
                case 5:
                    return Encoding.UTF32.CodePage.ToString();

                default:
                    return String.Empty;
            }
        }

        internal static Encoding GetFileEncoding(String fileName)
        {
            bool withBOM;
            return GetFileEncoding(fileName, out withBOM);
        }
        internal static Encoding GetFileEncoding(String fileName, out bool withBOM)
        {
            Encoding result = null;
            FileInfo fileInfo = new FileInfo(fileName);
            FileStream fileStream = null;
            withBOM = true;

            try
            {
                fileStream = fileInfo.OpenRead();
                Encoding[] unicodeEncodings = { Encoding.BigEndianUnicode, Encoding.UTF32, new UTF8Encoding(true), Encoding.Unicode }; //new UTF8Encoding(false)

                for (int i = 0; result == null && i < unicodeEncodings.Length; i++)
                {
                    fileStream.Position = 0;
                    byte[] preamble = unicodeEncodings[i].GetPreamble();
                    bool preamblesAreEqual = true;

                    for (int j = 0; preamblesAreEqual && j < preamble.Length; j++)
                    {
                        preamblesAreEqual = (preamble[j] == fileStream.ReadByte());
                    }

                    if (!preamblesAreEqual)
                    {
                        continue;
                    }

                    result = unicodeEncodings[i];
                }

                if (result == null) //new UTF8Encoding(false) o Encoding.Default?
                {
                    byte[] byteArray = new byte[Convert.ToInt32(fileStream.Length)];
                    fileStream.Read(byteArray, 0, Convert.ToInt32(fileStream.Length));
                    String sANSI = Encoding.Default.GetString(byteArray);
                    String sUTF8 = new UTF8Encoding(false).GetString(byteArray);

                    if (sANSI == sUTF8) //If they are equal let default value decide if it is UTF-8 without BOM, otherwise ANSI
                    {
                        if (GetDefaultEncoding() == new UTF8Encoding(false))
                        {
                            withBOM = false;
                            result = new UTF8Encoding(false);
                        }
                        else
                        {
                            result = Encoding.Default;
                        }
                    }
                    else //Otherwise I try to find en error character into file content
                    {
                        //foreach (char c in s)
                        //{
                        //    if (c == 65533)
                        //    {
                        //        result = Encoding.Default;
                        //        break;
                        //    }
                        //}
                        if (sUTF8.Any(c => c == 65533))
                        {
                            result = Encoding.Default;
                        }

                        if (result == null)
                        {
                            withBOM = false;
                            result = new UTF8Encoding(false);
                        }
                    }
                }
            }
            catch (IOException)
            {
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            return result ?? (Encoding.Default);
        }

        #endregion Internal Methods
    }
}
