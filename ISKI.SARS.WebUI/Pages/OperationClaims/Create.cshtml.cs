using AutoMapper;
using ISKI.SARS.Application.Features.OperationClaims.Commands.Create;
using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.OperationClaims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.OperationClaims;

public class CreateModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public OperationClaimVm Claim { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var command = _mapper.Map<CreateOperationClaimCommand>(Claim);
        var result = await _apiService.PostAsync<CreatedOperationClaimResponse>("api/OperationClaims", command);
        if (result != null)
            return RedirectToPage("Index");
        return Page();
    }
}
