using ISKI.SARS.WebUI.Common.ViewModels;
using Newtonsoft.Json;

namespace ISKI.SARS.WebUI.Areas.NewReport.ViewModels
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
}
