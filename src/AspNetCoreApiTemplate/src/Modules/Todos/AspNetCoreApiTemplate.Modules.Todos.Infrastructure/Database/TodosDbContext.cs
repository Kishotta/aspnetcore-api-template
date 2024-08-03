using AspNetCoreApiTemplate.Common.Infrastructure.Database;
using AspNetCoreApiTemplate.Modules.Todos.Domain.Todos;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApiTemplate.Modules.Todos.Infrastructure.Database;

public sealed class TodosDbContext(DbContextOptions<TodosDbContext> options) 
    : ModuleDbContext<TodosDbContext>(options, Schemas.Todos, AssemblyReference.Assembly)
{
    public DbSet<Todo> Todos => Set<Todo>();
}