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
        [Display(Name = "Car Owner ID")]
        public int CarOwnerId { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "Car Make")]
        public string CarMake { get; set; }
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }
    }
}
