using Microsoft.Extensions.Configuration;

namespace AspNetCoreApiTemplate.Common.Infrastructure;

public static class ConfigurationExtensions
{
    public static void AddModuleConfigurationFiles(this IConfigurationBuilder configurationBuilder, IModule module)
    {
        configurationBuilder.AddJsonFile($"modules.{module.Name}.json", false, true);
        configurationBuilder.AddJsonFile($"modules.{module.Name}.Development.json", false, true);
    }
}