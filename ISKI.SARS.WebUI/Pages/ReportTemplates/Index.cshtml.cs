using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.ReportTemplates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.ReportTemplates;

public class IndexModel(ApiService apiService, IMapper mapper) : PageModel
{
    private readonly ApiService _apiService = apiService;
    private readonly IMapper _mapper = mapper;
    public List<ReportTemplateVm> Templates { get; set; } = new();

    public async Task OnGetAsync()
    {
        var result = await _apiService.PostAsync<PaginatedList<GetReportTemplateDto>>("api/ReportTemplates/list", new { });
        if (result != null)
            Templates = _mapper.Map<List<ReportTemplateVm>>(result.Items);
    }

    public class PaginatedList<T>
    {
        public List<T> Items { get; set; } = new();
        public int Index { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
