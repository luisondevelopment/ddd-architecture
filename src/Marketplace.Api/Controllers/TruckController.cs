using Marketplace.Application.CommandHandlers.RegisterVehicle;
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
    public class TruckController : BaseController
    {
        private readonly MarketplaceContext _ctx;
        private readonly IMediator _mediator;

        public TruckController(
            MarketplaceContext ctx,
            IMediator mediator)
        {
            _ctx = ctx;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterTruckCommand command)
        {
            return Response(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("{id}")]
        public TruckDb Get(int id)
        {
            return _ctx.Trucks.FirstOrDefault(x => x.Id == id);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<TruckDb> Delete(int id)
        {
            var truck = _ctx.Trucks.FirstOrDefault(x => x.Id == id);

            _ctx.Trucks.Remove(truck);
            await _ctx.SaveChangesAsync();

            return truck;
        }
    }
}
