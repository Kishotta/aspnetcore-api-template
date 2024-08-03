using AspNetCoreApiTemplate.Common.Application.Messaging;

namespace AspNetCoreApiTemplate.Modules.WeatherForecasts.Application.WeatherForecasts;

public sealed record GetWeatherForecastQuery(int Days) 
    : IQuery<IEnumerable<WeatherForecastResponse>>;