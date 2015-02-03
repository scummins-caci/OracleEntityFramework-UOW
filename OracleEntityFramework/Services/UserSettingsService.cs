using System.Collections.Generic;
using System.Data.Entity;
using OracleEntityFramework.Models;
using OracleEntityFramework.UnitOfWork;

namespace OracleEntityFramework.Services
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly IUserSettingsUOW settingsUOW;

        public UserSettingsService(IUserSettingsUOW settingsUOW)
        {
            this.settingsUOW = settingsUOW;
        }

        #region retrieval methods

        public IEnumerable<Widget> GetAllWidgets()
        {
            return settingsUOW.WidgetRepository.GetAll();
        }

        public IEnumerable<CustomDashboard> GetAllDashboards()
        {
            return settingsUOW.DashboardRepository.GetAll();
        }

        public UserParameters GetUserSettings(int userId)
        {
            return settingsUOW.UserSettingsRepository.GetById(userId);
        }

        public CustomDashboard GetDashboard(int dashboardId)
        {
            return settingsUOW.DashboardRepository.GetById(dashboardId);
        }

        #endregion

        #region CRUD methods

        public int CreateUserSettings(UserParameters userSettings)
        {
            settingsUOW.UserSettingsRepository.Add(userSettings);
            return settingsUOW.Commit();
        }

        public int UpdateUserSettings(UserParameters userSettings)
        {
            settingsUOW.UserSettingsRepository.AttachForUpdate(userSettings);
            settingsUOW.UpdateEntityState(userSettings, EntityState.Modified);
            return settingsUOW.Commit();
        }

        public int CreateDashboard(CustomDashboard dashboard)
        {
            settingsUOW.DashboardRepository.Add(dashboard);
            return settingsUOW.Commit();
        }

        public int UpdateDashboard(CustomDashboard dashboard)
        {
            settingsUOW.DashboardRepository.AttachForUpdate(dashboard);
            settingsUOW.UpdateEntityState(dashboard, EntityState.Modified);
            return settingsUOW.Commit();
        }

        public int DeleteDashboard(CustomDashboard dashboard)
        {
            settingsUOW.DashboardRepository.Delete(dashboard);
            return settingsUOW.Commit();
        }

        #endregion

    }
}
