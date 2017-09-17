using Api.Common;
using Api.Common.Middlewares;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Admin

{
    public class AutofacConfig : AutofacSharedConfig
    {
        public AutofacConfig(IConfiguration configuration, IServiceCollection services)
            : base(configuration, services)
        {
        }

        public (IContainer, IServiceProvider) RegisterDependencies()
        {
            var containerBuilder = new ContainerBuilder();

            var services = RegisterSharedDependencies(containerBuilder);

            services.AddAutoMapper(typeof(Startup), typeof(MiddlewareExtensions));

            // read service collection to Autofac
            containerBuilder.Populate(services);

            // build the Autofac container
            var container = containerBuilder.Build();

            // creating the IServiceProvider out of the Autofac container
            var serviceProvider = new AutofacServiceProvider(container);

            return (container, serviceProvider);
        }
    }
}