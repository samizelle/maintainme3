using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;

namespace MaintainMe.Models
{
    public class CarDetail
    {

        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Car Make")]
        public string CarMake { get; set; }
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }
    }
}
