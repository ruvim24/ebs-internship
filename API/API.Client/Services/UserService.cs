using System.Net.Http.Json;
using Shared.Dtos.Users;

namespace API.Client.Services;

public class UserService
{
    HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> UpdateUserAsync(UpdateUserDto updateUserDto)
    {
        return await _httpClient.PutAsJsonAsync("api/user/update", updateUserDto);
    }

    public async Task<HttpResponseMessage> GetUsersAsync()
    {
        return await _httpClient.GetAsync("api/User");
    }

    public async Task<HttpResponseMessage> GetMastersAsync()
    {
        return await _httpClient.GetAsync("api/User/masters");
    }

    public async Task<HttpResponseMessage> DeleteUserAsync(int userId)
    {
        return await _httpClient.DeleteAsync($"api/User/delete/{userId}");
    }
}