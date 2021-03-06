﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public Guid OwnerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CityStZip { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
