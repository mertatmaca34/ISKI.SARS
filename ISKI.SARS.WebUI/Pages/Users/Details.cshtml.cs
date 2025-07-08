using AutoMapper;
using ISKI.SARS.Application.Features.Users.Dtos;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.Users;

public class DetailsModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    public UserVm User { get; set; } = new();

    public async Task OnGetAsync(Guid id)
    {
        var dto = await _apiService.GetAsync<UserDto>($"api/Users/{id}");
        if (dto.Success && dto.Data != null)
            User = _mapper.Map<UserVm>(dto.Data);
    }
}
