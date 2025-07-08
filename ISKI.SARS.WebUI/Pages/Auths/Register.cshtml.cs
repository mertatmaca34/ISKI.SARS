using AutoMapper;
using ISKI.Core.Security.Dtos;
using ISKI.Core.Security.JWT;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.Auths;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.Auths;

public class RegisterModel(ApiService apiService, TokenService tokenService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly TokenService _tokenService = tokenService;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public RegisterVm User { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = _mapper.Map<RegisterDto>(User);
        var result = await _apiService.PostAsync<AccessToken>("api/Auth/register", dto);
        if (result.Success && result.Data != null)
        {
            _tokenService.SaveToken(result.Data.Token);
            return RedirectToPage("/Index");
        }

        ModelState.AddModelError(string.Empty, result.Error?.Message ?? "Registration failed");
        return Page();
    }
}
