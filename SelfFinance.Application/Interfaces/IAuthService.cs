using SelfFinance.Application.DTOs;
using SelfFinance.Domain.Entities;

namespace SelfFinance.Application.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto dto);
    Task<ApplicationUser?> LoginAsync(LoginDto dto);
}