using Microsoft.AspNetCore.Mvc;
using SelfFinance.Application.DTOs;
using SelfFinance.Application.Interfaces;
using System.Security.Claims;

namespace SelfFinance.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService, IJwtTokenService jwtTokenService) : ControllerBase
{
    private readonly IAuthService _authService = authService;
    private readonly IJwtTokenService _jwtTokenService = jwtTokenService;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto);
        if (!result)
            return BadRequest("Registration failed");

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _authService.LoginAsync(dto);
        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = _jwtTokenService.GenerateToken(user);

        Response.Cookies.Append("authToken", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.UtcNow.AddHours(7)
        });

        return Ok(new { Token = token });
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("authToken");
        return Ok();
    }

    [HttpGet("user")]
    public IActionResult GetUser()
    {
        if (!User.Identity?.IsAuthenticated ?? true)
            return Unauthorized();

        return Ok(new UserInfoDto
        {
            UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!),
            UserName = User.Identity!.Name ?? string.Empty,
            Email = User.FindFirstValue(ClaimTypes.Email) ?? string.Empty
        });
    }
}