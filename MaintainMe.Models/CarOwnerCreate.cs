using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class CarOwnerCreate
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [MaxLength(35)]
        public string Address { get; set; }
        [MaxLength(35)]
        [Display(Name = "City St ZipCode")]
        public string CityStZip { get; set; }
    }
}
