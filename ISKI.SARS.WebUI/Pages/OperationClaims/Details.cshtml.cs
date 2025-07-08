using AutoMapper;
using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.OperationClaims;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.OperationClaims;

public class DetailsModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    public OperationClaimVm Claim { get; set; } = new();

    public async Task OnGetAsync(int id)
    {
        var dto = await _apiService.GetAsync<OperationClaimDto>($"api/OperationClaims/{id}");
        if (dto != null)
            Claim = _mapper.Map<OperationClaimVm>(dto);
    }
}
