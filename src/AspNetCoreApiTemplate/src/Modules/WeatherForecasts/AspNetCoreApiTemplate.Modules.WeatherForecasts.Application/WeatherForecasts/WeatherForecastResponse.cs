using AspNetCoreApiTemplate.Modules.WeatherForecasts.Domain.WeatherForecasts;

namespace AspNetCoreApiTemplate.Modules.WeatherForecasts.Application.WeatherForecasts;

public sealed record WeatherForecastResponse(DateOnly Date, int TemperatureC, string? Summary)
{
    public static implicit operator WeatherForecastResponse(WeatherForecast weatherForecast) =>
        new(weatherForecast.Date, weatherForecast.TemperatureC, weatherForecast.Summary);
};