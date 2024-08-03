using AspNetCoreApiTemplate.Common.Application.Messaging;
using AspNetCoreApiTemplate.Common.Domain;
using AspNetCoreApiTemplate.Modules.Todos.Domain.Todos;

namespace AspNetCoreApiTemplate.Modules.Todos.Application.Todos.GetTodo;

internal sealed class GetTodoQueryHandler(ITodoRepository todoRepository)
    : IQueryHandler<GetTodoQuery, TodoResponse>
{
    public async Task<Result<TodoResponse>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var todo = await todoRepository.GetAsync(request.TodoId, cancellationToken);
        if (todo is null)
            return Result.Failure<TodoResponse>(TodoErrors.NotFound(request.TodoId));

        return new TodoResponse(todo.Id, todo.Title, todo.IsCompleted, todo.CompletedAtUtc);
    }
}