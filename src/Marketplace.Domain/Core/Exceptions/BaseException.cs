using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Marketplace.Domain.Core.Exceptions
{
    public class BaseException : Exception
    {
        public int StatusCode { get; set; }
        public IList<ValidationFailure> Errors { get; set; }

        public BaseException(int statusCode, IList<ValidationFailure> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        public BaseException(int statusCode, string propertyName, Enum @enum)
        {
            string description = "Todo";
            string errorCode = Convert.ToInt32(@enum).ToString();

            StatusCode = statusCode;

            Errors = new List<ValidationFailure>
            {
                new ValidationFailure(propertyName, description) {ErrorCode = errorCode}
            };
        }
    }
}

