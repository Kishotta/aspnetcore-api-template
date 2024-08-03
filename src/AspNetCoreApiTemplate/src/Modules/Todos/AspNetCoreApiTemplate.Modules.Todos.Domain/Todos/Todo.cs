using AspNetCoreApiTemplate.Common.Domain;

namespace AspNetCoreApiTemplate.Modules.Todos.Domain.Todos;

public class Todo : Entity
{
    public Guid UserId { get; set; }
    public string Title { get; private set; } = string.Empty;
    public bool IsCompleted { get; private set; }
    public DateTime? CompletedAtUtc { get; private set; }

    private Todo() { }
    
    public static Todo Create(Guid userId, string title)
    {
        var todo = new Todo
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Title = title
        };
        
        todo.RaiseDomainEvent(new TodoCompletedDomainEvent(todo.Id));

        return todo;
    }
    
    public void MarkAsCompleted(DateTime completedAtUtc)
    {
        IsCompleted = true;
        CompletedAtUtc = completedAtUtc;
        
        RaiseDomainEvent(new TodoCompletedDomainEvent(Id));
    }
}