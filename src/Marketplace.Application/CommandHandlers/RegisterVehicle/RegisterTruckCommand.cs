using MediatR;

namespace Marketplace.Application.CommandHandlers.RegisterVehicle
{
    public class RegisterTruckCommand : RegisterVehicleCommand, IRequest<VehicleRegisteredResponse>
    {
        public int Km { get; set; }
        public string LicensePlate { get; set; }
    }
}
