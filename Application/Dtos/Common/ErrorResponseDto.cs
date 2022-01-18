namespace Application.Dtos.Common;

/// <summary>
/// Error response DTO.
/// </summary>
public class ErrorResponseDto
{
    /// <summary>
    /// Gets or sets the status code.
    /// </summary>
    /// <value>
    /// The status code.
    /// </value>
    public int StatusCode { get; init; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>
    /// Error type.
    /// </value>
    public string Type { get; init; }

    /// <summary>
    /// Gets or sets error message.
    /// </summary>
    /// <value>
    /// Error message.
    /// </value>
    public string Message { get; init; }
}
