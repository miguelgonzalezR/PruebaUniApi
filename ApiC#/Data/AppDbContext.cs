using Microsoft.EntityFrameworkCore;
using ApiC_.Models;

namespace ApiC_.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }

    }
}
