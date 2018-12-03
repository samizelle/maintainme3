using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Data
{
    public class ServiceEvent
    {
        [Key]
        public int ServiceId { get; set; }
        public int CarId { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public DateTime ServiceDate { get; set; }
    }
}
