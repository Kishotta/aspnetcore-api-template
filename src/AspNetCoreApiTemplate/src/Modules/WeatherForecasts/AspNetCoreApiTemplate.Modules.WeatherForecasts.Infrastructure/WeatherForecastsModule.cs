using AspNetCoreApiTemplate.Common.Application;
using AspNetCoreApiTemplate.Common.Infrastructure;
using AspNetCoreApiTemplate.Common.Presentation.Endpoints;
using AspNetCoreApiTemplate.Modules.WeatherForecasts.Domain.WeatherForecasts;
using AspNetCoreApiTemplate.Modules.WeatherForecasts.Infrastructure.WeatherForecasts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreApiTemplate.Modules.WeatherForecasts.Infrastructure;

public sealed class WeatherForecastsModule : IModule
{
    public string Name => nameof(WeatherForecasts);
    
    public void AddModule(IServiceCollection services, ConfigurationManager configuration)
    {
        configuration.AddModuleConfigurationFiles(this);
        
        // services.AddDomainEventHandlers(Domain.AssemblyReference.Assembly, typeof(IdempotentDomainEventHandler<>))
        // services.AddIntegrationEventHandlers(Presentation.AssemblyReference.Assembly, typeof(IdempotentIntegrationEventHandler<>))
        
        services.AddApplicationUseCases(Application.AssemblyReference.Assembly);
        
        // services.AddDatabase<WeatherForecastsDbContext, IUnitOfWork>(configuration, Schemas.WeatherForecasts)
        //     .AddScoped<IWeatherForecastRepository, WeatherForecastRepository>()
        
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);
        
        services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
    }
}