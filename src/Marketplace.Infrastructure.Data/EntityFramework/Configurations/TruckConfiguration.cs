using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Infrastructure.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infrastructure.Data.EntityFramework.Configurations
{
    public class TruckConfiguration : IEntityTypeConfiguration<TruckDb>
    {
        public void Configure(EntityTypeBuilder<TruckDb> builder)
        {
            //builder
            //    .Property(p => p.LicensePlate)
            //    .HasConversion(p => p.ToString(), p => new LicensePlate(p));

            //builder
            //    .Property(p => p.LicensePlate)
            //    .HasConversion(p => p.ToString(), p => new LicensePlate(p));

        }
    }
}
