using System;
using System.Runtime.Serialization;

namespace DtPad.Exceptions
{
    /// <summary>
    /// Not-an-exception custom exception.
    /// </summary>
    /// <author>Marco Macciò</author>
    [Serializable]
    public class FakeException : Exception
    {
        #region Public Methods

        public FakeException()
        {
        }

        public FakeException(String message)
            : base(message)
        {
        }

        public FakeException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Methods

        #region Protected Methods

        protected FakeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Methods
    }
}
