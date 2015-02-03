using System.Collections.Generic;
using OracleEntityFramework.Models;

namespace OracleEntityFramework.Services
{
    public interface IUserSettingsService
    {
        IEnumerable<Widget> GetAllWidgets();
        IEnumerable<CustomDashboard> GetAllDashboards();

        UserParameters GetUserSettings(int userId);
        CustomDashboard GetDashboard(int dashboardId);

        int CreateUserSettings(UserParameters userSettings);
        int UpdateUserSettings(UserParameters userSettings);

        int CreateDashboard(CustomDashboard dashboard);
        int UpdateDashboard(CustomDashboard dashboard);
        int DeleteDashboard(CustomDashboard dashboard);

    }
}
