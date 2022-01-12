namespace Application.Exceptions;

/// <summary>
/// Not found exception.
/// </summary>
/// <seealso cref="System.Exception" />
public class NotFoundException : Exception
{
    /// <summary>
    /// Exception message.
    /// </summary>
    private readonly string _message;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="objectName">Name of not found object.</param>
    public NotFoundException(string objectName)
        => _message = $"{objectName} not found";

    /// <summary>
    /// Gets a message that describes the current exception.
    /// </summary>
    public override string Message { get { return _message; } }
}