using FluentValidation.Results;
using System.Collections.Generic;

namespace Marketplace.Application
{
    public class Response<T>
    {
        public Response(T data)
        {
            Data = data;
        }

        public IList<ValidationFailure> Errors { get; set; }
        public T Data { get; set; }
    }
}
