using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class CarEdit
    {
        public int CarId { get; set; }
        public int CarOwnerId { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
    }
}
