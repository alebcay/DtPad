using System;
using System.Runtime.Serialization;

namespace DtPad.Exceptions
{
    /// <summary>
    /// Session serializable custom exception.
    /// </summary>
    /// <author>Marco Macciò</author>
    [Serializable]
    public class SessionException : Exception
    {
        #region Public Methods

        public SessionException()
        {
        }

        public SessionException(String message)
            : base(message)
        {
        }

        public SessionException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Methods

        #region Protected Methods

        protected SessionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Methods
    }
}
