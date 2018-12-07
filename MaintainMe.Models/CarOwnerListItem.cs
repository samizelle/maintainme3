﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class CarOwnerListItem
    {
        [Display(Name = "Car Owner ID")]
        public int CarOwnerId { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [Display(Name = "City St ZipCode")]
        public string CityStZip { get; set; }
    }
}
