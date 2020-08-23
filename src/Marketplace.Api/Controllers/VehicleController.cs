using Marketplace.Application.CommandHandlers.RegisterVehicle;
using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Infrastructure.Data.DbModels;
using Marketplace.Infrastructure.Data.EntityFramework.Contexts;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly MarketplaceContext _ctx;

        public VehicleController(IMediator mediator, MarketplaceContext ctx)
        {
            _mediator = mediator;
            _ctx = ctx;
        }

        [HttpPost]
        [Route("truck")]
        public async Task<IActionResult> Post(RegisterTruckCommand command)
        {
            return Response(await _mediator.Send(command));
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<TruckDb> Get()
        {
            return _ctx.Trucks.AsQueryable();
        }
    }
}
