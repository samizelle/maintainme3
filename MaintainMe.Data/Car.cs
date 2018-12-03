using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Data
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
    }
}
