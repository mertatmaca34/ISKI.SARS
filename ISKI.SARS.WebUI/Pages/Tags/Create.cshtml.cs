using AutoMapper;
using ISKI.SARS.WebUI.DTOs.Tags;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.Tags;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.Tags;

public class CreateModel : PageModel
{
    private readonly ApiService _apiService;
    private readonly TokenService _tokenService;
    private readonly IMapper _mapper;

    [BindProperty]
    public TagVm Tag { get; set; } = new();

    public CreateModel(ApiService apiService, TokenService tokenService, IMapper mapper)
    {
        _apiService = apiService;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var token = _tokenService.GetToken();
        var dto = _mapper.Map<TagDto>(Tag);
        var result = await _apiService.PostAsync<TagDto>("/api/tags", dto, token);
        if (result.IsSuccess)
        {
            return RedirectToPage("Index");
        }
        if (result.Errors != null)
        {
            foreach (var kvp in result.Errors)
            {
                foreach (var message in kvp.Value)
                {
                    ModelState.AddModelError(kvp.Key, message);
                }
            }
        }
        return Page();
    }
}
