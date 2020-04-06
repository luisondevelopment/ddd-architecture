using Marketplace.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public new IActionResult Response(IResponse response)
        {
            if (response.Errors == null || !response.Errors.Any())
            {
                try
                {
                    return Ok(new
                    {
                        response.Data
                    });
                }
                catch
                {
                    return BadRequest(new
                    {
                        errors = new[] { "Internal Server Error." }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    errors = response.Errors
                });
            }
        }
    }
}
