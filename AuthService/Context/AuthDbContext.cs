using AuthService.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Context
{
    public class AuthDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
    }
}
