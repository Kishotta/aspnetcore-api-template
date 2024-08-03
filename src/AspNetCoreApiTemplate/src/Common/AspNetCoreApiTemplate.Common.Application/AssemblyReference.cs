using System.Reflection;

namespace AspNetCoreApiTemplate.Common.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}