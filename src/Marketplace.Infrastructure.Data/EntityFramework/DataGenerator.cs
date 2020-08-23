using Marketplace.Infrastructure.Data.DbModels;
using Marketplace.Infrastructure.Data.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Marketplace.Infrastructure.Data.EntityFramework
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MarketplaceContext(
                serviceProvider.GetRequiredService<DbContextOptions<MarketplaceContext>>()))
            {
                context.Trucks.AddRange(
                      new TruckDb()
                      {
                          Id = 1,
                          Km = 30,
                          LicensePlate = "ABC-1234",
                          Offers = new List<OfferDb>()
                          {
                             new OfferDb() { Value = 5, TruckId = 1 },
                             new OfferDb() { Value = 10, TruckId = 1 }
                          }
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
                    });

                context.Contacts.AddRange(

                        new ContactDb()
                        {
                            Id = 2,
                            Name = "Luis",
                            Phone = "423894389249",
                            TruckId = 1
                        },
                         new ContactDb()
                         {
                             Id = 3,
                             Name = "Luis",
                             Phone = "423894389249",
                             TruckId = 2
                         },
                        new ContactDb()
                        {
                            Id = 4,
                            Name = "Someone",
                            Phone = "563465464564",
                            TruckId = 2
                        },
                        new ContactDb()
                        {
                            Id = 5,
                            Name = "Eric Evans",
                            Phone = "654654646544",
                            TruckId = 2
                        }, new ContactDb()
                        {
                            Id = 6,
                            Name = "Teste",
                            Phone = "423894389249",
                            TruckId = 3
                        },
                        new ContactDb()
                        {
                            Id = 7,
                            Name = "Someone again",
                            Phone = "563465464564",
                            TruckId = 3
                        },
                        new ContactDb()
                        {
                            Id = 8,
                            Name = "Vough Vernon",
                            Phone = "654654646544",
                            TruckId = 3
                        });

                context.SaveChanges();
            }
        }
    }

}
