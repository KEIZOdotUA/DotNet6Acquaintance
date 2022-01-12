using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

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
        context.HttpContext.Response.StatusCode =
            context.Exception switch
            {
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.BadRequest,
            };

        context.Result = new ObjectResult(new ErrorResponseDto { Message = context.Exception.GetBaseException().Message });

        context.ExceptionHandled = true;
    }
}
