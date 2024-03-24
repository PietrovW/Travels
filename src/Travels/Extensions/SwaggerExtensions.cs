using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Travels.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection ConfigureServicesSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API - V1", Version = "v1" });
            options.SwaggerDoc("v2", new OpenApiInfo { Title = "My API - V2", Version = "v2" });
            options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            options.CustomSchemaIds(x => x.FullName);
        });
        return services;
    }
    
    public static IApplicationBuilder ConfigureApplicationSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();// u =>
        //{
           // u.RouteTemplate = "swagger/{documentName}/swagger.json";
       // });
        app.UseSwaggerUI(c =>
        {
           // c.RoutePrefix = "swagger";
            c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Your API Title or Version 1");
            c.SwaggerEndpoint(url: "/swagger/v2/swagger.json", name: "Your API Title or Version 2");
        });
        app.UseReDoc(c =>
        {
            c.PathInMiddlePanel();
            c.OnlyRequiredInSamples();
            c.DocumentTitle = "REDOC API Documentation";
            c.SpecUrl = "/swagger/v1/swagger.json";
        });
        return app;
    }
}
