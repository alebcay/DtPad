using System;
using System.Runtime.Serialization;

namespace AppLimit.CloudComputing.SharpBox.Exceptions
{
    /// <summary>
    /// Config serializable custom exception.
    /// </summary>
    /// <author>Marco Macciò</author>
    [Serializable]
    public class HttpInternalException : Exception
    {
        public int code { get; set; }

        #region Public Methods

        public HttpInternalException()
        {
        }

        public HttpInternalException(int codeValue, String message)
            : base(message)
        {
            code = codeValue;
        }

        public HttpInternalException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Methods

        #region Protected Methods

        protected HttpInternalException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Methods
    }
}
