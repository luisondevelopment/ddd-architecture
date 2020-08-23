using MediatR;

namespace Marketplace.Application.CommandHandlers.RegisterVehicle
{
    public class RegisterTruckCommand : IRequest<TruckRegisteredResponse>
    {
        public int Km { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string LicensePlate { get; set; }
    }
}
