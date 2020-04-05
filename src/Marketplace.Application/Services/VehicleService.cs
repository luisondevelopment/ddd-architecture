using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Infrastructure.Data.EntityFramework.Contexts;

namespace Marketplace.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly MarketplaceContext _ctx;

        public VehicleService(IVehicleRepository vehicleRepository, MarketplaceContext ctx)
        {
            _vehicleRepository = vehicleRepository;
            _ctx = ctx;
        }

        public void Save(Vehicle vehicle)
        {
            _ctx.Vehicles.Add(vehicle);
            _ctx.SaveChanges();
        }
    }
}
