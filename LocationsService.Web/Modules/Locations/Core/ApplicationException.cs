namespace WeatherService.Web.Modules.Application.Exceptions;

public class ApplicationException : Exception
{
    private readonly string _message;

    public ApplicationException(string errorMessage) => _message = errorMessage;

    public override string Message { get { return _message; } }
}