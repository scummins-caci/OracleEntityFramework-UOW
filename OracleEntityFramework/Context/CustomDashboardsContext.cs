using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using OracleEntityFramework.Models;

namespace OracleEntityFramework.Context
{
    public class CustomDashboardsContext : BaseContext<CustomDashboardsContext>, ISettingsEFContext
    {
        public CustomDashboardsContext() { }
        public CustomDashboardsContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection) { }

        public DbSet<UserParameters> UserSettings { get; set; }
        public DbSet<CustomDashboard> Dashboards { get; set; }
        public DbSet<Widget> Widgets { get; set; }
    }
}
