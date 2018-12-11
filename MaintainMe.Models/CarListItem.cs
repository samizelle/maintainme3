using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;

namespace MaintainMe.Models
{
    public class CarListItem
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerLastName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }

    }
}
