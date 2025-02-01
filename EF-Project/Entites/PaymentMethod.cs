using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.Entites
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public List<Vendor> Vendors { get; set; } = new();
    }
}
