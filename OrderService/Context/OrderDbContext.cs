using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.Context
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
    }
}
