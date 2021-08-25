using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Travels.Infrastructure.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection ConfigureServicesSwagger(this IServiceCollection services)
        {
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("WebAPI", new OpenApiInfo
            //    {
            //        Title = "Movies API",
            //        Description = "This is a Web API for Movies operations",
            //        TermsOfService = new Uri("https://udemy.com/user/felipegaviln/"),
            //        License = new OpenApiLicense()
            //        {
            //            Name = "MIT"
            //        },
            //        Contact = new OpenApiContact()
            //        {
            //            Name = "Felipe Gavilán",
            //            Email = "felipe_gavilan887@hotmail.com",
            //            Url = new Uri("https://gavilan.blog/")
            //        }
            //    });
            //   // options.EnableAnnotations();
            //});

            services.AddSwaggerGen();
            services.AddFluentValidationRulesToSwagger();
            services.AddSwaggerGenNewtonsoftSupport();
            return services;
        }
        
        public static IApplicationBuilder ConfigureApplicationSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Travels v1");
            });
            return app;
        }
    }
}
