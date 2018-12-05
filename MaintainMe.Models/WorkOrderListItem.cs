using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class WorkOrderListItem
    {
        [Key]
        [Display(Name = "Work Order ID")]
        public int WorkOrderId { get; set; }
        [Display(Name = "Owner ID")]
        public Guid OwnerId { get; set; }
        [Display(Name = "Car ID")]
        public int CarId { get; set; }
        [Display(Name = "Car Mileage")]
        public int CarMileage { get; set; }
        [Display(Name = "WO Detail")]
        [MinLength(2)]
        [MaxLength(100, ErrorMessage = "Max 100 characters")]
        public string WorkOrderDetail { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "WO Date")]
        public DateTime WorkOrderDate { get; set; }
    }
}
