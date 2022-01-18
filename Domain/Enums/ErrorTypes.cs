namespace Domain.Enums;

/// <summary>
/// Application error types.
/// </summary>
public enum ErrorTypes
{
    /// <summary>
    /// Resourse exists.
    /// </summary>
    EXIST_EXCEPTION,

    /// <summary>
    /// External service error.
    /// </summary>
    EXTERNAL_SERVICE_EXCEPTION,

    /// <summary>
    /// Resourse not found.
    /// </summary>
    NOT_FOUND_EXCEPTION,

    /// <summary>
    /// No access.
    /// </summary>
    UNAUTHORIZED_EXCEPTION,

    /// <summary>
    /// Unhandled error.
    /// </summary>
    UNHANDLED_EXCEPTION,
}
