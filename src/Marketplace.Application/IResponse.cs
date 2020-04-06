﻿using FluentValidation.Results;
using System.Collections.Generic;

namespace Marketplace.Application
{
    public interface IResponse
    {
        dynamic Data { get; set; }

        public IList<ValidationFailure> Errors { get; set; }
    }
}
