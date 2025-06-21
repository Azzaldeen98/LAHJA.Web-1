
using Microsoft.Extensions.Logging;
using Shared.Interfaces;



namespace Shared.Services.Infrastructure.Extensions
{
    public interface ILoggingService : ITScope
    {
        void LogError(Exception exception, string context = null);
        void LogWarning(Exception exception = null, string context = null);
        void LogInformation(string message, string context = null);
        void LogDebug(string message, string context = null);
        void LogTrace(string message, string context = null);
        void LogCritical(Exception exception, string context = null);
    }



    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Error logging
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="context"> Where the error occurred</param>
        /// <returns></returns>
        public void LogError(Exception exception, string context = null)
        {
            var message = context is not null
                ? $"⚠️ [{context}] - {exception.Message}"
                : $"⚠️ {exception.Message}";

            _logger.LogError(exception, message);
            //return Task.CompletedTask;
        }

        /// <summary>
        /// Log a warning with an optional context.
        /// </summary>
        /// <param name="exception">The exception that triggered the warning (optional).</param>
        /// <param name="context">The context where the warning occurred (optional).</param>
        public void LogWarning(Exception exception = null, string context = null)
        {
            // إذا كان الاستثناء موجودًا، يتم تضمين تفاصيله في الرسالة
            string message;
            if (exception != null)
            {
                message = context is not null
                    ? $"⚠️ [{context}] - {exception.Message} - StackTrace: {exception.StackTrace}"
                    : $"⚠️ {exception.Message} - StackTrace: {exception.StackTrace}";
            }
            else
            {
                message = context is not null
                    ? $"⚠️ [{context}] - No exception, just a warning."
                    : "⚠️ Just a warning with no exception.";
            }

            // تسجيل التحذير باستخدام ILogger
            _logger.LogWarning(message);
        }

        /// <summary>
        /// تسجيل المعلومات
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void LogInformation(string message, string context = null)
        {
            string logMessage = context != null
                ? $"ℹ️ [{context}] - {message}"
                : $"ℹ️ {message}";
            _logger.LogInformation(logMessage);
        }

        /// <summary>
        /// تسجيل رسائل التصحيح (Debug)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void LogDebug(string message, string context = null)
        {
            string logMessage = context != null
                ? $"🐞 [{context}] - {message}"
                : $"🐞 {message}";
            _logger.LogDebug(logMessage);
        }

        /// <summary>
        /// تسجيل رسائل التتبع (Trace)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void LogTrace(string message, string context = null)
        {
            string logMessage = context != null
                ? $"🔍 [{context}] - {message}"
                : $"🔍 {message}";
            _logger.LogTrace(logMessage);
        }

        /// <summary>
        /// تسجيل الرسائل الحرجة (Critical)
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="context"></param>
        public void LogCritical(Exception exception, string context = null)
        {
            var message = context != null
                ? $"🚨 [{context}] - {exception.Message} - StackTrace: {exception.StackTrace}"
                : $"🚨 {exception.Message} - StackTrace: {exception.StackTrace}";
            _logger.LogCritical(exception, message);
        }
    }

}
