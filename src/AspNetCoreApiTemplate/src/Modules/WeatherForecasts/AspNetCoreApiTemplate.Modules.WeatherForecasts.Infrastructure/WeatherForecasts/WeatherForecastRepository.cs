using AspNetCoreApiTemplate.Modules.WeatherForecasts.Domain.WeatherForecasts;

namespace AspNetCoreApiTemplate.Modules.WeatherForecasts.Infrastructure.WeatherForecasts;

internal sealed class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    
    public async Task<IEnumerable<WeatherForecast>> GetForDaysAsync(int days, CancellationToken cancellationToken = default)
    {
        var rng = new Random();
        return await Task.FromResult(
            Enumerable.Range(1, days).Select(index =>
            new WeatherForecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                rng.Next(-20, 55),
                _summaries[rng.Next(_summaries.Length)])
        ));
    }
}
