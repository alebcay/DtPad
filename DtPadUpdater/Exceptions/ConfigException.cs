using System;
using System.Runtime.Serialization;

namespace DtPadUpdater.Exceptions
{
    /// <summary>
    /// Config serializable custom exception.
    /// </summary>
    /// <author>Marco Macciò</author>
    [Serializable]
    public class ConfigException : Exception
    {
        #region Public Methods

        public ConfigException()
        {
        }

        public ConfigException(String message)
            : base(message)
        {
        }

        public ConfigException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Methods

        #region Protected Methods

        protected ConfigException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Methods
    }
}
