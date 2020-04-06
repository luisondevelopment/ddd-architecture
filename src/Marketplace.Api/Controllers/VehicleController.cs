using Marketplace.Application.CommandHandlers.RegisterVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : BaseController
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("truck")]
        public async Task<IActionResult> Post(RegisterTruckCommand command)
        {
            return Response(await _mediator.Send(command));
        }
    }
}
