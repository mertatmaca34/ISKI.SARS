using ISKI.SARS.WebUI.Areas.InstantValues.ViewModels;
using ISKI.SARS.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ISKI.SARS.WebUI.Areas.InstantValues.Controllers;

[Area("InstantValues")]
public class InstantValuesController : Controller
{
    private readonly IApiService _apiService;

    public InstantValuesController(IApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var token = HttpContext.Session.GetString("AccessToken");
        if (string.IsNullOrEmpty(token))
            return RedirectToAction("Index", "Login", new { area = "Login" });

        var request = new InstantValueListRequest { PageNumber = 1, PageSize = 20 };
        var values = await _apiService.GetInstantValuesAsync(request, token);
        return View(values);
    }
}
