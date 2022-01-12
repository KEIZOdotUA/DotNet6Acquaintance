namespace Application.Exceptions;

/// <summary>
/// Exists exception.
/// </summary>
/// <seealso cref="System.Exception" />
public class ExistsException : Exception
{
    /// <summary>
    /// Exception message.
    /// </summary>
    private readonly string _message;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExistsException"/> class.
    /// </summary>
    /// <param name="objectName">Name of exists object.</param>
    public ExistsException(string objectName)
        => _message = $"{objectName} already exists";

    /// <summary>
    /// Gets a message that describes the current exception.
    /// </summary>
    public override string Message { get { return _message; } }
}