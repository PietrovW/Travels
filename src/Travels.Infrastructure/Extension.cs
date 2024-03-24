using Microsoft.Extensions.DependencyInjection;
using Travels.Application.Interfaces;
using Travels.Infrastructure.Profiles;
using Travels.Infrastructure.Repositories;

namespace Travels.Infrastructure;
public static class Extension
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<ITravelRepository, TravelRepository>();
        services.AddAutoMapper(typeof(AutoMapperProfile));
        return services;
    }
}