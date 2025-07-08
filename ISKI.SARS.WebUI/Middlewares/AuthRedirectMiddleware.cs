using Microsoft.AspNetCore.Http;

namespace ISKI.SARS.WebUI.Middlewares;

public class AuthRedirectMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status401Unauthorized &&
            !context.Request.Path.StartsWithSegments("/Auths/Login"))
        {
            context.Response.Redirect("/Auths/Login");
        }
    }
}
