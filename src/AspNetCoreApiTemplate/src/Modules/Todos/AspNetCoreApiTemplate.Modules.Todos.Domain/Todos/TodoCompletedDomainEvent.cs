using AspNetCoreApiTemplate.Common.Domain;

namespace AspNetCoreApiTemplate.Modules.Todos.Domain.Todos;

public sealed class TodoCompletedDomainEvent(Guid todoId) : DomainEvent
{
    public Guid TodoId { get; } = todoId;
}