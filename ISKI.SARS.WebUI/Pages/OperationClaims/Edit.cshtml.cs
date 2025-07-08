using AutoMapper;
using ISKI.SARS.Application.Features.OperationClaims.Commands.Update;
using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using ISKI.SARS.Application.Features.OperationClaims.Queries.GetById;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.OperationClaims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.OperationClaims;

public class EditModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public OperationClaimVm Claim { get; set; } = new();

    public async Task OnGetAsync(int id)
    {
        var dto = await _apiService.GetAsync<OperationClaimDto>($"api/OperationClaims/{id}");
        if (dto.Success && dto.Data != null)
            Claim = _mapper.Map<OperationClaimVm>(dto.Data);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var command = _mapper.Map<UpdateOperationClaimCommand>(Claim);
        var result = await _apiService.PutAsync<UpdatedOperationClaimResponse>("api/OperationClaims", command);
        if (result.Success)
            return RedirectToPage("Index");

        ModelState.AddModelError(string.Empty, result.Error?.Message ?? "Update failed");
        return Page();
    }
}
