using Microsoft.Extensions.DependencyInjection;
using Travels.Api.Extensions;

namespace Travels.Api;

public static class Extension
{
    public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
    {
        //services.AddControllers(options =>
        // {
        //     options.SuppressAsyncSuffixInActionNames = false;
        // });
        //services.AddHttpContextAccessor();
        //services.AddEndpointsApiExplorer();
       // services.ConfigureServicesVersion();
        //services.ConfigureServicesSwagger();
        return services;
    }
}
