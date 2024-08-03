using AspNetCoreApiTemplate.Common.Domain;
using AspNetCoreApiTemplate.Common.Presentation.ApiResults;
using AspNetCoreApiTemplate.Common.Presentation.Endpoints;
using AspNetCoreApiTemplate.Modules.Todos.Application.Todos.GetTodo;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace AspNetCoreApiTemplate.Modules.Todos.Presentation.Todos;

internal sealed class GetTodo : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/todos/{id:guid}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetTodoQuery(id));
                return result.Match(ApiResults.Ok, ApiResults.Problem);
            })
            .WithName(nameof(GetTodo));
    }
}