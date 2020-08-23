using Marketplace.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Api.Middlewares
{
    public class ResponseExceptionHandler : Controller
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseExceptionHandler> _logger;

        public ResponseExceptionHandler(RequestDelegate next, ILogger<ResponseExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            ResponseViewModel responseError = new ResponseViewModel();

            if (exception is BaseException)
            {
                var ex = exception as BaseException;

                if (ex.Errors != null && ex.Errors.Any())
                {
                    foreach (var error in ex.Errors)
                    {
                        responseError.AddError(error.ErrorMessage, error.ErrorCode);
                    }
                }

                httpContext.Response.StatusCode = ex.StatusCode;
            }
            //else if (exception is HttpException)
            //{
            //    var ex = exception as HttpException;

            //    try
            //    {
            //        ErrorViewModel errorViewModel = JsonConvert.DeserializeObject<ErrorViewModel>(ex.Message);
            //        responseError.AddError(errorViewModel.Message, errorViewModel.Code);
            //        HttpContext.Response.StatusCode = 400;
            //    }
            //    catch (Exception ex)
            //    {
            //        responseError.AddError(ex.Message);
            //        HttpContext.Response.StatusCode = (int)ex.StatusCode;
            //    }
            //}
            else
            {
                _logger.LogError(exception, exception.Message);
                HttpContext.Response.StatusCode = 500;
                responseError.AddError("An unhandled exception has occured");
            }

            httpContext.Response.ContentType = "application/json";
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(responseError, Formatting.Indented));
        }

        public class ResponseViewModel
        {
            public dynamic Data { get; set; }
            public IList<ErrorViewModel> Errors { get; set; } = new List<ErrorViewModel>();

            internal void AddError(string errorMessage, string errorCode = "0")
            {
                var errorViewModel = new ErrorViewModel() { Code = errorCode, Message = errorMessage };
                Errors.Add(errorViewModel);
            }
        }

        public class ErrorViewModel
        {
            public string Code { get; set; }
            public string Message { get; set; }
        }
    }

    public static class ResponseExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseResponseExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseExceptionHandler>();
        }
    }
}
