using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Travels.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection ConfigureServicesSwagger(this IServiceCollection services)
    {
        services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(options =>
        {
            options.OperationFilter<SwaggerDefaultValues>();
            options.SwaggerDoc("v1", new OpenApiInfo() { Title = "API V1", Version = "v1.0" });
            options.SwaggerDoc("v2", new OpenApiInfo() { Title = "API V2", Version = "v2.0" });
            options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            options.CustomSchemaIds(x => x.FullName);
        });
        return services;
    }
    
    public static IApplicationBuilder ConfigureApplicationSwagger(this ApplicationBuilder app)
    {
        app.UseSwagger();// u =>
                         //{
                         // u.RouteTemplate = "swagger/{documentName}/swagger.json";
                         // });
        //app.UseSwaggerUI(options =>
        //{
        //    var descriptions = app.DescribeApiVersions();

        //    // Build a swagger endpoint for each discovered API version
        //    foreach (var description in descriptions)
        //    {
        //        var url = $"/swagger/{description.GroupName}/swagger.json";
        //        var name = description.GroupName.ToUpperInvariant();
        //        options.SwaggerEndpoint(url, name);
        //    }
        //});
    
        //app.UseReDoc(c =>
        //{
        //    c.PathInMiddlePanel();
        //    c.OnlyRequiredInSamples();
        //    c.DocumentTitle = "REDOC API Documentation";
        //    c.SpecUrl = "/swagger/v1/swagger.json";
        //});
        return app;
    }
}
