namespace AspNetCoreApiTemplate.Common.Domain;

/// <summary>
/// Represents the various types of errors that can occur.
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// An unrecoverable error occured.
    /// </summary>
    Failure = 0,
    
    /// <summary>
    /// The inputs provided are invalid, such as out-of-range or unknown values.
    /// </summary>
    Validation = 1,
    
    /// <summary>
    ///  A domain invariant violation occurred.
    /// </summary>
    Problem = 2,
    
    /// <summary>
    /// The requested data was not found.
    /// </summary>
    NotFound = 3,
    
    /// <summary>
    /// A conflict was detected.
    /// </summary>
    Conflict = 4,
    
    /// <summary>
    /// The user is unauthorized to perform the action.
    /// </summary>
    Authorization = 5,
}