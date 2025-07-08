using AutoMapper;
using ISKI.SARS.Application.Features.Users.Dtos;
using ISKI.SARS.Application.Features.Users.Queries.GetList;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.Users;

public class IndexModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    public List<UserVm> Users { get; set; } = new();

    public async Task OnGetAsync()
    {
        var result = await _apiService.GetAsync<PaginatedList<UserDto>>("api/Users");
        if (result.Success && result.Data != null)
            Users = _mapper.Map<List<UserVm>>(result.Data.Items);
    }

    public class PaginatedList<T>
    {
        public List<T> Items { get; set; } = new();
    }
}
