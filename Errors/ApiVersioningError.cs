using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        context.ProblemDetails.Detail = "No existe la version de la api";
        context.ProblemDetails.Instance = context.HttpContext.Request.Path;
    }


}



