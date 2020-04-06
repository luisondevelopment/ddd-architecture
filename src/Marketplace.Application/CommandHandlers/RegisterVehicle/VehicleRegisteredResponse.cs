using FluentValidation.Results;
using Marketplace.Domain.Entities.Vehicles;
using System.Collections.Generic;

namespace Marketplace.Application.CommandHandlers
{
    public class VehicleRegisteredResponse : IResponse
    {
        public VehicleRegisteredResponse()
        {
        }

        public VehicleRegisteredResponse(Vehicle vehicle)
        {
            Data = vehicle;
        }

        public dynamic Data { get; set; }
        public IList<ValidationFailure> Errors { get; set; }
    }
}
