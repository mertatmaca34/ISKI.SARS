using Newtonsoft.Json;

namespace ISKI.SARS.WebUI.Models
{

    public class NewReportFromTemplateViewModel
    {
        public int TemplateId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string OpcEndpoint { get; set; } = string.Empty;
        public int PullInterval { get; set; }

        public List<ReportTemplateTagItem> SelectedTags { get; set; } = new();
        public ReportTemplateListItem SelectedTemplate { get; set; } = new();
        public List<ReportTemplateTagItem> AllTags { get; set; } = new();

        public ReportTemplateQueryModel Query { get; set; } = new();
        public List<ReportTemplateListItem> Items { get; set; } = new();
    }


    class ReportTemplateTagListRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public ReportTemplateQueryModel Query { get; set; } = new();
    }

    public class ReportTemplateTagListResponse
    {
        public List<ReportTemplateTagItem> Items { get; set; } = new();
        public int TotalCount { get; set; }
    }

    public class ReportTemplateTagItem
    {
        public string TagName { get; set; }
        public string TagNodeId { get; set; }
    }
}
