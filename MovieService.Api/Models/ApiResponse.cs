namespace MovieService.Api.Models;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }
    public int StatusCode { get; set; }
}