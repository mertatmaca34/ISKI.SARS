using System;
using System.Collections.Generic;

namespace ISKI.SARS.WebUI.Models
{
    public class ReportTemplateListViewModel
    {
        public List<ReportTemplateListItem> Items { get; set; } = new();
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string SortField { get; set; } = "CreatedDate";
        public string SortDirection { get; set; } = "desc";
    }
}
