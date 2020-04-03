using FluentValidation.Results;
using System.Collections.Generic;

namespace Marketplace.Application.CommandHandlers
{
    public class VehicleRegisteredResponse : IResponse
    {
        public int Id { get; set; }
        public IList<ValidationFailure> Errors { get; set; }
    }
}
