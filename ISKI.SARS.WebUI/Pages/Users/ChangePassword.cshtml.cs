using AutoMapper;
using ISKI.SARS.Application.Features.Users.Commands.ChangePassword;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.Users;

public class ChangePasswordModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public ChangePasswordVm ModelData { get; set; } = new();

    public void OnGet(Guid userId)
    {
        ModelData.UserId = userId;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var command = _mapper.Map<ChangePasswordCommand>(ModelData);
        var result = await _apiService.PutAsync<ChangedPasswordResponse>("api/Users/change-password", command);
        if (result.Success)
            return RedirectToPage("Index");

        ModelState.AddModelError(string.Empty, result.Error?.Message ?? "Change failed");
        return Page();
    }
}
