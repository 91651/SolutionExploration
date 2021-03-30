using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nlog记录日志到Sqlite并加密_Net5Wpf.Data;
using Nlog记录日志到Sqlite并加密_Net5Wpf.LoggingExtensions;

namespace Nlog记录日志到Sqlite并加密_Net5Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; }
        public static IServiceProvider Container { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            // 注入服务
            ConfigureServices();
        }
        private void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(option => option.UseSqlite("Filename=APP.db;"));
            services.AddLogging(builder =>
            {
                //var l = new LoggingConfiguration();
                //var b = new DbContextTarget();
                //l.AddTarget(b);
                //builder.AddNLog(l);
                //builder.AddNLog("NLog.config");

                builder.AddDb<AppDbContext>();
            });
            Container = services.BuildServiceProvider();
        }
    }
}
