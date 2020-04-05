using FluentValidation;
using Marketplace.Application.PipelineBehaviors;
using Marketplace.Application.Services;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarketPlace.IoC
{
    public class NativeInjectorBootstraper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // MediatR setup
            services.AddMediatR(AppDomain.CurrentDomain.Load("Marketplace.Application"));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            
            // Fluent Validator setup
            services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("Marketplace.Application"));
            
            //Vehicle
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();

            // Truck
            services.AddTransient<ITruckUniquenessChecker, TruckUniquenessChecker>();
        }
    }
}
 