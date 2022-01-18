namespace Application.Exceptions;

/// <summary>
/// External service error exception.
/// </summary>
/// <seealso cref="System.Exception" />
public class ExternalServiceException : Exception
{
    /// <summary>
    /// Exception message.
    /// </summary>
    private readonly string _message;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExternalServiceException"/> class.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    public ExternalServiceException(string errorMessage)
        => _message = errorMessage;

    /// <summary>
    /// Gets a message that describes the current exception.
    /// </summary>
    public override string Message { get { return _message; } }
}
