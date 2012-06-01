using System;
using System.Runtime.Serialization;

namespace DtPad.Exceptions
{
    /// <summary>
    /// Template serializable custom exception.
    /// </summary>
    /// <author>Marco Macciò</author>
    [Serializable]
    public class TemplateException : Exception
    {
        #region Public Methods

        public TemplateException()
        {
        }

        public TemplateException(String message)
            : base(message)
        {
        }

        public TemplateException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Methods

        #region Protected Methods

        protected TemplateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Methods
    }
}
