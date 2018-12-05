﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Data
{
    public class CarOwner
    {
        [Key]
        public int CarOwnerId { get; set; }
        public Guid OwnerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CityStZip { get; set; }

        public string FullName => FirstName + " " + LastName; 

        public virtual ICollection<Car> Cars { get; set; }
    }
}
