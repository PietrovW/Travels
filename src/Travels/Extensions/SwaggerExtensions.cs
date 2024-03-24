using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Travels.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection ConfigureServicesSwagger(this IServiceCollection services)
    {
        
       // services.AddFluentValidationRulesToSwagger();
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
       
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("v1/swagger.json", "My API V1");
        });

        return app;
    }
}
