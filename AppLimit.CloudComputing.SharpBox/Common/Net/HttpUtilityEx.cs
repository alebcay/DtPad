using System;
using System.Linq;
using System.Text;
using System.Net;
using AppLimit.CloudComputing.SharpBox.Common.IO;

namespace AppLimit.CloudComputing.SharpBox.Common.Net
{
    /// <summary>
    /// This class exposes some extensions to the .NET HttpUtility class
    /// </summary>
    public class HttpUtilityEx
    {
        /// <summary>
        /// This method encodes an url
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string UrlEncodeUTF8(string text)
        {
            if (text == null)
            {
                return null;
            }

            if (text.Length == 0)
            {
                return String.Empty;
            }

            //encode with url encoder
            String enc = Uri.EscapeDataString(text); //HttpUtility.UrlEncode(text, Encoding.UTF8);

            //fix the missing space
            enc = enc.Replace("+", "%20");

            //fix the exclamation point
            enc = enc.Replace("!", "%21");

            //fix the quote
            enc = enc.Replace("'", "%27");

            //fix the parentheses
            enc = enc.Replace("(", "%28");
            enc = enc.Replace(")", "%29");

            // uppercase the encoded stuff            
            StringBuilder enc2 = new StringBuilder();

            for (int i = 0; i < enc.Length; i++)
            {
                // copy char
                enc2.Append(enc[i]);

                // upper stuff
                if (enc[i] != '%')
                {
                    continue;
                }

                enc2.Append(Char.ToUpper(enc[i + 1]));
                enc2.Append(Char.ToUpper(enc[i + 2]));

                i += 2;
            }

            return enc2.ToString();
        }

        /// <summary>
        /// This method returns true if the give http error code is a success 
        /// error code, this means in 2XX
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Boolean IsSuccessCode(HttpStatusCode code)
        {
            return (((int)code >= 200 && (int)code < 300));
        }

        /// <summary>
        /// This method generates a well encoded uri string
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static String GenerateEncodedUriString(Uri uri)
        {
            //first part of string
            String uriString = uri.Scheme + "://" + uri.Host + ":" + uri.Port;

            //for (int i = 0; i < uri.Segments.Length; i++)
            //{
            //    String partString = uri.Segments[i];
            //    partString = partString.TrimEnd('/');

            //    uriString = PathHelper.Combine(uriString, partString);
            //}
            return uri.Segments.Select(partString => partString.TrimEnd('/')).Aggregate(uriString, PathHelper.Combine);
        }
    }
}
