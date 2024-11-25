using System.Net.Http.Json;
using System.Text.Json;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        return await _httpClient.PostAsJsonAsync("api/Account/login", loginDto);
    }

    public async Task<HttpResponseMessage> Register(RegisterDto registerDto)
    {
        return await _httpClient.PostAsJsonAsync("api/Account/register", registerDto);
    }

    public async Task<HttpResponseMessage> RegisterMaster(RegisterDto registerDto)
    {
        return await _httpClient.PostAsJsonAsync("api/Account/register-master", registerDto);
    }

    public async Task<HttpResponseMessage> Logout()
    {
        return await _httpClient.PostAsJsonAsync<object>("api/Account/logout", null! );
    }

    public async Task<UserDto> GetLoggedInUser()
    {
        
        return await _httpClient.GetFromJsonAsync<UserDto>("api/Account/user-info");
        
    }
    
}