namespace ZitroShop.Api.Common;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
    public T? Data { get; set; }
    public int StatusCode { get; set; }

    public static ApiResponse<T> Ok(T data, string message = "Operation completed successfully.")
        => new() { Success = true, Message = message, Data = data, StatusCode = StatusCodes.Status200OK };

    public static ApiResponse<T> Fail(string message, int statusCode)
        => new() { Success = false, Message = message, StatusCode = statusCode };
}