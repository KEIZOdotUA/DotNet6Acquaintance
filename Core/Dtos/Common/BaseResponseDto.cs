namespace Core.Dtos.Common;

/// <summary>
/// Base response DTO.
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseResponseDto<T>
{
    /// <summary>
    /// Gets or sets response data.
    /// </summary>
    /// <value>
    /// Response data.
    /// </value>
    public T Data { get; init; }
}
