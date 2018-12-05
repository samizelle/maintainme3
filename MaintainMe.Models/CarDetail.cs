using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class CarDetail
    {
        [Required]
        public int CarId { get; set; }
        public Guid OwnerId { get; set; }
        public int CarOwnerId { get; set; }
        [Display(Name = "Car Make")]
        public string CarMake { get; set; }
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }
    }
}
