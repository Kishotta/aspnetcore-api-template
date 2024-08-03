using AspNetCoreApiTemplate.Common.Domain;

namespace AspNetCoreApiTemplate.Modules.Todos.Domain.Todos;

public static class TodoErrors
{
    public static Error NotFound(Guid todoId) =>
        Error.NotFound(
            "Todos.NotFound",
            $"The todo with identifier {todoId} was not found");
}