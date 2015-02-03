using System.Data.Entity;
using OracleEntityFramework.Context;
using OracleEntityFramework.Models;
using OracleEntityFramework.Repositories;

namespace OracleEntityFramework.UnitOfWork
{
    public class UserSettingsUOW: IUserSettingsUOW
    {
        private readonly IEFRepository<Widget> widgetRepository;
        private readonly IEFRepository<CustomDashboard> dashboardRepository;
        private readonly IEFRepository<UserParameters> userSettingsRepository;
        private readonly ISettingsEFContext context;


        public UserSettingsUOW(ISettingsEFContext context)
        {
            widgetRepository = new EFRepository<Widget>(context.Widgets);
            dashboardRepository = new EFRepository<CustomDashboard>(context.Dashboards);
            userSettingsRepository = new EFRepository<UserParameters>(context.UserSettings);
            this.context = context;
        }


        public void Dispose()
        {
            context.Dispose();
        }

        public IEFRepository<Widget> WidgetRepository
        {
            get { return widgetRepository; }
        }

        public IEFRepository<CustomDashboard> DashboardRepository
        {
            get { return dashboardRepository; }
        }

        public IEFRepository<UserParameters> UserSettingsRepository
        {
            get { return userSettingsRepository; }
        }

        public void UpdateEntityState<TEntity>(TEntity entity, EntityState state)
        {
            context.Entry(entity).State = state;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
