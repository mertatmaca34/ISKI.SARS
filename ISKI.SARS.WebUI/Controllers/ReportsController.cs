using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.Models;

namespace ISKI.SARS.WebUI.Controllers;

public class ReportsController(IApiService apiService) : Controller
{
    private readonly IApiService _apiService = apiService;

    public async Task<IActionResult> Index()
    {
        var templates = await _apiService.GetReportTemplatesAsync();
        return View(templates);
    }

    public IActionResult Create()
    {
        return View(new ReportTemplateViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReportTemplateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _apiService.CreateReportTemplateAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DownloadPdf(int id)
    {
        var bytes = await _apiService.GetReportPdfAsync(id);
        return File(bytes, "application/pdf", $"report_{id}.pdf");
    }

    public async Task<IActionResult> DownloadExcel(int id)
    {
        var bytes = await _apiService.GetReportExcelAsync(id);
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"report_{id}.xlsx");
    }
}
