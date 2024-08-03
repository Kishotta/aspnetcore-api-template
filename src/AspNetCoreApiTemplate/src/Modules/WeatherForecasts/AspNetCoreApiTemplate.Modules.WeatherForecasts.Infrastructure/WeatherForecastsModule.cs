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
    
    public void AddConfiguration(IConfigurationBuilder configuration)
    {
        configuration.AddModuleConfigurationFiles(this);
    }

    public void AddModule(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddApplicationUseCases(Application.AssemblyReference.Assembly);
        services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);
    }
}