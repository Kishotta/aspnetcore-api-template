using AspNetCoreApiTemplate.Common.Application.Clock;

namespace AspNetCoreApiTemplate.Common.Infrastructure.Clock;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}