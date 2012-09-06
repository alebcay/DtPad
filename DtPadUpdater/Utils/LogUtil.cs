using System;
using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace DtPadUpdater.Utils
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

            PatternLayout patternLayout = new PatternLayout { ConversionPattern = "%date [%thread] %-5level %logger - %message%newline" };
            FileAppender fileAppender = new FileAppender
                                            {
                                                File = ConstantUtil.logFile,
                                                AppendToFile = true,
                                                Layout = patternLayout,
                                                Threshold = Level.Warn,
                                                Name = "DtPadUpdaterFileAppender"
                                            };
            fileAppender.ActivateOptions();
            BasicConfigurator.Configure(fileAppender);
        }

        #region Internal Log Methods

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

        #endregion Internal Log Methods
    }
}
