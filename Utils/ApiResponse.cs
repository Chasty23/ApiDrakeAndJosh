
namespace api.Utils;

public class ApiResponse<T>
{
    public int Code { get; }
    public string? Message { get; }
    public T? Data { get; }
    public bool Success { get; }

    public ApiResponse(int code, bool success, string message, T? data = default)
    {
        Code = code;
        Success = success;
        Message = message;
        Data = data;
    }

}



