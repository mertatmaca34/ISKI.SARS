using Microsoft.AspNetCore.Http;

namespace ISKI.SARS.WebUI.Extensions;

public static class HttpContextExtensions
{
    public static Guid GetUserId(this HttpContext context)
        => context.User.GetUserId();
}
