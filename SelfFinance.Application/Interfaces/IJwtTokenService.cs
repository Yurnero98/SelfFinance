using SelfFinance.Domain.Entities;

namespace SelfFinance.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(ApplicationUser user);
}