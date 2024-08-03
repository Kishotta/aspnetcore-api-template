using System.Data.Common;
using AspNetCoreApiTemplate.Common.Application.Data;
using Npgsql;

namespace AspNetCoreApiTemplate.Common.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
