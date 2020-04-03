using MediatR;

namespace Marketplace.Application.CommandHandlers
{
    public class RegisterVehicleCommand : IRequest<VehicleRegisteredResponse>
    {
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}
