using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Travels.Core.Entities;
using Travels.Core.Interfaces;
using Travels.Infrastructure.Data;
using Travels.Infrastructure.Extensions;
using Travels.Infrastructure.Repositories;

namespace Travels
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
            services.AddControllers().AddFluentValidation(c =>
            {
                c.RegisterValidatorsFromAssemblyContaining<Startup>();
                c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
            });
            services.AddDbContext<TravelsContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddOptions();
            services.AddTransient<ITravelRepository, TravelRepository>();
            services.AddHttpContextAccessor();
            services.ConfigureServicesVersion();
            services.ConfigureServicesSwagger();
            services.ConfigureServicesMediator();
            services.ConfigureServicesAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseErrorHandler();
            
            app.ConfigureApplicationSwagger();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
