using Marketplace.Api.Configuration;
using Marketplace.Api.Middlewares;
using Marketplace.Infrastructure.Data.DbModels;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using System.Linq;

namespace Marketplace.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Setting DbContext
            services.AddDatabaseSetup(Configuration);

            // WebApi config
            services.AddControllers().AddNewtonsoftJson();

            // Swagger setup
            services.AddSwaggerSetup();

            // Register services
            services.AddDependencyInjectionSetup(Configuration);

            // OData
            services.AddOData();

            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<OutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }

                foreach (var inputFormatter in options.InputFormatters.OfType<InputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseResponseExceptionHandler();

            // Swagger setup
            app.UseSwaggerSetup();
            app.UseODataBatching();
            app.UseEndpoints(endpoints =>
            {
                endpoints.EnableDependencyInjection();
                endpoints.MapControllers();
                endpoints.Expand().Select().OrderBy().Filter();
                endpoints.MapODataRoute("ODataRoute", "api", GetEdmModel());
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<TruckDb>("Trucks");
            builder.EntitySet<ContactDb>("Contacts");
            builder.EntitySet<ContactDb>("Offers");
            return builder.GetEdmModel();
        }
    }
}
