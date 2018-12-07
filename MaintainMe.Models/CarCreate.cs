using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class CarCreate
    {
        [Required]
        [Display(Name = "Car Owner ID")]
        public int CarOwnerId { get; set; }
        public string FullName { get; set; }
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
    }
}
