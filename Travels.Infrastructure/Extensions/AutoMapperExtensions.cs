using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Travels.Infrastructure.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection ConfigureServicesAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
