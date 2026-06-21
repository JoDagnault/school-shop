using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolShop.Application.Exceptions;

namespace SchoolShop.Api.Errors;

public sealed class ApiExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ApiExceptionHandler> _logger;

    public ApiExceptionHandler(ILogger<ApiExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problem = CreateProblemDetails(exception);

        if (problem.Status == StatusCodes.Status500InternalServerError)
        {
            _logger.LogError(exception, "An unhandled exception occurred while processing the request.");
        }

        await Results.Problem(problem).ExecuteAsync(httpContext);

        return true;
    }

    private static ProblemDetails CreateProblemDetails(Exception exception)
    {
        return exception switch
        {
            NotFoundException notFound => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Not Found",
                Detail = notFound.Message
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Detail = "An unexpected error occurred."
            }
        };
    }
}
