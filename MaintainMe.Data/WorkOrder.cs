using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Data
{
    public class WorkOrder
    {
        [Key]
        public int WorkOrderId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public int CarId { get; set; }
        [Required]
        public int CarMileage { get; set; }
        [Required]
        public DateTime WorkOrderDate { get; set; }
        public virtual Car Car { get; set; }
    }
}
