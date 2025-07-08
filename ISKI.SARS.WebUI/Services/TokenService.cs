using Microsoft.AspNetCore.Http;

namespace ISKI.SARS.WebUI.Services;

public class TokenService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public TokenService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetToken()
    {
        return _httpContextAccessor.HttpContext?.Request.Cookies["token"];
    }

    public void SetToken(string token)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Append("token", token);
    }

    public void RemoveToken()
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete("token");
    }
}
