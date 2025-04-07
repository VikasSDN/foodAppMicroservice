using Microsoft.EntityFrameworkCore;
using RestaurantService.Model;

namespace RestaurantService.Context
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }
    }
}
