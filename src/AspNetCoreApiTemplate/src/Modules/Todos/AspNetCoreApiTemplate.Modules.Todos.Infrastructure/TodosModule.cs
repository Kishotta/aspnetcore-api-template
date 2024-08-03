using AspNetCoreApiTemplate.Common.Application;
using AspNetCoreApiTemplate.Common.Infrastructure;
using AspNetCoreApiTemplate.Common.Infrastructure.Database;
using AspNetCoreApiTemplate.Common.Presentation.Endpoints;
using AspNetCoreApiTemplate.Modules.Todos.Domain.Todos;
using AspNetCoreApiTemplate.Modules.Todos.Infrastructure.Database;
using AspNetCoreApiTemplate.Modules.Todos.Infrastructure.Todos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreApiTemplate.Modules.Todos.Infrastructure;

public class TodosModule : IModule
{
    public string Name => nameof(Todos);
    
    public void AddModule(IServiceCollection services, ConfigurationManager configuration)
    {
        configuration.AddModuleConfigurationFiles(this);
        
        services.AddApplicationUseCases(Application.AssemblyReference.Assembly);
        
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        services.AddDbContext<TodosDbContext>(Postgres.StandardOptions(configuration, Schemas.Todos));
        services.AddScoped<ITodoRepository, TodoRepository>();
    }
}