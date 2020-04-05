using Marketplace.Domain.Entities.Vehicles;

namespace Marketplace.Domain.Interfaces.Services
{
    public interface IVehicleService
    {
        void Save(Vehicle vehicle);
    }
}
