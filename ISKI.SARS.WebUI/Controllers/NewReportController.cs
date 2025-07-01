using ISKI.SARS.WebUI.Models;
using ISKI.SARS.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.WebUI.Controllers
{
    public class NewReportController : Controller
    {
        private readonly IApiService _apiService;

        public NewReportController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            string? name,
            DateTime? startDate,
            DateTime? endDate,
            string sortField = "CreatedDate",
            string sortDirection = "desc",
            int page = 1,
            int pageSize = 10)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Index", "Login");

            var query = new ReportTemplateQueryModel();

            if (!string.IsNullOrWhiteSpace(name))
                query.Filters.Add(new FilterModel { Field = "Name", Operator = "contains", Value = name });

            if (startDate.HasValue)
                query.Filters.Add(new FilterModel { Field = "CreatedDate", Operator = ">=", Value = startDate.Value.ToString("yyyy-MM-dd") });

            if (endDate.HasValue)
                query.Filters.Add(new FilterModel { Field = "CreatedDate", Operator = "<=", Value = endDate.Value.ToString("yyyy-MM-dd") });

            if (!string.IsNullOrWhiteSpace(sortField))
                query.Sorts.Add(new SortModel { Field = sortField, Direction = sortDirection });

            var request = new ReportTemplateListRequest
            {
                PageNumber = page,
                PageSize = pageSize,
                Query = query
            };

            var data = await _apiService.GetReportTemplatesAsync(request, token);

            var vm = new ReportTemplateListViewModel
            {
                Items = data.Items,
                Page = page,
                PageSize = pageSize,
                TotalCount = data.TotalCount,
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                SortField = sortField,
                SortDirection = sortDirection
            };

            return View(vm);
        }
    }
}
