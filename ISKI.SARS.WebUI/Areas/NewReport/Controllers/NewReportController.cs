using ISKI.SARS.WebUI.Areas.NewReport.ViewModels;
using ISKI.SARS.WebUI.Common.ViewModels;
using ISKI.SARS.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.WebUI.Areas.NewReport.Controllers
{
    [Area("NewReport")]
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
                return RedirectToAction("Index", "Login", new { area = "Login" });

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
                return RedirectToAction("Index", "Login", new { area = "Login" });

            // TODO: Replace temporary tags with service call when API is available
            var tags = new List<ReportTemplateTagItem>
            {
                new ReportTemplateTagItem
                {
                    Id = 1,
                    TagName = "AgvaDesarjDebi",
                    TagNodeId = "sd213k1l4n"
                },
                new ReportTemplateTagItem
                {
                    Id = 2,
                    TagName = "AgvaSeviye",
                    TagNodeId = "as465k9h8g"
                },
                new ReportTemplateTagItem
                {
                    Id = 3,
                    TagName = "BeykozDebi",
                    TagNodeId = "bk123z4p8r"
                },
                new ReportTemplateTagItem
                {
                    Id = 4,
                    TagName = "BeykozSeviye",
                    TagNodeId = "bk456g7m2q"
                },
                new ReportTemplateTagItem
                {
                    Id = 5,
                    TagName = "KadikoyBasinc",
                    TagNodeId = "kd789a1s0d"
                },
                new ReportTemplateTagItem
                {
                    Id = 6,
                    TagName = "KadikoySicaklik",
                    TagNodeId = "kd098d3f5g"
                },
                new ReportTemplateTagItem
                {
                    Id = 7,
                    TagName = "UmraniyeDebi",
                    TagNodeId = "um234v6b9c"
                },
                new ReportTemplateTagItem
                {
                    Id = 8,
                    TagName = "UmraniyeSeviye",
                    TagNodeId = "um345x7n8y"
                },
                new ReportTemplateTagItem
                {
                    Id = 9,
                    TagName = "AtasehirDebi",
                    TagNodeId = "at567h4k9r"
                },
                new ReportTemplateTagItem
                {
                    Id = 10,
                    TagName = "AtasehirBasinc",
                    TagNodeId = "at678p1d2q"
                }
            };

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
