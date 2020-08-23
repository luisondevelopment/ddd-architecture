using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public new IActionResult Response(object response)
        {
            try
            {
                return Ok(new
                {
                    Data = response
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
    }
}
