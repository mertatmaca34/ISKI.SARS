using AutoMapper;
using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using ISKI.SARS.Application.Features.OperationClaims.Queries.GetList;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.OperationClaims;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.OperationClaims;

public class IndexModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    public List<OperationClaimVm> Claims { get; set; } = new();

    public async Task OnGetAsync()
    {
        var result = await _apiService.GetAsync<PaginatedList<OperationClaimDto>>("api/OperationClaims");
        if (result.Success && result.Data != null)
            Claims = _mapper.Map<List<OperationClaimVm>>(result.Data.Items);
    }

    public class PaginatedList<T>
    {
        public List<T> Items { get; set; } = new();
    }
}
