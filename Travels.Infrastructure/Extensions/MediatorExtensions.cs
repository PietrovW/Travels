using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Travels.Infrastructure.Extensions
{
    public static class MediatorExtensions
    {
        public static IServiceCollection ConfigureServicesMediator(this IServiceCollection services)
        {
            var domainAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(domainAssembly);
            services.AddFluentValidation(new[] { domainAssembly });
            return services;
        }
    }
}
