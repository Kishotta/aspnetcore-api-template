namespace AspNetCoreApiTemplate.Modules.Todos.Domain.Todos;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetForUserAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Todo?> GetAsync(Guid todoId, CancellationToken cancellationToken = default);
    void Add(Todo todo);
}