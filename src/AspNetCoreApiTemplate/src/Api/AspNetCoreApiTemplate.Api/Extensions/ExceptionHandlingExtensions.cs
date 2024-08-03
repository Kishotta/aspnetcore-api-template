using AspNetCoreApiTemplate.Api.Middleware;

namespace AspNetCoreApiTemplate.Api.Extensions;

public static class ExceptionHandlingExtensions
{
    public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        
        return services;
    }
}