using FluentValidation;
using Marketplace.Application.CommandHandlers;
using Marketplace.Application.PipelineBehaviors;
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
            services.AddMediatR(AppDomain.CurrentDomain.Load("Marketplace.Application"));
            services.AddTransient<RegisterVehicleHandler>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("Marketplace.Application"));
        }
    }
}
