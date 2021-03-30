using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Nlog记录日志到Sqlite并加密_Net5Wpf.LoggingExtensions
{
    public static class LogExtensions
    {
        //public static void LogModel<T>(this ILogger logger, T model)
        //{
        //    logger.
        //}

        public static ILoggingBuilder AddDb<T>(this ILoggingBuilder builder)
            where T : DbContext
        {
            //builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, DbLoggerProvider<T>>(
            //    (srvPrv) =>
            //    {
            //        return new DbLoggerProvider<T>(srvPrv.GetService<T>());
            //    }
            //));
            builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, DbLoggerProvider<T>>(
                (srvPrv) =>
                {
                    var bbb = srvPrv.GetService<T>();
                    return new DbLoggerProvider<T>(bbb);
                }
            ));
            return builder;
        }
    }
}
