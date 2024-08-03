using System.Reflection;

namespace AspNetCoreApiTemplate.Modules.Todos.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}