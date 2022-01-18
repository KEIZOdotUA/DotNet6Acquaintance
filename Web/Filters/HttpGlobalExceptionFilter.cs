using Application.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters;

/// <summary>
/// Exception filter.
/// </summary>
public class HttpGlobalExceptionFilter : IExceptionFilter
{
    /// <summary>
    /// Called after an action has thrown an <see cref="T:System.Exception" />.
    /// </summary>
    /// <param name="context">The <see cref="T:Microsoft.AspNetApplication.Mvc.Filters.ExceptionContext" />.</param>
    public void OnException(ExceptionContext context)
    {
        var errorMessage = context.Exception.GetBaseException().Message;

        ErrorResponseDto errorResponse = context.Exception switch
        {
            ExistsException => new()
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Type = ErrorTypes.EXIST_EXCEPTION.ToString(),
                Message = errorMessage,
            },
            ExternalServiceException => new()
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Type = ErrorTypes.EXTERNAL_SERVICE_EXCEPTION.ToString(),
                Message = errorMessage,
            },
            UnauthorizedAccessException => new()
            {
                StatusCode = (int)HttpStatusCode.Unauthorized,
                Type = ErrorTypes.UNAUTHORIZED_EXCEPTION.ToString(),
                Message = errorMessage,
            },
            NotFoundException => new()
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Type = ErrorTypes.NOT_FOUND_EXCEPTION.ToString(),
                Message = errorMessage,
            },
            _ => new()
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Type = ErrorTypes.UNHANDLED_EXCEPTION.ToString(),
                Message = errorMessage,
            },
        };

        context.HttpContext.Response.StatusCode = errorResponse.StatusCode;
        context.Result = new ObjectResult(errorResponse);
        context.ExceptionHandled = true;
    }
}
