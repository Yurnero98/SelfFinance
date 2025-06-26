using System.Security.Claims;

namespace SelfFinance.WebApi.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int GetId(this ClaimsPrincipal user)
    {
        var idClaim = user.FindFirstValue(ClaimTypes.NameIdentifier);
        if (idClaim is null)
            throw new InvalidOperationException("User ID claim not found.");

        return int.Parse(idClaim);
    }
}