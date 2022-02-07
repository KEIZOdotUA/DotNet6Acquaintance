namespace WeatherService.Web.Modules.Application.Exceptions;

/// <summary>
/// Not found exception.
/// </summary>
/// <seealso cref="Exception" />
public class NotFoundException : Exception
{
    /// <summary>
    /// Exception message.
    /// </summary>
    private readonly string _message;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    public NotFoundException() => _message = $"Object not found";

    /// <summary>
    /// Gets a message that describes the current exception.
    /// </summary>
    public override string Message { get { return _message; } }
}