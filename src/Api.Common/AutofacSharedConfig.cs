using Autofac;
using Core.SeedWork;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace Api.Common
{
    public abstract class AutofacSharedConfig
    {
        protected readonly IConfiguration Configuration;
        protected readonly IServiceCollection Services;

        protected AutofacSharedConfig(IConfiguration configuration, IServiceCollection services)
        {
            Configuration = configuration;
            Services = services;

            CoreAssembly = Assembly.Load("Infrastructure");
            ImplementationAssembly = Assembly.Load("Infrastructure");
        }

        public Assembly CoreAssembly { get; }

        public Assembly ImplementationAssembly { get; }

        protected IServiceCollection RegisterSharedDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new CoreDependencyModule { ImplementationAssembly = ImplementationAssembly });

            Services.AddMvc();

            // Entity Framework
            ConfigureEntityFramework();

            // Cookie Authentication
            ConfigureAuthentication();

            // MediatR
            ConfigureMediator();

            // Swagger
            ConfigureSwagger();

            return Services;
        }

        protected virtual void ConfigureEntityFramework()
        {
            Services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DataConnection"]));
        }

        protected virtual void ConfigureAuthentication()
        {
            Services.AddAuthentication("ClientApp")
                .AddCookie(options =>
                {
                    //options.LoginPath = "/Account/Unauthorized/";
                    options.SlidingExpiration = true;
                    options.Cookie.Expiration = TimeSpan.FromDays(7);
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = ctx =>
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            return Task.FromResult<object>(null);
                        }
                    };
                });
        }

        protected virtual void ConfigureMediator()
        {
            Services.AddMediatR(CoreAssembly, ImplementationAssembly);
        }

        protected virtual void ConfigureSwagger()
        {
            Services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Client HTTP API",
                    Version = "v1",
                    Description = "The Client Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
            });
        }

        private class CoreDependencyModule : Module
        {
            public Assembly ImplementationAssembly { get; set; }

            protected override void Load(ContainerBuilder builder)
            {
                // Register all repositories implementation. do not register any services unless this
                // registration does not support your scenario.
                builder
                    .RegisterAssemblyTypes(ImplementationAssembly)
                    .Where(type => type.IsClass && typeof(IRepository).IsAssignableFrom(type))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                // Register all business services implementation. do not register any services unless this
                // registration does not support your scenario.
                builder
                    .RegisterAssemblyTypes(ImplementationAssembly)
                    .Where(type => type.IsClass && typeof(IService).IsAssignableFrom(type))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                builder.RegisterType<DataContextSeed>().As<DataContextSeed>().InstancePerDependency();
            }
        }
    }
}