using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Infrastructure.Data.DbModels;
using Marketplace.Infrastructure.Data.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Marketplace.Infrastructure.Data.EntityFramework.Contexts
{
    public class MarketplaceContext : DbContext
    {
        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<LicensePlate>();
            modelBuilder.ApplyConfiguration(new TruckConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());

            var Contacts = new List<ContactDb>()
                    {
                        new ContactDb()
                        {
                            Id = 2, Name = "Luis", Phone = "423894389249", TruckId = 1
                        },
                         new ContactDb()
                        {
                            Id = 3, Name = "Luis", Phone = "423894389249", TruckId = 2
                        },
                        new ContactDb()
                        {
                            Id = 4, Name = "Someone", Phone = "563465464564", TruckId = 2
                        },
                        new ContactDb()
                        {
                            Id = 5, Name = "Eric Evans", Phone = "654654646544", TruckId = 2
                        }, new ContactDb()
                        {
                            Id = 6, Name = "Teste", Phone = "423894389249", TruckId = 3
                        },
                        new ContactDb()
                        {
                            Id = 7, Name = "Someone again", Phone = "563465464564", TruckId = 3
                        },
                        new ContactDb()
                        {
                            Id = 8, Name = "Vough Vernon", Phone = "654654646544", TruckId = 3
                        },
                    };

            var trucks = new List<TruckDb>()
            {
                new TruckDb()
                {
                    Id = 1,
                    Km = 30,
                    LicensePlate = "ABC-1234"
                },
                new TruckDb()
                {
                    Id = 2,
                    Km = 32424,
                    LicensePlate = "GHF-5435"
                },
                new TruckDb()
                {
                    Id = 3,
                    Km = 543543543,
                    LicensePlate = "THH-5544"
                },
            };

            //var trucks = new List<TruckDb>()
            //{
            //    new TruckDb()
            //    {
            //        Id = 1,
            //        Km = 30,
            //        LicensePlate = "ABC-1234",
            //        Contacts = new List<ContactDb>()
            //        {
            //            new ContactDb()
            //            {
            //                Id = 2, Name = "Luis", Phone = "423894389249", TruckId = 1
            //            }
            //        }
            //    },
            //    new TruckDb()
            //    {
            //        Id = 2,
            //        Km = 32424,
            //        LicensePlate = "GHF-5435",
            //        Contacts = new List<ContactDb>()
            //        {
            //            new ContactDb()
            //            {
            //                Id = 3, Name = "Luis", Phone = "423894389249", TruckId = 2
            //            },
            //            new ContactDb()
            //            {
            //                Id = 4, Name = "Someone", Phone = "563465464564", TruckId = 2
            //            },
            //            new ContactDb()
            //            {
            //                Id = 5, Name = "Eric Evans", Phone = "654654646544", TruckId = 2
            //            },
            //        }
            //    },
            //    new TruckDb()
            //    {
            //        Id = 3,
            //        Km = 543543543,
            //        LicensePlate = "THH-5544",
            //        Contacts = new List<ContactDb>()
            //        {
            //            new ContactDb()
            //            {
            //                Id = 6, Name = "Teste", Phone = "423894389249", TruckId = 3
            //            },
            //            new ContactDb()
            //            {
            //                Id = 7, Name = "Someone again", Phone = "563465464564", TruckId = 3
            //            },
            //            new ContactDb()
            //            {
            //                Id = 8, Name = "Vough Vernon", Phone = "654654646544", TruckId = 3
            //            },
            //        }
            //    },
            //};

            modelBuilder.Entity<TruckDb>().HasData(trucks);
            modelBuilder.Entity<ContactDb>().HasData(Contacts);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<TruckDb> Trucks { get; set; }
        public DbSet<ContactDb> Contacts { get; set; }
    }
}
