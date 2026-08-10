namespace CodeAssessment.API.Models;

public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public static ApiResponse<T> Success(T data, string message = "Success", int statusCode = 200)
    {
        return new ApiResponse<T> { StatusCode = statusCode, IsSuccess = true, Message = message, Data = data };
    }
    public static ApiResponse<T> Failure(string message, int statusCode = 400)
    {
        return new ApiResponse<T> { StatusCode = statusCode, IsSuccess = false, Message = message, Data = default };
    }
}