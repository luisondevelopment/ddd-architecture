using Marketplace.Application.CommandHandlers.RegisterVehicle;
using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Domain.Interfaces.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.Application.CommandHandlers
{
    public class RegisterTruckHandler : IRequestHandler<RegisterTruckCommand, VehicleRegisteredResponse>
    {
        private readonly ITruckUniquenessChecker _truckUniquenessChecker;
        private readonly IVehicleService _vehicleService;

        public RegisterTruckHandler(ITruckUniquenessChecker truckUniquenessChecker, IVehicleService vehicleService)
        {
            _truckUniquenessChecker = truckUniquenessChecker;
            _vehicleService = vehicleService;
        }

        public Task<VehicleRegisteredResponse> Handle(RegisterTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = new Truck(
                request.Km,
                request.LicensePlate,
                _truckUniquenessChecker);

             _vehicleService.SaveTruck(truck);

            return Task.FromResult(new VehicleRegisteredResponse(truck));
        }
    }
}
