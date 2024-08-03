using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreApiTemplate.Common.Infrastructure;

public interface IModule
{
    string Name { get; }
    void AddConfiguration(IConfigurationBuilder configuration);
    void AddModule(IServiceCollection services, ConfigurationManager configuration);
}