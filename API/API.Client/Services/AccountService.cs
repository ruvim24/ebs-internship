using System.Net.Http.Json;
using Shared.Dtos.Users;

namespace API.Client.Services;

public class AccountService
{
    HttpClient _httpClient;

    public AccountService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> Login(LoginDto loginDto)
    {
        return await _httpClient.PostAsJsonAsync("Account/Login", loginDto);
    }

    public async Task<HttpResponseMessage> Register(RegisterDto registerDto)
    {
        return await _httpClient.PostAsJsonAsync("Account/register", registerDto);
    }
    
}