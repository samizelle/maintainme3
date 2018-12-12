using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;

namespace MaintainMe.Models
{
    public class WorkOrderDetailModel
    {
        public int WorkOrderId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerLastName { get; set; }
        [Display(Name = "Car Mileage")]
        public int CarMileage { get; set; }
        public string WorkOrderDetail { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Work Order Date")]
        public DateTime WorkOrderDate { get; set; }
    }
}
