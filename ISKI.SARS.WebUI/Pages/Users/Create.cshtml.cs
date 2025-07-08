using AutoMapper;
using ISKI.SARS.Application.Features.Users.Commands.Create;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.Users;

public class CreateModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public UserVm User { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        var command = _mapper.Map<CreateUserCommand>(User);
        var result = await _apiService.PostAsync<CreatedUserResponse>("api/Users", command);
        if (result.Success)
            return RedirectToPage("Index");

        ModelState.AddModelError(string.Empty, result.Error?.Message ?? "Create failed");
        return Page();
    }
}
