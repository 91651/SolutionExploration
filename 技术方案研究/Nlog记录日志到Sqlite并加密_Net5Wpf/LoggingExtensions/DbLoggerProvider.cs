using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Nlog记录日志到Sqlite并加密_Net5Wpf.LoggingExtensions
{
    public class DbLoggerProvider<T> : ILoggerProvider
    {
        private readonly T _dbContext;
        private readonly ConcurrentDictionary<string, DbLogger<T>> loggers =
            new ConcurrentDictionary<string, DbLogger<T>>();

        public DbLoggerProvider(T config) =>
        _dbContext = config;

        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }
        private DbLogger<T> CreateLoggerImplementation(string name)
        {
            return new DbLogger<T>(name, this);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
