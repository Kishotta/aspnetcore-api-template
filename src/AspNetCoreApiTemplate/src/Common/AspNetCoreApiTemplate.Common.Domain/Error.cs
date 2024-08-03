namespace AspNetCoreApiTemplate.Common.Domain;

/// <summary>
/// Represents an error that occurred during the execution of the application.
/// </summary>
/// <param name="Code"></param>
/// <param name="Description"></param>
/// <param name="Type"></param>
public record Error(string Code, string Description, ErrorType Type)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new("General.Null", "Null value was provided", ErrorType.Failure);
    
    public static Error Failure (string code, string description) => new(code, description, ErrorType.Failure);
    public static Error NotFound (string code, string description) => new(code, description, ErrorType.NotFound);
    public static Error Problem (string code, string description) => new(code, description, ErrorType.Problem);
    public static Error Conflict (string code, string description) => new(code, description, ErrorType.Conflict);
    public static Error Authorization (string code, string description) => new(code, description, ErrorType.Authorization);
}