using Microsoft.AspNetCore.Http;

namespace ISKI.SARS.WebUI.Extensions;

public static class HttpContextExtensions
{
    public static string? GetToken(this HttpContext context)
    {
        return context.Request.Cookies["token"];
    }
}
