namespace SelfFinance.WebApi.Middleware;

public class JwtFromCookieMiddleware
{
    private readonly RequestDelegate _next;

    public JwtFromCookieMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Cookies["authToken"];

        if (!string.IsNullOrEmpty(token) &&
            !context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Request.Headers.Append("Authorization", $"Bearer {token}");
        }

        await _next(context);
    }
}