using ISKI.SARS.WebUI.Features.NewReport.Models;
using ISKI.SARS.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.WebUI.Features.NewReport
{
    public class NewReportController : Controller
    {
        private readonly IApiService _apiService;

        public NewReportController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? name, string? startDate, string? endDate, string? sortField, string? sortDirection)
        {
            var token = HttpContext.Session.GetString("AccessToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Index", "Login");

            // ViewBag ile filtreleri geri aktar
            ViewBag.NameFilter = name;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.SortField = sortField;
            ViewBag.SortDirection = sortDirection;

            var query = new ReportTemplateQueryModel();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Filters.Add(new FilterModel
                {
                    Field = "name",
                    Operator = "contains",
                    Value = name
                });
            }

            if (!string.IsNullOrWhiteSpace(startDate) && !string.IsNullOrWhiteSpace(endDate))
            {
                query.Filters.Add(new FilterModel
                {
                    Field = "createdDate",
                    Operator = "between",
                    Value = $"{startDate},{endDate}"
                });
            }

            if (!string.IsNullOrWhiteSpace(sortField) && !string.IsNullOrWhiteSpace(sortDirection))
            {
                query.Sorts.Add(new SortModel
                {
                    Field = sortField,
                    Direction = sortDirection
                });
            }

            var request = new ReportTemplateListRequest
            {
                PageNumber = 1,
                PageSize = 50,
                Query = query
            };

            var result = await _apiService.GetReportTemplateListAsync(request, token);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFromTemplate(ReportTemplateListItem model)
        {
            var token = HttpContext.Session.GetString("AccessToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Index", "Login");

            var request = new ReportTemplateTagListRequest
            {
                PageNumber = 1,
                PageSize = 100,
                Query = new ReportTemplateQueryModel
                {
                    Filters =
                    [
                        new FilterModel
                        {
                            Field = "reportTemplateId",
                            Operator = "eq",
                            Value = model.Id.ToString()
                        }
                    ]
                }
            };

            var tags = await _apiService.GetReportTemplateTagListAsync(request, token);

            var viewModel = new NewReportFromTemplateViewModel
            {
                SelectedTemplate = model,
                AllTags = tags,
                SelectedTags = new List<ReportTemplateTagItem>()
            };

            return View(viewModel);
        }

    }
}
