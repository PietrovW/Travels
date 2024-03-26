using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Travels.Api.Controllers.v1_0;

namespace Travels.Api.Extensions;

public static class VersioningExtensions
{
    public static IServiceCollection ConfigureServicesVersion(this IServiceCollection services)
    {
        //services.AddApiVersioning(options =>
        //{
        //    options.DefaultApiVersion = new ApiVersion(1);
        //    options.ReportApiVersions = true;
        //    options.AssumeDefaultVersionWhenUnspecified = true;
        //    options.ApiVersionReader = ApiVersionReader.Combine(
        //        new UrlSegmentApiVersionReader(),
        //        new QueryStringApiVersionReader("api-version"),
        //        new HeaderApiVersionReader("X-Version"),
        //        new MediaTypeApiVersionReader("ver"));
        // })
        services.AddApiVersioning()
    .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        return services;
    }
}
