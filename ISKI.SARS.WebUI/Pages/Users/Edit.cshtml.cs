using AutoMapper;
using ISKI.SARS.Application.Features.Users.Commands.Update;
using ISKI.SARS.Application.Features.Users.Dtos;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.Users;

public class EditModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public UserVm User { get; set; } = new();

    public async Task OnGetAsync(Guid id)
    {
        var dto = await _apiService.GetAsync<UserDto>($"api/Users/{id}");
        if (dto.Success && dto.Data != null)
            User = _mapper.Map<UserVm>(dto.Data);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var command = _mapper.Map<UpdateUserCommand>(User);
        var result = await _apiService.PutAsync<UpdatedUserResponse>("api/Users", command);
        if (result.Success)
            return RedirectToPage("Index");

        ModelState.AddModelError(string.Empty, result.Error?.Message ?? "Update failed");
        return Page();
    }
}
