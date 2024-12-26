using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApiTask.Model.Models
{
    public class Order: AuditableEntity
    {
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal TotalPrice { get; set; }
    }
}
