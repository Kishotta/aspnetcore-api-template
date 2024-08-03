using AspNetCoreApiTemplate.Common.Domain;

namespace AspNetCoreApiTemplate.Common.Application.Exceptions;

public sealed class AspNetCoreApiTemplateException(
    string requestName,
    Error? error = default,
    Exception? innerException = default)
    : Exception("Application exception", innerException)
{
    public string RequestName { get; } = requestName;

    public Error? Error { get; } = error;
}
