using Microsoft.AspNetCore.Mvc;

namespace api.Utils;

[ApiController]
[Route("api/[controller]")]
public abstract class ControllerResponse : ControllerBase
{
    protected ActionResult SuccessResponse<T>(T data, string message = "Ok", int statusCode = 200)
    {
        var response = new ApiResponse<T>(statusCode, true, message, data);
        return StatusCode(statusCode, response);
    }

    protected ActionResult ErrorResponse(string message, int statusCode = 400)
    {
        var response = new ApiResponse<object>(statusCode, false, message, null);
        return StatusCode(statusCode, response);
    }
}





