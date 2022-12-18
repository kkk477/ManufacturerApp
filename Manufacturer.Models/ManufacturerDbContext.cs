using Microsoft.EntityFrameworkCore;

namespace Manufacturer.Models
{
    public class ManufacturerDbContext : DbContext
    {
        public ManufacturerDbContext()
        {

        }

        public ManufacturerDbContext(DbContextOptions<ManufacturerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }

        public DbSet<Manufacturer> manufacturers { get; set; }
    }
}
