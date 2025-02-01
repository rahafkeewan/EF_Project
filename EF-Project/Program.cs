using EF_Project;
using EF_Project.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<PurchasingContext>(options =>
                options.UseSqlServer("Your_Connection_String"))
            .AddTransient<OrderService>()
            .AddTransient<LinqQueries>()
            .BuildServiceProvider();

        var orderService = serviceProvider.GetRequiredService<OrderService>();
        var linqQueries = serviceProvider.GetRequiredService<LinqQueries>();

        Console.WriteLine("بدء التنفيذ...");

        var newOrder = new Order
        {
            OrderDate = DateTime.UtcNow,
            VendorId = 1,
            Description = "طلب شراء أولي"
        };
        orderService.PlaceOrder(newOrder);
        Console.WriteLine("تم إنشاء الطلب الجديد.");

        var orderItem = new OrderItem
        {
            OrderId = newOrder.OrderId,
            ItemId = 101,
            ItemCode = "ITEM123",
            ItemName = "منتج تجريبي",
            Unit = "قطعة",
            Quantity = 5,
            Price = 10.50m,
            CostAmount = 5 * 10.50m
        };
        orderService.AddItemToOrder(newOrder.OrderId, orderItem);
        Console.WriteLine("تمت إضافة عنصر إلى الطلب.");

        Console.WriteLine("عرض الموظفين مع أقسامهم:");
        linqQueries.ListEmployeesWithDepartments();

        Console.WriteLine("التنفيذ انتهى.");
    }
}