namespace API.Client.Services;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string? ErrorMesage { get; set; }
    public int StatusCode { get; set; }
}