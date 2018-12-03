using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class MaintenanceCreate
    {
        [Required]
        [Display(Name = "Suggested Maintenance Interval")]
        public int MaintenanceMileage { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Maintenance Description")]
        public string MaintenanceDescription { get; set; }

        public override string ToString() => MaintenanceDescription;
    }
}
