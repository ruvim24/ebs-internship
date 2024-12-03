using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace API.Client.Services.Auth;
public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;

    public CustomAuthenticationStateProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity());

        var response = await _httpClient.GetAsync("api/account/isAuthenticated");

        if (response.IsSuccessStatusCode)
        {
            var claimsDto = await response.Content.ReadFromJsonAsync<List<ClaimDto>>();

            if (claimsDto != null)
            {
                var claims = claimsDto.Select(c => 
                    new Claim((c.Type == "role" ? ClaimTypes.Role : c.Type) ?? string.Empty, c.Value)).ToList();

                var identity = new ClaimsIdentity(claims, "cookie");
                user = new ClaimsPrincipal(identity);
            }
        }
        return new AuthenticationState(user);
    }
}
public class ClaimDto
{
    public string? Type { get; set; }
    public string? Value { get; set; }
}