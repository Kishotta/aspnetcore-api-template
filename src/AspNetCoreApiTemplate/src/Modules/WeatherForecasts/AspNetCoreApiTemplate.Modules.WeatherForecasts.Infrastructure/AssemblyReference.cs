using System.Reflection;

namespace AspNetCoreApiTemplate.Modules.WeatherForecasts.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}