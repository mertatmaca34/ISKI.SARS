using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.Models;

namespace ISKI.SARS.WebUI.Controllers;

public class TagsController(IApiService apiService) : Controller
{
    private readonly IApiService _apiService = apiService;

    public async Task<IActionResult> Index(int templateId)
    {
        var tags = await _apiService.GetTagsAsync(templateId);
        ViewBag.TemplateId = templateId;
        return View(tags);
    }

    public IActionResult Create(int templateId)
    {
        return View(new TagViewModel { ReportTemplateId = templateId });
    }

    [HttpPost]
    public async Task<IActionResult> Create(TagViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _apiService.CreateTagAsync(model);
        return RedirectToAction(nameof(Index), new { templateId = model.ReportTemplateId });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var tag = await _apiService.GetTagByIdAsync(id);
        if (tag == null)
            return NotFound();
        return View(tag);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TagViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _apiService.UpdateTagAsync(model);
        return RedirectToAction(nameof(Index), new { templateId = model.ReportTemplateId });
    }

    public async Task<IActionResult> Delete(int id, int templateId)
    {
        await _apiService.DeleteTagAsync(id);
        return RedirectToAction(nameof(Index), new { templateId });
    }
}
