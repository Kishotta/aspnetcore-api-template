using Microsoft.AspNetCore.Routing;

namespace AspNetCoreApiTemplate.Common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}