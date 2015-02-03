using System.Configuration;
using System.Data.Common;
using System.Data.Entity;

namespace OracleEntityFramework.Context
{
    public class BaseContext<T> : DbContext where T : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<T>(null);
        }

        protected BaseContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection) { }

        protected BaseContext()
            : base("name=MainContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var defaultSchema = ConfigurationManager.AppSettings["DefaultSchema"];
            if (!string.IsNullOrEmpty(defaultSchema))
            {
                modelBuilder.HasDefaultSchema(defaultSchema);
            }
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
