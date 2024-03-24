using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Travels.Domain;

public static class Extension
{
    public static IServiceCollection ConfigureServices(IServiceCollection services,IConfiguration configuration)
    {
        return services;
    }
}
