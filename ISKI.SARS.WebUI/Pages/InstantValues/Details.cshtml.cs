using AutoMapper;
using ISKI.SARS.Application.Features.InstantValues.Dtos;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.InstantValues;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.InstantValues;

public class DetailsModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    public InstantValueVm Value { get; set; } = new();

    public async Task OnGetAsync(DateTime timestamp)
    {
        var result = await _apiService.GetAsync<GetInstantValueDto>($"api/InstantValues/{timestamp:o}");
        if (result.Success && result.Data != null)
            Value = _mapper.Map<InstantValueVm>(result.Data);
    }
}
