using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Nlog记录日志到Sqlite并加密_Net5Wpf.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //var connectionString = new SqliteConnectionStringBuilder("Data Source=APP.db;")
            //{
            //    Mode = SqliteOpenMode.ReadWriteCreate,
            //    Password = "Password"
            //}.ToString();
            //optionsBuilder.UseSqlite(connectionString);
            //optionsBuilder.UseLoggerFactory(LoggerFactory);
        }
    }


    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.BaseType == null && entity.ClrType.CustomAttributes.All(a => a.AttributeType != typeof(TableAttribute)))
                {
                    entity.SetTableName(entity.GetDefaultTableName());
                }
            }

        }
    }
}
