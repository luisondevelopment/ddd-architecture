using Marketplace.Application.CommandHandlers.RegisterVehicle;
using Marketplace.Application.Core;
using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Domain.Interfaces.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.Application.CommandHandlers
{
    public class RegisterTruckHandler : IRequestHandler<RegisterTruckCommand, TruckRegisteredResponse>
    {
        private readonly ITruckUniquenessChecker _truckUniquenessChecker;
        private readonly IVehicleService _vehicleService;
        private readonly IResponse<Truck,TruckRegisteredResponse> _truckRegisteredResponse;

        public RegisterTruckHandler(
            ITruckUniquenessChecker truckUniquenessChecker, 
            IVehicleService vehicleService,
            IResponse<Truck, TruckRegisteredResponse> truckRegisteredResponse)
        {
            _truckUniquenessChecker = truckUniquenessChecker;
            _vehicleService = vehicleService;
            _truckRegisteredResponse = truckRegisteredResponse;
        }

        public async Task<TruckRegisteredResponse> Handle(RegisterTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = new Truck(
                request.Km,
                request.LicensePlate,
                request.Brand,
                request.Model,
                _truckUniquenessChecker);

             _vehicleService.SaveTruck(truck);

            return _truckRegisteredResponse.Create(truck);
        }
    }
}
