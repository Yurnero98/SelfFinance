using SelfFinance.WebApi.Middleware;

namespace SelfFinance.WebApi.Extensions;

public static class JwtFromCookieMiddlewareExtensions
{
    public static IApplicationBuilder UseJwtFromCookie(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<JwtFromCookieMiddleware>();
    }
}