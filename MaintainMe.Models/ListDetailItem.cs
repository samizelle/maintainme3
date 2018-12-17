using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class ListDetailItem
    {
        public int CustomerId { get; set; }
        //public string CarMake { get; set; }
        //public string CarModel { get; set; }

        public List<CustomerCarListItem> car { get; set; }
    }
}
