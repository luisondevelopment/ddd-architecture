using FluentValidation.Results;
using System.Collections.Generic;

namespace Marketplace.Application
{
    public interface IResponse
    {
        IList<ValidationFailure> Errors { get; set; }
    }
}
