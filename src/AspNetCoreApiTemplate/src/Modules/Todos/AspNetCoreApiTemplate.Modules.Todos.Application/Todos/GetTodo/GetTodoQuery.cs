using AspNetCoreApiTemplate.Common.Application.Messaging;

namespace AspNetCoreApiTemplate.Modules.Todos.Application.Todos.GetTodo;

public sealed record GetTodoQuery(Guid TodoId) : IQuery<TodoResponse>;