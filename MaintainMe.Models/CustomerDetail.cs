using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class CustomerDetail
    {
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City St ZipCode")]
        public string CityStZip { get; set; }
    }
}
