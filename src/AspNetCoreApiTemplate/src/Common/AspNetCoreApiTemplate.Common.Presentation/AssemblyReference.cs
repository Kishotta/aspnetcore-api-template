using System.Reflection;

namespace AspNetCoreApiTemplate.Common.Presentation;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}