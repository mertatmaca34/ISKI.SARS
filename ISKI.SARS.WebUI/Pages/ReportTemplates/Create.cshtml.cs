using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.ReportTemplates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.ReportTemplates;

public class CreateModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public ReportTemplateVm Template { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var command = _mapper.Map<CreateReportTemplateCommand>(Template);
        var result = await _apiService.PostAsync<GetReportTemplateDto>("api/ReportTemplates", command);
        if (result.Success)
        {
            return RedirectToPage("Index");
        }
        ModelState.AddModelError(string.Empty, result.Error?.Message ?? "Create failed");
        return Page();
    }
}
