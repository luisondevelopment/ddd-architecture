using Marketplace.Infrastructure.Data.DbModels;
using Marketplace.Infrastructure.Data.EntityFramework.Contexts;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    [Route("odata/truck")]
    public class TruckODataController : ODataController
    {
        [HttpGet]
        [EnableQuery]
        public IQueryable<TruckDb> Get([FromServices] MarketplaceContext _ctx)
        {
            return _ctx.Trucks.AsQueryable();
        }
    }
}
