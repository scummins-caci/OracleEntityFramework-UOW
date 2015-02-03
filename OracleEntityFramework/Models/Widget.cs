using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEntityFramework.Models
{
    public class Widget
    {
        public Widget()
        {
            Dashboards = new HashSet<CustomDashboard>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WidgetID { get; set; }

        [MaxLength(200), Index(IsUnique=true)]
        public string DisplayName { get; set; }

        [MaxLength(200)]
        public string ControlName { get; set; }

        // model links
        public virtual ICollection<CustomDashboard> Dashboards { get; set; }
    }
}
