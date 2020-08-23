using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Marketplace.Domain.Core.Exceptions
{
    public class BusinessException : BaseException
    {
        public new const int StatusCode = 400;

        public BusinessException(IList<ValidationFailure> errors) : base(StatusCode, errors)
        {

        }

        public BusinessException(string propertyName, Enum errorType) : base(StatusCode, propertyName, errorType)
        {

        }
    }
}
