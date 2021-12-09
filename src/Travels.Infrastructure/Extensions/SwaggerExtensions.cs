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

            //app.UseSwagger(c =>
            //{
            //    c.SerializeAsV2 = true;
            //    c.PreSerializeFilters.Add((swagger, httpReq) =>
            //    {
            //        swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
            //    });
            //});
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("v1/swagger.json", "My API V1");
            //    //      options.SwaggerEndpoint("/swagger/1.0/swagger.json", "Travels v1");
            //});
            return app;
        }
    }
}
