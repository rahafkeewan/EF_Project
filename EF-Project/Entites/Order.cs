using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.Entites
{
    public class Order
    {
        public int OrderId { get; set; }
        public int VendorId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Description { get; set; }
        public Vendor Vendor { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
