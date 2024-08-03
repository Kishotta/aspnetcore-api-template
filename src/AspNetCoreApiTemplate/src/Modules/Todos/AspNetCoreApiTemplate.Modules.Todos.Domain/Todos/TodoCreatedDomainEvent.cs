using AspNetCoreApiTemplate.Common.Domain;

namespace AspNetCoreApiTemplate.Modules.Todos.Domain.Todos;

public sealed class TodoCreatedDomainEvent(Guid todoId) : DomainEvent
{
    public Guid TodoId { get; } = todoId;
}