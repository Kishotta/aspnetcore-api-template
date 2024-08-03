using System.Reflection;

namespace AspNetCoreApiTemplate.Common.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}