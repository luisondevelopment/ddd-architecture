using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Infrastructure.Data.DbModels;
using Marketplace.Infrastructure.Data.EntityFramework.Contexts;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ODataController
    {
        private readonly MarketplaceContext _ctx;

        public TruckController(MarketplaceContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<TruckDb> Get()
        {
            return _ctx.Trucks.AsQueryable();
        }
    }
}
