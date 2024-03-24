using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.DependencyInjection;
using Travels.Api.Controllers.v1_0;

namespace Travels.Api.Extensions;

public static class VersioningExtensions
{
    public static IServiceCollection ConfigureServicesVersion(this IServiceCollection services)
    {
        //services.AddApiVersioning(options =>
        //{
        //    options.DefaultApiVersion = new ApiVersion(1, 0);
        //    options.AssumeDefaultVersionWhenUnspecified = true;
        //    options.ReportApiVersions = true;
        //    options.ApiVersionReader = ApiVersionReader.Combine(
        //        new QueryStringApiVersionReader("api-version"),
        //        new HeaderApiVersionReader("api-version"));
        //    options.Conventions.Controller<StopsController>().HasApiVersion(new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0));
        //    options.Conventions.Controller<TravelController>().HasApiVersion(new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0));
        //    options.Conventions.Controller<TripController>().HasApiVersion(new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0));
        //});
        return services;
    }
}
