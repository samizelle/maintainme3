﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    class CustomerCarListItem
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public List<CarListItem>Cars { get; set; }
    }
}