using Microsoft.AspNetCore.Http;

namespace ISKI.SARS.WebUI.Services;

public class TokenService(IHttpContextAccessor accessor)
{
    private readonly IHttpContextAccessor _accessor = accessor;
    private const string CookieName = "sars_token";

    public void SaveToken(string token)
    {
        _accessor.HttpContext?.Response.Cookies.Append(CookieName, token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(1)
        });
    }

    public string? GetToken()
    {
        _accessor.HttpContext?.Request.Cookies.TryGetValue(CookieName, out var token);
        return token;
    }

    public void ClearToken()
    {
        _accessor.HttpContext?.Response.Cookies.Delete(CookieName);
    }
}
