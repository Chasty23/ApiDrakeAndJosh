using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace api.Middleware;

public class ErrorMiddleware : IExceptionHandler
{
    private readonly ILogger<ErrorMiddleware> _logger;

    public ErrorMiddleware(ILogger<ErrorMiddleware> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Ocurrió una excepción no controlada: {Message}", exception.Message);

        // Personalizamos la respuesta según el tipo de excepción
        var (statusCode, title) = exception switch
        {
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "No autorizado"),
            KeyNotFoundException => (StatusCodes.Status404NotFound, "Recurso no encontrado"),
            _ => (StatusCodes.Status500InternalServerError, "Error interno del servidor")
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        // Retornamos true para indicar que la excepción ya fue manejada
        return true;
    }
}













