using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;

namespace MaintainMe.Models
{
    public class CarCreate
    {
        [Required]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Car Make")]
        [MinLength(2, ErrorMessage ="Please enter at least two characters")]
        [MaxLength(25, ErrorMessage ="Make can be no longer than 25 characters")]
        public string CarMake { get; set; }
        [Required]
        [Display(Name = "Car Model")]
        [MinLength(2, ErrorMessage = "Please enter at least two characters")]
        [MaxLength(25, ErrorMessage = "Model can be no longer than 25 characters")]
        public string CarModel { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

    }
}
