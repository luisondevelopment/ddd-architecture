using Marketplace.Domain.Core.Entities;
using System.Collections.Generic;

namespace Marketplace.Infrastructure.Data.DbModels
{
    public class TruckDb : DbEntity
    {
        public int Km { get; set; }
        public string LicensePlate { get; set; }
        public List<ContactDb> Contacts { get; set; }
        public List<OfferDb> Offers { get; set; }
    }
}
