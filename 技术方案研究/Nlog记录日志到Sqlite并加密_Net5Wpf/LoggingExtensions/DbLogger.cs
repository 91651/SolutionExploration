using System;
using Microsoft.Extensions.Logging;

namespace Nlog记录日志到Sqlite并加密_Net5Wpf.LoggingExtensions
{
    public class DbLogger<T> : ILogger
    {
        private readonly string logName;
        private readonly DbLoggerProvider<T> LoggerPrv;
        private readonly T _dbContext;

        public DbLogger(string logName, DbLoggerProvider<T> loggerPrv)
        {
            this.logName = logName;
            this.LoggerPrv = loggerPrv;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }
    }
}
