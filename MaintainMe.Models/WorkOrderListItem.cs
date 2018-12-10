using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;

namespace MaintainMe.Models
{
    public class WorkOrderListItem
    {
        [Display(Name = "Work Order ID")]
        public int WorkOrderId { get; set; }

        [Display(Name = "Car ID")]
        public int CarId { get; set; }

        [Display(Name = "Car Mileage")]
        public int CarMileage { get; set; }

        public string CustomerLastName { get; set; }


        public WorkOrderDetail WorkOrderDetail { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "WO Date")]
        public DateTime WorkOrderDate { get; set; }

    }
}
