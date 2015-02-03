using System;
using System.Data.Entity;
using OracleEntityFramework.Models;
using OracleEntityFramework.Repositories;

namespace OracleEntityFramework.UnitOfWork
{
    public interface IUserSettingsUOW : IDisposable
    {
        IEFRepository<Widget> WidgetRepository { get; }
        IEFRepository<CustomDashboard> DashboardRepository { get; }
        IEFRepository<UserParameters> UserSettingsRepository { get; }

        void UpdateEntityState<TEntity>(TEntity entity, EntityState state);
        int Commit();
    }

}
