using AspNetCoreApiTemplate.Common.Application.Data;
using AspNetCoreApiTemplate.Common.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace AspNetCoreApiTemplate.Common.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddCommonInfrastructure(
        this IServiceCollection services,
        string databaseConnectionString)
    {
        var npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        
        return services;
    }
}