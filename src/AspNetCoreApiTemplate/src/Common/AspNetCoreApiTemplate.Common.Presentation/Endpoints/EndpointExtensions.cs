using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AspNetCoreApiTemplate.Common.Presentation.Endpoints;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(
        this IServiceCollection services,
        Assembly assembly)
    {
        var endpointDescriptors = assembly
            .GetTypes()
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(endpointDescriptors);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(
        this WebApplication app,
        RouteGroupBuilder? routeGroupBuilder = null)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();
        
        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;
        
        endpoints
            .ToList()
            .ForEach(endpoint => endpoint.MapEndpoint(builder));

        return app;
    }
}