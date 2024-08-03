using System.Reflection;

namespace AspNetCoreApiTemplate.Common.Domain;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}