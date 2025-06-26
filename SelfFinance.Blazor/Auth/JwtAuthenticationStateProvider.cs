using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using SelfFinance.Application.DTOs;

namespace SelfFinance.Blazor.Auth;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;

    public JwtAuthenticationStateProvider(HttpClient httpClient) => _httpClient = httpClient;

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/auth/user");
            if (!response.IsSuccessStatusCode)
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var json = await response.Content.ReadAsStringAsync();
            var userInfo = JsonSerializer.Deserialize<UserInfoDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo!.UserId.ToString()),
                new Claim(ClaimTypes.Name, userInfo.UserName),
                new Claim(ClaimTypes.Email, userInfo.Email),
            };

            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
        catch
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }

    public void NotifyUserAuthentication()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void NotifyUserLogout()
    {
        var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
    }
    public async Task LogoutAsync()
    {
        await _httpClient.PostAsync("api/auth/logout", null); 
        NotifyUserLogout();
    }
}