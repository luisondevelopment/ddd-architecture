using FluentValidation.Results;
using Marketplace.Domain.Entities.Vehicles;
using System.Collections.Generic;

namespace Marketplace.Application.CommandHandlers
{
    public class VehicleRegisteredResponse : IResponse
    {
        public VehicleRegisteredResponse(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public Vehicle Vehicle { get; set; }
        public IList<ValidationFailure> Errors { get; set; }
    }
}
