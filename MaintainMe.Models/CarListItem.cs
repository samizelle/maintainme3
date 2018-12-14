using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;

namespace MaintainMe.Models
{
    public class CarListItem
    {
        [Display(Name = "Car ID")]
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerLastName { get; set; }
        [Display(Name = "Car Make")]
        public string CarMake { get; set; }
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
