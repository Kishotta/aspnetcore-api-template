using AspNetCoreApiTemplate.Common.Application.Messaging;
using AspNetCoreApiTemplate.Common.Domain;
using AspNetCoreApiTemplate.Modules.WeatherForecasts.Domain.WeatherForecasts;

namespace AspNetCoreApiTemplate.Modules.WeatherForecasts.Application.WeatherForecasts;

internal sealed class GetWeatherForecastQueryHandler(IWeatherForecastRepository weatherForecastRepository)
    : IQueryHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecastResponse>>
{
    public async Task<Result<IEnumerable<WeatherForecastResponse>>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var weatherForecast = await weatherForecastRepository.GetForDaysAsync(request.Days, cancellationToken);

        var response = weatherForecast
            .Select(x => (WeatherForecastResponse)x);

        return Result.Success(response);
    }
}