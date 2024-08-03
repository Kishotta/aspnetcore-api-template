using System.Reflection;
using AspNetCoreApiTemplate.Common.Application.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreApiTemplate.Common.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationUseCasePipeline(
        this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(AssemblyReference.Assembly);
            
            config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });
        
        return services;
    }
    
    public static IServiceCollection AddApplicationUseCases(
        this IServiceCollection services,
        Assembly moduleApplicationAssembly)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(moduleApplicationAssembly);
        });

        services.AddValidatorsFromAssembly(moduleApplicationAssembly, includeInternalTypes: true);
        
        return services;
    }
}