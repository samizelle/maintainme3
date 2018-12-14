using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Data
{
    public enum WorkOrderDetail { [Display(Name="Oil Change")] Oil_Change,
        [Display(Name="Air Filter")] Air_Filter,
        [Display(Name = "Windshield Wipers")] Windshield_Wipers,
        [Display(Name = "Brake Service")] Brake_Service,
        [Display(Name = "Fuel Filter")] Fuel_Filter,
        Battery }

    public class WorkOrder
    {
        [Key]
        public int WorkOrderId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int CarMileage { get; set; }

        [Required]
        public string WorkOrderDetail { get; set; }

        [Required]
        public DateTime WorkOrderDate { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customers { get; set; }

    }
}
