using System;
using System.Runtime.Serialization;

namespace DtPad.Exceptions
{
    /// <summary>
    /// Parse serializable custom exception.
    /// </summary>
    /// <author>Marco Macciò</author>
    [Serializable]
    public class ParseException : Exception
    {
        #region Public Methods

        public ParseException()
        {
        }

        public ParseException(String message)
            : base(message)
        {
        }

        public ParseException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Methods

        #region Protected Methods

        protected ParseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Methods
    }
}
