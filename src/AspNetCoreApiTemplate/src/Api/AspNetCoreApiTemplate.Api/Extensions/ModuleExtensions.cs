using System.Reflection;
using AspNetCoreApiTemplate.Common.Application;
using AspNetCoreApiTemplate.Common.Infrastructure;
using AspNetCoreApiTemplate.Modules.Todos.Infrastructure;
using AspNetCoreApiTemplate.Modules.WeatherForecasts.Infrastructure;

namespace AspNetCoreApiTemplate.Api.Extensions;

internal static class ModuleExtensions
{
    public static void AddModules(this WebApplicationBuilder applicationBuilder, string databaseConnectionString)
    {
        applicationBuilder
            .Services
            .AddApplicationUseCasePipeline()
            .AddCommonInfrastructure(databaseConnectionString);
        
        var modules = GetModules();
        
        modules
            .ToList()
            .ForEach(applicationBuilder.AddModule);
    }

    private static IEnumerable<IModule> GetModules() => [
        new TodosModule(),
        new WeatherForecastsModule()
    ];

    private static void AddModule(this WebApplicationBuilder applicationBuilder, IModule module)
    {
        module.AddModule(applicationBuilder.Services, applicationBuilder.Configuration);
    }
}