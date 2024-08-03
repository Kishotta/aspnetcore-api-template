using AspNetCoreApiTemplate.Common.Domain;
using AspNetCoreApiTemplate.Common.Presentation.ApiResults;
using AspNetCoreApiTemplate.Common.Presentation.Endpoints;
using AspNetCoreApiTemplate.Modules.WeatherForecasts.Application.WeatherForecasts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace AspNetCoreApiTemplate.Modules.WeatherForecasts.Presentation.WeatherForecast;

internal sealed class GetWeatherForecast : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", async (int days,ISender sender) =>
            {
                var result = await sender.Send(new GetWeatherForecastQuery(days));
                
                return result.Match(ApiResults.Ok, ApiResults.Problem);
            })
            .WithName("GetWeatherForecast");
    }
}