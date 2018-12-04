using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Models
{
    public class CarDetail
    {
        public int CarId { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }

        public override string ToString() => $"[{CarId}] {CarMake} {CarModel}";
    }
}
