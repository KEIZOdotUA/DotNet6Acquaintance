namespace WeatherService.Web.Modules.Application.Exceptions;

/// <summary>
/// Exists exception.
/// </summary>
/// <seealso cref="Exception" />
public class ExistsException : Exception
{
    /// <summary>
    /// Exception message.
    /// </summary>
    private readonly string _message;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExistsException"/> class.
    /// </summary>
    public ExistsException() => _message = $"Object already exists";

    /// <summary>
    /// Gets a message that describes the current exception.
    /// </summary>
    public override string Message { get { return _message; } }
}