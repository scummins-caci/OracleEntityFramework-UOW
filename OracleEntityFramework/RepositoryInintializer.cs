using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleEntityFramework.Context;
using OracleEntityFramework.Models;

namespace OracleEntityFramework
{
    public class RepositoryInintializer : DropCreateDatabaseAlways<CustomDashboardsContext>
    {
        protected override void Seed(CustomDashboardsContext context)
        {
            var widgets = new List<Widget>
            {
                new Widget
                {
                    DisplayName = "Test Widget One",
                    ControlName = "TestWidgetOne.cshtml"
                },
                new Widget
                {
                    DisplayName = "Test Widget Two",
                    ControlName = "TestWidgetTwo.cshtml"
                },
                new Widget
                {
                    DisplayName = "Test Widget Three",
                    ControlName = "TestWidgetThree.cshtml"
                }
            };

            widgets.ForEach(w => context.Widgets.Add(w));
            context.SaveChanges();

            base.Seed(context);
        }

    }
}
