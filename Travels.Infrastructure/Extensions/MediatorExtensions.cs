using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Travels.Infrastructure.Extensions
{
    public static class MediatorExtensions
    {
        public static IServiceCollection ConfigureServicesMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
