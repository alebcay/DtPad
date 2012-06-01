using System;
using System.Reflection;
using log4net;
using log4net.Config;

[assembly: XmlConfigurator(Watch = true)]
namespace DtPad.Utils
{
    /// <summary>
    /// Log4Net implementation class.
    /// </summary>
    /// <author>Marco Macciò</author>
    /// <remarks>
    /// private enum LogLevel { info, debug, warn, error, fatal }
    /// </remarks>
    internal class LogUtil
    {
        private readonly ILog log;

        internal LogUtil(MethodBase methodBase)
        {
            log = LogManager.GetLogger(methodBase.DeclaringType);
        }

        #region Internal Log Methods

        /// <summary>
        /// Fatal logging.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <param name="exception">The exception raised up.</param>
        internal void fatalLog(String message, Exception exception)
        {
            if (log.IsFatalEnabled)
            {
                log.Fatal(message, exception);
            }
        }

        /// <summary>
        /// Error logging.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <param name="exception">The exception raised up.</param>
        internal void errorLog(String message, Exception exception)
        {
            if (log.IsErrorEnabled)
            {
                log.Error(message, exception);
            }
        }

        ///// <summary>
        ///// Warn logging.
        ///// </summary>
        ///// <param name="message">The log message</param>
        ///// <param name="exception">The exception raised up</param>
        //internal void warnLog(String message, Exception exception)
        //{
        //    if (log.IsWarnEnabled)
        //    {
        //        log.Warn(message, exception);
        //    }
        //}

        ///// <summary>
        /////// Fatal logging.
        ///// </summary>
        ///// <param name="message">The log message.</param>
        //internal void warnLog(String message)
        //{
        //    if (log.IsWarnEnabled)
        //    {
        //        log.Warn(message);
        //    }
        //}

        ///// <summary>
        ///// Debug logging.
        ///// </summary>
        ///// <param name="message">The log message.</param>
        ///// <param name="exception">The exception raised up.</param>
        //internal void debugLog(String message, Exception exception)
        //{
        //    if (log.IsDebugEnabled)
        //    {
        //        log.Debug(message, exception);
        //    }
        //}

        ///// <summary>
        ///// Debug logging.
        ///// </summary>
        ///// <param name="message">The log message.</param>
        //internal void debugLog(String message)
        //{
        //    if (log.IsDebugEnabled)
        //    {
        //        log.Debug(message);
        //    }
        //}

        ///// <summary>
        ///// Info logging.
        ///// </summary>
        ///// <param name="message">The log message.</param>
        //internal void infoLog(String message)
        //{
        //    if (log.IsInfoEnabled)
        //    {
        //        log.Info(message);
        //    }
        //}

        #endregion Internal Log Methods
    }
}
