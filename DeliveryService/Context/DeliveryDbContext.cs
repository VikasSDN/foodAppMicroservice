using DeliveryService.Model;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Context
{
    public class DeliveryDbContext : DbContext
    {
        public DbSet<DeliveryPartner> DeliveryPartners { get; set; }

        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options) { }
    }
}
