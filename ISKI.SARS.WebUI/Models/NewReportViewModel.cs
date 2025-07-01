using Newtonsoft.Json;

namespace ISKI.SARS.WebUI.Models
{
    public class ReportTemplateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OpcEndpoint { get; set; }
        public int PullInterval { get; set; }
    }

    public class NewReportViewModel
    {
        public List<ReportTemplateDto> ReportTemplates { get; set; } = new();
    }
    public class PagedResponse<T>
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }
    }
}
