using AgriComply.FarmerService.Application.Commands;
using AgriComply.FarmerService.Application.Interfaces;
using AgriComply.FarmerService.Domain.Interfaces;
using AgriComply.FarmerService.Infrastructure.EventBus;
using AgriComply.FarmerService.Infrastructure.Repositories;
using MediatR;
using Carter;
using AgriComply.FarmerService.Application.Handlers;
using AgriComply.FarmerService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AgriComply.FarmService.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Register your repositories

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("YourConnectionStringHere"));

            services.AddScoped<IFarmerRepository, FarmerRepository>();
            services.AddScoped<IEventBus, InMemoryEventBus>();

            // Register your application services
            services.AddScoped<IFarmerService, AgriComply.FarmerService.Application.Services.FarmerService>();

            // Register MediatR for handling commands
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateFarmerCommand>());
            services.AddCarter(); // Register Carter for minimal APIs

            // Register command handler
            services.AddScoped<IRequestHandler<CreateFarmerCommand, Unit>, CreateFarmerCommandHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Middleware configuration
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting(); // Ensure routing is enabled

            // Map Carter modules
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapCarter(); // This is the correct usage for .NET 6 and later
            });
        }
    }
}
