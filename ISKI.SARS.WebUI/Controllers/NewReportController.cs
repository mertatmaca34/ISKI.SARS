using ISKI.SARS.WebUI.Models;
using ISKI.SARS.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.WebUI.Controllers
{
    public class NewReportController : Controller
        private readonly IApiService _apiService;

        public NewReportController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Index", "Login");

            var request = new ReportTemplateListRequest
            {
                PageNumber = page,
                PageSize = pageSize,
                Query = new ReportTemplateQueryModel() // boş filtre
            };

            var data = await _apiService.GetReportTemplatesAsync(request, token);
            ViewBag.TotalCount = data.TotalCount;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            return View(data.Items);
        }
    }
}
