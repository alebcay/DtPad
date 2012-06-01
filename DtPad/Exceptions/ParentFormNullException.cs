using System;
using System.Runtime.Serialization;

namespace DtPad.Exceptions
{
    /// <summary>
    /// ParentForm null serializable custom exception.
    /// </summary>
    /// <author>Marco Macciò</author>
    [Serializable]
    public class ParentFormNullException : Exception
    {
        #region Public Methods

        public ParentFormNullException()
        {
        }

        public ParentFormNullException(String message)
            : base(message)
        {
        }

        public ParentFormNullException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Methods

        #region Protected Methods

        protected ParentFormNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Methods
    }
}
