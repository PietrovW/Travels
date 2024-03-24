using Microsoft.AspNetCore.Builder;
using Travels.Infrastructure.Middlewares;

namespace Travels.Infrastructure.Extensions;

public static class ErrorHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandler(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}
