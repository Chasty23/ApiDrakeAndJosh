using Asp.Versioning;
using Microsoft.Extensions.Options;

namespace api.Errors;

public class ApiVersioningError : ErrorObjectWriter
{
    public ApiVersioningError(IOptions<Microsoft.AspNetCore.Http.Json.JsonOptions> options) : base(options)
    {
    }

    protected override void OnBeforeWrite(ProblemDetailsContext context, ref ErrorObject errorObject)
    {
        context.ProblemDetails.Type = "https://httpstatuses.com/400";
        context.ProblemDetails.Title = "Bad Request";
        context.ProblemDetails.Status = StatusCodes.Status400BadRequest;
        context.ProblemDetails.Detail = $"No exist the version {context.HttpContext.Request.Headers["X-Version"]} - Use the version 1.0";
        context.ProblemDetails.Instance = context.HttpContext.Request.Path;
    }

}



