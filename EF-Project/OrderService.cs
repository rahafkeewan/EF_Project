using EF_Project.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EF_Project
{
    public class OrderService
    {
        private readonly PurchasingContext _context;

        public OrderService(PurchasingContext context)
        {
            _context = context;
        }

        public void PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void AddItemToOrder(int orderId, OrderItem item)
        {
            _context.OrderItems.Add(item);
            _context.SaveChanges();
        }
    }
}
