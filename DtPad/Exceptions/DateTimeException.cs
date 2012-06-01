using System;
using System.Runtime.Serialization;

namespace DtPad.Exceptions
{
    /// <summary>
    /// DateTime serializable custom exception.
    /// </summary>
    /// <author>Marco Macciò</author>
    [Serializable]
    public class DateTimeException : Exception
    {
        #region Public Methods

        public DateTimeException()
        {
        }

        public DateTimeException(String message)
            : base(message)
        {
        }

        public DateTimeException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Methods

        #region Protected Methods

        protected DateTimeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Methods
    }
}
