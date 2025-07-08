using ISKI.Core.Security.Dtos;
using ISKI.SARS.Application.Features.Auths.Commands.Login;
using ISKI.SARS.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.Auths;

public class LoginModel(ApiService apiService, TokenService tokenService) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly TokenService _tokenService = tokenService;

    [BindProperty]
    public string Email { get; set; } = string.Empty;
    [BindProperty]
    public string Password { get; set; } = string.Empty;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = new LoginDto { Email = Email, Password = Password };
        var command = new LoginCommand { LoginDto = dto, IpAddress = "" };
        var token = await _apiService.PostAsync<AccessToken>("api/Auth/login", command);
        if (token != null)
        {
            _tokenService.SaveToken(token.Token);
            return RedirectToPage("/Index");
        }
        return Page();
    }
}
