using AspNetCoreApiTemplate.Modules.Todos.Domain.Todos;
using AspNetCoreApiTemplate.Modules.Todos.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApiTemplate.Modules.Todos.Infrastructure.Todos;

internal sealed class TodoRepository(TodosDbContext context) : ITodoRepository
{
    public async Task<IEnumerable<Todo>> GetForUserAsync(Guid userId, CancellationToken cancellationToken = default) =>
        await context
            .Todos
            .Where(todo => todo.UserId == userId)
            .ToListAsync(cancellationToken);

    public async Task<Todo?> GetAsync(Guid todoId, CancellationToken cancellationToken = default) =>
        await context
            .Todos
            .SingleOrDefaultAsync(todo => todo.Id == todoId, cancellationToken);

    public void Add(Todo todo)
    {
        context.Todos.Add(todo);
    }
}