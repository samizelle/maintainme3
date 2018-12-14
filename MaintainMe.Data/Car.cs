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
        public int CustomerId { get; set; }
        [Required]
        public string CarMake { get; set; }
        [Required]
        public string CarModel { get; set; }

        public virtual Customer Customer  { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

    }
}
