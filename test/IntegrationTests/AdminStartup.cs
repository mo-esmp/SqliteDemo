using Api.Admin;
using Api.Common;
using Api.Common.Middlewares;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IntegrationTests
{
    public class AdminStartup
    {
        public AdminStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IApplicationBuilder ApplicationBuilder { get; private set; }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var (container, serviceProvider) = new AutofacAdminConfig(Configuration, services).RegisterDependencies();
            ApplicationContainer = container;

            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            ApplicationBuilder = app;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandling();

            app.UseMvcWithDefaultRoute();

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
                c.ConfigureOAuth2("basketswaggerui", "", "", "Basket Swagger UI");
            });

            applicationLifetime.ApplicationStarted.Register(SeedDataAsync);
        }

        private void SeedDataAsync()
        {
            if (bool.Parse(Configuration["SeedData"]) == false)
                return;

            var context = (DataContext)ApplicationBuilder.ApplicationServices.GetService(typeof(DataContext));
            context.Database.EnsureCreated();
            //context.Database.Migrate();

            var contextSeed = (DataContextSeed)ApplicationBuilder.ApplicationServices.GetService(typeof(DataContextSeed));

            var task = contextSeed.SeedAsync();
            task.Wait();
        }
    }

    internal class AutofacAdminConfig : AutofacSharedConfig
    {
        public AutofacAdminConfig(IConfiguration configuration, IServiceCollection services)
            : base(configuration, services)
        {
        }

        public (IContainer, IServiceProvider) RegisterDependencies()
        {
            var containerBuilder = new ContainerBuilder();

            var services = RegisterSharedDependencies(containerBuilder);

            services.AddAutoMapper(typeof(Startup));

            // read service collection to Autofac
            containerBuilder.Populate(services);

            // build the Autofac container
            var container = containerBuilder.Build();

            // creating the IServiceProvider out of the Autofac container
            var serviceProvider = new AutofacServiceProvider(container);

            return (container, serviceProvider);
        }

        protected override void ConfigureEntityFramework()
        {
            Services.AddDbContext<DataContext>(options =>
            {
                var liteConn = new SqliteConnection(Configuration["ConnectionStrings:DataConnection"]);
                liteConn.Open();

                options
                    .UseSqlite(liteConn)
                    .ConfigureWarnings(warnings =>
                    {
                        warnings.Throw(RelationalEventId.QueryClientEvaluationWarning);
                    });
            }, ServiceLifetime.Singleton);
        }
    }
}