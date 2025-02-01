using EF_Project.Entites;
using Microsoft.EntityFrameworkCore;

public class PurchasingContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }

    public PurchasingContext(DbContextOptions<PurchasingContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("server=YOUSEF;database=EF;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
        modelBuilder.Entity<OrderItem>().HasKey(oi => oi.ItemId);
        modelBuilder.Entity<Vendor>().HasKey(v => v.VendorId);
        modelBuilder.Entity<PaymentMethod>().HasKey(pm => pm.PaymentMethodId);
    }
}
