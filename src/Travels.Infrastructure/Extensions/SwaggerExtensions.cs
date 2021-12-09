using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Travels.Infrastructure.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection ConfigureServicesSwagger(this IServiceCollection services)
        {
            
            services.AddFluentValidationRulesToSwagger();
            services.AddSwaggerGenNewtonsoftSupport();
            return services;
        }
        
        public static IApplicationBuilder ConfigureApplicationSwagger(this IApplicationBuilder app)
        {
            app.UseReDoc(c =>
            {
                c.PathInMiddlePanel();
                c.OnlyRequiredInSamples();
                c.DocumentTitle = "REDOC API Documentation";
                c.SpecUrl = "/swagger/v1/swagger.json";
               
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });

            return app;
        }
    }
}
