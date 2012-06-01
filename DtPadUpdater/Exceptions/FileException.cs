using System;
using System.Runtime.Serialization;

namespace DtPadUpdater.Exceptions
{
    /// <summary>
    /// File serializable custom exception.
    /// </summary>
    /// <author>Marco Macciò</author>
    [Serializable]
    public class FileException : Exception
    {
        #region Public Methods

        public FileException()
        {
        }

        public FileException(String message)
            : base(message)
        {
        }

        public FileException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Methods

        #region Protected Methods

        protected FileException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Methods
    }
}
