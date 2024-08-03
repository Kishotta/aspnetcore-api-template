namespace AspNetCoreApiTemplate.Modules.WeatherForecasts.Domain.WeatherForecasts;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>> GetForDaysAsync(
        int days, 
        CancellationToken cancellationToken = default);
}