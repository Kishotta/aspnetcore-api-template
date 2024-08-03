namespace AspNetCoreApiTemplate.Modules.Todos.Application.Todos.GetTodo;

public sealed record TodoResponse(Guid Id, string Title, bool IsCompleted, DateTime? CompletedAtUtc);