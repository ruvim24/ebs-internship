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
}