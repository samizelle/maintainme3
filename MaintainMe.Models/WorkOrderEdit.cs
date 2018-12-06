using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class WorkOrderEdit
    {
        public int WorkOrderId { get; set; }
        public int CarId { get; set; }
        [Display(Name = "Car Mileage")]
        public int CarMileage { get; set; }
        [Display(Name = "Work Order Detail")]
        [MinLength(2)]
        [MaxLength(100, ErrorMessage = "Max 100 characters")]
        public string WorkOrderDetail { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Work Order Date")]
        public DateTime WorkOrderDate { get; set; }
    }
}
