using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using HighView.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OracleEntityFramework.Context;
using OracleEntityFramework.Models;
using OracleEntityFramework.Services;
using OracleEntityFramework.UnitOfWork;

namespace OracleEntityFramework.Tests
{
    [TestClass]
    public class UserSettingsServiceTest
    {
        private IUserSettingsService service;

        [TestInitialize]
        public void Initialize()
        {
            var context = new CustomDashboardsContext();
            var uow = new UserSettingsUOW(context);
            service = new UserSettingsService(uow);
        }


        [TestMethod]
        public void GetAllWidgets_Test()
        {
            var widgets = service.GetAllWidgets();
            Assert.IsTrue(widgets.Any());
        }

        [TestMethod]
        public void CreateDashboard_Test()
        {
            var widgets = service.GetAllWidgets();

            var newDash = new CustomDashboard
            {
                CreatedBy = 1,
                DateCreated = DateTime.Now,
                Name = "Custom Dash 2",
                IsPublic = true,
                Widgets = widgets.ToList()
            };

            var result = service.CreateDashboard(newDash);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CreateDashboardAndWidgets_Test()
        {
            var newDash = new CustomDashboard
            {
                CreatedBy = 4,
                DateCreated = DateTime.Now,
                Name = "New Dash",
                IsPublic = false,
                Widgets = new List<Widget>
                {
                    new Widget
                    {
                        ControlName = "Widget1.cshtml",
                        DisplayName = "Widget 1"
                    },
                    new Widget
                    {
                        ControlName = "Widget2.cshtml",
                        DisplayName = "Widget 2"
                    },
                    new Widget
                    {
                        ControlName = "Widget3.cshtml",
                        DisplayName = "Widget 3"
                    }
                }
            };

            var result = service.CreateDashboard(newDash);
            Assert.IsTrue(result > 0);
        }



        [TestMethod]
        public void CreateSomeUserSettings_Test()
        {
            var dash1 = service.GetDashboard(1);
            var dash2 = service.GetDashboard(2);

            var userSettings = new UserParameters
            {
                Dashboards = new[] { dash1, dash2 },
                UserID = 5
            };

            var userSettings2 = new UserParameters
            {
                Dashboards = new[] { dash1, dash2 },
                UserID = 4
            };

            var userSettings3 = new UserParameters
            {
                Dashboards = new[] { dash2 },
                UserID = 6
            };

            var result = service.CreateUserSettings(userSettings);
            Assert.IsTrue(result > 0);

        }

        [TestMethod]
        public void GetDashboard_Test()
        {
            var dash = service.GetDashboard(1);
            Assert.IsNotNull(dash);
        }

        [TestMethod]
        public void UpdateDashboard_Test()
        {
            var dash = service.GetDashboard(1);
            dash.Name = "Updated Dash";

            var result = service.UpdateDashboard(dash);
            Assert.IsTrue(result > 0);

        }

        [TestMethod]
        public void HighViewConnection_Test()
        {
            var connectString = ConfigurationManager.AppSettings["AuthenticationConnectString"];
            WinModule.Initialize();
            WinModule.CreateNewSession(connectString, "test", "test");



            var connection = Session.GetSession().OpenConnection();

            var context = new CustomDashboardsContext(connection, false);
            var uow = new UserSettingsUOW(context);
            var hvService = new UserSettingsService(uow);


            var widgets = hvService.GetAllWidgets();
            Assert.IsTrue(widgets.Any());
        }
    }
}
