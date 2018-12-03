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
        public string Make { get; set; }
        public string Model { get; set; }
        public override string ToString() => $"[{CarId}] {Make} {Model}";
    }
}
