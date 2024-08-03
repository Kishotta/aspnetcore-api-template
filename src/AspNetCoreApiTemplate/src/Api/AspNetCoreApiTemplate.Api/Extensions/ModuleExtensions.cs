using AspNetCoreApiTemplate.Common.Application;
using AspNetCoreApiTemplate.Common.Infrastructure;
using AspNetCoreApiTemplate.Modules.WeatherForecasts.Infrastructure;

namespace AspNetCoreApiTemplate.Api.Extensions;

internal static class ModuleExtensions
{
    public static void AddModules(this WebApplicationBuilder applicationBuilder)
    {
        applicationBuilder
            .Services
            .AddApplicationUseCasePipeline();
        
        var modules = GetModules();
        
        modules
            .ToList()
            .ForEach(applicationBuilder.AddModule);
    }

    private static IEnumerable<IModule> GetModules() =>
    [
        new WeatherForecastsModule()
    ];

    private static void AddModule(this WebApplicationBuilder applicationBuilder, IModule module)
    {
        module.AddConfiguration(applicationBuilder.Configuration);
        module.AddModule(applicationBuilder.Services, applicationBuilder.Configuration);
    }
}