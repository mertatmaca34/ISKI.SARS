using Microsoft.AspNetCore.Http;

namespace ISKI.SARS.WebUI.Middlewares;

public class AuthRedirectMiddleware
{
    private readonly RequestDelegate _next;

    public AuthRedirectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // simple placeholder
        await _next(context);
    }
}
