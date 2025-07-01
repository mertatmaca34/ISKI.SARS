namespace ISKI.SARS.WebUI.Models
{
    public class FilterModel
    {
        public string Field { get; set; } = string.Empty;
        public string Operator { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class SortModel
    {
        public string Field { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
    }

    public class ReportTemplateQueryModel
    {
        public List<FilterModel> Filters { get; set; } = new();
        public List<SortModel> Sorts { get; set; } = new();
    }

    public class ReportTemplateListRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public ReportTemplateQueryModel Query { get; set; } = new();
    }

    public class ReportTemplateListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string OpcEndpoint { get; set; } = string.Empty;
        public int PullInterval { get; set; }
    }


    public class ReportTemplateListResponse
    {
        public List<ReportTemplateListItem> Items { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
