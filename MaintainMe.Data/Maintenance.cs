using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Data
{
    public class Maintenance
    {
        [Key]
        public int MaintenanceId { get; set; }
        [Required]
        [Display(Name = "Suggested Maintenance Interval")]
        public int MaintenanceMileage { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Maintenance Description")]
        public string MaintenanceDescription { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
