using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OracleEntityFramework.Models;

namespace OracleEntityFramework.Context
{
    public interface ISettingsEFContext
    {
        DbSet<UserParameters> UserSettings { get; set; }
        DbSet<CustomDashboard> Dashboards { get; set; }
        DbSet<Widget> Widgets { get; set; }
        int SaveChanges();

        DbEntityEntry Entry(object entity);
        void Dispose();
    }
}
