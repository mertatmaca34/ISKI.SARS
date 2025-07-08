using AutoMapper;
using ISKI.SARS.Application.Features.InstantValues.Dtos;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.InstantValues;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.InstantValues;

public class IndexModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    public List<InstantValueVm> Values { get; set; } = new();

    public async Task OnGetAsync()
    {
        var result = await _apiService.PostAsync<PaginatedList<GetInstantValueDto>>("api/InstantValues/list", new { });
        if (result.Success && result.Data != null)
            Values = _mapper.Map<List<InstantValueVm>>(result.Data.Items);
    }

    public class PaginatedList<T>
    {
        public List<T> Items { get; set; } = new();
    }
}
