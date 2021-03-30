using NLog;
using NLog.Config;
using NLog.Targets;

namespace Nlog记录日志到Sqlite并加密_Net5Wpf.NLog
{
    [Target("DbContext")]
    public sealed class DbContextTarget : TargetWithLayout
    {
        public DbContextTarget()
        {
            Name = "DbContext";
            OptimizeBufferReuse = true;
        }

        protected override void Write(LogEventInfo logEvent)
        {
            string logMessage = this.Layout.Render(logEvent);

            //TODO write to target
        }
    }
}
