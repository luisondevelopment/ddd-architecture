using Marketplace.Application.Services;
using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Infrastructure.Data.EntityFramework.Contexts;
using System.Linq;

namespace Marketplace.Domain.Interfaces.Services
{
    public class TruckUniquenessChecker : UniquenessChecker<Truck>, ITruckUniquenessChecker
    {
        private readonly MarketplaceContext _context;

        public TruckUniquenessChecker(MarketplaceContext db) : base(db)
        {
            _context = db;
        }

        public bool IsLicensePlateUnique(string licensePlate)
        {
            var trucks = _context.Trucks;
            var vehicles = _context.Vehicles.ToList();

            return !_context.Trucks.Any(x => x.LicensePlate == licensePlate);
        }
    }
}
