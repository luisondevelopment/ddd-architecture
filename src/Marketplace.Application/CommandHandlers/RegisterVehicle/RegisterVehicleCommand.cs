using MediatR;

namespace Marketplace.Application.CommandHandlers.RegisterVehicle
{
    public abstract class RegisterVehicleCommand : IRequest<VehicleRegisteredResponse>
    {
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}
