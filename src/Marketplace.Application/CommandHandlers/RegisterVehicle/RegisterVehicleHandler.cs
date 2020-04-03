using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.Application.CommandHandlers
{
    public class RegisterVehicleHandler : IRequestHandler<RegisterVehicleCommand, VehicleRegisteredResponse>
    {
        public Task<VehicleRegisteredResponse> Handle(RegisterVehicleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
