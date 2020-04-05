using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Infrastructure.Data.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Data.EntityFramework.Contexts
{
    public class MarketplaceContext : DbContext
    {
        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<LicensePlate>();
            modelBuilder.ApplyConfiguration(new TruckConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Truck> Trucks { get; set; }
    }
}
