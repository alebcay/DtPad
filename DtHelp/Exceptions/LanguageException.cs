using System;
using System.Runtime.Serialization;

namespace DtHelp.Exceptions
{
    /// <summary>
    /// Multilanguage serializable custom exception.
    /// </summary>
    /// <author>Marco Macciò</author>
    [Serializable]
    public class LanguageException : Exception
    {
        #region Public Methods

        public LanguageException()
        {
        }

        public LanguageException(String message)
            : base(message)
        {
        }

        public LanguageException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Methods

        #region Protected Methods

        protected LanguageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Methods
    }
}
