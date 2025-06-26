using Microsoft.AspNetCore.Identity;
using SelfFinance.Application.DTOs;
using SelfFinance.Application.Interfaces;
using SelfFinance.Domain.Entities;

namespace SelfFinance.Application.Services;

public class AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : IAuthService
{
    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        var user = new ApplicationUser
        {
            UserName = dto.UserName,
            Email = dto.Email
        };

        var result = await userManager.CreateAsync(user, dto.Password);
        return result.Succeeded;
    }

    public async Task<ApplicationUser?> LoginAsync(LoginDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return null;

        var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        return result.Succeeded ? user : null;
    }
}