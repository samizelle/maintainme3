using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;

namespace MaintainMe.Models
{
    public class CustomerListItem
    {
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [Display(Name = "City St ZipCode")]
        public string CityStZip { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
